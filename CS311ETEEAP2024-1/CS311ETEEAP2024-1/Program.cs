using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS311ETEEAP2024_1
{
    internal static class Program
    {
        // Setup your mySQL server here, change based on your setup
        public static string Server = "127.0.0.1";
        public static string Database = "emsdb";
        public static string Username = "testuser";
        public static string Password = "12345678";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmlogin());
        }
    }
}
