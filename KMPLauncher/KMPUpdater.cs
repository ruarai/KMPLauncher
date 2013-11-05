using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using Ionic.Zip;



namespace KMPLauncher
{
    static class KMPUpdater
    {
        public static void Update(string UpdateFileURL)
        {
            WebClient downloader = new WebClient();

            Uri downloadUri = new Uri(UpdateFileURL);

            downloader.DownloadFileCompleted += downloader_DownloadFileCompleted;

            downloader.DownloadFileAsync(downloadUri, "update.zip");

            
        }

        static void downloader_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            ZipFile z = ZipFile.Read("update.zip");
            z.ExtractAll(UpdaterSettings.KSPDirectory, ExtractExistingFileAction.OverwriteSilently);

            MessageBox.Show("Downloaded and updated KMP.");
            
        }
    }
}
