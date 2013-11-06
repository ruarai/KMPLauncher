using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;

namespace KMPLauncher
{
    static class ServerInformationRetriever
    {
        public static KMPServer Retrieve(string IP, int HTTPPort)
        {
            KMPServer server = new KMPServer();

            WebClient retriever = new WebClient();

            string url = "http://" + IP + ":" + HTTPPort + "/";//Make a nice URL out of the IP and Port
            
            string page = retriever.DownloadString(url);

            string[] lines = page.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);


            server.Version = lines[0].Substring("Version: ".Length, lines[0].Length - "Version: ".Length);//Version


            string PlayerLine = lines[2].Substring("Num Players: ".Length, lines[2].Length - "Num Players: ".Length);//Player count
            string[] SplitPlayers = PlayerLine.Split('/');
            
            server.Players = int.Parse(SplitPlayers[0]);
            server.MaxPlayers = int.Parse(SplitPlayers[1]);


            string FullPlayers = lines[3].Substring("Players: ".Length, lines[3].Length - "Players: ".Length);//Actual players
            String[] IndividualPlayers = FullPlayers.Split(',');

            foreach (string p in IndividualPlayers) server.PlayerList.Add(p.Trim());
                

            server.Information = lines[4].Substring("Information: ".Length, lines[4].Length - "Information: ".Length);//Information



            return server;
        }
    }
}
