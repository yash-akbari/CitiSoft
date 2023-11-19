using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{
    public partial class addVendor : Form 
    {
        Label companyNameLabel = new Label();
        TextBox companyNameTextBox = new TextBox();
        
        Label companyEstablishedLabel = new Label();
        TextBox companyEstablishedTextBox = new TextBox();
        
        Label streetLabel = new Label();
        TextBox streetTextBox = new TextBox();
        Label cityLabel = new Label();
        TextBox cityTextBox = new TextBox();
        Label countryLabel = new Label();
        TextBox countryTextBox = new TextBox();
        Label emailLabel = new Label();
        TextBox emailTextBox = new TextBox();
        Label telephoneLabel = new Label();
        TextBox telephoneTextBox = new TextBox();
        ListBox addressListBox = new ListBox();
        Button addAddressButton = new Button();
        Label employeesLabel = new Label();
        TextBox employeesTextBox = new TextBox();
        Label internalServicesLabel = new Label();
        ComboBox internalServicesComboBox = new ComboBox();
        Label lastDemoDateLabel = new Label();
        DateTimePicker lastDemoDatePicker = new DateTimePicker();
        Label lastReviewIntLabel = new Label();
        TextBox lastReviewIntText = new TextBox();
        Label lastReviewedDateLabel = new Label();
        DateTimePicker lastReviewedDatePicker = new DateTimePicker();
        Label docAttachLabel = new Label();
        ComboBox docAttachComboBox = new ComboBox();
        Button submitButton = new Button(); 


        public addVendor()
        {
            InitializeComponent();
        }

        void InitializeComponent() 
        {
            

            addAddressButton.Text = "Add Address";

            internalServicesComboBox.Items.Add("Yes");
            internalServicesComboBox.Items.Add("No");
            submitButton.Text = "Submit";

            Controls.AddRange(new Control[]
            {
                companyNameLabel, companyNameTextBox,
                companyEstablishedLabel, companyEstablishedTextBox,addressListBox,
                streetLabel,streetTextBox,addAddressButton,
                cityLabel, cityTextBox,
                countryLabel, countryTextBox,
                emailLabel, emailTextBox,
                telephoneLabel, telephoneTextBox,
                employeesLabel, employeesTextBox,
                internalServicesLabel, internalServicesComboBox,
                lastDemoDateLabel, lastDemoDatePicker,
                lastReviewedDateLabel, lastReviewedDatePicker,
                docAttachLabel, docAttachComboBox,
                submitButton
            });
            string[] venControlVarName = new string[]
            {
                "companyNameLabel", "companyNameTextBox",
                "companyEstablishedLabel", "companyEstablishedTextBox", "addressListBox",
                "streetLabel","streetTextBox","addAddressButton" ,
                "cityLabel", "cityTextBox",
                "countryLabel", "countryTextBox",
                "emailLabel", "emailTextBox",
                "telephoneLabel", "telephoneTextBox",
                "employeesLabel", "employeesTextBox",
                "internalServicesLabel", "internalServicesComboBox",
                "lastDemoDateLabel", "lastDemoDatePicker",
                "lastReviewedDateLabel", "lastReviewedDatePicker",
                "docAttachLabel", "docAttachComboBox",
                "submitButton"
            };
            string[] venControlText = new string[]
            {   "Company Name:",
                "Company Established:",
                "Street:",
                "City:",
                "Country:",
                "Email address:",
                "Telephone No.:",
                "No. of Employees:",
                "Internal Professional Services:",
                "Last Demo Date:",
                "Last Reviewed Date:",
                "Document to attach?",
            };
            int venAddxLoc = 10;
            int venAddyLoc = 20;
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
                    con.Width = venAddWidth + 100;
                    con.Height = venAddHeight + 90;

                    con.Left = venAddxLoc + 210;
                    con.Top = venAddyLoc;
                    venAddyLoc = venAddyLoc + 120;
                }
                else if (con is ListBox)
                {
                    con.Width = venAddWidth;
                    con.Height = venAddHeight + 100;

                    con.Left = venAddxLoc + 210 + 100 + 210;
                    con.Top = venAddyLoc;
                    venAddyLoc = venAddyLoc;
                }
                else if (con.Name is "addAddressButton")
                {
                    con.Width = venAddWidth;
                    con.Height = venAddHeight;

                    con.Left = venAddxLoc + 210 + 100 + 210;
                    con.Top = venAddyLoc+90;
                }
                else
                {
                    con.Width = venAddWidth + 100;
                    con.Height = venAddHeight;

                    con.Left = venAddxLoc + 210;
                    con.Top = venAddyLoc;
                    venAddyLoc = venAddyLoc + 50;
                }

            }
            submitButton.Click += new EventHandler(submitButton_click);
            addressListBox.SelectedIndexChanged += new EventHandler(addressListToAddressText);
            addAddressButton.Click += new EventHandler(addAddressButton_click);
        }

        private void addressListToAddressText(object sender, EventArgs e)
        {

        }
        private void addAddressButton_click(object sender, EventArgs e)
        {
            string[] controls = {"streetTextBox",
                "cityTextBox",
                "countryTextBox",
                "emailTextBox",
                "telephoneTextBox"};

            string[] street = new string[20];
            string[] city = new string[20];
            string[] country = new string[20];
            string[] email = new string[20];
            string[] phone = new string[20];
            foreach (Control con in Controls)
            {
                if (con.Name == "streetTextBox")
                    street[street.Length - 1] = con.Text;
                else if (con.Name == "cityTextBox")
                    city[city.Length - 1] = con.Text;
                else if (con.Name == "countryTextBox")
                    country[country.Length - 1] = con.Text;
                else if (con.Name == "emailTextBox")
                    email[email.Length - 1] = con.Text;
                else if (con.Name == "phoneTextBox")
                    phone[phone.Length - 1] = con.Text;
            }

            addressListBox.Items.Add(street[street.Length - 1] + ", " + city[city.Length - 1] + ", " + country[country.Length - 1] + ", " + email[email.Length - 1] + ", " + phone[phone.Length - 1]);

        }
        public void submitButton_click(object sender, EventArgs e)
        {
            // Assuming 'venAdd' contains TextBox controls with appropriate names
            TextBox companyNameTextBox = Controls.Find("companyNameTextBox", true).FirstOrDefault() as TextBox;
            TextBox emailTextBox = Controls.Find("emailTextBox", true).FirstOrDefault() as TextBox;
            TextBox telephoneTextBox = Controls.Find("telephoneTextBox", true).FirstOrDefault() as TextBox;
            // ... other text boxes
            bool isValid = true;

            // Validate company name - must be only letters and spaces, and less than 30 characters
            if (companyNameTextBox != null)
            {
                InputValidation.IsOnlyLettersAndSpaces(companyNameTextBox, 30, "Company Name");
                // No direct way to get the result of the validation, assuming it shows a MessageBox and handles the correction internally
            }

            // Validate email - since IsValidEmail returns a bool, you can use it to set the isValid flag
            if (emailTextBox != null && !InputValidation.IsValidEmail(emailTextBox.Text))
            {
                MessageBox.Show("The email format is invalid.");
                isValid = false;
            }
            // Validate telephone - structured phone number
            if (telephoneTextBox != null)
            {
                InputValidation.IsPhoneNumberStructured(telephoneTextBox, 15, "Phone Number");
                // No direct way to get the result of the validation, assuming it shows a MessageBox and handles the correction internally
            }

            if (isValid)
            {
                // Proceed with submitting the data
                string[] data = new string[50];
                int i = 0;
                foreach (Control con in Controls)
                {
                    if (con is TextBox || con is RichTextBox) // Ensure only text-based controls are included
                    {
                        data[i] = con.Text;
                        i++;
                    }
                }
                // ... submit data
            }
            else
            {
                // Handle the case where validation fails
                MessageBox.Show("Please correct the highlighted errors before submitting.");
            }

        }

    }



}

