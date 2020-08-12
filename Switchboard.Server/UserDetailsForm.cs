using System;
using System.Windows.Forms;

namespace SwitchboardServer {
    public partial class UserDetailsForm:Form {

        Switchboard.SwitchboardServer.SwitchboardConnection MyConnection;

        public UserDetailsForm(ref Switchboard.SwitchboardServer.SwitchboardConnection MyConnection) {
            InitializeComponent();
            this.MyConnection = MyConnection;
            RefreshDetails();
        }

        private void RefreshBTN_Click(object sender,EventArgs e) { RefreshDetails(); }

        private void OKBTN_Click(object sender,EventArgs e) { Close(); }

        private void RefreshDetails() {
            if(MyConnection.IsConnected) {UsernameLabel.Text = MyConnection.GetUser().GetUsername() + " (" + MyConnection.GetUser().GetPLevel() + ")";} 
            else {UsernameLabel.Text = "User Disconnected";}
            Text = UsernameLabel.Text;

            OnlineSinceLabel.Text = "Online since: " + MyConnection.GetConnectedSince().ToString();
            LastOfflineLabel.Text = "Last offline: " + MyConnection.GetUser().GetLastOnline();

            CommandsBox.Text = MyConnection.GetConsolePreview();
        }

      
    }
}
