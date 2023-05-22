using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Windows.Forms;

namespace busState.model
{
    public class loginHandle
    {
       
        public int login(string phone, string pass,string user,string mkLogin)
        {
            int code;
            SqlConnection conn = new SqlConnection();
            connectClass conClass = new connectClass(user, mkLogin);
            try
            {
                conn = conClass.getConnect();
                using (conn)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText= "SP_AuthoLogin";
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@Password", pass);
                    cmd.Connection = conn;  
                    var kq = cmd.ExecuteScalar();
                    code = Convert.ToInt32(kq);
                    conn.Close();
                }
                return code;

            }
            catch (Exception e)
            {
                MessageBox.Show("fail!"+ e.ToString());
                return 3;
            }
           
        }





        public int loginQL(string phone, string pass, string user, string mkLogin)
        {
            int code;
            SqlConnection conn = new SqlConnection();
            connectClass conClass = new connectClass(user, mkLogin);
            try
            {
                conn = conClass.getConnect();
                using (conn)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "quanlylogin";
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@Password", pass);
                    cmd.Connection = conn;
                    var kq = cmd.ExecuteScalar();
                    code = Convert.ToInt32(kq);
                    conn.Close();
                }
                return code;

            }
            catch (Exception e)
            {
                MessageBox.Show("fail!" + e.ToString());
                return 3;
            }

        }

    }
}
