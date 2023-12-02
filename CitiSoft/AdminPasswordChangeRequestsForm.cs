using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using CitiSoft;

public partial class AdminPasswordChangeRequestsForm : Form
{

    private DataGridView dgvPasswordRequests;
    private Button btnApprove;
    private Button btnDeny;

    public AdminPasswordChangeRequestsForm()
    {
        InitializeComponent();
        LoadPasswordChangeRequests();
    }

    private void InitializeComponent()
    {
        this.dgvPasswordRequests = new System.Windows.Forms.DataGridView();
        this.btnApprove = new System.Windows.Forms.Button();
        this.btnDeny = new System.Windows.Forms.Button();

        ((System.ComponentModel.ISupportInitialize)(this.dgvPasswordRequests)).BeginInit();
        this.SuspendLayout();

        // 
        // dgvPasswordRequests
        // 
        this.dgvPasswordRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvPasswordRequests.Location = new System.Drawing.Point(12, 12);
        this.dgvPasswordRequests.Name = "dgvPasswordRequests";
        this.dgvPasswordRequests.Size = new System.Drawing.Size(560, 250);
        this.dgvPasswordRequests.TabIndex = 0;
        // 
        // approveButton
        // 
        this.btnApprove.Location = new System.Drawing.Point(12, 268);
        this.btnApprove.Name = "approveButton";
        this.btnApprove.Size = new System.Drawing.Size(75, 23);
        this.btnApprove.TabIndex = 1;
        this.btnApprove.Text = "Approve";
        this.btnApprove.UseVisualStyleBackColor = true;
        this.btnApprove.Click += new System.EventHandler(this.BtnApprove_Click);
        // 
        // rejectButton
        // 
        this.btnDeny.Location = new System.Drawing.Point(93, 268);
        this.btnDeny.Name = "rejectButton";
        this.btnDeny.Size = new System.Drawing.Size(75, 23);
        this.btnDeny.TabIndex = 2;
        this.btnDeny.Text = "Reject";
        this.btnDeny.UseVisualStyleBackColor = true;
        this.btnDeny.Click += new System.EventHandler(this.BtnDeny_Click);
        
        // 
        // AdminPasswordChangeRequestsForm
        // 
        this.ClientSize = new System.Drawing.Size(584, 303);
        this.Controls.Add(this.btnDeny);
        this.Controls.Add(this.btnApprove);
        this.Controls.Add(this.dgvPasswordRequests);
        this.Name = "AdminPasswordChangeRequestsForm";
        this.Text = "Password Change Requests";

        ((System.ComponentModel.ISupportInitialize)(this.dgvPasswordRequests)).EndInit();
        this.ResumeLayout(false);
    }
    private void InitializeCustomComponents()
    {
        dgvPasswordRequests = new DataGridView
        {
            Dock = DockStyle.Fill,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };

        btnApprove = new Button
        {
            Text = "Approve",
            Dock = DockStyle.Top
        };
        btnApprove.Click += BtnApprove_Click;

        btnDeny = new Button
        {
            Text = "Deny",
            Dock = DockStyle.Top
        };
        btnDeny.Click += BtnDeny_Click;

        this.Controls.Add(dgvPasswordRequests);
        this.Controls.Add(btnApprove);
        this.Controls.Add(btnDeny);
    }
    private void LoadPasswordChangeRequests()
    {
        
        string query = "SELECT uid, fn, email, NewPassword FROM [User] WHERE PasswordChangeRequested = 1";
        using (SqlConnection connection = new SqlConnection(DataBaseManager.functionalityConnectionString))
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                    dgvPasswordRequests.DataSource = dt;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while accessing the database: " + ex.Message);
            }
        }
    }

    private void BtnApprove_Click(object sender, EventArgs e)
    {
        if (dgvPasswordRequests.CurrentRow != null)
        {
            string userId = dgvPasswordRequests.CurrentRow.Cells["uid"].Value.ToString();
            string newPassword = dgvPasswordRequests.CurrentRow.Cells["NewPassword"].Value.ToString();
            UpdateUserPassword(userId, newPassword, false);
        }
    }

    private void BtnDeny_Click(object sender, EventArgs e)
    {
        if (dgvPasswordRequests.CurrentRow != null)
        {
            string userId = dgvPasswordRequests.CurrentRow.Cells["uid"].Value.ToString();
            UpdateUserPassword(userId, null, true);
        }
    }

    private void UpdateUserPassword(string userId, string newPassword, bool denyRequest)
    {
        string query = denyRequest ?
            "UPDATE [User] SET PasswordChangeRequested = 0 WHERE uid = @UserId" :
            "UPDATE [User] SET pwd = @NewPassword, PasswordChangeRequested = 0 WHERE uid = @UserId";

        using (SqlConnection connection = new SqlConnection(DataBaseManager.functionalityConnectionString))
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    if (!denyRequest)
                    {
                        command.Parameters.AddWithValue("@NewPassword", newPassword);
                    }

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        string message = denyRequest ? "Password change request has been denied." : "Password has been updated.";
                        MessageBox.Show(message);
                        LoadPasswordChangeRequests(); // Refresh the list
                    }
                    else
                    {
                        MessageBox.Show("Failed to update the password change request.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while accessing the database: " + ex.Message);
            }
        }
    }

}
