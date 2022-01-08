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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        UserBLL bll = new UserBLL();
        UserDAL dal = new UserDAL();

        public static int UserID;
        public static string LogedInAs;
        public static int IsAdmin;
        public static string AdminAcitve;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bll.Username = txtUsername.Text;
            bll.Password = txtPassword.Text;

            bool isSuccess = dal.LoginCheck(bll);

            if(isSuccess == true)
            {
                MessageBox.Show("LOGED IN SUCCESFULLY");
                LogedInAs = bll.Username;

                UserID = dal.CheckAID(LogedInAs);
                IsAdmin = dal.isAdmin(LogedInAs);
               
                if(IsAdmin  > 0)
                {
                    AdminAcitve = "TRUE";
                }
                else
                {
                    AdminAcitve = "FALSE";
                }

                frmMain main = new frmMain();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("LOGIN FAILED");
            }
        }
    }
}
