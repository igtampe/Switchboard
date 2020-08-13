namespace TinyForms {
    partial class TextboxForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.TheLabel = new System.Windows.Forms.Label();
            this.TheBox = new System.Windows.Forms.TextBox();
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TheLabel
            // 
            this.TheLabel.AutoSize = true;
            this.TheLabel.Location = new System.Drawing.Point(12, 9);
            this.TheLabel.Name = "TheLabel";
            this.TheLabel.Size = new System.Drawing.Size(35, 13);
            this.TheLabel.TabIndex = 0;
            this.TheLabel.Text = "label1";
            // 
            // TheBox
            // 
            this.TheBox.Location = new System.Drawing.Point(12, 25);
            this.TheBox.Name = "TheBox";
            this.TheBox.Size = new System.Drawing.Size(156, 20);
            this.TheBox.TabIndex = 1;
            // 
            // OKBtn
            // 
            this.OKBtn.Location = new System.Drawing.Point(12, 51);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 23);
            this.OKBtn.TabIndex = 2;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // CancelBTN
            // 
            this.CancelBTN.Location = new System.Drawing.Point(93, 51);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 3;
            this.CancelBTN.Text = "Cancel";
            this.CancelBTN.UseVisualStyleBackColor = true;
            this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
            // 
            // TextboxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(182, 90);
            this.Controls.Add(this.CancelBTN);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.TheBox);
            this.Controls.Add(this.TheLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TextboxForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TextboxForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TheLabel;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBTN;
        public System.Windows.Forms.TextBox TheBox;
    }
}