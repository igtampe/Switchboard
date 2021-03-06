﻿using System;
using System.Windows.Forms;
using static Igtampe.Switchboard.Server.SwitchboardServer;

namespace Igtampe.Switchboard.Server.Forms {
    internal partial class UserDetailsForm:Form {

        private readonly SwitchboardConnection MyConnection;

        internal UserDetailsForm(ref SwitchboardConnection MyConnection) {
            InitializeComponent();
            this.MyConnection = MyConnection;
            RefreshDetails();
        }

        private void RefreshBTN_Click(object sender,EventArgs e) { RefreshDetails(); }

        private void OKBTN_Click(object sender,EventArgs e) { Close(); }

        private void RefreshDetails() {
            while(MyConnection.Busy) { } //wait for connection not to be busy.
            if(MyConnection.IsConnected) {UsernameLabel.Text = MyConnection.GetUser().GetUsername() + " (" + MyConnection.GetUser().GetPLevel() + ")";} 
            else {UsernameLabel.Text = "User Disconnected";}
            Text = UsernameLabel.Text;

            IDLabel.Text = "Connection ID: " + MyConnection.ID.ToString();  
            OnlineSinceLabel.Text = "Online since: " + MyConnection.GetConnectedSince().ToString();
            LastOfflineLabel.Text = "Last offline: " + MyConnection.GetUser().GetLastOnline();

            CommandsBox.Text = MyConnection.GetConsolePreview();
        }

      
    }
}
