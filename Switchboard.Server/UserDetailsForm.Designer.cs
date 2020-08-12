namespace SwitchboardServer {
    partial class UserDetailsForm {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LastOfflineLabel = new System.Windows.Forms.Label();
            this.OnlineSinceLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CommandsBox = new System.Windows.Forms.TextBox();
            this.OKBTN = new System.Windows.Forms.Button();
            this.RefreshBTN = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 3);
            this.groupBox1.Controls.Add(this.LastOfflineLabel);
            this.groupBox1.Controls.Add(this.OnlineSinceLabel);
            this.groupBox1.Controls.Add(this.UsernameLabel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Info";
            // 
            // LastOfflineLabel
            // 
            this.LastOfflineLabel.AutoSize = true;
            this.LastOfflineLabel.Location = new System.Drawing.Point(8, 61);
            this.LastOfflineLabel.Name = "LastOfflineLabel";
            this.LastOfflineLabel.Size = new System.Drawing.Size(173, 13);
            this.LastOfflineLabel.TabIndex = 2;
            this.LastOfflineLabel.Text = "Last Offline: 12:00 AM 12/25/1999";
            // 
            // OnlineSinceLabel
            // 
            this.OnlineSinceLabel.AutoSize = true;
            this.OnlineSinceLabel.Location = new System.Drawing.Point(8, 48);
            this.OnlineSinceLabel.Name = "OnlineSinceLabel";
            this.OnlineSinceLabel.Size = new System.Drawing.Size(180, 13);
            this.OnlineSinceLabel.TabIndex = 1;
            this.OnlineSinceLabel.Text = "Online Since: 12:00 AM 12/25/1999";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(6, 16);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(134, 26);
            this.UsernameLabel.TabIndex = 0;
            this.UsernameLabel.Text = "Igtampe (4)";
            // 
            // groupBox2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 3);
            this.groupBox2.Controls.Add(this.CommandsBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(8, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 327);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Console Preview";
            // 
            // CommandsBox
            // 
            this.CommandsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommandsBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommandsBox.Location = new System.Drawing.Point(3, 16);
            this.CommandsBox.Multiline = true;
            this.CommandsBox.Name = "CommandsBox";
            this.CommandsBox.ReadOnly = true;
            this.CommandsBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.CommandsBox.Size = new System.Drawing.Size(384, 308);
            this.CommandsBox.TabIndex = 0;
            this.CommandsBox.TabStop = false;
            this.CommandsBox.WordWrap = false;
            // 
            // OKBTN
            // 
            this.OKBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OKBTN.Location = new System.Drawing.Point(314, 429);
            this.OKBTN.Name = "OKBTN";
            this.OKBTN.Size = new System.Drawing.Size(84, 23);
            this.OKBTN.TabIndex = 0;
            this.OKBTN.Text = "OK";
            this.OKBTN.UseVisualStyleBackColor = true;
            this.OKBTN.Click += new System.EventHandler(this.OKBTN_Click);
            // 
            // RefreshBTN
            // 
            this.RefreshBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RefreshBTN.Location = new System.Drawing.Point(224, 429);
            this.RefreshBTN.Name = "RefreshBTN";
            this.RefreshBTN.Size = new System.Drawing.Size(84, 23);
            this.RefreshBTN.TabIndex = 3;
            this.RefreshBTN.Text = "Refresh";
            this.RefreshBTN.UseVisualStyleBackColor = true;
            this.RefreshBTN.Click += new System.EventHandler(this.RefreshBTN_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.Controls.Add(this.OKBTN, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.RefreshBTN, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(406, 460);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // UserDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 460);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(329, 344);
            this.Name = "UserDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserDetailsForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LastOfflineLabel;
        private System.Windows.Forms.Label OnlineSinceLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox CommandsBox;
        private System.Windows.Forms.Button OKBTN;
        private System.Windows.Forms.Button RefreshBTN;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}