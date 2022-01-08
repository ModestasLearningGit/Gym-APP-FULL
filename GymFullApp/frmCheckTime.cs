using GymFullApp.BLL;
using GymFullApp.DAL;
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
    public partial class frmCheckTime : Form
    {
        LogsBLL logsBLL = new LogsBLL();
        LogsDAL logsDAL = new LogsDAL();
        MemberBLL MemberBLL = new MemberBLL();
        memberDAL MemberDAL = new memberDAL();

        string imageName = "no-image.jpg";
        bool newImage = false;
        string rowHeaderImage;
        string sourcePath = "";
        string destinationPath = "";
        public frmCheckTime()
        {
            InitializeComponent();
        }

        private void frmCheckTime_Load(object sender, EventArgs e)
        {
            DataTable dt = MemberDAL.select_CheckTime();
            dgvData.DataSource = dt;
            
            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 36);
            destinationPath = path + "Images\\" + imageName;
            pictureBox1.Image = new Bitmap(destinationPath);
        }

        private void dgvData_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtID.Text = dgvData.Rows[rowIndex].Cells[0].Value.ToString();
            imageName  = dgvData.Rows[rowIndex].Cells[1].Value.ToString();
            txtFirstName.Text = dgvData.Rows[rowIndex].Cells[2].Value.ToString();
            txtLastName.Text = dgvData.Rows[rowIndex].Cells[3].Value.ToString();
            txtTimeLeft.Text = dgvData.Rows[rowIndex].Cells[4].Value.ToString();

            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 36);
            destinationPath = path + "Images\\" + imageName;
            pictureBox1.Image = new Bitmap(destinationPath);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            if (keyword != null)
            {
                DataTable dt = MemberDAL.search_CheckTime(keyword);
                dgvData.DataSource = dt;
            }
            else
            {
                DataTable dt = MemberDAL.select_CheckTime();
                dgvData.DataSource = dt;
            }
        }
    }
}
