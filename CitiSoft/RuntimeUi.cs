using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CitiSoft
{
    public partial class RuntimeUI : MainUI
    {

        private Label setMenu = new Label();
        private Label venMenu = new Label();
        private Label softMenu = new Label();
        private Label notiMenu = new Label();
        private TabControl venTab = new TabControl();
        private TabPage venView = new TabPage();
        private TabPage venSearch = new TabPage();
        private TabPage venAdd = new TabPage();
        private TabPage venRemind = new TabPage();
        private TabPage venProblemHistory = new TabPage();

        private TabPage venModifyClient = new TabPage();
        private ComboBox venFilCombo = new ComboBox();
        private Button venSerBtn = new Button();
        private TextBox venSerTex = new TextBox();
        private Panel venPan = new Panel();
        private Panel userProfilePanel;


        int menuYLoc = 0;


        public void setMenuFunc()
        {//Settings Menu
            setMenu.Text = "Settings";
            menuPan.Controls.Add(setMenu);
            setMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            setMenu.Location = new System.Drawing.Point(0, menuYLoc);
            menuYLoc = menuYLoc + 50;
            setMenu.Size = new System.Drawing.Size(200, 50);
            setMenu.TabIndex = 1;
            setMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        }
        public void venMenuFunc()
        {// Vendor Menu
            venMenu.Text = "Vendor";
            menuPan.Controls.Add(venMenu);
            venMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            venMenu.Location = new System.Drawing.Point(0, menuYLoc);
            menuYLoc = menuYLoc + 50;
            venMenu.Size = new System.Drawing.Size(200, 50);
            venMenu.TabIndex = 1;
            venMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            venMenu.Click += venMenu_Click;

        }

        private void venMenu_Click(object sender, EventArgs e)
        {
            panSelector("venPan");
        }
        public void panSelector(String panName) 
        {
            foreach (Control con in mainPan.Controls) //will iterate through each controls added in mainPan
            {
                if (con.Name == panName)
                {
                    con.Visible = true;
                }
                else
                {
                    con.Visible = false;
                }
            }
        }

        /*private void VenMenu_Click(object sender, EventArgs e)
{
   // Hide the user profile panel and any other panels
   userProfilePanel.Visible = false;
   // ... hide other panels

   // Show the "Vendor" panel
   venPan.Visible = true;
   // ... show other controls related to "Vendor"
}*/

        private void UserProfileMenuFunc()
        {
            // Create the User Profile menu label
            var userProfileMenu = new Label
            {
                Text = "User Profile",
                Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(0, menuYLoc),
                Size = new Size(200, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };
            userProfileMenu.Click += UserProfileMenu_Click; // Event handler for click action
            menuPan.Controls.Add(userProfileMenu);
            menuYLoc += 50; // Update the location for the next menu item
        }
        private void UserProfileMenu_Click(object sender, EventArgs e)
        {
            panSelector("userProfileMenu");
        }


        public void softMenuFunc()
        {//Software Menu
            softMenu.Text = "Software";
            menuPan.Controls.Add(softMenu);
            softMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            softMenu.Location = new System.Drawing.Point(0, menuYLoc);
            menuYLoc = menuYLoc + 50;
            softMenu.Size = new System.Drawing.Size(200, 50);
            softMenu.TabIndex = 1;
            softMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        }
        
        public void notiMenuFunc()
        {//notification Menu
            
            notiMenu.Text = "Notifications";
            menuPan.Controls.Add(notiMenu);
            notiMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            notiMenu.Location = new System.Drawing.Point(0, menuYLoc);
            menuYLoc = menuYLoc + 50;
            notiMenu.Size = new System.Drawing.Size(200, 50);
            notiMenu.TabIndex = 1;
            notiMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        }
        public void venPanFunc() 
        {

            venPan.Dock = System.Windows.Forms.DockStyle.Fill;
           // venPan.Location = new System.Drawing.Point(0, 0);
            venPan.Name = "venPan";
            venPan.Size = new System.Drawing.Size(618, 692);
            venPan.TabIndex = 2;
        }
        public void venTabFunc()
        {   // 
            // venTab
            //
            venTab.Dock = System.Windows.Forms.DockStyle.Fill;
            venTab.BackColor = System.Drawing.Color.Red;
            //venTab.Location = new System.Drawing.Point(202, 128);
            venTab.Name = "venTab";
            venTab.SelectedIndex = 0;
            venTab.Size = new System.Drawing.Size(618, 692);
            venTab.TabIndex = 2;
        }

        public void venViewFunc()
        {
            // 
            // venView
            // 
            
            venView.Controls.Add(venViewData);
            venView.Location = new System.Drawing.Point(4, 22);
            venView.Name = "venView";
            venView.Padding = new System.Windows.Forms.Padding(3);
            venView.Size = new System.Drawing.Size(610, 666);
            venView.TabIndex = 0;
            venView.Text = "View";
            venView.UseVisualStyleBackColor = true;

            venTab.Controls.Add(venView);

            // 
            // venViewData
            // 
            venViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            venViewData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            venViewData.Location = new System.Drawing.Point(3, 3);
            venViewData.Name = "venVieData";
            venViewData.Size = new System.Drawing.Size(604, 660);
            venViewData.TabIndex = 0;
        }
        public void venSearchFunc()
        {
            // 
            // venSearch
            // 
            venSearch.Controls.Add(venSerData);
            venSearch.Controls.Add(venFilCombo);
            venSearch.Controls.Add(venSerBtn);
            venSearch.Controls.Add(venSerTex);
            venSearch.Location = new System.Drawing.Point(4, 22);
            venSearch.Name = "venSearch";
            venSearch.Padding = new System.Windows.Forms.Padding(3);
            venSearch.Size = new System.Drawing.Size(610, 666);
            venSearch.TabIndex = 1;
            venSearch.Text = "Search";
            venSearch.UseVisualStyleBackColor = true;

            venTab.Controls.Add(venSearch);

            // 
            // venSerData
            // 

            venSerData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            venSerData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            venSerData.Location = new System.Drawing.Point(0, 34);
            venSerData.Name = "venSerData";
            venSerData.Size = new System.Drawing.Size(610, 632);
            venSerData.TabIndex = 1;
            // 
            // venFilCombo
            // 
            
            venFilCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            venFilCombo.FormattingEnabled = true;
            venFilCombo.ImeMode = System.Windows.Forms.ImeMode.Off;
            venFilCombo.Location = new System.Drawing.Point(418, 5);
            venFilCombo.MaximumSize = new System.Drawing.Size(100, 0);
            venFilCombo.MinimumSize = new System.Drawing.Size(100, 0);
            venFilCombo.Name = "venFilCombo";
            venFilCombo.Size = new System.Drawing.Size(100, 23);
            venFilCombo.TabIndex = 2;
            // 
            // venSerBtn
            // 
            
            venSerBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            venSerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            venSerBtn.Location = new System.Drawing.Point(524, 5);
            venSerBtn.MaximumSize = new System.Drawing.Size(82, 23);
            venSerBtn.MinimumSize = new System.Drawing.Size(82, 23);
            venSerBtn.Name = "venSerBtn";
            venSerBtn.Size = new System.Drawing.Size(82, 23);
            venSerBtn.TabIndex = 1;
            venSerBtn.Text = "Search";
            venSerBtn.UseVisualStyleBackColor = true;
            // 
            // venSerTex
            //
            venSerTex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            venSerTex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            venSerTex.Location = new System.Drawing.Point(4, 5);
            venSerTex.MaximumSize = new System.Drawing.Size(520, 24);
            venSerTex.MinimumSize = new System.Drawing.Size(409, 24);
            venSerTex.Name = "venSerTex";
            venSerTex.Size = new System.Drawing.Size(409, 23);
            venSerTex.TabIndex = 0;
        }

        public void venReminderFunc()
        {
            // 
            // venRemind
            // 

            venRemind.Location = new System.Drawing.Point(4, 22);
            venRemind.Name = "venRemind";
            venRemind.Padding = new System.Windows.Forms.Padding(3);
            venRemind.Size = new System.Drawing.Size(610, 666);
            venRemind.TabIndex = 0;
            venRemind.Text = "Remind";
            venRemind.UseVisualStyleBackColor = true;
            venRemind.Controls.Add(venRemData);
            venTab.Controls.Add(venRemind);

            // 
            // venRemData
            // 
            
            venRemData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            venRemData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            venRemData.Location = new System.Drawing.Point(3, 3);
            venRemData.Name = "venRemData";
            venRemData.Size = new System.Drawing.Size(604, 660);
            venRemData.TabIndex = 0;

            dataBinding(Variables.citiSoftDatabaseConnectionString, "SELECT VendorInfo.compName AS 'Company Name', VendorInfo.lstDemoDt AS 'Last Demo Date', VendorInfo.lstRevInt AS 'Last Review Interval', VendorInfo.lstRevDt AS 'Last Reviewed Date' FROM VendorInfo", venRemData);
        }

        public void venProblemHistoryFunc()
        {
            venProblemHistory.Location = new System.Drawing.Point(4, 22);
            venProblemHistory.Name = "venProblemHistory";
            venProblemHistory.Padding = new System.Windows.Forms.Padding(3);
            venProblemHistory.Size = new System.Drawing.Size(610, 666);
            venProblemHistory.TabIndex = 0;
            venProblemHistory.Text = "Client Problem History";
            venProblemHistory.UseVisualStyleBackColor = true;
            venTab.Controls.Add(venProblemHistory);
           
            ProblemHistoryForm problemHistoryForm = new ProblemHistoryForm();
            AddForm(problemHistoryForm, venProblemHistory);
        }

        // takes database name, query and DataGridView instance to display a table. Also takes optional argument,
        // which enables to display a particular row
        public static void dataBinding(string connectionString, string baseQuery, DataGridView table, int? id = null, string idName = null)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(baseQuery, connection);

                    // Modify the query and add parameter if 'id' is provided
                    if (id.HasValue && idName != null)
                    {
                        command.CommandText += $" WHERE {idName} = @Id";
                        command.Parameters.AddWithValue("@Id", id.Value);
                    }

                    DataTable table1 = new DataTable();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table1);
                    }

                    if (id.HasValue && table1.Rows.Count == 0)
                    {
                        // Handle the case where no data is found for the provided id
                        MessageBox.Show($"No data found for ID: {id.Value}");
                    }
                    else
                    {
                        DataTable mergedTable = new DataTable();
                        mergedTable.Merge(table1);

                        table.DataSource = mergedTable;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL-specific errors here
                MessageBox.Show("SQL Error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                // Handle other types of errors here
                MessageBox.Show("General Error: " + ex.Message);
            }
        }

        public void venAddFunc()
        {
            venAdd = new TabPage
            {
                Location = new System.Drawing.Point(4, 22),
                Name = "venAdd",
                Padding = new System.Windows.Forms.Padding(3),
                Size = new System.Drawing.Size(610, 666),
                TabIndex = 0,
                Text = "Add",
                UseVisualStyleBackColor = true,
            };

            venTab.Controls.Add(venAdd);

            Label companyNameLabel = new Label();
            TextBox companyNameTextBox = new TextBox();

            Label softwareNameLabel = new Label();
            TextBox softwareNameTextBox = new TextBox();

            Label companyWebsiteLabel = new Label();
            TextBox companyWebsiteTextBox = new TextBox();

            Label typeOfSoftwareLabel = new Label();
            TextBox typeOfSoftwareTextBox = new TextBox();

            Label companyEstablishedLabel = new Label();
            TextBox companyEstablishedTextBox = new TextBox();

            Label descriptionLabel = new Label();
            RichTextBox descriptionRichTextBox = new RichTextBox();

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
            addAddressButton.Text = "Add Address";

            Label employeesLabel = new Label();
            TextBox employeesTextBox = new TextBox();

            Label internalServicesLabel = new Label();
            ComboBox internalServicesCheckBox = new ComboBox();
            internalServicesCheckBox.Items.Add("Yes");
            internalServicesCheckBox.Items.Add("No");


            Label lastDemoDateLabel = new Label();
            DateTimePicker lastDemoDatePicker = new DateTimePicker();


            Label lastReviewIntLabel = new Label();
            TextBox lastReviewIntText = new TextBox();

            Label lastReviewedDateLabel = new Label();
            DateTimePicker lastReviewedDatePicker = new DateTimePicker();

            Label businessAreasLabel = new Label();
            TextBox businessAreasTextBox = new TextBox();

            Label modulesLabel = new Label();
            TextBox modulesTextBox = new TextBox();

            Label financialServicesLabel = new Label();
            TextBox financialServicesTextBox = new TextBox();

            Label cloudLabel = new Label();
            ComboBox cloudComboBox = new ComboBox();

            Label additionalInfoLabel = new Label();
            RichTextBox additionalInfoRichTextBox = new RichTextBox();

            Label docAttachLabel = new Label();
            ComboBox docAttachCheckBox = new ComboBox();


            Button submitButton = new Button();
            submitButton.Text = "Submit";

            venAdd.Controls.AddRange(new Control[]
            {
                companyNameLabel, companyNameTextBox,
                softwareNameLabel, softwareNameTextBox,
                companyWebsiteLabel, companyWebsiteTextBox,
                typeOfSoftwareLabel, typeOfSoftwareTextBox,
                companyEstablishedLabel, companyEstablishedTextBox,
                descriptionLabel, descriptionRichTextBox,addressListBox,
                streetLabel,streetTextBox,addAddressButton,
                cityLabel, cityTextBox,
                countryLabel, countryTextBox,
                emailLabel, emailTextBox,
                telephoneLabel, telephoneTextBox,
                employeesLabel, employeesTextBox,
                internalServicesLabel, internalServicesCheckBox,
                lastDemoDateLabel, lastDemoDatePicker,
                lastReviewedDateLabel, lastReviewedDatePicker,
                businessAreasLabel, businessAreasTextBox,
                modulesLabel, modulesTextBox,
                financialServicesLabel, financialServicesTextBox,
                cloudLabel, cloudComboBox,
                additionalInfoLabel, additionalInfoRichTextBox,
                docAttachLabel, docAttachCheckBox,
                submitButton
            });
            string[] venControlVarName = new string[]
            {
                "companyNameLabel", "companyNameTextBox",
                "softwareNameLabel", "softwareNameTextBox",
                "companyWebsiteLabel", "companyWebsiteTextBox",
                "typeOfSoftwareLabel", "typeOfSoftwareTextBox",
                "companyEstablishedLabel", "companyEstablishedTextBox",
                "descriptionLabel", "descriptionRichTextBox", "addressListBox",
                "streetLabel","streetTextBox","addAddressButton" ,
                "cityLabel", "cityTextBox",
                "countryLabel", "countryTextBox",
                "emailLabel", "emailTextBox",
                "telephoneLabel", "telephoneTextBox",
                "employeesLabel", "employeesTextBox",
                "internalServicesLabel", "internalServicesCheckBox",
                "lastDemoDateLabel", "lastDemoDatePicker",
                "lastReviewedDateLabel", "lastReviewedDatePicker",
                "businessAreasLabel", "businessAreasTextBox",
                "modulesLabel", "modulesTextBox",
                "financialServicesLabel", "financialServicesTextBox",
                "cloudLabel", "cloudComboBox",
                "additionalInfoLabel", "additionalInfoRichTextBox",
                "docAttachLabel", "docAttachCheckBox",
                "submitButton"
            };
            string[] venControlText = new string[]
            {   "Company Name:",
                "Software Name:",
                "Company Website:",
                "Type of Software:",
                "Company Established:",
                "Description:",
                "Street:",
                "City:",
                "Country:",
                "Email address:",
                " Telephone No.:",
                "No. of Employees:",
                "Internal Professional Services:",
                "Last Demo Date:",
                "Last Reviewed Date:",
                "Business Areas:",
                "Modules:",
                "Financial Services Client Types:",
                "Cloud (Enabled/Native/Based):",
                "Additional Information:",
                "Document to attach?",
            };
            int venAddxLoc = 10;
            int venAddyLoc = 11;
            int venAddHeight = 21;
            int venAddWidth = 200;
            int i = 0, j = 0;
            foreach (Control con in venAdd.Controls)
            {
                con.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
                else if (con is ListBox || con.Name is "addAddressButton")
                {
                    con.Width = venAddWidth;
                    con.Height = venAddHeight;

                    con.Left = venAddxLoc + 210 + 100 + 210;
                    con.Top = venAddyLoc;

                }
                else
                {
                    con.Width = venAddWidth + 100;
                    con.Height = venAddHeight;

                    con.Left = venAddxLoc + 210;
                    con.Top = venAddyLoc;
                    venAddyLoc = venAddyLoc + 30;
                }

            }
            submitButton.Click += new EventHandler(submitButton_click);
            addressListBox.SelectedIndexChanged += new EventHandler(addressListToAddressText);
        }

        private void addressListToAddressText(object sender, EventArgs e)
        {

        }
        public void submitButton_click(object sender, EventArgs e)
        {
            // Assuming 'venAdd' contains TextBox controls with appropriate names
            TextBox companyNameTextBox = venAdd.Controls.Find("companyNameTextBox", true).FirstOrDefault() as TextBox;
            TextBox emailTextBox = venAdd.Controls.Find("emailTextBox", true).FirstOrDefault() as TextBox;
            TextBox telephoneTextBox = venAdd.Controls.Find("telephoneTextBox", true).FirstOrDefault() as TextBox;
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
                foreach (Control con in venAdd.Controls)
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



        public void venModifyClientFunc()
        {
            venModifyClient.Location = new System.Drawing.Point(4, 22);
            venModifyClient.Name = "venModifyClient";
            venModifyClient.Padding = new System.Windows.Forms.Padding(3);
            venModifyClient.Size = new System.Drawing.Size(610, 666);
            venModifyClient.TabIndex = 0;
            venModifyClient.Text = "Modify Client";
            venModifyClient.UseVisualStyleBackColor = true;
            venTab.Controls.Add(venModifyClient);

            ModifyClientForm modifyClientForm = new ModifyClientForm();
            AddForm(modifyClientForm, venModifyClient);

        }

        // adds the form inside the tab
        public static void AddForm(Form form, TabPage page)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            page.Controls.Add(form);
            form.Show();
        }

        private void InitializeUserProfilePanel()
        {
            userProfilePanel = new Panel
            {
                // Set properties according to your layout needs
                Size = new Size(600, 400),
                Location = new Point(200, 50), // Adjust the location as needed
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false // Start as hidden
            };
        }

        public RuntimeUI()
        {

            InitializeUserProfilePanel(); // Initialize the panel
            tblSelector(2);
            UserProfileMenuFunc(); // Initialize menu items
        }
        public void tblSelector(int val)
        {
            switch (val)
            {
                case 1:

                    // not visible
                    break;
                case 2:
                    mainPan.Controls.Add(venPan);
                    venPan.Controls.Add(venTab);
                    menuPan.Controls.Add(venMenu);
                    venPanFunc();
                    venMenuFunc();
                    venTabFunc();
                    venViewFunc();
                    venSearchFunc();
                    venAddFunc();
                    venReminderFunc();
                    venProblemHistoryFunc();
                    venModifyClientFunc();
                    // visible
                    break;
                case 3:

                    // Editable, Visible
                    break;
                case 4:
                    // Deletable, editable, Visisble
                    break;
                case 5:
                    // Add , Deletable, Editable, Visible
                    break;
            }

        }

        

        private void CitiSoft_Load(object sender, EventArgs e)
        {

        }
    }
}
