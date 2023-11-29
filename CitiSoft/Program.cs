using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using CitiSoft;

namespace CitiSoft
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var loginForm = new Login()) 
            {
               
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    
                    Application.Run(new RuntimeUI());
                }
                else
                {
                    
                    Application.Exit();
                }
            }
        }
    }
}
