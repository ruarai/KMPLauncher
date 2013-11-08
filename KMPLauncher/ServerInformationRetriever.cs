using System;
using System.Net;

namespace KMPLauncher
{
    static class ServerInformationRetriever
    {
        public static KMPServer Retrieve(string IP, int HTTPPort)
        {
            KMPServer server = new KMPServer();

            WebClient retriever = new WebClient();

            retriever.Headers.Add("KMPLAUNCHER", "SERVER_INFO_REQUEST");//Mostly unneeded. Only a courtesy thing for server owners.

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


            server.UpdateRate = int.Parse(lines[5].Substring("Updates per Second: ".Length, lines[5].Length - "Updates per Second: ".Length));//Update Rate


            server.InactiveShipLimit = int.Parse(lines[6].Substring("Inactive Ship Limit: ".Length, lines[6].Length - "Inactive Ship Limit: ".Length));//Inactive Ship Limit


            server.ScreenshotHeight = int.Parse(lines[7].Substring("Screenshot Height: ".Length, lines[7].Length - "Screenshot Height: ".Length));//Screenshot Height


            server.Screenshots = bool.Parse(lines[8].Substring("Screenshot Save: ".Length, lines[8].Length - "Screenshot Save: ".Length));//Can you save screenshots?


            server.Whitelisted = bool.Parse(lines[9].Substring("Whitelisted: ".Length, lines[9].Length - "Whitelisted: ".Length));//Is it whitelisted?




            return server;
        }
    }
}
