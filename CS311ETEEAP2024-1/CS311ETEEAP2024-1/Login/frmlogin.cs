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
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
            txtusername.Text = "";
            txtpassword.Text = "";
        }
        Class1 login = new Class1(Program.Server, Program.Database, Program.Username, Program.Password);
        private void validateUsername()
        {
            if (string.IsNullOrEmpty(txtusername.Text))
            {
                errorProvider1.SetError(txtusername, "Input is empty");
            }
            else
            {
                errorProvider1.SetError(txtusername, "");
            }
        }
        private void validatePassword()
        {
            if (string.IsNullOrEmpty(txtpassword.Text))
            {
                errorProvider1.SetError(txtpassword, "Input is empty");
            }
            else
            {
                errorProvider1.SetError(txtpassword, "");
            }
        }
        private int errorcount;
        private void countErrors()
        {
            errorcount = 0;
            foreach (Control c in errorProvider1.ContainerControl.Controls)
            {
                if (!(string.IsNullOrEmpty(errorProvider1.GetError(c))))
                {
                    errorcount++;
                }
            }
        }

        private void doLogin()
        {
            //validations
            validateUsername();
            validatePassword();
            countErrors();
            //process and output
            if (errorcount == 0)
            {
                try
                {
                    string username = txtusername.Text;
                    string password = txtpassword.Text;
                    DataTable dt = login.GetData("SELECT * FROM tblaccounts WHERE username = '" + username + "' AND password = '" + password + "' AND status = 'ACTIVE'");
                    if (dt.Rows.Count > 0)
                    {
                        frmmain mainform = new frmmain(txtusername.Text, dt.Rows[0].Field<string>("usertype"));
                        mainform.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect account credentials or account is inactive", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error on login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            doLogin();
        }

        private void cbshow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbshow.Checked)
            {
                txtpassword.PasswordChar = '\0'; 
            }
            else
            {
                txtpassword.PasswordChar = '*'; 
            }
        }

        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                doLogin();
            }
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                doLogin();

            }
        }
    }
}
