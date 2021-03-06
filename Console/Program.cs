﻿using System;
using Igtampe.Switchboard.Console.Graphics;
using Igtampe.Switchboard.Common;
using Igtampe.BasicRender;

namespace Igtampe.Switchboard.Console {
    /// <summary>Holds the Switchboard Client</summary>
    public static class Program {

        /// <summary>Prefix for the "Command Prompt"</summary>
        public static string Prefix = "DISCONNECTED";

        /// <summary>The SwitchboardClient object</summary>
        public static SwitchboardClient MainClient;

        static void Main(string[] args) {

            //Set title and clear the screen
            System.Console.Title = "Switchboard Console: Disconnected";
            DrawHeader();

            if(args.Length > 0) {
                Parse("CONNECT " + args[0]);
                if(args.Length > 2) {Parse("LOGIN " + args[1] + " " + args[2]);}
            }

            //The Main Loop
            while(true) {Parse(PromptInput());}

        }

        /// <summary>Locally parses a prompt</summary>
        /// <param name="prompt"></param>
        public static void Parse(string prompt) {

            string[] PromptSplit = prompt.Split(' ');

            switch(PromptSplit[0].ToUpper()) {
                case "CONNECT":
                    //attempt to connect to a Server
                    if(MainClient != null) { RenderUtils.Echo("There's already an ongoing connection! Close this one to open another one."); break; } //Make sure we're not already connected
                    if(PromptSplit.Length == 2) {
                        string[] IPPortSplit = PromptSplit[1].Split(':'); //Split the IP and port
                        string IP = IPPortSplit[0];
                        string Port;
                        if(IPPortSplit.Length == 1) { Port = "909"; } else { Port = IPPortSplit[1]; }

                        MainClient = new SwitchboardClient(IP,int.Parse(Port),true); //Create client
                        if(MainClient.Connect(true)) { UpdatePrefix(IP); }  //Initialize it, and if we manage to connect, setup the prefix and title.
                        else { MainClient = null; } //If not reset mainclient to null.

                    } else { RenderUtils.Echo("Improper connection request. Try something like 127.0.0.1:909"); }
                    break;
                case "CLOSE":
                    //Close the connection.
                    if(MainClient == null) { RenderUtils.Echo("No connection to close"); }  //Make sure we cannot close if there is no connection.
                    else { MainClient.Close(); Prefix = "DISCONNECTED"; System.Console.Title = "Switchboard Console: Disconnected"; MainClient = null; } //Close the connection.
                    break;
                case "READ":
                    //Attempt to read any data that may be there to read.
                    if(MainClient == null) { RenderUtils.Echo("No connection to read from!"); break; }
                    if(!MainClient.Available) {
                        RenderUtils.Echo("No data is available! Wait for data? ");
                        if(!YesNo()) { break; } //Display a warning if there is no data to read, and if the user wants to read the data.
                    }
                    try { RenderUtils.Echo(MainClient.Receive()); } catch(Exception) { Draw.Sprite("There was an error sending/receiving this command. Perhaps the server was disconnected?",ConsoleColor.Black,ConsoleColor.Red); }
                    //Read the data and display it.
                    break;
                case "CLS":
                    //Clear the screen.
                    DrawHeader();
                    break;
                case "LOGIN":
                    if(MainClient==null ||MainClient?.Connected == false) { RenderUtils.Echo("Client is not connected! Connect using CONNECT [IP]:[PORT]"); break; }
                    if(PromptSplit.Length != 3) { RenderUtils.Echo("Invalid Login Credentials"); break; }
                    //now let's log in.
                    switch(MainClient.Login(PromptSplit[1],PromptSplit[2])) {
                        case SwitchboardClient.LoginResult.ALREADY:
                            RenderUtils.Echo("Already logged in");
                            break;
                        case SwitchboardClient.LoginResult.INVALID:
                            RenderUtils.Echo("Invalid Login Credentials");
                            break;
                        case SwitchboardClient.LoginResult.OTHERLOCALE:
                            RenderUtils.Echo("Already logged in on another connection");
                            break;
                        case SwitchboardClient.LoginResult.SUCCESS:
                            RenderUtils.Echo("Successfully logged in as " + PromptSplit[1]);
                            UpdatePrefix(PromptSplit[1] + "@" + MainClient.IP);
                            break;
                        default:
                            break;
                    }
                    break;
                case "LOGOUT":

                    if(MainClient==null || MainClient?.Connected == false) { RenderUtils.Echo("Client is not connected! Connect using CONNECT [IP]:[PORT]"); break; }

                    //Try to log out.
                    if(MainClient.Logout()) {
                        RenderUtils.Echo("Logged out successfully!");
                        UpdatePrefix(MainClient.IP);
                    } else { RenderUtils.Echo("Unable to log out. You're already logged out!"); }

                    break;
                default:

                    //Try to send the commend to the server.
                    if(MainClient?.Connected == false) {

                        if(MainClient.ID == -1) { 
                            RenderUtils.Echo("Connection to the server has been interrupted unexpectedly and cannot be automatically reconnected.");
                            MainClient = null;
                        }

                        RenderUtils.Echo("Connection to the server has been interrupted unexpectedly. Attempt reconnect? ");
                        if(YesNo()) {

                            switch(MainClient.Reconnect()) {
                                case SwitchboardClient.ReconnectResult.SUCCESS:
                                    break;
                                case SwitchboardClient.ReconnectResult.NOREBIND:
                                    if(Prefix.Contains("@")) { UpdatePrefix(Prefix.Split('@')[1]);} //remove the login
                                    break;
                                case SwitchboardClient.ReconnectResult.NOCONNECT:
                                    //Return. Give the user a chance to try *again*
                                    return;
                                case SwitchboardClient.ReconnectResult.NOTPOSSIBLE:
                                    //this shouldn't happen but ok
                                    return;
                                default:
                                    break;
                            }

                        } else { MainClient = null; }
                        RenderUtils.Echo("\n\n");
                    }

                    if(MainClient == null) { RenderUtils.Echo("Client is not connected! Connect using CONNECT [IP]:[PORT]"); }  //warn the user if there's no connection.
                    else {
                        //The console doesn't need to check if the client is busy since there are no other threads, but if you're doing this with a background worker and are trying to send
                        //anything maybe check that.
                        try { RenderUtils.Echo(MainClient.SendReceive(prompt)); } catch(Exception E) { Draw.Sprite("There was an error sending/receiving this command. Perhaps the server was disconnected?\n\n" + E.Message + "\n" + E.StackTrace,ConsoleColor.Black,ConsoleColor.Red); }
                    }
                    break;
            }
        }

        /// <summary>Updates the connection prefix.</summary>
        public static void UpdatePrefix(string NewPrefix) {
            Prefix = NewPrefix;
            System.Console.Title = "Switchboard Console: " + Prefix;
        }

        /// <summary>Clears the screen and draws the header</summary>
        public static void DrawHeader() {
            System.Console.Clear();

            //Draw the header
            SwitchboardLogo Logo = new SwitchboardLogo();
            Logo.Draw(2,1);
            Draw.Sprite("Switchboard Console [Version 2.0]",System.Console.BackgroundColor,ConsoleColor.White,3 + Logo.GetWidth(),2);
            Draw.Sprite("(C)2020 Chopo, No Rights Reserved",System.Console.BackgroundColor,ConsoleColor.White,3 + Logo.GetWidth(),3);

            //Set the position, and draw a neat little message
            RenderUtils.SetPos(0,2 + Logo.GetHeight());
            RenderUtils.Echo("Welcome to the Switchboard Console! Type CONNECT [IP]:[PORT] to connect to a server! \n\n");
        }


        //Some of these maybe should be moved to BasicRender tbh but eh for now.

        /// <summary>Prompts the user for input</summary>
        public static string PromptInput() {
            RenderUtils.Echo("\n\n"+Prefix+"> ");
            return System.Console.ReadLine();
        }

        /// <summary>Prompts the user with Y/N.</summary>
        /// <returns>True if the user hits Y, false otherwise.</returns>
        public static bool YesNo() {
            RenderUtils.Echo("(Y/N) ");
            return System.Console.ReadKey().Key == ConsoleKey.Y;
        }

    }
}
