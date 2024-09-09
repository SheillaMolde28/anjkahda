using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS311ETEEAP2024_1
{
    public partial class frmlogs : Form
    {
        private string username, usertype;
        Class1 logs = new Class1(Program.Server, Program.Database, Program.Username, Program.Password);
        public frmlogs(String username, String usertype)
        {
            InitializeComponent();
            this.username = username;
            this.usertype = usertype;
        }

        private void loadDataTable()
        {
            if(usertype != "ADMINISTRATOR")
            {
                btnclear.Enabled = false;
            }
            try
            {
                DataTable dt = logs.GetData("SELECT datelog, timelog, ID, performedby, action, module " +
                                            "FROM tbllogs " +
                                            "ORDER BY CAST(CONCAT(datelog, ' ', timelog) AS DATETIME) DESC");
                dt.DefaultView.Sort = "datelog DESC, timelog DESC";
                logsDataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on logs load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmlogs_Load(object sender, EventArgs e)
        {
            loadDataTable();
        }


        private void btnclear_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Clear all logs (This action is irreversible)?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    logs.executeSQL("DELETE FROM tbllogs");
                    if (logs.rowAffected > 0)
                    {
                        logs.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() +
                        "', 'Clear Logs', 'Logs Management', 'All', '" + username + "')");
                        MessageBox.Show("All logs have been cleared.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDataTable();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error on clear button", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private int row;
     
        private void logsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                row = (int)e.RowIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on datagrid cell click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
