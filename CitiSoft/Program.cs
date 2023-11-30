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

                // Show the main application window after successful login
                var userForm = new UserProfileForm();
                if (userForm.ShowDialog() == DialogResult.Abort)
                {
                    // User chose "Logout", we will restart the loop and show LoginForm again
                    continue;
                }
                else
                {
                    // If the user closes the UserProfileForm in another way, we exit the application
                    break;
                }
            }

            Application.Exit(); // Exit the application after the loop ends
        }
    }
}
