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
    public partial class frmAdd : Form
    {
        LogsBLL logsBLL = new LogsBLL();
        LogsDAL logsDAL = new LogsDAL();
        MemberBLL MemberBLL = new MemberBLL();
        memberDAL MemberDAL = new memberDAL();

        string imageName = "no-image.jpg";
        string sourcePath = "";
        string destinationPath = "";

        public frmAdd()
        {
            InitializeComponent();
        }
        private void frmAdd_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 36);
            destinationPath = path + "Images\\" + imageName;
            pictureBox1.Image = new Bitmap(destinationPath);
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
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;

            MemberBLL.ImageName = imageName;
            MemberBLL.Fname = txtFNAME.Text;
            MemberBLL.Lname = txtLNAME.Text;
            if(rbMale.Checked == true)
            {
                MemberBLL.Gender = "Male";
            }
            else
            {
                MemberBLL.Gender = "Female";
            }
            MemberBLL.Email = txtEMAIL.Text;
            MemberBLL.DOB = dtpDOB.Text;
            MemberBLL.Address = txtAddress.Text;
            MemberBLL.Mobile = txtMobile.Text;
            MemberBLL.JoinDate = DateTime.Now.ToString();
            MemberBLL.TimeValid = DateTime.Now.ToString();
            MemberBLL.TimeLeft = "0";

            isSuccess = MemberDAL.Insert(MemberBLL);

            if (isSuccess == true)
            {
                if (imageName != "no-image.jpg")
                {
                    File.Copy(sourcePath, destinationPath);
                }
                logsBLL.Info = "Added new gym member: " + txtFNAME.Text +" " + txtLNAME.Text + " TimeAdded: " + DateTime.Now.ToString(); 
                logsDAL.insertLog(logsBLL);
                Clear();
                MessageBox.Show("RECORD INSERTED SUCCESFULLY");
            }
            else
            {
                MessageBox.Show("RECORD FAILED TO ADD");
            }

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            txtFNAME.Clear();
            txtLNAME.Clear();
            rbMale.Checked = false;
            rbFemale.Checked = false;
            txtEMAIL.Clear();
            dtpDOB.Value = DateTime.Now;
            txtAddress.Clear();
            txtMobile.Clear();
        }

        
    }
}
