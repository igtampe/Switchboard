using System;
using Igtampe.Switchboard.Server.Forms;
using System.Windows.Forms;

namespace ExampleServer {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new MainForm());
        }
    }
}
