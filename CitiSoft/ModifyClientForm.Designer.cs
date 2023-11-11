using System.Windows.Forms;

namespace CitiSoft
{
    partial class ModifyClientForm
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
            this.updateClientBtn = new System.Windows.Forms.Button();
            this.deleteClientBtn = new System.Windows.Forms.Button();
            this.ModifyClientDgv = new System.Windows.Forms.DataGridView();
            this.clientIDTxtBox = new System.Windows.Forms.TextBox();
            this.companyNameTxtBox = new System.Windows.Forms.TextBox();
            this.countryTxtBox = new System.Windows.Forms.TextBox();
            this.cityTxtBox = new System.Windows.Forms.TextBox();
            this.streetTxtBox = new System.Windows.Forms.TextBox();
            this.emailTxtBox = new System.Windows.Forms.TextBox();
            this.phoneTxtBox = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.countryLabel = new System.Windows.Forms.Label();
            this.companyNameLabel = new System.Windows.Forms.Label();
            this.streetLabel = new System.Windows.Forms.Label();
            this.deleteIDTextBox = new System.Windows.Forms.TextBox();
            this.clientIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ModifyClientDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // updateClientBtn
            // 
            this.updateClientBtn.Location = new System.Drawing.Point(1256, 545);
            this.updateClientBtn.Name = "updateClientBtn";
            this.updateClientBtn.Size = new System.Drawing.Size(139, 50);
            this.updateClientBtn.TabIndex = 0;
            this.updateClientBtn.Text = "Update";
            this.updateClientBtn.UseVisualStyleBackColor = true;
            this.updateClientBtn.Click += new System.EventHandler(this.updateClientBtn_Click);

            // 
            // deleteClientBtn
            // 
            this.deleteClientBtn.Location = new System.Drawing.Point(148, 637);
            this.deleteClientBtn.Name = "deleteClientBtn";
            this.deleteClientBtn.Size = new System.Drawing.Size(146, 44);
            this.deleteClientBtn.TabIndex = 1;
            this.deleteClientBtn.Text = "Delete row";
            this.deleteClientBtn.UseVisualStyleBackColor = true;
            this.deleteClientBtn.Click += new System.EventHandler(this.deleteClientBtn_Click);
            // 
            // ModifyClientDgv
            // 
            this.ModifyClientDgv.AllowUserToAddRows = false;
            this.ModifyClientDgv.AllowUserToDeleteRows = false;
            this.ModifyClientDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ModifyClientDgv.Location = new System.Drawing.Point(12, 12);
            this.ModifyClientDgv.Name = "ModifyClientDgv";
            this.ModifyClientDgv.ReadOnly = true;
            this.ModifyClientDgv.RowHeadersWidth = 82;
            this.ModifyClientDgv.RowTemplate.Height = 33;
            this.ModifyClientDgv.Size = new System.Drawing.Size(831, 492);
            this.ModifyClientDgv.TabIndex = 2;
            this.ModifyClientDgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            RuntimeUI.dataBinding("Functionality.mdf", "SELECT Client.cid, compName, phone, email, Street, City, Cointry AS 'Country'\r\nFROM Client\r\nJOIN CustAddress\r\n  ON Client.cid=CustAddress.cid;", ModifyClientDgv);

            // 
            // clientIDTxtBox
            // 
            this.clientIDTxtBox.Location = new System.Drawing.Point(1120, 57);
            this.clientIDTxtBox.Name = "clientIDTxtBox";
            this.clientIDTxtBox.Size = new System.Drawing.Size(275, 31);
            this.clientIDTxtBox.TabIndex = 3;
            this.clientIDTxtBox.TextChanged += new System.EventHandler(this.clientIDTxtBox_TextChanged);
            // 
            // companyNameTxtBox
            // 
            this.companyNameTxtBox.Location = new System.Drawing.Point(1120, 120);
            this.companyNameTxtBox.Name = "companyNameTxtBox";
            this.companyNameTxtBox.Size = new System.Drawing.Size(275, 31);
            this.companyNameTxtBox.TabIndex = 4;
            this.companyNameTxtBox.TextChanged += new System.EventHandler(this.companyNameTxtBox_TextChanged);
            // 
            // countryTxtBox
            // 
            this.countryTxtBox.Location = new System.Drawing.Point(1120, 484);
            this.countryTxtBox.Name = "countryTxtBox";
            this.countryTxtBox.Size = new System.Drawing.Size(275, 31);
            this.countryTxtBox.TabIndex = 5;
            this.countryTxtBox.TextChanged += new System.EventHandler(this.countryTxtBox_TextChanged);
            // 
            // cityTxtBox
            // 
            this.cityTxtBox.Location = new System.Drawing.Point(1120, 413);
            this.cityTxtBox.Name = "cityTxtBox";
            this.cityTxtBox.Size = new System.Drawing.Size(275, 31);
            this.cityTxtBox.TabIndex = 6;
            this.cityTxtBox.TextChanged += new System.EventHandler(this.cityTxtBox_TextChanged);
            // 
            // streetTxtBox
            // 
            this.streetTxtBox.Location = new System.Drawing.Point(1120, 335);
            this.streetTxtBox.Name = "streetTxtBox";
            this.streetTxtBox.Size = new System.Drawing.Size(275, 31);
            this.streetTxtBox.TabIndex = 7;
            this.streetTxtBox.TextChanged += new System.EventHandler(this.streetTxtBox_TextChanged);
            // 
            // emailTxtBox
            // 
            this.emailTxtBox.Location = new System.Drawing.Point(1120, 261);
            this.emailTxtBox.Name = "emailTxtBox";
            this.emailTxtBox.Size = new System.Drawing.Size(275, 31);
            this.emailTxtBox.TabIndex = 8;
            this.emailTxtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.emailTextBox_KeyDown);
            // 
            // phoneTxtBox
            // 
            this.phoneTxtBox.Location = new System.Drawing.Point(1120, 186);
            this.phoneTxtBox.Name = "phoneTxtBox";
            this.phoneTxtBox.Size = new System.Drawing.Size(275, 31);
            this.phoneTxtBox.TabIndex = 9;
            this.phoneTxtBox.TextChanged += new System.EventHandler(this.phoneTxtBox_TextChanged);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(949, 57);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(90, 25);
            this.idLabel.TabIndex = 10;
            this.idLabel.Text = "Client id";
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(949, 192);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(74, 25);
            this.phoneLabel.TabIndex = 12;
            this.phoneLabel.Text = "Phone";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(949, 267);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(65, 25);
            this.emailLabel.TabIndex = 13;
            this.emailLabel.Text = "Email";
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(949, 416);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(49, 25);
            this.cityLabel.TabIndex = 15;
            this.cityLabel.Text = "City";
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Location = new System.Drawing.Point(949, 490);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(87, 25);
            this.countryLabel.TabIndex = 16;
            this.countryLabel.Text = "Country";
            // 
            // companyNameLabel
            // 
            this.companyNameLabel.AutoSize = true;
            this.companyNameLabel.Location = new System.Drawing.Point(949, 120);
            this.companyNameLabel.Name = "companyNameLabel";
            this.companyNameLabel.Size = new System.Drawing.Size(165, 25);
            this.companyNameLabel.TabIndex = 11;
            this.companyNameLabel.Text = "Company Name";
            // 
            // streetLabel
            // 
            this.streetLabel.AutoSize = true;
            this.streetLabel.Location = new System.Drawing.Point(949, 341);
            this.streetLabel.Name = "streetLabel";
            this.streetLabel.Size = new System.Drawing.Size(69, 25);
            this.streetLabel.TabIndex = 14;
            this.streetLabel.Text = "Street";
            // 
            // deleteIDTextBox
            // 
            this.deleteIDTextBox.Location = new System.Drawing.Point(159, 558);
            this.deleteIDTextBox.Name = "deleteIDTextBox";
            this.deleteIDTextBox.Size = new System.Drawing.Size(135, 31);
            this.deleteIDTextBox.TabIndex = 17;
            this.deleteIDTextBox.TextChanged += new System.EventHandler(this.deleteIDTxtBox_TextChanged);
            // 
            // clientIDLabel
            // 
            this.clientIDLabel.AutoSize = true;
            this.clientIDLabel.Location = new System.Drawing.Point(27, 558);
            this.clientIDLabel.Name = "clientIDLabel";
            this.clientIDLabel.Size = new System.Drawing.Size(90, 25);
            this.clientIDLabel.TabIndex = 18;
            this.clientIDLabel.Text = "Client id";
            // 
            // ModifyClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 722);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Controls.Add(this.clientIDLabel);
            this.Controls.Add(this.deleteIDTextBox);
            this.Controls.Add(this.countryLabel);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.streetLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.companyNameLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.phoneTxtBox);
            this.Controls.Add(this.emailTxtBox);
            this.Controls.Add(this.streetTxtBox);
            this.Controls.Add(this.cityTxtBox);
            this.Controls.Add(this.countryTxtBox);
            this.Controls.Add(this.companyNameTxtBox);
            this.Controls.Add(this.clientIDTxtBox);
            this.Controls.Add(this.ModifyClientDgv);
            this.Controls.Add(this.deleteClientBtn);
            this.Controls.Add(this.updateClientBtn);
            this.Name = "ModifyClientForm";
            this.Text = "Modify Client";
            this.Load += new System.EventHandler(this.ModifyClientForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ModifyClientDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button updateClientBtn;
        private System.Windows.Forms.Button deleteClientBtn;
        private System.Windows.Forms.DataGridView ModifyClientDgv;

        private System.Windows.Forms.TextBox clientIDTxtBox;
        private System.Windows.Forms.TextBox companyNameTxtBox;
        private System.Windows.Forms.TextBox countryTxtBox;
        private System.Windows.Forms.TextBox cityTxtBox;
        private System.Windows.Forms.TextBox streetTxtBox;
        private System.Windows.Forms.TextBox emailTxtBox;
        private System.Windows.Forms.TextBox phoneTxtBox;

        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.Label companyNameLabel;
        private System.Windows.Forms.Label streetLabel;

        private System.Windows.Forms.TextBox deleteIDTextBox;
        private System.Windows.Forms.Label clientIDLabel;

    }
}