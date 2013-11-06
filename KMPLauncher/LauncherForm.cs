﻿using System;
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
    public partial class LauncherForm : Form
    {
        List<KMPServer> PlayerServers = new List<KMPServer>();

        KMPServer selection = new KMPServer();//The server the user had last selected

        ListViewGroup PlayerServerGroup = new ListViewGroup("Player Added Servers");

        static string APP_DATA = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\KMPLauncher\";

        readonly string SERVER_CONST = "STARTSERVER";

        public LauncherForm()
        {
            InitializeComponent();

            InitLauncherDirectory();

            LoadServers();
            LoadUpdaterSettings();

            RefreshServerList();

            CheckUpdate();
        }

        private void InitLauncherDirectory()
        {
            if (!Directory.Exists(APP_DATA))
            {
                Directory.CreateDirectory(APP_DATA);
            }
        }

        #region ServerListing
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
            foreach (KMPServer s in PlayerServers)
            {
                ListViewItem serveritem = new ListViewItem(s.Name);
                serveritem.SubItems.Add(s.IP + ":" + s.Port);
                serveritem.SubItems.Add(s.Version);
                serveritem.SubItems.Add(s.Players + "/" + s.MaxPlayers);
                serveritem.SubItems.Add(s.Information);
                serveritem.Group = PlayerServerGroup;

                listView1.Groups.Add(PlayerServerGroup);
                listView1.Items.Add(serveritem);
            }
        } 
        #endregion

        #region ServerSaveLoad
        private void SaveServers()
        {
            StreamWriter wr = new StreamWriter(APP_DATA + "servers.txt");
            wr.NewLine = Environment.NewLine;
            foreach (KMPServer s in PlayerServers)
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
            if (!File.Exists(APP_DATA + "servers.txt"))
            {
                FileStream file = File.Create(APP_DATA + "servers.txt");
                file.Close();
            }
            StreamReader reader = new StreamReader(APP_DATA + "servers.txt");
            while (reader.ReadLine() == SERVER_CONST)
            {
                KMPServer server = new KMPServer();
                server.Name = reader.ReadLine();
                server.IP = reader.ReadLine();
                server.Port = int.Parse(reader.ReadLine());

                PlayerServers.Add(server);
            }

            reader.Close();
        } 
        #endregion


        #region ServerListRetriever
        private void NetworkWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            List<KMPServer> Playerserversinternal = PlayerServers;

            worker.ReportProgress(0);
            int index = 1;
            foreach (KMPServer s in Playerserversinternal)
            {
                try
                {
                    KMPServer filled = ServerInformationRetriever.Retrieve(s.IP, s.HTTPPort);//This is terrible, I know. I wish it wasn't so mean to me and just let me do s = filled
                    s.MaxPlayers = filled.MaxPlayers;
                    s.Players = filled.Players;
                    s.Information = filled.Information;
                    s.Version = filled.Version;
                    s.PlayerList = filled.PlayerList;
                    s.UpdateRate = filled.UpdateRate;
                    s.Whitelisted = filled.Whitelisted;
                    s.Screenshots = filled.Screenshots;
                    s.ScreenshotHeight = filled.ScreenshotHeight;
                    s.InactiveShipLimit = filled.InactiveShipLimit;

                    float relativepercentage = (float)index / (float)Playerserversinternal.Count;

                    int percentage = Convert.ToInt32(relativepercentage * 100.0f);

                    worker.ReportProgress(percentage);

                }
                catch (System.Net.WebException)
                {
                    s.Information = "-NO CONNECTION-";
                }
                index++;
            }
            e.Result = Playerserversinternal;
        }

        private void NetworkWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Text = "Kerbal Multiplayer Launcher - Refreshing: " + e.ProgressPercentage + "%";
            
        }

        private void NetworkWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PlayerServers = (List<KMPServer>)e.Result;

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


            PlayerServers.Add(server);


            RefreshServerList();
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            UpdateUpdaterSettings();
            if (selection.Version == UpdaterSettings.CurrentKMPUpdate)
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
                    MessageBox.Show("Please check directory settings. KSP or KMP not found.");
                }
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
            foreach (KMPServer s in PlayerServers)
            {
                if (s.Address == e.Item.SubItems[1].Text)
                {
                    selection = s;
                    break;
                }
            }

            ServerInformationListBox.Items.Clear();

            ServerInformationListBox.Items.Add("Whitelist: " + selection.Whitelisted.ToString().ToLower());
            ServerInformationListBox.Items.Add("Screenshots: " + selection.Screenshots.ToString().ToLower());
            ServerInformationListBox.Items.Add("Screenshot Height: " + selection.ScreenshotHeight.ToString());
            ServerInformationListBox.Items.Add("Update Rate: " + selection.UpdateRate.ToString());
            ServerInformationListBox.Items.Add("Inactive Ship Limit: " + selection.InactiveShipLimit.ToString());

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
            PlayerServers.Remove(selection);
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

        

        #region Updater
        private void UpdateUpdaterSettings()
        {
            //Check if the directory contains KSP
            if (File.Exists(directoryPath.Text + @"\KSP.exe"))
            {
                KSPStatusLabel.Text = "Kerbal Space Program found";
                UpdaterSettings.KSPExecutable = directoryPath.Text + @"\KSP.exe";
                UpdaterSettings.KSPDirectory = directoryPath.Text;
                UpdaterSettings.KSPExists = true;
            }
            else
            {
                KSPStatusLabel.Text = "Kerbal Space Program not found";
                UpdaterSettings.KSPExists = false;
            }

            //Check if the directory contains KSP
            if (File.Exists(directoryPath.Text + @"\GameData\KMP\Plugins\KerbalMultiPlayer.dll"))
            {
                KMPStatusLabel.Text = "Kerbal Multiplayer found";
                UpdaterSettings.KMPDirectory = directoryPath.Text + @"\GameData\KMP\Plugins";
                UpdaterSettings.KMPExecutable = directoryPath.Text + @"\GameData\KMP\Plugins\KerbalMultiPlayer.dll";
                UpdaterSettings.KMPExists = true;
            }
            else
            {
                KMPStatusLabel.Text = "Kerbal Multiplayer not found";
                UpdaterSettings.KMPExists = false;
            }

            CheckUpdate();
        }

        private void CheckUpdate()
        {
            KMPVersionLabel.Text = UpdaterSettings.CurrentKMPUpdate;
            try
            {
                UpdateInformationRetriever.Retrieve();
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("Failed to retrieve latest KMP version!");
            }

            KMPLatestUpdateLabel.Text = UpdateInfo.LatestVersion;

            ChangelogGroupBox.Text = "Update Changelog (KMP Version " + UpdateInfo.LatestVersion.Trim() + ")";
            ChangelogBox.Text = ChangelogRetriever.Retrieve();
        } 
        #endregion

        #region UpdaterSaveLoad
        private void SaveUpdaterSettings()
        {
            StreamWriter wr = new StreamWriter(APP_DATA + "updater.txt");


            wr.Write(UpdaterSettings.KSPDirectory);
            wr.Write(Environment.NewLine);

            wr.Close();
        }
        private void LoadUpdaterSettings()
        {
            if (!File.Exists(APP_DATA + "updater.txt"))
            {
                FileStream file = File.Create(APP_DATA + "updater.txt");
                file.Close();
            }
            StreamReader reader = new StreamReader(APP_DATA + "updater.txt");

            directoryPath.Text = reader.ReadLine();

            reader.Close();
        } 
        #endregion

        #region UpdateEvents
        private void FolderBrowseButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            directoryPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void directoryPath_TextChanged(object sender, EventArgs e)
        {
            UpdateUpdaterSettings();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            KMPUpdater.Update(UpdateInfo.DownloadURL);
        }

        private void UpdateCheckButton_Click(object sender, EventArgs e)
        {
            UpdateUpdaterSettings();
        } 
        #endregion



       


    }
}
