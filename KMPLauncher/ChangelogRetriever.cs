using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;

namespace KMPLauncher
{
    public delegate void ChangelogRetrieverRetrieveComplete(string changelog);

    static class ChangelogRetriever
    {
        public static event ChangelogRetrieverRetrieveComplete RetrieveComplete;

        public static void Retrieve()
        {
            WebClient retriever = new WebClient();

            retriever.DownloadStringCompleted += retriever_DownloadStringCompleted;

            retriever.DownloadStringAsync(new Uri(UpdaterSettings.UPDATE_CHANGELOG_URL));
        }

        static void retriever_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                RetrieveComplete(e.Result);
            }
            else
            {
                RetrieveComplete("Failed to retrieve changelog");
            }
        }
    }
}
