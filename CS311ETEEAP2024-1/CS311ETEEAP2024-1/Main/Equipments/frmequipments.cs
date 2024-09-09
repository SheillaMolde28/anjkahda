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

namespace CS311ETEEAP2024_1
{
    public partial class frmequipments : Form
    {
        private string username, usertype;
        Class1 equipments = new Class1(Program.Server, Program.Database, Program.Username, Program.Password);
        public frmequipments(String username, String usertype)
        {
            InitializeComponent();
            this.username = username;
            this.usertype = usertype;
        }
        private void frmequipments_Load(object sender, EventArgs e)
        {
            if(usertype == "USER")
            {
                btnadd.Enabled = false;
                btnupdate.Enabled = false;
                btndelete.Enabled = false;
            }
            {
                try
                {
                    DataTable dt = equipments.GetData("SELECT assetnumber, serialnumber, type, branch, department, status FROM tblequipments ORDER BY assetnumber");
                    equipmentDataGridView.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error on equipments load", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtsearch_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = equipments.GetData("SELECT assetnumber, serialnumber, type, branch, department, status FROM tblequipments WHERE "+
                    " (assetnumber LIKE '%" + txtsearch.Text + 
                    "%' OR serialnumber LIKE '%" + txtsearch.Text + 
                    "%' OR type LIKE '%" + txtsearch.Text + 
                    "%' OR branch LIKE '% " + txtsearch.Text + 
                    "%'  OR department LIKE '%" + txtsearch.Text + 
                    "%' OR status LIKE '%" + txtsearch.Text + 
                    "%') ORDER BY assetnumber");
                equipmentDataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on search", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnrefresh_Click_1(object sender, EventArgs e)
        {
            frmequipments_Load(sender, e);
        }

        private void btnadd_Click_1(object sender, EventArgs e)
        {
            frmnewequipment newequipment = new frmnewequipment(username);
            newequipment.Show();

        }

        private void btndelete_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Delete Equipment?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    string selectedEquipment = equipmentDataGridView.Rows[row].Cells[0].Value.ToString();
                    equipments.executeSQL("DELETE FROM tblequipments WHERE assetnumber = '" + selectedEquipment + "'");
                    if (equipments.rowAffected > 0)
                    {
                        MessageBox.Show("Equipment Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        equipments.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() +
                        "', 'Delete', 'Equipments Management', '" + selectedEquipment + "', '" + username + "')");
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

        private void equipmentsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void btnupdate_Click_1(object sender, EventArgs e)
        {
            if (equipmentDataGridView.SelectedRows.Count > 0)
            {
                int rowIndex = equipmentDataGridView.SelectedRows[0].Index;

                string assetnumber = equipmentDataGridView.Rows[rowIndex].Cells["assetnumber"].Value.ToString();

                string query = "SELECT assetnumber, serialnumber, type, manufacturer, yearmodel, description, branch, department, status " +
                               "FROM tblequipments WHERE assetnumber = '"+ assetnumber +"'";

                DataTable dt = new DataTable();
                dt = equipments.GetData(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    string serialnumber = row["serialnumber"].ToString();
                    string type = row["type"].ToString();
                    string manufacturer = row["manufacturer"].ToString();
                    string yearmodel = row["yearmodel"].ToString();
                    string description = row["description"].ToString();
                    string branch = row["branch"].ToString();
                    string department = row["department"].ToString();
                    string status = row["status"].ToString();

                    frmupdateequipment updateequipment = new frmupdateequipment(
                        assetnumber,
                        serialnumber,
                        type,
                        manufacturer,
                        yearmodel,
                        description,
                        branch,
                        department,
                        status,
                        username
                    );

                    updateequipment.Show();
                }
                else
                {
                    MessageBox.Show("No details found for the selected asset number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
