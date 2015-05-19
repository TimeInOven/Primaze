namespace CompactMovieManager
{
    partial class FrmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mniZap = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstMovies = new System.Windows.Forms.ListBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.stsStatus = new System.Windows.Forms.StatusStrip();
            this.stslblTotalCap = new System.Windows.Forms.ToolStripStatusLabel();
            this.stslblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.stslblSep1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsprgRandomPick = new System.Windows.Forms.ToolStripProgressBar();
            this.stslblError = new System.Windows.Forms.ToolStripStatusLabel();
            this.bkgPicker = new System.ComponentModel.BackgroundWorker();
            this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.lblSyncStatus = new System.Windows.Forms.Label();
            this.cxtList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.markAsViewedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.gToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpLineFunctions = new System.Windows.Forms.GroupBox();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnCopyToViewed = new System.Windows.Forms.Button();
            this.btnImdb = new System.Windows.Forms.Button();
            this.lblDurationCap = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblSubtitlesCap = new System.Windows.Forms.Label();
            this.chkSubs = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblResolution = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.MaskedTextBox();
            this.txtTo = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSync = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPick = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkSearchSubs = new System.Windows.Forms.CheckBox();
            this.chkHD = new System.Windows.Forms.CheckBox();
            this.chkViewed = new System.Windows.Forms.CheckBox();
            this.txtCurrentSyncDirs = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.stsStatus.SuspendLayout();
            this.cxtList.SuspendLayout();
            this.grpLineFunctions.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.databaseToolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(828, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // databaseToolStripMenuItem1
            // 
            this.databaseToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniZap});
            this.databaseToolStripMenuItem1.Name = "databaseToolStripMenuItem1";
            this.databaseToolStripMenuItem1.Size = new System.Drawing.Size(84, 24);
            this.databaseToolStripMenuItem1.Text = "&Database";
            // 
            // mniZap
            // 
            this.mniZap.Name = "mniZap";
            this.mniZap.Size = new System.Drawing.Size(152, 24);
            this.mniZap.Text = "&Zap";
            this.mniZap.Click += new System.EventHandler(this.mniZap_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // lstMovies
            // 
            this.lstMovies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMovies.ColumnWidth = 175;
            this.lstMovies.FormattingEnabled = true;
            this.lstMovies.ItemHeight = 16;
            this.lstMovies.Location = new System.Drawing.Point(11, 103);
            this.lstMovies.Margin = new System.Windows.Forms.Padding(4);
            this.lstMovies.Name = "lstMovies";
            this.lstMovies.ScrollAlwaysVisible = true;
            this.lstMovies.Size = new System.Drawing.Size(749, 292);
            this.lstMovies.TabIndex = 4;
            this.lstMovies.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstMovies_DrawItem);
            this.lstMovies.SelectedIndexChanged += new System.EventHandler(this.lstMovies_SelectedIndexChanged);
            this.lstMovies.DoubleClick += new System.EventHandler(this.lstMovies_DoubleClick);
            this.lstMovies.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstMovies_KeyDown);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(10, 73);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(255, 22);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // stsStatus
            // 
            this.stsStatus.AutoSize = false;
            this.stsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stslblTotalCap,
            this.stslblTotal,
            this.stslblSep1,
            this.stsprgRandomPick,
            this.stslblError});
            this.stsStatus.Location = new System.Drawing.Point(0, 433);
            this.stsStatus.Name = "stsStatus";
            this.stsStatus.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.stsStatus.Size = new System.Drawing.Size(828, 31);
            this.stsStatus.TabIndex = 13;
            // 
            // stslblTotalCap
            // 
            this.stslblTotalCap.AutoSize = false;
            this.stslblTotalCap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stslblTotalCap.ForeColor = System.Drawing.Color.Black;
            this.stslblTotalCap.LinkColor = System.Drawing.Color.Black;
            this.stslblTotalCap.Name = "stslblTotalCap";
            this.stslblTotalCap.Size = new System.Drawing.Size(40, 26);
            this.stslblTotalCap.Text = "Total :";
            this.stslblTotalCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stslblTotal
            // 
            this.stslblTotal.AutoSize = false;
            this.stslblTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.stslblTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stslblTotal.Name = "stslblTotal";
            this.stslblTotal.Size = new System.Drawing.Size(45, 26);
            this.stslblTotal.Text = "0";
            this.stslblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stslblSep1
            // 
            this.stslblSep1.AutoSize = false;
            this.stslblSep1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stslblSep1.Name = "stslblSep1";
            this.stslblSep1.Size = new System.Drawing.Size(10, 26);
            this.stslblSep1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stsprgRandomPick
            // 
            this.stsprgRandomPick.CausesValidation = false;
            this.stsprgRandomPick.MarqueeAnimationSpeed = 150;
            this.stsprgRandomPick.Maximum = 20;
            this.stsprgRandomPick.Name = "stsprgRandomPick";
            this.stsprgRandomPick.Size = new System.Drawing.Size(433, 25);
            this.stsprgRandomPick.Step = 1;
            this.stsprgRandomPick.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // stslblError
            // 
            this.stslblError.AutoSize = false;
            this.stslblError.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stslblError.ForeColor = System.Drawing.Color.Red;
            this.stslblError.IsLink = true;
            this.stslblError.LinkColor = System.Drawing.Color.Red;
            this.stslblError.Name = "stslblError";
            this.stslblError.Size = new System.Drawing.Size(52, 26);
            this.stslblError.Text = "Error";
            this.stslblError.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stslblError.Visible = false;
            this.stslblError.Click += new System.EventHandler(this.stslblError_Click);
            // 
            // bkgPicker
            // 
            this.bkgPicker.WorkerSupportsCancellation = true;
            this.bkgPicker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgPicker_DoWork);
            this.bkgPicker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkgPicker_RunWorkerCompleted);
            // 
            // dlgFolderBrowser
            // 
            this.dlgFolderBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // lblSyncStatus
            // 
            this.lblSyncStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSyncStatus.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblSyncStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSyncStatus.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblSyncStatus.Location = new System.Drawing.Point(557, 2);
            this.lblSyncStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSyncStatus.Name = "lblSyncStatus";
            this.lblSyncStatus.Size = new System.Drawing.Size(268, 23);
            this.lblSyncStatus.TabIndex = 17;
            this.lblSyncStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cxtList
            // 
            this.cxtList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.markAsViewedToolStripMenuItem,
            this.toolStripSeparator2,
            this.gToolStripMenuItem});
            this.cxtList.Name = "cxtList";
            this.cxtList.Size = new System.Drawing.Size(213, 114);
            // 
            // markAsViewedToolStripMenuItem
            // 
            this.markAsViewedToolStripMenuItem.Name = "markAsViewedToolStripMenuItem";
            this.markAsViewedToolStripMenuItem.Size = new System.Drawing.Size(212, 52);
            this.markAsViewedToolStripMenuItem.Text = "Mark as &Viewed";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(209, 6);
            // 
            // gToolStripMenuItem
            // 
            this.gToolStripMenuItem.Image = global::CompactMovieManager.Properties.Resources.icon_imdb;
            this.gToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.gToolStripMenuItem.Name = "gToolStripMenuItem";
            this.gToolStripMenuItem.Size = new System.Drawing.Size(212, 52);
            this.gToolStripMenuItem.Text = "Search in IMDB";
            // 
            // grpLineFunctions
            // 
            this.grpLineFunctions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLineFunctions.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpLineFunctions.Controls.Add(this.btnOpenFolder);
            this.grpLineFunctions.Controls.Add(this.btnCopyToViewed);
            this.grpLineFunctions.Controls.Add(this.btnImdb);
            this.grpLineFunctions.Location = new System.Drawing.Point(667, 104);
            this.grpLineFunctions.Margin = new System.Windows.Forms.Padding(4);
            this.grpLineFunctions.Name = "grpLineFunctions";
            this.grpLineFunctions.Padding = new System.Windows.Forms.Padding(4);
            this.grpLineFunctions.Size = new System.Drawing.Size(71, 289);
            this.grpLineFunctions.TabIndex = 5;
            this.grpLineFunctions.TabStop = false;
            this.grpLineFunctions.Visible = false;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFolder.BackColor = System.Drawing.Color.White;
            this.btnOpenFolder.BackgroundImage = global::CompactMovieManager.Properties.Resources.Folder1;
            this.btnOpenFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFolder.ImageKey = "(none)";
            this.btnOpenFolder.Location = new System.Drawing.Point(5, 130);
            this.btnOpenFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(60, 55);
            this.btnOpenFolder.TabIndex = 2;
            this.btnOpenFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpenFolder.UseVisualStyleBackColor = false;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnCopyToViewed
            // 
            this.btnCopyToViewed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyToViewed.BackgroundImage = global::CompactMovieManager.Properties.Resources.CheckBox_Icon_Large;
            this.btnCopyToViewed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCopyToViewed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyToViewed.ImageKey = "(none)";
            this.btnCopyToViewed.Location = new System.Drawing.Point(5, 71);
            this.btnCopyToViewed.Margin = new System.Windows.Forms.Padding(4);
            this.btnCopyToViewed.Name = "btnCopyToViewed";
            this.btnCopyToViewed.Size = new System.Drawing.Size(60, 55);
            this.btnCopyToViewed.TabIndex = 1;
            this.btnCopyToViewed.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopyToViewed.UseVisualStyleBackColor = true;
            this.btnCopyToViewed.Click += new System.EventHandler(this.btnCopyToViewed_Click);
            // 
            // btnImdb
            // 
            this.btnImdb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImdb.BackgroundImage = global::CompactMovieManager.Properties.Resources.icon_imdb;
            this.btnImdb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImdb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImdb.ImageKey = "(none)";
            this.btnImdb.Location = new System.Drawing.Point(5, 12);
            this.btnImdb.Margin = new System.Windows.Forms.Padding(4);
            this.btnImdb.Name = "btnImdb";
            this.btnImdb.Size = new System.Drawing.Size(60, 55);
            this.btnImdb.TabIndex = 0;
            this.btnImdb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImdb.UseVisualStyleBackColor = true;
            this.btnImdb.Click += new System.EventHandler(this.btnImdb_Click);
            // 
            // lblDurationCap
            // 
            this.lblDurationCap.Location = new System.Drawing.Point(4, 4);
            this.lblDurationCap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDurationCap.Name = "lblDurationCap";
            this.lblDurationCap.Size = new System.Drawing.Size(71, 18);
            this.lblDurationCap.TabIndex = 27;
            this.lblDurationCap.Text = "Duration :";
            // 
            // lblDuration
            // 
            this.lblDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.Location = new System.Drawing.Point(79, 4);
            this.lblDuration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(116, 18);
            this.lblDuration.TabIndex = 28;
            // 
            // lblSubtitlesCap
            // 
            this.lblSubtitlesCap.Location = new System.Drawing.Point(204, 4);
            this.lblSubtitlesCap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtitlesCap.Name = "lblSubtitlesCap";
            this.lblSubtitlesCap.Size = new System.Drawing.Size(71, 16);
            this.lblSubtitlesCap.TabIndex = 29;
            this.lblSubtitlesCap.Text = "Subtitles :";
            // 
            // chkSubs
            // 
            this.chkSubs.Enabled = false;
            this.chkSubs.Location = new System.Drawing.Point(281, 4);
            this.chkSubs.Margin = new System.Windows.Forms.Padding(4);
            this.chkSubs.Name = "chkSubs";
            this.chkSubs.Size = new System.Drawing.Size(27, 17);
            this.chkSubs.TabIndex = 30;
            this.chkSubs.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkSubs.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblResolution);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.chkSubs);
            this.panel1.Controls.Add(this.lblSubtitlesCap);
            this.panel1.Controls.Add(this.lblDuration);
            this.panel1.Controls.Add(this.lblDurationCap);
            this.panel1.Location = new System.Drawing.Point(3, 403);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(757, 26);
            this.panel1.TabIndex = 27;
            // 
            // lblResolution
            // 
            this.lblResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResolution.Location = new System.Drawing.Point(441, 5);
            this.lblResolution.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(137, 16);
            this.lblResolution.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(348, 4);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 16);
            this.label4.TabIndex = 31;
            this.label4.Text = "Resolution :";
            // 
            // txtFrom
            // 
            this.txtFrom.AsciiOnly = true;
            this.txtFrom.BeepOnError = true;
            this.txtFrom.HideSelection = false;
            this.txtFrom.Location = new System.Drawing.Point(322, 73);
            this.txtFrom.Margin = new System.Windows.Forms.Padding(4);
            this.txtFrom.Mask = "000";
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(32, 22);
            this.txtFrom.TabIndex = 1;
            this.txtFrom.Click += new System.EventHandler(this.txtFrom_Click);
            this.txtFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFrom_KeyDown);
            // 
            // txtTo
            // 
            this.txtTo.AsciiOnly = true;
            this.txtTo.Location = new System.Drawing.Point(388, 73);
            this.txtTo.Margin = new System.Windows.Forms.Padding(4);
            this.txtTo.Mask = "000";
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(31, 22);
            this.txtTo.TabIndex = 2;
            this.txtTo.Click += new System.EventHandler(this.txtTo_Click);
            this.txtTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTo_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(280, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 18);
            this.label1.TabIndex = 31;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(362, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 18);
            this.label2.TabIndex = 32;
            this.label2.Text = "to";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(423, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 18);
            this.label3.TabIndex = 33;
            this.label3.Text = "mins";
            // 
            // btnSync
            // 
            this.btnSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSync.BackgroundImage = global::CompactMovieManager.Properties.Resources.sync;
            this.btnSync.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSync.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSync.ImageKey = "(none)";
            this.btnSync.Location = new System.Drawing.Point(767, 101);
            this.btnSync.Margin = new System.Windows.Forms.Padding(4);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(56, 52);
            this.btnSync.TabIndex = 6;
            this.btnSync.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackgroundImage = global::CompactMovieManager.Properties.Resources.save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageKey = "(none)";
            this.btnSave.Location = new System.Drawing.Point(767, 264);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 52);
            this.btnSave.TabIndex = 9;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackgroundImage = global::CompactMovieManager.Properties.Resources.Refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ImageKey = "(none)";
            this.btnRefresh.Location = new System.Drawing.Point(767, 156);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(56, 52);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPick
            // 
            this.btnPick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPick.BackgroundImage = global::CompactMovieManager.Properties.Resources.Dice;
            this.btnPick.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPick.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPick.ImageKey = "(none)";
            this.btnPick.Location = new System.Drawing.Point(767, 210);
            this.btnPick.Margin = new System.Windows.Forms.Padding(4);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(56, 52);
            this.btnPick.TabIndex = 8;
            this.btnPick.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPick.UseVisualStyleBackColor = true;
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = global::CompactMovieManager.Properties.Resources.Search;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Location = new System.Drawing.Point(726, 70);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(33, 28);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkSearchSubs
            // 
            this.chkSearchSubs.Checked = true;
            this.chkSearchSubs.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkSearchSubs.Location = new System.Drawing.Point(574, 76);
            this.chkSearchSubs.Margin = new System.Windows.Forms.Padding(4);
            this.chkSearchSubs.Name = "chkSearchSubs";
            this.chkSearchSubs.Size = new System.Drawing.Size(73, 18);
            this.chkSearchSubs.TabIndex = 31;
            this.chkSearchSubs.Text = "Subs";
            this.chkSearchSubs.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkSearchSubs.ThreeState = true;
            this.chkSearchSubs.UseVisualStyleBackColor = true;
            // 
            // chkHD
            // 
            this.chkHD.Checked = true;
            this.chkHD.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkHD.Location = new System.Drawing.Point(652, 76);
            this.chkHD.Margin = new System.Windows.Forms.Padding(4);
            this.chkHD.Name = "chkHD";
            this.chkHD.Size = new System.Drawing.Size(60, 18);
            this.chkHD.TabIndex = 34;
            this.chkHD.Text = "HD";
            this.chkHD.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkHD.ThreeState = true;
            this.chkHD.UseVisualStyleBackColor = true;
            // 
            // chkViewed
            // 
            this.chkViewed.Location = new System.Drawing.Point(482, 76);
            this.chkViewed.Margin = new System.Windows.Forms.Padding(4);
            this.chkViewed.Name = "chkViewed";
            this.chkViewed.Size = new System.Drawing.Size(84, 18);
            this.chkViewed.TabIndex = 35;
            this.chkViewed.Text = "Viewed";
            this.chkViewed.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkViewed.ThreeState = true;
            this.chkViewed.UseVisualStyleBackColor = true;
            // 
            // txtCurrentSyncDirs
            // 
            this.txtCurrentSyncDirs.AcceptsReturn = true;
            this.txtCurrentSyncDirs.AcceptsTab = true;
            this.txtCurrentSyncDirs.CausesValidation = false;
            this.txtCurrentSyncDirs.Location = new System.Drawing.Point(11, 41);
            this.txtCurrentSyncDirs.Margin = new System.Windows.Forms.Padding(4);
            this.txtCurrentSyncDirs.Name = "txtCurrentSyncDirs";
            this.txtCurrentSyncDirs.ReadOnly = true;
            this.txtCurrentSyncDirs.Size = new System.Drawing.Size(804, 22);
            this.txtCurrentSyncDirs.TabIndex = 36;
            this.txtCurrentSyncDirs.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCurrentSyncDirs_KeyUp);
            this.txtCurrentSyncDirs.Leave += new System.EventHandler(this.txtCurrentSyncDirs_Leave);
            this.txtCurrentSyncDirs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCurrentSyncDirs_MouseDoubleClick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 464);
            this.Controls.Add(this.txtCurrentSyncDirs);
            this.Controls.Add(this.grpLineFunctions);
            this.Controls.Add(this.chkViewed);
            this.Controls.Add(this.chkHD);
            this.Controls.Add(this.chkSearchSubs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.lblSyncStatus);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.stsStatus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnPick);
            this.Controls.Add(this.lstMovies);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnSearch);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(804, 509);
            this.Name = "FrmMain";
            this.Text = "Compact Movie Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.stsStatus.ResumeLayout(false);
            this.stsStatus.PerformLayout();
            this.cxtList.ResumeLayout(false);
            this.grpLineFunctions.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ListBox lstMovies;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPick;
        private System.Windows.Forms.StatusStrip stsStatus;
        private System.Windows.Forms.ToolStripProgressBar stsprgRandomPick;
        private System.Windows.Forms.ToolStripStatusLabel stslblError;
        private System.ComponentModel.BackgroundWorker bkgPicker;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderBrowser;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStripStatusLabel stslblTotalCap;
        private System.Windows.Forms.ToolStripStatusLabel stslblSep1;
        private System.Windows.Forms.ToolStripStatusLabel stslblTotal;
        private System.Windows.Forms.Label lblSyncStatus;
        private System.Windows.Forms.ContextMenuStrip cxtList;
        private System.Windows.Forms.ToolStripMenuItem markAsViewedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Button btnImdb;
        private System.Windows.Forms.GroupBox grpLineFunctions;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mniZap;
        private System.Windows.Forms.Button btnCopyToViewed;
        private System.Windows.Forms.Label lblDurationCap;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblSubtitlesCap;
        private System.Windows.Forms.CheckBox chkSubs;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MaskedTextBox txtFrom;
        private System.Windows.Forms.MaskedTextBox txtTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.CheckBox chkSearchSubs;
        private System.Windows.Forms.CheckBox chkHD;
        private System.Windows.Forms.CheckBox chkViewed;
        private System.Windows.Forms.Label lblResolution;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCurrentSyncDirs;
    }
}