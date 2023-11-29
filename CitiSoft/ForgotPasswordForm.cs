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
    public partial class ForgotPasswordForm : Form
    {
        private TextBox emailTextBox;
        private Button submitButton;
        private Label instructionLabel;

        public ForgotPasswordForm()
        {
            InitializeComponent();
            //no maximize buttonm
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void InitializeComponent()
        {
            this.emailTextBox = new TextBox();
            this.submitButton = new Button();
            this.instructionLabel = new Label();

            // emailTextBox
            this.emailTextBox.Location = new Point(10, 50); // Adjust these values as needed
            this.emailTextBox.Size = new Size(200, 20);
            this.emailTextBox.Enter += EmailTextBox_Enter;
            this.emailTextBox.Leave += EmailTextBox_Leave;

            // submitButton
            this.submitButton.Location = new Point(10, 80); // Adjust these values as needed
            this.submitButton.Size = new Size(200, 30);
            this.submitButton.Text = "Submit";
            this.submitButton.Click += new EventHandler(SubmitButton_Click);

            // instructionLabel
            this.instructionLabel.Location = new Point(10, 20); // Adjust these values as needed
            this.instructionLabel.Size = new Size(200, 20);
            this.instructionLabel.Text = "Please enter your email address:";

            // ForgotPasswordForm
            this.ClientSize = new Size(220, 120); // Adjust these values as needed
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.instructionLabel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Forgot Password";
        }

        private void EmailTextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "Enter your email here")
            {
                textBox.Text = "";
                textBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void EmailTextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Enter your email here";
                textBox.ForeColor = SystemColors.GrayText;
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string email = emailTextBox.Text;
            if (InputValidation.IsValidEmail(email))
            {
                // Implement your password recovery logic here.
                // For now, we'll just show a message box.
                MessageBox.Show("A password reset link has been sent to: " + email, "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Optionally close the form after submission.
            }
            else
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
