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

        Label setMenu = new Label();
        Label venMenu = new Label();
        Label softMenu = new Label();
        Label notiMenu = new Label();


        TabControl venTabControl = new TabControl();
        TabPage viewParentTabPage = new TabPage();
        TabPage modifyParentTabPage = new TabPage();

        TabControl venViewChildTabControl = new TabControl(); 
        TabPage viewTabPage = new TabPage();
        TabPage searchTabPage = new TabPage();
        TabPage venProblemHistory = new TabPage();

        TabControl venModifyChildTabControl = new TabControl();
        TabPage addVendorTabPage = new TabPage();
        TabPage venRemind = new TabPage();
        TabPage venModifyClient = new TabPage();


        Panel venPan = new Panel();
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

        }

        void venMenu_Click(object sender, EventArgs e)
        {
            panSelector("venPan");
        }

        public void venPanFunc()
        {
            //
            // venPan
            //
            venPan.Dock = System.Windows.Forms.DockStyle.Fill;
            venPan.Name = "venPan";
        }
        public void venTabControlFunc()
        {   // 
            // venTabControl
            //
            venTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            venTabControl.BackColor = System.Drawing.Color.Red;
            venTabControl.Name = "venTab";
            venTabControl.SelectedIndex = 0;
            venTabControl.Controls.Add(viewParentTabPage);
            venTabControl.Controls.Add(modifyParentTabPage);
            venPan.Controls.Add(venTabControl);
        }

        public void viewParentTabPageFunc()
        {
            // 
            // viewParentTabPage
            //
            viewParentTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            viewParentTabPage.Name = "viewParentTabPage";
            viewParentTabPage.Text = "View";
        }
        public void modifyParentTabPageFunc()
        {
            // 
            // venViewTab
            //
            modifyParentTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            modifyParentTabPage.Name = "modifyParentTabPage";
            modifyParentTabPage.Text = "Modify";
        }

        public void viewTabPageFunc()
        {
            // 
            // viewTabPage
            // 
            viewTabPage.Controls.Add(venViewData);
            viewTabPage.Name = "viewTabPage";
            viewTabPage.Text = "View Vendor";
            viewParentTabPage.Controls.Add(venViewChildTabControl);


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
        }
        public void searchTabPageFunc()
        {
            // 
            // searchTabPage
            // 
            searchTabPage.Name = "searchTabPage";
            searchTabPage.Text = "Search";
            searchTabPage.UseVisualStyleBackColor = true;
            venViewChildTabControl.Controls.Add(searchTabPage);
            vendorSearch venSearch = new vendorSearch();
            AddForm(venSearch,searchTabPage);
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

        public void venProblemHistoryFunc()
        {
            venProblemHistory.Location = new System.Drawing.Point(4, 22);
            venProblemHistory.Name = "venProblemHistory";
            venProblemHistory.Padding = new System.Windows.Forms.Padding(3);
            venProblemHistory.Size = new System.Drawing.Size(610, 666);
            venProblemHistory.TabIndex = 0;
            venProblemHistory.Text = "Client Problem History";
            venProblemHistory.UseVisualStyleBackColor = true;
            venViewChildTabControl.Controls.Add(venProblemHistory);

            ProblemHistoryForm problemHistoryForm = new ProblemHistoryForm();
            AddForm(problemHistoryForm, venProblemHistory);
        }
        public void addVendorTabPageFunc()
        {
            addVendorTabPage = new TabPage
            {
                Location = new System.Drawing.Point(4, 22),
                Name = "addVendorTabPage",
                Padding = new System.Windows.Forms.Padding(3),
                Size = new System.Drawing.Size(610, 666),
                TabIndex = 0,
                Text = "Add Vendor",
                UseVisualStyleBackColor = true,
            };

            venViewChildTabControl.Controls.Add(addVendorTabPage);
            vendorAdd add = new vendorAdd();
            AddForm(add, addVendorTabPage);

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
            venViewChildTabControl.Controls.Add(venModifyClient);

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

        void InitializeUserProfilePanel()
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
        void UserProfileMenu_Click(object sender, EventArgs e)
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
                    
                    menuPan.Controls.Add(venMenu);
                    venPanFunc();
                    venMenuFunc();
                    venTabControlFunc();
                    viewTabPageFunc();
                    searchTabPageFunc();
                    addVendorTabPageFunc();
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

        

        void CitiSoft_Load(object sender, EventArgs e)
        {

        }
    }
}
