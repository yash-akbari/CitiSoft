using System;
using System.Drawing;
using System.Windows.Forms;

namespace CitiSoft
{
    public partial class UserProfileForm : Form
    {
        private Button changePasswordButton;
        private Button logoutButton;
        public UserProfileForm()
        {
            InitializeComponent();
            InitializeChangePasswordButton();
            this.Dock = DockStyle.Fill;

        }
        private void InitializeChangePasswordButton()
        {
            changePasswordButton = new Button
            {
                Text = "Change Password",
                Size = new Size(120, 40),
                Location = new Point(10, 10)
            };
            changePasswordButton.Click += ChangePasswordButton_Click;
            Controls.Add(changePasswordButton);
        }
        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {

            InitializeComponent();
            ChangePasswordForm changePasswordForm = new ChangePasswordForm();
            changePasswordForm.ShowDialog(this);
        }
        private void InitializeLogoutButton()
        {
            logoutButton = new Button
            {
                Text = "Logout",
                Size = new Size(100, 30),
                Location = new Point(10, 10) 
            };
            logoutButton.Click += LogoutButton_Click;
            Controls.Add(logoutButton);
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = DialogResult.Abort; 
            this.Close();
        }

    }
}
