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
    public partial class frmmain : Form
    {
        private string username, usertype;
        public frmmain(String username, String usertype)
        {
            InitializeComponent();
            this.username = username;
            this.usertype = usertype;
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmaccount accounts = new frmaccount(username);
            accounts.MdiParent = this;
            accounts.Show();
        }

        private void equipmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmequipments equipments = new frmequipments(username, usertype);
            equipments.MdiParent = this;
            equipments.Show();
        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmlogs logs = new frmlogs(username, usertype);
            logs.MdiParent = this;
            logs.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to Logout?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                // Create the login form instance
                frmlogin login = new frmlogin();
                login.Show();

                // Close all open forms except the login form
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm != login)  // Do not close the login form
                    {
                        frm.Hide();
                    }
                }
            }
        }


        private void frmmain_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is MdiClient mdiClient)
                {
                    // Set the background image
                    mdiClient.BackgroundImage = Properties.Resources.bg; // Update the path to your image
                    this.BackgroundImageLayout = ImageLayout.Stretch; // Set the layout as needed
                    break;
                }
            }
            toolStripStatusLabel1.Text = "Username: " + username;
            toolStripStatusLabel2.Text = "Usertype: " + usertype;
            if (usertype == "ADMINISTRATOR")
            {
                accountsToolStripMenuItem.Enabled = true;
                equipmentsToolStripMenuItem.Enabled = true;
                logsToolStripMenuItem.Enabled = true;
            }
            else if (usertype == "TECHNICAL")
            {
                accountsToolStripMenuItem.Enabled = false;
                equipmentsToolStripMenuItem.Enabled = true;
                logsToolStripMenuItem.Enabled = false;
            }
            else
            {
                accountsToolStripMenuItem.Enabled = false;
                equipmentsToolStripMenuItem.Enabled = true;
                logsToolStripMenuItem.Enabled = false;
            }
        }
    }
}
