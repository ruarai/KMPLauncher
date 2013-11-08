using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMPLauncher
{
    public class KMPServer
    {
        public string Name = "";
        public string IP;
        public int Port;

        public bool HasHTTPConnection;

        public string Version;


        public int Players;
        public int MaxPlayers;

        public string Information;
        public bool Whitelisted;
        public bool Screenshots;
        public int InactiveShipLimit;
        public int UpdateRate;
        public int ScreenshotHeight;



        public List<String> PlayerList = new List<string>();

        public string Address
        {
            get
            {
                return IP + ":" + Port; 
            }
            set
            {
                string[] split = value.Split(':');
                IP = split[0];
                Port = int.Parse(split[1]);
            }
        }
    }
}
