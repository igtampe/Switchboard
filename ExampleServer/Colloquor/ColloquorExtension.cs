using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Igtampe.Switchboard.Server;

namespace Igtampe.Colloquor {
    public partial class ColloquorExtension:SwitchboardExtension {


        private static readonly string[] DefaultSettings = {"1","General:Welcome to General:"};
        readonly Dictionary<String,ColloquorChannel> ChannelDictionary;
        readonly Dictionary<SwitchboardUser,ColloquorChannel> UserChannelDictionary;

        private int PermissionLevel=1;

        public ColloquorExtension():base("Colloquor","1.0"){

            if(!File.Exists("Colloquor.cfg")) { File.WriteAllLines("Colloquor.cfg",DefaultSettings); }

            ChannelDictionary = new Dictionary<string,ColloquorChannel>();
            UserChannelDictionary = new Dictionary<SwitchboardUser,ColloquorChannel>();

            try { 
                String[] AllLines = File.ReadAllLines("Colloquor.CFG");
                foreach(String Line in AllLines) {
                    String[] LineSplit = Line.Split(':');
                    if(LineSplit.Length == 1) { 
                        PermissionLevel = int.Parse(Line); 
                    }
                    else if (LineSplit.Length == 3) { ChannelDictionary.Add(LineSplit[0],new ColloquorChannel(LineSplit[0],LineSplit[1],LineSplit[2])); }
                }
            
            } 
            catch (Exception e){Console.WriteLine(e.Message + "\n\n" + e.StackTrace);}

        }

        public override string Help() {
            return "Colloquor Extension Version 1.0\n" +
                "\n (All Commands have the prefix CQUOR) \n\n" +
                "JOIN (Channel) (Pass) : Joins the specified channel. Return's channel's welcome message\n" +
                "LISTCHANNELS          : Shows a list of all channels\n" +
                "SEND (Message)        : Sends the message to the channel you're connected to\n" +
                "REQUEST               : Retrieves the latest message on the channel.\n" +
                "LEAVE                 : Leaves the channel\n" +
                "PING                  : Ping the Colloquor Extension";

        }

        public override string Parse(ref SwitchboardUser User,string Command) {
            if(!Command.ToUpper().StartsWith("CQUOR")) { return null; }

            //Make sure the user can access Colloquor
            if(!User.CanExecute(PermissionLevel)) { return "NOEXECUTE"; }

            Command = Command.Remove(0,6); //Remove "CQUOR "
            String[] CommandSplit = Command.Split(' ');

            switch(CommandSplit[0].ToUpper()) {
                case "JOIN":

                    //First let's make sure the user isn't already in a channel
                    if(UserChannelDictionary.ContainsKey(User)) { return "ALREADY CONNECTED"; }

                    if(CommandSplit.Length == 2) {
                        //Join without a password.
                        //First get the channel
                        if(!ChannelDictionary.ContainsKey(CommandSplit[1])) { return "NOT FOUND"; }
                        if(ChannelDictionary[CommandSplit[1]].HasPassword()) { return "NEEDS PASS"; }

                        //Now that we know that the channel exists, let's add the user.
                        UserChannelDictionary.Add(User,ChannelDictionary[CommandSplit[1]]);
                        UserChannelDictionary[User].ReceiveMessage(User.GetUsername() + " joined the channel!");
                        return UserChannelDictionary[User].GetWelcome() + "\n\n";


                    } else if(CommandSplit.Length == 3) {
                        //Join with a password.
                        //First get the channel
                        if(!ChannelDictionary.ContainsKey(CommandSplit[1])) { return "NOT FOUND"; }
                        if(!ChannelDictionary[CommandSplit[1]].VerifyPassword(CommandSplit[2])) { return "WRONG PASS"; }

                        //Now that we know that the channel exists, let's add the user.
                        UserChannelDictionary.Add(User,ChannelDictionary[CommandSplit[1]]);
                        UserChannelDictionary[User].ReceiveMessage(User.GetUsername() + " joined the channel!");
                        return UserChannelDictionary[User].GetWelcome() + "\n\n";


                    } else { return "ERR"; }

                case "LISTCHANNELS":
                    //Send a list of all channels. The list should appear as:
                    //CHANNEL_NAME:CHANNEL_HAS_PASSWORD,CHANNEL_NAME2...

                    List<String> AllChannels = new List<String>();
                    foreach(ColloquorChannel channel in ChannelDictionary.Values) {AllChannels.Add(channel.ToListChannelString());}
                    return String.Join(",",AllChannels);

                case "SEND":
                    if(!UserChannelDictionary.ContainsKey(User)) { return "NOT CONNECTED"; }
                    UserChannelDictionary[User].ReceiveMessage("["+User.GetUsername() + "] " + Command.Remove(0,5)); //Remove "SEND "
                    return UserChannelDictionary[User].GetLastMessage();
                case "REQUEST":
                    if(!UserChannelDictionary.ContainsKey(User)) { return "NOT CONNECTED"; }
                    return UserChannelDictionary[User].GetLastMessage();
                case "LEAVE":
                    if(!UserChannelDictionary.ContainsKey(User)) { return "NOT CONNECTED"; }
                    UserChannelDictionary[User].ReceiveMessage(User.GetUsername() + " left the channel");
                    UserChannelDictionary.Remove(User);
                    return "OK";
                case "PING":
                    return "PONG";
                default:
                    return null;
            }

        }

        public override void Settings() {
            ColloquorSettings SettingsForm = new ColloquorSettings(PermissionLevel,ChannelDictionary.Values.ToList());
            if(SettingsForm.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                PermissionLevel = SettingsForm.PermissionLevel;

                //Rebuild the channel Dictionary
                ChannelDictionary.Clear();
                foreach(ColloquorChannel Channel in SettingsForm.AllChannels) {ChannelDictionary.Add(Channel.GetName(),Channel);}
                SaveSettings();
            }

        }


        /// <summary>Saves Colloquor's Settings.</summary>
        public void SaveSettings() {

            List<String> AllLines = new List<string> {PermissionLevel.ToString()};
            foreach(ColloquorChannel Channel in ChannelDictionary.Values) {AllLines.Add(Channel.ToString());}

            File.Delete("Colloquor.CFG");
            File.WriteAllLines("Colloquor.cfg",AllLines);

        }

    }
}
