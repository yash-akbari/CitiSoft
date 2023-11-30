﻿using System;
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
            dashboardFunctionality.Padding = new System.Windows.Forms.Padding(3);
            dashboardFunctionality.Size = new System.Drawing.Size(610, 666);
            dashboardFunctionality.TabIndex = 0;
            dashboardFunctionality.Text = "Functionality";
            dashboardFunctionality.UseVisualStyleBackColor = true;

            dashboard dashboardForm = new dashboard();
            AddForm(dashboardForm, dashboardFunctionality);
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

            dataBinding(DataBaseManager.citiSoftDatabaseConnectionString, "SELECT VendorInfo.compName AS 'Company Name', VendorInfo.lstDemoDt AS 'Last Demo Date', VendorInfo.lstRevInt AS 'Last Review Interval', VendorInfo.lstRevDt AS 'Last Reviewed Date' FROM VendorInfo", venRemData);
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
            modifyClientForm.showDataInTable();
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

            panSelector("userProfilePanel");
           
            if (!userProfilePanel.Controls.ContainsKey("userProfileForm"))
            {
                UserProfileForm userProfileForm = new UserProfileForm
                {
                    Name = "userProfileForm",
                    TopLevel = false,
                    Dock = DockStyle.Fill,
                    FormBorderStyle = FormBorderStyle.None
                };
                userProfilePanel.Controls.Add(userProfileForm); // Add the form to the panel
                userProfileForm.Show();
            }
            else
            {
                // If the form is already created, just show it.
                userProfilePanel.Controls["userProfileForm"].BringToFront();
            }

            userProfilePanel.Visible = true; // Make the user profile panel visible
            userProfilePanel.BringToFront(); // Bring the user profile panel to the front
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
        /*public static void dataBinding(string connectionString, string baseQuery, DataGridView table, int? id = null, string idName = null)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            SqlCommand command = new SqlCommand(baseQuery, connection, transaction);

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

                            // Commit the transaction if everything is successful
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            // An error occurred, rollback the transaction
                            transaction.Rollback();
                            MessageBox.Show("Transaction Rolled Back. Error: " + ex.Message);
                        }
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
        }*/
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
                    dashboardMenuFunc();
                    dashboardFunctionalityFunc();
                    dasboardTabControlFunc();
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
            // mainPan
            // 
            this.mainPan.Size = new System.Drawing.Size(600, 652);
            // 
            // RuntimeUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(820, 800);
            this.Name = "RuntimeUI";
            this.ResumeLayout(false);

        }
    }
}
