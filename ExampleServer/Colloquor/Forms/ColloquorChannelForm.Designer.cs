namespace Igtampe.Colloquor {
    partial class ColloquorChannelForm {
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NameTXB = new System.Windows.Forms.TextBox();
            this.PasswordTXB = new System.Windows.Forms.TextBox();
            this.WelcomeTXB = new System.Windows.Forms.TextBox();
            this.EnablePass = new System.Windows.Forms.CheckBox();
            this.TooltipHandler = new System.Windows.Forms.ToolTip(this.components);
            this.CancelBTN = new System.Windows.Forms.Button();
            this.OKBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Welcome Message";
            // 
            // NameTXB
            // 
            this.NameTXB.Location = new System.Drawing.Point(116, 12);
            this.NameTXB.Name = "NameTXB";
            this.NameTXB.Size = new System.Drawing.Size(116, 20);
            this.NameTXB.TabIndex = 0;
            // 
            // PasswordTXB
            // 
            this.PasswordTXB.Location = new System.Drawing.Point(116, 38);
            this.PasswordTXB.Name = "PasswordTXB";
            this.PasswordTXB.Size = new System.Drawing.Size(95, 20);
            this.PasswordTXB.TabIndex = 1;
            // 
            // WelcomeTXB
            // 
            this.WelcomeTXB.Location = new System.Drawing.Point(116, 64);
            this.WelcomeTXB.Name = "WelcomeTXB";
            this.WelcomeTXB.Size = new System.Drawing.Size(116, 20);
            this.WelcomeTXB.TabIndex = 3;
            // 
            // EnablePass
            // 
            this.EnablePass.AutoSize = true;
            this.EnablePass.Location = new System.Drawing.Point(217, 41);
            this.EnablePass.Name = "EnablePass";
            this.EnablePass.Size = new System.Drawing.Size(15, 14);
            this.EnablePass.TabIndex = 2;
            this.TooltipHandler.SetToolTip(this.EnablePass, "Enable the Password or not");
            this.EnablePass.UseVisualStyleBackColor = true;
            this.EnablePass.CheckedChanged += new System.EventHandler(this.EnablePass_CheckedChanged);
            // 
            // CancelBTN
            // 
            this.CancelBTN.Location = new System.Drawing.Point(157, 91);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 5;
            this.CancelBTN.Text = "Cancel";
            this.CancelBTN.UseVisualStyleBackColor = true;
            this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
            // 
            // OKBTN
            // 
            this.OKBTN.Location = new System.Drawing.Point(76, 91);
            this.OKBTN.Name = "OKBTN";
            this.OKBTN.Size = new System.Drawing.Size(75, 23);
            this.OKBTN.TabIndex = 4;
            this.OKBTN.Text = "OK";
            this.OKBTN.UseVisualStyleBackColor = true;
            this.OKBTN.Click += new System.EventHandler(this.OKBTN_Click);
            // 
            // ColloquorChannelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 126);
            this.Controls.Add(this.OKBTN);
            this.Controls.Add(this.CancelBTN);
            this.Controls.Add(this.EnablePass);
            this.Controls.Add(this.WelcomeTXB);
            this.Controls.Add(this.PasswordTXB);
            this.Controls.Add(this.NameTXB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ColloquorChannelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Channel Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip TooltipHandler;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Button OKBTN;
        public System.Windows.Forms.TextBox NameTXB;
        public System.Windows.Forms.TextBox PasswordTXB;
        public System.Windows.Forms.TextBox WelcomeTXB;
        public System.Windows.Forms.CheckBox EnablePass;
    }
}