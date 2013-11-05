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

        static public bool KSPExists;
        static public bool KMPExists;
        


        public static string CurrentKMPUpdate
        {
            get
            {
                try
                {
                    return FileVersionInfo.GetVersionInfo(UpdaterSettings.KMPExecutable).FileVersion;
                }
                catch (Exception e)
                {
                    return "0.0.0.0";
                }
            }
        }

        
    }
}
