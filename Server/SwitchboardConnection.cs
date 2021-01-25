using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Igtampe.Switchboard.Server {

    internal partial class SwitchboardServer {
        /// <summary>Holds a Switchboard Connection</summary>
        public class SwitchboardConnection {
            //SwitchboarConnection needs access to some parts of the headserver, so it has to be nested. Shhh.

            //~~~~~~~~~~~~~~{Variables}~~~~~~~~~~~~~~

            /// <summary>Server this connection belongs to.</summary>
            private readonly SwitchboardServer HeadServer;

            private readonly DateTime ConnectedSince;
            private IPEndPoint IP;
            private SwitchboardUser User;

            public readonly int ID;

            private NetworkStream River;
            private Socket TheSocket;

            private string ConsolePreview;
            private string LastMessage="";

            public bool IsConnected => TheSocket.Connected;
            public bool Busy { get; protected set; } = false;

            private Thread TickThread;

            //~~~~~~~~~~~~~~{Constructor}~~~~~~~~~~~~~~

            public SwitchboardConnection(SwitchboardServer HeadServer,Socket MainSocket, int ID) {

                this.ID = ID;

                ConnectedSince = DateTime.Now;
                IP = (IPEndPoint)MainSocket.RemoteEndPoint;
                River = new NetworkStream(MainSocket);
                TheSocket = MainSocket;

                this.HeadServer = HeadServer;
                HeadServer.ToLog("New user connected from " + IP.Address.ToString());

                User = HeadServer.AnonymousUser;
                ConsolePreview = "";

            }

            //~~~~~~~~~~~~~~{Getters}~~~~~~~~~~~~~~
            public string GetConsolePreview() { return ConsolePreview; }
            public SwitchboardUser GetUser() { return User; }
            public DateTime GetConnectedSince() { return ConnectedSince; }
            public IPEndPoint GetIP() { return IP; }

            //~~~~~~~~~~~~~~{Setter}~~~~~~~~~~~~~~

            /// <summary>Merges two connections, grabbing the socket from this conneciton</summary>
            /// <param name="OtherConnection"></param>
            public void AbsorbConnection(SwitchboardConnection OtherConnection) {

                while(Busy) { } //Wait for *this* connection to not be busy

                TickThread.Abort(); //Stop the thread

                //Close this connection's river and socket
                River.Close();
                TheSocket.Close();

                //Move everything over
                River = OtherConnection.River;
                TheSocket = OtherConnection.TheSocket;
                IP = OtherConnection.IP;

                //Send OK
                Send("OK",false);

                //Start async again
                StartAsync();
                
                //Log it
                HeadServer.ToLog("User from " + IP.Address.ToString() + " reconnected from " + OtherConnection.IP.Address.ToString());

                //Remove the other connection from the list of connections
                HeadServer.Connections.Remove(OtherConnection.ID);

                //Look at how far back we can go
                HeadServer.TheForm.ServerBWorker.ReportProgress(0); //Refresh the main form's listview.

                //Stop the other tickthread. This will stop *this* operation, so it's the last one to go.
                OtherConnection.TickThread.Abort();
            }

            //~~~~~~~~~~~~~~{Functions}~~~~~~~~~~~~~~

            /// <summary>Ticks this connection. Essentially processes any input it may need to parse.</summary>
            public void Tick() {

                //If there's data available.
                if(IsConnected && River.DataAvailable) {
                    //HeadServer.ToLog("Attempting to read message from " + IP.Address.ToString()); //no mas

                    //Save all the bytes to an array
                    List<byte> Bytes = new List<byte>();
                    while(River.DataAvailable) { Bytes.Add((byte)River.ReadByte()); }

                    //Parse that array of bytes as a ASCII encoded string
                    string Command = Encoding.ASCII.GetString(Bytes.ToArray());
                    
                    //Handle VBNullChar or \0 in this case.
                    Command = Command.Replace("\0","");

                    //Add this to the list of commands.
                    ConsolePreview += IP.Address + "> " + Command;

                    //Now let's try to parse it.
                    string Reply = "";

                    string[] CommandSplit = Command.Split(' ');
                    switch(CommandSplit[0].ToUpper()) {
                        case "WELCOME":
                            Reply = HeadServer.GetWelcomeMessage();
                            break;
                        case "LOGIN":
                            if(User != HeadServer.AnonymousUser) { Reply = "2"; } //ALREADY
                            else if(CommandSplit.Length != 3) { Reply = "1"; }  //INVALID
                            else {
                                SwitchboardUser myUser = null;

                                //Find the user.
                                foreach(SwitchboardUser User in HeadServer.Users) { if(User.GetUsername().ToUpper() == CommandSplit[1].ToUpper()) { myUser = User; break; } }

                                if(myUser != null && myUser.VerifyPassword(CommandSplit[2])) {
                                    if(myUser.IsOnline() && !HeadServer.AllowMultiLogin) { Reply = "3"; }  //OTHERLOCALE
                                    else {
                                        User = myUser;
                                        User.SetOnline(true);

                                        //Refresh the list, this connection has logged in
                                        try {HeadServer.TheForm.ServerBWorker.ReportProgress(0); } catch(Exception) {}
                                        //In a try because this may cause a problem if two users try to log in at the same time. The user will still sign in though, so this would sitll
                                        //refresh anyways, so no need to worry.

                                        Reply = "0"; //SUCCESS
                                    }
                                } else {Reply = "1"; } //INVALID
                            }
                            break;
                        case "LOGOUT":
                            if(User == HeadServer.AnonymousUser) { Reply = "0"; } else {
                                User.SetOnline(false);
                                User = HeadServer.AnonymousUser;
                                HeadServer.TheForm.ServerBWorker.ReportProgress(0); //Refresh the list, this connection has logged out.
                                Reply = "1";
                            }
                            break;
                        case "CLOSE":
                            Close(true);
                            return;
                        case "ID":
                            Reply = ID + "";
                            break;
                        case "REBIND":

                            //Check if the rebind exist
                            try {
                                int OtherConnectionID = int.Parse(CommandSplit[1]);

                                if(OtherConnectionID == ID) { 
                                    Reply = "Could not rebind connection " + ID + ". Cannot rebind connection to itself";
                                    break;
                                }

                                if(!HeadServer.Connections.ContainsKey(OtherConnectionID)) {
                                    Reply = "Could not rebind connection " + OtherConnectionID + ". It was not found.";
                                    break;
                                }

                                HeadServer.Connections[OtherConnectionID].AbsorbConnection(this);

                                //Absorbing this connection should stop the thread but just in case
                                TickThread.Abort();

                            } catch(Exception E) {Reply = "An Exception Occurred:\n\n" + E.Message + "\n" + E.StackTrace;}

                            break;
                        case "REPEAT":
                            Reply = LastMessage;
                            break;
                        default:
                            if(!HeadServer.AllowAnonymous && User == HeadServer.AnonymousUser) { Reply = "You're unauthorized to run any other commands."; } else {
                                foreach(SwitchboardExtension extension in HeadServer.Extensions) {
                                    if(!string.IsNullOrEmpty(Reply)) { break; }
                                    Reply = extension.Parse(ref User,Command);
                                }
                                if(string.IsNullOrEmpty(Reply)) { Reply = "Could not parse command [" + Command + "]"; }
                            }
                            break;
                    }

                    if(String.IsNullOrWhiteSpace(Reply)) { Reply = "An unspecified error occured"; }

                    //Time to return whatever it is we got.
                    Send(Reply);
                    //and we're done.

                }
            }

            /// <summary>Sends data to the client of this connection, updating last message</summary>
            /// <param name="Data"></param>
            public void Send(String Data) { Send(Data,true); }

            /// <summary>Sends data to the client of this connection</summary>
            public void Send(String Data, bool UpdateLastMessage) {
                Byte[] ReturnBytes = Encoding.ASCII.GetBytes(Data);
                River.Write(ReturnBytes,0,ReturnBytes.Length);
                ConsolePreview += Environment.NewLine + Data.Replace("\n",Environment.NewLine) + Environment.NewLine + Environment.NewLine;
                if(UpdateLastMessage) { LastMessage = Data; }
            }

            public void Close() { Close(false); }

            /// <summary>Close the connection</summary>
            public void Close(bool force) {
                while(Busy && !force) { } //Wait for this cosa to not be busy
                if(User != HeadServer.AnonymousUser) { User.SetOnline(false); }
                River.Close();
                TheSocket.Close();
                HeadServer.ToLog("User from " + IP.Address.ToString() + " Disconnected."); //log disconnections.
                TickThread.Abort();
            }

            public void AsyncTick() {

                while(true) {
                    Busy = true;
                    Tick();
                    if(!IsConnected) { return; }
                    Busy = false;
                    Thread.Sleep(100); //every 100 ms so the server has a chance to reply 
                }

            }

            public void StartAsync() {
                if(TickThread?.IsAlive==true) { throw new InvalidOperationException("Connection is already ticking"); }
                TickThread = new Thread(AsyncTick);
                TickThread.Start();
            }

        }
    }
}
