﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace KMPLauncher
{
    public partial class LauncherForm : Form
    {
        List<KMPServer> PlayerServers = new List<KMPServer>();
        List<KMPServer> GlobalServers = new List<KMPServer>();

        KMPServer LastSelectedServer = new KMPServer();//The server the user had last selected
        ListViewItem LastSelectedListViewItem = new ListViewItem();

        ListViewGroup PlayerServerGroup = new ListViewGroup("Player Added Servers");
        ListViewGroup GlobalServerGroup = new ListViewGroup("Community Servers");

        private const string SERVER_CONST = "STARTSERVER";

        public LauncherForm()
        {
            InitializeComponent();
            ChangelogBox.BackColor = SystemColors.Window;
            KSPLogBox.BackColor = SystemColors.Window;

            KMPUpdater.UpdateComplete += KMPUpdater_UpdateComplete;
            KMPUpdater.UpdateProgressChange += KMPUpdater_UpdateProgressChange;

            UpdateInformationRetriever.RetrieveComplete += UpdateInformationRetriever_RetrieveComplete;
            ChangelogRetriever.RetrieveComplete += ChangelogRetriever_RetrieveComplete;

            GlobalServerRetriever.Retrieved += GlobalServerRetriever_Retrieved;


            Log.Write("Applied events. Calling InitLauncherDirectory");
            InitLauncherDirectory();

            Log.Write("Calling LoadServers");
            LoadServers();
            Log.Write("Calling LoadUpdaterSettings");
            LoadUpdaterSettings();

            Log.Write("Calling FillServerList");
            FillServerList();

            Log.Write("Calling CheckUpdate");
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


        private void FillServerList()
        {
            listView1.Items.Clear();

            var retriever = new ServerInformationRetrieverAsync();

            retriever.ServerRetrieved += retrieverLocal_ServerRetrieved;
            foreach (KMPServer s in PlayerServers)
            {
                retriever.RetrieveAsync(s, s.HTTPPort);
                
            }

            GlobalServerRetriever.Retrieve();
        }


        void retrieverLocal_ServerRetrieved(KMPServer s)
        {
            var serveritem = new ListViewItem(s.Name);
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


        void GlobalServerRetriever_Retrieved(List<KMPServer> serverlist)
        {
            GlobalServers = serverlist;


            var retriever = new ServerInformationRetrieverAsync();

            retriever.ServerRetrieved += retrieverGlobal_ServerRetrieved;

            foreach (KMPServer s in GlobalServers)
            {
                retriever.RetrieveAsync(s, s.HTTPPort);
            }
        }


        private void retrieverGlobal_ServerRetrieved(KMPServer s)
        {
            if (!s.HasHTTPConnection)
            {
                return;//Dont even bother if no http connection.
            }

            var serveritem = new ListViewItem(s.Name);
            serveritem.SubItems.Add(s.IP + ":" + s.Port);
            serveritem.SubItems.Add(s.Version);
            serveritem.SubItems.Add(s.Players + "/" + s.MaxPlayers);
            serveritem.SubItems.Add(s.Information);

            serveritem.Group = GlobalServerGroup;

            listView1.Groups.Add(GlobalServerGroup);
            listView1.Items.Add(serveritem);
        }


        #endregion

        #region ServerSaveLoad
        private void SaveServers()
        {
            var wr = new StreamWriter(UpdaterSettings.LAUNCHER_FOLDER + UpdaterSettings.SERVER_FILE)
                         {NewLine = Environment.NewLine};
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
            var reader = new StreamReader(UpdaterSettings.LAUNCHER_FOLDER + UpdaterSettings.SERVER_FILE);
            while (reader.ReadLine() == SERVER_CONST)
            {
                var server = new KMPServer
                                 {Name = reader.ReadLine(), IP = reader.ReadLine(), Port = int.Parse(reader.ReadLine())};
                if (!String.IsNullOrEmpty(server.IP))
                {
                    PlayerServers.Add(server);
                }
            }

            reader.Close();
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
            if (PlayerServers.Exists(ser => ser.Address == textBoxAddress.Text))
            {
                MessageBox.Show("Server already exists.");
                return;
            }
            var server = new KMPServer {Name = textBoxName.Text, Address = textBoxAddress.Text};

            PlayerServers.Add(server);


            FillServerList();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {

            LastSelectedServer.Name = textBoxName.Text;

            LastSelectedServer.Address = textBoxAddress.Text;

            var retriever = new ServerInformationRetrieverAsync();

            retriever.ServerRetrieved +=retriever_EditServerRetrieved;

            retriever.RetrieveAsync(LastSelectedServer, 8081);

        }

        private void retriever_EditServerRetrieved(KMPServer s)
        {
            LastSelectedServer = s;

            LastSelectedListViewItem.SubItems.Clear();

            LastSelectedListViewItem.Text = LastSelectedServer.Name;

            LastSelectedListViewItem.SubItems.Add(LastSelectedServer.IP + ":" + LastSelectedServer.Port);
            LastSelectedListViewItem.SubItems.Add(LastSelectedServer.Version);
            LastSelectedListViewItem.SubItems.Add(LastSelectedServer.Players + "/" + LastSelectedServer.MaxPlayers);
            LastSelectedListViewItem.SubItems.Add(LastSelectedServer.Information);

            if (!LastSelectedServer.HasHTTPConnection)
            {
                LastSelectedListViewItem.ForeColor = Color.DarkRed;
            }
        }


        private void UserNameInput_TextChanged(object sender, EventArgs e)
        {
            UpdaterSettings.Username = UserNameInput.Text;
        }


        private void JoinButton_Click(object sender, EventArgs e)
        {
            UpdateUpdaterSettings();
            KMPJoiner.JoinKMPServer(LastSelectedServer);
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            FillServerList();
        }

        private void ServerInformationListBox_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            LastSelectedListViewItem.BackColor = SystemColors.Window;//Remove highlight from last selection

            e.Item.BackColor = SystemColors.Highlight;//Add highlight to new selection

            LastSelectedListViewItem = e.Item;//Make this 'last selection'

            LastSelectedServer = new KMPServer();
            if (LastSelectedListViewItem.Group == PlayerServerGroup)
            {
                foreach (KMPServer s in PlayerServers.Where(s => s.Address == e.Item.SubItems[1].Text))
                {
                    LastSelectedServer = s;
                    break;
                }
            }
            else if (LastSelectedListViewItem.Group == GlobalServerGroup)
            {
                foreach (KMPServer s in GlobalServers.Where(s => s.Address == e.Item.SubItems[1].Text))
                {
                    LastSelectedServer = s;
                    break;
                }
            }
            else
            {
                return;//dont bother if a server isn't found
            }


            textBoxName.Text = LastSelectedServer.Name;
            textBoxAddress.Text = LastSelectedServer.Address;

            textBoxAddress.ForeColor = SystemColors.WindowText;
            textBoxName.ForeColor = SystemColors.WindowText;

            ServerInformationListBox.Items.Clear();

            ServerInformationListBox.Items.Add("Whitelist: " + LastSelectedServer.Whitelisted.ToString().ToLower());
            ServerInformationListBox.Items.Add("Screenshots Save: " + LastSelectedServer.Screenshots.ToString().ToLower());
            ServerInformationListBox.Items.Add("Screenshot Height: " + LastSelectedServer.ScreenshotHeight);
            ServerInformationListBox.Items.Add("Update Rate: " + LastSelectedServer.UpdateRate);
            ServerInformationListBox.Items.Add("Inactive Ship Limit: " + LastSelectedServer.InactiveShipLimit);

            PlayerListBox.Items.Clear();
            foreach (string s in LastSelectedServer.PlayerList)
            {
                PlayerListBox.Items.Add(s);
            }

        } 
        
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            LastSelectedListViewItem.Remove();
            PlayerServers.Remove(LastSelectedServer);
        }
        #endregion

        #region PrettyTextBoxes
        

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
            
            UpdateInformationRetriever.Retrieve();

            ChangelogRetriever.Retrieve();
        }


        void UpdateInformationRetriever_RetrieveComplete()
        {

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
        }


        void ChangelogRetriever_RetrieveComplete(string changelog)
        {
            ChangelogBox.Text = changelog;
        }

        #endregion

        #region UpdaterSaveLoad
        private void SaveUpdaterSettings()
        {
            var wr = new StreamWriter(UpdaterSettings.LAUNCHER_FOLDER + UpdaterSettings.UPDATER_FILE);


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
            var reader = new StreamReader(UpdaterSettings.LAUNCHER_FOLDER + UpdaterSettings.UPDATER_FILE);

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
            if (UpdaterSettings.KSPExists)
            {
                UpdateButton.Enabled = false;
                KMPUpdater.Update(UpdateInfo.DownloadURL);
            }
            else
            {
                MessageBox.Show("KSP cannot be found, updater cannot continue.");
            }
        }

        private void UpdateCheckButton_Click(object sender, EventArgs e)
        {
            UpdateUpdaterSettings();
        }


        void KMPUpdater_UpdateComplete()
        {
            UpdateUpdaterSettings();
            UpdateButton.Enabled = true;
            UpdateButton.Text = "Update KMP";
        }


        void KMPUpdater_UpdateProgressChange(System.Net.DownloadProgressChangedEventArgs e)
        {
            UpdateButton.Text = "Updating:" + e.ProgressPercentage + "%";
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

                KSPLogBox.Clear();

                var fs = new FileStream(UpdaterSettings.KSPDirectory + @"\KSP.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                var reader = new StreamReader(fs);

                string log = reader.ReadToEnd();

                if (fs.Length < 1024 * 1024)//Only do fancy log reading if filesize is below 1KB
                {
                    string[] lines = log.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string s in lines)
                    {
                        if (s.StartsWith("[EXC"))
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

                    try
                    {

                        DateTime CreationDateTime = Convert.ToDateTime(LogCreationDate);


                        string TimeSince;
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
                    catch
                    {

                    }
                }
                else
                {
                    KSPLogBox.Text = log;
                }



            }
            catch (IOException)
            {
                KSPLogBox.Text = "Log not found.";
            }
            if (File.Exists(UpdaterSettings.KSPDirectory + @"\KSP.log"))
            {
                KMPLogLink.Text = UpdaterSettings.KSPDirectory + @"\KSP.log";
            }
            else
            {
                KMPLogLink.Text = "";
            }
        }

        private void Logging_Enter(object sender, EventArgs e)
        {
            LoadLog();//Reload the log when you switch to the logging tab
        }

        private void KMPLogLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(UpdaterSettings.KSPDirectory + @"\KSP.log");
            }
            catch
            {

            }

        }
        
        #endregion



        





       


    }
}
