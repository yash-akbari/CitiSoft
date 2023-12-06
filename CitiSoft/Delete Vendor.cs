using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{
    internal class Delete_Vendor : Form
    {

        public Label companyNameLabel = new Label();
        public ComboBox companyNameComboBox = new ComboBox();
        public Button submitButton = new Button();

        VendorModel existingVendor;

        public Delete_Vendor() 
        {
            initializaComponents();
        }


        void initializaComponents()
        {
            Controls.AddRange(new Control[]
            {
                companyNameLabel, companyNameComboBox,
        
                submitButton
            });
            string[] venControlVarName = new string[]
            {
                "companyNameLabel", "companyNameComboBox",
                "submitButton"
            };
            string[] venControlText = new string[]
            {   "Company Name:",
                "Submit",
            };
            int venAddxLoc = 10;
            int venAddyLoc = 11;
            int venAddHeight = 30;
            int venAddWidth = 200;
            int i = 0, j = 0;
            foreach (Control con in Controls)
            {
                con.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                con.Name = venControlVarName.ElementAt(i++);
                if (con is Label)
                {
                    con.Width = venAddWidth;
                    con.Height = venAddHeight;
                    con.Text = venControlText[j++];
                    con.Left = venAddxLoc;
                    con.Top = venAddyLoc;
                
                }
                else if ( con is ComboBox)
                {
                    con.TabStop = false;
                    con.Width = venAddWidth + 100;
                    con.Height = venAddHeight;

                    con.Left = venAddxLoc + 210;
                    con.Top = venAddyLoc;
                    venAddyLoc = venAddyLoc + 50;
                }
                else
                {
                    con.Width = venAddWidth - 100;
                    con.Height = venAddHeight;
                    con.Left = venAddxLoc + 100;
                    con.Top = venAddyLoc;
                    con.Text = venControlText[j++];
                    venAddxLoc = venAddxLoc + 110;
                }
            }
            submitButton.Click += new EventHandler(submitButton_click);
            companyNameComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            companyNameComboBox.DataSource = Controller.vendorModelList.Select(vendor => vendor.CompanyName).ToList();
            companyNameComboBox.SelectedIndex = -1;
            companyNameComboBox.Leave += CompNameComboBox_Leave;
            companyNameComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            companyNameComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            companyNameComboBox.SelectedIndexChanged += CompanyNameComboBox_SelectedIndexChanged;
        }

        private void CompNameComboBox_Leave(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                if (!Controller.getDeliverVendor().Any(vendor => vendor.CompanyName.Equals(comboBox.Text, StringComparison.OrdinalIgnoreCase)))
                {
                    comboBox.Text = string.Empty;
                }
            }
        }

        private void CompanyNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            existingVendor = Controller.vendorModelList.FirstOrDefault(vendor => vendor.CompanyName.Equals(companyNameComboBox.SelectedItem.ToString(), StringComparison.OrdinalIgnoreCase));
        }

        private void submitButton_click(object sender, EventArgs e)
        {
            int vid = Controller.vendorModelList
           .Where(v => v.CompanyName.Equals(companyNameComboBox.SelectedItem.ToString(), StringComparison.OrdinalIgnoreCase))
           .Select(v => v.Vid)
           .FirstOrDefault();

            int vendorIndex = Controller.vendorModelList.FindIndex(vendor => vendor.Vid == vid);
            existingVendor.Vid = vid;
            existingVendor.CompanyName = null;
            Controller.vendorModelList.RemoveAt(vendorIndex);
            Controller.vendorModelList.Insert(vendorIndex, existingVendor);
            companyNameComboBox.DataSource = Controller.vendorModelList.Select(vendor => vendor.CompanyName).ToList();
        }
    }
}
