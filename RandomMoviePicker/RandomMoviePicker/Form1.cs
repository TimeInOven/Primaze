using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Data.SqlServerCe;
using System.Collections;

namespace CompactMovieManager
{
    public partial class frmCompactMovieManager : Form
    {
        private bool _bPicking = false;
        private string _strErrorMessage = "";
        private enum Mode
        {
            Path,
            Database
        }
        private Mode CurrentMode = Mode.Path;
        private string _strCurrentPath = "";
        private SqlCeConnection _sqlConn = null;

        public delegate void SelectRandomMovie(int p_nPick);
        public delegate void FinalMovieSelected(int p_nPick);
        public delegate void DisplayError(bool p_bShow);

        public frmCompactMovieManager()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (this.dlgFolderBrowser.ShowDialog(this) == DialogResult.OK)
            {
                this.txtPath.Text = dlgFolderBrowser.SelectedPath;
                this.fswFileWatcher.Path = dlgFolderBrowser.SelectedPath;

                this.GetMovieList(CurrentMode);
            }
        }
        private void frmCompactMovieManager_Load(object sender, EventArgs e)
        {
            this.cmbSearch.SelectedIndex = 0;

            #region retrieve app mode
            string strMode = XMLManager.ReadSetting("MovieManager.xml", "Settings", "Mode");
            if (strMode == null)
            {
                CurrentMode = Mode.Path;
            }
            else if (strMode == "PATH")
            {
                CurrentMode = Mode.Path;
            }
            else if (strMode == "DATABASE")
            {
                CurrentMode = Mode.Database;
            }
            #endregion

            if (CurrentMode == Mode.Path)
            {
                #region get movies from path
                this.mniPathMode.Checked = true;

                string strPath = XMLManager.ReadSetting("MovieManager.xml", "Settings", "MoviesPath");
                if (strPath != null)
                {
                    this.txtPath.Text = strPath;
                }
                else
                {
                    this.txtPath.Text = "";
                }
                this.GetMovieList(CurrentMode);
                this.fswFileWatcher.Path = this.txtPath.Text; 
                #endregion
            }
            else if (CurrentMode == Mode.Database)
            {
                try 
                {
                    _sqlConn = new SqlCeConnection("data source=.\\Database\\CMM.sdf;");
                    if (_sqlConn.State != ConnectionState.Open) 
                    {
                        _sqlConn.Open();
                    }
                }
                catch (Exception ex) 
                {
                    this._strErrorMessage = ex.Message;
                    this.ShowError(true);
                }

                this.mniDatabase.Checked = true;
            }
            else
            {
                this.mniDatabase.Checked = true;
            }            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.GetMovieList(CurrentMode);
        }
        private void btnPick_Click(object sender, EventArgs e)
        {
            this.btnPick.Enabled = false;
            this.btnRefresh.Enabled = false;
            
            bkgPicker.RunWorkerAsync();
            this._bPicking = true;
        }
        private void grpMovieList_Enter(object sender, EventArgs e)
        {

        }

        private void bkgPicker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                for (int i = 0; i < 20; i++)
                {
                    Random rndSeed = new Random();
                    Random rndPicker = new Random(rndSeed.Next() * i);
                    int nPick = rndPicker.Next(0, this.lstMovies.Items.Count);
                    
                    Invoke(new SelectRandomMovie(GoToMovie), nPick);
                    Thread.Sleep(100);
                    e.Result = nPick;
                    this._strErrorMessage = "";
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

        private void GetMovieList(Mode p_Mode)
        {
            lstMovies.Items.Clear();

            if (p_Mode == Mode.Path)
            {
                #region Get movie list from path
                if (this.txtPath.Text != "")
                {
                    try
                    {
                        string[] strMovies = Directory.GetFiles(this.txtPath.Text);
                        string[] strMovieFolders = Directory.GetDirectories(this.txtPath.Text);

                        if (strMovies != null)
                        {
                            if (strMovies.Length > 0)
                            {
                                lstMovies.Sorted = true;
                                foreach (string strMovie in strMovies)
                                {
                                    lstMovies.Items.Add(Path.GetFileNameWithoutExtension(strMovie));
                                }
                                foreach (string strMovieFolder in strMovieFolders)
                                {
                                    if (!(Path.GetFileName(strMovieFolder) == "Viewed"))
                                    {
                                        lstMovies.Items.Add(Path.GetFileName(strMovieFolder));
                                    }
                                }
                            }
                        }
                        _strCurrentPath = this.txtPath.Text;
                        this._strErrorMessage = "";
                        this.ShowError(false);
                        this.lblTotalMovies.Text = this.lstMovies.Items.Count.ToString();
                    }
                    catch (Exception ex)
                    {
                        this._strErrorMessage = ex.Message;
                        this.ShowError(true);
                    }
                }
                else
                {
                    this._strErrorMessage = "Movie path not specified";
                    this.ShowError(true);
                }
                #endregion
            }
            else if (p_Mode == Mode.Database)
            {
                string strSelect = "SELECT title FROM Movies";
                //SqlCeCommand sqlCmd = new SqlCeCommand(strSelect, 
            }
        }
        private void GoToMovie(int p_nPick)
        {
            try
            {
                this.lstMovies.SelectedIndex = p_nPick;
                this.stsprgRandomPick.Increment(1);
            }
            catch (Exception ex)
            {
                this._strErrorMessage = ex.Message;
                this.ShowError(true);
            }
        }
        private void SetLastPicked(int p_nPick)
        {
            this.stslblLastPicked.Text = this.lstMovies.Items[p_nPick].ToString();
            this.stsprgRandomPick.Value = 0;
            this.btnPick.Enabled = true;
            this.btnRefresh.Enabled = true;
            this.ShowError(false);
        }
        private void ShowError(bool p_bShow)
        {
            this.stslblError.Visible = p_bShow;
        }
        private bool MovieHasSubtitles(string strPath)
        {
            try
            {
                if (Directory.Exists(strPath))
                {
                    string[] strFiles_sub = Directory.GetFiles(strPath, "*.sub");
                    string[] strFiles_srt = Directory.GetFiles(strPath, "*.srt");

                    if ((strFiles_srt.Length > 0) || (strFiles_sub.Length > 0))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                this._strErrorMessage = ex.Message;
                this.ShowError(true);
                return false;
            }
        }
        private bool SaveListToDatabase()
        {
            int nLastIndex = 0;
            bool bCloseConnectionAfterSave = false;

            try
            {
                this.ShowError(false);

                #region create and open connection if connection is null
                if (_sqlConn == null)
                {
                    bCloseConnectionAfterSave = true;
                    _sqlConn = new SqlCeConnection("data source=.\\Database\\CMM.sdf;");
                    _sqlConn.Open();
                } 
                #endregion

                SqlCeTransaction sqlTrans = _sqlConn.BeginTransaction();

                #region Prepare commands
                string strInsertMovie = "INSERT INTO Movies (title) " +
                                                  "VALUES (@title)";
                string strSelect = "SELECT title from Movies Where title=@title";
                string strUpdate = "UPDATE Movies SET path=@path WHERE title=@title";

                SqlCeCommand sqlInsCmd = new SqlCeCommand(strInsertMovie, _sqlConn, sqlTrans);
                sqlInsCmd.Parameters.AddWithValue("@title", "");
                SqlCeCommand sqlSelCmd = new SqlCeCommand(strSelect, _sqlConn, sqlTrans);
                sqlSelCmd.Parameters.AddWithValue("@title", "");
                SqlCeCommand sqlUpdCmd = new SqlCeCommand(strUpdate, _sqlConn, sqlTrans);
                sqlUpdCmd.Parameters.AddWithValue("@path", "");
                sqlUpdCmd.Parameters.AddWithValue("@title", ""); 
                #endregion

                #region prepare progress bar
                this.stsprgRandomPick.Maximum = lstMovies.Items.Count;
                this.stsprgRandomPick.Value = 0;
                this.stsprgRandomPick.Style = ProgressBarStyle.Continuous; 
                #endregion

                for (int i = 0; i < lstMovies.Items.Count; i++)
                {
                    nLastIndex = i;
                    sqlSelCmd.Parameters["@title"].Value = lstMovies.Items[i].ToString();

                    if (sqlSelCmd.ExecuteScalar() == null)
                    {
                        sqlInsCmd.Parameters["@title"].Value = lstMovies.Items[i].ToString();
                        sqlInsCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        if (CurrentMode == Mode.Path)
                        {
                            #region update file or folder path
                            string[] strFilePath = Directory.GetFiles(this.txtPath.Text, this.lstMovies.Items[i].ToString() + ".*");
                            string[] strFolderPath = Directory.GetDirectories(this.txtPath.Text, this.lstMovies.Items[i].ToString());

                            sqlUpdCmd.Parameters["@title"].Value = lstMovies.Items[i].ToString();
                            if (strFilePath.Length > 0)
                            {
                                sqlUpdCmd.Parameters["@path"].Value = Path.Combine(_strCurrentPath, strFilePath[0]);
                            }
                            else if (strFolderPath.Length > 0)
                            {
                                sqlUpdCmd.Parameters["@path"].Value = Path.Combine(_strCurrentPath, strFolderPath[0]);
                            }
                            else
                            {
                                sqlUpdCmd.Parameters["@path"].Value = "";
                            } 
                            #endregion
                            sqlUpdCmd.ExecuteNonQuery();
                        } 
                    }

                    stsprgRandomPick.Increment(1);
                }
                stsprgRandomPick.Value = 0;

                sqlTrans.Commit();                

                return true;            
            }
            catch (SqlCeException sqlEx)
            {
                this.lstMovies.SelectedIndex = nLastIndex;
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
                #region Close connection
                if (bCloseConnectionAfterSave)
                {
                    if (_sqlConn != null)
                    {
                        if (_sqlConn.State == ConnectionState.Open)
                        {
                            _sqlConn.Close();
                        }
                    }
                } 
                #endregion
            }
        }
        private void InitFormLayout(Mode p_Mode)
        {
            if (p_Mode == Mode.Database)
            {
                //hide path groupbox, etc
            }
        }
            
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, this._strErrorMessage, "Error Message", MessageBoxButtons.OK, 
                            MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
        private void lstMovies_DoubleClick(object sender, EventArgs e)
        {
            try
            {                
                string[] strMovie = Directory.GetFiles(_strCurrentPath,
                                                        this.lstMovies.SelectedItem.ToString() + "*");
                if ((strMovie != null) && (strMovie.Length > 0))
                {
                    if (File.Exists(strMovie[0]))
                    {
                        System.Diagnostics.Process.Start(strMovie[0]);                    
                    }
                }
                else
                {
                    string[] strMovieParts = Directory.GetFiles(Path.Combine(_strCurrentPath, this.lstMovies.SelectedItem.ToString()), "*.avi");

                    if ((strMovieParts != null) && (strMovieParts.Length > 0))
                    {
                        System.Diagnostics.Process.Start(strMovieParts[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                this._strErrorMessage = ex.Message;
                this.ShowError(true);
            }
        }
        private void fswFileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (!_bPicking)
            {
                this.GetMovieList(CurrentMode);
            }
        }
        private void fswFileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (!_bPicking)
            {
                this.GetMovieList(CurrentMode);
            }
        }
        private void fswFileWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (!_bPicking)
            {
                this.GetMovieList(CurrentMode);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.cxtSave.Show(this.btnSave, Convert.ToInt32(btnSave.Width / 2), Convert.ToInt32(btnSave.Height / 2));           
        }
        private void frmCompactMovieManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            #region determine selected mode
            string strMode = "";
            if (this.CurrentMode == Mode.Path)
            {
                strMode = "PATH";
            }
            else if (this.CurrentMode == Mode.Database)
            {
                strMode = "DATABASE";
            }
            else
            {
                //default
                strMode = "PATH";
            }
            #endregion

            if (CurrentMode == Mode.Path)
            {
                XMLManager.WriteSetting("MovieManager.xml", "Settings", "MoviesPath", this.txtPath.Text);
            }
            XMLManager.WriteSetting("MovieManager.xml", "Settings", "Mode", strMode);

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
        private void mniAbout_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog();
        }
        private void lstMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.MovieHasSubtitles(Path.Combine(this.txtPath.Text, this.lstMovies.SelectedItem.ToString())))
            {
                this.chkSubtitles.Checked = true;
            }
            else
            {
                this.chkSubtitles.Checked = false;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
        private void mniDatabase_CheckedChanged(object sender, EventArgs e)
        {
            this.mniPathMode.Checked = !this.mniDatabase.Checked;
            if (this.mniPathMode.Checked) 
            {
                this.CurrentMode = Mode.Path;
            } 
            else 
            {
                this.CurrentMode = Mode.Database;
            }
        }
        private void mniPathMode_CheckedChanged(object sender, EventArgs e)
        {
            this.mniDatabase.Checked = !this.mniPathMode.Checked;
            if (this.mniPathMode.Checked)
            {
                this.CurrentMode = Mode.Path;
            }
            else
            {
                this.CurrentMode = Mode.Database;
            }
        }
        private void saveTotextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.stsprgRandomPick.Maximum = lstMovies.Items.Count;
                string[] aMovies = new string[lstMovies.Items.Count];
                for (int i = 0; i < lstMovies.Items.Count; i++)
                {
                    aMovies.SetValue(lstMovies.Items[i], i);
                    this.stsprgRandomPick.Increment(1);
                }
                this.stsprgRandomPick.Maximum = 20;
                this.stsprgRandomPick.Value = 0;
                File.WriteAllLines("Movies.txt", aMovies);
                this.ShowError(false);
                this.stsprgRandomPick.Style = ProgressBarStyle.Continuous;

                if (MessageBox.Show(this, "Movies.txt saved to:\n" + Environment.CurrentDirectory + "\n\nGo to directory?", "Save Successful", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", Environment.CurrentDirectory);
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
       
        private void saveToDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SaveListToDatabase())
            {
                MessageBox.Show(this, "Database updated successfully!", "Database", MessageBoxButtons.OK, 
                                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
    }
}