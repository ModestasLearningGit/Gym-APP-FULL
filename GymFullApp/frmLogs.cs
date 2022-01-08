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
    public partial class frmLogs : Form
    {
        public frmLogs()
        {
            InitializeComponent();
        }
        LogsBLL lBLL = new LogsBLL();
        LogsDAL lDAL = new LogsDAL();

        private void frmLogs_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = lDAL.SelectLogs();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            try
            {
                txtLID.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                txtAddedBy.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                txtTime.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                txtInfo.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
