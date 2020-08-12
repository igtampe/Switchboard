using System;
using System.Collections.Generic;

namespace Igtampe.Switchboard.Server {

    /// <summary>Configuration of the Switchboard Server.</summary>
    public class Config {

        /// <summary>Name of this server. By default, "Switchboard Server"</summary>
        public string ServerName { get; set; } = "Switchboard Server";

        /// <summary>Version of this server. By Default, 2.0</summary>
        public string ServerVersion { get; set; } = "2.0";

        /// <summary>Default IP for this server. By default, 127.0.0.1</summary>
        public string DefaultIP { get; set; } = "127.0.0.1";

        /// <summary>Default port for this server. By default, 909</summary>
        public int DefaultPort { get; set; } = 909;

        /// <summary>Allow Anonymous users by default or no. By default, true</summary>
        public bool AllowAnonymousDefault { get; set; } = true;

        /// <summary>Allow multiple logins wit the same account or no. By default, true</summary>
        public bool MultiLoginDefault { get; set; } = true;

        /// <summary>Default Welcome Message. By default, "H o l a"</summary>
        public string DefaultWelcome { get; set; } = "H o l a";

        public Func<List<SwitchboardExtension>> ServerExtensions=DefaultServerExtensions;

        /// <summary>Gets a list of the extensions from this server</summary>
        public static List<SwitchboardExtension> DefaultServerExtensions() {

            List<SwitchboardExtension> List = new List<SwitchboardExtension>();

            //Here add/initialize your server extensions.
            //By default, the server will always have the DummyExtension, and the Switchboard Main Extension.

            return List;

        }

    }
}
