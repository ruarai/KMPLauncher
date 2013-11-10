﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KMPLauncher
{
    public partial class LauncherForm : Form
    {
        List<KMPServer> PlayerServers = new List<KMPServer>();

        KMPServer selection = new KMPServer();//The server the user had last selected
        ListViewItem lastselecteditem = new ListViewItem();

        ListViewGroup PlayerServerGroup = new ListViewGroup("Player Added Servers");


        readonly string SERVER_CONST = "STARTSERVER";

        public LauncherForm()
        {
            InitializeComponent();
            ChangelogBox.BackColor = System.Drawing.SystemColors.Window;
            KSPLogBox.BackColor = System.Drawing.SystemColors.Window;

            InitLauncherDirectory();

            LoadServers();
            LoadUpdaterSettings();

            RefreshServerList();

            CheckUpdate();
        }

        private void InitLauncherDirectory()
        {
            if (!Directory.Exists(UpdaterSettings.LAUNCHER_FOLDER))
            {
                Directory.CreateDirectory(UpdaterSettings.LAUNCHER_FOLDER);
            }
        }

        #region ServerListing
        private void RefreshServerList()
        {
            RefreshButton.Enabled = false;
            listView1.Items.Clear();


            if (!ServerlistNetworker.IsBusy)
            {
                ServerlistNetworker.RunWorkerAsync();
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

                if (!s.HasHTTPConnection)
                {
                    serveritem.ForeColor = Color.DarkRed;
                }

                serveritem.Group = PlayerServerGroup;

                listView1.Groups.Add(PlayerServerGroup);
                listView1.Items.Add(serveritem);
            }
        } 
        #endregion

        #region ServerSaveLoad
        private void SaveServers()
        {
            StreamWriter wr = new StreamWriter(UpdaterSettings.LAUNCHER_FOLDER + UpdaterSettings.SERVER_FILE);
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
            if (!File.Exists(UpdaterSettings.LAUNCHER_FOLDER + UpdaterSettings.SERVER_FILE))
            {
                FileStream file = File.Create(UpdaterSettings.LAUNCHER_FOLDER + UpdaterSettings.SERVER_FILE);
                file.Close();
            }
            StreamReader reader = new StreamReader(UpdaterSettings.LAUNCHER_FOLDER + UpdaterSettings.SERVER_FILE);
            while (reader.ReadLine() == SERVER_CONST)
            {
                KMPServer server = new KMPServer();
                server.Name = reader.ReadLine();
                server.IP = reader.ReadLine();
                server.Port = int.Parse(reader.ReadLine());
                if (!String.IsNullOrEmpty(server.IP))
                {
                    PlayerServers.Add(server);
                }
            }

            reader.Close();
        } 
        #endregion


        #region ServerListRetriever
        private void ServerlistNetworker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            List<KMPServer> Playerserversinternal = PlayerServers;

            worker.ReportProgress(0);
            int index = 1;
            foreach (KMPServer s in Playerserversinternal)
            {
                try
                {
                    KMPServer filled = ServerInformationRetriever.Retrieve(s.IP, 8081);

                    s.MaxPlayers = filled.MaxPlayers;//This is terrible, I know. I wish it wasn't so mean to me and just let me do s = filled
                    s.Players = filled.Players;
                    s.Information = filled.Information;
                    s.Version = filled.Version;
                    s.PlayerList = filled.PlayerList;
                    s.UpdateRate = filled.UpdateRate;
                    s.Whitelisted = filled.Whitelisted;
                    s.Screenshots = filled.Screenshots;
                    s.ScreenshotHeight = filled.ScreenshotHeight;
                    s.InactiveShipLimit = filled.InactiveShipLimit;
                    s.HasHTTPConnection = true;



                    float relativepercentage = (float)index / (float)Playerserversinternal.Count;

                    int percentage = Convert.ToInt32(relativepercentage * 100.0f);

                    worker.ReportProgress(percentage);

                }
                catch (System.Net.WebException)
                {
                    s.Information = "-NO HTTP CONNECTION-";
                    s.HasHTTPConnection = false;
                }
                index++;
            }
            e.Result = Playerserversinternal;
        }

        private void ServerlistNetworker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Text = "Kerbal Multiplayer Launcher - Refreshing: " + e.ProgressPercentage + "%";
            
        }

        private void ServerlistNetworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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




            PlayerServers.Add(server);


            RefreshServerList();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            PlayerServers.Remove(selection);

            selection.Name = textBoxName.Text;

            string address = textBoxAddress.Text;
            string[] splitaddress = address.Split(':');

            selection.IP = splitaddress[0];
            try
            {
                selection.Port = int.Parse(splitaddress[1]);
            }
            catch (Exception)
            {
                selection.Port = 2076;
            }




            PlayerServers.Add(selection);


            RefreshServerList();
        }


        private void UserNameInput_TextChanged(object sender, EventArgs e)
        {
            UpdaterSettings.Username = UserNameInput.Text;
        }


        private void JoinButton_Click(object sender, EventArgs e)
        {
            KMPJoiner.JoinKMPServer(selection);
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshServerList();
        }

        private void ServerInformationListBox_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            lastselecteditem.BackColor = SystemColors.Window;//Remove highlight from last selection

            e.Item.BackColor = SystemColors.Highlight;//Add highlight to new selection

            lastselecteditem = e.Item;//Make this 'last selection'

            selection = new KMPServer();
            foreach (KMPServer s in PlayerServers)
            {
                if (s.Address == e.Item.SubItems[1].Text)
                {
                    selection = s;
                    break;
                }
            }

            textBoxName.Text = selection.Name;
            textBoxAddress.Text = selection.Address;

            textBoxAddress.ForeColor = SystemColors.WindowText;
            textBoxName.ForeColor = SystemColors.WindowText;

            ServerInformationListBox.Items.Clear();

            ServerInformationListBox.Items.Add("Whitelist: " + selection.Whitelisted.ToString().ToLower());
            ServerInformationListBox.Items.Add("Screenshots Save: " + selection.Screenshots.ToString().ToLower());
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
            if (textBoxName.Text == "Name")//This code will reset the textbox when the user clicks
            {
                textBoxName.Text = "";
                textBoxName.ForeColor = SystemColors.WindowText;
            }
        }

        private void textBoxIP_Enter(object sender, EventArgs e)
        {
            if (textBoxAddress.Text == "Address")
            {
                textBoxAddress.Text = "";
                textBoxAddress.ForeColor = SystemColors.WindowText;
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
            try
            {
                ChangelogGroupBox.Text = "Update Changelog (KMP Version " + UpdateInfo.LatestVersion.Trim() + ")";
            }
            catch
            {
                ChangelogGroupBox.Text = "Update Changelog";
            }

            KMPForumLink.Text = UpdateInfo.ForumURL;
            KMPGithubLink.Text = UpdateInfo.GitHubURL;
            KMPIssuesLink.Text = UpdateInfo.GitHubIssuesURL;

            ChangelogBox.Text = ChangelogRetriever.Retrieve();
        } 
        #endregion

        #region UpdaterSaveLoad
        private void SaveUpdaterSettings()
        {
            StreamWriter wr = new StreamWriter(UpdaterSettings.LAUNCHER_FOLDER + UpdaterSettings.UPDATER_FILE);


            wr.Write(UpdaterSettings.KSPDirectory);
            wr.Write(Environment.NewLine);

            wr.Write(UpdaterSettings.Username);
            wr.Write(Environment.NewLine);

            wr.Close();
        }
        private void LoadUpdaterSettings()
        {
            if (!File.Exists(UpdaterSettings.LAUNCHER_FOLDER + UpdaterSettings.UPDATER_FILE))
            {
                FileStream file = File.Create(UpdaterSettings.LAUNCHER_FOLDER + UpdaterSettings.UPDATER_FILE);
                file.Close();
            }
            StreamReader reader = new StreamReader(UpdaterSettings.LAUNCHER_FOLDER + UpdaterSettings.UPDATER_FILE);

            directoryPath.Text = reader.ReadLine();

            UpdaterSettings.Username = reader.ReadLine();
            UserNameInput.Text = UpdaterSettings.Username;

            reader.Close();
        } 
        #endregion

        #region UpdateEvents
        private void FolderBrowseButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if (Directory.Exists(folderBrowserDialog1.SelectedPath))
            {
                directoryPath.Text = folderBrowserDialog1.SelectedPath;
            }
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

        #region Links
        private void KMPForumLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(KMPForumLink.Text);
        }

        private void KMPGithubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(KMPGithubLink.Text);
        }

        private void KMPIssuesLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(KMPIssuesLink.Text);
        } 
        #endregion

        #region LogViewer
        private void ReloadLogButton_Click(object sender, EventArgs e)
        {
            LoadLog();
        }

        private void LoadLog()
        {
            try
            {
                StreamReader reader = new StreamReader(UpdaterSettings.KSPDirectory + @"\KSP.log");

                string log = reader.ReadToEnd();

                string[] lines = log.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string s in lines)
                {
                    if(s.StartsWith("[EXC"))
                    {
                        KSPLogBox.AppendText(s, Color.Red);
                    }
                    else if (s.StartsWith("[ERR"))
                    {
                        KSPLogBox.AppendText(s, Color.DarkRed);
                    }
                    else if (s.StartsWith("[WRN"))
                    {
                        KSPLogBox.AppendText(s, Color.Orange);
                    }
                    else
                    {
                        KSPLogBox.AppendText(s);
                    }
                }


                string startedInfo = "";
                foreach (string s in lines)
                {
                    if (s.StartsWith("Log started:"))
                    {
                        startedInfo = s;
                        break;
                    }
                }

                string LogCreationDate = startedInfo.Replace("Log started:", "").Trim();


                DateTime CreationDateTime = Convert.ToDateTime(LogCreationDate);


                string TimeSince = "";
                TimeSpan ts = DateTime.Now.Subtract(CreationDateTime);
                if (ts.TotalHours < 1)
                    if (ts.Minutes == 1)
                        TimeSince = ts.Minutes + " minute ago";
                    else
                        TimeSince = ts.Minutes + " minutes ago";
                else if (ts.TotalDays < 1)
                    if (ts.Hours == 1)
                        TimeSince = ts.Hours + " hour ago";
                    else
                        TimeSince = ts.Hours + " hours ago";
                else
                    if (ts.Days == 1)
                        TimeSince = ts.Days + " day ago";
                    else
                        TimeSince = ts.Days + " days ago";

                LogGroupBox.Text = "Kerbal Space Program Log " + "(created " + TimeSince + ")";



            }
            catch (FileNotFoundException)
            {
                KSPLogBox.Text = "No log found.";
            }

            KMPLogLink.Text = UpdaterSettings.KSPDirectory + @"\KSP.log";
        }

        private void Logging_Enter(object sender, EventArgs e)
        {
            LoadLog();//Reload the log when you switch to the logging tab
        }

        private void KMPLogLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(UpdaterSettings.KSPDirectory + @"\KSP.log");

        }
        
        #endregion

        





       


    }
}
