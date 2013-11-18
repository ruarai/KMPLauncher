using System;
using System.Collections.Generic;
using System.Net;

namespace KMPLauncher
{
    public delegate void GlobalServerRetrieverRetrieved(List<KMPServer> serverlist);

    static class GlobalServerRetriever
    {
        public static event GlobalServerRetrieverRetrieved Retrieved;

        public static void Retrieve()
        {
            
            WebClient retriever = new WebClient();
            retriever.DownloadStringCompleted += retriever_DownloadStringCompleted;

            retriever.DownloadStringAsync(new Uri(UpdaterSettings.GLOBAL_SERVERS_URL));

        }

        static void retriever_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            
            if (e.Error == null)
            {
                List<KMPServer> serverList = new List<KMPServer>();

                string[] lines = e.Result.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);//Split file into lines

                foreach (string s in lines)
                {
                    KMPServer server = new KMPServer();

                    string[] splitServer = s.Split('/');

                    server.Address = splitServer[0];

                    server.HTTPPort = int.Parse(splitServer[1]);

                    serverList.Add(server);

                }

                Retrieved(serverList);
            }
        }
    }
}
