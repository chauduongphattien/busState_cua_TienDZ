using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices;
using busState.model;
using System.Web;
using System.IO;
using System.Windows.Media.Imaging;

namespace busState.viewModel
{
    public class handleTaikhoan
    {
        string phone;
        string mk;
        int statuslog;
        public string Phone { get => phone; set => phone = value; }
        public string Mk { get => mk; set => mk = value; }
        public int Statuslog { get => statuslog; set => statuslog = value; }

        public handleTaikhoan(string phone, string pass,int stt)
        {
           Phone=phone;
            Mk = pass;
            Statuslog = stt;
        }
        public void SaveImageToSql(byte[] imageData)
        {

            if (Statuslog == 0) {
                connectClass conClass = new connectClass("nhanvien", "12345");
                SqlConnection con = conClass.getConnect();
                using (con)
                {

                    con.Open();
                    string qr = "UPDATE Tai_Khoan SET avatar = @path WHERE phone=@phone";
                    SqlCommand cmd = new SqlCommand(qr, con);
                    cmd.Parameters.AddWithValue("@path", imageData);
                    cmd.Parameters.AddWithValue("@phone", Phone);
                    cmd.ExecuteNonQuery();
                    con.Close();


                }

            }
            else if (Statuslog == 1)
            {
                connectClass conClass = new connectClass("tienDZ", "12345");
                SqlConnection con = conClass.getConnect();
                using (con)
                {

                    con.Open();
                    string qr = "UPDATE QuanLy SET avt = @path WHERE sodienthoai=@phone";
                    SqlCommand cmd = new SqlCommand(qr, con);
                    cmd.Parameters.AddWithValue("@path", imageData);
                    cmd.Parameters.AddWithValue("@phone", Phone);
                    cmd.ExecuteNonQuery();
                    con.Close();


                }
            }
           
        }

        public BitmapImage onLoadImage()
        {

            if (Statuslog == 0)
            {
                try
                {
                    connectClass conClass = new connectClass("nhanvien", "12345");
                    byte[] imageData = new byte[1000000];
                    SqlConnection con = conClass.getConnect();
                    using (con)
                    {

                        con.Open();
                        string qr = "select avatar from Tai_Khoan where phone=@phone";
                        SqlCommand cmd = new SqlCommand(qr, con);
                        cmd.Parameters.AddWithValue("@phone", Phone);

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
                catch
                {
                    return null;
                }
                
            }

            else if (Statuslog == 1)
            {
                connectClass conClass = new connectClass("tienDZ", "12345");
                byte[] imageData = new byte[1000000];
                SqlConnection con = conClass.getConnect();
                using (con)
                {

                    con.Open();
                    string qr = "select avt from QuanLy where sodienthoai=@phone";
                    SqlCommand cmd = new SqlCommand(qr, con);
                    cmd.Parameters.AddWithValue("@phone", Phone);

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


            else { return null; }

           
            
        }

        public int getId(string phone)
        {
            connectClass conClass = new connectClass(Phone, Mk);
            int id;
            SqlConnection con = conClass.getConnect();
            using (con)
            {

                con.Open();
                string qr = "select ID from Tai_Khoan where phone=@phone";
                SqlCommand cmd = new SqlCommand(qr, con);
                cmd.Parameters.AddWithValue("@phone",phone);

                id = Convert.ToInt32( cmd.ExecuteScalar());
                con.Close();


            }
            return id;
        }
        
    }
}
