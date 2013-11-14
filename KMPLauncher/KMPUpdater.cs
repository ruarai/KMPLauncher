using Ionic.Zip;

using System;
using System.IO;
using System.Net;
using System.Windows.Forms;



namespace KMPLauncher
{
    public delegate void KMPUpdaterUpdateComplete();

    static class KMPUpdater
    {
        public static event KMPUpdaterUpdateComplete UpdateComplete;

        public static void Update(string UpdateFileURL)
        {
            WebClient downloader = new WebClient();

            Uri downloadUri = new Uri(UpdateFileURL);

            downloader.DownloadFileCompleted += downloader_DownloadFileCompleted;

            downloader.DownloadFileAsync(downloadUri, UpdaterSettings.LAUNCHER_FOLDER + UpdaterSettings.UPDATE_FILE);
        }

        static void downloader_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            ZipFile z = ZipFile.Read(UpdaterSettings.LAUNCHER_FOLDER + UpdaterSettings.UPDATE_FILE);
            z.ExtractAll(UpdaterSettings.KSPDirectory, ExtractExistingFileAction.OverwriteSilently);

            z.Dispose();

            File.Delete(UpdaterSettings.LAUNCHER_FOLDER + UpdaterSettings.UPDATE_FILE);
            
            UpdateComplete();


            MessageBox.Show("Downloaded and updated KMP.");


            
        }
    }
}
