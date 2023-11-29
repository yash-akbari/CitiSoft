using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{
    public partial class UserProfileForm : Form
    {
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
            ChangePasswordForm changePasswordForm = new ChangePasswordForm();
            changePasswordForm.ShowDialog(this); // Show the form as a modal dialog
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            ForgotPasswordForm forgotPasswordForm = new ForgotPasswordForm(); // Assuming you have a form for this
            forgotPasswordForm.ShowDialog();
        }
    }
}
