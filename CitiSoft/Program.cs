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
        public static Login Login
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            

            while (true) // Infinite loop to re-display the LoginForm
            {
                using (var loginForm = new Login())
                {
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        // If the login is not successful, exit the application
                        break;
                    }
                }

                // Show the main window after a successful login
                using (var runtimeUi = new RuntimeUI())
                {
                    runtimeUi.ShowDialog();

                    // If the user logs out, restart the loop and show login form again
                    
                }
        }   }
    }
}
