using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{
    public partial class CitiSoft : Form
    {

        private System.Windows.Forms.Label setMenu = new System.Windows.Forms.Label();
        private System.Windows.Forms.Label venMenu = new System.Windows.Forms.Label();
        private System.Windows.Forms.Label softMenu = new System.Windows.Forms.Label();
        private System.Windows.Forms.Label notiMenu = new System.Windows.Forms.Label();
        private System.Windows.Forms.TabControl venTab = new System.Windows.Forms.TabControl();
        private System.Windows.Forms.TabPage venView = new System.Windows.Forms.TabPage();
        private System.Windows.Forms.TabPage venSearch = new System.Windows.Forms.TabPage();
        private System.Windows.Forms.TabPage venAdd = new System.Windows.Forms.TabPage();
        private System.Windows.Forms.TabPage venRemind = new System.Windows.Forms.TabPage();

        private System.Windows.Forms.TabPage venProblemHistory = new System.Windows.Forms.TabPage();

        private System.Windows.Forms.ComboBox venFilCombo = new System.Windows.Forms.ComboBox();
        private System.Windows.Forms.Button venSerBtn = new System.Windows.Forms.Button();
        private System.Windows.Forms.TextBox venSerTex = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.Panel venPan = new System.Windows.Forms.Panel();

       

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
        public void venAddFunc()
        {
            // 
            // venAdd
            // 

            venAdd.Location = new System.Drawing.Point(4, 22);
            venAdd.Name = "venAdd";
            venAdd.Padding = new System.Windows.Forms.Padding(3);
            venAdd.Size = new System.Drawing.Size(610, 666);
            venAdd.TabIndex = 0;
            venAdd.Text = "Add";
            venAdd.UseVisualStyleBackColor = true;
            venTab.Controls.Add(venAdd);
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
            

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\CitiSoftDatabase.mdf;Integrated Security=True;Connect Timeout=30";
            //Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = "\\anglia.local\fs\StudentsHome\ia543\My Documents\CitiSoft\CitiSoft\CitiSoftDatabase.mdf"; Integrated Security = True
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query
                    string query1 = "SELECT VendorInfo.compName AS 'Company Name', VendorInfo.lstDemoDt AS 'Last Demo Date', VendorInfo.lstRevInt AS 'Last Review Interval', VendorInfo.lstRevDt AS 'Last Reviewed Date' FROM VendorInfo";
                    DataTable table1 = new DataTable();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query1, connection))
                    {
                        adapter.Fill(table1);
                    }

                    DataTable mergedTable = new DataTable();
                    mergedTable.Merge(table1);

                    venRemData.DataSource = mergedTable;
            }
        }

        public void venProblemHistoryFunc()
        {

            //
            // venProblemHistory
            //
            
            venProblemHistory.Location = new System.Drawing.Point(4, 22);
            venProblemHistory.Name = "venProblemHistory";
            venProblemHistory.Padding = new System.Windows.Forms.Padding(3);
            venProblemHistory.Size = new System.Drawing.Size(610, 666);
            venProblemHistory.TabIndex = 0;
            venProblemHistory.Text = "Client Problem History";
            venProblemHistory.UseVisualStyleBackColor = true;
            venTab.Controls.Add(venProblemHistory);
            venProblemHistory.Controls.Add(venProblemHistoryData);

            //
            // venProblemHistoryData
            //

            venProblemHistoryData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            venProblemHistoryData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            venProblemHistoryData.Location = new System.Drawing.Point(3, 3);
            venProblemHistoryData.Name = "venProblemHistoryData";
            venProblemHistoryData.Size = new System.Drawing.Size(604, 660);
            venProblemHistoryData.TabIndex = 0;

           
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Functionality.mdf;Integrated Security=True;Connect Timeout=30";
            //Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = "\\anglia.local\fs\StudentsHome\ia543\My Documents\CitiSoft\CitiSoft\CitiSoftDatabase.mdf"; Integrated Security = True
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL query
                string query1 = "SELECT * FROM ProblemHistory";
                DataTable table1 = new DataTable();

                using (SqlDataAdapter adapter = new SqlDataAdapter(query1, connection))
                {
                    adapter.Fill(table1);
                }

                DataTable mergedTable = new DataTable();
                mergedTable.Merge(table1);

                venProblemHistoryData.DataSource = mergedTable;
            }
            
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

        
    }
}
