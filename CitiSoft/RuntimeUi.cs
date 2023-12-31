﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CitiSoft
{
    public partial class RuntimeUI :MainUI
    {

        public bool LoggedOut { get; private set; }
        Label setMenu = new Label();
        Label notiMenu = new Label();





        /// <VendorMenu>
        Label venMenu = new Label();
        Panel venPan = new Panel();
        TabControl venTabControl = new TabControl();
        TabPage viewParentTabPage = new TabPage();
        TabPage modifyParentTabPage = new TabPage();

        TabControl venViewChildTabControl = new TabControl();
        TabPage viewVendorTabPage = new TabPage();

        TabPage clientProblemHistory = new TabPage();

        TabControl venModifyChildTabControl = new TabControl();
        TabPage addVendorTabPage = new TabPage();
        TabPage addSoftwareTabPage = new TabPage();
        TabPage updateVendorTabPage = new TabPage();
        TabPage updateSoftwareTabPage = new TabPage();
        TabPage deleteVendortabPage = new TabPage();
        TabPage deleteSoftwaretabPage = new TabPage();

        TabPage softRemind = new TabPage();


        //dashboard
        Label dashboardMenu = new Label();
        Panel dashboardPan = new Panel();
        TabControl dashboardTabControl = new TabControl();
        TabPage dashboardFunctionality = new TabPage();


        /// </VendorMenu>

        /// <ClientMenu>
        Label clientMenu = new Label();
        Panel clientPan = new Panel();
        TabControl clientTabControl = new TabControl();
        TabPage modifyClientTabPage = new TabPage();
        /// </ClientMenu>

        Panel userProfilePanel;
        int menuYLoc = 0;

        TabPage registerTabPage = new TabPage();
        TabControl registerTabControl = new TabControl();
        TabPage userRegistrationTabPage = new TabPage();
        TabPage passwordRequestsTabPage = new TabPage();

        public int CurrentUserType { get; set; }
        private int _userType;
        private int _userId;
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

            menuPan.Controls.Add(venMenu);

            mainPan.Controls.Add(venPan);

            venPan.Dock = System.Windows.Forms.DockStyle.Fill;
            venPan.Name = "venPan";
        }

        void venMenu_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            panSelector("venPan");
        }

        /// <summary>
        /// All the Functions ending with Func keyword are used to initialize the Speicific Controls
        /// </summary>

        public void venTabControlFunc()
        {
            venTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            venTabControl.Name = "venTabControl";
            venTabControl.Controls.Add(viewParentTabPage);
            venTabControl.Controls.Add(modifyParentTabPage);
            venPan.Controls.Add(venTabControl);
        }

        public void viewParentTabPageFunc()
        {
            viewParentTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            viewParentTabPage.Name = "viewParentTabPage";
            viewParentTabPage.Text = "View";
            venViewChildTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            viewParentTabPage.Controls.Add(venViewChildTabControl);
        }


        public void modifyParentTabPageFunc()
        {
            modifyParentTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            modifyParentTabPage.Name = "modifyParentTabPage";
            modifyParentTabPage.Text = "Modify";
            venModifyChildTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            modifyParentTabPage.Controls.Add(venModifyChildTabControl);
        }

        public void viewVendorTabPageFunc()
        {
            venViewChildTabControl.Controls.Add(viewVendorTabPage);
            viewVendorTabPage.Name = "viewVendorTabPage";
            viewVendorTabPage.Text = "View & Search";
            viewVendorTabPage.AutoScroll = true;

            ViewDataByVendor venView = new ViewDataByVendor();

            AddForm(venView, viewVendorTabPage);
        }

        void dashboardMenuFunc()
        {
            dashboardMenu.Text = "Dashboard";
            menuPan.Controls.Add(dashboardMenu);
            dashboardMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dashboardMenu.Location = new System.Drawing.Point(0, menuYLoc);
            menuYLoc = menuYLoc + 50;
            dashboardMenu.Size = new System.Drawing.Size(200, 50);
            dashboardMenu.TabIndex = 1;
            dashboardMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            dashboardMenu.Click += dashboardMenu_Click;

            mainPan.Controls.Add(dashboardPan);


            dashboardPan.Dock = System.Windows.Forms.DockStyle.Fill;
            dashboardPan.Name = "dashboardPan";
            dashboardPan.Controls.Add(dashboardTabControl);
        }
        void dasboardTabControlFunc()
        {
            dashboardTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            dashboardTabControl.Name = "dashboardTabControl";
        }
        private void dashboardMenu_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            panSelector("dashboardPan");
        }

        public void dashboardFunctionalityFunc()
        {
            dashboardTabControl.Controls.Add(dashboardFunctionality);
            dashboardFunctionality.Location = new System.Drawing.Point(4, 22);
            dashboardFunctionality.Name = "dashboardFunctionality";
            dashboardFunctionality.Size = new System.Drawing.Size(610, 666);
            dashboardFunctionality.TabIndex = 0;
            dashboardFunctionality.UseVisualStyleBackColor = true;

            dashboard dashboardForm = new dashboard();
            AddForm(dashboardForm, dashboardFunctionality);
        }


        public void addVendorTabPageFunc()
        {
            addVendorTabPage.Name = "addVendorTabPage";
            addVendorTabPage.Text = "Add Vendor";
            AddVendor addVen = new AddVendor();
            AddForm(addVen, addVendorTabPage);
            venModifyChildTabControl.Controls.Add(addVendorTabPage);
        }

        public void addSoftwareTabPageFunc()
        {
            addSoftwareTabPage.Name = "addSoftwareTabPage";
            addSoftwareTabPage.Text = "Add Software";
            AddSoftware addSoft = new AddSoftware();
            AddForm(addSoft, addSoftwareTabPage);
            venModifyChildTabControl.Controls.Add(addSoftwareTabPage);
        }

        public void updateSoftwareTabPageFunc()
        {
            updateSoftwareTabPage.Name = "updateSoftwareTabPage";
            updateSoftwareTabPage.Text = "Update Software";
            UpdateSoftware updateSoft = new UpdateSoftware();
            AddForm(updateSoft, updateSoftwareTabPage);
            venModifyChildTabControl.Controls.Add(updateSoftwareTabPage);
        }

        public void updateVendorTabPageFunc()
        {
            updateVendorTabPage.Name = "updateVendorTabPage";
            updateVendorTabPage.Text = "Update Vendor";
            UpdateVendor updateVendor = new UpdateVendor();
            AddForm(updateVendor, updateVendorTabPage);
            venModifyChildTabControl.Controls.Add(updateVendorTabPage);
        }
        public void deleteVendorTabPageFunc()
        {
            deleteVendortabPage.Name = "updateVendorTabPage";
            deleteVendortabPage.Text = "Delete Vendor";
            Delete_Vendor delete_Vendor = new Delete_Vendor();
            AddForm(delete_Vendor, deleteVendortabPage);
            venModifyChildTabControl.Controls.Add(deleteVendortabPage);
        }
        public void deleteSoftwareTabPageFunc()
        {
            deleteSoftwaretabPage.Name = "deleteSoftwareTabPage";
            deleteSoftwaretabPage.Text = "Delete Software";
            DeleteSoftware deleteSoftware = new DeleteSoftware();
            AddForm(deleteSoftware, deleteSoftwaretabPage);
            venModifyChildTabControl.Controls.Add(deleteSoftwaretabPage);
        }





        public void softReminderFunc()
        {
            // 
            // venRemind
            // 
            softRemind.Location = new System.Drawing.Point(4, 22);
            softRemind.Name = "venRemind";
            softRemind.Padding = new System.Windows.Forms.Padding(3);
            softRemind.Size = new System.Drawing.Size(610, 666);
            softRemind.TabIndex = 0;
            softRemind.Text = "Remind";
            softRemind.UseVisualStyleBackColor = true;
            softRemind.Controls.Add(softRemData);
            venViewChildTabControl.Controls.Add(softRemind);

            // 
            // venRemData
            // 

            softRemData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            softRemData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            softRemData.Location = new System.Drawing.Point(3, 3);
            softRemData.Name = "venRemData";
            softRemData.Size = new System.Drawing.Size(604, 660);
            softRemData.TabIndex = 0;

            dataBinding(DataBaseManager.citiSoftDatabaseConnectionString, "SELECT s.SoftName, c.comment, c.lstDemoDt,c.lstRevDt,  c.lstRevInt FROM dbo.SoftName s Join dbo.Comments c ON s.sid = c.sid;", softRemData);
            //SELECT VendorInfo.compName AS 'Company Name', VendorInfo.lstDemoDt AS 'Last Demo Date', VendorInfo.lstRevInt AS 'Last Review Interval', VendorInfo.lstRevDt AS 'Last Reviewed Date' FROM VendorInfo
        }


        public void clientMenuFunc()
        {//Settings Menu
            clientMenu.Text = "Client";
            menuPan.Controls.Add(clientMenu);
            clientMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            clientMenu.Location = new System.Drawing.Point(0, menuYLoc);
            menuYLoc = menuYLoc + 50;
            clientMenu.Size = new System.Drawing.Size(200, 50);
            clientMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            clientMenu.Click += clientMenu_Click;

            mainPan.Controls.Add(clientPan);


            clientPan.Dock = System.Windows.Forms.DockStyle.Fill;
            clientPan.Name = "clientPan";
            clientPan.Controls.Add(clientTabControl);
        }

        private void clientMenu_Click(object sender, EventArgs e)
        {
            panSelector("clientPan");
            HideAllPanels();
            clientPan.Visible = true;
        }

        void clientTabControlFunc()
        {
            clientTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            clientTabControl.Name = "clientTabControl";
        }

        public void modifyClientTabPageFunc()
        {
            clientTabControl.Controls.Add(modifyClientTabPage);
            modifyClientTabPage.Location = new System.Drawing.Point(4, 22);
            modifyClientTabPage.Name = "modifyClientTabPage";
            modifyClientTabPage.Padding = new System.Windows.Forms.Padding(3);
            modifyClientTabPage.Size = new System.Drawing.Size(610, 666);
            modifyClientTabPage.TabIndex = 0;
            modifyClientTabPage.Text = "Modify Client";
            modifyClientTabPage.UseVisualStyleBackColor = true;

            ModifyClientForm modifyClientForm = new ModifyClientForm();
            AddForm(modifyClientForm, modifyClientTabPage);
        }
        public void clientProblemHistoryFunc()
        {
            clientProblemHistory.Location = new System.Drawing.Point(4, 22);
            clientProblemHistory.Name = "clientProblemHistory";
            clientProblemHistory.Padding = new System.Windows.Forms.Padding(3);
            clientProblemHistory.Size = new System.Drawing.Size(610, 666);
            clientProblemHistory.TabIndex = 0;
            clientProblemHistory.Text = "Client Problem History";
            clientProblemHistory.UseVisualStyleBackColor = true;
            clientTabControl.Controls.Add(clientProblemHistory);

            ProblemHistoryForm problemHistoryForm = new ProblemHistoryForm();
            AddForm(problemHistoryForm, clientProblemHistory);
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
                Dock = DockStyle.Fill,
                Size = new Size(600, 400),
                Location = new Point(200, 50),
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false
            };
            this.Controls.Add(userProfilePanel); // Add userProfilePanel to the main form's controls only once
            userProfilePanel.BringToFront();
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


        void UserProfileMenuFunc()
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
            // Hide all panels first.
            HideAllPanels();


            UserProfileForm userProfileForm;

            if (!userProfilePanel.Controls.ContainsKey("userProfileForm"))
            {
                userProfileForm = new UserProfileForm
                {
                    Name = "userProfileForm",
                    TopLevel = false,
                    Dock = DockStyle.Fill,
                    FormBorderStyle = FormBorderStyle.None
                };
                userProfileForm.UserLoggedOut += (s, args) =>
                {
                    this.Close(); 
                };

                userProfilePanel.Controls.Add(userProfileForm);
                userProfileForm.Show();
            }
            else
            {
                userProfileForm = (UserProfileForm)userProfilePanel.Controls["userProfileForm"];
                userProfileForm.BringToFront();
            }

            userProfilePanel.Visible = true;


        }

        public void RegisterMenuFunc()
        {
            // I'm setting up the main "Register" tab here
            registerTabPage.Text = "Register";
            registerTabPage.Dock = DockStyle.Fill;
            registerTabControl.Dock = DockStyle.Fill;

            // Adding the main "Register" tab to my vendor tab control
            venTabControl.Controls.Add(registerTabPage);

            // Inserting a tab control into the register tab for sub-tabs
            registerTabPage.Controls.Add(registerTabControl);

            // Now, I'm configuring the sub-tabs
            SetupUserRegistrationTab();
            SetupPasswordRequestsTab();
        }
        private void SetupUserRegistrationTab()
        {

            TabPage userRegistrationTab = new TabPage("User Registration");
            userRegistrationTab.Dock = DockStyle.Fill;


            UserRegistrationForm userRegForm = new UserRegistrationForm();
            userRegForm.TopLevel = false;
            userRegForm.Dock = DockStyle.Fill;
            userRegForm.FormBorderStyle = FormBorderStyle.None;

            userRegistrationTab.Controls.Add(userRegForm);
            registerTabControl.TabPages.Add(userRegistrationTab);

            userRegForm.Show();
        }

        public void SetupPasswordRequestsTab()
        {
           
            passwordRequestsTabPage.Text = "Password Requests";
            passwordRequestsTabPage.Dock = DockStyle.Fill;

            
            AdminPasswordChangeRequestsForm passwordChangeRequestsForm = new AdminPasswordChangeRequestsForm();
            passwordChangeRequestsForm.TopLevel = false;
            passwordChangeRequestsForm.Dock = DockStyle.Fill;
            passwordChangeRequestsForm.FormBorderStyle = FormBorderStyle.None;

            passwordRequestsTabPage.Controls.Add(passwordChangeRequestsForm);
            registerTabControl.TabPages.Add(passwordRequestsTabPage);

            passwordChangeRequestsForm.Show();
        }









        // Method to hide all panels.
        private void HideAllPanels()
        {
            dashboardPan.Visible = false;
            venPan.Visible = false;
            clientPan.Visible = false;
            userProfilePanel.Visible = false;
            // Hide other panels as needed...
        }



        public void notiMenuFunc()
        {//notification Menu

            notiMenu.Text = "Notifications";
            menuPan.Controls.Add(notiMenu);
            notiMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            notiMenu.Location = new System.Drawing.Point(0, menuYLoc);
            menuYLoc = menuYLoc + 50;
            notiMenu.Size = new System.Drawing.Size(200, 50);
            notiMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        }

        public void setMenuFunc()
        {//Settings Menu
            setMenu.Text = "Settings";
            menuPan.Controls.Add(setMenu);
            setMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            setMenu.Location = new System.Drawing.Point(0, menuYLoc);
            menuYLoc = menuYLoc + 50;
            setMenu.Size = new System.Drawing.Size(200, 50);
            setMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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

                    // Modify the query and add parameter if 'id' is provided
                    if (id.HasValue && idName != null)
                    {
                        baseQuery += $" WHERE {idName} = {id}";
                    }

                    SqlDataAdapter sqlData = new SqlDataAdapter(baseQuery, connectionString);
                    DataTable dataTable = new DataTable();
                    sqlData.Fill(dataTable);
                    
                    table.DataSource = dataTable;
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL-specific errors
                MessageBox.Show("SQL Error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                // Handle other types of errors
                MessageBox.Show("General Error: " + ex.Message);
            }
        }



        public void InitializeTabs()
        {

            InitializeUserProfilePanel();
            tblSelector(2);
            UserProfileMenuFunc();



            if (CurrentUserType == 1)
            {
                
                RegisterMenuFunc(); // Call this only if the user is an admin
              
            }
        }

        public RuntimeUI(int userType, int userId)
        {
            InitializeComponent();
            CurrentUserType = userType;
            _userId = userId;    
            InitializeTabs();
        }


        public void tblSelector(int val)
        {
            switch (val)
            {
                case 1:

                    // not visible
                    break;
                case 2:

                    CheckIndent c = new CheckIndent();
                    dashboardMenuFunc();
                    dashboardFunctionalityFunc();
                    dasboardTabControlFunc();
                    venMenuFunc();
                    venTabControlFunc();
                    viewParentTabPageFunc();
                    viewVendorTabPageFunc();
                    modifyParentTabPageFunc();
                    addVendorTabPageFunc();
                    addSoftwareTabPageFunc();
                    updateVendorTabPageFunc();
                    updateSoftwareTabPageFunc();
                    deleteVendorTabPageFunc();
                    deleteSoftwareTabPageFunc();
                    softReminderFunc();
                    clientProblemHistoryFunc();
                    clientMenuFunc();
                    clientTabControlFunc();
                    modifyClientTabPageFunc();
                    
                    //ModifyDocumentsForm modifyDocumentsForm = new ModifyDocumentsForm();
                    //modifyDocumentsForm.ShowDialog();
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


        private void _statusLabel_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // mainPan
            // 
            this.mainPan.Size = new System.Drawing.Size(749, 652);
            // 
            // RuntimeUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(969, 800);
            this.Name = "RuntimeUI";
            this.Load += new System.EventHandler(this.RuntimeUI_Load);
            this.ResumeLayout(false);

        }

        private void RuntimeUI_Load(object sender, EventArgs e)
        {

        }

        public AddVendor AddVendor
        {
            get => default;
            set
            {
            }
        }

        internal AddSoftware AddSoftware
        {
            get => default;
            set
            {
            }
        }

        public ModifyClientForm ModifyClientForm
        {
            get => default;
            set
            {
            }
        }


        public ModifyDocumentsForm ModifyDocumentsForm
        {
            get => default;
            set
            {
            }
        }

        public ChangePasswordForm ChangePasswordForm
        {
            get => default;
            set
            {
            }
        }

        public ForgotPasswordForm ForgotPasswordForm
        {
            get => default;
            set
            {
            }
        }

        public ProblemHistoryForm ProblemHistoryForm
        {
            get => default;
            set
            {
            }
        }

        public UserProfileForm UserProfileForm
        {
            get => default;
            set
            {
            }
        }

        public dashboard dashboard
        {
            get => default;
            set
            {
            }
        }
    }
}
