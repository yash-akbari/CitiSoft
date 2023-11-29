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
    public class ChangePasswordForm : Form
    {
        private TextBox oldPasswordTextBox;
        private TextBox newPasswordTextBox;
        private TextBox confirmNewPasswordTextBox;
        private Button changePasswordButton;
        private Button forgotPasswordButton;
        private Label oldPasswordLabel;
        private Label newPasswordLabel;
        private Label confirmNewPasswordLabel;

        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            oldPasswordTextBox = new TextBox { PasswordChar = '*' };
            newPasswordTextBox = new TextBox { PasswordChar = '*' };
            confirmNewPasswordTextBox = new TextBox { PasswordChar = '*' };
            changePasswordButton = new Button { Text = "Change Password" };
            forgotPasswordButton = new Button { Text = "Forgot Password?" };
            oldPasswordLabel = new Label { Text = "Old Password:" };
            newPasswordLabel = new Label { Text = "New Password:" };
            confirmNewPasswordLabel = new Label { Text = "Confirm New Password:" };

            

            // Add controls to the form
            Controls.AddRange(new Control[] {
            oldPasswordLabel, oldPasswordTextBox,
            newPasswordLabel, newPasswordTextBox,
            confirmNewPasswordLabel, confirmNewPasswordTextBox,
            changePasswordButton, forgotPasswordButton
        });

            

            // Event handlers
            changePasswordButton.Click += ChangePasswordButton_Click;
            forgotPasswordButton.Click += ForgotPasswordButton_Click;

            // Set the form properties
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 180); // Adjust as needed
            Text = "Change Password";
        }

        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            string oldPassword = oldPasswordTextBox.Text;
            string newPassword = newPasswordTextBox.Text;
            string confirmNewPassword = confirmNewPasswordTextBox.Text;

            // Validation and password change logic here
            // ...
        }

        private void ForgotPasswordButton_Click(object sender, EventArgs e)
        {
            // Logic to handle forgotten password here
            // This could involve showing another form or a dialog to handle password reset
            ForgotPasswordForm forgotPasswordForm = new ForgotPasswordForm();
            forgotPasswordForm.ShowDialog();
        }
    }
}
