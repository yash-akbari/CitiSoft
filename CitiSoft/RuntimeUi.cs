using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CitiSoft
{
    public partial class RuntimeUI : MainUI
    {

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
        TabPage searchVendorTabPage = new TabPage();
        TabPage clientProblemHistory = new TabPage();

        TabControl venModifyChildTabControl = new TabControl();
        TabPage addVendorTabPage = new TabPage();
        TabPage addSoftwareTabPage = new TabPage();
        TabPage modifyVendorTabPage = new TabPage();

        TabPage venRemind = new TabPage();
        /// </VendorMenu>

        /// <ClientMenu>
        Label clientMenu = new Label();
        Panel clientPan = new Panel();
        TabControl clientTabControl = new TabControl();
        TabPage modifyClientTabPage = new TabPage();
        /// </ClientMenu>

        Panel userProfilePanel;
        int menuYLoc = 0;


      
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
            panSelector("venPan");
        }

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
            viewVendorTabPage.Text = "View Vendor";
            viewVendor venView = new viewVendor();
            AddForm(venView, viewVendorTabPage);
        }

        public void searchVendorTabPageFunc()
        {
            searchVendorTabPage.Name = "searchVendorTabPage";
            searchVendorTabPage.Text = "Search";
            venViewChildTabControl.Controls.Add(searchVendorTabPage);
            searchVendor venSearch = new searchVendor();
            AddForm(venSearch, searchVendorTabPage);
        }


        public void addVendorTabPageFunc()
        {
            addVendorTabPage.Name = "addVendorTabPage";
            addVendorTabPage.Text = "Add Vendor";
            addVendor addVen = new addVendor();
            AddForm(addVen, addVendorTabPage);
            venModifyChildTabControl.Controls.Add(addVendorTabPage);
        }

        public void addSoftwareTabPageFunc()
        {
            addSoftwareTabPage.Name = "addSoftwareTabPage";
            addSoftwareTabPage.Text = "Add Software";
            addSoftware addSoft = new addSoftware();
            AddForm(addSoft, addSoftwareTabPage);
            venModifyChildTabControl.Controls.Add(addSoftwareTabPage);
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
            venViewChildTabControl.Controls.Add(venRemind);

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
                Size = new Size(600, 400), // Adjust the size as needed
                Location = new Point(200, 50), // Adjust the location as needed
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false // Start as hidden
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

            if (userProfilePanel.Controls.ContainsKey("userProfileForm"))
            {
                userProfilePanel.Controls["userProfileForm"].BringToFront();
            }
            else
            {

                UserProfileForm userProfileForm = new UserProfileForm
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill,
                    FormBorderStyle = FormBorderStyle.None
                };

                userProfilePanel.Controls.Add(userProfileForm); // Add the form to the panel
                userProfileForm.Show();
            }

            userProfilePanel.Visible = true;
            userProfilePanel.BringToFront();
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


        public RuntimeUI()
        {
            InitializeComponent();
            InitializeUserProfilePanel();
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


                    venMenuFunc();
                    venTabControlFunc();
                    viewParentTabPageFunc();
                    viewVendorTabPageFunc();
                    modifyParentTabPageFunc();
                    searchVendorTabPageFunc();
                    addVendorTabPageFunc();
                    addSoftwareTabPageFunc();
                    venReminderFunc();
                    clientProblemHistoryFunc();
                    clientMenuFunc();
                    clientTabControlFunc();
                    modifyClientTabPageFunc();
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
       /* private void AccessButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(_vendorDocsGridView.Text, out int vendorId))
            {
                var docPath = _manager.AccessVendorDocs(vendorId);
                if (docPath != null)
                {
                    _statusLabel.Text = $"Document Path: {docPath}";
                }
                else
                {
                    _statusLabel.Text = "Document not found!";
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Vendor ID!");
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(_vendorDocsGridView.Text, out int vendorId))
            {
                if (_manager.RemoveVendorDocs(vendorId))
                {
                    _statusLabel.Text = "Document removed successfully!";
                }
                else
                {
                    _statusLabel.Text = "Failed to remove document!";
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Vendor ID!");
            }
        }*/

        private void _statusLabel_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RuntimeUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(820, 572);
            this.Name = "RuntimeUI";
            this.ResumeLayout(false);

        }
    }
}
