using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;


namespace KMPLauncher
{
    static class UpdateInformationRetriever
    {

        static Uri UpdateInfoUri = new Uri("https://dl.dropboxusercontent.com/u/6898485/index.html");

        public static void Retrieve()
        {
            WebClient retriever = new WebClient();


            string page = retriever.DownloadString(UpdateInfoUri);

            string[] lines = page.Split(new string[] { "</br>" }, StringSplitOptions.RemoveEmptyEntries);


            UpdateInfo.LatestVersion = lines[0];
            UpdateInfo.DownloadURL = lines[1];

        }
    }
}
