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
        public string Version;
        public int HTTPPort = 8081;
        public int Players;
        public int MaxPlayers;
        public string Information;
        public bool Whitelisted;
        public bool Screenshots;
        public int InactiveShipLimit;
        public int UpdateRate;
        public List<String> PlayerList = new List<string>();
    }
}
