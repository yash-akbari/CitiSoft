using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{
    public partial class vendorSearch : Form
    {
        ComboBox venFilCombo = new ComboBox();
        Button venSerBtn = new Button();
        TextBox venSerTex = new TextBox();
        DataGridView venSerData = new DataGridView();

        public vendorSearch() 
        {
            InitializeComponent();  
        }
        private void InitializeComponent()
        {

            Controls.Add(venSerData);
            Controls.Add(venFilCombo);
            Controls.Add(venSerBtn);
            Controls.Add(venSerTex);
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
            venFilCombo.Name = "venFilCombo";
            venFilCombo.Size = new System.Drawing.Size(100, 23);
            venFilCombo.TabIndex = 2;
            // 
            // venSerBtn
            // 
            venSerBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            venSerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            venSerBtn.Location = new System.Drawing.Point(524, 5);
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
            venSerTex.Name = "venSerTex";
            venSerTex.Size = new System.Drawing.Size(409, 23);
            venSerTex.TabIndex = 0;

        }
    }
}
