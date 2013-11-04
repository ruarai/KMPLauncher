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

namespace KMPLauncher
{
    public partial class Form1 : Form
    {
        List<KMPServer> servers = new List<KMPServer>();
        KMPServer selection = new KMPServer();

        string SERVER_CONST = "STARTSERVER";

        public Form1()
        {
            InitializeComponent();

            LoadServers();

            RefreshServerList();

            SaveServers();
        }

        private void RefreshServerList()
        {
            RefreshButton.Enabled = false;
            listView1.Items.Clear();
            
            NetworkWorker.RunWorkerAsync();

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
            while(reader.ReadLine() == SERVER_CONST)
            {
                KMPServer server = new KMPServer();
                server.Name = reader.ReadLine();
                server.IP = reader.ReadLine();
                server.Port = int.Parse(reader.ReadLine());

                servers.Add(server);
            }

            reader.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            NetworkWorker.RunWorkerAsync();
        }


        private void AddNewServer_Click(object sender, EventArgs e)
        {
            KMPServer server = new KMPServer();
            server.Name = textBoxName.Text;
            server.IP = textBoxIP.Text;
            try
            {
                server.Port = int.Parse(textBoxPort.Text);
            }
            catch (Exception)
            {
                server.Port = 2076;
            }

            servers.Add(server);


            RefreshServerList();
        }

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
                    s.Name = filled.Name;
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveServers();
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {

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
            foreach (string s in selection.PlayerList)
            {
                PlayerListBox.Items.Add(s);
            }

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            servers.Remove(selection);
            RefreshServerList();
        }




    }
}
