namespace KMPLauncher
{
    partial class LauncherForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
            this.listView1 = new System.Windows.Forms.ListView();
            this.ServerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServerAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServerVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServerPlayers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServerDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBoxHTTPPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.UserNameInput = new System.Windows.Forms.TextBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PlayerListBox = new System.Windows.Forms.ListBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.AddNewServer = new System.Windows.Forms.Button();
            this.JoinButton = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.UpdateCheckButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.KMPLatestUpdateLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.KMPVersionLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.KMPStatusLabel = new System.Windows.Forms.Label();
            this.KSPStatusLabel = new System.Windows.Forms.Label();
            this.FolderBrowseButton = new System.Windows.Forms.Button();
            this.directoryPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NetworkWorker = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ServerInformationListBox = new System.Windows.Forms.ListBox();
            this.ChangelogBox = new System.Windows.Forms.RichTextBox();
            this.ChangelogGroupBox = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.ChangelogGroupBox.SuspendLayout();
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
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(6, 33);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(740, 169);
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
            this.ServerDescription.Width = 390;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 338);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.textBoxHTTPPort);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.UserNameInput);
            this.tabPage2.Controls.Add(this.DeleteButton);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.RefreshButton);
            this.tabPage2.Controls.Add(this.AddNewServer);
            this.tabPage2.Controls.Add(this.JoinButton);
            this.tabPage2.Controls.Add(this.textBoxName);
            this.tabPage2.Controls.Add(this.textBoxAddress);
            this.tabPage2.Controls.Add(this.listView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(752, 312);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Servers";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBoxHTTPPort
            // 
            this.textBoxHTTPPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxHTTPPort.Location = new System.Drawing.Point(6, 280);
            this.textBoxHTTPPort.Name = "textBoxHTTPPort";
            this.textBoxHTTPPort.Size = new System.Drawing.Size(100, 20);
            this.textBoxHTTPPort.TabIndex = 14;
            this.textBoxHTTPPort.Text = "HTTP Port";
            this.textBoxHTTPPort.Enter += new System.EventHandler(this.textBoxHTTPAddress_Enter);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(500, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Name:";
            // 
            // UserNameInput
            // 
            this.UserNameInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UserNameInput.Location = new System.Drawing.Point(544, 9);
            this.UserNameInput.Name = "UserNameInput";
            this.UserNameInput.Size = new System.Drawing.Size(121, 20);
            this.UserNameInput.TabIndex = 11;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(87, 6);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(58, 23);
            this.DeleteButton.TabIndex = 10;
            this.DeleteButton.Text = "Remove";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.PlayerListBox);
            this.groupBox1.Location = new System.Drawing.Point(544, 208);
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
            this.RefreshButton.Location = new System.Drawing.Point(6, 6);
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
            this.AddNewServer.Location = new System.Drawing.Point(112, 278);
            this.AddNewServer.Name = "AddNewServer";
            this.AddNewServer.Size = new System.Drawing.Size(47, 23);
            this.AddNewServer.TabIndex = 6;
            this.AddNewServer.Text = "Add";
            this.AddNewServer.UseVisualStyleBackColor = true;
            this.AddNewServer.Click += new System.EventHandler(this.AddNewServer_Click);
            // 
            // JoinButton
            // 
            this.JoinButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.JoinButton.Location = new System.Drawing.Point(671, 7);
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
            this.textBoxName.Location = new System.Drawing.Point(6, 251);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(153, 20);
            this.textBoxName.TabIndex = 4;
            this.textBoxName.Text = "Name";
            this.textBoxName.Enter += new System.EventHandler(this.textBoxName_Enter);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxAddress.Location = new System.Drawing.Point(6, 220);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(153, 20);
            this.textBoxAddress.TabIndex = 2;
            this.textBoxAddress.Text = "Address";
            this.textBoxAddress.Enter += new System.EventHandler(this.textBoxIP_Enter);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ChangelogGroupBox);
            this.tabPage1.Controls.Add(this.UpdateCheckButton);
            this.tabPage1.Controls.Add(this.UpdateButton);
            this.tabPage1.Controls.Add(this.KMPLatestUpdateLabel);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.KMPVersionLabel);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.KMPStatusLabel);
            this.tabPage1.Controls.Add(this.KSPStatusLabel);
            this.tabPage1.Controls.Add(this.FolderBrowseButton);
            this.tabPage1.Controls.Add(this.directoryPath);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(752, 312);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Updater";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // UpdateCheckButton
            // 
            this.UpdateCheckButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateCheckButton.Location = new System.Drawing.Point(536, 97);
            this.UpdateCheckButton.Name = "UpdateCheckButton";
            this.UpdateCheckButton.Size = new System.Drawing.Size(97, 23);
            this.UpdateCheckButton.TabIndex = 10;
            this.UpdateCheckButton.Text = "Refresh Checks";
            this.UpdateCheckButton.UseVisualStyleBackColor = true;
            this.UpdateCheckButton.Click += new System.EventHandler(this.UpdateCheckButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateButton.Location = new System.Drawing.Point(639, 97);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(97, 23);
            this.UpdateButton.TabIndex = 9;
            this.UpdateButton.Text = "Update KMP";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // KMPLatestUpdateLabel
            // 
            this.KMPLatestUpdateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KMPLatestUpdateLabel.AutoSize = true;
            this.KMPLatestUpdateLabel.Location = new System.Drawing.Point(696, 71);
            this.KMPLatestUpdateLabel.Name = "KMPLatestUpdateLabel";
            this.KMPLatestUpdateLabel.Size = new System.Drawing.Size(40, 13);
            this.KMPLatestUpdateLabel.TabIndex = 8;
            this.KMPLatestUpdateLabel.Text = "0.0.0.0";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(588, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Latest KMP version:";
            // 
            // KMPVersionLabel
            // 
            this.KMPVersionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KMPVersionLabel.AutoSize = true;
            this.KMPVersionLabel.Location = new System.Drawing.Point(696, 48);
            this.KMPVersionLabel.Name = "KMPVersionLabel";
            this.KMPVersionLabel.Size = new System.Drawing.Size(40, 13);
            this.KMPVersionLabel.TabIndex = 6;
            this.KMPVersionLabel.Text = "0.0.0.0";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(542, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Current installed KMP version:";
            // 
            // KMPStatusLabel
            // 
            this.KMPStatusLabel.AutoSize = true;
            this.KMPStatusLabel.Location = new System.Drawing.Point(6, 71);
            this.KMPStatusLabel.Name = "KMPStatusLabel";
            this.KMPStatusLabel.Size = new System.Drawing.Size(138, 13);
            this.KMPStatusLabel.TabIndex = 4;
            this.KMPStatusLabel.Text = "Kerbal Multiplayer not found";
            // 
            // KSPStatusLabel
            // 
            this.KSPStatusLabel.AutoSize = true;
            this.KSPStatusLabel.Location = new System.Drawing.Point(6, 48);
            this.KSPStatusLabel.Name = "KSPStatusLabel";
            this.KSPStatusLabel.Size = new System.Drawing.Size(161, 13);
            this.KSPStatusLabel.TabIndex = 3;
            this.KSPStatusLabel.Text = "Kerbal Space Program not found";
            // 
            // FolderBrowseButton
            // 
            this.FolderBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderBrowseButton.Location = new System.Drawing.Point(673, 10);
            this.FolderBrowseButton.Name = "FolderBrowseButton";
            this.FolderBrowseButton.Size = new System.Drawing.Size(63, 23);
            this.FolderBrowseButton.TabIndex = 2;
            this.FolderBrowseButton.Text = "Browse...";
            this.FolderBrowseButton.UseVisualStyleBackColor = true;
            this.FolderBrowseButton.Click += new System.EventHandler(this.FolderBrowseButton_Click);
            // 
            // directoryPath
            // 
            this.directoryPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryPath.Location = new System.Drawing.Point(85, 12);
            this.directoryPath.Name = "directoryPath";
            this.directoryPath.Size = new System.Drawing.Size(582, 20);
            this.directoryPath.TabIndex = 1;
            this.directoryPath.TextChanged += new System.EventHandler(this.directoryPath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "KSP Directory";
            // 
            // NetworkWorker
            // 
            this.NetworkWorker.WorkerReportsProgress = true;
            this.NetworkWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.NetworkWorker_DoWork);
            this.NetworkWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.NetworkWorker_ProgressChanged);
            this.NetworkWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.NetworkWorker_RunWorkerCompleted);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.ProgramFilesX86;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ServerInformationListBox);
            this.groupBox2.Location = new System.Drawing.Point(320, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 93);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server Information";
            // 
            // ServerInformationListBox
            // 
            this.ServerInformationListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ServerInformationListBox.FormattingEnabled = true;
            this.ServerInformationListBox.Location = new System.Drawing.Point(6, 19);
            this.ServerInformationListBox.Name = "ServerInformationListBox";
            this.ServerInformationListBox.Size = new System.Drawing.Size(207, 69);
            this.ServerInformationListBox.TabIndex = 9;
            // 
            // ChangelogBox
            // 
            this.ChangelogBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangelogBox.Location = new System.Drawing.Point(6, 19);
            this.ChangelogBox.Name = "ChangelogBox";
            this.ChangelogBox.ReadOnly = true;
            this.ChangelogBox.Size = new System.Drawing.Size(715, 147);
            this.ChangelogBox.TabIndex = 11;
            this.ChangelogBox.Text = "";
            // 
            // ChangelogGroupBox
            // 
            this.ChangelogGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangelogGroupBox.Controls.Add(this.ChangelogBox);
            this.ChangelogGroupBox.Location = new System.Drawing.Point(9, 134);
            this.ChangelogGroupBox.Name = "ChangelogGroupBox";
            this.ChangelogGroupBox.Size = new System.Drawing.Size(727, 172);
            this.ChangelogGroupBox.TabIndex = 12;
            this.ChangelogGroupBox.TabStop = false;
            this.ChangelogGroupBox.Text = "Changelog";
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 362);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "LauncherForm";
            this.Text = "Kerbal Multiplayer Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ChangelogGroupBox.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Button AddNewServer;
        private System.ComponentModel.BackgroundWorker NetworkWorker;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.ListBox PlayerListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button FolderBrowseButton;
        private System.Windows.Forms.TextBox directoryPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label KMPStatusLabel;
        private System.Windows.Forms.Label KSPStatusLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label KMPVersionLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label KMPLatestUpdateLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox UserNameInput;
        private System.Windows.Forms.TextBox textBoxHTTPPort;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button UpdateCheckButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox ServerInformationListBox;
        private System.Windows.Forms.GroupBox ChangelogGroupBox;
        private System.Windows.Forms.RichTextBox ChangelogBox;
    }
}

