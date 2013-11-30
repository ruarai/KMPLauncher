using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml;
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
                    if (!File.Exists(UpdaterSettings.KMPDirectory + @"\PluginData\KerbalMultiPlayer\KMPClientConfig.xml"))
                    {
                        if (!Directory.Exists(UpdaterSettings.KMPDirectory + @"\PluginData\"))
                        {
                            Directory.CreateDirectory(UpdaterSettings.KMPDirectory + @"\PluginData\");
                        }
                        if (!Directory.Exists(UpdaterSettings.KMPDirectory + @"\PluginData\KerbalMultiPlayer\"))
                        {
                            Directory.CreateDirectory(UpdaterSettings.KMPDirectory + @"\PluginData\KerbalMultiPlayer\");
                        }


                        FileStream file = File.Create(UpdaterSettings.KMPDirectory + @"\PluginData\KerbalMultiPlayer\KMPClientConfig.xml");
                        file.Close();
                    }

                    var clientConfig = new XmlDocument();

                    clientConfig.Load(UpdaterSettings.KMPDirectory + @"\PluginData\KerbalMultiPlayer\KMPClientConfig.xml");

                    XmlNode username = clientConfig.DocumentElement.SelectSingleNode("//global/@username");
                    XmlNode hostname = clientConfig.DocumentElement.SelectSingleNode("//favourite/@hostname");

                    username.Value = UpdaterSettings.Username;
                    hostname.Value = server.Address;

                    clientConfig.Save(UpdaterSettings.KMPDirectory + @"\PluginData\KerbalMultiPlayer\KMPClientConfig.xml");

                    var startInfo = new ProcessStartInfo
                                        {
                                            WorkingDirectory = UpdaterSettings.KSPDirectory,
                                            FileName = UpdaterSettings.KSPExecutable
                                        };

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
