﻿using System;
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

        public static string LAUNCHER_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\KMPLauncher\";
        public static string UPDATE_FILE = "updatetemporary.zip";
        public static string SERVER_FILE = "servers.dat";
        public static string UPDATER_FILE = "updater.dat";

        public static string UPDATER_INFO_URL = "https://dl.dropboxusercontent.com/u/6898485/updateinfo.txt";
        public static string UPDATE_CHANGELOG_URL = "https://dl.dropboxusercontent.com/u/6898485/changelog.txt";

        public static string CurrentKMPUpdate
        {
            get
            {
                try
                {
                    return FileVersionInfo.GetVersionInfo(UpdaterSettings.KMPExecutable).FileVersion;
                }
                catch
                {
                    return "0.0.0.0";
                }
            }
        }

        
    }
}
