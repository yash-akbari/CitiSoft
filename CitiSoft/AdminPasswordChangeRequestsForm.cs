using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
        // 
        // rejectButton
        // 
        this.btnDeny.Location = new System.Drawing.Point(93, 268);
        this.btnDeny.Name = "rejectButton";
        this.btnDeny.Size = new System.Drawing.Size(75, 23);
        this.btnDeny.TabIndex = 2;
        this.btnDeny.Text = "Reject";
        this.btnDeny.UseVisualStyleBackColor = true;
        this.btnDeny.Click += new System.EventHandler(this.btnDeny_Click);
        
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

    private void LoadPasswordChangeRequests()
    {
        string query = "SELECT uid, userName, newPwd FROM [User] WHERE pwdChangeStatus = 1";
        using (SqlConnection connection = new SqlConnection(DataBaseManager.functionalityConnectionString))
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvPasswordRequests.DataSource = dt;
        }
    }

    private void btnApprove_Click(object sender, EventArgs e)
    {
        if (dgvPasswordRequests.CurrentRow != null)
        {
            string userId = dgvPasswordRequests.CurrentRow.Cells["uid"].Value.ToString();
            UpdatePassword(userId, true);
        }
    }

    private void btnDeny_Click(object sender, EventArgs e)
    {
        if (dgvPasswordRequests.CurrentRow != null)
        {
            string userId = dgvPasswordRequests.CurrentRow.Cells["uid"].Value.ToString();
            UpdatePassword(userId, false);
        }
    }

    private void UpdatePassword(string userId, bool approve)
    {
        string query = approve
            ? "UPDATE [User] SET pwd = newPwd, newPwd = NULL, pwdChangeStatus = 0 WHERE uid = @uid"
            : "UPDATE [User] SET newPwd = NULL, pwdChangeStatus = 0 WHERE uid = @uid";

        using (SqlConnection connection = new SqlConnection(DataBaseManager.functionalityConnectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@uid", userId);
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show(approve ? "Password change approved." : "Password change denied.");
                    LoadPasswordChangeRequests();
                }
                else
                {
                    MessageBox.Show("Error updating the password change request.");
                }
            }
        }
    }


}
