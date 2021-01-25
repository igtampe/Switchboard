namespace Igtampe.Colloquor {

    /// <summary>
    /// A Colloquor Channel
    /// </summary>
    public class ColloquorChannel {

        //Wow look at me I'm declaring variables like this now wooooooooooooooo
        private string Name, Welcome, Password, LastMessage;
        
        public ColloquorChannel(string Name, string Welcome, string Password) {
            this.Name = Name;
            this.Welcome = Welcome;
            this.Password = Password;
        }

        public bool VerifyPassword(string Attempt) {
            if(!HasPassword()) { return true; } //I guess if a channel doesn't have a password any password should do.
            return Password == Attempt;
        }
                
        //-------------------[Getters and Setters]-------------------
        public void SetWelcome(string Welcome) { this.Welcome = Welcome; }
        public void SetName(string Name) { this.Name = Name; }
        public void SetPassword(string Password) { this.Password = Password; }
        public string GetWelcome() { return Welcome; }
        public string GetName() { return Name; }
        public string GetPassword() { return Password; }

        /// <summary>Updates the most recent message on this channel</summary>
        public void ReceiveMessage(string Message) { LastMessage = Message; }

        /// <summary>Gets the last message sent on this channel</summary>
        public string GetLastMessage() { return LastMessage; }

        /// <summary>Specifies whether or not this channel has a password.</summary>
        /// <returns>True if this channel has a password, false otherwise.</returns>
        public bool HasPassword() { return !string.IsNullOrWhiteSpace(Password); }

        /// <summary>ToString mostly to be able to save channels</summary>
        /// <returns>NAME,WelcomeMessage,Password</returns>
        public override string ToString() {return string.Join(":",Name,Welcome,Password);}

        /// <summary>Only provides name and if this channel has a password. Used in ListChannels command</summary>
        /// <returns>NAME:HasPassword</returns>
        public string ToListChannelString() {return string.Join(":",Name,HasPassword()); }

    }
}
