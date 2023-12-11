using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{

    public partial class AddVendor : Form
    {

        public Label companyNameLabel = new Label();
        public TextBox companyNameTextBox = new TextBox();

        public Label companyEstablishedLabel = new Label();
        public TextBox companyEstablishedTextBox = new TextBox();

        public AddressPanel addressPanel = new AddressPanel();

        public Label employeesLabel = new Label();
        public TextBox employeesTextBox = new TextBox();

        public Label internalServicesLabel = new Label();
        public ComboBox internalServicesComboBox = new ComboBox();



        public Button submitButton = new Button();
        public Button clearButton = new Button();


        public AddVendor()
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
            this.SuspendLayout();
            // 
            // AddVendor
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "AddVendor";
            this.ResumeLayout(false);

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            clearAll();
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

        private void CompanyNameTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsValid(textBox, 20, "Only AlphabetsNumbers, at(@) and Spaces", @"^[a-zA-Z\d\s]*$");//@"^[a-zA-Z0-9\s]+$"
        }


        public void submitButton_click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int random = rand.Next(int.MinValue, 0);
            if (!(InputValidation.GetStringValueOrNoneOrWhitespace(companyNameTextBox.Text)).Equals("None"))
            {
                try
                {
                    Controller.vendorModelList.Add(new VendorModel
                    {
                        Vid = random,
                        CompanyName = companyNameTextBox.Text,
                        CompanyEstablished = InputValidation.ParseStringToIntOrZero((companyEstablishedTextBox.Text)),
                        EmployeesCount = InputValidation.GetStringValueOrNoneOrWhitespace(employeesTextBox.Text),
                        InternalProfessionalServices = InputValidation.ParseTrueOrFalse(internalServicesComboBox.SelectedText),
                        Operation = 'I'
                    });
                    foreach (AddressModel address in addressPanel.addressList)
                    {
                        Controller.addressModelList.Add
                        (new AddressModel
                        {
                            AddressId = random,
                            AddressLine1 = address.AddressLine1,
                            AddressLine2 = address.AddressLine2,
                            City = address.City,
                            Country = address.Country,
                            PostCode = address.PostCode,
                            Email = address.Email,
                            Telephone = address.Telephone,
                            Operation = 'I'
                        });
                    }
                    clearAll();
                    //Controller.sendVendorUpdate(Controller.vendorModelList);
                    MessageBox.Show("Vendor Successfully added.");
                    new ViewDataByVendor(1);

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

