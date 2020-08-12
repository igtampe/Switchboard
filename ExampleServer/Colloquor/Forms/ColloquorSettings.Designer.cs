namespace Igtampe.Colloquor {
    partial class ColloquorSettings {
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
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "General",
            "(None)"}, -1);
            this.label1 = new System.Windows.Forms.Label();
            this.PermissionLevelUpDown = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DeleteChannelBTN = new System.Windows.Forms.Button();
            this.ModifyChannelBTN = new System.Windows.Forms.Button();
            this.AddChannelBTN = new System.Windows.Forms.Button();
            this.ChannelsListview = new System.Windows.Forms.ListView();
            this.OKBTN = new System.Windows.Forms.Button();
            this.CANCELBTN = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.PermissionLevelUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Required Switchboard User Permission Level";
            // 
            // PermissionLevelUpDown
            // 
            this.PermissionLevelUpDown.Location = new System.Drawing.Point(277, 108);
            this.PermissionLevelUpDown.Name = "PermissionLevelUpDown";
            this.PermissionLevelUpDown.Size = new System.Drawing.Size(120, 20);
            this.PermissionLevelUpDown.TabIndex = 1;
            this.PermissionLevelUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PermissionLevelUpDown.ValueChanged += new System.EventHandler(this.PermissionLevelUpDown_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Igtampe.Switchboard.ExampleServer.Properties.Resources.Colloquor__Banner_;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(385, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DeleteChannelBTN);
            this.groupBox1.Controls.Add(this.ModifyChannelBTN);
            this.groupBox1.Controls.Add(this.AddChannelBTN);
            this.groupBox1.Controls.Add(this.ChannelsListview);
            this.groupBox1.Location = new System.Drawing.Point(12, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 116);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Channels";
            // 
            // DeleteChannelBTN
            // 
            this.DeleteChannelBTN.Location = new System.Drawing.Point(304, 77);
            this.DeleteChannelBTN.Name = "DeleteChannelBTN";
            this.DeleteChannelBTN.Size = new System.Drawing.Size(75, 23);
            this.DeleteChannelBTN.TabIndex = 3;
            this.DeleteChannelBTN.Text = "Delete";
            this.DeleteChannelBTN.UseVisualStyleBackColor = true;
            this.DeleteChannelBTN.Click += new System.EventHandler(this.DeleteChannelBTN_Click);
            // 
            // ModifyChannelBTN
            // 
            this.ModifyChannelBTN.Location = new System.Drawing.Point(304, 48);
            this.ModifyChannelBTN.Name = "ModifyChannelBTN";
            this.ModifyChannelBTN.Size = new System.Drawing.Size(75, 23);
            this.ModifyChannelBTN.TabIndex = 2;
            this.ModifyChannelBTN.Text = "Modify";
            this.ModifyChannelBTN.UseVisualStyleBackColor = true;
            this.ModifyChannelBTN.Click += new System.EventHandler(this.ModifyChannelBTN_Click);
            // 
            // AddChannelBTN
            // 
            this.AddChannelBTN.Location = new System.Drawing.Point(304, 19);
            this.AddChannelBTN.Name = "AddChannelBTN";
            this.AddChannelBTN.Size = new System.Drawing.Size(75, 23);
            this.AddChannelBTN.TabIndex = 1;
            this.AddChannelBTN.Text = "Add";
            this.AddChannelBTN.UseVisualStyleBackColor = true;
            this.AddChannelBTN.Click += new System.EventHandler(this.AddChannelBTN_Click);
            // 
            // ChannelsListview
            // 
            this.ChannelsListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.ChannelsListview.HideSelection = false;
            this.ChannelsListview.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem6});
            this.ChannelsListview.Location = new System.Drawing.Point(6, 19);
            this.ChannelsListview.Name = "ChannelsListview";
            this.ChannelsListview.Size = new System.Drawing.Size(292, 81);
            this.ChannelsListview.TabIndex = 0;
            this.ChannelsListview.UseCompatibleStateImageBehavior = false;
            this.ChannelsListview.View = System.Windows.Forms.View.Details;
            // 
            // OKBTN
            // 
            this.OKBTN.Location = new System.Drawing.Point(235, 256);
            this.OKBTN.Name = "OKBTN";
            this.OKBTN.Size = new System.Drawing.Size(75, 23);
            this.OKBTN.TabIndex = 4;
            this.OKBTN.Text = "OK";
            this.OKBTN.UseVisualStyleBackColor = true;
            this.OKBTN.Click += new System.EventHandler(this.OKBTN_Click);
            // 
            // CANCELBTN
            // 
            this.CANCELBTN.Location = new System.Drawing.Point(322, 256);
            this.CANCELBTN.Name = "CANCELBTN";
            this.CANCELBTN.Size = new System.Drawing.Size(75, 23);
            this.CANCELBTN.TabIndex = 5;
            this.CANCELBTN.Text = "Cancel";
            this.CANCELBTN.UseVisualStyleBackColor = true;
            this.CANCELBTN.Click += new System.EventHandler(this.CANCELBTN_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 153;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Password";
            this.columnHeader2.Width = 108;
            // 
            // ColloquorSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 291);
            this.Controls.Add(this.CANCELBTN);
            this.Controls.Add(this.OKBTN);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PermissionLevelUpDown);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ColloquorSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Colloquor Settings";
            ((System.ComponentModel.ISupportInitialize)(this.PermissionLevelUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown PermissionLevelUpDown;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView ChannelsListview;
        private System.Windows.Forms.Button DeleteChannelBTN;
        private System.Windows.Forms.Button ModifyChannelBTN;
        private System.Windows.Forms.Button AddChannelBTN;
        private System.Windows.Forms.Button OKBTN;
        private System.Windows.Forms.Button CANCELBTN;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}