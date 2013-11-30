using Ionic.Zip;

using System;
using System.IO;
using System.Net;



namespace KMPLauncher
{
    public delegate void KMPUpdaterUpdateComplete();
    public delegate void KMPUpdaterUpdateProgress(DownloadProgressChangedEventArgs e);

    static class KMPUpdater
    {
        public static event KMPUpdaterUpdateComplete UpdateComplete;
        public static event KMPUpdaterUpdateProgress UpdateProgressChange;

        public static void Update(string UpdateFileURL)
        {
            var downloader = new WebClient();

            var downloadUri = new Uri(UpdateFileURL);

            downloader.DownloadFileCompleted += downloader_DownloadFileCompleted;

            downloader.DownloadProgressChanged += downloader_DownloadProgressChanged;

            downloader.DownloadFileAsync(downloadUri, UpdaterSettings.LAUNCHER_FOLDER + UpdaterSettings.UPDATE_FILE);
        }

        static void downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            UpdateProgressChange(e);
        }

        static void downloader_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            ZipFile z = ZipFile.Read(UpdaterSettings.LAUNCHER_FOLDER + UpdaterSettings.UPDATE_FILE);
            z.ExtractAll(UpdaterSettings.KSPDirectory, ExtractExistingFileAction.OverwriteSilently);

            z.Dispose();

            File.Delete(UpdaterSettings.LAUNCHER_FOLDER + UpdaterSettings.UPDATE_FILE);
            
            UpdateComplete();



            
        }
    }
}
