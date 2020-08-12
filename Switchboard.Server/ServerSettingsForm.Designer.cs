namespace SwitchboardServer {
    partial class ServerSettingsForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerSettingsForm));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Igtampe",
            "4",
            "1:00 AM 12/25/2019"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "LBL+",
            "Beta 1.0"}, -1);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AnonymousCheckbox = new System.Windows.Forms.CheckBox();
            this.MultiLoginCheckbox = new System.Windows.Forms.CheckBox();
            this.PortTextbox = new System.Windows.Forms.TextBox();
            this.IPTextbox = new System.Windows.Forms.TextBox();
            this.ToolTipHandler = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DeleteUserBTN = new System.Windows.Forms.Button();
            this.SetPasswordBTN = new System.Windows.Forms.Button();
            this.SetPLevelButton = new System.Windows.Forms.Button();
            this.AddUserBTN = new System.Windows.Forms.Button();
            this.UsersListview = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ExtensionSettingsBTN = new System.Windows.Forms.Button();
            this.ExtensionsListview = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.WelcomeBox = new System.Windows.Forms.TextBox();
            this.OKBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Port";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AnonymousCheckbox);
            this.groupBox1.Controls.Add(this.MultiLoginCheckbox);
            this.groupBox1.Controls.Add(this.PortTextbox);
            this.groupBox1.Controls.Add(this.IPTextbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 159);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Main Server Settings";
            // 
            // AnonymousCheckbox
            // 
            this.AnonymousCheckbox.AutoSize = true;
            this.AnonymousCheckbox.Location = new System.Drawing.Point(38, 114);
            this.AnonymousCheckbox.Name = "AnonymousCheckbox";
            this.AnonymousCheckbox.Size = new System.Drawing.Size(108, 30);
            this.AnonymousCheckbox.TabIndex = 4;
            this.AnonymousCheckbox.Text = "Allow anonymous\r\nusers";
            this.ToolTipHandler.SetToolTip(this.AnonymousCheckbox, resources.GetString("AnonymousCheckbox.ToolTip"));
            this.AnonymousCheckbox.UseVisualStyleBackColor = true;
            // 
            // MultiLoginCheckbox
            // 
            this.MultiLoginCheckbox.AutoSize = true;
            this.MultiLoginCheckbox.Location = new System.Drawing.Point(38, 78);
            this.MultiLoginCheckbox.Name = "MultiLoginCheckbox";
            this.MultiLoginCheckbox.Size = new System.Drawing.Size(90, 30);
            this.MultiLoginCheckbox.TabIndex = 3;
            this.MultiLoginCheckbox.Text = "Allow Multiple\r\nLogins";
            this.ToolTipHandler.SetToolTip(this.MultiLoginCheckbox, resources.GetString("MultiLoginCheckbox.ToolTip"));
            this.MultiLoginCheckbox.UseVisualStyleBackColor = true;
            // 
            // PortTextbox
            // 
            this.PortTextbox.Location = new System.Drawing.Point(38, 52);
            this.PortTextbox.Name = "PortTextbox";
            this.PortTextbox.Size = new System.Drawing.Size(100, 20);
            this.PortTextbox.TabIndex = 2;
            this.ToolTipHandler.SetToolTip(this.PortTextbox, resources.GetString("PortTextbox.ToolTip"));
            // 
            // IPTextbox
            // 
            this.IPTextbox.Location = new System.Drawing.Point(38, 26);
            this.IPTextbox.Name = "IPTextbox";
            this.IPTextbox.Size = new System.Drawing.Size(100, 20);
            this.IPTextbox.TabIndex = 1;
            this.ToolTipHandler.SetToolTip(this.IPTextbox, resources.GetString("IPTextbox.ToolTip"));
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DeleteUserBTN);
            this.groupBox2.Controls.Add(this.SetPasswordBTN);
            this.groupBox2.Controls.Add(this.SetPLevelButton);
            this.groupBox2.Controls.Add(this.AddUserBTN);
            this.groupBox2.Controls.Add(this.UsersListview);
            this.groupBox2.Location = new System.Drawing.Point(168, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 159);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User Management";
            // 
            // DeleteUserBTN
            // 
            this.DeleteUserBTN.Location = new System.Drawing.Point(328, 114);
            this.DeleteUserBTN.Name = "DeleteUserBTN";
            this.DeleteUserBTN.Size = new System.Drawing.Size(75, 23);
            this.DeleteUserBTN.TabIndex = 9;
            this.DeleteUserBTN.Text = "Delete User";
            this.DeleteUserBTN.UseVisualStyleBackColor = true;
            this.DeleteUserBTN.Click += new System.EventHandler(this.DeleteUserBTN_Click);
            // 
            // SetPasswordBTN
            // 
            this.SetPasswordBTN.Location = new System.Drawing.Point(328, 85);
            this.SetPasswordBTN.Name = "SetPasswordBTN";
            this.SetPasswordBTN.Size = new System.Drawing.Size(75, 23);
            this.SetPasswordBTN.TabIndex = 8;
            this.SetPasswordBTN.Text = "Set Pass";
            this.SetPasswordBTN.UseVisualStyleBackColor = true;
            this.SetPasswordBTN.Click += new System.EventHandler(this.SetPasswordBTN_Click);
            // 
            // SetPLevelButton
            // 
            this.SetPLevelButton.Location = new System.Drawing.Point(328, 55);
            this.SetPLevelButton.Name = "SetPLevelButton";
            this.SetPLevelButton.Size = new System.Drawing.Size(75, 23);
            this.SetPLevelButton.TabIndex = 7;
            this.SetPLevelButton.Text = "Set PLevel";
            this.SetPLevelButton.UseVisualStyleBackColor = true;
            this.SetPLevelButton.Click += new System.EventHandler(this.SetPLevelButton_Click);
            // 
            // AddUserBTN
            // 
            this.AddUserBTN.Location = new System.Drawing.Point(328, 24);
            this.AddUserBTN.Name = "AddUserBTN";
            this.AddUserBTN.Size = new System.Drawing.Size(75, 23);
            this.AddUserBTN.TabIndex = 6;
            this.AddUserBTN.Text = "Add User";
            this.AddUserBTN.UseVisualStyleBackColor = true;
            this.AddUserBTN.Click += new System.EventHandler(this.AddUserBTN_Click);
            // 
            // UsersListview
            // 
            this.UsersListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.UsersListview.HideSelection = false;
            this.UsersListview.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.UsersListview.Location = new System.Drawing.Point(6, 18);
            this.UsersListview.Name = "UsersListview";
            this.UsersListview.Size = new System.Drawing.Size(316, 126);
            this.UsersListview.TabIndex = 5;
            this.UsersListview.UseCompatibleStateImageBehavior = false;
            this.UsersListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Username";
            this.columnHeader1.Width = 122;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "PLevel";
            this.columnHeader2.Width = 47;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Last Login";
            this.columnHeader3.Width = 139;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ExtensionSettingsBTN);
            this.groupBox3.Controls.Add(this.ExtensionsListview);
            this.groupBox3.Location = new System.Drawing.Point(12, 177);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(258, 207);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Extensions";
            // 
            // ExtensionSettingsBTN
            // 
            this.ExtensionSettingsBTN.Location = new System.Drawing.Point(172, 172);
            this.ExtensionSettingsBTN.Name = "ExtensionSettingsBTN";
            this.ExtensionSettingsBTN.Size = new System.Drawing.Size(75, 23);
            this.ExtensionSettingsBTN.TabIndex = 11;
            this.ExtensionSettingsBTN.Text = "Settings";
            this.ExtensionSettingsBTN.UseVisualStyleBackColor = true;
            this.ExtensionSettingsBTN.Click += new System.EventHandler(this.ExtensionSettingsBTN_Click);
            // 
            // ExtensionsListview
            // 
            this.ExtensionsListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.ExtensionsListview.HideSelection = false;
            this.ExtensionsListview.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.ExtensionsListview.Location = new System.Drawing.Point(9, 19);
            this.ExtensionsListview.Name = "ExtensionsListview";
            this.ExtensionsListview.Size = new System.Drawing.Size(238, 147);
            this.ExtensionsListview.TabIndex = 10;
            this.ExtensionsListview.UseCompatibleStateImageBehavior = false;
            this.ExtensionsListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Extension";
            this.columnHeader4.Width = 164;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Version";
            this.columnHeader5.Width = 61;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.WelcomeBox);
            this.groupBox4.Location = new System.Drawing.Point(276, 177);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(301, 178);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Welcome Message";
            // 
            // WelcomeBox
            // 
            this.WelcomeBox.Location = new System.Drawing.Point(6, 19);
            this.WelcomeBox.Multiline = true;
            this.WelcomeBox.Name = "WelcomeBox";
            this.WelcomeBox.Size = new System.Drawing.Size(289, 153);
            this.WelcomeBox.TabIndex = 12;
            // 
            // OKBTN
            // 
            this.OKBTN.Location = new System.Drawing.Point(415, 361);
            this.OKBTN.Name = "OKBTN";
            this.OKBTN.Size = new System.Drawing.Size(75, 23);
            this.OKBTN.TabIndex = 13;
            this.OKBTN.Text = "OK";
            this.OKBTN.UseVisualStyleBackColor = true;
            this.OKBTN.Click += new System.EventHandler(this.OKBTN_Click);
            // 
            // CancelBTN
            // 
            this.CancelBTN.Location = new System.Drawing.Point(496, 361);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 14;
            this.CancelBTN.Text = "Cancel";
            this.CancelBTN.UseVisualStyleBackColor = true;
            this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
            // 
            // ServerSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 402);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.CancelBTN);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.OKBTN);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ServerSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox AnonymousCheckbox;
        private System.Windows.Forms.ToolTip ToolTipHandler;
        private System.Windows.Forms.CheckBox MultiLoginCheckbox;
        private System.Windows.Forms.TextBox PortTextbox;
        private System.Windows.Forms.TextBox IPTextbox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView UsersListview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button DeleteUserBTN;
        private System.Windows.Forms.Button SetPasswordBTN;
        private System.Windows.Forms.Button SetPLevelButton;
        private System.Windows.Forms.Button AddUserBTN;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button ExtensionSettingsBTN;
        private System.Windows.Forms.ListView ExtensionsListview;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Button OKBTN;
        private System.Windows.Forms.TextBox WelcomeBox;
    }
}