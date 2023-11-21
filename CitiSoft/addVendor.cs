using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{
    public class addVenVar 
    {
        public String CompanyName { get; set; }
        public String CompanyEstablished { get; set; }
        public int  Employees { get; set; }
        public bool internalServices { get; set; }
        public String lastDemoDate { get; set; }
        public String lastReviewInt { get; set; }
        public String lastReviewedDate { get; set;}



    }
    public partial class addVendor : Form 
    {

        Label companyNameLabel = new Label();
        TextBox companyNameTextBox = new TextBox();
        
        Label companyEstablishedLabel = new Label();
        TextBox companyEstablishedTextBox = new TextBox();
        
        AddressPanel addressPanel = new AddressPanel();

        Label employeesLabel = new Label();
        TextBox employeesTextBox = new TextBox();

        Label internalServicesLabel = new Label();
        ComboBox internalServicesComboBox = new ComboBox();

        Label lastDemoDateLabel = new Label();
        DateTimePicker lastDemoDatePicker = new DateTimePicker();

        Label lastReviewIntLabel = new Label();
        TextBox lastReviewIntTextBox = new TextBox();

        Label lastReviewedDateLabel = new Label();
        DateTimePicker lastReviewedDatePicker = new DateTimePicker();

        Label docAttachLabel = new Label();
        Button docAttachBrowseButton= new Button();

        Button submitButton = new Button(); 


        public addVendor()
        {
            InitializeComponent();
        }

        void InitializeComponent() 
        {
            AutoScroll = true;
            internalServicesComboBox.Items.Add("Yes");
            internalServicesComboBox.Items.Add("No");
            submitButton.Text = "Submit";

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
                docAttachLabel, docAttachBrowseButton,
                submitButton
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
                "docAttachLabel", "docAttachBrowseButton",
                "submitButton"
            };
            string[] venControlText = new string[]
            {   "Company Name:",
                "Company Established:",
                "No. of Employees:",
                "Internal Professional Services:",
                "Last Demo Date:",
                "Last Reviewe Date Interval:",
                "Last Reviewed Date:",
                "Document to attach?",
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
                    con.Width = venAddWidth + 100;
                    con.Height = venAddHeight + 90;

                    con.Left = venAddxLoc + 210;
                    con.Top = venAddyLoc;
                    venAddyLoc = venAddyLoc + 120;
                }
                else if (con is AddressPanel)
                {
                    con.Left = venAddxLoc;
                    con.Top = venAddyLoc;
                    venAddyLoc = venAddyLoc + 350;
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
            companyNameTextBox.TextChanged += CompanyNameTextBox_TextChanged;
            companyEstablishedTextBox.TextChanged += CompanyEstablishedTextBox_TextChanged;
            employeesTextBox.TextChanged += EmployeesTextBox_TextChanged;
            internalServicesComboBox.SelectedIndexChanged += InternalServicesComboBox_SelectedIndexChanged;
            lastDemoDatePicker.Leave += LastDemoDatePicker_Leave;
            lastReviewIntTextBox.TextChanged += LastReviewIntTextBox_TextChanged;
            lastReviewedDatePicker.Leave += LastReviewedDatePicker_Leave;
                

        }

        private void LastReviewedDatePicker_Leave(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LastReviewIntTextBox_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LastDemoDatePicker_Leave(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void InternalServicesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void EmployeesTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsOnlyAlphanumericWithDash(textBox,15,"Employees Number");
        }



        private void CompanyEstablishedTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsOnlyNumbers(textBox);
        }

        private void CompanyNameTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsOnlyAlphanumericWithDashAt(textBox, 20, "Company Name");
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

