using System;
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

        static public string Username;

        public static string CurrentKMPUpdate
        {
            get
            {
                try
                {
                    return FileVersionInfo.GetVersionInfo(UpdaterSettings.KMPExecutable).FileVersion;
                }
                catch (Exception)
                {
                    return "0.0.0.0";
                }
            }
        }

        
    }
}
