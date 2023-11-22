namespace CitiSoft
{
    partial class VendorDocsUI 
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
            this._vendorDocsGridView = new System.Windows.Forms.DataGridView();
            this._statusLabel = new System.Windows.Forms.Label();
            this._searchTextBox = new System.Windows.Forms.TextBox();
            this._searchButton = new System.Windows.Forms.Button();
            this._accessButton = new System.Windows.Forms.Button();
            this._removeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._vendorDocsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _vendorDocsGridView
            // 
            this._vendorDocsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._vendorDocsGridView.Location = new System.Drawing.Point(98, 109);
            this._vendorDocsGridView.Name = "_vendorDocsGridView";
            this._vendorDocsGridView.Size = new System.Drawing.Size(525, 281);
            this._vendorDocsGridView.TabIndex = 0;
            // 
            // _statusLabel
            // 
            this._statusLabel.AutoSize = true;
            this._statusLabel.Location = new System.Drawing.Point(95, 478);
            this._statusLabel.Name = "_statusLabel";
            this._statusLabel.Size = new System.Drawing.Size(35, 13);
            this._statusLabel.TabIndex = 1;
            this._statusLabel.Text = "label1";
            this._statusLabel.Click += new System.EventHandler(this._statusLabel_Click);
            // 
            // _searchTextBox
            // 
            this._searchTextBox.Location = new System.Drawing.Point(98, 72);
            this._searchTextBox.Name = "_searchTextBox";
            this._searchTextBox.Size = new System.Drawing.Size(432, 20);
            this._searchTextBox.TabIndex = 2;
            // 
            // _searchButton
            // 
            this._searchButton.Location = new System.Drawing.Point(548, 72);
            this._searchButton.Name = "_searchButton";
            this._searchButton.Size = new System.Drawing.Size(75, 23);
            this._searchButton.TabIndex = 3;
            this._searchButton.Text = "Search";
            this._searchButton.UseVisualStyleBackColor = true;
            // 
            // _accessButton
            // 
            this._accessButton.Location = new System.Drawing.Point(98, 407);
            this._accessButton.Name = "_accessButton";
            this._accessButton.Size = new System.Drawing.Size(75, 23);
            this._accessButton.TabIndex = 4;
            this._accessButton.Text = "Access";
            this._accessButton.UseVisualStyleBackColor = true;
            // 
            // _removeButton
            // 
            this._removeButton.Location = new System.Drawing.Point(548, 407);
            this._removeButton.Name = "_removeButton";
            this._removeButton.Size = new System.Drawing.Size(75, 23);
            this._removeButton.TabIndex = 5;
            this._removeButton.Text = "Remove";
            this._removeButton.UseVisualStyleBackColor = true;
            // 
            // VendorDocsUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 539);
            this.Controls.Add(this._removeButton);
            this.Controls.Add(this._accessButton);
            this.Controls.Add(this._searchButton);
            this.Controls.Add(this._searchTextBox);
            this.Controls.Add(this._statusLabel);
            this.Controls.Add(this._vendorDocsGridView);
            this.Name = "VendorDocsUI";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._vendorDocsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _vendorDocsGridView;
        private System.Windows.Forms.Label _statusLabel;
        private System.Windows.Forms.TextBox _searchTextBox;
        private System.Windows.Forms.Button _searchButton;
        private System.Windows.Forms.Button _accessButton;
        private System.Windows.Forms.Button _removeButton;
    }
}