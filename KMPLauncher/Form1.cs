using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;

namespace KMPLauncher
{
    public partial class Form1 : Form
    {
        List<KMPServer> servers = new List<KMPServer>();
        KMPServer selection = new KMPServer();

        readonly string SERVER_CONST = "STARTSERVER";

        public Form1()
        {
            InitializeComponent();


            LoadServers();
            LoadUpdaterSettings();

            RefreshServerList();

            SaveServers();

            CheckUpdate();
        }

        private void RefreshServerList()
        {
            RefreshButton.Enabled = false;
            listView1.Items.Clear();
            if (!NetworkWorker.IsBusy)
            {
                NetworkWorker.RunWorkerAsync();
            }

        }


        private void PopulateServerList()
        {
            foreach (KMPServer s in servers)
            {
                ListViewItem serveritem = new ListViewItem(s.Name);
                serveritem.SubItems.Add(s.IP + ":" + s.Port);
                serveritem.SubItems.Add(s.Version);
                serveritem.SubItems.Add(s.Players + "/" + s.MaxPlayers);
                serveritem.SubItems.Add(s.Information);

                listView1.Items.Add(serveritem);

            }
        }

        #region ServerSaveLoad
        private void SaveServers()
        {
            StreamWriter wr = new StreamWriter("servers.txt");
            wr.NewLine = Environment.NewLine;
            foreach (KMPServer s in servers)
            {
                wr.Write(SERVER_CONST);
                wr.Write(Environment.NewLine);

                wr.Write(s.Name);
                wr.Write(Environment.NewLine);

                wr.Write(s.IP);
                wr.Write(Environment.NewLine);

                wr.Write(s.Port);
                wr.Write(Environment.NewLine);

            }
            wr.Close();
        }

        private void LoadServers()
        {
            if (!File.Exists("servers.txt"))
            {
                FileStream file = File.Create("servers.txt");
                file.Close();
            }
            StreamReader reader = new StreamReader("servers.txt");
            while (reader.ReadLine() == SERVER_CONST)
            {
                KMPServer server = new KMPServer();
                server.Name = reader.ReadLine();
                server.IP = reader.ReadLine();
                server.Port = int.Parse(reader.ReadLine());

                servers.Add(server);
            }

            reader.Close();
        } 
        #endregion

        private void label1_Click(object sender, EventArgs e)
        {
            NetworkWorker.RunWorkerAsync();
        }


        

        #region NetworkWorker
        private void NetworkWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            List<KMPServer> serversinternal = servers;

            worker.ReportProgress(0);
            int index = 1;
            foreach (KMPServer s in serversinternal)
            {
                try
                {
                    KMPServer filled = ServerInformationRetriever.Retrieve(s.IP, s.HTTPPort);//This is terrible, I know. I wish it wasn't so mean to me and just let me do s = filled
                    s.MaxPlayers = filled.MaxPlayers;
                    s.Players = filled.Players;
                    s.Information = filled.Information;
                    s.Version = filled.Version;
                    s.PlayerList = filled.PlayerList;

                    float relativepercentage = (float)index / (float)serversinternal.Count;

                    int percentage = Convert.ToInt32(relativepercentage * 100.0f);

                    worker.ReportProgress(percentage);

                }
                catch (System.Net.WebException)
                {
                    s.Information = "-NO CONNECTION-";
                }
                index++;
            }
            e.Result = serversinternal;
        }

        private void NetworkWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Text = "Kerbal Multiplayer Launcher - Refreshing: " + e.ProgressPercentage + "%";
            
        }

        private void NetworkWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            servers = (List<KMPServer>)e.Result;

            this.Text = "Kerbal Multiplayer Launcher";
            RefreshButton.Enabled = true;

            PopulateServerList();
        }
        
        #endregion

        #region ServerListEvents
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveServers();
            SaveUpdaterSettings();
        }

        private void AddNewServer_Click(object sender, EventArgs e)
        {
            KMPServer server = new KMPServer();
            server.Name = textBoxName.Text;

            string address = textBoxAddress.Text;
            string[] splitaddress = address.Split(':');

            server.IP = splitaddress[0];
            try
            {
                server.Port = int.Parse(splitaddress[1]);
            }
            catch (Exception)
            {
                server.Port = 2076;
            }


            try
            {
                server.HTTPPort = int.Parse(textBoxHTTPPort.Text);
            }
            catch (Exception)
            {
                server.HTTPPort = 8081;
            }


            servers.Add(server);


            RefreshServerList();
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            if (selection.Version == UpdaterSettings.CurrentKMPUpdate)
            {

                StreamWriter wr = new StreamWriter(UpdaterSettings.KMPDirectory + @"\PluginData\KerbalMultiPlayer\KMPClientConfig.txt");

                wr.WriteLine("username");
                wr.WriteLine(UserNameInput.Text);

                wr.WriteLine("ip");
                wr.WriteLine("");

                wr.WriteLine("reconnect");
                wr.WriteLine("True");

                wr.WriteLine("fav0");
                wr.WriteLine(selection.Address);

                wr.Close();

                Process.Start(UpdaterSettings.KSPExecutable);
            }
            else
            {
                MessageBox.Show("Version mis-match.");
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshServerList();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            selection = new KMPServer();
            foreach (KMPServer s in servers)
            {
                if (s.Address == e.Item.SubItems[1].Text)
                {
                    selection = s;
                    break;
                }
            }

            PlayerListBox.Items.Clear();
            foreach (string s in selection.PlayerList)
            {
                PlayerListBox.Items.Add(s);
            }

        } 
        #endregion

        #region PrettyTextBoxes
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            servers.Remove(selection);
            RefreshServerList();
        }

        private void textBoxName_Enter(object sender, EventArgs e)
        {
            if (textBoxName.Text == "Name")
            {
                textBoxName.Text = "";
            }
        }

        private void textBoxIP_Enter(object sender, EventArgs e)
        {
            if (textBoxAddress.Text == "Address")
            {
                textBoxAddress.Text = "";
            }
        }




        private void textBoxHTTPAddress_Enter(object sender, EventArgs e)
        {
            if (textBoxHTTPPort.Text == "HTTP Port")
            {
                textBoxHTTPPort.Text = "";
            }
        }


        #endregion

        private void FolderBrowseButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            directoryPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void directoryPath_TextChanged(object sender, EventArgs e)
        {
            UpdateUpdaterSettings();
        }

        private void UpdateUpdaterSettings()
        {
            //Check if the directory contains KSP
            if (File.Exists(directoryPath.Text + @"\KSP.exe"))
            {
                KSPStatusLabel.Text = "Kerbal Space Program found";
                UpdaterSettings.KSPExecutable = directoryPath.Text + @"\KSP.exe";
                UpdaterSettings.KSPDirectory = directoryPath.Text;
            }
            else
            {
                KSPStatusLabel.Text = "Kerbal Space Program not found";
            }

            //Check if the directory contains KSP
            if (File.Exists(directoryPath.Text + @"\GameData\KMP\Plugins\KerbalMultiPlayer.dll"))
            {
                KMPStatusLabel.Text = "Kerbal Multiplayer found";
                UpdaterSettings.KMPDirectory = directoryPath.Text + @"\GameData\KMP\Plugins";
                UpdaterSettings.KMPExecutable = directoryPath.Text + @"\GameData\KMP\Plugins\KerbalMultiPlayer.dll";
            }
            else
            {
                KMPStatusLabel.Text = "Kerbal Multiplayer not found";
            }

            CheckUpdate();
        }

        private void CheckUpdate()
        {
            KMPVersionLabel.Text = UpdaterSettings.CurrentKMPUpdate;

            UpdateInformationRetriever.Retrieve();

            KMPLatestUpdateLabel.Text = UpdateInfo.LatestVersion;
        }



        #region UpdaterSaveLoad
        private void SaveUpdaterSettings()
        {
            StreamWriter wr = new StreamWriter("updater.txt");


            wr.Write(UpdaterSettings.KSPDirectory);
            wr.Write(Environment.NewLine);

            wr.Close();
        }
        private void LoadUpdaterSettings()
        {
            if (!File.Exists("updater.txt"))
            {
                FileStream file = File.Create("updater.txt");
                file.Close();
            }
            StreamReader reader = new StreamReader("updater.txt");

            directoryPath.Text = reader.ReadLine();

            reader.Close();
        } 
        #endregion

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            KMPUpdater.Update(UpdateInfo.DownloadURL);
        }

        private void UpdateCheckButton_Click(object sender, EventArgs e)
        {
            UpdateUpdaterSettings();
        }



       


    }
}
