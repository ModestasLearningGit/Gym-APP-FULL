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
    public partial class frmRemoveTime : Form
    {
        LogsBLL logsBLL = new LogsBLL();
        LogsDAL logsDAL = new LogsDAL();
        MemberBLL MemberBLL = new MemberBLL();
        memberDAL MemberDAL = new memberDAL();

        string imageName = "no-image.jpg";
        string sourcePath = "";
        string destinationPath = "";
        public frmRemoveTime()
        {
            InitializeComponent();
        }

        private void frmRemoveTime_Load(object sender, EventArgs e)
        {
            DataTable dt = MemberDAL.Select_RemoveTime();
            dgvTable.DataSource = dt;

            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 36);
            destinationPath = path + "Images\\" + imageName;
            pictureBox1.Image = new Bitmap(destinationPath);
        }

        private void dgvTable_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                txtID.Text = dgvTable.Rows[rowIndex].Cells[0].Value.ToString();
                imageName = dgvTable.Rows[rowIndex].Cells[1].Value.ToString();
                txtFirstName.Text = dgvTable.Rows[rowIndex].Cells[2].Value.ToString();
                txtLastName.Text = dgvTable.Rows[rowIndex].Cells[3].Value.ToString();
                txtValidTill.Text = dgvTable.Rows[rowIndex].Cells[4].Value.ToString();
                txtTimeLeft.Text = dgvTable.Rows[rowIndex].Cells[5].Value.ToString();

                string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 36);
                destinationPath = path + "Images\\" + imageName;
                pictureBox1.Image = new Bitmap(destinationPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            if (keyword != null)
            {
                DataTable dt = MemberDAL.search_RemoveTime(keyword);
                dgvTable.DataSource = dt;
            }
            else
            {
                DataTable dt = MemberDAL.Select_RemoveTime();
                dgvTable.DataSource = dt;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;
            int daysToRemove = 0;
            int daysLeft = 0;
            try
            {
                if (txtDaysToRemove.Text == "")
                {
                    MessageBox.Show("Please enter days to delete");
                }
                else
                {
                    daysToRemove = int.Parse(txtDaysToRemove.Text);
                }
                daysLeft = int.Parse(txtTimeLeft.Text);

                if(daysLeft <= 0)
                {
                    MessageBox.Show("No time to remove");
                }
                else
                {
                    DateTime dateTime1 = DateTime.Parse(txtValidTill.Text);
                    int newDaysLeft = daysLeft - daysToRemove;
                    if(newDaysLeft < 0)
                    {
                        newDaysLeft = 0;
                    }
                    DateTime newValidTill = dateTime1.AddDays(-daysToRemove);

                    MemberBLL.MID = int.Parse(txtID.Text);
                    MemberBLL.TimeLeft = newDaysLeft.ToString();
                    MemberBLL.TimeValid = newValidTill.ToString();

                    isSuccess = MemberDAL.updateTime_RemoveTime(MemberBLL);

                    if(isSuccess  == true)
                    {
                        MessageBox.Show("TIME REMOVED");
                        DataTable dt = new DataTable();
                        dt = MemberDAL.Select_RemoveTime(); 
                        dgvTable.DataSource = dt;
                        logsBLL.Info = "Time Removed from ID: " + txtID.Text + " Name: " + txtFirstName.Text + " " +
                        txtLastName.Text + ". Days removed: " + txtDaysToRemove.Text;
                        logsDAL.insertLog(logsBLL);
        
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("TIME FAILED TO REMOVE");
                    }
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Clear()
        {
            imageName = "no-image.jpg";
            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 36);
            destinationPath = path + "Images\\" + imageName;
            pictureBox1.Image = new Bitmap(destinationPath);

            txtID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtTimeLeft.Clear();
            txtValidTill.Clear();
            txtDaysToRemove.Clear();

            DataTable dt = MemberDAL.Select_RemoveTime();
            dgvTable.DataSource = dt;
        }
    }
}
