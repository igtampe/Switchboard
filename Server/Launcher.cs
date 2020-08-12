using Igtampe.Switchboard.Server.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Igtampe.Switchboard.Server {

    /// <summary>Launches the server app with the title and the specified config</summary>
    public class Launcher {public static void Launch(String MainFormTitle, Config Config) {Application.Run(new MainForm(MainFormTitle,Config));}}
}
