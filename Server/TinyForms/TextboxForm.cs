using System;
using System.Windows.Forms;

namespace TinyForms {
    public partial class TextboxForm:Form {
        public TextboxForm(string caption, string title) {
            InitializeComponent();
            TheLabel.Text = caption;
            Text = title;
        }

        private void OKBtn_Click(object sender,EventArgs e) {
            DialogResult = DialogResult.OK;
            return;
        }

        private void CancelBTN_Click(object sender,EventArgs e) {
            DialogResult = DialogResult.Cancel;
            return;
        }
    }
}
