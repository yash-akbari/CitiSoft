using System;
using System.Collections.Generic;
using System.Linq;
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

        public Label docAttachLabel = new Label();
        public Button docAttachBrowseButton= new Button();

        public Button submitButton = new Button();

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
            lastReviewIntTextBox.TextChanged += LastReviewIntTextBox_TextChanged;
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
        }

    }



}

