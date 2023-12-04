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
                    // Show the login form as a dialog and check the result.
                    var result = loginForm.ShowDialog();

                    // If the result is not OK, which means the user clicked the Cancel button or closed the form, exit the loop.
                    if (result != DialogResult.OK)
                    {
                        break;
                    }

                    // Retrieve user information from the login form. These properties should be set in the login form upon successful login.
                    var userType = loginForm.UserType;
                    var userId = loginForm.UserId;

                    // Show the main application window after a successful login.
                    using (var runtimeUi = new RuntimeUI(userType, userId))
                    {
                        runtimeUi.ShowDialog();

                        // If the user logs out, the runtimeUi form will close and the loop will start again showing the login form.
                        // If the user closes the application, the entire application exits.
                    }
                 }
            }   }
    }
}
