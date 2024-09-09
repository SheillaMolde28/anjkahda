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
    public partial class frmnewaccount : Form
    {
        private string username;
        Class1 newaccount = new Class1(Program.Server, Program.Database, Program.Username, Program.Password);
        public frmnewaccount(String username)
        {
            InitializeComponent();
            this.username = username;   
        }
        private int errorcount;
        public void validateForm()
        {
            errorcount = 0;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtusername.Text))
            {
                errorProvider1.SetError(txtusername, "Input is empty");
                errorcount++;
            }
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
            if (cmbusertype.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbusertype, "Select usertype");
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
            try
            {
                DataTable dt = newaccount.GetData("SELECT * FROM tblaccounts WHERE username = '" + txtusername.Text + "'");
                if(dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtusername,"Username already in use.");
                    errorcount++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on validate existing username", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            validateForm();
            if (errorcount == 0)
            {
                try
                {
                    newaccount.executeSQL("INSERT INTO tblaccounts (username, password, usertype, email, status, createdby, datecreated) VALUES ('" + txtusername.Text + "', '" + txtpassword.Text + "', '" +
                         cmbusertype.Text.ToUpper() + "', '"+ txtemail.Text+ "', 'ACTIVE', '" + username + "', '" + DateTime.Now.ToShortDateString() + "')" );
                    if (newaccount.rowAffected > 0)
                    {
                        newaccount.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() +
                        "', 'Create', 'Accounts Management', '" + txtusername.Text + "', '" + username + "')");
                        MessageBox.Show("New account added.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error on save button", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtusername.Text = "";
            txtpassword.Text = "";
            cmbusertype.SelectedIndex = -1;
            txtemail.Text = "";
        }

    }
}
