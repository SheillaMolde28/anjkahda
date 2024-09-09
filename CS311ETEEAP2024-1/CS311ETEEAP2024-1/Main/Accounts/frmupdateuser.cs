using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS311ETEEAP2024_1
{
    public partial class frmupdateuser : Form
    {
        private string editusername, editpassword, editusertype, editemail, editstatus, username;
        Class1 updateaccount = new Class1(Program.Server, Program.Database, Program.Username, Program.Password);

        private int errorcount;
        public void validateForm()
        {
            errorcount = 0;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtpassword.Text))
            {
                errorProvider1.SetError(txtpassword, "Input is empty");
                errorcount++;
            }
            if (txtpassword.TextLength < 6)
            {
                errorProvider1.SetError(txtpassword, "Password should be at least 6 characters");
                errorcount++;
            }
            // Validate email
            if (string.IsNullOrEmpty(txtemail.Text))
            {
                errorProvider1.SetError(txtemail, "Email is required");
                errorcount++;
            }
            else if (!IsValidEmail(txtemail.Text))
            {
                errorProvider1.SetError(txtemail, "Invalid email format");
                errorcount++;
            }
            bool IsValidEmail(string email)
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            validateForm();
            if (errorcount == 0)
            {
                try
                {
                    DialogResult dr = MessageBox.Show("Update Account?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            updateaccount.executeSQL("UPDATE tblaccounts SET password = '" + txtpassword.Text + "', usertype = '" + cmbusertype.Text.ToUpper() + "', email = '"+ txtemail.Text +"', status = '" +
                                cmbstatus.Text.ToUpper() + "' WHERE username = '" + txtusername.Text + "'");
                            if (updateaccount.rowAffected > 0)
                            {
                                MessageBox.Show("Account Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                updateaccount.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() +
                                "', 'Update', 'Accounts Management', '" + txtusername.Text + "', '" + username + "')");
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

        public frmupdateuser(string editusername, string editpassword, string editusertype, string editemail, string editstatus, string username)
        {
            InitializeComponent();
            this.editusername = editusername;
            this.editpassword = editpassword;
            this.editusertype = editusertype;
            this.editemail= editemail;
            this.editstatus = editstatus;
            this.username = username;
        }

        private void frmupdateuser_Load(object sender, EventArgs e)
        {
            txtusername.Text = editusername;
            txtpassword.Text = editpassword;
            if (editusertype == "ADMINISTRATOR")
            {
                cmbusertype.SelectedIndex = 0;
            }
            else if (editusertype == "TECHNICAL")
            {
                cmbusertype.SelectedIndex = 1;
            }
            else
            {
                cmbusertype.SelectedIndex = 2;
            }
            txtemail.Text = editemail;
            if (editstatus == "ACTIVE")
            {
                cmbstatus.SelectedIndex = 0;
            }
            else
            {
                cmbstatus.SelectedIndex = 1;
            }
            txtusername.ReadOnly = true;
        }
    }
}
