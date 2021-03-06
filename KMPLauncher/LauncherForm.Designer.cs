﻿namespace KMPLauncher
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
            this.EditButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ServerInformationListBox = new System.Windows.Forms.ListBox();
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.KMPIssuesLink = new System.Windows.Forms.LinkLabel();
            this.KMPGithubLink = new System.Windows.Forms.LinkLabel();
            this.KMPForumLink = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.KSPStatusLabel = new System.Windows.Forms.Label();
            this.KMPStatusLabel = new System.Windows.Forms.Label();
            this.UpdateCheckButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.KMPVersionLabel = new System.Windows.Forms.Label();
            this.KMPLatestUpdateLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ChangelogGroupBox = new System.Windows.Forms.GroupBox();
            this.ChangelogBox = new System.Windows.Forms.RichTextBox();
            this.FolderBrowseButton = new System.Windows.Forms.Button();
            this.directoryPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Logging = new System.Windows.Forms.TabPage();
            this.LogGroupBox = new System.Windows.Forms.GroupBox();
            this.KMPLogLink = new System.Windows.Forms.LinkLabel();
            this.ReloadLogButton = new System.Windows.Forms.Button();
            this.KSPLogBox = new System.Windows.Forms.RichTextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.ChangelogGroupBox.SuspendLayout();
            this.Logging.SuspendLayout();
            this.LogGroupBox.SuspendLayout();
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
            this.listView1.Size = new System.Drawing.Size(934, 303);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ServerInformationListBox_ItemSelectionChanged);
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
            this.tabControl1.Controls.Add(this.Logging);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(963, 472);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.EditButton);
            this.tabPage2.Controls.Add(this.groupBox2);
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
            this.tabPage2.Size = new System.Drawing.Size(955, 446);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Servers";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // EditButton
            // 
            this.EditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EditButton.Location = new System.Drawing.Point(59, 399);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(47, 23);
            this.EditButton.TabIndex = 14;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ServerInformationListBox);
            this.groupBox2.Location = new System.Drawing.Point(514, 342);
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
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(694, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Name:";
            // 
            // UserNameInput
            // 
            this.UserNameInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UserNameInput.Location = new System.Drawing.Point(738, 9);
            this.UserNameInput.Name = "UserNameInput";
            this.UserNameInput.Size = new System.Drawing.Size(121, 20);
            this.UserNameInput.TabIndex = 11;
            this.UserNameInput.TextChanged += new System.EventHandler(this.UserNameInput_TextChanged);
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
            this.groupBox1.Location = new System.Drawing.Point(738, 342);
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
            this.AddNewServer.Location = new System.Drawing.Point(112, 399);
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
            this.JoinButton.Location = new System.Drawing.Point(865, 7);
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
            this.textBoxName.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBoxName.Location = new System.Drawing.Point(9, 347);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(150, 20);
            this.textBoxName.TabIndex = 4;
            this.textBoxName.Text = "Name";
            this.textBoxName.Enter += new System.EventHandler(this.textBoxName_Enter);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxAddress.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBoxAddress.Location = new System.Drawing.Point(9, 373);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(150, 20);
            this.textBoxAddress.TabIndex = 2;
            this.textBoxAddress.Text = "Address";
            this.textBoxAddress.Enter += new System.EventHandler(this.textBoxIP_Enter);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.ChangelogGroupBox);
            this.tabPage1.Controls.Add(this.FolderBrowseButton);
            this.tabPage1.Controls.Add(this.directoryPath);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(955, 446);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Updater - Changelog - Resources";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.KMPIssuesLink);
            this.groupBox4.Controls.Add(this.KMPGithubLink);
            this.groupBox4.Controls.Add(this.KMPForumLink);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(230, 38);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(713, 103);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "KMP Resources";
            // 
            // KMPIssuesLink
            // 
            this.KMPIssuesLink.AutoSize = true;
            this.KMPIssuesLink.Location = new System.Drawing.Point(143, 68);
            this.KMPIssuesLink.Name = "KMPIssuesLink";
            this.KMPIssuesLink.Size = new System.Drawing.Size(263, 13);
            this.KMPIssuesLink.TabIndex = 16;
            this.KMPIssuesLink.TabStop = true;
            this.KMPIssuesLink.Text = "https://github.com/TehGimp/KerbalMultiPlayer/issues";
            this.KMPIssuesLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.KMPIssuesLink_LinkClicked);
            // 
            // KMPGithubLink
            // 
            this.KMPGithubLink.AutoSize = true;
            this.KMPGithubLink.Location = new System.Drawing.Point(143, 42);
            this.KMPGithubLink.Name = "KMPGithubLink";
            this.KMPGithubLink.Size = new System.Drawing.Size(229, 13);
            this.KMPGithubLink.TabIndex = 15;
            this.KMPGithubLink.TabStop = true;
            this.KMPGithubLink.Text = "https://github.com/TehGimp/KerbalMultiPlayer";
            this.KMPGithubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.KMPGithubLink_LinkClicked);
            // 
            // KMPForumLink
            // 
            this.KMPForumLink.AutoSize = true;
            this.KMPForumLink.Location = new System.Drawing.Point(143, 16);
            this.KMPForumLink.Name = "KMPForumLink";
            this.KMPForumLink.Size = new System.Drawing.Size(357, 13);
            this.KMPForumLink.TabIndex = 14;
            this.KMPForumLink.TabStop = true;
            this.KMPForumLink.Text = "http://forum.kerbalspaceprogram.com/threads/55835-Kmp-0-22-wip-alpha";
            this.KMPForumLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.KMPForumLink_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "KMP GitHub Issues Page:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "KMP GitHub Page:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Official KMP Forum Thread:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.KSPStatusLabel);
            this.groupBox3.Controls.Add(this.KMPStatusLabel);
            this.groupBox3.Controls.Add(this.UpdateCheckButton);
            this.groupBox3.Controls.Add(this.UpdateButton);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.KMPVersionLabel);
            this.groupBox3.Controls.Add(this.KMPLatestUpdateLabel);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(15, 38);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(209, 103);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Updater";
            // 
            // KSPStatusLabel
            // 
            this.KSPStatusLabel.AutoSize = true;
            this.KSPStatusLabel.Location = new System.Drawing.Point(6, 16);
            this.KSPStatusLabel.Name = "KSPStatusLabel";
            this.KSPStatusLabel.Size = new System.Drawing.Size(161, 13);
            this.KSPStatusLabel.TabIndex = 3;
            this.KSPStatusLabel.Text = "Kerbal Space Program not found";
            // 
            // KMPStatusLabel
            // 
            this.KMPStatusLabel.AutoSize = true;
            this.KMPStatusLabel.Location = new System.Drawing.Point(6, 29);
            this.KMPStatusLabel.Name = "KMPStatusLabel";
            this.KMPStatusLabel.Size = new System.Drawing.Size(138, 13);
            this.KMPStatusLabel.TabIndex = 4;
            this.KMPStatusLabel.Text = "Kerbal Multiplayer not found";
            // 
            // UpdateCheckButton
            // 
            this.UpdateCheckButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateCheckButton.Location = new System.Drawing.Point(6, 74);
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
            this.UpdateButton.Location = new System.Drawing.Point(109, 74);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(94, 23);
            this.UpdateButton.TabIndex = 9;
            this.UpdateButton.Text = "Update KMP";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Current installed KMP version:";
            // 
            // KMPVersionLabel
            // 
            this.KMPVersionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KMPVersionLabel.AutoSize = true;
            this.KMPVersionLabel.Location = new System.Drawing.Point(160, 42);
            this.KMPVersionLabel.Name = "KMPVersionLabel";
            this.KMPVersionLabel.Size = new System.Drawing.Size(40, 13);
            this.KMPVersionLabel.TabIndex = 6;
            this.KMPVersionLabel.Text = "0.0.0.0";
            // 
            // KMPLatestUpdateLabel
            // 
            this.KMPLatestUpdateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KMPLatestUpdateLabel.AutoSize = true;
            this.KMPLatestUpdateLabel.Location = new System.Drawing.Point(160, 55);
            this.KMPLatestUpdateLabel.Name = "KMPLatestUpdateLabel";
            this.KMPLatestUpdateLabel.Size = new System.Drawing.Size(40, 13);
            this.KMPLatestUpdateLabel.TabIndex = 8;
            this.KMPLatestUpdateLabel.Text = "0.0.0.0";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Latest KMP version:";
            // 
            // ChangelogGroupBox
            // 
            this.ChangelogGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangelogGroupBox.Controls.Add(this.ChangelogBox);
            this.ChangelogGroupBox.Location = new System.Drawing.Point(9, 147);
            this.ChangelogGroupBox.Name = "ChangelogGroupBox";
            this.ChangelogGroupBox.Size = new System.Drawing.Size(940, 293);
            this.ChangelogGroupBox.TabIndex = 12;
            this.ChangelogGroupBox.TabStop = false;
            this.ChangelogGroupBox.Text = "Changelog";
            // 
            // ChangelogBox
            // 
            this.ChangelogBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangelogBox.Location = new System.Drawing.Point(6, 19);
            this.ChangelogBox.Name = "ChangelogBox";
            this.ChangelogBox.ReadOnly = true;
            this.ChangelogBox.Size = new System.Drawing.Size(928, 268);
            this.ChangelogBox.TabIndex = 11;
            this.ChangelogBox.Text = "";
            // 
            // FolderBrowseButton
            // 
            this.FolderBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderBrowseButton.Location = new System.Drawing.Point(880, 9);
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
            this.directoryPath.Location = new System.Drawing.Point(91, 12);
            this.directoryPath.Name = "directoryPath";
            this.directoryPath.Size = new System.Drawing.Size(783, 20);
            this.directoryPath.TabIndex = 1;
            this.directoryPath.TextChanged += new System.EventHandler(this.directoryPath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "KSP Directory";
            // 
            // Logging
            // 
            this.Logging.Controls.Add(this.LogGroupBox);
            this.Logging.Location = new System.Drawing.Point(4, 22);
            this.Logging.Name = "Logging";
            this.Logging.Padding = new System.Windows.Forms.Padding(3);
            this.Logging.Size = new System.Drawing.Size(955, 446);
            this.Logging.TabIndex = 2;
            this.Logging.Text = "Logs";
            this.Logging.UseVisualStyleBackColor = true;
            this.Logging.Enter += new System.EventHandler(this.Logging_Enter);
            // 
            // LogGroupBox
            // 
            this.LogGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogGroupBox.Controls.Add(this.KMPLogLink);
            this.LogGroupBox.Controls.Add(this.ReloadLogButton);
            this.LogGroupBox.Controls.Add(this.KSPLogBox);
            this.LogGroupBox.Location = new System.Drawing.Point(6, 6);
            this.LogGroupBox.Name = "LogGroupBox";
            this.LogGroupBox.Size = new System.Drawing.Size(943, 434);
            this.LogGroupBox.TabIndex = 0;
            this.LogGroupBox.TabStop = false;
            this.LogGroupBox.Text = "Kerbal Space Program Log";
            // 
            // KMPLogLink
            // 
            this.KMPLogLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.KMPLogLink.AutoSize = true;
            this.KMPLogLink.Location = new System.Drawing.Point(6, 396);
            this.KMPLogLink.Name = "KMPLogLink";
            this.KMPLogLink.Size = new System.Drawing.Size(49, 13);
            this.KMPLogLink.TabIndex = 14;
            this.KMPLogLink.TabStop = true;
            this.KMPLogLink.Text = "KSP Log";
            this.KMPLogLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.KMPLogLink_LinkClicked);
            // 
            // ReloadLogButton
            // 
            this.ReloadLogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ReloadLogButton.Location = new System.Drawing.Point(862, 391);
            this.ReloadLogButton.Name = "ReloadLogButton";
            this.ReloadLogButton.Size = new System.Drawing.Size(75, 23);
            this.ReloadLogButton.TabIndex = 13;
            this.ReloadLogButton.Text = "Reload Log";
            this.ReloadLogButton.UseVisualStyleBackColor = true;
            this.ReloadLogButton.Click += new System.EventHandler(this.ReloadLogButton_Click);
            // 
            // KSPLogBox
            // 
            this.KSPLogBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KSPLogBox.Location = new System.Drawing.Point(6, 19);
            this.KSPLogBox.Name = "KSPLogBox";
            this.KSPLogBox.ReadOnly = true;
            this.KSPLogBox.Size = new System.Drawing.Size(931, 367);
            this.KSPLogBox.TabIndex = 12;
            this.KSPLogBox.Text = "";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 496);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "LauncherForm";
            this.Text = "Kerbal Multiplayer Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ChangelogGroupBox.ResumeLayout(false);
            this.Logging.ResumeLayout(false);
            this.LogGroupBox.ResumeLayout(false);
            this.LogGroupBox.PerformLayout();
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
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button UpdateCheckButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox ServerInformationListBox;
        private System.Windows.Forms.GroupBox ChangelogGroupBox;
        private System.Windows.Forms.RichTextBox ChangelogBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel KMPIssuesLink;
        private System.Windows.Forms.LinkLabel KMPGithubLink;
        private System.Windows.Forms.LinkLabel KMPForumLink;
        private System.Windows.Forms.TabPage Logging;
        private System.Windows.Forms.GroupBox LogGroupBox;
        private System.Windows.Forms.Button ReloadLogButton;
        private System.Windows.Forms.RichTextBox KSPLogBox;
        private System.Windows.Forms.LinkLabel KMPLogLink;
        private System.Windows.Forms.Button EditButton;
    }
}

