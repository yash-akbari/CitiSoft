using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{
    public partial class UserRegistrationForm : Form

    {
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtPhone;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private ComboBox cmbUserType;
        private Button btnRegister;
        private Label lblTitle;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblPhone;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblUserType;
        private TextBox txtDeleteUsername;
        private Button btnDeleteUser;
        private Label lblDeleteUser;

        public UserRegistrationForm()
        {
            InitializeComponent();
            InitializeDeleteComponents();
        }
        private void InitializeDeleteComponents()
        {
            // Initialize and configure the delete user label and textbox
            lblDeleteUser = new Label { Text = "Username:", AutoSize = true };
            txtDeleteUsername = new TextBox();

            // Initialize and configure the delete user button
            btnDeleteUser = new Button { Text = "Delete User" };

            // Positioning controls
            lblDeleteUser.Location = new Point(10, 330);
            txtDeleteUsername.Location = new Point(130, 330);
            txtDeleteUsername.Size = new Size(150, 20);
            btnDeleteUser.Location = new Point(130, 360);
            btnDeleteUser.Size = new Size(150, 20);

            // Subscribe to button click event
            btnDeleteUser.Click += BtnDeleteUser_Click;

            // Add controls to the form
            Controls.Add(lblDeleteUser);
            Controls.Add(txtDeleteUsername);
            Controls.Add(btnDeleteUser);
        }
        private void InitializeComponent()
        {
            this.txtFirstName = new TextBox();
            this.txtLastName = new TextBox();
            this.txtPhone = new TextBox();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.cmbUserType = new ComboBox();
            this.btnRegister = new Button();
            this.lblTitle = new Label();
            this.lblFirstName = new Label();
            this.lblLastName = new Label();
            this.lblPhone = new Label();
            this.lblUsername = new Label();
            this.lblPassword = new Label();
            this.lblUserType = new Label();

            // Title label
            lblTitle.Text = "User Registration";
            lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            lblTitle.Location = new System.Drawing.Point(10, 10);
            lblTitle.Size = new System.Drawing.Size(200, 24);
            this.Controls.Add(lblTitle);

            // First Name label and textbox
            lblFirstName.Text = "First Name:";
            lblFirstName.Location = new System.Drawing.Point(20, 50);
            lblFirstName.Size = new System.Drawing.Size(100, 20);
            txtFirstName.Location = new System.Drawing.Point(130, 50);
            txtFirstName.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(lblFirstName);
            this.Controls.Add(txtFirstName);

            // Last Name label and textbox
            lblLastName.Text = "Last Name:";
            lblLastName.Location = new System.Drawing.Point(20, 80);
            lblLastName.Size = new System.Drawing.Size(100, 20);
            txtLastName.Location = new System.Drawing.Point(130, 80);
            txtLastName.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(lblLastName);
            this.Controls.Add(txtLastName);

            // Phone label and textbox
            lblPhone.Text = "Phone:";
            lblPhone.Location = new System.Drawing.Point(20, 110);
            lblPhone.Size = new System.Drawing.Size(100, 20);
            txtPhone.Location = new System.Drawing.Point(130, 110);
            txtPhone.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(lblPhone);
            this.Controls.Add(txtPhone);

            // Username label and textbox
            lblUsername.Text = "Username:";
            lblUsername.Location = new System.Drawing.Point(20, 140);
            lblUsername.Size = new System.Drawing.Size(100, 20);
            txtUsername.Location = new System.Drawing.Point(130, 140);
            txtUsername.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);

            // Password label and textbox
            lblPassword.Text = "Password:";
            lblPassword.Location = new System.Drawing.Point(20, 170);
            lblPassword.Size = new System.Drawing.Size(100, 20);
            txtPassword.Location = new System.Drawing.Point(130, 170);
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);

            // User Type label and combobox
            lblUserType.Text = "User Type:";
            lblUserType.Location = new System.Drawing.Point(20, 200);
            lblUserType.Size = new System.Drawing.Size(100, 20);
            cmbUserType.Location = new System.Drawing.Point(130, 200);
            cmbUserType.Size = new System.Drawing.Size(150, 20);
            cmbUserType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUserType.Items.Add(new { Text = "Admin", Value = 1 });
            cmbUserType.Items.Add(new { Text = "Manager", Value = 2 });
            cmbUserType.Items.Add(new { Text = "User", Value = 3 });
            cmbUserType.DisplayMember = "Text";
            cmbUserType.ValueMember = "Value";
            this.Controls.Add(lblUserType);
            this.Controls.Add(cmbUserType);

            // Register button
            btnRegister.Text = "Register";
            btnRegister.Location = new System.Drawing.Point(105, 240);
            btnRegister.Size = new System.Drawing.Size(100, 30);
            btnRegister.Click += new EventHandler(btnRegister_Click);
            this.Controls.Add(btnRegister);

            // Form settings
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(lblTitle);
            this.Controls.Add(txtFirstName);
            this.Controls.Add(txtLastName);
            this.Controls.Add(txtPhone);
            this.Controls.Add(txtUsername);
            this.Controls.Add(txtPassword);
            this.Controls.Add(cmbUserType);
            this.Controls.Add(btnRegister);
            this.Controls.Add(lblFirstName);
            this.Controls.Add(lblLastName);
            this.Controls.Add(lblPhone);
            this.Controls.Add(lblUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(lblUserType);
            this.Name = "UserRegistrationForm";
            this.Text = "Registration";
        

        }
        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            var usernameToDelete = txtDeleteUsername.Text.Trim();
            if (string.IsNullOrEmpty(usernameToDelete))
            {
                MessageBox.Show("Please enter a username to delete.");
                return;
            }

            // Confirmation dialog before deletion
            var confirmResult = MessageBox.Show($"Are you sure to delete user {usernameToDelete}?",
                                                "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                DeleteUserByUsername(usernameToDelete);
            }
        }

        private void DeleteUserByUsername(string username)
        {
            try
            {
                using (var connection = new SqlConnection(DataBaseManager.functionalityConnectionString))
                {
                    var query = "DELETE FROM [User] WHERE userName = @Username";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("User successfully deleted.");
                            // Optionally refresh the user list if you have a display control
                        }
                        else
                        {
                            MessageBox.Show("User not found or could not be deleted.");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while deleting the user: " + ex.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Проверка ввода пользователя
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Please enter the first name.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please enter the last name.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please enter a phone number.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter a username.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter a password.");
                return;
            }
            if (cmbUserType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a user type.");
                return;
            }


            try
            {
                using (SqlConnection conn = new SqlConnection(DataBaseManager.functionalityConnectionString))
                {
                    string query = @"
                 INSERT INTO [User] (fn, ln, phone, userName, pwd, newPwd, pwdChnageStatus,uType) 
                 VALUES (@FirstName, @LastName, @Phone, @Username, @Password, 0, 0, @UserType)";

                    var selectedUserType = (dynamic)cmbUserType.SelectedItem;

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@UserType", selectedUserType.Value);
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("User successfully registered.");

                        }
                        else
                        {
                            MessageBox.Show("User registration failed.");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while registering the user: " + ex.Message);
            }
        }

    }
}
