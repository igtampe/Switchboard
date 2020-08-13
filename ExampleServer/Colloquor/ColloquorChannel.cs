using System;

namespace Igtampe.Colloquor {
        public class ColloquorChannel {

        //Wow look at me I'm declaring variables like this now wooooooooooooooo
        private String Name, Welcome, Password, LastMessage;
        
        public ColloquorChannel(String Name,  String Welcome,String Password) {
            this.Name = Name;
            this.Welcome = Welcome;
            this.Password = Password;
        }

        public Boolean VerifyPassword(String Attempt) {
            if(!HasPassword()) { return true; } //I guess if a channel doesn't have a password any password should do.
            return Password == Attempt;
        }
                
        //-------------------[Getters and Setters]-------------------
        public void SetWelcome(String Welcome) { this.Welcome = Welcome; }
        public void SetName(String Name) { this.Name = Name; }
        public void SetPassword(String Password) { this.Password = Password; }
        public String GetWelcome() { return Welcome; }
        public String GetName() { return Name; }
        public String GetPassword() { return Password; }

        /// <summary>Updates the most recent message on this channel</summary>
        public void ReceiveMessage(String Message) { LastMessage = Message; }

        /// <summary>Gets the last message sent on this channel</summary>
        public string GetLastMessage() { return LastMessage; }

        /// <summary>Specifies whether or not this channel has a password.</summary>
        /// <returns>True if this channel has a password, false otherwise.</returns>
        public bool HasPassword() { return !String.IsNullOrWhiteSpace(Password); }

        /// <summary>ToString mostly to be able to save channels</summary>
        /// <returns>NAME,WelcomeMessage,Password</returns>
        public override string ToString() {return String.Join(":",Name,Welcome,Password);}

        /// <summary>Only provides name and if this channel has a password. Used in ListChannels command</summary>
        /// <returns>NAME:HasPassword</returns>
        public String ToListChannelString() {return String.Join(":",Name,HasPassword()); }

    }
}
