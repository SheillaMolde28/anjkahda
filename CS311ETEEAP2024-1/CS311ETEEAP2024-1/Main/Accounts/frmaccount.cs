using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS311ETEEAP2024_1
{
    public partial class frmaccount : Form
    {
        private string username;
        Class1 accounts = new Class1(Program.Server, Program.Database, Program.Username, Program.Password);
        public frmaccount(String username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void frmaccount_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = accounts.GetData("SELECT username, password, usertype, email, status, createdby, datecreated  FROM tblaccounts WHERE username <> '" + username + "' ORDER BY username");
                accountDataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on accounts load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = accounts.GetData("SELECT username, password, usertype, email, status, createdby, datecreated  FROM tblaccounts WHERE username <> '" + username +
                    "' AND (username LIKE '%" + txtsearch.Text + "%' OR usertype LIKE '%" + txtsearch.Text + "%') ORDER BY username");
                accountDataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on search", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            frmaccount_Load(sender, e);
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            frmnewaccount newaccount = new frmnewaccount(username);
            newaccount.Show();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Delete Account?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    string selectedUser = accountDataGridView.Rows[row].Cells[0].Value.ToString();
                    accounts.executeSQL("DELETE FROM tblaccounts WHERE username = '" +selectedUser + "'");
                    if (accounts.rowAffected > 0)
                    {
                        MessageBox.Show("Account Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        accounts.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() +
                        "', 'Delete', 'Accounts Management', '" + selectedUser + "', '" + username + "')");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error on delete button",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private int row;

        private void accountDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < accountDataGridView.Rows.Count)
            {
                row = e.RowIndex;
            }
            else
            {
                row = -1;
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (row >= 0 && row < accountDataGridView.Rows.Count)
            {
                string editusername = accountDataGridView.Rows[row].Cells[0].Value?.ToString() ?? string.Empty;
                string editpassword = accountDataGridView.Rows[row].Cells[1].Value?.ToString() ?? string.Empty;
                string editusertype = accountDataGridView.Rows[row].Cells[2].Value?.ToString() ?? string.Empty;
                string editemail = accountDataGridView.Rows[row].Cells[3].Value?.ToString() ?? string.Empty;
                string editstatus = accountDataGridView.Rows[row].Cells[4].Value?.ToString() ?? string.Empty;

                frmupdateuser updateaccount = new frmupdateuser(editusername, editpassword, editusertype, editemail, editstatus, username);
                updateaccount.Show();
            }
            else
            {
                MessageBox.Show("Please select a valid row from the data grid.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}