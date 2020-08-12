using System;
using System.Windows.Forms;

namespace TinyForms {
    public partial class NumUpDownForm:Form {
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

        private void button2_Click(object sender,EventArgs e) {
            DialogResult = DialogResult.Cancel;
            return;
        }
    }
}
