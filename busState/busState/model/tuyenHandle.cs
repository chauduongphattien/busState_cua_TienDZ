using busState._model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Diagnostics;

namespace busState.model
{
    public class tuyenHandle
    {
        public List<tuyenObj> getTuyen(string us,string pss)
        {
            List<tuyenObj> listTuyen=new List<tuyenObj>();
            connectClass conClass=new connectClass(us,pss);
            SqlConnection con = conClass.getConnect();
            using (con)
            {


                try
                {
                    con.Open();
                    string qr = "select * from Tuyen";
                    SqlCommand cmd = new SqlCommand(qr, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        tuyenObj t = new tuyenObj();
                        t.Matuyen = reader.GetString(0);
                        t.Ten = reader.GetString(1);
                        t.Start = reader.GetTimeSpan(3);
                        t.End = reader.GetTimeSpan(2);
                        t.Bendau = reader.GetString(4);
                        t.Bencuoi = reader.GetString(5);
                        t.Trangthai = reader.GetString(6);
                        listTuyen.Add(t);

                    }

                    con.Close();
                }
                catch
                {
                    System.Windows.MessageBox.Show("bạn không được phép");
                }

                
            }



            return listTuyen;
        }
    }
}
