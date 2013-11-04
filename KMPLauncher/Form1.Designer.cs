namespace KMPLauncher
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.ServerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServerAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServerVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServerPlayers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServerDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PlayerListBox = new System.Windows.Forms.ListBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.AddNewServer = new System.Windows.Forms.Button();
            this.JoinButton = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.NetworkWorker = new System.ComponentModel.BackgroundWorker();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.AutoArrange = false;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ServerName,
            this.ServerAddress,
            this.ServerVersion,
            this.ServerPlayers,
            this.ServerDescription});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(6, 6);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(586, 373);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // ServerName
            // 
            this.ServerName.Text = "Name";
            this.ServerName.Width = 120;
            // 
            // ServerAddress
            // 
            this.ServerAddress.Text = "Address";
            this.ServerAddress.Width = 120;
            // 
            // ServerVersion
            // 
            this.ServerVersion.Text = "Version";
            this.ServerVersion.Width = 49;
            // 
            // ServerPlayers
            // 
            this.ServerPlayers.Text = "Players";
            this.ServerPlayers.Width = 47;
            // 
            // ServerDescription
            // 
            this.ServerDescription.Text = "Description";
            this.ServerDescription.Width = 205;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(606, 515);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(598, 489);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Updater";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DeleteButton);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.RefreshButton);
            this.tabPage2.Controls.Add(this.AddNewServer);
            this.tabPage2.Controls.Add(this.JoinButton);
            this.tabPage2.Controls.Add(this.textBoxName);
            this.tabPage2.Controls.Add(this.textBoxPort);
            this.tabPage2.Controls.Add(this.textBoxIP);
            this.tabPage2.Controls.Add(this.listView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(598, 489);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Servers";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.PlayerListBox);
            this.groupBox1.Location = new System.Drawing.Point(215, 385);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 93);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Players";
            // 
            // PlayerListBox
            // 
            this.PlayerListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PlayerListBox.FormattingEnabled = true;
            this.PlayerListBox.Location = new System.Drawing.Point(6, 19);
            this.PlayerListBox.Name = "PlayerListBox";
            this.PlayerListBox.Size = new System.Drawing.Size(188, 69);
            this.PlayerListBox.TabIndex = 8;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshButton.Location = new System.Drawing.Point(517, 385);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 7;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // AddNewServer
            // 
            this.AddNewServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddNewServer.Location = new System.Drawing.Point(6, 454);
            this.AddNewServer.Name = "AddNewServer";
            this.AddNewServer.Size = new System.Drawing.Size(89, 24);
            this.AddNewServer.TabIndex = 6;
            this.AddNewServer.Text = "Add new server";
            this.AddNewServer.UseVisualStyleBackColor = true;
            this.AddNewServer.Click += new System.EventHandler(this.AddNewServer_Click);
            // 
            // JoinButton
            // 
            this.JoinButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.JoinButton.Location = new System.Drawing.Point(517, 455);
            this.JoinButton.Name = "JoinButton";
            this.JoinButton.Size = new System.Drawing.Size(75, 23);
            this.JoinButton.TabIndex = 5;
            this.JoinButton.Text = "Join";
            this.JoinButton.UseVisualStyleBackColor = true;
            this.JoinButton.Click += new System.EventHandler(this.JoinButton_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxName.Location = new System.Drawing.Point(6, 428);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(153, 20);
            this.textBoxName.TabIndex = 4;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxPort.Location = new System.Drawing.Point(112, 397);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(47, 20);
            this.textBoxPort.TabIndex = 3;
            // 
            // textBoxIP
            // 
            this.textBoxIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxIP.Location = new System.Drawing.Point(6, 397);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(100, 20);
            this.textBoxIP.TabIndex = 2;
            // 
            // NetworkWorker
            // 
            this.NetworkWorker.WorkerReportsProgress = true;
            this.NetworkWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.NetworkWorker_DoWork);
            this.NetworkWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.NetworkWorker_ProgressChanged);
            this.NetworkWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.NetworkWorker_RunWorkerCompleted);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteButton.Location = new System.Drawing.Point(101, 454);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(58, 24);
            this.DeleteButton.TabIndex = 10;
            this.DeleteButton.Text = "Remove";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 555);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Kerbal Multiplayer Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ColumnHeader ServerName;
        private System.Windows.Forms.ColumnHeader ServerAddress;
        private System.Windows.Forms.ColumnHeader ServerVersion;
        private System.Windows.Forms.ColumnHeader ServerPlayers;
        private System.Windows.Forms.ColumnHeader ServerDescription;
        private System.Windows.Forms.Button JoinButton;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Button AddNewServer;
        private System.ComponentModel.BackgroundWorker NetworkWorker;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.ListBox PlayerListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button DeleteButton;
    }
}

