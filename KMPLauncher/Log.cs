﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KMPLauncher
{
    static class Log
    {
        static string LOG = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\KMPDEBUGLOG.txt";

        static bool DoLog = true;

        public static void Write(string log)
        {
            if (DoLog)
            {
                StreamWriter writer = File.AppendText(LOG);

                writer.WriteLine(DateTime.Now.ToString() + " " + DateTime.Now.Second + " " + log);

                writer.Close();
            }
        }
    }
}
