namespace CompactMovieManager
{
    partial class frmCompactMovieManager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompactMovieManager));
            this.lstMovies = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stslblLastPickedCap = new System.Windows.Forms.ToolStripStatusLabel();
            this.stslblLastPicked = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsprgRandomPick = new System.Windows.Forms.ToolStripProgressBar();
            this.stslblError = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConnectTo = new System.Windows.Forms.ToolStripMenuItem();
            this.mniPathMode = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.grpMovieList = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.chkSubtitles = new System.Windows.Forms.CheckBox();
            this.lblTotalMovies = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPick = new System.Windows.Forms.Button();
            this.grpMoviesPath = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.ttpMain = new System.Windows.Forms.ToolTip(this.components);
            this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.bkgPicker = new System.ComponentModel.BackgroundWorker();
            this.fswFileWatcher = new System.IO.FileSystemWatcher();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.txtTitleSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbSearch = new System.Windows.Forms.ComboBox();
            this.cxtSave = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveTotextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.grpMovieList.SuspendLayout();
            this.grpDetails.SuspendLayout();
            this.grpMoviesPath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fswFileWatcher)).BeginInit();
            this.grpSearch.SuspendLayout();
            this.cxtSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstMovies
            // 
            this.lstMovies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMovies.FormattingEnabled = true;
            this.lstMovies.Location = new System.Drawing.Point(48, 19);
            this.lstMovies.Name = "lstMovies";
            this.lstMovies.ScrollAlwaysVisible = true;
            this.lstMovies.Size = new System.Drawing.Size(227, 212);
            this.lstMovies.TabIndex = 0;
            this.lstMovies.SelectedIndexChanged += new System.EventHandler(this.lstMovies_SelectedIndexChanged);
            this.lstMovies.DoubleClick += new System.EventHandler(this.lstMovies_DoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stslblLastPickedCap,
            this.stslblLastPicked,
            this.stsprgRandomPick,
            this.stslblError});
            this.statusStrip1.Location = new System.Drawing.Point(0, 401);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(466, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stslblLastPickedCap
            // 
            this.stslblLastPickedCap.AutoSize = false;
            this.stslblLastPickedCap.Name = "stslblLastPickedCap";
            this.stslblLastPickedCap.Size = new System.Drawing.Size(109, 17);
            this.stslblLastPickedCap.Text = "Last Random Pick: ";
            // 
            // stslblLastPicked
            // 
            this.stslblLastPicked.AutoSize = false;
            this.stslblLastPicked.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stslblLastPicked.Name = "stslblLastPicked";
            this.stslblLastPicked.Size = new System.Drawing.Size(170, 17);
            this.stslblLastPicked.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stsprgRandomPick
            // 
            this.stsprgRandomPick.MarqueeAnimationSpeed = 150;
            this.stsprgRandomPick.Maximum = 20;
            this.stsprgRandomPick.Name = "stsprgRandomPick";
            this.stsprgRandomPick.Size = new System.Drawing.Size(100, 16);
            this.stsprgRandomPick.Step = 1;
            this.stsprgRandomPick.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // stslblError
            // 
            this.stslblError.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stslblError.ForeColor = System.Drawing.Color.Red;
            this.stslblError.IsLink = true;
            this.stslblError.LinkColor = System.Drawing.Color.Red;
            this.stslblError.Name = "stslblError";
            this.stslblError.Size = new System.Drawing.Size(70, 17);
            this.stslblError.Spring = true;
            this.stslblError.Text = "Error";
            this.stslblError.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stslblError.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(466, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConnectTo,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuConnectTo
            // 
            this.mnuConnectTo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniPathMode,
            this.mniDatabase});
            this.mnuConnectTo.Name = "mnuConnectTo";
            this.mnuConnectTo.Size = new System.Drawing.Size(166, 22);
            this.mnuConnectTo.Text = "Connect to ...";
            // 
            // mniPathMode
            // 
            this.mniPathMode.Checked = true;
            this.mniPathMode.CheckOnClick = true;
            this.mniPathMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mniPathMode.Name = "mniPathMode";
            this.mniPathMode.Size = new System.Drawing.Size(142, 22);
            this.mniPathMode.Text = "Path";
            this.mniPathMode.CheckedChanged += new System.EventHandler(this.mniPathMode_CheckedChanged);
            // 
            // mniDatabase
            // 
            this.mniDatabase.CheckOnClick = true;
            this.mniDatabase.Name = "mniDatabase";
            this.mniDatabase.Size = new System.Drawing.Size(142, 22);
            this.mniDatabase.Text = "Database";
            this.mniDatabase.CheckedChanged += new System.EventHandler(this.mniDatabase_CheckedChanged);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(45, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mniAbout
            // 
            this.mniAbout.Name = "mniAbout";
            this.mniAbout.Size = new System.Drawing.Size(122, 22);
            this.mniAbout.Text = "&About";
            this.mniAbout.Click += new System.EventHandler(this.mniAbout_Click);
            // 
            // grpMovieList
            // 
            this.grpMovieList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMovieList.Controls.Add(this.btnSave);
            this.grpMovieList.Controls.Add(this.grpDetails);
            this.grpMovieList.Controls.Add(this.btnRefresh);
            this.grpMovieList.Controls.Add(this.btnPick);
            this.grpMovieList.Controls.Add(this.lstMovies);
            this.grpMovieList.Location = new System.Drawing.Point(8, 149);
            this.grpMovieList.Name = "grpMovieList";
            this.grpMovieList.Size = new System.Drawing.Size(450, 242);
            this.grpMovieList.TabIndex = 5;
            this.grpMovieList.TabStop = false;
            this.grpMovieList.Text = "Movies";
            this.grpMovieList.Enter += new System.EventHandler(this.grpMovieList_Enter);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::CompactMovieManager.Properties.Resources.save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageKey = "(none)";
            this.btnSave.ImageList = this.imageList;
            this.btnSave.Location = new System.Drawing.Point(7, 99);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(39, 40);
            this.btnSave.TabIndex = 9;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttpMain.SetToolTip(this.btnSave, "Save to Text File");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Dice.png");
            this.imageList.Images.SetKeyName(1, "Refresh.png");
            // 
            // grpDetails
            // 
            this.grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetails.Controls.Add(this.chkSubtitles);
            this.grpDetails.Controls.Add(this.lblTotalMovies);
            this.grpDetails.Controls.Add(this.label1);
            this.grpDetails.Location = new System.Drawing.Point(281, 13);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(161, 219);
            this.grpDetails.TabIndex = 8;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Details";
            // 
            // chkSubtitles
            // 
            this.chkSubtitles.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSubtitles.Location = new System.Drawing.Point(4, 20);
            this.chkSubtitles.Name = "chkSubtitles";
            this.chkSubtitles.Size = new System.Drawing.Size(150, 17);
            this.chkSubtitles.TabIndex = 11;
            this.chkSubtitles.Text = "Subtitles";
            this.chkSubtitles.UseVisualStyleBackColor = true;
            // 
            // lblTotalMovies
            // 
            this.lblTotalMovies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalMovies.AutoSize = true;
            this.lblTotalMovies.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMovies.Location = new System.Drawing.Point(130, 200);
            this.lblTotalMovies.Name = "lblTotalMovies";
            this.lblTotalMovies.Size = new System.Drawing.Size(0, 13);
            this.lblTotalMovies.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Total:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::CompactMovieManager.Properties.Resources.Refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ImageKey = "(none)";
            this.btnRefresh.ImageList = this.imageList;
            this.btnRefresh.Location = new System.Drawing.Point(7, 59);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(39, 40);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttpMain.SetToolTip(this.btnRefresh, "Refresh");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPick
            // 
            this.btnPick.BackgroundImage = global::CompactMovieManager.Properties.Resources.Dice;
            this.btnPick.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPick.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPick.ImageKey = "(none)";
            this.btnPick.ImageList = this.imageList;
            this.btnPick.Location = new System.Drawing.Point(7, 19);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(39, 40);
            this.btnPick.TabIndex = 6;
            this.btnPick.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttpMain.SetToolTip(this.btnPick, "Random Pick");
            this.btnPick.UseVisualStyleBackColor = true;
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // grpMoviesPath
            // 
            this.grpMoviesPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMoviesPath.Controls.Add(this.btnBrowse);
            this.grpMoviesPath.Controls.Add(this.txtPath);
            this.grpMoviesPath.Location = new System.Drawing.Point(8, 28);
            this.grpMoviesPath.Name = "grpMoviesPath";
            this.grpMoviesPath.Size = new System.Drawing.Size(450, 43);
            this.grpMoviesPath.TabIndex = 6;
            this.grpMoviesPath.TabStop = false;
            this.grpMoviesPath.Text = "Path";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.BackgroundImage = global::CompactMovieManager.Properties.Resources.Folder;
            this.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBrowse.Location = new System.Drawing.Point(419, 15);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(26, 22);
            this.btnBrowse.TabIndex = 8;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(6, 16);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(410, 20);
            this.txtPath.TabIndex = 7;
            // 
            // ttpMain
            // 
            this.ttpMain.AutoPopDelay = 5000;
            this.ttpMain.InitialDelay = 300;
            this.ttpMain.ReshowDelay = 100;
            // 
            // dlgFolderBrowser
            // 
            this.dlgFolderBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // bkgPicker
            // 
            this.bkgPicker.WorkerSupportsCancellation = true;
            this.bkgPicker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgPicker_DoWork);
            this.bkgPicker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkgPicker_RunWorkerCompleted);
            // 
            // fswFileWatcher
            // 
            this.fswFileWatcher.EnableRaisingEvents = true;
            this.fswFileWatcher.SynchronizingObject = this;
            this.fswFileWatcher.Renamed += new System.IO.RenamedEventHandler(this.fswFileWatcher_Renamed);
            this.fswFileWatcher.Created += new System.IO.FileSystemEventHandler(this.fswFileWatcher_Created);
            this.fswFileWatcher.Changed += new System.IO.FileSystemEventHandler(this.fswFileWatcher_Changed);
            // 
            // grpSearch
            // 
            this.grpSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSearch.Controls.Add(this.txtTitleSearch);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.cmbSearch);
            this.grpSearch.Location = new System.Drawing.Point(8, 87);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(450, 43);
            this.grpSearch.TabIndex = 9;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Search by";
            // 
            // txtTitleSearch
            // 
            this.txtTitleSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitleSearch.Location = new System.Drawing.Point(129, 17);
            this.txtTitleSearch.Name = "txtTitleSearch";
            this.txtTitleSearch.Size = new System.Drawing.Size(287, 20);
            this.txtTitleSearch.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackgroundImage = global::CompactMovieManager.Properties.Resources.Search;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Location = new System.Drawing.Point(419, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(26, 22);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbSearch
            // 
            this.cmbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSearch.FormattingEnabled = true;
            this.cmbSearch.Items.AddRange(new object[] {
            "Title",
            "Duration",
            "Subtitles"});
            this.cmbSearch.Location = new System.Drawing.Point(6, 16);
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.Size = new System.Drawing.Size(119, 21);
            this.cmbSearch.TabIndex = 8;
            // 
            // cxtSave
            // 
            this.cxtSave.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveTotextFileToolStripMenuItem,
            this.saveToDatabaseToolStripMenuItem});
            this.cxtSave.Name = "cxtSave";
            this.cxtSave.Size = new System.Drawing.Size(189, 48);
            // 
            // saveTotextFileToolStripMenuItem
            // 
            this.saveTotextFileToolStripMenuItem.Name = "saveTotextFileToolStripMenuItem";
            this.saveTotextFileToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.saveTotextFileToolStripMenuItem.Text = "Save to &text file";
            this.saveTotextFileToolStripMenuItem.Click += new System.EventHandler(this.saveTotextFileToolStripMenuItem_Click);
            // 
            // saveToDatabaseToolStripMenuItem
            // 
            this.saveToDatabaseToolStripMenuItem.Name = "saveToDatabaseToolStripMenuItem";
            this.saveToDatabaseToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.saveToDatabaseToolStripMenuItem.Text = "Save to database";
            this.saveToDatabaseToolStripMenuItem.Click += new System.EventHandler(this.saveToDatabaseToolStripMenuItem_Click);
            // 
            // frmCompactMovieManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 423);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.grpMoviesPath);
            this.Controls.Add(this.grpMovieList);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(407, 353);
            this.Name = "frmCompactMovieManager";
            this.Text = "Compact Movie Manager";
            this.Load += new System.EventHandler(this.frmCompactMovieManager_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCompactMovieManager_FormClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpMovieList.ResumeLayout(false);
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.grpMoviesPath.ResumeLayout(false);
            this.grpMoviesPath.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fswFileWatcher)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.cxtSave.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstMovies;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpMovieList;
        private System.Windows.Forms.Button btnPick;
        private System.Windows.Forms.ToolStripStatusLabel stslblLastPickedCap;
        private System.Windows.Forms.ToolStripStatusLabel stslblLastPicked;
        private System.Windows.Forms.GroupBox grpMoviesPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ToolTip ttpMain;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderBrowser;
        private System.ComponentModel.BackgroundWorker bkgPicker;
        private System.Windows.Forms.ToolStripStatusLabel stslblError;
        private System.Windows.Forms.ToolStripProgressBar stsprgRandomPick;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.IO.FileSystemWatcher fswFileWatcher;
        private System.Windows.Forms.Label lblTotalMovies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mniAbout;
        private System.Windows.Forms.CheckBox chkSubtitles;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbSearch;
        private System.Windows.Forms.TextBox txtTitleSearch;
        private System.Windows.Forms.ToolStripMenuItem mnuConnectTo;
        private System.Windows.Forms.ToolStripMenuItem mniPathMode;
        private System.Windows.Forms.ToolStripMenuItem mniDatabase;
        private System.Windows.Forms.ContextMenuStrip cxtSave;
        private System.Windows.Forms.ToolStripMenuItem saveTotextFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToDatabaseToolStripMenuItem;
    }
}

