using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{
    public partial class SearchByVendor : Form
    {
        ComboBox searchByVendorComboBox = new ComboBox();
        Button searchByVendorButton = new Button();
        TextBox searchByVendorTextBox = new TextBox();
        DataGridView searchByVendorDataGridView = new DataGridView();
        public SearchByVendor()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {

            Controls.Add(searchByVendorDataGridView);
            Controls.Add(searchByVendorComboBox);
            Controls.Add(searchByVendorButton);
            Controls.Add(searchByVendorTextBox);
            // 
            // serByVendor
            // 

            searchByVendorDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            searchByVendorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            searchByVendorDataGridView.Location = new System.Drawing.Point(0, 34);
            searchByVendorDataGridView.Name = "searchByVendorDataGridView";
            searchByVendorDataGridView.Size = new System.Drawing.Size(610, 632);
            searchByVendorDataGridView.TabIndex = 1;
            // 
            // searchByVendorComboBox
            // 
            searchByVendorComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            searchByVendorComboBox.FormattingEnabled = true;
            searchByVendorComboBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            searchByVendorComboBox.Location = new System.Drawing.Point(418, 5);
            searchByVendorComboBox.Name = "searchByVendorComboBox";
            searchByVendorComboBox.Size = new System.Drawing.Size(100, 23);
            searchByVendorComboBox.TabIndex = 2;
            // 
            // searchByVendorButton
            // 
            searchByVendorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            searchByVendorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            searchByVendorButton.Location = new System.Drawing.Point(524, 5);
            searchByVendorButton.Name = "searchByVendorButton";
            searchByVendorButton.Size = new System.Drawing.Size(82, 23);
            searchByVendorButton.TabIndex = 1;
            searchByVendorButton.Text = "Search";
            searchByVendorButton.UseVisualStyleBackColor = true;
            // 
            // searchByVendorTextBox
            //
            searchByVendorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            searchByVendorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            searchByVendorTextBox.Location = new System.Drawing.Point(4, 5);
            searchByVendorTextBox.Name = "searchByVendorTextBox";
            searchByVendorTextBox.Size = new System.Drawing.Size(409, 23);
            searchByVendorTextBox.TabIndex = 0;

        }
    }
}
