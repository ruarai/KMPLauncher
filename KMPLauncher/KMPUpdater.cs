using Ionic.Zip;

using System;
using System.IO;
using System.Net;
using System.Windows.Forms;



namespace KMPLauncher
{
    static class KMPUpdater
    {

        static string LAUNCHER_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\KMPLauncher\";

        public static void Update(string UpdateFileURL)
        {
            WebClient downloader = new WebClient();

            Uri downloadUri = new Uri(UpdateFileURL);

            downloader.DownloadFileCompleted += downloader_DownloadFileCompleted;

            downloader.DownloadFileAsync(downloadUri, LAUNCHER_FOLDER + "update.zip");
        }

        static void downloader_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            ZipFile z = ZipFile.Read(LAUNCHER_FOLDER + "update.zip");
            z.ExtractAll(UpdaterSettings.KSPDirectory, ExtractExistingFileAction.OverwriteSilently);

            File.Delete(LAUNCHER_FOLDER + "update.zip");
            

            MessageBox.Show("Downloaded and updated KMP.");
            
        }
    }
}
