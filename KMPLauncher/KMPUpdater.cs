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

        static string APP_DATA = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\KMPLauncher\";

        public static void Update(string UpdateFileURL)
        {
            WebClient downloader = new WebClient();

            Uri downloadUri = new Uri(UpdateFileURL);

            downloader.DownloadFileCompleted += downloader_DownloadFileCompleted;

            downloader.DownloadFileAsync(downloadUri, APP_DATA + "update.zip");

            
        }

        static void downloader_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            ZipFile z = ZipFile.Read(APP_DATA + "update.zip");
            z.ExtractAll(UpdaterSettings.KSPDirectory, ExtractExistingFileAction.OverwriteSilently);

            MessageBox.Show("Downloaded and updated KMP.");
            
        }
    }
}
