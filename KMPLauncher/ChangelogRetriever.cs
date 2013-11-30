using System;

using System.Net;

namespace KMPLauncher
{
    public delegate void ChangelogRetrieverRetrieveComplete(string changelog);

    static class ChangelogRetriever
    {
        public static event ChangelogRetrieverRetrieveComplete RetrieveComplete;

        public static void Retrieve()
        {
            var retriever = new WebClient();

            retriever.DownloadStringCompleted += retriever_DownloadStringCompleted;

            retriever.DownloadStringAsync(new Uri(UpdaterSettings.UPDATE_CHANGELOG_URL));
        }

        static void retriever_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            RetrieveComplete(e.Error == null ? e.Result : "Failed to retrieve changelog");
        }
    }
}
