using Igtampe.Switchboard.Server.Forms;
using System.Windows.Forms;

namespace Igtampe.Switchboard.Server {

    /// <summary>Class that holds a launcher for a Switchboard Server</summary>
    public static class Launcher {

        /// <summary>Launhes the server app wit hthe title and specified config</summary>
        /// <param name="MainFormTitle">Title for the Switchboard Server form</param>
        /// <param name="icon">Icon for the form</param>
        /// <param name="Config">Configuration of the server</param>
        public static void Launch(string MainFormTitle, System.Drawing.Icon icon, SwitchboardConfiguration Config) {Application.Run(new MainForm(MainFormTitle, icon, Config));}
    }
}
