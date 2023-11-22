using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

    
namespace CitiSoft
{
    public partial class MainUI : Form
    {
        
        public MainUI()
        {
            
            InitializeComponent();

            //reminderTimer.Interval = 60000; // Check every minute
            //reminderTimer.Tick += ReminderTimer_Tick;
            //reminderTimer.Start();


        }
        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessge(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void maximizeBtn_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void headPan_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessge(this.Handle, 0x112, 0xf012, 0);
        }


        private void mainPan_Paint(object sender, PaintEventArgs e)
        {

        }

        private List<Reminder> reminders = new List<Reminder>();

        private void btnAddReminder_Click(object sender, EventArgs e)
        {
            ReminderForm reminderForm = new ReminderForm();
            if (reminderForm.ShowDialog() == DialogResult.OK)
            {
                reminders.Add(new Reminder { Message = reminderForm.Message, Date = reminderForm.Date });
                venVieData.DataSource = null;
                venVieData.DataSource = reminders;
            }
        }
        private void ReminderTimer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            foreach (var reminder in reminders)
            {
                if (reminder.Date <= now)
                {
                    MessageBox.Show("Reminder: " + reminder.Message);
                    reminders.Remove(reminder);
                    venVieData.DataSource = null;
                    venVieData.DataSource = reminders;
                    break; // Only show one reminder per tick
                }
            }
        }
    }
}