using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

    
namespace CitiSoft
{
    public partial class CitiSoft : Form
    {
        int menuYLoc = 0;
        public CitiSoft()
        {
            
            InitializeComponent();
            tblSelector(2);


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
    }
}