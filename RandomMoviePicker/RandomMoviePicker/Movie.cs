using System;
using System.Collections.Generic;
using System.Text;

namespace CompactMovieManager
{
    public class Movie
    {
        private int _iid = 0;
        private string _strTitle = "";
        private int _nDuration = 0;
        private string _strPath = "";
        private bool _bViewed = false;
        private bool _bSubs = false;
        private int _resWidth = 0;
        private int _resHeight = 0;

        public int Iid
        {
            get
            {
                return _iid;
            }            
        }
        public string Title
        {
            get
            {
                return _strTitle;
            }
        }
        public int Duration
        {
            get
            {
                return _nDuration;
            }
        }
        public string Path
        {
            get
            {
                return _strPath;
            }
        }
        public bool Viewed
        {
            get
            {
                return _bViewed;
            }
        }
        public bool Subs
        {
            get
            {
                return _bSubs;
            }
        }
        public int ResWidth
        {
            get
            {
                return _resWidth;
            }
        }
        public int ResHeight
        {
            get
            {
                return _resHeight;
            }
        }
        public Movie(int pIid, string p_strTitle, int p_nDuration, 
                        string p_strPath, bool p_bViewed,
                        bool p_bSubs, int pResWidth, int pResHeight)
        {
            _iid = pIid;
            _strTitle = p_strTitle;
            _nDuration = p_nDuration;
            _strPath = p_strPath;
            _bViewed = p_bViewed;
            _bSubs = p_bSubs;
            _resWidth = pResWidth;
            _resHeight = pResHeight;
        }

        public override string ToString()
        {
            return _strTitle;
        }

        public string GetDuration()
        {
            double nMinutes = this._nDuration;
            int nHours = Convert.ToInt32(Math.Floor(nMinutes / 60));
            nMinutes = nMinutes - (nHours * 60);

            return nHours + "h " + nMinutes + "m";
        }
    }
}
