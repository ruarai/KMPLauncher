using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;

namespace KMPLauncher
{
    static class ChangelogRetriever
    {
        public static string Retrieve()
        {
            WebClient retriever = new WebClient();
            try
            {
                return retriever.DownloadString("https://dl.dropboxusercontent.com/u/6898485/changelog.txt");
            }
            catch (WebException)
            {
                return "No connection to changelog.";
            }
        }
    }
}
