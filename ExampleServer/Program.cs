using System;
using Igtampe.Switchboard.Server;
using System.Windows.Forms;
using System.Collections.Generic;
using Igtampe.Colloquor;

namespace ExampleServer {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //Most of these values are the default ones within the configuration class itself, but they're here to show u what u can modify.
            SwitchboardConfiguration ExampleConfig = new SwitchboardConfiguration {
                ServerName = "Switchboard Example Server",
                ServerVersion = "1.0",
                DefaultIP = "127.0.0.1",
                DefaultPort = 909,
                AllowAnonymousDefault = true,
                MultiLoginDefault = true,
                DefaultWelcome = "Bonjour. Welcome to the server.",
                ServerExtensions = GetExtensions
            };

            Launcher.Launch("Colloquor Server",ExampleConfig);


        }

        public static List<SwitchboardExtension> GetExtensions() {
            List<SwitchboardExtension> extensions = new List<SwitchboardExtension>();

            extensions.Add(new ColloquorExtension());

            return extensions;
        }

    }
}
