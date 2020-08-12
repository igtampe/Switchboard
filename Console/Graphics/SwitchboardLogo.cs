using Igtampe.BasicGraphics;

namespace Igtampe.Switchboard.Console.Graphics {
    /// <summary>Switchboard Logo</summary>
    public class SwitchboardLogo:BasicGraphic {

        public SwitchboardLogo() {

            string[] Cloud = {
                "22222222222",
                "22F22722F22",
                "22222222222",
                "22722F22722",
                "22222222222"
            };

            Contents = Cloud;
            Name = "SwitchboardLogo Graphic";
        }
    }
}
