using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABEYAT
{
    internal static class Program
    {
        /// <summary>
        /// 
        /// 1.4 Stable - LABEYAT: Crud Fuctionality
        /// 
        /// In this version we added a crud fuctionality for some windows, the requeriments 
        /// indicate the aplication no have a sidebar or navegation bar to move arround the aplication so, you have change 
        /// the window defaul window from "window" form, sorry :/
        /// 
        /// for more information about the requeriments and use, please visit the README.md file atach in the project
        /// 
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new window());
        }
    }
}
