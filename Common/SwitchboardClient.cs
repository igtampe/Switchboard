﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Igtampe.Switchboard.Common {

    /// <summary>Holds one (1) Switchboard Client. Part of a balanced lunch.</summary>
    public class SwitchboardClient {

        //------------------------------[Variables]------------------------------

        /// <summary>Main TCP Client</summary>
        private TcpClient Client;

        /// <summary>haha River like a larger stream ahahaha</summary>
        private NetworkStream River;

        /// <summary>Whether or not the client is connected to the server.</summary>
        public bool Connected => Client.Connected;

        /// <summary>Whether or not the client has data available to read.</summary>
        public bool Available => River.DataAvailable;

        /// <summary>counter for the animation</summary>
        private static int ConnectionStatus = 0;

        /// <summary>ID of this connection</summary>
        public int ID { get; protected set; } = -1;

        /// <summary>IP of the remote server.</summary>
        public string IP { get; private set; }

        /// <summary>Port of the remote server</summary>
        public int Port { get; private set; }

        /// <summary>Indicates whether or not this is being run in a console.</summary>
        private readonly bool ConsoleMode = false;

        /// <summary>
        /// Indicates whether the client is busy or not.
        /// Should help prevent a user/programmer from attempting to send/receive data when the client is already trying to send/receive data.
        /// </summary>
        public bool Busy { get; private set; }

        /// <summary>Result of a login attempt.</summary>
        public enum LoginResult {
            /// <summary>Successfully logged in</summary>
            SUCCESS = 0,

            /// <summary>Invalid login credentials were sent</summary>
            INVALID = 1,

            /// <summary>Already logged in on this connection</summary>
            ALREADY = 2,

            /// <summary>Already logged in on another connection</summary>
            OTHERLOCALE=3
        }

        /// <summary>Result of a Reconnection Attempt</summary>
        public enum ReconnectResult { 
            /// <summary>Successfully reconnected</summary>
            SUCCESS = 0,

            /// <summary>Rebind was unsuccessful, but a connection was established</summary>
            NOREBIND = 1,

            /// <summary>Unable to connect to the server</summary>
            NOCONNECT = 2,

            /// <summary>There is no saved ID. A Reconnection is impossible.</summary>
            NOTPOSSIBLE=3
        }

        //------------------------------[Constructor]------------------------------

        /// <summary>Generates a Switchboard Client in non-console mode, but does not start it.</summary>
        public SwitchboardClient(string IP,int Port):this(IP,Port,false) { }

        /// <summary>Generates a Switchboard Client, but does not start it</summary>
        public SwitchboardClient(string IP, int Port,bool ConsoleMode) {
            this.IP = IP;
            this.Port = Port;
            this.ConsoleMode = ConsoleMode;
        }

        //------------------------------[Functions]------------------------------

        /// <summary>Initiate the connection without connectanim</summary>
        /// <returns>True if it managed to connect, false otherwise</returns>
        public bool Connect() { return Connect(false); }

        /// <summary>Initiate the connection</summary>
        /// <param name="ShowAnim">Select true to show the connection animation on the console. CRASHES FORM APPS</param>
        /// <returns>True if it managed to connect, false otherwise</returns>
        public bool Connect(bool ShowAnim) {

            //Attempt to connect.
            Console.Write("Attempting to connect to " + IP + ":" + Port + " ");
            Client = new TcpClient();
            Client.ConnectAsync(IP,Port);

            //15 second time out
            for(int i = 0; i < 30; i++) {
                if(ShowAnim) { ConnectAnim(); }
                if(Client.Connected) { break; }
                Thread.Sleep(500);
            }
            
            //Verify if we've connected.
            if(!Client.Connected) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nERROR: Could not connect to server. Maybe it's busy?");
                Console.ForegroundColor = ConsoleColor.Gray;
                return false ;
            }

            //Neat we connected!
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nConnected to the server!\n\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            River = Client.GetStream();

            //See if we can reconnect
            if(int.TryParse(SendReceive("ID"),out int ID1)) {Console.WriteLine("Connection ID: " + ID1 + "\n");}

            ID = ID1;

            //Also display the welcome message
            Console.WriteLine(SendReceive("WELCOME"));


            return true;
        }

        /// <summary>Reconnects to a session on a Switchboard Server if the connection was interrupted unexpectedly</summary>
        /// <returns>True if it was possible, false otherwise</returns>
        public ReconnectResult Reconnect() {
            if(ID == -1) { return ReconnectResult.NOTPOSSIBLE; }

            int ReconnectID = ID;
            Console.WriteLine("\n\nAttempting to reconnect to connection with ID " + ReconnectID + "\n");

            if(Connect()) {

                Console.WriteLine("Attempting to rebind connection with ID " + ReconnectID + " to this connection\n");
                string RebindResult = SendReceive("REBIND " + ReconnectID);
                if(RebindResult == "OK") {

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Rebind successful! Connection re-established\n");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    return ReconnectResult.SUCCESS; 
                
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Rebind unsuccessful. " + RebindResult + "\n");
                Console.ForegroundColor = ConsoleColor.Gray;

                return ReconnectResult.NOREBIND;

            }

            return ReconnectResult.NOCONNECT;
        }

        /// <summary>Close the Client's connection</summary>
        public void Close() {
            if(!Connected) { return; } //Make sure attempting to close an already closed connection doesn't cause an exception. That's kinda bobo.
            //Send CLOSE to the server, closing that side.
            try { Send("CLOSE",false) ; } catch(IOException) { } //try to close remotely. This may fail because of an IOException so if algo just shhh.

            //I mean that should close the TCPClient and the stream, no?
            River.Close();
            Client.Close();

        }

        /// <summary>Send data to the switchboard server, and retrieve a response</summary>
        public string SendReceive(string Data) {
            Send(Data,true);; 
            return Receive();
        }

        /// <summary>Sends data to the Server</summary>
        /// <param name="data">Data to send</param>
        /// <param name="KeepBusy">Whether or not to keep the client busy (in case you're going to receive data right after sending it)</param>
        public void Send(string data,bool KeepBusy) {
            if(!Connected) { throw new InvalidOperationException("This client is not connected right now!"); }
            Busy = true;
            byte[] Bytes = Encoding.ASCII.GetBytes(data); //Convert the string to bytes.
            River.Write(Bytes,0,Bytes.Length); //send the bytes
            if(!KeepBusy) { Busy = false; }
        }

        /// <summary>Only receive data</summary>
        public string Receive() {
            if(!Connected) { throw new InvalidOperationException("This client is not connected right now!"); }
            Busy = true;

            //10 second time out.
            for(int X = 0; X < 100; X++) {
                if(Available) { break; }
                if(ConsoleMode) {
                    if(Console.KeyAvailable) { if(Console.ReadKey().Key == ConsoleKey.Escape) { return "BREAK"; } } //This is to allow a user to breka the connection
                }
                Thread.Sleep(100);
            }

            if(!Available) { throw new TimeoutException("Server did not respond in 10 seconds. Probably CLOSE the connection"); }

            List<byte> Bytes = new List<byte>();
            while(Available) { Bytes.Add((byte)(River.ReadByte())); } //Get all the bytes in a nice little array.
            Busy = false;
            return Encoding.ASCII.GetString(Bytes.ToArray()); //convert the array of bytes back into a neat little bit of text, and return it.
        }

        /// <summary>Login on the server</summary>
        /// <returns>The appropriate login result</returns>
        public LoginResult Login(string Username, string Password) {
            switch(SendReceive("LOGIN " + Username + " " + Password)) {
                case "0":
                    return LoginResult.SUCCESS;
                case "1":
                    return LoginResult.INVALID;
                case "2":
                    return LoginResult.ALREADY;
                case "3":
                    return LoginResult.OTHERLOCALE;
                default:
                    return LoginResult.INVALID;
            }

        }

        /// <summary>Logout on the server</summary>
        /// <returns>True if logout was successful, false otherwise.</returns>
        public bool Logout() {return SendReceive("Logout")=="1";}

        /// <summary>Spinner animation</summary>
        public static void ConnectAnim() {
            Console.SetCursorPosition(Console.CursorLeft-1,Console.CursorTop); //Move the cursor a little back
            string Output = ""; //This will hold our output
            switch(ConnectionStatus) {
                case 0:
                    Output = "/";
                    break;
                case 1:
                    Output = "-";
                    break;
                case 2:
                    Output = "\\"; //two because we need to ecapse.
                    break;
                case 3:
                    Output = "|";
                    ConnectionStatus = -1; //negative one so it is incremented back to 0
                    break;
                default:
                    break;
            }

            ConnectionStatus++; //Increment Connection Status
            Console.Write(Output); //Render the spinner.
        }


    }
}
