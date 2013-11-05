using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
namespace KMPLauncher
{
    static class UpdaterSettings
    {
        static public string KSPDirectory;
        static public string KMPDirectory;

        static public string KSPExecutable;
        static public string KMPExecutable;


        public static string CurrentKMPUpdate
        {
            get { return FileVersionInfo.GetVersionInfo(UpdaterSettings.KMPExecutable).FileVersion; }
        }
        static public string LatestKMPUpdate;

        
    }
}
