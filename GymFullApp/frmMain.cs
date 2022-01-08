using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymFullApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblShowAs.Text = Form1.LogedInAs;
            lblIsAdmin.Text = Form1.AdminAcitve;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlLOGOUT_Click(object sender, EventArgs e)
        {
            Form1 frmLogin = new Form1();
            frmLogin.Show();
            this.Hide();
        }
        private void label6_Click(object sender, EventArgs e)
        {
            Form1 frmLogin = new Form1();
            frmLogin.Show();
            this.Hide();
        }

        private void pnlEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlADMINPANEL_Click(object sender, EventArgs e)
        {
            if(lblIsAdmin.Text == "TRUE")
            {
                frmAdminPanel apanel = new frmAdminPanel();
                apanel.Show();
            }
            else
            {
                MessageBox.Show("YOU DONT HAVE ADMINS PREMMISION");
            }
        }

        private void pADDNEW_Click(object sender, EventArgs e)
        {
            frmAdd fadd = new frmAdd();
            fadd.Show();
        }

        private void pADDTIME_Click(object sender, EventArgs e)
        {
            frmAddTime frmAddTime = new frmAddTime();
            frmAddTime.Show();
        }

        private void pnlCheckTime_Click(object sender, EventArgs e)
        {
            frmCheckTime frmCT = new frmCheckTime();
            frmCT.Show();
        }

        private void pnlUpdateInfo_Click(object sender, EventArgs e)
        {
            frmUpdate frmU = new frmUpdate();
            frmU.Show();
        }

        private void pnlRemoveMember_Click(object sender, EventArgs e)
        {
            frmRemove frmRemoveMember = new frmRemove();
            frmRemoveMember.Show();
        }

        private void pnlRemoveTime_Click(object sender, EventArgs e)
        {
            frmRemoveTime frmRT = new frmRemoveTime();
            frmRT.Show();
        }
    }
}
