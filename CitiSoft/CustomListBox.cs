using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{

    internal class CustomListBox : Panel
    {

        public CustomListBox() 
        {
            Controls.AddRange(new Control[] { listBox, add, remove, edit, update });
            Size = new System.Drawing.Size(width, height);
        }

        public CustomListBox(TextBox tb)
        {
            Controls.AddRange(new Control[] { listBox, add, remove, edit,update });
            Size = new System.Drawing.Size(width, height);

            add.Click += (sender, e) => Add_Click(tb);
            remove.Click += (sender, e) => Remove_Click(tb);
            update.Click += (sender,e) => Update_Click(tb);
            edit.Click += (sender, e) => Edit_Click(tb);
            
        }

        

        public ListBox listBox = new ListBox() { Size = new System.Drawing.Size(150, 90), Location = new System.Drawing.Point(0,0) };
        public Button add = new Button() { Size = new System.Drawing.Size(100, 28), Location = new System.Drawing.Point(155,0), Text="Add" };
        public Button update = new Button() { Size = new System.Drawing.Size(100, 28), Location = new System.Drawing.Point(155, 0), Text = "Update" , Visible = false };
        public Button remove = new Button() { Size = new System.Drawing.Size(100, 28), Location = new System.Drawing.Point(155,30), Text= "Remove" };
        public Button edit = new Button() { Size = new System.Drawing.Size(100, 28), Location = new System.Drawing.Point(155, 60), Text="Edit"};
        public int height = 90, width = 300;


        public void setHeightWidth(int width, int height)
        {
            Size = new System.Drawing.Size(width, height);
            listBox.Size = new System.Drawing.Size(width - 150, height);
            add.Left = width - 145;
            remove.Left = width - 145;
            edit.Left = width - 145;
            update.Left = width - 145;
        
        }
        public virtual void Remove_Click(TextBox tb)
        {
            int index = listBox.SelectedIndex;
            if (index > -1)
            {
                listBox.Items.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("No Element Selected");
            }
        }
        public void Update_Click(TextBox tb)
        {
            int index = listBox.SelectedIndex;
            if (tb.Text != "" && index > -1)
            {
                listBox.Items.RemoveAt(index);
                listBox.Items.Insert(index, tb.Text);
                tb.Text = null;
            }
            else
            {
                listBox.Items.RemoveAt(index);
            }
            add.Visible = true;
            edit.Visible = true;
            remove.Visible = true;
            update.Visible = false;
            


        }

        public virtual void Edit_Click(TextBox tb)
        {
            int index = listBox.SelectedIndex;
            if (index > -1)
            {
                tb.Text = listBox.SelectedItem.ToString();
                add.Visible = false;
                edit.Visible = false;
                remove.Visible = false;
                update.Visible = true;
            }
            else 
            {
                MessageBox.Show("No Entries Found Or Please Select the Entry.");
            }
        }

        public virtual void Add_Click(TextBox tb)
        {
            
            if (tb.Text != "")
            {
                listBox.Items.Add(tb.Text);
                tb.Text= null;
            }
            else
            {
                MessageBox.Show("Empty TextBox.");
            }
        }

        

    }
}
