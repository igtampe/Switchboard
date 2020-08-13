using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Igtampe.Colloquor {
    public partial class ColloquorSettings:Form {

        //------------------------------[Variables]------------------------------

        public int PermissionLevel = 1;
        public List<ColloquorChannel> AllChannels;

        //------------------------------[Constructor]------------------------------

        public ColloquorSettings(int PermissionLevel, List<ColloquorChannel> AllChannels) {
            InitializeComponent();
            this.PermissionLevel = PermissionLevel;
            PermissionLevelUpDown.Value = PermissionLevel;
            this.AllChannels = AllChannels;

            ChannelsListview.MultiSelect = false;
            ChannelsListview.FullRowSelect = true;

            UpdateListview();
        }

        //------------------------------[Buttons]------------------------------

        private void OKBTN_Click(object sender,EventArgs e) {
            DialogResult = DialogResult.OK;
            //Saving is handled by the Settings Subroutine.
            Close();
        }

        private void CANCELBTN_Click(object sender,EventArgs e) { 
            DialogResult = DialogResult.Cancel; 
            Close(); 
        }

        private void AddChannelBTN_Click(object sender,EventArgs e) {
            ColloquorChannelForm Form = new ColloquorChannelForm();
            if(Form.ShowDialog() == DialogResult.OK) {

                //Make sure there is no repeated channel.
                foreach(ColloquorChannel Channel in AllChannels) {
                    if(Channel.GetName() == Form.NameTXB.Text) {
                        MessageBox.Show("Channel with that name already exists!","n o",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                }

                //now let's add it
                if(Form.EnablePass.Checked) { AllChannels.Add(new ColloquorChannel(Form.NameTXB.Text,Form.WelcomeTXB.Text,Form.PasswordTXB.Text)); } 
                else { AllChannels.Add(new ColloquorChannel(Form.NameTXB.Text,Form.WelcomeTXB.Text,"")); }

                UpdateListview();
            }

        }

        private void ModifyChannelBTN_Click(object sender,EventArgs e) {
            int Index = GetSelectedIndex(ChannelsListview);
            if(Index == -2) { return; }

            ColloquorChannelForm Form = new ColloquorChannelForm(AllChannels[Index]);
            if(Form.ShowDialog() == DialogResult.OK) {

                //Make sure there is no repeated channel.
                for(int i = 0; i < AllChannels.Count; i++) {
                    if((AllChannels[i].GetName() == Form.NameTXB.Text) && i!=Index) {
                        MessageBox.Show("Channel with that name already exists!","n o",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                }

                //now let's update todo
                AllChannels[Index].SetName(Form.NameTXB.Text);
                AllChannels[Index].SetWelcome(Form.WelcomeTXB.Text);
                if(Form.EnablePass.Checked) { AllChannels[Index].SetPassword(Form.PasswordTXB.Text); } else {AllChannels[Index].SetPassword("");}

                UpdateListview();


            }

        }

        private void DeleteChannelBTN_Click(object sender,EventArgs e) {
            int Index = GetSelectedIndex(ChannelsListview);
            if(Index == -2) {return;}
            if(AreYouSure("Are you sure you want to delete this channel?")) {
                AllChannels.RemoveAt(Index);
                UpdateListview();
            }
        }

        private void PermissionLevelUpDown_ValueChanged(object sender,EventArgs e) {
            PermissionLevel = Decimal.ToInt32(PermissionLevelUpDown.Value);
            if(PermissionLevel == 0) {
                MessageBox.Show("Colloquor doesn't work well with anonymous users. \n\n" +
                    "Extensions only see users, not connections, so only one anonymous user would be allowed at any time.\n\n" +
                    "Probably use a permission level of at least one!","Warning!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        //------------------------------[Functions]------------------------------

        /// <summary>Updates the list view</summary>
        private void UpdateListview() {
            ChannelsListview.Items.Clear();
            foreach(ColloquorChannel Channel in AllChannels) {
                ListViewItem NLI = new ListViewItem(Channel.GetName());
                NLI.SubItems.Add(Channel.GetPassword());
                ChannelsListview.Items.Add(NLI);
            }

        }

        /// <summary>Gets the selected item index on a listview.</summary>
        /// <returns>-2 if no items are selected, otherwise the first selected index.</returns>
        public int GetSelectedIndex(ListView List) {
            if(List.SelectedItems.Count != 1) {
                MessageBox.Show("No item selected!","n o",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return -2; 
            }
            return List.SelectedIndices[0];
        }

        /// <summary>Shows A Yes/No Message box</summary>
        /// <param name="Message">Question you want to ask the user</param>
        /// <returns>True if the user clicks yes, false otherwise.</returns>
        public bool AreYouSure(String Message) {return MessageBox.Show(Message,"Are you sure?",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes;}

      
    }
}
