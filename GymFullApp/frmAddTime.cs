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
    public partial class frmAddTime : Form
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
        string oldName = "";
        public frmAddTime()
        {
            InitializeComponent();
        }

        private void frmAddTime_Load(object sender, EventArgs e)
        {

            DataTable dt = MemberDAL.onLoadCalculate();
            dgvSearch.DataSource = dt;

            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 36);
            destinationPath = path + "Images\\" + imageName;
            pictureBox1.Image = new Bitmap(destinationPath); 

        }

        private void dgvSearch_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtID.Text = dgvSearch.Rows[rowIndex].Cells[0].Value.ToString();
            imageName = dgvSearch.Rows[rowIndex].Cells[1].Value.ToString();
            txtFirstName.Text = dgvSearch.Rows[rowIndex].Cells[2].Value.ToString();
            txtLastName.Text = dgvSearch.Rows[rowIndex].Cells[3].Value.ToString();
            txtValidTill.Text = dgvSearch.Rows[rowIndex].Cells[4].Value.ToString();
            txtTimeLeft.Text = dgvSearch.Rows[rowIndex].Cells[5].Value.ToString();
            newImage = false;
            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 36);
            destinationPath = path + "Images\\" + imageName;
            pictureBox1.Image = new Bitmap(destinationPath);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;

            if (keyword != null)
            {
                DataTable dt = MemberDAL.search(keyword);
                dgvSearch.DataSource = dt;
            }
            else
            {
                DataTable dt = MemberDAL.afterAdd();
                dgvSearch.DataSource = dt;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            txtID.Clear();
            imageName = "no-image.jpg";
            txtFirstName.Clear();
            txtLastName.Clear();
            txtTimeLeft.Clear();
            txtValidTill.Clear();

            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 36);
            destinationPath = path + "Images\\" + imageName;
            pictureBox1.Image = new Bitmap(destinationPath);

        }

        private void btnAddTime_Click(object sender, EventArgs e)
        {
            int monthToAdd = 0;
            bool isSuccess = false;

            if(cmbAddedTime.Text == "")
            {
                MessageBox.Show("PLEASE ADD TIME");
            }
            else
            {
                MemberBLL.MID = int.Parse(txtID.Text);
                MemberBLL.TimeValid = txtValidTill.Text;
                MemberBLL.TimeLeft = txtTimeLeft.Text;
 
                if (cmbAddedTime.Text == "1 Month")
                {
                    monthToAdd = 1;
                }
                else if(cmbAddedTime.Text == "3 Months")
                {
                    monthToAdd = 3;
                }
                else if(cmbAddedTime.Text == "6 Months")
                {
                    monthToAdd = 6;
                }
                else
                {
                    monthToAdd = 12;
                }
                isSuccess = MemberDAL.AddTimeForMembership(MemberBLL, monthToAdd);

                if(isSuccess)
                {
                    MessageBox.Show("Time added succesfully");
                    logsBLL.Info = "Added time to gym member: " + txtFirstName.Text + " " + txtLastName.Text + " TimeAdded: " + cmbAddedTime.Text;
                    logsDAL.insertLog(logsBLL);
                    dgvSearch.DataSource = MemberDAL.afterAdd();
                }
                else
                {
                    MessageBox.Show("Failed to add time");
                }
                Clear();
            }
        }
    }
}
