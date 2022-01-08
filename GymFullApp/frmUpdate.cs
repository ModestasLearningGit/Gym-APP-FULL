using GymFullApp.BLL;
using GymFullApp.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymFullApp
{
    public partial class frmUpdate : Form
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
        public frmUpdate()
        {
            InitializeComponent();
        }

        private void frmUpdate_Load(object sender, EventArgs e)
        {
           

            DataTable dt = MemberDAL.select_Update();
            dgvData.DataSource = dt;

            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 36);
            destinationPath = path + "Images\\" + imageName;
            pictureBox1.Image = new Bitmap(destinationPath);
        }

        private void dgvData_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                txtID.Text = dgvData.Rows[rowIndex].Cells[0].Value.ToString();
                imageName = dgvData.Rows[rowIndex].Cells[1].Value.ToString();
                txtFname.Text = dgvData.Rows[rowIndex].Cells[2].Value.ToString();
                txtLname.Text = dgvData.Rows[rowIndex].Cells[3].Value.ToString();
                oldName = txtFname.Text + " " + txtLname.Text;
                if (dgvData.Rows[rowIndex].Cells[4].Value.ToString() == "Male")
                {
                    rbMale.Checked = true;
                }
                else
                {
                    rbFemale.Checked = true;
                }
                txtEmail.Text = dgvData.Rows[rowIndex].Cells[5].Value.ToString();
                dtpDOB.Value = DateTime.Parse(dgvData.Rows[rowIndex].Cells[6].Value.ToString());
                txtAddress.Text = dgvData.Rows[rowIndex].Cells[7].Value.ToString();
                txtMobile.Text = dgvData.Rows[rowIndex].Cells[8].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                DataTable dt = MemberDAL.search_Update(keyword);
                dgvData.DataSource = dt;
            }
            else
            {
                DataTable dt = MemberDAL.afterAdd_Update();
                dgvData.DataSource = dt;
            }
        }

        private void btnSIMAGE_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files Only(*.jpg; *.jpeg; *.png; *.gif | *.jpg; *.jpeg; *.png; *.gif)";

            if (open.ShowDialog() == DialogResult.OK)
            {
                if (open.CheckFileExists)
                {
                    pictureBox1.Image = new Bitmap(open.FileName);

                    string ext = Path.GetExtension(open.FileName);
                    string name = Path.GetFileNameWithoutExtension(open.FileName);

                    Guid g = new Guid();
                    g = Guid.NewGuid();

                    imageName = "STRONG_GYM_" + name + g + ext;

                    sourcePath = open.FileName;

                    string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 36);
                    destinationPath = path + "Images\\" + imageName;

                    newImage = true;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string gender = "";
                MemberBLL.MID = int.Parse(txtID.Text);
                MemberBLL.ImageName = imageName;
                MemberBLL.Fname = txtFname.Text;
                MemberBLL.Lname = txtLname.Text;
                if (rbMale.Checked == true)
                {
                    MemberBLL.Gender = "Male";
                }
                else
                {
                    MemberBLL.Gender = "Female";
                }
                MemberBLL.Email = txtEmail.Text;
                MemberBLL.DOB = dtpDOB.Text;
                MemberBLL.Address = txtAddress.Text;
                MemberBLL.Mobile = txtMobile.Text;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            bool isSuccess = MemberDAL.Update_Upadate(MemberBLL);
            if(isSuccess == true)
            {
                MessageBox.Show("DATA UPDATED");
                if(newImage ==  true)
                {
                    string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 36);
                    destinationPath = path + "Images\\" + imageName;
                    File.Copy(sourcePath, destinationPath);
                }
                logsBLL.Info = "Member Info Updated Where ID: " + txtID.Text + " OldName: " + oldName + " newName: " +
                txtFname.Text + " " + txtLname.Text;
                logsDAL.insertLog(logsBLL);
                dgvData.DataSource = MemberDAL.afterAdd_Update();
            }
            else
            {
                MessageBox.Show("DATA UPDATE FAILED");
            }
            Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txtID.Clear();
            imageName = "no-image.jpg";
            txtFname.Clear();
            txtLname.Clear();
            rbMale.Checked = false;
            rbFemale.Checked = false;
            txtEmail.Clear();
            dtpDOB.Value = DateTime.Now;
            txtAddress.Clear();
            txtMobile.Clear();

            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 36);
            destinationPath = path + "Images\\" + imageName;
            pictureBox1.Image = new Bitmap(destinationPath);
            newImage = false;
        }
    }
}
