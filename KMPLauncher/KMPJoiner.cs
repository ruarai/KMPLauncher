using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace KMPLauncher
{
    static class KMPJoiner
    {
        public static void JoinKMPServer(KMPServer server)
        {
            if (server.Version == UpdaterSettings.CurrentKMPUpdate | !server.HasHTTPConnection)
            {
                if (UpdaterSettings.KSPExists & UpdaterSettings.KMPExists)
                {
                    if (!File.Exists(UpdaterSettings.KMPDirectory + @"\PluginData\KerbalMultiPlayer\KMPClientConfig.txt"))
                    {
                        if (!Directory.Exists(UpdaterSettings.KMPDirectory + @"\PluginData\"))
                        {
                            Directory.CreateDirectory(UpdaterSettings.KMPDirectory + @"\PluginData\");
                        }
                        if (!Directory.Exists(UpdaterSettings.KMPDirectory + @"\PluginData\KerbalMultiPlayer\"))
                        {
                            Directory.CreateDirectory(UpdaterSettings.KMPDirectory + @"\PluginData\KerbalMultiPlayer\");
                        }


                        FileStream file = File.Create(UpdaterSettings.KMPDirectory + @"\PluginData\KerbalMultiPlayer\KMPClientConfig.txt");
                        file.Close();
                    }
                    StreamWriter wr = new StreamWriter(UpdaterSettings.KMPDirectory + @"\PluginData\KerbalMultiPlayer\KMPClientConfig.txt");

                    wr.WriteLine("username");//Very lazy way to do this, I know.
                    wr.WriteLine(UpdaterSettings.Username);

                    wr.WriteLine("ip");
                    wr.WriteLine("");

                    wr.WriteLine("reconnect");
                    wr.WriteLine("True");

                    wr.WriteLine("fav0");
                    wr.WriteLine(server.Address);

                    wr.Close();

                    ProcessStartInfo startInfo = new ProcessStartInfo();

                    startInfo.WorkingDirectory = UpdaterSettings.KSPDirectory;

                    startInfo.FileName = UpdaterSettings.KSPExecutable;

                    Process.Start(startInfo);
                }
                else
                {
                    MessageBox.Show("Please check directory settings. KSP or KMP not found.");
                }
            }
            else
            {
                MessageBox.Show("Version mis-match between server and client. \nServer Version: " + server.Version + "\nClient Version: " + UpdaterSettings.CurrentKMPUpdate);
            }
        }
    }
}
