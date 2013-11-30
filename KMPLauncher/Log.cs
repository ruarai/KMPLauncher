using System;
using System.IO;

namespace KMPLauncher
{
    static class Log
    {
        static string LOG = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\KMPDEBUGLOG.txt";

        private const bool DoLog = false;

        public static void Write(string log)
        {
            if (DoLog)
            {
                StreamWriter writer = File.AppendText(LOG);

                writer.WriteLine(DateTime.Now + " " + DateTime.Now.Second + " " + log);

                writer.Close();
            }
        }
    }
}
