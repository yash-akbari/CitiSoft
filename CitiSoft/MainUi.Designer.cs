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
            this.softMenu = new System.Windows.Forms.Label();
            this.venMenu = new System.Windows.Forms.Label();
            this.venTab = new System.Windows.Forms.TabControl();
            this.venView = new System.Windows.Forms.TabPage();
            this.venVieData = new System.Windows.Forms.DataGridView();
            this.venSearch = new System.Windows.Forms.TabPage();
            this.venSerData = new System.Windows.Forms.DataGridView();
            this.venFilCombo = new System.Windows.Forms.ComboBox();
            this.venSerBtn = new System.Windows.Forms.Button();
            this.venSerTex = new System.Windows.Forms.TextBox();
            this.headPan.SuspendLayout();
            this.menuPan.SuspendLayout();
            this.venTab.SuspendLayout();
            this.venView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.venVieData)).BeginInit();
            this.venSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.venSerData)).BeginInit();
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
            this.headPan.Name = "headPan";
            this.headPan.Size = new System.Drawing.Size(820, 128);
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
            this.minimizeBtn.Location = new System.Drawing.Point(702, 12);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(22, 23);
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
            this.maximizeBtn.Location = new System.Drawing.Point(730, 12);
            this.maximizeBtn.Name = "maximizeBtn";
            this.maximizeBtn.Size = new System.Drawing.Size(36, 23);
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
            this.closeBtn.Location = new System.Drawing.Point(772, 12);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(36, 23);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.Text = "X";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // menuPan
            // 
            this.menuPan.Controls.Add(this.softMenu);
            this.menuPan.Controls.Add(this.venMenu);
            this.menuPan.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPan.Location = new System.Drawing.Point(0, 128);
            this.menuPan.Name = "menuPan";
            this.menuPan.Size = new System.Drawing.Size(202, 692);
            this.menuPan.TabIndex = 1;
            // 
            // softMenu
            // 
            this.softMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.softMenu.Location = new System.Drawing.Point(0, 50);
            this.softMenu.Name = "softMenu";
            this.softMenu.Size = new System.Drawing.Size(200, 50);
            this.softMenu.TabIndex = 1;
            this.softMenu.Text = "Software";
            this.softMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // venMenu
            // 
            this.venMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.venMenu.Location = new System.Drawing.Point(0, 0);
            this.venMenu.Name = "venMenu";
            this.venMenu.Size = new System.Drawing.Size(200, 50);
            this.venMenu.TabIndex = 0;
            this.venMenu.Text = "Vendor";
            this.venMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // venTab
            // 
            this.venTab.Controls.Add(this.venView);
            this.venTab.Controls.Add(this.venSearch);
            this.venTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.venTab.Location = new System.Drawing.Point(202, 128);
            this.venTab.Name = "venTab";
            this.venTab.SelectedIndex = 0;
            this.venTab.Size = new System.Drawing.Size(618, 692);
            this.venTab.TabIndex = 2;
            // 
            // venView
            // 
            this.venView.Controls.Add(this.venVieData);
            this.venView.Location = new System.Drawing.Point(4, 22);
            this.venView.Name = "venView";
            this.venView.Padding = new System.Windows.Forms.Padding(3);
            this.venView.Size = new System.Drawing.Size(610, 666);
            this.venView.TabIndex = 0;
            this.venView.Text = "View";
            this.venView.UseVisualStyleBackColor = true;
            // 
            // venVieData
            // 
            this.venVieData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.venVieData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.venVieData.Location = new System.Drawing.Point(3, 3);
            this.venVieData.Name = "venVieData";
            this.venVieData.Size = new System.Drawing.Size(604, 660);
            this.venVieData.TabIndex = 0;
            // 
            // venSearch
            // 
            this.venSearch.Controls.Add(this.venSerData);
            this.venSearch.Controls.Add(this.venFilCombo);
            this.venSearch.Controls.Add(this.venSerBtn);
            this.venSearch.Controls.Add(this.venSerTex);
            this.venSearch.Location = new System.Drawing.Point(4, 22);
            this.venSearch.Name = "venSearch";
            this.venSearch.Padding = new System.Windows.Forms.Padding(3);
            this.venSearch.Size = new System.Drawing.Size(610, 666);
            this.venSearch.TabIndex = 1;
            this.venSearch.Text = "Search";
            this.venSearch.UseVisualStyleBackColor = true;
            // 
            // venSerData
            // 
            this.venSerData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.venSerData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.venSerData.Location = new System.Drawing.Point(0, 34);
            this.venSerData.Name = "venSerData";
            this.venSerData.Size = new System.Drawing.Size(610, 632);
            this.venSerData.TabIndex = 1;
            // 
            // venFilCombo
            // 
            this.venFilCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.venFilCombo.FormattingEnabled = true;
            this.venFilCombo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.venFilCombo.Location = new System.Drawing.Point(418, 5);
            this.venFilCombo.MaximumSize = new System.Drawing.Size(100, 0);
            this.venFilCombo.MinimumSize = new System.Drawing.Size(100, 0);
            this.venFilCombo.Name = "venFilCombo";
            this.venFilCombo.Size = new System.Drawing.Size(100, 23);
            this.venFilCombo.TabIndex = 2;
            // 
            // venSerBtn
            // 
            this.venSerBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.venSerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.venSerBtn.Location = new System.Drawing.Point(524, 5);
            this.venSerBtn.MaximumSize = new System.Drawing.Size(82, 23);
            this.venSerBtn.MinimumSize = new System.Drawing.Size(82, 23);
            this.venSerBtn.Name = "venSerBtn";
            this.venSerBtn.Size = new System.Drawing.Size(82, 23);
            this.venSerBtn.TabIndex = 1;
            this.venSerBtn.Text = "Search";
            this.venSerBtn.UseVisualStyleBackColor = true;
            this.venSerBtn.Click += new System.EventHandler(this.venSerBtn_Click);
            // 
            // venSerTex
            // 
            this.venSerTex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.venSerTex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.venSerTex.Location = new System.Drawing.Point(4, 5);
            this.venSerTex.MaximumSize = new System.Drawing.Size(520, 24);
            this.venSerTex.MinimumSize = new System.Drawing.Size(409, 24);
            this.venSerTex.Name = "venSerTex";
            this.venSerTex.Size = new System.Drawing.Size(409, 23);
            this.venSerTex.TabIndex = 0;
            // 
            // CitiSoft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 820);
            this.ControlBox = false;
            this.Controls.Add(this.venTab);
            this.Controls.Add(this.menuPan);
            this.Controls.Add(this.headPan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(820, 820);
            this.Name = "CitiSoft";
            this.Text = "CitiSoft";
            this.headPan.ResumeLayout(false);
            this.menuPan.ResumeLayout(false);
            this.venTab.ResumeLayout(false);
            this.venView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.venVieData)).EndInit();
            this.venSearch.ResumeLayout(false);
            this.venSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.venSerData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headPan;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Panel menuPan;
        private System.Windows.Forms.Label venMenu;
        private System.Windows.Forms.TabControl venTab;
        private System.Windows.Forms.TabPage venView;
        private System.Windows.Forms.TabPage venSearch;
        private System.Windows.Forms.DataGridView venVieData;
        private System.Windows.Forms.DataGridView venSerData;
        private System.Windows.Forms.Label softMenu;
        private System.Windows.Forms.TextBox venSerTex;
        private System.Windows.Forms.ComboBox venFilCombo;
        private System.Windows.Forms.Button venSerBtn;
        private System.Windows.Forms.Button maximizeBtn;
        private System.Windows.Forms.Button minimizeBtn;
    }
}

