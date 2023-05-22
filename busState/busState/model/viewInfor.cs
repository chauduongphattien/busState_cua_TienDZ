using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using busState._model;
using System.Windows.Data;
using System.Windows.Media;
using System.IO;
using System.Windows.Media.Imaging;
/*using System.Windows.Forms;*/

namespace busState.model
{
    public class viewInfor

    {
       public List<NhanVien> getAllNv( int stt)
        {

            if (stt == 0)
            {
                List<NhanVien> listnv = new List<NhanVien>();

                connectClass conClass = new connectClass("nhanvien", "12345");
                SqlConnection con = new SqlConnection();
                con = conClass.getConnect();
                string query = "select * from NhanVien";

                try
                {
                    using (con)
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader reader = cmd.ExecuteReader();


                        while (reader.Read())
                        {
                            NhanVien nv = new NhanVien();
                            nv.CViec = reader.GetString(0);


                            nv.Sex = reader.GetInt32(8);
                            if (nv.Sex == 1)
                            {
                                nv.IconGT = "MarsStroke";
                                nv.ClIconGT = "Blue";
                            }
                            else
                            {
                                nv.IconGT = "Venus";
                                nv.ClIconGT = "Pink";
                            }


                            nv.Name = reader.GetString(1);
                            nv.Sdt = reader.GetString(2);
                           nv.Diachi = reader.GetString(3);
                            nv.Ngaysinh = reader.GetDateTime(5);
                            /* nv.Maxe = reader.GetString(4);

                             nv.Trangthai = reader.GetInt32(6);
                             nv.Id = reader.GetInt32(7);
                             */
                            listnv.Add(nv);
                        }
                        reader.Close();

                        /* GridView gv = (GridView)lv.View;
                         gv.Columns[0].DisplayMemberBinding = "{Binding id}";*/




                    }

                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("ban khong du quyen!");
                }

                finally
                {
                    con.Close();
                }
                return listnv;
            }

            else if (stt == 1) {
                List<NhanVien> listnv = new List<NhanVien>();

                connectClass conClass = new connectClass("tienDZ", "12345");
                SqlConnection con = new SqlConnection();
                con = conClass.getConnect();
                string query = "select * from NhanVien";

                try
                {
                    using (con)
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader reader = cmd.ExecuteReader();


                        while (reader.Read())
                        {
                            NhanVien nv = new NhanVien();
                            nv.CViec = reader.GetString(0);


                            nv.Sex = reader.GetInt32(8);
                            if (nv.Sex == 1)
                            {
                                nv.IconGT = "MarsStroke";
                                nv.ClIconGT = "Blue";
                            }
                            else
                            {
                                nv.IconGT = "Venus";
                                nv.ClIconGT = "Pink";
                            }


                            nv.Name = reader.GetString(1);
                            nv.Sdt = reader.GetString(2);
                            nv.Diachi = reader.GetString(3);
                            nv.Ngaysinh = reader.GetDateTime(5);
                            /* nv.Maxe = reader.GetString(4);

                             nv.Trangthai = reader.GetInt32(6);
                             nv.Id = reader.GetInt32(7);
                             */
                            listnv.Add(nv);
                        }
                        reader.Close();

                        /* GridView gv = (GridView)lv.View;
                         gv.Columns[0].DisplayMemberBinding = "{Binding id}";*/




                    }

                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("ban khong du quyen!");
                }

                finally
                {
                    con.Close();
                }
                return listnv;
            }

           return null;
        }


        public void add_nv(string name, string sdt, string cv, string gioitinh,string phone, string pass)
        {
            connectClass conClass = new connectClass(phone, pass);
            SqlConnection con = conClass.getConnect();
            using (con)
            {
                con.Open();
                string qr = "insert into NhanVien values(@name,@sdt,@cv,@gt)";
                SqlCommand cmd=new SqlCommand(qr,con);
              
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@sdt", sdt);
                cmd.Parameters.AddWithValue("@cv", cv);
                cmd.Parameters.AddWithValue("@gt", gioitinh);
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                con.Close();


            }
        }


        public void SaveImageToSql(byte[] imageData,string phone,string pass,string phone_nv)
        {
            connectClass conClass = new connectClass(phone, pass);
            SqlConnection con = conClass.getConnect();
            using (con)
            {

                con.Open();
                string qr = "UPDATE TaiKhoan SET avatar = @path WHERE phone=@phone";
                SqlCommand cmd = new SqlCommand(qr, con);
                cmd.Parameters.AddWithValue("@path", imageData);
                cmd.Parameters.AddWithValue("@phone", phone_nv);
                cmd.ExecuteNonQuery();
                con.Close();


            }
        }


        public BitmapImage onLoadImage(string phone, string pass,string phone_nv)
        {
            connectClass conClass = new connectClass(phone, pass);
            byte[] imageData = new byte[1000000];
            SqlConnection con = conClass.getConnect();
            using (con)
            {

                con.Open();
                string qr = "select avatar from Tai_Khoan where phone=@phone";
                SqlCommand cmd = new SqlCommand(qr, con);
                cmd.Parameters.AddWithValue("@phone", phone_nv);

                imageData = (byte[])cmd.ExecuteScalar();
                con.Close();


            }


            BitmapImage bitmapImage = new BitmapImage();
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                ms.Position = 0;
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = ms;
                bitmapImage.EndInit();
            }
            return bitmapImage;

        }

    }
}
