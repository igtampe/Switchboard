using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SwitchboardServer {
    public partial class NewUserForm:Form {

        private List<Switchboard.SwitchboardUser> AllUsers;

        public NewUserForm(ref List<Switchboard.SwitchboardUser> AllUsers) {
            InitializeComponent();
            this.AllUsers = AllUsers;

            PasswordConfirmTextbox.PasswordChar = '*';
            PasswordTextBox.PasswordChar = '*';
        }

        private void Verify(object sender,EventArgs e) {

            //Clear the text
            ErrorLabel.Text = "";

            //Look I know these are a lot of Else-Ifs but these are all the conditions that need to be met to do this.
            if(UsernameTextBox.Text.Contains(" ") || UsernameTextBox.Text.Contains("~")||String.IsNullOrEmpty(UsernameTextBox.Text)) { ErrorLabel.Text = "Username is invalid"; } 
            else if(PasswordTextBox.Text.Contains(" ") || PasswordTextBox.Text.Contains("~")|| String.IsNullOrEmpty(PasswordTextBox.Text)) { ErrorLabel.Text = "Password is invalid"; } 
            else if(!(PasswordConfirmTextbox.Text == PasswordTextBox.Text)) { ErrorLabel.Text = "Passwords don't match"; } 
            else {

                //Last check is to check if allusers contains the username.
                foreach(Switchboard.SwitchboardUser user in AllUsers) {
                    if(user.GetUsername() == UsernameTextBox.Text) { ErrorLabel.Text = "Username Already Exists"; }
                }

            }

            //if all's clear, the errorlabel will be empty.
        }

        private void OKBtn_Click(object sender,EventArgs e) {
            if(!string.IsNullOrEmpty(ErrorLabel.Text)) {
                MessageBox.Show(ErrorLabel.Text,"w o o p s",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();

        }

        private void CancelBTN_Click(object sender,EventArgs e) {

            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
