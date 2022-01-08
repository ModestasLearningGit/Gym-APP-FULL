using GymFullApp.BLL;
using GymFullApp.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymFullApp
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }
        UserBLL userBLL = new UserBLL();
        UserDAL userDAL = new UserDAL();
        LogsBLL logsBLL = new LogsBLL();
        LogsDAL logsDAL = new LogsDAL();

        string imageName = "no-image.jpg";
        bool newImage = false;
        string rowHeaderImage;
        string sourcePath = "";
        string destinationPath = "";
        string oldUserName = "";

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            lblShowAs.Text = Form1.LogedInAs;
            lblIsAdmin.Text = Form1.AdminAcitve;

            DataTable dt = userDAL.Select();
            dgvUsers.DataSource = dt;

            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 36);
            destinationPath = path + "Images\\" + imageName;
            pictureBox1.Image = new Bitmap(destinationPath);
        }

        private void btnSIMAGE_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files Only(*.jpg; *.jpeg; *.png; *.gif | *.jpg; *.jpeg; *.png; *.gif)";

            if(open.ShowDialog() == DialogResult.OK)
            {
                if(open.CheckFileExists)
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

        private void btnADD_Click(object sender, EventArgs e)
        {

           
            bool isSuccess = false;

            userBLL.ImageName = imageName;
            userBLL.Username = txtUserName.Text;
            userBLL.Password = txtUserPass.Text;
            if (cmbIsAdmin.Text ==  "TRUE")
            {
                userBLL.AdminStatus = 1;
            }
            else
            {
                userBLL.AdminStatus = 0;
            }
            userBLL.Comment = txtComment.Text;

            isSuccess = userDAL.Insert(userBLL);

            if(isSuccess == true)
            {
                if (imageName != "no-image.jpg")
                {
                    File.Copy(sourcePath, destinationPath);
                }
                MessageBox.Show("RECORD INSERTED SUCCESFULLY");
            }
            else
            {
                MessageBox.Show("RECORD FAILED TO INSERT");
            }
            logsBLL.Info = "Added new user: " + txtUserName.Text + " Admin Status: "+ cmbIsAdmin.Text +" Added By: "+ lblShowAs.Text;
            logsDAL.insertLog(logsBLL);
            Clear();
        }

       

        private void dgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            try
            {
                txtUserID.Text = dgvUsers.Rows[rowIndex].Cells[0].Value.ToString();
                imageName = dgvUsers.Rows[rowIndex].Cells[1].Value.ToString();
                rowHeaderImage = imageName;
                txtUserName.Text = dgvUsers.Rows[rowIndex].Cells[2].Value.ToString();
                txtUserPass.Text = dgvUsers.Rows[rowIndex].Cells[3].Value.ToString();
                if (int.Parse(dgvUsers.Rows[rowIndex].Cells[4].Value.ToString()) > 0)
                {
                    cmbIsAdmin.Text = "TRUE";
                }
                else
                {
                    cmbIsAdmin.Text = "FALSE";
                }
                txtComment.Text = dgvUsers.Rows[rowIndex].Cells[5].Value.ToString();
                newImage = false;
                oldUserName = dgvUsers.Rows[rowIndex].Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 36);
                destinationPath = path + "Images\\" + imageName;
                pictureBox1.Image = new Bitmap(destinationPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUPDATE_Click(object sender, EventArgs e)
        {
            int adminStatus = 0;
            bool isSuccess = false;

            userBLL.AID = int.Parse(txtUserID.Text);
            userBLL.ImageName = imageName;
            userBLL.Username = txtUserName.Text;
            userBLL.Password = txtUserPass.Text;

            if(cmbIsAdmin.Text == "TRUE")
            {
                userBLL.AdminStatus = 1;
            }
            else
            {
                userBLL.AdminStatus = 0;
            }
            userBLL.Comment = txtComment.Text;
            if (userBLL.Username == "Admin")
            {
                MessageBox.Show("CANNOT CHANGE MAIN ADMIN PARAMETERS");
            }
            else
            {
                isSuccess = userDAL.Update(userBLL);

                if(isSuccess == true)
                {
                    logsBLL.Info = "Updated staff member: "+oldUserName+ " New username: " + txtUserName.Text + " Admin Status: " + cmbIsAdmin.Text + " Added By: " + lblShowAs.Text;
                    logsDAL.insertLog(logsBLL);
                    MessageBox.Show("DATA UPDATED");
                    if(newImage == true)
                    {
                        string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 36);
                        destinationPath = path + "Images\\" + imageName;

                        File.Copy(sourcePath, destinationPath);
                        
                 
                    }
                    Clear();
                    DataTable dt = userDAL.Select();
                    dgvUsers.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("DATA FAILED TO UPDATE");
                }
            }
            

        }
        private void btnDELETE_Click(object sender, EventArgs e)
        {

            if(txtUserID.Text != "")
            {
                userBLL.AID = int.Parse(txtUserID.Text);

                if (lblShowAs.Text == txtUserName.Text)
                {
                    MessageBox.Show("CANT DELETE YOURSELF");
                }
                else if (txtUserName.Text == "Admin")
                {
                    MessageBox.Show("CANT DELETE MAIN ADMIN ACCOUNT");
                }
                else
                {
                    bool isSucess = userDAL.Delete(userBLL);

                    if (isSucess == true)
                    {
                        if (imageName != "no-image.jpg")
                        {
                            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 36);
                            destinationPath = path + "Images\\" + imageName;
                            string NoImageDestinationPath = path + "Images\\" + "no-image.jpg";
                            pictureBox1.Image = new Bitmap(NoImageDestinationPath);

                            GC.Collect();
                            GC.WaitForPendingFinalizers();

                            if (File.Exists(destinationPath))
                            {
                                File.Delete(destinationPath);
                            }
                            
                        }
                        MessageBox.Show("USER DELETED SUCCESFULLY");
                        logsBLL.Info = "Deleted staff member: " + txtUserName.Text + " Admin Status: " + cmbIsAdmin.Text + " Added By: " + lblShowAs.Text;
                        logsDAL.insertLog(logsBLL);
                        Clear();
                        DataTable dt = userDAL.Select();
                        dgvUsers.DataSource = dt;
                    }
                }
            }
           

            
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            DataTable dt = new DataTable();
            if(keyword != null)
            {
                dt = userDAL.Search(keyword);
                dgvUsers.DataSource = dt;
            }
            else
            {
                dt = userDAL.Select();
                dgvUsers.DataSource = dt;
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txtUserID.Clear();
            txtUserName.Clear();
            txtUserPass.Clear();
            txtComment.Clear();

            DataTable dt = userDAL.Select();
            dgvUsers.DataSource = dt;

            imageName = "no-image.jpg";

            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 36);
            destinationPath = path + "Images\\" + imageName;
            pictureBox1.Image = new Bitmap(destinationPath);
        }

        
    }
}
