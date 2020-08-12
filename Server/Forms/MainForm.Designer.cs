namespace Igtampe.Switchboard.Server.Forms {
    partial class MainForm {
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Anonymous",
            "127.0.0.1",
            "1:00 AM, 12/25/1999",
            "Idle"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.StartStopServerButton = new System.Windows.Forms.Button();
            this.ConnectionsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TitleLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.ConnectionDetailsButton = new System.Windows.Forms.Button();
            this.ServerSettingsButton = new System.Windows.Forms.Button();
            this.ServerBWorker = new System.ComponentModel.BackgroundWorker();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartStopServerButton
            // 
            this.StartStopServerButton.Location = new System.Drawing.Point(291, 17);
            this.StartStopServerButton.Name = "StartStopServerButton";
            this.StartStopServerButton.Size = new System.Drawing.Size(90, 23);
            this.StartStopServerButton.TabIndex = 0;
            this.StartStopServerButton.Text = "Start Server";
            this.StartStopServerButton.UseVisualStyleBackColor = true;
            this.StartStopServerButton.Click += new System.EventHandler(this.StartStopServerButton_Click);
            // 
            // ConnectionsListView
            // 
            this.ConnectionsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.ConnectionsListView.FullRowSelect = true;
            this.ConnectionsListView.HideSelection = false;
            this.ConnectionsListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.ConnectionsListView.Location = new System.Drawing.Point(12, 78);
            this.ConnectionsListView.Name = "ConnectionsListView";
            this.ConnectionsListView.Size = new System.Drawing.Size(369, 377);
            this.ConnectionsListView.TabIndex = 1;
            this.ConnectionsListView.UseCompatibleStateImageBehavior = false;
            this.ConnectionsListView.View = System.Windows.Forms.View.Details;
            this.ConnectionsListView.SelectedIndexChanged += new System.EventHandler(this.ConnectionsListView_SelectedIndexChanged);
            this.ConnectionsListView.DoubleClick += new System.EventHandler(this.ConnectionDetailsButton_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "User";
            this.columnHeader1.Width = 93;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "IP";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Connected Since";
            this.columnHeader3.Width = 143;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(12, 17);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(273, 32);
            this.TitleLabel.TabIndex = 2;
            this.TitleLabel.Text = "Switchboard Server";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(15, 49);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(73, 13);
            this.StatusLabel.TabIndex = 3;
            this.StatusLabel.Text = "Status: Offline";
            // 
            // ConnectionDetailsButton
            // 
            this.ConnectionDetailsButton.Location = new System.Drawing.Point(225, 462);
            this.ConnectionDetailsButton.Name = "ConnectionDetailsButton";
            this.ConnectionDetailsButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectionDetailsButton.TabIndex = 5;
            this.ConnectionDetailsButton.Text = "Details";
            this.ConnectionDetailsButton.UseVisualStyleBackColor = true;
            this.ConnectionDetailsButton.Click += new System.EventHandler(this.ConnectionDetailsButton_Click);
            // 
            // ServerSettingsButton
            // 
            this.ServerSettingsButton.Location = new System.Drawing.Point(291, 44);
            this.ServerSettingsButton.Name = "ServerSettingsButton";
            this.ServerSettingsButton.Size = new System.Drawing.Size(90, 23);
            this.ServerSettingsButton.TabIndex = 6;
            this.ServerSettingsButton.Text = "Settings";
            this.ServerSettingsButton.UseVisualStyleBackColor = true;
            this.ServerSettingsButton.Click += new System.EventHandler(this.ServerSettingsButton_Click);
            // 
            // ServerBWorker
            // 
            this.ServerBWorker.WorkerReportsProgress = true;
            this.ServerBWorker.WorkerSupportsCancellation = true;
            this.ServerBWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ServerTime);
            this.ServerBWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.RefreshListview);
            this.ServerBWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ServerDone);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Location = new System.Drawing.Point(306, 462);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(75, 23);
            this.DisconnectButton.TabIndex = 4;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 497);
            this.Controls.Add(this.ServerSettingsButton);
            this.Controls.Add(this.ConnectionDetailsButton);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.ConnectionsListView);
            this.Controls.Add(this.StartStopServerButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Switchboard Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_Close);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartStopServerButton;
        private System.Windows.Forms.ListView ConnectionsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button ConnectionDetailsButton;
        private System.Windows.Forms.Button ServerSettingsButton;
        public System.ComponentModel.BackgroundWorker ServerBWorker;
        private System.Windows.Forms.Button DisconnectButton;
    }
}

