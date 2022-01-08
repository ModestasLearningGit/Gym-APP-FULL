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
    public partial class frmRemove : Form
    {
        LogsBLL logsBLL = new LogsBLL();
        LogsDAL logsDAL = new LogsDAL();
        MemberBLL MemberBLL = new MemberBLL();
        memberDAL MemberDAL = new memberDAL();

        string imageName = "no-image.jpg";
        string sourcePath = "";
        string destinationPath = "";

        public frmRemove()
        {
            InitializeComponent();
        }

        private void frmRemove_Load(object sender, EventArgs e)
        {
            DataTable dt = MemberDAL.select_RemoveMember();
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
                DataTable dt = MemberDAL.search_RemoveMember(keyword);
                dgvTable.DataSource = dt;
            }
            else
            {
                DataTable dt = MemberDAL.select_RemoveMember();
                dgvTable.DataSource = dt;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MemberBLL.MID = int.Parse(txtID.Text.ToString());

            bool isSuccess = MemberDAL.delete_RemoveMember(MemberBLL);

            if (isSuccess == true)
            {
                try
                {


                    if (imageName != "no-image.jpg")
                    {


                        string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 36);
                        destinationPath = path + "Images\\" + imageName;
                        string noImageDestinationPath = path + "Images\\" + "no-image.jpg";
                        pictureBox1.Image = new Bitmap(noImageDestinationPath);
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        if (File.Exists(destinationPath))
                        {

                            File.Delete(destinationPath);
                        }
                       
                    }
                    MessageBox.Show("DONOR DELETED SUCCESSFULLY");

                    logsBLL.Info = "Deleted Member ID = " + txtID.Text + " Member name: " + txtFirstName.Text + " " + txtLastName.Text;
                    logsDAL.insertLog(logsBLL);
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("DONOR FAILED TO DELETE ");
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

            DataTable dt = MemberDAL.select_RemoveMember();
            dgvTable.DataSource = dt;
        }
    }
}
