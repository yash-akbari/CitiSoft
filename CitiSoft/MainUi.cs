using System;
using System.Drawing;
using System.Windows.Forms;

    
namespace CitiSoft
{
    public partial class CitiSoft : Form
    {
        public CitiSoft()
        {
            InitializeComponent();
        }
        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void venSerBtn_Click(object sender, EventArgs e)
        {
            Label l = new Label();
            l.Text = "Logs";
            menuPan.Controls.Add(l);
            l.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            l.Location = new System.Drawing.Point(0, 100);
            l.Name = "softMenu";
            l.Size = new System.Drawing.Size(200, 50);
            l.TabIndex = 1;
            l.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        }

        private void venSerTex_TextChanged(object sender, EventArgs e)
        {

        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            
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
        }

        private void headPan_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void headPan_MouseUp(object sender, MouseEventArgs e)
        {
            
        }
        
    }
}
//Label l = new Label();
//l.Text = "Logs";
//menuPan.Controls.Add(l);
//l.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//l.Location = new System.Drawing.Point(0, 100);
//l.Name = "softMenu";
//l.Size = new System.Drawing.Size(200, 50);
//l.TabIndex = 1;
//l.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;