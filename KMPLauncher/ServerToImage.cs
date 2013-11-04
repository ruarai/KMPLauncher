using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace KMPLauncher
{
    static class ServerToImage
    {
        static Font f = new Font(FontFamily.GenericSansSerif, 12.0f);
        static SolidBrush b = new SolidBrush(Color.Black);


        static public Image Convert(KMPServer server)
        {
            Bitmap output = new Bitmap(100, 100);

            Graphics g = Graphics.FromImage(output);

            g.DrawString(server.Version, f, b, 10, 10);

            g.Dispose();

            return output;
        }
    }
}
