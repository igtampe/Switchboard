using System;
using System.Windows.Forms;

namespace TinyForms {

    /// <summary>A form with a caption, and a textbox</summary>
    public partial class TextboxForm:Form {

        /// <summary>Creates a mini textbox form</summary>
        /// <param name="caption"></param>
        /// <param name="title"></param>
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
