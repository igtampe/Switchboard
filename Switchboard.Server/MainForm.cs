using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Switchboard;
using SwitchboardServer;

namespace SwitchboardServerForm {
    public partial class MainForm:Form {

        //------------------------------[Variables]------------------------------

        /// <summary>Main server this form holds</summary>
        private Switchboard.SwitchboardServer MainServer;

        //These are here so we don't have to load them *during* the backgroundworker.
        private String IP;
        private int Port;
        private bool AllowAnon;
        private bool AllowMulti;
        private String Welcome;

        //------------------------------[Constructor]------------------------------

        public MainForm() {
            InitializeComponent();
            ConnectionDetailsButton.Enabled = false;
            DisconnectButton.Enabled = false;

            ConnectionsListView.Items.Clear();
            ConnectionsListView.Enabled = false;
            ConnectionsListView.FullRowSelect = true;
            ConnectionsListView.MultiSelect = false;
        }

        //------------------------------[Buttons]------------------------------

        /// <summary>Shwne selecting a user from the listview</summary>
        private void ConnectionsListView_SelectedIndexChanged(object sender,EventArgs e) {
            ConnectionDetailsButton.Enabled = true;
            DisconnectButton.Enabled = true;
        }

        private void ConnectionDetailsButton_Click(object sender,EventArgs e) {
            //Make sure there is at least one connection selected.
            //Well, there will only ever be one because we disabled multi-select but shh its ok.
            if(ConnectionsListView.SelectedIndices.Count == 0) {
                MessageBox.Show("Please select a connection to see its details","n o",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            //Get the connection index
            int ConnectionIndex = ConnectionsListView.SelectedIndices[0];

            //Get the connection.
            Switchboard.SwitchboardServer.SwitchboardConnection Connection = MainServer.GetConnections()[ConnectionIndex];

            //Pass the connection to a connection details form
            new UserDetailsForm(ref Connection).Show();

        }

        private void ServerSettingsButton_Click(object sender,EventArgs e) {
            //Make sure there is no main server since these settings cannot be modified while the server is running.
            if(MainServer != null) {
                MessageBox.Show("Settings can only be modified while server isn't running!","n o",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            //Now launch the de-esta cosa. The settings form will handle loading settings.

            new ServerSettingsForm().ShowDialog();
        }

        private void DisconnectButton_Click(object sender,EventArgs e) {
            //Make sure there is at least one connection selected.
            //Well, there will only ever be one because we disabled multi-select but shh its ok.
            if(ConnectionsListView.SelectedIndices.Count == 0) {
                MessageBox.Show("Please select a connection to see its details","n o",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            //Get the connection index
            int ConnectionIndex = ConnectionsListView.SelectedIndices[0];

            //Ask the user
            DialogResult Result = MessageBox.Show("Are you sure you want to disconnect this user?","Are you sure",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            //if yes close the connection
            if(Result == DialogResult.Yes) { 
                MainServer.GetConnections()[ConnectionIndex].Close();
                ServerBWorker.ReportProgress(0);
            }   

        }

        private void StartStopServerButton_Click(object sender,EventArgs e) {
            if(MainServer == null) {

                //Load Server Settings
                if(!File.Exists("SwitchboardServer.cfg")) {

                    //Show a brief little welcome message!
                    MessageBox.Show("Server is not configured! Run Server Settings at least once before starting server!","Welcome!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                } else {

                    try {

                        String[] Settings = File.ReadAllLines("SwitchboardServer.cfg")[0].Split(':');
                        IP = Settings[0];
                        Port = int.Parse(Settings[1]);
                        AllowAnon = bool.Parse(Settings[2]);
                        AllowMulti = bool.Parse(Settings[3]);

                    } catch(Exception d) {
                        MessageBox.Show("There was a problem interpretting your config file. Default values were loaded instead. \n\n" + d.Message + "\n" + d.StackTrace,"oopsie",MessageBoxButtons.OK,MessageBoxIcon.Error); ;
                        LoadDefault();
                    }

                }

                //Load Welcome Message
                if(File.Exists("Welcome.txt")) { Welcome = File.ReadAllText("Welcome.txt"); } else { Welcome = SwitchboardConfiguration.DefaultWelcome; }

                //Server is not started
                StatusLabel.Text = "Status: Online";
                StartStopServerButton.Text = "Stop";
                ConnectionsListView.Enabled = Enabled;


                ServerBWorker.RunWorkerAsync();

            } else { ServerBWorker.CancelAsync(); } //server is started, cancel it.

        }

        //------------------------------[Other Stuff]------------------------------

        private void LoadDefault() {
            IP = SwitchboardConfiguration.DefaultIP;
            Port = SwitchboardConfiguration.DefaultPort;
            AllowAnon = SwitchboardConfiguration.AllowAnonymousDefault;
            AllowMulti = SwitchboardConfiguration.MultiLoginDefault;
        }

        /// <summary>TODO: Ensure the server is closed properly when closing</summary>
        private void MainForm_Close(object sender,EventArgs e) {}

        //------------------------------[Server Background Worker]------------------------------

        private void ServerTime(object sender,DoWorkEventArgs e) {
                                    
            //First lets start a server.
            MainServer = new Switchboard.SwitchboardServer(this, IP,Port,Welcome,AllowAnon, AllowMulti);

            //now 
            while(!ServerBWorker.CancellationPending) {
                MainServer.Tick();
                Thread.Sleep(50);  //sleep to make sure this doesn't drive my computer insane
            }

            //if there is a cancelation pending:
            MainServer.Close();

        }

        private void RefreshListview(object sender,ProgressChangedEventArgs e) {
            //Report the progress on the internal server
            ConnectionsListView.Items.Clear();
            foreach(Switchboard.SwitchboardServer.SwitchboardConnection Con in MainServer.GetConnections()) {
                ListViewItem NLI = new ListViewItem(Con.GetUser().GetUsername());
                NLI.SubItems.Add(Con.GetIP().Address.ToString());
                NLI.SubItems.Add(Con.GetConnectedSince().ToShortTimeString() + " " + Con.GetConnectedSince().ToShortDateString());
                ConnectionsListView.Items.Add(NLI);
            }
        }

        private void ServerDone(object Sender,RunWorkerCompletedEventArgs e) {
            StatusLabel.Text = "Status: Offline";
            StartStopServerButton.Text = "Start Server";
            ConnectionDetailsButton.Enabled = false;
            DisconnectButton.Enabled = false;

            ConnectionsListView.Items.Clear();
            ConnectionsListView.Enabled = false;
            MainServer = null;
        }

    }
}
