using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;

namespace CompactMovieManager
{
    static class Program
    {
        private static Version _vVersion = null;

        public static Version AppVersion
        {
            get
            {
                return _vVersion;
            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _vVersion = new Version(Application.ProductVersion.ToString());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}