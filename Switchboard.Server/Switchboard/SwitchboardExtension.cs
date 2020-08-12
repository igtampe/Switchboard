using System;
using System.Windows.Forms;

namespace Switchboard {

    /// <summary>Abstract class for Switchboard Extensions</summary>
    public abstract class SwitchboardExtension {
        /// <summary>Name of this extension</summary>
        protected string Name;

        /// <summary>Version of this extension</summary>
        protected string Version;

        /// <summary>Creates a basic Switchboard Extension</summary>
        /// <param name="Name">Name of the extension</param>
        /// <param name="Version">Version of the extension</param>
        public SwitchboardExtension(String Name, String Version) { this.Name = Name; this.Version = Version; }

        /// <summary>Should executes every tick</summary>
        public virtual void Tick() { }

        /// <summary>Modifies settings for this extension</summary>
        public virtual void Settings() { MessageBox.Show("Extension has no settings",Name,MessageBoxButtons.OK,MessageBoxIcon.Information); }

        //In implementation, the settings function should probably launch a tiny winform. 
        //Your extension, should it have settings, should be able to save them, and load them when being instantiated.
        //Settings subroutine should only launch while the server *isn't running*

        /// <summary>Parses a given command.</summary>
        /// <param name="User">USER attempting to execute a command within this extension</param>
        /// <param name="Command">The command the user is trying to execute</param>
        /// <returns>A string if the extension was able to parse it, otherwise null</returns>
        public abstract string Parse(ref SwitchboardUser User,String Command);

        /// <summary>
        /// returns a bit of info on the extension and help with its commands.
        /// maybe also include a list of the available commands, though nose.
        /// </summary>
        public abstract string Help();

        /// <summary>Gets the name of this extension</summary>
        public string GetName() { return Name; }

        /// <summary>Gets the version of this extension</summary>
        public string GetVersion() { return Version; }

    }

    /// <summary>The default dummy extension which also serves as an example for what you should do</summary>
    public class DummyExtension:SwitchboardExtension {

        /// <summary>Handle any initialization of your extension here</summary>
        public DummyExtension() : base("DummyExtension","Version 1.0") { }

        //NAMES OF EXTENSIONS SHOULD NOT HAVE SPACES. OTHERWISE HELP WILL BE INACCESSIBLE.

        public override string Help() {return "This is just a dummy extension. Don't have any funny ideas this isn't hiding anything.";}

        public override string Parse(ref SwitchboardUser User,string Command) {

            if(Command == "CONNECTED") { return "Congrats! You've connected to the server!"; }
            return null;
        }

    }

}
