using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{
    internal class CustomListBox : Panel
    {

        public CustomListBox()
        {
            InitializeComponent ();
        }
        
        public ListBox listBox = new ListBox() { Size = new System.Drawing.Size(150, 90), Location = new System.Drawing.Point(0,0) };
        public Button add = new Button() { Size = new System.Drawing.Size(100, 28), Location = new System.Drawing.Point(155,0), Text="Add" };
        public Button remove = new Button() { Size = new System.Drawing.Size(100, 28), Location = new System.Drawing.Point(155,30), Text= "Remove" };
        public Button reset = new Button() { Size = new System.Drawing.Size(100, 28), Location = new System.Drawing.Point(155, 60), Text= "Reset" };
        public Button update = new Button() { Size = new System.Drawing.Size(100, 28), Location = new System.Drawing.Point(155, 0), Text="Update", Visible=false };
        public int height = 90, width = 300;
        void InitializeComponent() 
        {
            Controls.AddRange(new Control[] {listBox,add,remove,reset,update});
            Size = new System.Drawing.Size(width, height);
        }

        public void setHeightWidth(int width, int height)
        {
            Size = new System.Drawing.Size(width, height);
            listBox.Size=new System.Drawing.Size(width-150, height);
            add.Left = width - 145;
            remove.Left = width - 145;
            reset.Left = width - 145;
            update.Left = width - 145;
        }

    }
}
