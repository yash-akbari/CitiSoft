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
    public partial class ReminderForm : Form
    {

        public ReminderForm()
        {
            InitializeComponent();
        }
        public string Message { get; private set; }
        public DateTime Date { get; private set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Message = txtMessage.Text;
            Date = dtpDate.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


    }
}
