using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{
    internal class DeleteSoftware : Form
    {
        Label compNameLabel = new Label();
        ComboBox compNameComboBox = new ComboBox();

        Label softwareNameLabel = new Label();
        ComboBox softwareNameComboBox = new ComboBox();
        Button deleteButton = new Button();
        SoftwareModel existingSoftware;
        int sid =0, vid = 0;

        public DeleteSoftware() 
        { 
            init();
        }
        void init() 
        {
            Controls.AddRange(new Control[] {
                compNameLabel, compNameComboBox,
                softwareNameLabel, softwareNameComboBox,
                deleteButton
                });
            string[] softControlVarName = new string[] {
                "compNameLabel","compNameComboBox",
                "softwareNameLabel", "softwareNameComboBox",
                "deleteButton"
            };
            string[] softControlText = new string[]
            {
                "Comapany Name:",
                "Software Name:",
                "Delete"
            };

            int softAddxLoc = 10;
            int softAddyLoc = 11;
            int softAddHeight = 30;
            int softAddWidth = 200;
            int i = 0, j = 0;
            foreach (Control con in Controls)
            {
                con.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                con.Name = softControlVarName.ElementAt(i++);
                if (con is Label)
                {
                    con.Width = softAddWidth;
                    con.Height = softAddHeight;
                    con.Text = softControlText[j++];
                    con.Left = softAddxLoc;
                    con.Top = softAddyLoc;
                }

                

                else if ( con is ComboBox)
                {
                    con.Width = softAddWidth + 100;
                    con.Height = softAddHeight;

                    con.Left = softAddxLoc + 210;
                    con.Top = softAddyLoc;
                    softAddyLoc = softAddyLoc + 50;
                }
                else if (con is Button)
                {

                    con.Width = softAddWidth - 100;
                    con.Height = softAddHeight;
                    con.Left = softAddxLoc + 100;
                    con.Top = softAddyLoc;
                    con.Text = softControlText[j++];
                    softAddxLoc = softAddxLoc + 110;
                }

            }

            deleteButton.Click += SubmitButton_Click;





            compNameComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            compNameComboBox.DataSource = Controller.vendorModelList.Select(vendor => vendor.CompanyName).ToList();
            compNameComboBox.SelectedIndex = -1;
            compNameComboBox.Leave += CompNameComboBox_Leave;
            compNameComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            compNameComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            compNameComboBox.SelectedIndexChanged += CompNameComboBox_SelectedIndexChanged;


            softwareNameComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            //softwareNameComboBox.DataSource = Controller..Select(software => software.SoftwareName).ToList();
            softwareNameComboBox.SelectedIndex = -1;
            softwareNameComboBox.Leave += SoftwareNameComboBox_Leave;
            softwareNameComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            softwareNameComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            softwareNameComboBox.SelectedIndexChanged += SoftwareNameComboBox_SelectedIndexChanged;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            existingSoftware.SoftwareId = sid;
            existingSoftware.SoftwareName = null;
            int softwareIndex = Controller.softwareModelList.FindIndex(software => software.SoftwareId == sid);
            compNameComboBox.DataSource = Controller.vendorModelList.Select(vendor => vendor.CompanyName).ToList();
            Controller.softwareModelList.RemoveAt(softwareIndex);
            Controller.softwareModelList.Insert(softwareIndex, existingSoftware);


        }

        private void CompNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (compNameComboBox.SelectedIndex >= -1)
            {
                vid = Controller.vendorModelList.Where(vendor => vendor.CompanyName.Equals(compNameComboBox.SelectedItem.ToString(), StringComparison.OrdinalIgnoreCase)).Select(vendor => vendor.Vid).FirstOrDefault();

                if (vid != 0)
                {
                    softwareNameComboBox.DataSource = Controller.softwareModelList.Where(software => software.Vid == vid).Select(software => software.SoftwareName).ToList();
                }
            }
        }
       
        private void SoftwareNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            existingSoftware = Controller.softwareModelList.FirstOrDefault(software => software.SoftwareName.Equals(softwareNameComboBox.SelectedItem.ToString()));
            sid = existingSoftware.SoftwareId;
        
        }


        private void SoftwareNameComboBox_Leave(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {

                if (!Controller.getDeliverSoftware(vid).Any(vendor => vendor.SoftwareName.Equals(comboBox.Text, StringComparison.OrdinalIgnoreCase)))
                {
                    comboBox.Text = string.Empty;
                }
            }
        }

        private static void CompNameComboBox_Leave(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {

                if (!Controller.getDeliverVendor().Any(vendor => vendor.CompanyName.Equals(comboBox.Text, StringComparison.OrdinalIgnoreCase)))
                {
                    comboBox.Text = string.Empty;
                }
            }
        }
    }

}

