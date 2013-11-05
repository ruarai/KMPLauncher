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

        static Uri UpdateInfoUri = new Uri("https://gist.github.com/ruarai/7312239/raw/cceba0a2d75a8e14531073295cb0c7e4489f53eb/UpdateInfo");

        public static void Retrieve()
        {
            WebClient retriever = new WebClient();


            string page = retriever.DownloadString(UpdateInfoUri);

            string[] lines = page.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);


            UpdateInfo.LatestVersion = lines[0];
            UpdateInfo.DownloadURL = lines[1];

        }
    }
}
