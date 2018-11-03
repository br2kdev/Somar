using Somar.DAL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoSomarUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormPrincipal());

            Properties.Settings.Default["SomarDatabase"] = Globals.stringConn;

            FormLogin f = new FormLogin();

            if (f.ShowDialog() == DialogResult.OK)
                Application.Run(new FormPrincipal());
        }
    }
}
