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
            this.Dock = DockStyle.Fill;

        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            ForgotPasswordForm forgotPasswordForm = new ForgotPasswordForm(); // Assuming you have a form for this
            forgotPasswordForm.ShowDialog();
        }
    }
}
