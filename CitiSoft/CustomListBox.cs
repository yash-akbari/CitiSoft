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
        public Button add = new Button() { Size = new System.Drawing.Size(100, 25), Location = new System.Drawing.Point(155,2), Text="Add" };
        public Button remove = new Button() { Size = new System.Drawing.Size(100, 25), Location = new System.Drawing.Point(155,32), Text= "Remove" };
        public Button clear = new Button() { Size = new System.Drawing.Size(100, 25), Location = new System.Drawing.Point(155, 62), Text= "Clear" };

        void InitializeComponent() 
        {
            Controls.AddRange(new Control[] {listBox,add,remove,clear});
            Size = new System.Drawing.Size(300, 90);
            
        }

    }
}
