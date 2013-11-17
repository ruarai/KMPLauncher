using System;

using System.Net;


namespace KMPLauncher
{
    public delegate void InfoRetrieverRetrieveComplete();

    static class UpdateInformationRetriever
    {

        static Uri UpdateInfoUri = new Uri(UpdaterSettings.UPDATER_INFO_URL);//This is where the information for downloading is always stored
        //The file itself looks like
        //0.1.2.0
        //http://www.kerbalspaceport.com/wp/wp-content/themes/kerbal/inc/download.php?f=uploads/2013/11/KMP_Client3.zip
        //http://www.forumurl.com/lalala
        //http://www.github.com/lalala
        //http://www.github.com/lalala/issues

        public static event InfoRetrieverRetrieveComplete RetrieveComplete;

        public static void Retrieve()
        {
            WebClient retriever = new WebClient();

            retriever.DownloadStringCompleted += retriever_DownloadStringCompleted;

            retriever.DownloadStringAsync(UpdateInfoUri);


        }

        static void retriever_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                string[] lines = e.Result.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);//Split file into lines


                UpdateInfo.LatestVersion = lines[0];
                UpdateInfo.DownloadURL = lines[1];
                UpdateInfo.ForumURL = lines[2];
                UpdateInfo.GitHubURL = lines[3];
                UpdateInfo.GitHubIssuesURL = lines[4];

                RetrieveComplete();
            }
        }

    }
}
