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
    class UserDAL
    {
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;


        public bool LoginCheck(UserBLL bll)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                conn.Open();
                string sql = "SELECT * FROM AdminInfo WHERE Username=@Username AND UserPassword=@UPass";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Username", bll.Username);
                cmd.Parameters.AddWithValue("@UPass", bll.Password);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }

        public int CheckAID(string Username)
        {
            int AdminID = 0;
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT AID FROM AdminInfo where Username = '" + Username + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    AdminID = int.Parse(dt.Rows[0]["AID"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return AdminID;

        }
        public int isAdmin(string Username)
        {
            int adminLevel = 0;
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT AdminStatus FROM AdminInfo WHERE Username = '" + Username + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    adminLevel = int.Parse(dt.Rows[0]["AdminStatus"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return adminLevel;
        }

        public DataTable Select()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string sql = "SELECT * FROM AdminInfo";
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
        public bool Insert(UserBLL bll)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string sql = "INSERT INTO AdminInfo(ImageName,Username,UserPassword,AdminStatus,Comment)" +
                "VALUES(@ImageName,@UserName,@UserPass, @AdminStatus,@Comment)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ImageName", bll.ImageName);
                cmd.Parameters.AddWithValue("@UserName", bll.Username);
                cmd.Parameters.AddWithValue("@UserPass", bll.Password);
                cmd.Parameters.AddWithValue("@AdminStatus", bll.AdminStatus);
                cmd.Parameters.AddWithValue("@Comment", bll.Comment);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
        public bool Update(UserBLL bll)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string sql = "UPDATE AdminInfo set ImageName=@ImageName, Username=@UName, UserPassword=@UPass," +
                "AdminStatus=@AdminStatus, Comment=@Comment WHERE AID=@AID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ImageName", bll.ImageName);
                cmd.Parameters.AddWithValue("@UName", bll.Username);
                cmd.Parameters.AddWithValue("UPass", bll.Password);
                cmd.Parameters.AddWithValue("@AdminStatus", bll.AdminStatus);
                cmd.Parameters.AddWithValue("@Comment", bll.Comment);
                cmd.Parameters.AddWithValue("@AID", bll.AID);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }


            return isSuccess;
        }
        public bool Delete(UserBLL bll)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string sql = "DELETE FROM AdminInfo WHERE AID=@AID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@AID", bll.AID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
        public DataTable Search(string keyword)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string sql = "SELECT * FROM AdminInfo where AID LIKE '%" + keyword + "%' OR Username LIKE '%" + keyword + "%'" +
                " OR AdminStatus LIKE '%" + keyword + "%'";

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
