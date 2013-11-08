using System;

using System.Net;


namespace KMPLauncher
{
    static class UpdateInformationRetriever
    {

        static Uri UpdateInfoUri = new Uri("https://dl.dropboxusercontent.com/u/6898485/updateinfo.txt");//This is where the information for downloading is always stored
        //The file itself looks like
        //0.1.2.0
        //http://www.kerbalspaceport.com/wp/wp-content/themes/kerbal/inc/download.php?f=uploads/2013/11/KMP_Client3.zip
        

        public static void Retrieve()
        {
            WebClient retriever = new WebClient();


            string page = retriever.DownloadString(UpdateInfoUri);

            string[] lines = page.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);//Split file into lines


            UpdateInfo.LatestVersion = lines[0];
            UpdateInfo.DownloadURL = lines[1];

        }
    }
}
