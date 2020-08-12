using SwitchboardServerForm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Switchboard {

    /// <summary>Holds one (1) Switchboard Server. Part of a complete breakfast</summary>
    public partial class SwitchboardServer {

        //------------------------------[Variables]------------------------------

        /// <summary>The "Pen" that will write to logs.</summary>
        protected StreamWriter LogPen;

        /// <summary>List that holds active connections</summary>
        protected List<SwitchboardConnection> Connections;

        /// <summary>List that holds extensions</summary>
        protected List<SwitchboardExtension> Extensions;

        /// <summary>List that holds all of the users</summary>
        protected List<SwitchboardUser> Users;

        /// <summary>Allow anonymous users</summary>
        protected bool AllowAnonymous;

        /// <summary>Allows users to login from more than one connection</summary>
        protected bool AllowMultiLogin;

        /// <summary>The Default, Anonymous User</summary>
        protected SwitchboardUser AnonymousUser;

        /// <summary>Welcome message that's sent to a user when they connect, and when they type WELCOME</summary>
        protected String WelcomeMessage;

        /// <summary>The "Ears" of this server, that will listen for other connections.</summary>
        private readonly TcpListener Ears;

        /// <summary>Holds the main form (Mostly so we can report progress)</summary>
        private readonly MainForm TheForm;

        //------------------------------[Switchboard Main Extension]------------------------------

        /// <summary>Holds the main Switchboard Extension</summary>
        private class SwitchboardMainExtension:SwitchboardExtension {

            //~~~~~~~~~~~~~~{Variables}~~~~~~~~~~~~~~
            private readonly SwitchboardServer HeadServer;

            //~~~~~~~~~~~~~~{Constructor}~~~~~~~~~~~~~~
            public SwitchboardMainExtension(SwitchboardServer Main) : base("MAIN","1.0") {HeadServer = Main;}

            //~~~~~~~~~~~~~~{Functions}~~~~~~~~~~~~~~
            public override string Help() {
                return "Switchboard Main Extension [Version " + Version + "]\n" +
                    "\n" +
                    "Available Commands: \n" +
                    "VER                            : Displays Server Version\n" +
                    "SHOWEXTENSIONS                 : Displays all available extensions\n" +
                    "HELP [Extension]               : Displays help on the extension\n" +
                    "SETPASS (CurrentPass) (NewPas) : Sets your new password. Password must not contain spaces, or the character ~\n" +
                    "CLOSE                          : Closes the connection and disconnects you from the server \n" +
                    "LOGIN (USERNAME) (PASSWORD)    : Logs you in if you're currently anonymous\n" +
                    "LOGOUT                         : Logs you out of this terminal, maintains you connected as an anonymous user.\n" +
                    "WELCOME                        : Shows this server's welcome message" +
                    "\n" +
                    "More user options are available on the server GUI program";
            }

            public override string Parse(ref SwitchboardUser User,string Command) {
                String[] CommandSplit = Command.Split(' ');

                switch(CommandSplit[0].ToUpper()) {
                    case "VER":
                        //Return version of this server
                        return SwitchboardConfiguration.ServerName + " [Version " + SwitchboardConfiguration.ServerVersion + "]";

                    case "SHOWEXTENSIONS":
                        //Show all extensions on this server
                        String AllExtensions = HeadServer.Extensions.Count + " Extension(s)\n\n";
                        foreach(SwitchboardExtension Extension in HeadServer.Extensions) {AllExtensions += Extension.GetName() + " [Version " + Extension.GetVersion() + "]\n";}
                        return AllExtensions;

                    case "HELP":
                        //Show Server Help (Or the help of a specific command)
                        if(CommandSplit.Length == 1) { return Help(); }
                        foreach(SwitchboardExtension Extension in HeadServer.Extensions) { if(Extension.GetName().ToUpper() == CommandSplit[1].ToUpper()) { return Extension.Help(); }}
                        return "Could not find extension " + CommandSplit[1];

                    case "SETPASS":
                        //Set the password of the current user
                        if(CommandSplit.Length != 3 || Command.Contains("~")) { return "Could not update password due to invalid characters"; }
                        if(User == HeadServer.AnonymousUser) { return "cannot set password if user is not logged in"; }

                        if(User.SetPassword(CommandSplit[1],CommandSplit[2])) {
                            HeadServer.SaveUsers(); //Make sure to save all users.
                            return "Successfully updated password!"; 
                        }

                        return "Server was unable to update your password";

                    default:
                        //Return nada because we could not parse it.
                        return null;
                }

            }
        }

        //------------------------------[Constructor]------------------------------

        /// <summary>Creates and starts a Switchboard Server</summary>
        /// <param name="IP">IP to listen on</param>
        /// <param name="Port">Port to listen on</param>
        /// <param name="WelcomeMessage">Welcome message for each user.</param>
        /// <param name="AllowAnonymous">Allow Anonymous Users on this server.</param>
        public SwitchboardServer(MainForm TheForm, String IP, int Port, String WelcomeMessage, bool AllowAnonymous, bool AllowMultiLogin) {

            //Get us our pen
            LogPen = File.AppendText("SwitchboardLog.log");
            LogPen.WriteLine("\n\n"+SwitchboardConfiguration.ServerName + " [Version " + SwitchboardConfiguration.ServerVersion + "]\n\n" + "[" + DateTime.Now.ToShortDateString() + "] Starting Server...");

            //Get us the main form
            this.TheForm = TheForm;

            //Get the welcome message
            this.WelcomeMessage = WelcomeMessage;

            //Register the extensions from the Switchboard Configuration and add the default extensions.
            ToLog("Registering extensions...");
            Extensions = SwitchboardConfiguration.ServerExtensions();
            Extensions.Add(new DummyExtension());
            Extensions.Add(new SwitchboardMainExtension(this));

            //Load users
            ToLog("Loading Users...");
            Users = new List<SwitchboardUser>();
            if(File.Exists("SwitchboardUsers.txt")) {
                //Read all lines from the file
                String[] UserStrings = File.ReadAllLines("SwitchboardUsers.txt");
                
                //For each userstring, add a new user
                foreach(String UserString in UserStrings) {Users.Add(new SwitchboardUser(UserString));}
            }

            //Allow Anonymous and generate the anonymous user.
            this.AllowAnonymous = AllowAnonymous;
            AnonymousUser = new SwitchboardUser("Anonymous","",0,"");

            this.AllowMultiLogin = AllowMultiLogin;

            //Display a warning in case there are no users and we do not allow anonymous access.
            if(Users.Count == 0 && !AllowAnonymous) { ToLog("WARNING! No registered users and now annonymous access! You won't be able to actually use this server!"); }

            //Create the Connections list
            ToLog("One last thing...");
            Connections = new List<SwitchboardConnection>();

            //Finally, Actually start the server.
            ToLog("Actually starting the server...");
            Ears = new TcpListener(IPAddress.Parse(IP),Port);
            Ears.Start();
            ToLog("Server started!");

        }

        //------------------------------[Getters]------------------------------

        /// <summary>Gets the welcome message, and appends a warning if anonymous use is not allowed.</summary>
        /// <returns></returns>
        protected string GetWelcomeMessage() {
            if(AllowAnonymous) { return WelcomeMessage; }
            return WelcomeMessage +Environment.NewLine+Environment.NewLine+ "This server requires that you log in. Use Login (Username) (Password) to log in.";
        }

        /// <summary>Gets All Active Connections</summary>
        public List<SwitchboardConnection> GetConnections() { return Connections; }

        //------------------------------[Functions]------------------------------

        /// <summary>
        /// Ticks the server. Each tick, the server: <br></br><br></br>
        /// <list type="number">
        /// <item>Checks if there's a pending connection, and if so allows them in.</item>
        /// <item>Ticks each connection, essentially processing any pending commands they have.</item>
        /// <item>Checks if any connection has been closed, and if so, removes it.</item>
        /// <item>Ticks each extension.</item>
        /// </list></summary>
        public void Tick() {

            //Check if we need to let in another connection.
            if(Ears.Pending()) {
                Connections.Add(new SwitchboardConnection(this,Ears.AcceptSocket())); //Let them in to the system.
                TheForm.ServerBWorker.ReportProgress(0); //Refresh the main form's listview.
            } 

            //ok now check every connection to see if they're pending.
            foreach(SwitchboardConnection Connection in Connections.ToArray()) { Connection.Tick();}

            //I'm pretty sure this is a bit of an innefficient way to do this, but if we turn it into an array, its no longer by ref, no? I don't think we can use that and tick each user the same way.
            //Plus this allows us to modify the root list, since we're itterating over an array, not the list.

            foreach(SwitchboardConnection Connection in Connections.ToArray()) {
                if(!Connection.IsConnected) { 
                    Connections.Remove(Connection);  //if the connection was closed, remove it from the list
                    TheForm.ServerBWorker.ReportProgress(0); //Refresh the main form's listview.
                }
            }

            //Now tick every extension
            foreach(SwitchboardExtension extension in Extensions) {extension.Tick();}

        }

        /// <summary>Closes the server</summary>
        public void Close() {

            //Close each connection
            foreach(SwitchboardConnection Connection in Connections) { Connection.Close(); }

            SaveUsers(); //Save users when we close.

            //Stop the cosa, and put down the pen
            Ears.Stop();
            ToLog("Server stopped");
            LogPen.Close();
        }

        /// <summary>Writes the specified text to the logfile</summary>
        public void ToLog(String LogItem) {
            String Line = "[" + DateTime.Now.ToShortTimeString() + "] " + LogItem;
            LogPen.WriteLine(Line);
            Console.WriteLine(Line);
        }

        /// <summary>Saves all users</summary>
        protected void SaveUsers() {

            if(File.Exists("SwitchboardUsers.txt")) { File.Delete("SwitchboardUsers.txt"); }
            StreamWriter Pen = File.CreateText("SwitchboardUsers.txt");

            foreach(SwitchboardUser User in Users) { Pen.WriteLine(User.ToString()); }
            Pen.Close();
        }


    }


}
