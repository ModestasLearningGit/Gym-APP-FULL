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
    class memberDAL
    {
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        public bool Insert(MemberBLL bll)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string sql = "INSERT INTO MemberInfo(ImageName, Fname, Lname, Gender, Email,  Dob, mAddress," +
                "Mobile, JoinDate, TimeValid, TimeLeft)  " +
                "VALUES(@ImageName, @Fname, @Lname, @Gender, @Email, @Dob, @mAddress, @Mobile, @JoinDate, @TimeValid, @TimeLeft)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ImageName", bll.ImageName);
                cmd.Parameters.AddWithValue("@Fname", bll.Fname);
                cmd.Parameters.AddWithValue("@Lname", bll.Lname);
                cmd.Parameters.AddWithValue("@Gender", bll.Gender);
                cmd.Parameters.AddWithValue("@Email", bll.Email);
                cmd.Parameters.AddWithValue("@Dob", bll.DOB);
                cmd.Parameters.AddWithValue("@mAddress", bll.Address);
                cmd.Parameters.AddWithValue("@Mobile", bll.Mobile);
                cmd.Parameters.AddWithValue("@JoinDate", bll.JoinDate);
                cmd.Parameters.AddWithValue("@TimeValid", bll.TimeValid);
                cmd.Parameters.AddWithValue("@TimeLeft", bll.TimeLeft);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if(rows >  0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
        
        public DataTable Select()
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string sql = "SELECT * FROM MemberInfo";
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
        public DataTable onLoadCalculate()
        {
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            int newTimeLeft = 0;

            SqlConnection conn = new SqlConnection(myconnstring);


            try
            {
                string sql = "SELECT MID, TimeValid, TimeLeft FROM MemberInfo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();

                adapter.Fill(dt);
                foreach(DataRow  dr in dt.Rows)
                {
                    int id = int.Parse(dr["MID"].ToString());
                    newTimeLeft = calculateTimeLeft(DateTime.Parse(dr["TimeValid"].ToString()));

                    string sql2 = "UPDATE MemberInfo set TimeLeft=@TimeLeft  WHERE MID=@MID";
                    SqlCommand cmd2 = new SqlCommand(sql2, conn);
                    cmd2.Parameters.AddWithValue("@TimeLeft", newTimeLeft);
                    cmd2.Parameters.AddWithValue("@MID", id);

                    int rows = cmd2.ExecuteNonQuery();
                }
                string sql3 = "SELECT MID, ImageName, Fname, Lname, TimeValid, TimeLeft FROM MemberInfo";
                SqlCommand cmd3 = new SqlCommand(sql3, conn);
                SqlDataAdapter adapter2 = new SqlDataAdapter(cmd3);
                adapter2.Fill(dt2);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt2;
        }
        public int calculateTimeLeft(DateTime lastUpdate)
        {
            int newTimeLeft = 0;
            DateTime date1 = lastUpdate;
            newTimeLeft = (date1 - DateTime.Now).Days;

            if (newTimeLeft < 0)
            {
                newTimeLeft = 0;
            }

            return newTimeLeft;
        }
        public DataTable search(string keyword)
        {
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT MID, ImageName, Fname, Lname, TimeValid, TimeLeft FROM MemberInfo " +
                "WHERE MID LIKE '%"+keyword+ "%'  OR Fname LIKE '%" + keyword + "%'  OR Lname LIKE '%" + keyword + "%'";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        public DataTable afterAdd()
        {
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT MID, ImageName, Fname, Lname, TimeValid, TimeLeft FROM MemberInfo";
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
        public bool AddTimeForMembership(MemberBLL bll, int timeInMoths)
        {
            DateTime newDT;
            DateTime oldDT;
            int TimeLeftAtStart;
            int TimeLeftAfter;
            bool isSuccess = false;

            TimeLeftAtStart = int.Parse(bll.TimeLeft);
            if (TimeLeftAtStart > 0)
            {
                oldDT = DateTime.Parse(bll.TimeValid.ToString());
                newDT = oldDT.AddMonths(timeInMoths);
                TimeLeftAfter = (newDT - DateTime.Now).Days;
            }
            else
            {
                newDT = DateTime.Now.AddMonths(timeInMoths);
                TimeLeftAfter = (newDT - DateTime.Now).Days;
            }

            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string sql = "UPDATE MemberInfo SET TimeValid=@TimeValid, TimeLeft=@TimeLeft WHERE MID=@MID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@TimeValid", newDT.ToString());
                cmd.Parameters.AddWithValue("@TimeLeft", TimeLeftAfter.ToString());
                cmd.Parameters.AddWithValue("@MID", bll.MID);

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
        public DataTable select_CheckTime()
        {
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT MID, ImageName, Fname, Lname, TimeLeft FROM MemberInfo";
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
        public DataTable search_CheckTime(string keyword)
        {
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT MID,ImageName, Fname, Lname, TimeLeft FROM MemberInfo " +
                "WHERE MID LIKE '%" + keyword + "%'  OR Fname LIKE '%" + keyword + "%'  OR Lname LIKE '%" + keyword + "%'";

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

        public DataTable select_Update()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string sql = "SELECT MID, ImageName, Fname, Lname, Gender, Email, Dob, mAddress, Mobile FROM MemberInfo";
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
        public DataTable search_Update(string keyword)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string sql = "SELECT MID, ImageName, Fname, Lname, Gender, Email, Dob, mAddress, Mobile  FROM MemberInfo " +
                "WHERE MID LIKE '%" + keyword + "%'  OR Fname LIKE '%" + keyword + "%'  OR Lname LIKE '%" + keyword + "%'" +
                "OR Email LIKE '%" + keyword + "%'";

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
        public DataTable afterAdd_Update()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string sql = "SELECT MID, ImageName, Fname, Lname, Gender, Email, Dob, mAddress, Mobile  FROM MemberInfo";

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
        public bool Update_Upadate(MemberBLL bll)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string sql = "UPDATE MemberInfo Set ImageName=@ImageName, Fname=@Fname, Lname=@Lname," +
                " Gender=@Gender, Email=@Email, Dob=@Dob, mAddress=@mAddress, Mobile=@Mobile WHERE MID=@MID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ImageName", bll.ImageName);
                cmd.Parameters.AddWithValue("@Fname", bll.Fname);
                cmd.Parameters.AddWithValue("@Lname", bll.Lname);
                cmd.Parameters.AddWithValue("@Gender", bll.Gender);
                cmd.Parameters.AddWithValue("@Email", bll.Email);
                cmd.Parameters.AddWithValue("@Dob", bll.DOB);
                cmd.Parameters.AddWithValue("@mAddress", bll.Address);
                cmd.Parameters.AddWithValue("@Mobile", bll.Mobile);
                cmd.Parameters.AddWithValue("@MID", bll.MID);

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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }

            return isSuccess;
        }
        public DataTable select_RemoveMember()
        {
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT MID, ImageName, Fname, Lname FROM MemberInfo";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        public DataTable search_RemoveMember(string keyword)
        {
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();

            try
            {

                string sql = "SELECT MID, ImageName, Fname, Lname FROM MemberInfo " +
                "WHERE MID LIKE '%" + keyword + "%'  OR Fname LIKE '%" + keyword + "%'  OR Lname LIKE '%" + keyword + "%'";

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

        public bool delete_RemoveMember(MemberBLL bll)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string sql = "DELETE FROM MemberInfo WHERE MID=@MID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MID", bll.MID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if(rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }

        public DataTable Select_RemoveTime()
        {
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT MID, ImageName, Fname, Lname, TimeValid, TimeLeft FROM MemberInfo";

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
        public DataTable search_RemoveTime(String keyword)
        {
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();

            try
            {

                string sql = "SELECT MID, ImageName, Fname, Lname, TimeValid, TimeLeft FROM MemberInfo " +
                "WHERE MID LIKE '%" + keyword + "%'  OR Fname LIKE '%" + keyword + "%'  OR Lname LIKE '%" + keyword + "%'";

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
        public bool updateTime_RemoveTime(MemberBLL bll)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string sql = "UPDATE MemberInfo SET TimeValid=@TimeValid, TimeLeft=@TimeLeft  " +
                "WHERE MID=@MId";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@MID", bll.MID);
                cmd.Parameters.AddWithValue("@TimeValid", bll.TimeValid);
                cmd.Parameters.AddWithValue("@TimeLeft", bll.TimeLeft);

                conn.Open();
                //create and integer variable to hol value afte query is excecuted
                int rows = cmd.ExecuteNonQuery();

                //the value of rows will be greater than 0 if queery excecuted succesfully
                // else it will be 0
                if (rows > 0)
                {
                    //Query excecuted sufesfullly
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
    }
    
}

