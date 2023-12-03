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

        public Label lastDemoDateLabel = new Label();
        public DateTimePicker lastDemoDatePicker = new DateTimePicker();

        public Label lastReviewIntLabel = new Label();
        public TextBox lastReviewIntTextBox = new TextBox();

        public Label lastReviewedDateLabel = new Label();
        public DateTimePicker lastReviewedDatePicker = new DateTimePicker();


        public Button submitButton = new Button();
        public Button clearButton = new Button();

        // Events for CRUD operations
        public event EventHandler InsertVendor;
        public event EventHandler UpdateVendor;
        public event EventHandler DeleteVendor;


        public AddVendor()
        {
            InitializeComponent();
        }

        void InitializeComponent() 
        {
            AutoScroll = true;
            internalServicesComboBox.Items.Add("Yes");
            internalServicesComboBox.Items.Add("No");

            Controls.AddRange(new Control[]
            {
                companyNameLabel, companyNameTextBox,
                companyEstablishedLabel, companyEstablishedTextBox,
                addressPanel,
                employeesLabel, employeesTextBox,
                internalServicesLabel, internalServicesComboBox,
                lastDemoDateLabel, lastDemoDatePicker,
                lastReviewIntLabel,lastReviewIntTextBox,
                lastReviewedDateLabel, lastReviewedDatePicker,               
                submitButton, clearButton
            });
            string[] venControlVarName = new string[]
            {
                "companyNameLabel", "companyNameTextBox",
                "companyEstablishedLabel", "companyEstablishedTextBox",
                "addressPanel",
                "employeesLabel", "employeesTextBox",
                "internalServicesLabel", "internalServicesComboBox",
                "lastDemoDateLabel", "lastDemoDatePicker",
                "lastReviewIntLabel","lastReviewIntTextBox",
                "lastReviewedDateLabel", "lastReviewedDatePicker",
                "submitButton", "clearButton"
            };
            string[] venControlText = new string[]
            {   "Company Name:",
                "Company Established:",
                "No. of Employees:",
                "Internal Professional Services:",
                "Last Demo Date:",
                "Last Reviewe Date Interval:",
                "Last Reviewed Date:",
                "Submit",
                "Clear"
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
                    con.Width = venAddWidth -100;
                    con.Height = venAddHeight;
                    con.Left = venAddxLoc + 100;
                    con.Top = venAddyLoc;
                    con.Text = venControlText[j++];
                    venAddxLoc = venAddxLoc + 110;
                }
            }
            submitButton.Click += new EventHandler(submitButton_click);
            clearButton.Click += ClearButton_Click;
            companyNameTextBox.TextChanged += CompanyNameTextBox_TextChanged;
            companyEstablishedTextBox.TextChanged += CompanyEstablishedTextBox_TextChanged;
            employeesTextBox.TextChanged += EmployeesTextBox_TextChanged;
            lastReviewIntTextBox.TextChanged += LastReviewIntTextBox_TextChanged;
            internalServicesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void LastReviewIntTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsValid(textBox, 3, "Only Numbers", @"^[0-9]+$"); ;
        }

        private void EmployeesTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsValid(textBox, 25, "Only Number, Space and dashes", @"^[0-9 -]+$");
        }

        private void CompanyEstablishedTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsValid(textBox,8, "Only Numbers", @"^[0-9]+$"); ;
        }

        private void CompanyNameTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsValid(textBox,20,"Only AlphabetsNumbers, at(@) and Spaces", @"^[a-zA-Z\d\s]*$");//@"^[a-zA-Z0-9\s]+$"
        }

        
        public void submitButton_click(object sender, EventArgs e)
        {
            Random rand= new Random();
            int random = rand.Next(int.MinValue, 0);
            if (!(InputValidation.GetStringValueOrNullOrWhitespace(companyNameTextBox.Text)).Equals("None"))
            { 
                try
                {
                    Controller.vendorModelList.Add(new VendorModel
                    {
                        Vid = random,
                        CompanyName = companyNameTextBox.Text,
                        CompanyEstablished = InputValidation.ParseStringToIntOrZero((companyEstablishedTextBox.Text)),
                        EmployeesCount = InputValidation.GetStringValueOrNullOrWhitespace(employeesTextBox.Text),
                        InternalProfessionalServices = Convert.ToBoolean(internalServicesComboBox.SelectedValue),                        
                    });
                    MessageBox.Show(InputValidation.GetStringValueOrNullOrWhitespace(employeesTextBox.Text));
                    foreach (AddressModel address in addressPanel.addressList)
                    {
                        Controller.addressModelList.Add
                        (new AddressModel
                        {
                            Vid = -1,
                            addressId = random,
                            AddressLine1 = address.AddressLine1,
                            AddressLine2 = address.AddressLine2,
                            City = address.City,
                            Country = address.Country,
                            PostCode = address.PostCode,
                            Email = address.Email,
                            Telephone = address.Telephone,
                        });
                    }
                    clearAll();
                    Controller.sendVendorUpdate(Controller.vendorModelList);
                    //ViewDataByVendor viewDataByVendor = new ViewDataByVendor(1); 
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

