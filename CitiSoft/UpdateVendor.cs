using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CitiSoft
{
    internal class UpdateVendor : Form
    {

        public Label companyNameLabel = new Label();
        public ComboBox companyNameComboBox = new ComboBox();

        public Label companyEstablishedLabel = new Label();
        public TextBox companyEstablishedTextBox = new TextBox();

        public AddressPanel addressPanel = new AddressPanel();

        public Label employeesLabel = new Label();
        public TextBox employeesTextBox = new TextBox();

        public Label internalServicesLabel = new Label();
        public ComboBox internalServicesComboBox = new ComboBox();

        int vid = 0;


        public Button submitButton = new Button();
        public Button cancelButton = new Button();


        public UpdateVendor()
        {
            InitializeComponent();
        }

        public Controller Controller
        {
            get => default;
            set
            {
            }
        }

        internal InputValidation InputValidation
        {
            get => default;
            set
            {
            }
        }

        public AddressPanel AddressPanel
        {
            get => default;
            set
            {
            }
        }

        void InitializeComponent()
        {
            AutoScroll = true;
            internalServicesComboBox.Items.Add("Yes");
            internalServicesComboBox.Items.Add("No");
            internalServicesComboBox.SelectedIndex = 0;

            Controls.AddRange(new Control[]
            {
                companyNameLabel, companyNameComboBox,
                companyEstablishedLabel, companyEstablishedTextBox,
                addressPanel,
                employeesLabel, employeesTextBox,
                internalServicesLabel, internalServicesComboBox,
                submitButton
            });
            string[] venControlVarName = new string[]
            {
                "companyNameLabel", "companyNameComboBox",
                "companyEstablishedLabel", "companyEstablishedTextBox",
                "addressPanel",
                "employeesLabel", "employeesTextBox",
                "internalServicesLabel", "internalServicesComboBox",
                "submitButton"
            };
            string[] venControlText = new string[]
            {   "Company Name:",
                "Company Established:",
                "No. of Employees:",
                "Internal Professional Services:",
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
                else if (con is RichTextBox)
                {
                    con.TabStop = false;
                    con.Width = venAddWidth + 100;
                    con.Height = venAddHeight + 90;

                    con.Left = venAddxLoc + 210;
                    con.Top = venAddyLoc;
                    venAddyLoc = venAddyLoc + 120;
                }
                else if (con is AddressPanel)
                {
                    con.TabStop = false;
                    con.Left = venAddxLoc;
                    con.Top = venAddyLoc;
                    venAddyLoc = venAddyLoc + 350;
                }
                else if (con is TextBox || con is DateTimePicker || con is ComboBox)
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
            companyEstablishedTextBox.TextChanged += CompanyEstablishedTextBox_TextChanged;
            employeesTextBox.TextChanged += EmployeesTextBox_TextChanged;
            internalServicesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            companyNameComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            companyNameComboBox.DataSource = Controller.vendorModelList.Select(vendor => vendor.CompanyName).ToList();
            companyNameComboBox.SelectedIndex = -1;
            companyNameComboBox.Leave += CompNameComboBox_Leave;
            companyNameComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            companyNameComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            companyNameComboBox.SelectedIndexChanged += CompanyNameComboBox_SelectedIndexChanged;
        }


        private void CompanyNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            VendorModel vendorModel= Controller.vendorModelList.FirstOrDefault(vendor => vendor.CompanyName.Equals(companyNameComboBox.SelectedItem.ToString(), StringComparison.OrdinalIgnoreCase));
            companyEstablishedTextBox.Text = vendorModel.CompanyEstablished.ToString();
            employeesTextBox.Text = vendorModel.EmployeesCount;
            if (vendorModel.InternalProfessionalServices)
                internalServicesComboBox.SelectedIndex = 0;
            else internalServicesComboBox.SelectedIndex = 1;


             vid = Controller.vendorModelList
            .Where(v => v.CompanyName.Equals(companyNameComboBox.SelectedItem.ToString(), StringComparison.OrdinalIgnoreCase))
            .Select(v => v.Vid)
            .FirstOrDefault();

            if (vid != 0)
            {
                List<AddressModel> addressModels = Controller.addressModelList.Where(address => address.Vid == vid).ToList();
                addressPanel.addressList = addressModels;
                
            }
            foreach (AddressModel instance in addressPanel.addressList)
            {
                addressPanel.addressCustomListBox.listBox.Items.Add(instance.AddressLine1 + " " + instance.AddressLine2 + " " + instance.City + " " + instance.Country + " " + instance.PostCode + " " + instance.Email + " " + instance.Telephone);
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

        private void EmployeesTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsValid(textBox, 25, "Only Number, Space and dashes", @"^[0-9 -]+$");
        }

        private void CompanyEstablishedTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsValid(textBox, 8, "Only Numbers", @"^[0-9]+$"); ;
        }

      


        public void submitButton_click(object sender, EventArgs e)
        {

            if (!(InputValidation.GetStringValueOrNoneOrWhitespace(companyNameComboBox.Text)).Equals("None"))
            {
                try
                {
                    int vendorIndex= Controller.vendorModelList.FindIndex(vendor => vendor.Vid == vid);
                    VendorModel existingVendor = Controller.vendorModelList.FirstOrDefault(vendor => vendor.Vid == vid);
                    existingVendor.CompanyEstablished = InputValidation.ParseStringToIntOrZero((companyEstablishedTextBox.Text));
                    existingVendor.EmployeesCount = InputValidation.GetStringValueOrNoneOrWhitespace(employeesTextBox.Text);
                    existingVendor.InternalProfessionalServices = InputValidation.ParseTrueOrFalse(internalServicesComboBox.SelectedText);
                    Controller.vendorModelList.RemoveAt(vendorIndex);
                    Controller.vendorModelList.Insert(vendorIndex, existingVendor);
                    foreach (AddressModel address in addressPanel.addressList)
                    {
                        if (!address.addressId.Equals(null))
                        {
                            int index = Controller.addressModelList.FindIndex(inst => inst.addressId == address.addressId);
                            AddressModel instance = Controller.addressModelList.FirstOrDefault(inst => inst.addressId == address.addressId);
                            instance.AddressLine1 = address.AddressLine1;
                            instance.AddressLine2 = address.AddressLine2;
                            instance.City = address.City;
                            instance.Country = address.Country;
                            instance.PostCode = address.PostCode;
                            instance.Email = address.Email;
                            instance.Telephone = address.Telephone;
                            Controller.addressModelList.RemoveAt(index);
                            Controller.addressModelList.Insert(index, instance);
                        }
                        else 
                        {
                            Controller.addressModelList.Add
                        (new AddressModel
                        {
                            addressId=-1,
                            Vid = vid,
                            AddressLine1 = address.AddressLine1,
                            AddressLine2 = address.AddressLine2,
                            City = address.City,
                            Country = address.Country,
                            PostCode = address.PostCode,
                            Email = address.Email,
                            Telephone = address.Telephone,
                        });
                        }
                    }
                    clearAll();
                    //Controller.sendVendorUpdate(Controller.vendorModelList);
                    MessageBox.Show("Vendor Successfully Updated.");

                }
                catch (FormatException fe)
                {
                    MessageBox.Show(fe.Message);
                }
            }
            else
            {
                MessageBox.Show("Company Name is Empty");
            }
        }

        void clearAll()
        {

            foreach (Control con in Controls)
            {
                if (con is TextBox)
                    con.Text = "";
                else if (con is RichTextBox)
                    con.Text = "";
                else if (con is AddressPanel)
                {
                    foreach (Control addCon in addressPanel.Controls)
                    {
                        if (addCon is TextBox)
                            addCon.Text = "";
                    }
                }
            }
            addressPanel.addressList.Clear();
            addressPanel.addressCustomListBox.listBox.Items.Clear();
        }

    }
}
