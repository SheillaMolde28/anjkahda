using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CS311ETEEAP2024_1
{
    public partial class frmupdateequipment : Form
    {
        private string assetnumber, editserialnumber, edittype, editmanufacturer, edityearmodel, editdescription, editbranch, editdepartment, editstatus, username;
        Class1 updateequipment = new Class1(Program.Server, Program.Database, Program.Username, Program.Password);

        public frmupdateequipment(string assetnumber, string editserialnumber, string edittype, string editmanufacturer, string edityearmodel, string editdescription, string editbranch, string editdepartment, string editstatus, string username)
        {
            InitializeComponent();
            this.assetnumber = assetnumber;
            this.editserialnumber = editserialnumber;
            this.edittype = edittype; 
            this.editmanufacturer = editmanufacturer;
            this.edityearmodel = edityearmodel;
            this.editdescription = editdescription;
            this.editbranch = editbranch;
            this.editdepartment = editdepartment;
            this.editstatus = editstatus;
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
            if (txtyearmodel.Text.Length != 4)
            {
                errorProvider1.SetError(txtyearmodel, "Please enter a 4-digit year.");
                errorcount++;
            }
            if (string.IsNullOrEmpty(txtyearmodel.Text))
            {
                errorProvider1.SetError(txtyearmodel, "Input is empty");
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
                DataTable dt = updateequipment.GetData("SELECT * FROM tblequipments WHERE (assetnumber = '" + assetnumber + "' OR serialnumber = '" + txtserialnumber.Text + "') AND serialnumber <> '" + editserialnumber + "'");
                if (dt.Rows.Count > 0)
                {
                    string rowSerialNumber = dt.Rows[0]["serialnumber"].ToString();
                    if (rowSerialNumber == txtserialnumber.Text)
                    {
                        errorProvider1.SetError(txtserialnumber, "Serial number already in use.");
                    }
                    errorcount++;
                        
                }       
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on validate existing serial number", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtyearmodel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnequipmentsave_Click(object sender, EventArgs e)
        {
            validateForm();
            if (errorcount == 0)
            {
                try
                {
                    DialogResult dr = MessageBox.Show("Update Equipment?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            updateequipment.executeSQL("UPDATE tblequipments SET " +
                                    "serialnumber = '" + txtserialnumber.Text +
                                    "', type = '" + cmbtype.Text +
                                    "', manufacturer = '" + txtmanufacturer.Text +
                                    "', yearmodel = '" + txtyearmodel.Text+
                                    "', description = '" + txtdescription.Text +
                                    "', branch = '" + cmbbranch.Text+
                                    "', department = '" + cmbdepartment.Text+
                                    "', status = '" + cmbstatus.Text.ToUpper()+
                                    "' WHERE assetnumber = '" + assetnumber + "'");
                                      
                            if (updateequipment.rowAffected > 0)
                            {
                                MessageBox.Show("Equipment Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                updateequipment.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() +
                                "', 'Update', 'Equipments Management', '" + assetnumber + "', '" + username + "')");
                                this.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error on save button", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error on save button", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnequipmentclear_Click(object sender, EventArgs e)
        {
            txtassetnumber.Text = assetnumber; 
            txtserialnumber.Text = editserialnumber; 
            txtmanufacturer.Text = editmanufacturer; 
            txtyearmodel.Text = edityearmodel; 
            txtdescription.Text = editdescription;

            SelectComboBoxItem(cmbtype, edittype);
            SelectComboBoxItem(cmbbranch, editbranch); 
            SelectComboBoxItem(cmbdepartment, editdepartment); 
            SelectComboBoxItem(cmbstatus, editstatus); 

            txtassetnumber.Focus();
        }

        private void frmupdateequipment_Load(object sender, EventArgs e)
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

            cmbstatus.Items.AddRange(new string[] {
                "Working",
                "On-Repair",
                "Retired"
            });

            txtassetnumber.Text = assetnumber;
            txtserialnumber.Text = editserialnumber;
            txtmanufacturer.Text = editmanufacturer;
            txtyearmodel.Text = edityearmodel;
            txtdescription.Text = editdescription;

            SelectComboBoxItem(cmbtype, edittype);
            SelectComboBoxItem(cmbbranch, editbranch);
            SelectComboBoxItem(cmbdepartment, editdepartment);
            SelectComboBoxItem(cmbstatus, editstatus);
        }
        private void SelectComboBoxItem(ComboBox comboBox, string value)
        {
            bool found = false;

            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (string.Equals(comboBox.Items[i].ToString(), value, StringComparison.OrdinalIgnoreCase))
                {
                    comboBox.SelectedIndex = i;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                comboBox.SelectedIndex = -1;
            }
        }
    }
}
