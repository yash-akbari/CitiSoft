using System.Windows.Forms;

namespace CitiSoft
{
    partial class CitiSoft
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
            this.headPan = new System.Windows.Forms.Panel();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.maximizeBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.menuPan = new System.Windows.Forms.Panel();
            this.venViewData = new System.Windows.Forms.DataGridView();
            this.venSerData = new System.Windows.Forms.DataGridView();
            this.mainPan = new System.Windows.Forms.Panel();
            this.btnAddReminder = new System.Windows.Forms.Button();
            this.venVieData = new System.Windows.Forms.DataGridView();
            this.headPan.SuspendLayout();
            this.menuPan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.venViewData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.venSerData)).BeginInit();
            this.mainPan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.venVieData)).BeginInit();
            this.SuspendLayout();
            // 
            // headPan
            // 
            this.headPan.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.headPan.BackgroundImage = global::CitiSoft.Properties.Resources.citisoft_owler_20160727_124218_original;
            this.headPan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.headPan.Controls.Add(this.minimizeBtn);
            this.headPan.Controls.Add(this.maximizeBtn);
            this.headPan.Controls.Add(this.closeBtn);
            this.headPan.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.headPan.Dock = System.Windows.Forms.DockStyle.Top;
            this.headPan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.headPan.Location = new System.Drawing.Point(0, 0);
            this.headPan.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.headPan.Name = "headPan";
            this.headPan.Size = new System.Drawing.Size(1640, 246);
            this.headPan.TabIndex = 0;
            this.headPan.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPan_MouseDown);
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.minimizeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(80)))), ((int)(((byte)(145)))));
            this.minimizeBtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.minimizeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeBtn.Location = new System.Drawing.Point(1404, 23);
            this.minimizeBtn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(44, 44);
            this.minimizeBtn.TabIndex = 2;
            this.minimizeBtn.Text = "🗕";
            this.minimizeBtn.UseVisualStyleBackColor = false;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            // 
            // maximizeBtn
            // 
            this.maximizeBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.maximizeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(80)))), ((int)(((byte)(145)))));
            this.maximizeBtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.maximizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.maximizeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maximizeBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.maximizeBtn.Location = new System.Drawing.Point(1460, 23);
            this.maximizeBtn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.maximizeBtn.Name = "maximizeBtn";
            this.maximizeBtn.Size = new System.Drawing.Size(72, 44);
            this.maximizeBtn.TabIndex = 1;
            this.maximizeBtn.Text = "🗖";
            this.maximizeBtn.UseVisualStyleBackColor = false;
            this.maximizeBtn.Click += new System.EventHandler(this.maximizeBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.BackColor = System.Drawing.Color.Red;
            this.closeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.closeBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.closeBtn.Location = new System.Drawing.Point(1544, 23);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(72, 44);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.Text = "X";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // menuPan
            // 
            this.menuPan.Controls.Add(this.btnAddReminder);
            this.menuPan.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPan.Location = new System.Drawing.Point(0, 246);
            this.menuPan.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.menuPan.Name = "menuPan";
            this.menuPan.Size = new System.Drawing.Size(404, 1331);
            this.menuPan.TabIndex = 1;
            // 
            // venViewData
            // 
            this.venViewData.ColumnHeadersHeight = 46;
            this.venViewData.Location = new System.Drawing.Point(0, 0);
            this.venViewData.Name = "venViewData";
            this.venViewData.RowHeadersWidth = 82;
            this.venViewData.Size = new System.Drawing.Size(240, 150);
            this.venViewData.TabIndex = 0;
            // 
            // venSerData
            // 
            this.venSerData.ColumnHeadersHeight = 46;
            this.venSerData.Location = new System.Drawing.Point(0, 0);
            this.venSerData.Name = "venSerData";
            this.venSerData.RowHeadersWidth = 82;
            this.venSerData.Size = new System.Drawing.Size(240, 150);
            this.venSerData.TabIndex = 0;
            // 
            // mainPan
            // 
            this.mainPan.Controls.Add(this.venVieData);
            this.mainPan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPan.Location = new System.Drawing.Point(404, 246);
            this.mainPan.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.mainPan.Name = "mainPan";
            this.mainPan.Size = new System.Drawing.Size(1236, 1331);
            this.mainPan.TabIndex = 2;
            // 
            // btnAddReminder
            // 
            this.btnAddReminder.Location = new System.Drawing.Point(106, 47);
            this.btnAddReminder.Name = "btnAddReminder";
            this.btnAddReminder.Size = new System.Drawing.Size(192, 54);
            this.btnAddReminder.TabIndex = 0;
            this.btnAddReminder.Text = "Add Reminder";
            this.btnAddReminder.UseVisualStyleBackColor = true;
            this.btnAddReminder.Click += new System.EventHandler(this.btnAddReminder_Click);
            // 
            // venVieData
            // 
            this.venVieData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.venVieData.Location = new System.Drawing.Point(65, 56);
            this.venVieData.Name = "venVieData";
            this.venVieData.RowHeadersWidth = 82;
            this.venVieData.RowTemplate.Height = 33;
            this.venVieData.Size = new System.Drawing.Size(1081, 610);
            this.venVieData.TabIndex = 0;
            // 
            // CitiSoft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1640, 1577);
            this.ControlBox = false;
            this.Controls.Add(this.mainPan);
            this.Controls.Add(this.menuPan);
            this.Controls.Add(this.headPan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MinimumSize = new System.Drawing.Size(1640, 1577);
            this.Name = "CitiSoft";
            this.Text = "CitiSoft";
            this.headPan.ResumeLayout(false);
            this.menuPan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.venViewData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.venSerData)).EndInit();
            this.mainPan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.venVieData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headPan;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Panel menuPan;
        private System.Windows.Forms.Button maximizeBtn;
        private System.Windows.Forms.Button minimizeBtn;
        private System.Windows.Forms.DataGridView venViewData;
        private System.Windows.Forms.DataGridView venSerData;
        private Panel mainPan;
        private Button btnAddReminder;
        private DataGridView venVieData;
    }
}

