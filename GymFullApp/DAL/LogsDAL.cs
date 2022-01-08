using GymFullApp.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymFullApp.DAL
{
    class LogsDAL
    {
        int AID = Form1.UserID;
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        public void insertLog(LogsBLL bll)
        { 
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string sql = "INSERT INTO Logs(AddedBy, TimeAdded, Info) " +
                "VALUES(@AddedBy, @TimeAdded, @Info)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@AddedBy", AID);
                cmd.Parameters.AddWithValue("@TimeAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@Info", bll.Info);

                conn.Open();

                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            
        }

        public DataTable SelectLogs()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string sql = "SELECT * FROM Logs ORDER BY LogID DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

    }
}
