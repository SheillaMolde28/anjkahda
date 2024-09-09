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
    public partial class frmnewequipment : Form
    {
      
        private string username;
        Class1 newequipment = new Class1(Program.Server, Program.Database, Program.Username, Program.Password);
        public frmnewequipment(String username)
        {
            InitializeComponent();
            this.username = username;
        }
        private int errorcount;
        public void validateForm()
        {
            errorcount = 0;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtassetnumber.Text))
            {
                errorProvider1.SetError(txtassetnumber, "Input is empty");
                errorcount++;
            }
            if (string.IsNullOrEmpty(txtserialnumber.Text))
            {
                errorProvider1.SetError(txtserialnumber, "Input is empty");
                errorcount++;
            }
            if (cmbtype.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbtype, "Select type");
                errorcount++;
            }
            if (string.IsNullOrEmpty(txtmanufacturer.Text))
            {
                errorProvider1.SetError(txtmanufacturer, "Input is empty");
                errorcount++;
            }
            if (string.IsNullOrEmpty(txtyearmodel.Text))
            {
                errorProvider1.SetError(txtyearmodel, "Input is empty");
                errorcount++;
            }
            if (txtyearmodel.Text.Length != 4)
            {
                errorProvider1.SetError(txtyearmodel, "Please enter a 4-digit year.");
                errorcount++;
            }
            if (cmbbranch.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbbranch, "Select branch");
                errorcount++;
            }
            if (cmbdepartment.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbdepartment, "Select department");
                errorcount++;
            }
            try
            {
                DataTable dt = newequipment.GetData("SELECT * FROM tblequipments WHERE assetnumber = '" + txtassetnumber.Text + "' OR serialnumber = '" + txtserialnumber.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["assetnumber"].ToString() == txtassetnumber.Text)
                    {
                        errorProvider1.SetError(txtassetnumber, "Asset number already in use.");
                    }

                    if (dt.Rows[0]["serialnumber"].ToString() == txtserialnumber.Text)
                    {
                        errorProvider1.SetError(txtserialnumber, "Serial number already in use.");
                    }
                    errorcount++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on validate existing username", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtyearmodel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnaddequipment_Click(object sender, EventArgs e)
        {
            validateForm();
            if (errorcount == 0)
            {
                try
                {
                    newequipment.executeSQL("INSERT INTO tblequipments (assetnumber, serialnumber, type, manufacturer, yearmodel, description, branch, department, status, createdby, datecreated) " +
                        "VALUES ('" +
                            txtassetnumber.Text + "', '" +
                            txtserialnumber.Text + "', '" +
                            cmbtype.Text + "', '" +
                            txtmanufacturer.Text + "', '" +
                            txtyearmodel.Text + "', '" +
                            txtdescription.Text + "', '" +
                            cmbbranch.Text + "', '" +
                            cmbdepartment.Text +
                            "', 'WORKING', '" +
                            username + "', '" +
                            DateTime.Now.ToShortDateString() +
                        "')");
                    if (newequipment.rowAffected > 0)
                    {
                        newequipment.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() +
                        "', 'Create', 'Equipments Management', '" + txtassetnumber.Text + "', '" + username + "')");
                        MessageBox.Show("New equipment added.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error on save button", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnclearaddequipment_Click(object sender, EventArgs e)
        {
            txtassetnumber.Text = "";
            txtserialnumber.Text = "";
            txtmanufacturer.Text = "";
            txtyearmodel.Text = "";
            txtdescription.Text = "";
            cmbtype.SelectedIndex = -1;
            cmbbranch.SelectedIndex = -1;
            cmbdepartment.SelectedIndex = -1;
        }

        private void frmnewequipment_Load(object sender, EventArgs e)
        {
            cmbtype.Items.AddRange(new string[] {
                "Monitor", "CPU", "Keyboard", "Mouse", "AVR", "MAC", "Printer", "Projector"
            });

            cmbbranch.Items.AddRange(new string[] {
                "Main Campus, AU Legarda",
                "Jose Abad Santos, AU Pasay",
                "Andres Bonifacio, AU Pasig",
                "Jose Rizal Campus, AU Malabon",
                "Apolinario Mabini Campus, AU Pasay",
                "Elisa Esguerra Campus, AU Malabon",
                "Plaridel Campus, AU Mandaluyong",
                "School of Law (A. Mabini Campus), AU Pasay"
            });

            cmbdepartment.Items.AddRange(new string[] {
                "Corporate Planning Office",
                "Research and Publications Department",
                "ETEEAP",
                "International Academic Linkages",
                "TESDA Programs",
                "Quality Assurance",
                "Accreditation",
                "Office of Student Affairs",
                "Office of the Occupational Safety & Health Standards",
                "Alumni Service & Placement Office",
                "Office of Community Development",
                "University Physician",
                "University Librarian",
                "Chief Bursar"
            });
        }
    }
}
