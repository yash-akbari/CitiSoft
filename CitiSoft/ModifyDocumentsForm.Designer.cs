using System.Windows.Forms;
using System.Xml.Linq;

namespace CitiSoft
{
    partial class ModifyDocumentsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileDropPBox = new System.Windows.Forms.PictureBox();
            this.dragAndDropLabel = new System.Windows.Forms.Label();
            this.vendorIDLabel = new System.Windows.Forms.Label();
            this.vendorIDTxtBox = new System.Windows.Forms.TextBox();
            this.addDocumentDgv = new System.Windows.Forms.DataGridView();
            this.removeDocumentBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileDropPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addDocumentDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // fileDropPBox
            // 
            this.fileDropPBox.BackColor = System.Drawing.SystemColors.Info;
            this.fileDropPBox.Location = new System.Drawing.Point(1329, 62);
            this.fileDropPBox.Name = "fileDropPBox";
            this.fileDropPBox.Size = new System.Drawing.Size(461, 314);
            this.fileDropPBox.TabIndex = 0;
            this.fileDropPBox.TabStop = false;
            // 
            // dragAndDropLabel
            // 
            this.dragAndDropLabel.AutoSize = true;
            this.dragAndDropLabel.Location = new System.Drawing.Point(1324, 34);
            this.dragAndDropLabel.Name = "dragAndDropLabel";
            this.dragAndDropLabel.Size = new System.Drawing.Size(352, 25);
            this.dragAndDropLabel.TabIndex = 1;
            this.dragAndDropLabel.Text = "Drag and drop your document here:";
            this.dragAndDropLabel.Click += new System.EventHandler(this.dragAndDropLabel_Click);
            // 
            // vendorIDLabel
            // 
            this.vendorIDLabel.AutoSize = true;
            this.vendorIDLabel.Location = new System.Drawing.Point(1329, 394);
            this.vendorIDLabel.Name = "vendorIDLabel";
            this.vendorIDLabel.Size = new System.Drawing.Size(107, 25);
            this.vendorIDLabel.TabIndex = 2;
            this.vendorIDLabel.Text = "Vendor ID";
            // 
            // vendorIDTxtBox
            // 
            this.vendorIDTxtBox.Location = new System.Drawing.Point(1471, 394);
            this.vendorIDTxtBox.Name = "vendorIDTxtBox";
            this.vendorIDTxtBox.Size = new System.Drawing.Size(100, 31);
            this.vendorIDTxtBox.TabIndex = 3;
            this.vendorIDTxtBox.TextChanged += new System.EventHandler(this.vendorIDTxtBox_TextChanged);
            // 
            // addDocumentDgv
            // 
            this.addDocumentDgv.AllowUserToAddRows = false;
            this.addDocumentDgv.AllowUserToDeleteRows = false;
            this.addDocumentDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addDocumentDgv.Dock = System.Windows.Forms.DockStyle.Left;
            this.addDocumentDgv.Location = new System.Drawing.Point(0, 0);
            this.addDocumentDgv.Name = "addDocumentDgv";
            this.addDocumentDgv.ReadOnly = true;
            this.addDocumentDgv.RowHeadersWidth = 82;
            this.addDocumentDgv.RowTemplate.Height = 33;
            this.addDocumentDgv.Size = new System.Drawing.Size(1237, 1284);
            this.addDocumentDgv.TabIndex = 4;
            // 
            // removeDocumentBtn
            // 
            this.removeDocumentBtn.Location = new System.Drawing.Point(1344, 454);
            this.removeDocumentBtn.Name = "removeDocumentBtn";
            this.removeDocumentBtn.Size = new System.Drawing.Size(227, 43);
            this.removeDocumentBtn.TabIndex = 5;
            this.removeDocumentBtn.Text = "Remove Document";
            this.removeDocumentBtn.UseVisualStyleBackColor = true;
            this.removeDocumentBtn.Click += new System.EventHandler(this.removeDocumentBtn_Click);
            // 
            // ModifyDocumentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1865, 1284);
            this.Controls.Add(this.removeDocumentBtn);
            this.Controls.Add(this.addDocumentDgv);
            this.Controls.Add(this.vendorIDTxtBox);
            this.Controls.Add(this.vendorIDLabel);
            this.Controls.Add(this.dragAndDropLabel);
            this.Controls.Add(this.fileDropPBox);
            this.Name = "ModifyDocumentsForm";
            this.Text = "ModifyDocumentsForm";
            ((System.ComponentModel.ISupportInitialize)(this.fileDropPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addDocumentDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox fileDropPBox;
        private System.Windows.Forms.Label dragAndDropLabel;
        private System.Windows.Forms.Label vendorIDLabel;
        private System.Windows.Forms.TextBox vendorIDTxtBox;
        private System.Windows.Forms.DataGridView addDocumentDgv;
        private Button removeDocumentBtn;
    }
}