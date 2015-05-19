using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using WMPLib;
using MediaInfoLib;
using System.Diagnostics;
using System.Collections;
using System.Linq;

namespace CompactMovieManager
{
    public partial class FrmMain : Form
    {
        private Movie SelectedMovie
        {
            get
            {
                if (this.lstMovies.SelectedItem != null)
                {
                    return ((Movie)this.lstMovies.SelectedItem);
                }
                else
                {
                    return null;
                }
            }
        }

        public delegate bool SelectRandomMovie(int p_nPick);
        public delegate void FinalMovieSelected(int p_nPick);
        public delegate void DisplayError(bool p_bShow);
        public delegate void UpdateProgress(int p_nIncrement);

        private bool _bAllowSearchTextChange = true;
        private bool _bPicking = false;
        private string _strErrorMessage = "";
        private SqlCeConnection _sqlConn = null;

        public FrmMain()
        {
            InitializeComponent();
            this.Text = "Compact Movie Manager (v" + Program.AppVersion.ToString() + ")";

            this.txtCurrentSyncDirs.Text = this.GetSyncDirs();

            this.MouseWheel += FrmMain_MouseWheel;
        }

        void FrmMain_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!this.lstMovies.Focused)
            {
                this.lstMovies.Focus();
            }
        }

        private void ShowError(bool p_bShow)
        {
            this.stslblError.Visible = p_bShow;
        }
        private void SetLastPicked(int p_nPick)
        {
            try
            {
                this.btnPick.Enabled = true;
                this.btnRefresh.Enabled = true;
                this.stsprgRandomPick.Value = 0;
                this.ChangeStatus("");
                this.ShowError(false);
            }
            catch (Exception ex)
            {
                this._strErrorMessage = ex.Message;
                this.ShowError(true);
            }
        }
        private bool GoToMovie(int p_nPick)
        {
            try
            {
                if (this.lstMovies.Items.Count > 0)
                {
                    this.lstMovies.SelectedIndex = p_nPick;
                    this.stsprgRandomPick.Increment(1);                                        
                    return true;
                }
                else
                {
                    throw new Exception("Movie list is empty");
                }
            }
            catch (Exception ex)
            {
                this._strErrorMessage = ex.Message;
                this.ShowError(true);
                return false;
            }
        }
        private bool GetMovieList_Database()
        {
            SqlCeCommand sqlCmd = null;
            SqlCeDataReader sqlDr = null;

            try
            {
                string strSubsFilter = "1=1";
                #region set subtitles filter
                if (chkSearchSubs.CheckState != CheckState.Indeterminate)
                {
                    if (chkSearchSubs.Checked)
                    {
                        strSubsFilter = "subs=1";
                    }
                    else
                    {
                        strSubsFilter = "subs=0";
                    }
                }
                #endregion

                string strHDFilter = "1=1";
                #region set HD filter
                if (chkHD.CheckState != CheckState.Indeterminate)
                {
                    if (chkHD.Checked)
                    {
                        strHDFilter = "resheight >= 500";
                    }
                    else
                    {
                        strHDFilter = "resheight < 500";
                    }
                }
                #endregion

                string strViewedFilter = "1=1";
                #region set viewed filter
                if (chkViewed.CheckState != CheckState.Indeterminate)
                {
                    if (chkViewed.Checked)
                    {
                        strViewedFilter = "viewed=1";
                    }
                    else
                    {
                        strViewedFilter = "viewed=0";
                    }
                }
                #endregion

                string strDurationFilter = "1=1";
                #region set duration filter
                int nFrom = (txtFrom.Text != "") ? (Convert.ToInt32(txtFrom.Text)) : 0;
                int nTo = (txtTo.Text != "") ? (Convert.ToInt32(txtTo.Text)) : 0;

                if ((nFrom > 0) && (nTo == 0))
                {
                    nTo = Int32.MaxValue;
                }

                if ((nFrom <= nTo))
                {
                    //_bAllowSearchTextChange = false;
                    //this.txtSearch.Text = "";

                    if (nTo > 0)
                    {
                        strDurationFilter = " (duration >= " + nFrom.ToString() +
                                        "AND duration <= " + nTo.ToString() + ")";
                    }
                }
                else
                {
                    throw new Exception("Duration range specified is invalid");
                }
                #endregion

                string strTitleFilter = "1=1";
                #region set title filter
                if (!String.IsNullOrEmpty(this.txtSearch.Text))
                {
                    strTitleFilter = "title LIKE '%" + this.txtSearch.Text + "%'";
                } 
                #endregion

                //this.GetMovieList_Database("title LIKE '%" + strTitle + "%'");

                #region set filter
                 string strFilter = strSubsFilter + " AND " + strHDFilter 
                                + " AND " + strViewedFilter + " AND " + strDurationFilter + " AND " + strTitleFilter;
                #endregion

                string strSelect = "SELECT iid, title, duration, path, viewed, subs, reswidth, resheight " +
                                    "FROM Movies " +
                                    "WHERE " + strFilter + " ORDER BY title";



                try
                {
                    this.lstMovies.Items.Clear();

                    sqlCmd = new SqlCeCommand(strSelect, _sqlConn);
                    sqlDr = sqlCmd.ExecuteReader(CommandBehavior.SingleResult);

                    if (sqlDr != null)
                    {
                        while (sqlDr.Read())
                        {
                            int iid = Convert.ToInt32(sqlDr["iid"]);
                            string strTitle = sqlDr["title"].ToString();
                            int nDuration = Convert.ToInt32(sqlDr["duration"]);
                            string strPath = sqlDr["path"].ToString();
                            bool bViewed = Convert.ToBoolean(sqlDr["viewed"]);
                            bool bSubs = Convert.ToBoolean(sqlDr["subs"]);
                            int nResWidth = Convert.ToInt32(sqlDr["reswidth"]);
                            int nResHeight = Convert.ToInt32(sqlDr["resheight"]);

                            this.lstMovies.Items.Add(new Movie(iid, strTitle, nDuration,
                                                                strPath, bViewed, bSubs, nResWidth, nResHeight));

                        }

                        this.grpLineFunctions.Visible = false;
                        this.stslblTotal.Text = this.lstMovies.Items.Count.ToString();
                        if (lstMovies.Items.Count > 0)
                        {
                            lstMovies.SelectedIndex = 0;
                        }

                        return true;
                    }
                    else
                    {
                        throw new Exception("Data reader could not be initialized");
                    }
                }
              
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (SqlCeException sqlEx)
            {
                this._strErrorMessage = sqlEx.Message;
                this.ShowError(true);
                return false;
            }
            catch (Exception ex)
            {
                this._strErrorMessage = ex.Message;
                this.ShowError(true);
                return false;
            }
            finally
            {
                if (sqlDr != null)
                {
                    sqlDr.Close();
                }
                if (sqlCmd != null)
                {
                    sqlCmd.Dispose();
                }
            }
        }
        private List<Movie> GetMovieList_Path(List<string> pMovieDirPaths)
        {            
            #region Get movie list from path
            if ((pMovieDirPaths != null) && (pMovieDirPaths.Count > 0))
            {        
                try
                {             
                    List<Movie> movies = new List<Movie>();

                    foreach (string path in pMovieDirPaths)
                    {
                        string[] strMovies = Directory.GetFiles(path);
                        string[] strMovieFolders = Directory.GetDirectories(path);

                        if (strMovies != null)
                        {
                            this.stsprgRandomPick.Maximum = (strMovies.Length + strMovieFolders.Length) * 2;                            

                            this.lstMovies.Sorted = true;

                            foreach (string strMovie in strMovies)
                            {
                                movies.Add(new Movie(0, Path.GetFileNameWithoutExtension(strMovie), 0, strMovie, false, false, 0, 0));
                                this.stsprgRandomPick.Increment(1);
                            }

                            foreach (string strMovieFolder in strMovieFolders)
                            {
                                movies.Add(new Movie(0, Path.GetFileNameWithoutExtension(strMovieFolder), 0, strMovieFolder, false, false, 0, 0));
                                this.stsprgRandomPick.Increment(1);
                            }
                            this._strErrorMessage = "";
                            this.ShowError(false);                            
                        }
                        else
                        {
                            throw new Exception("No movies found in directory:\n" + path);
                        }
                    }

                    return movies;
                }
                catch (Exception ex)
                {
                    this._strErrorMessage = ex.Message;
                    this.ShowError(true);
                    return null;
                }
                finally
                {

                }
            }
            else
            {
                this._strErrorMessage = "Movie path not specified";
                this.ShowError(true);
                return null;
            }
            #endregion
        }
        private bool SyncPathWithDatabase(List<string> pSyncDirs)
        {      
            try
            {
                #region Path -> Database synch
                List<Movie> _lstMovie = this.GetMovieList_Path(pSyncDirs);

                if (_lstMovie != null)
                {
                    SqlCeDataReader sqlDr = null; 

                    string strSelect = "SELECT title,duration,path FROM Movies " +
                                   "WHERE title=@title";
                    string strUpdate = "UPDATE Movies SET path=@path " +                                        
                                        "WHERE title=@title";
                    string strInsert = "INSERT INTO Movies (title,duration,path,subs,reswidth,resheight,viewed) " +
                                        "VALUES (@title, @duration, @path, @subs, @reswidth, @resheight,@viewed)";

                    SqlCeCommand sqlSelectCmd = new SqlCeCommand(strSelect, _sqlConn);
                    sqlSelectCmd.Parameters.AddWithValue("@title", "");
                    SqlCeCommand sqlUpdateCmd = new SqlCeCommand(strUpdate, _sqlConn);
                    sqlUpdateCmd.Parameters.AddWithValue("@duration", 0);
                    sqlUpdateCmd.Parameters.AddWithValue("@path", "");
                    sqlUpdateCmd.Parameters.AddWithValue("@title", "");
                    //sqlUpdateCmd.Parameters.AddWithValue("@viewed", false);

                    //comment to disable updating of duration, resolution, etc
                    sqlUpdateCmd.Parameters.AddWithValue("@reswidth", 0);
                    sqlUpdateCmd.Parameters.AddWithValue("@resheight", 0);
                    SqlCeCommand sqlInsertCmd = new SqlCeCommand(strInsert, _sqlConn);
                    sqlInsertCmd.Parameters.AddWithValue("@title", "");
                    sqlInsertCmd.Parameters.AddWithValue("@duration", 0);
                    sqlInsertCmd.Parameters.AddWithValue("@path", "");
                    sqlInsertCmd.Parameters.AddWithValue("@subs", false);
                    sqlInsertCmd.Parameters.AddWithValue("@reswidth", 0);
                    sqlInsertCmd.Parameters.AddWithValue("@resheight", 0);
                    sqlInsertCmd.Parameters.AddWithValue("@viewed", false);

                    MediaInfo mi = new MediaInfo();

                    foreach (Movie movie in _lstMovie)
                    {
                        try
                        {

                            if ((File.Exists(movie.Path)) && (this.IsMovieFile(movie.Path)) || (Directory.Exists(movie.Path)))
                            {
                                int nDuration = 0;
                                bool bSubs = false;
                                int nWidth = 0;
                                int nHeight = 0;
                                string moviePath = "";

                                sqlSelectCmd.Parameters["title"].Value = movie.Title;
                                sqlUpdateCmd.Parameters["@path"].Value = movie.Path;
                                sqlUpdateCmd.Parameters["@title"].Value = movie.Title;
                                //sqlUpdateCmd.Parameters["@viewed"].Value = false;

                                if (sqlUpdateCmd.ExecuteNonQuery() < 1)
                                {
                                    bool bInsert = true;

                                    #region get mediainfo info
                                    if (File.Exists(movie.Path))
                                    {
                                        try
                                        {
                                            if ((File.GetAttributes(movie.Path) & FileAttributes.Hidden) != FileAttributes.Hidden)
                                            {
                                                moviePath = movie.Path;

                                                mi.Open(Path.GetFullPath(movie.Path));

                                                ////CODE TO DISPLAY ALL MEDIAINFO.DLL GET OPTIONS
                                                //string test = "";
                                                //try
                                                //{
                                                //    for (int i = 0; i < 150; i++)
                                                //    {
                                                //        string option = mi.Get(StreamKind.Text, 0, i);
                                                //        if (option.Trim() != "")
                                                //        {
                                                //            test += i.ToString() + ": " + option + "\n";
                                                //        }
                                                //    }
                                                //}
                                                //catch
                                                //{
                                                //}
                                                //finally
                                                //{
                                                //    //MessageBox.Show(test);
                                                //}


                                                string durationString = mi.Get(StreamKind.General, 0, 85);
                                                if (durationString != "")
                                                {
                                                    nDuration = Convert.ToInt32(Convert.ToDateTime(durationString).TimeOfDay.TotalMinutes);
                                                }
                                                string reswidthString = mi.Get(StreamKind.Video, 0, 96);
                                                if (!string.IsNullOrEmpty(reswidthString))
                                                {
                                                    nWidth = Convert.ToInt32(reswidthString);
                                                }
                                                string resHeightString = mi.Get(StreamKind.Video, 0, 102);
                                                if (!string.IsNullOrEmpty(resHeightString))
                                                {
                                                    nHeight = Convert.ToInt32(resHeightString);
                                                }
                                                string subtitlesString = mi.Get(StreamKind.Text, 0, 0);
                                                if (!String.IsNullOrEmpty(subtitlesString))
                                                {
                                                    bSubs = true;
                                                }
                                            }
                                            else
                                            {
                                                bInsert = false;
                                            }
                                        }
                                        catch (AccessViolationException avEx)
                                        {
                                            //ignore error (seems to be a bug with MediaInfo.dll with certain files)
                                        }
                                        catch (Exception ex)
                                        {
                                            throw new Exception("Error getting duration:\n\n" + ex.Message);
                                        }
                                        finally
                                        {
                                            mi.Close();
                                        }
                                    }
                                    else if (Directory.Exists(movie.Path))
                                    {
                                        bInsert = false;

                                        string[] strSubFiles = Directory.GetFiles(movie.Path);
                                        foreach (string strSubFile in strSubFiles)
                                        {
                                            if (this.IsMovieFile(strSubFile))
                                            {
                                                bInsert = true;

                                                moviePath = strSubFile;

                                                try
                                                {
                                                    mi.Open(Path.GetFullPath(strSubFile));

                                                    string durationString = mi.Get(StreamKind.General, 0, 85);
                                                    if (durationString != "")
                                                    {
                                                        nDuration += Convert.ToInt32(Convert.ToDateTime(durationString).TimeOfDay.TotalMinutes);
                                                    }
                                                    string subtitlesString = mi.Get(StreamKind.Text, 0, 0);
                                                    if (!String.IsNullOrEmpty(subtitlesString))
                                                    {
                                                        bSubs = true;
                                                    }
                                                    string reswidthString = mi.Get(StreamKind.Video, 0, 96);
                                                    if (!string.IsNullOrEmpty(reswidthString))
                                                    {
                                                        nWidth = Convert.ToInt32(reswidthString);
                                                    }
                                                    string resHeightString = mi.Get(StreamKind.Video, 0, 102);
                                                    if (!string.IsNullOrEmpty(resHeightString))
                                                    {
                                                        nHeight = Convert.ToInt32(resHeightString);
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    throw new Exception("Error getting movie attributes:\n\n" + ex.Message);
                                                }
                                                finally
                                                {
                                                    mi.Close();
                                                }
                                            }
                                            else
                                            {
                                                if ((Path.GetExtension(strSubFile).ToUpper() == ".SRT") ||
                                                   (Path.GetExtension(strSubFile).ToUpper() == ".SUB"))
                                                {
                                                    bSubs = true;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        nDuration = 0;
                                    }
                                    #endregion

                                    if (bInsert)
                                    {
                                        sqlInsertCmd.Parameters["@title"].Value = movie.Title;
                                        sqlInsertCmd.Parameters["@duration"].Value = nDuration;
                                        sqlInsertCmd.Parameters["@path"].Value = moviePath;
                                        sqlInsertCmd.Parameters["@subs"].Value = bSubs;
                                        sqlInsertCmd.Parameters["@reswidth"].Value = nWidth;
                                        sqlInsertCmd.Parameters["@resheight"].Value = nHeight;
                                        sqlInsertCmd.Parameters["@viewed"].Value = false;

                                        sqlInsertCmd.ExecuteNonQuery();
                                    }
                                }
                                stsprgRandomPick.Increment(1);
                            }                            
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            if (sqlDr != null)
                            {
                                sqlDr.Close();
                            }
                        }
                    }                
                }
                else
                {
                    throw new Exception(this._strErrorMessage);
                }
                #endregion

                #region Datbase -> Path synch
                string strSelectAll = "SELECT title, path FROM Movies";
                string strDeleteMissing = "DELETE FROM Movies WHERE title=@title";

                SqlCeCommand sqlSelectCmdAll = new SqlCeCommand(strSelectAll, _sqlConn);
                SqlCeCommand sqlDeleteMissing= new SqlCeCommand(strDeleteMissing, _sqlConn);
                sqlDeleteMissing.Parameters.AddWithValue("@title", "");                

                SqlCeDataReader sqlDrAll = null;
                try
                {
                    sqlDrAll = sqlSelectCmdAll.ExecuteReader(CommandBehavior.SingleResult);
                    if (sqlDrAll != null)
                    {
                        while (sqlDrAll.Read())
                        {
                            string strPath = sqlDrAll["path"].ToString();
                            if (!File.Exists(strPath) && (!Directory.Exists(strPath)))
                            {
                                sqlDeleteMissing.Parameters["@title"].Value = sqlDrAll["title"].ToString();
                                sqlDeleteMissing.ExecuteNonQuery();
                            }                                                     
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (sqlDrAll != null)
                    {
                        sqlDrAll.Close();
                    }
                }
                #endregion

                this.GetMovieList_Database();
                return true;
            }
            catch (Exception ex)
            {
                this._strErrorMessage = ex.Message;
                this.ShowError(true);
                return false;
            }
            finally
            {
                this.stsprgRandomPick.Value = 0;
            }
        }
        private bool Zap()
        {
            string strDelete = "DELETE FROM Movies";
            string strReseed = "ALTER TABLE Movies ALTER COLUMN iid IDENTITY (1,1)";

            SqlCeCommand cmdDelete = null;
            SqlCeCommand cmdReseed = null;

            try
            {
                cmdDelete = new SqlCeCommand(strDelete, _sqlConn);
                cmdDelete.ExecuteNonQuery();

                cmdReseed = new SqlCeCommand(strReseed, _sqlConn);
                cmdReseed.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                this._strErrorMessage = ex.Message;
                this.ShowError(true);
                return false;
            }
            finally
            {
                if (cmdDelete != null)
                {
                    cmdDelete.Dispose();
                }
            }
        }
        private void SaveToTextFile()
        {
            try
            {
                this.stsprgRandomPick.Maximum = lstMovies.Items.Count;
                string[] aMovies = new string[lstMovies.Items.Count];
                for (int i = 0; i < lstMovies.Items.Count; i++)
                {
                    aMovies.SetValue(lstMovies.Items[i].ToString(), i);
                    this.stsprgRandomPick.Increment(1);
                }
                this.stsprgRandomPick.Maximum = 20;
                this.stsprgRandomPick.Value = 0;
                File.WriteAllLines("Movies.txt", aMovies);
                this.ShowError(false);
                this.stsprgRandomPick.Style = ProgressBarStyle.Continuous;

                if (MessageBox.Show(this, "Movies.txt saved to:\n" + Environment.CurrentDirectory + "\n\nDo you want to view this file?", "Save Successful", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("notepad.exe", Path.Combine(Environment.CurrentDirectory, "Movies.txt"));
                }
            }
            catch (Exception ex)
            {
                this.stsprgRandomPick.Maximum = 20;
                this.stsprgRandomPick.Style = ProgressBarStyle.Continuous;
                this._strErrorMessage = ex.Message;
                this.ShowError(true);
            }
        }
        private void ChangeStatus(string p_strStatus)
        {
            this.lblSyncStatus.Text = p_strStatus;
            this.Refresh();
        }
        private void Search()
        {
            this.ShowError(false);

            this.GetMovieList_Database();

            //this.lstMovies.Focus();
        }
        private bool IsMovieFile(string pPath)
        {
            List<string> validMovieExtensions = new List<string>() { ".avi", ".mkv" };

            return validMovieExtensions.Contains(Path.GetExtension(pPath).Trim().ToLower());
        }
        private void SetViewed(int pMovieIid, bool pViewed)
        {
            string strUpdate = "UPDATE Movies SET " +
                                        "viewed=@viewed " +
                                        "WHERE iid=@iid";

            SqlCeCommand sqlUpdateCmd = new SqlCeCommand(strUpdate, _sqlConn);                        
            sqlUpdateCmd.Parameters.AddWithValue("@iid", pMovieIid);
            sqlUpdateCmd.Parameters.AddWithValue("@viewed", pViewed);

            sqlUpdateCmd.ExecuteNonQuery();
        }

        private void bkgPicker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                for (int i = 0; i < this.stsprgRandomPick.Maximum; i++)
                {
                    Random rndSeed = new Random();
                    Random rndPicker = new Random(rndSeed.Next() * i);
                    int nPick = rndPicker.Next(0, this.lstMovies.Items.Count);

                    if ((bool)(Invoke(new SelectRandomMovie(GoToMovie), nPick)) == true)
                    {
                        Thread.Sleep(25);
                        e.Result = nPick;
                        this._strErrorMessage = "";
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                this._strErrorMessage = ex.Message;
                Invoke(new DisplayError(ShowError), true);
            }
        }
        private void bkgPicker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this._bPicking = false;
                Invoke(new FinalMovieSelected(SetLastPicked), Convert.ToInt32(e.Result));
            }
            catch (Exception ex)
            {
                this._strErrorMessage = ex.Message;
                Invoke(new DisplayError(ShowError), true);
            }
        }
        private void btnPick_Click(object sender, EventArgs e)
        {        
            this.btnPick.Enabled = false;
            this.btnRefresh.Enabled = false;
            this.stsprgRandomPick.Maximum = 20;

            this.ChangeStatus("Picking random movie ...");
            bkgPicker.RunWorkerAsync();
            this._bPicking = true;        
        }
        private void FrmMain_Shown(object sender, EventArgs e)
        {
            try
            {
                _sqlConn = new SqlCeConnection("data source=.\\Database\\CMM.sdf;");
                if (_sqlConn.State != ConnectionState.Open)
                {
                    _sqlConn.Open();
                }                

                this.GetMovieList_Database();
                this.stslblTotal.Text = this.lstMovies.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                this._strErrorMessage = ex.Message;
                this.ShowError(true);
            }
        }
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            #region close connection to database
            try
            {
                if (this._sqlConn != null)
                {
                    if (this._sqlConn.State != ConnectionState.Closed)
                    {
                        _sqlConn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Database Connection Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            #endregion
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout(Program.AppVersion);
            frmAbout.ShowDialog();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.GetMovieList_Database();
        }
        private void mniZap_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure you want to zap the database?", "Zap Database", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (this.Zap())
                {
                    this.GetMovieList_Database();
                }
            }            
        }
        private void stslblError_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, this._strErrorMessage, "Error Message", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

        }
        private void lstMovies_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string strPath = ((Movie)this.lstMovies.SelectedItem).Path;

                if (File.Exists(strPath))
                {
                    System.Diagnostics.Process.Start(strPath);
                }
                else if (Directory.Exists(strPath))
                {
                    string[] strMovieParts = Directory.GetFiles(strPath, "*.avi");

                    if ((strMovieParts != null) && (strMovieParts.Length > 0))
                    {
                        System.Diagnostics.Process.Start(strMovieParts[0]);
                    }
                }
                else
                {
                    this._strErrorMessage = "Movie path could not be found";
                    this.ShowError(true);
                }                
            }
            catch (Exception ex)
            {
                this._strErrorMessage = ex.Message;
                this.ShowError(true);
            }
        }
        private void lstMovies_KeyDown(object sender, KeyEventArgs e)
        {
            if (Char.IsLetterOrDigit((char)e.KeyValue))
            {
                this.txtSearch.Text = this.txtSearch.Text + ((char)e.KeyValue).ToString();
                this.txtSearch.SelectionStart = this.txtSearch.Text.Length;
                this.txtSearch.Focus();
                e.SuppressKeyPress = true;
            }                                    
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_bAllowSearchTextChange)
            {
                this.Search();
            }
            _bAllowSearchTextChange = true;
        }
        private void btnSync_Click(object sender, EventArgs e)
        {           
            List<string> syncDirs = this.GetSyncDirList();

            if ((syncDirs != null) && (syncDirs.Count > 0))
            {
                this.ChangeStatus("Synching database ...");
                this.Refresh();
                this.SyncPathWithDatabase(syncDirs);
                this.ChangeStatus("");
            }
            else
            {
                MessageBox.Show(this, "One or more sync directories must be specified", "Sync Error", MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
           
        }	          
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveToTextFile();            
        }
        private void mniSetViewedDir_Click(object sender, EventArgs e)
        {
            string strLastPath = XMLManager.ReadSetting("CMM.xml", "Settings", "ViewedPath");

            this.dlgFolderBrowser.SelectedPath = strLastPath;
            if (this.dlgFolderBrowser.ShowDialog(this) == DialogResult.OK)
            {
                XMLManager.WriteSetting("CMM.xml", "Settings", "ViewedPath", dlgFolderBrowser.SelectedPath);
            }       
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }
        private void btnImdb_Click(object sender, EventArgs e)
        {
            if (this.SelectedMovie != null)
            {
                string strTitle = this.SelectedMovie.Title;

                string strSearchString = strTitle.Replace(" ", "+");

                System.Diagnostics.Process.Start("http://www.imdb.com/find?s=all&q=" + strSearchString + "&x=0&y=0");
            }
            else
            {
                MessageBox.Show(this, "Please select a movie from the list", "No movie selected", MessageBoxButtons.OK, 
                                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
           
        }
        private void btnCopyToViewed_Click(object sender, EventArgs e)
        {
            string strPath = ((Movie)this.lstMovies.SelectedItem).Path;
            
            string strViewedPath = XMLManager.ReadSetting("CMM.xml", "Settings", "ViewedPath");

            if (strViewedPath != "") 
            {
                try
                {
                    int previousIndex = this.lstMovies.SelectedIndex;

                    this.SetViewed(this.SelectedMovie.Iid, true);

                    this.Search();

                    if (this.lstMovies.Items.Count > previousIndex)
                    {
                        this.lstMovies.SelectedIndex = previousIndex;
                    }
                    

                    //DialogResult result = MessageBox.Show(this, "This movie will be marked as viewed.  Copy to viewed folder?", "Copy Movie", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    //if (result == DialogResult.Yes)
                    //{
                    //    this.ChangeStatus("Copying file ...");
                    //    File.Move(strPath, Path.Combine(strViewedPath, Path.GetFileName(strPath)));
                    //    this.ChangeStatus("Deleting original file ...");
                    //    File.Delete(strPath);
                    //    this.ChangeStatus("");
                    //    this.btnSync_Click(this, null);
                    //}
                }
                catch (Exception ex)
                {
                    this.ChangeStatus("");
                    MessageBox.Show(this, ex.Message, "Error copying files", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                }
            } 
            else 
            {
                MessageBox.Show(this, "You must set a \"Viewed Folder\" before using this feature", "No Viewed folder set", MessageBoxButtons.OK, 
                                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }


        }
        private void lstMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMovies.SelectedIndex > -1)
            {
                this.grpLineFunctions.Visible = true;

                Movie mvSelectedMovie = ((Movie)lstMovies.SelectedItem);

                this.lblDuration.Text = mvSelectedMovie.GetDuration();
                this.chkSubs.Checked = mvSelectedMovie.Subs;
                this.btnCopyToViewed.Enabled = !mvSelectedMovie.Viewed;
                this.lblResolution.Text = mvSelectedMovie.ResWidth.ToString("N0") + " x " + mvSelectedMovie.ResHeight.ToString("N0");
                               
            }
            else
            {
                this.grpLineFunctions.Visible = false;
            }
        }
        private void txtTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Search();
            }
        }   
        private void txtFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Search();
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            Movie mvSelectedMovie = (Movie)lstMovies.SelectedItem;            

            if (Directory.Exists(mvSelectedMovie.Path))
            {
                System.Diagnostics.Process.Start(mvSelectedMovie.Path);
            }
            else
            {
                System.Diagnostics.Process.Start(Path.GetDirectoryName(mvSelectedMovie.Path));
            }            
        }
        private void txtFrom_Click(object sender, EventArgs e)
        {
            this.txtFrom.SelectAll();
        }

        private void txtTo_Click(object sender, EventArgs e)
        {
            this.txtTo.SelectAll();
        }

        private void lstMovies_DrawItem(object sender, DrawItemEventArgs e)
        {
            Movie movie = this.lstMovies.Items[e.Index] as Movie;
            if (movie != null)
            {
                if (movie.Viewed)
                {
                    e.Graphics.DrawString(movie.Title, new Font("Arial", 8), new SolidBrush(System.Drawing.Color.DarkGray), e.Bounds);
                    
                }
            }
        }
        private void txtCurrentSyncDirs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.txtCurrentSyncDirs.ReadOnly = false;
        }

        private void txtCurrentSyncDirs_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {                
                this.SetLastSyncDirs(this.txtCurrentSyncDirs.Text);
                this.txtCurrentSyncDirs.ReadOnly = true;

                //string strLastPath = XMLManager.ReadSetting("CMM.xml", "Settings", "LastSynchPath");

                //this.dlgFolderBrowser.SelectedPath = strLastPath;
                //if (this.dlgFolderBrowser.ShowDialog(this) == DialogResult.OK)
                //{
                //    XMLManager.WriteSetting("CMM.xml", "Settings", "LastSynchPath", dlgFolderBrowser.SelectedPath);
                //}         
            }
        }

        private void SetLastSyncDirs(string pSyncDirs)
        {
            XMLManager.WriteSetting("CMM.xml", "Settings", "LastSynchPaths", pSyncDirs);
        }
        private string GetSyncDirs()
        {
            return XMLManager.ReadSetting("CMM.xml", "Settings", "LastSynchPaths");
        }
        private List<string> GetSyncDirList()
        {            
            List<string> movieDirPaths = new List<string>();

            string syncDirsString = this.GetSyncDirs();
            if (!String.IsNullOrEmpty(syncDirsString))
            {
                movieDirPaths = syncDirsString.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            return movieDirPaths;
        }

        private void txtCurrentSyncDirs_Leave(object sender, EventArgs e)
        {
            this.txtCurrentSyncDirs.ReadOnly = true;
            this.SetLastSyncDirs(this.txtCurrentSyncDirs.Text);
        }
    }      
}