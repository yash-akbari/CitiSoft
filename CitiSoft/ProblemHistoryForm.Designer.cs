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
            this.userIDPHLabel = new System.Windows.Forms.Label();
            this.userIDPHTxtBox = new System.Windows.Forms.TextBox();
            this.viewProblemBtn = new System.Windows.Forms.Button();
            this.viewAllProblemsBtn = new System.Windows.Forms.Button();
            this.problemHistoryPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ProblemHistoryDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // ProblemHistoryDgv
            // 
            this.ProblemHistoryDgv.AllowUserToAddRows = false;
            this.ProblemHistoryDgv.AllowUserToDeleteRows = false;
            this.ProblemHistoryDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProblemHistoryDgv.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProblemHistoryDgv.Location = new System.Drawing.Point(0, 0);
            this.ProblemHistoryDgv.Name = "ProblemHistoryDgv";
            this.ProblemHistoryDgv.ReadOnly = true;
            this.ProblemHistoryDgv.RowHeadersWidth = 82;
            this.ProblemHistoryDgv.RowTemplate.Height = 33;
            this.ProblemHistoryDgv.Size = new System.Drawing.Size(1237, 1284);
            this.ProblemHistoryDgv.TabIndex = 0;
            // 
            // addClientBtn
            // 
            this.addClientBtn.Location = new System.Drawing.Point(1396, 369);
            this.addClientBtn.Name = "addClientBtn";
            this.addClientBtn.Size = new System.Drawing.Size(175, 54);
            this.addClientBtn.TabIndex = 1;
            this.addClientBtn.Text = "Add Client";
            this.addClientBtn.UseVisualStyleBackColor = true;
            this.addClientBtn.Click += new System.EventHandler(this.addClientBtn_Click);
            // 
            // descriptionTxtBox
            // 
            this.descriptionTxtBox.Location = new System.Drawing.Point(1283, 216);
            this.descriptionTxtBox.Multiline = true;
            this.descriptionTxtBox.Name = "descriptionTxtBox";
            this.descriptionTxtBox.Size = new System.Drawing.Size(288, 135);
            this.descriptionTxtBox.TabIndex = 2;
            this.descriptionTxtBox.TextChanged += new System.EventHandler(this.descriptionTxtBox_TextChanged);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(1278, 174);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(120, 25);
            this.descriptionLabel.TabIndex = 3;
            this.descriptionLabel.Text = "Description";
            // 
            // clientIDPHTxtBox
            // 
            this.clientIDPHTxtBox.Location = new System.Drawing.Point(1471, 90);
            this.clientIDPHTxtBox.Name = "clientIDPHTxtBox";
            this.clientIDPHTxtBox.Size = new System.Drawing.Size(100, 31);
            this.clientIDPHTxtBox.TabIndex = 4;
            this.clientIDPHTxtBox.TextChanged += new System.EventHandler(this.clientIDPHTxtBox_TextChanged);
            // 
            // clientIDPHLabel
            // 
            this.clientIDPHLabel.AutoSize = true;
            this.clientIDPHLabel.Location = new System.Drawing.Point(1278, 90);
            this.clientIDPHLabel.Name = "clientIDPHLabel";
            this.clientIDPHLabel.Size = new System.Drawing.Size(93, 25);
            this.clientIDPHLabel.TabIndex = 5;
            this.clientIDPHLabel.Text = "Client ID";
            // 
            // finishProblemBtn
            // 
            this.finishProblemBtn.Location = new System.Drawing.Point(1393, 650);
            this.finishProblemBtn.Name = "finishProblemBtn";
            this.finishProblemBtn.Size = new System.Drawing.Size(178, 44);
            this.finishProblemBtn.TabIndex = 6;
            this.finishProblemBtn.Text = "Finish Problem";
            this.finishProblemBtn.UseVisualStyleBackColor = true;
            this.finishProblemBtn.Click += new System.EventHandler(this.finishProblemBtn_Click_1);
            // 
            // problemIDLabel
            // 
            this.problemIDLabel.AutoSize = true;
            this.problemIDLabel.Location = new System.Drawing.Point(1278, 550);
            this.problemIDLabel.Name = "problemIDLabel";
            this.problemIDLabel.Size = new System.Drawing.Size(117, 25);
            this.problemIDLabel.TabIndex = 7;
            this.problemIDLabel.Text = "Problem ID";
            // 
            // problemIDTxtBox
            // 
            this.problemIDTxtBox.Location = new System.Drawing.Point(1471, 544);
            this.problemIDTxtBox.Name = "problemIDTxtBox";
            this.problemIDTxtBox.Size = new System.Drawing.Size(100, 31);
            this.problemIDTxtBox.TabIndex = 8;
            this.problemIDTxtBox.TextChanged += new System.EventHandler(this.problemIDTxtBox_TextChanged);
            // 
            // userIDPHLabel
            // 
            this.userIDPHLabel.AutoSize = true;
            this.userIDPHLabel.Location = new System.Drawing.Point(1278, 30);
            this.userIDPHLabel.Name = "userIDPHLabel";
            this.userIDPHLabel.Size = new System.Drawing.Size(84, 25);
            this.userIDPHLabel.TabIndex = 9;
            this.userIDPHLabel.Text = "Your ID";
            // 
            // userIDPHTxtBox
            // 
            this.userIDPHTxtBox.Location = new System.Drawing.Point(1471, 30);
            this.userIDPHTxtBox.Name = "userIDPHTxtBox";
            this.userIDPHTxtBox.Size = new System.Drawing.Size(100, 31);
            this.userIDPHTxtBox.TabIndex = 10;
            this.userIDPHTxtBox.TextChanged += new System.EventHandler(this.userIDPHTxtBox_TextChanged);
            // 
            // viewProblemBtn
            // 
            this.viewProblemBtn.Location = new System.Drawing.Point(1393, 600);
            this.viewProblemBtn.Name = "viewProblemBtn";
            this.viewProblemBtn.Size = new System.Drawing.Size(178, 44);
            this.viewProblemBtn.TabIndex = 11;
            this.viewProblemBtn.Text = "View a problem";
            this.viewProblemBtn.UseVisualStyleBackColor = true;
            this.viewProblemBtn.Click += new System.EventHandler(this.viewProblemBtn_Click);
            // 
            // viewAllProblemsBtn
            // 
            this.viewAllProblemsBtn.Location = new System.Drawing.Point(1393, 700);
            this.viewAllProblemsBtn.Name = "viewAllProblemsBtn";
            this.viewAllProblemsBtn.Size = new System.Drawing.Size(178, 44);
            this.viewAllProblemsBtn.TabIndex = 12;
            this.viewAllProblemsBtn.Text = "View all";
            this.viewAllProblemsBtn.UseVisualStyleBackColor = true;
            this.viewAllProblemsBtn.Click += new System.EventHandler(this.viewAllProblemsBtn_Click);
            // 
            // problemHistoryPanel
            // 
            this.problemHistoryPanel.Location = new System.Drawing.Point(0, 0);
            this.problemHistoryPanel.Name = "problemHistoryPanel";
            this.problemHistoryPanel.Size = new System.Drawing.Size(200, 100);
            this.problemHistoryPanel.TabIndex = 0;
            // 
            // ProblemHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1865, 1284);
            this.Controls.Add(this.viewAllProblemsBtn);
            this.Controls.Add(this.viewProblemBtn);
            this.Controls.Add(this.userIDPHTxtBox);
            this.Controls.Add(this.userIDPHLabel);
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
        private System.Windows.Forms.Label userIDPHLabel;
        private System.Windows.Forms.TextBox userIDPHTxtBox;
        private System.Windows.Forms.Button viewProblemBtn;
        private System.Windows.Forms.Button viewAllProblemsBtn;
        private System.Windows.Forms.Panel problemHistoryPanel;
    }
}