namespace CitiSoft
{
    partial class ProblemHistoryForm
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
            this.ProblemHistoryDgv = new System.Windows.Forms.DataGridView();
            this.addClientBtn = new System.Windows.Forms.Button();
            this.descriptionTxtBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.clientIDPHTxtBox = new System.Windows.Forms.TextBox();
            this.clientIDPHLabel = new System.Windows.Forms.Label();
            this.finishProblemBtn = new System.Windows.Forms.Button();
            this.problemIDLabel = new System.Windows.Forms.Label();
            this.problemIDTxtBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProblemHistoryDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // ProblemHistoryDgv
            // 
            this.ProblemHistoryDgv.AllowUserToAddRows = false;
            this.ProblemHistoryDgv.AllowUserToDeleteRows = false;
            this.ProblemHistoryDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProblemHistoryDgv.Location = new System.Drawing.Point(12, 12);
            this.ProblemHistoryDgv.Name = "ProblemHistoryDgv";
            this.ProblemHistoryDgv.ReadOnly = true;
            this.ProblemHistoryDgv.RowHeadersWidth = 82;
            this.ProblemHistoryDgv.RowTemplate.Height = 33;
            this.ProblemHistoryDgv.Size = new System.Drawing.Size(755, 476);
            this.ProblemHistoryDgv.TabIndex = 0;
            // 
            // addClientBtn
            // 
            this.addClientBtn.Location = new System.Drawing.Point(929, 475);
            this.addClientBtn.Name = "addClientBtn";
            this.addClientBtn.Size = new System.Drawing.Size(175, 54);
            this.addClientBtn.TabIndex = 1;
            this.addClientBtn.Text = "Add Client";
            this.addClientBtn.UseVisualStyleBackColor = true;
            this.addClientBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // descriptionTxtBox
            // 
            this.descriptionTxtBox.Location = new System.Drawing.Point(816, 315);
            this.descriptionTxtBox.Multiline = true;
            this.descriptionTxtBox.Name = "descriptionTxtBox";
            this.descriptionTxtBox.Size = new System.Drawing.Size(288, 135);
            this.descriptionTxtBox.TabIndex = 2;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(811, 272);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(120, 25);
            this.descriptionLabel.TabIndex = 3;
            this.descriptionLabel.Text = "Description";
            // 
            // clientIDPHTxtBox
            // 
            this.clientIDPHTxtBox.Location = new System.Drawing.Point(1004, 195);
            this.clientIDPHTxtBox.Name = "clientIDPHTxtBox";
            this.clientIDPHTxtBox.Size = new System.Drawing.Size(100, 31);
            this.clientIDPHTxtBox.TabIndex = 4;
            this.clientIDPHTxtBox.TextChanged += new System.EventHandler(this.clientIDPHTxtBox_TextChanged);
            // 
            // clientIDPHLabel
            // 
            this.clientIDPHLabel.AutoSize = true;
            this.clientIDPHLabel.Location = new System.Drawing.Point(811, 201);
            this.clientIDPHLabel.Name = "clientIDPHLabel";
            this.clientIDPHLabel.Size = new System.Drawing.Size(93, 25);
            this.clientIDPHLabel.TabIndex = 5;
            this.clientIDPHLabel.Text = "Client ID";
            this.clientIDPHLabel.Click += new System.EventHandler(this.clientIDPHLabel_Click);
            // 
            // finishProblemBtn
            // 
            this.finishProblemBtn.Location = new System.Drawing.Point(29, 559);
            this.finishProblemBtn.Name = "finishProblemBtn";
            this.finishProblemBtn.Size = new System.Drawing.Size(218, 44);
            this.finishProblemBtn.TabIndex = 6;
            this.finishProblemBtn.Text = "Finish Problem";
            this.finishProblemBtn.UseVisualStyleBackColor = true;
            this.finishProblemBtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // problemIDLabel
            // 
            this.problemIDLabel.AutoSize = true;
            this.problemIDLabel.Location = new System.Drawing.Point(24, 513);
            this.problemIDLabel.Name = "problemIDLabel";
            this.problemIDLabel.Size = new System.Drawing.Size(117, 25);
            this.problemIDLabel.TabIndex = 7;
            this.problemIDLabel.Text = "Problem ID";
            // 
            // problemIDTxtBox
            // 
            this.problemIDTxtBox.Location = new System.Drawing.Point(147, 513);
            this.problemIDTxtBox.Name = "problemIDTxtBox";
            this.problemIDTxtBox.Size = new System.Drawing.Size(100, 31);
            this.problemIDTxtBox.TabIndex = 8;
            this.problemIDTxtBox.TextChanged += new System.EventHandler(this.problemIDTxtBox_TextChanged);

            // 
            // ProblemHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 656);
            this.Controls.Add(this.problemIDTxtBox);
            this.Controls.Add(this.problemIDLabel);
            this.Controls.Add(this.finishProblemBtn);
            this.Controls.Add(this.clientIDPHLabel);
            this.Controls.Add(this.clientIDPHTxtBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.descriptionTxtBox);
            this.Controls.Add(this.addClientBtn);
            this.Controls.Add(this.ProblemHistoryDgv);
            this.Name = "ProblemHistoryForm";
            this.Text = "ProblemHistoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.ProblemHistoryDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ProblemHistoryDgv;
        private System.Windows.Forms.Button addClientBtn;
        private System.Windows.Forms.TextBox descriptionTxtBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox clientIDPHTxtBox;
        private System.Windows.Forms.Label clientIDPHLabel;
        private System.Windows.Forms.Button finishProblemBtn;
        private System.Windows.Forms.Label problemIDLabel;
        private System.Windows.Forms.TextBox problemIDTxtBox;
    }
}