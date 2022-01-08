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
    public partial class frmAdminPanel : Form
    {
        public frmAdminPanel()
        {
            InitializeComponent();
        }
        private void frmAdminPanel_Load(object sender, EventArgs e)
        {
            lblShowAs.Text = Form1.LogedInAs;
            lblIsAdmin.Text = Form1.AdminAcitve;
        }

        private void pADDNEW_Click(object sender, EventArgs e)
        {
            frmManageUsers mu = new frmManageUsers();
            mu.Show();
        }

        private void pCheckLogs_Click(object sender, EventArgs e)
        {
            frmLogs logs = new frmLogs();
            logs.Show();
        }

      
    }
}
