using System;
using System.Collections.Generic;

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
                try
                {
                    IP = split[0];
                }
                catch
                {
                    IP = value;
                }
                try
                {
                    Port = int.Parse(split[1]);
                }
                catch
                {
                    Port = 2076;
                }
                
            }
        }
    }
}
