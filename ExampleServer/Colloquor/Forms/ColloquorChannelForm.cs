using System;
using System.Windows.Forms;

namespace Igtampe.Colloquor {
    public partial class ColloquorChannelForm:Form {
        
        public ColloquorChannelForm() {InitializeComponent();}
        public ColloquorChannelForm(ColloquorChannel Channel):this() {
            NameTXB.Text = Channel.GetName();
            PasswordTXB.Text = Channel.GetPassword();
            EnablePass.Checked = Channel.HasPassword();
            PasswordTXB.Enabled = EnablePass.Checked;
            WelcomeTXB.Text = Channel.GetWelcome();
        }

        private void OKBTN_Click(object sender,EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelBTN_Click(object sender,EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void EnablePass_CheckedChanged(object sender,EventArgs e) {PasswordTXB.Enabled = EnablePass.Checked;}
    }
}
