using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CitiSoft
{
    public partial class ForgotPasswordForm : Form
    {
        private TextBox usernameTextBox;
        private TextBox newPasswordTextBox;
        private TextBox confirmNewPasswordTextBox;
        private Button submitButton;
        private Label instructionLabel;
        private Label usernameLabel;
        private Label newPasswordLabel;
        private Label confirmNewPasswordLabel;

        public ForgotPasswordForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void InitializeComponent()
        {
            this.usernameTextBox = new TextBox();
            this.newPasswordTextBox = new TextBox();
            this.confirmNewPasswordTextBox = new TextBox();
            this.submitButton = new Button();
            this.instructionLabel = new Label();
            this.usernameLabel = new Label();
            this.newPasswordLabel = new Label();
            this.confirmNewPasswordLabel = new Label();

            // instructionLabel
            this.instructionLabel.AutoSize = true;
            this.instructionLabel.Location = new Point(10, 10);
            this.instructionLabel.Text = "Enter your username and new password:";

            // usernameLabel
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new Point(10, 40);
            this.usernameLabel.Text = "Username:";

            // usernameTextBox
            this.usernameTextBox.Location = new Point(120, 40);

            // newPasswordLabel
            this.newPasswordLabel.AutoSize = true;
            this.newPasswordLabel.Location = new Point(10, 70);
            this.newPasswordLabel.Text = "New Password:";

            // newPasswordTextBox
            this.newPasswordTextBox.Location = new Point(120, 70);
            this.newPasswordTextBox.PasswordChar = '*';

            // confirmNewPasswordLabel
            this.confirmNewPasswordLabel.AutoSize = true;
            this.confirmNewPasswordLabel.Location = new Point(10, 100);
            this.confirmNewPasswordLabel.Text = "Confirm Password:";

            // confirmNewPasswordTextBox
            this.confirmNewPasswordTextBox.Location = new Point(120, 100);
            this.confirmNewPasswordTextBox.PasswordChar = '*';

            // submitButton
            this.submitButton.Location = new Point(120, 130);
            this.submitButton.Text = "Submit";
            this.submitButton.Click += new EventHandler(this.SubmitButton_Click);

            // ForgotPasswordForm
            this.ClientSize = new Size(300, 170);
            this.Controls.Add(this.instructionLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.newPasswordLabel);
            this.Controls.Add(this.newPasswordTextBox);
            this.Controls.Add(this.confirmNewPasswordLabel);
            this.Controls.Add(this.confirmNewPasswordTextBox);
            this.Controls.Add(this.submitButton);
            this.Text = "Forgot Password";
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string username = this.usernameTextBox.Text;
            string newPassword = this.newPasswordTextBox.Text;
            string confirmNewPassword = this.confirmNewPasswordTextBox.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                newPassword != confirmNewPassword)
            {
                MessageBox.Show("Username, new password, and password confirmation are required. The passwords must match.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
               
                using (SqlConnection conn = new SqlConnection(DataBaseManager.functionalityConnectionString))
                {
                    conn.Open();
                    var query = "UPDATE [User] SET newPwd = @NewPassword, pwdChnageStatus = 1 WHERE userName = @Username";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@NewPassword", newPassword); 
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Your password reset request has been submitted. Please wait for an admin to approve.", "Request Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No matching username found or error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
