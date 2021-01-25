using System;
using System.Windows.Forms;

namespace TinyForms {

    /// <summary>Mini form that holds a caption, and a numeric up down with configurable minimum and maximum.</summary>
    public partial class NumUpDownForm:Form {

        /// <summary>Creates a form with an updown</summary>
        /// <param name="caption"></param>
        /// <param name="title"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public NumUpDownForm(string caption, string title, int min, int max) {
            InitializeComponent();
            TheLabel.Text = caption;
            Text = title;
            numericUpDown1.Minimum = min;
            numericUpDown1.Maximum = max;
                
        }

        private void OKBtn_Click(object sender,EventArgs e) {
            DialogResult = DialogResult.OK;
            return;
        }

        private void Button2_Click(object sender,EventArgs e) {
            DialogResult = DialogResult.Cancel;
            return;
        }
    }
}
