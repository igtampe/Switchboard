using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Switchboard {

    public partial class SwitchboardServer {
        /// <summary>Holds a Switchboard Connection</summary>
        public class SwitchboardConnection {
            //SwitchboarConnection needs access to some parts of the headserver, so it has to be nested. Shhh.

            //~~~~~~~~~~~~~~{Variables}~~~~~~~~~~~~~~

            /// <summary>Server this connection belongs to.</summary>
            private readonly SwitchboardServer HeadServer;

            private readonly DateTime ConnectedSince;
            private readonly IPEndPoint IP;
            private SwitchboardUser User;

            private readonly NetworkStream River;
            private readonly Socket TheSocket;

            private string ConsolePreview;
            public bool IsConnected => TheSocket.Connected;

            //~~~~~~~~~~~~~~{Constructor}~~~~~~~~~~~~~~

            public SwitchboardConnection(SwitchboardServer HeadServer,Socket MainSocket) {
            
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

            //~~~~~~~~~~~~~~{Functions}~~~~~~~~~~~~~~

            /// <summary>Ticks this connection. Essentially processes any input it may need to parse.</summary>
            public void Tick() {

                //If there's data available.
                if(IsConnected && River.DataAvailable) {
                    HeadServer.ToLog("Attempting to read message from " + IP.Address.ToString());

                    //Save all the bytes to an array
                    List<byte> Bytes = new List<byte>();
                    while(River.DataAvailable) { Bytes.Add((byte)River.ReadByte()); }

                    //Parse that array of bytes as an ASCII encoded string
                    String Command = System.Text.Encoding.ASCII.GetString(Bytes.ToArray());

                    //Handle VBNullChar or \0 in this case.
                    Command = Command.Replace("\0","");

                    //Add this to the list of commands.
                    ConsolePreview += IP.Address + "> " + Command;

                    //Now let's try to parse it.
                    String Reply = "";

                    String[] CommandSplit = Command.Split(' ');
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
                                        HeadServer.TheForm.ServerBWorker.ReportProgress(0); //Refresh the list, this connection has logged in
                                        Reply = "0"; //SUCCESS
                                    }
                                } else {
                                    Reply = "1"; //INVALID
                                }
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
                            Close();
                            return;
                        default:
                            if(!HeadServer.AllowAnonymous && User == HeadServer.AnonymousUser) { Reply = "You're unauthorized to run any other commands."; } else {
                                foreach(SwitchboardExtension extension in HeadServer.Extensions) {
                                    if(!String.IsNullOrEmpty(Reply)) { break; }
                                    Reply = extension.Parse(ref User,Command);
                                }
                                if(string.IsNullOrEmpty(Reply)) { Reply = "Could not parse command [" + Command + "]"; }
                            }
                            break;
                    }

                    //Time to return whatever it is we got.
                    Send(Reply);
                    //and we're done.

                }
            }

            /// <summary>Sends data to the client of this connection</summary>
            public void Send(String Data) {
                Byte[] ReturnBytes = System.Text.Encoding.ASCII.GetBytes(Data);
                River.Write(ReturnBytes,0,ReturnBytes.Length);
                ConsolePreview += Environment.NewLine + Data.Replace("\n",Environment.NewLine) + Environment.NewLine + Environment.NewLine;
            }

            /// <summary>Close the connection</summary>
            public void Close() {
                if(User != HeadServer.AnonymousUser) { User.SetOnline(false); }
                River.Close();
                TheSocket.Close();
            }

        
        }


    }


}
