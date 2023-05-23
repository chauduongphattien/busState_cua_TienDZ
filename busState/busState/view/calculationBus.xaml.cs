using busState._model;
using busState.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace busState.view
{
    /// <summary>
    /// Interaction logic for calculationBus.xaml
    /// </summary>
    public partial class calculationBus : Window
    {


        busObj bus;
        public calculationBus(busObj b)
        {
            InitializeComponent();
            bus= b;
            txt0.Content += bus.Maxxe;
            txt1.Content += bus.Tuyen;
            
            txt2.Content += bus.TenTaiXe;
            txt3.Content += bus.TenPhuXe;
            txt4.Content += bus.Xuatphat;
            txt5.Content += bus.Trangthai;

        }

        private void xemDT_Click(object sender, RoutedEventArgs e)
        {
            string maxe = bus.Maxxe;
           
           DateTime ngayban=new DateTime();
            connectClass conClass = new connectClass("tienDZ", "12345");
            SqlConnection con = conClass.getConnect();
            
            using (con)
            {
                con.Open();
                string qr = "select NgayBanVe from DoanhThu where MaXe=@mx";
                SqlCommand cmd = new SqlCommand(qr, con);
                cmd.Parameters.AddWithValue("@mx", maxe.ToString());

                try
                {
                    ngayban = ((DateTime)cmd.ExecuteScalar());
                    ngaybanLB.Content = (ngayban.Date).ToString();

                }
                catch { System.Windows.MessageBox.Show("Xe hiện không có thu thông tin doanh thu!"); }



                /*con.Close();





                con.Open();*/

                string qr1 = @"select [dbo].[fn_TinhDoanhThu](@mx,@nbve)";
                SqlCommand cmd1 = new SqlCommand(qr1, con);
                cmd1.Parameters.AddWithValue("@mx", maxe);
                cmd1.Parameters.AddWithValue("@nbve", "2023-10-08");

                try
                {
                    int dt = (int)cmd1.ExecuteScalar();
                    doanhthuLB.Content = dt.ToString();
                }
                catch
                {
                    
                }


                con.Close();



            }

           
        }

        private void upBtn_Click(object sender, RoutedEventArgs e)
        {
            connectClass conClass = new connectClass("tienDZ", "12345");
            SqlConnection con = conClass.getConnect();
            using (con)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CreateDataBus";
                    cmd.Parameters.AddWithValue("@MaXe",box0.Text);
                    cmd.Parameters.AddWithValue("@Tuyen", box1.Text);
                    cmd.Parameters.AddWithValue("@TaiXe",SqlDbType.Int).Value=Convert.ToInt32(box2.Text);
                    cmd.Parameters.AddWithValue("@PhuXe", SqlDbType.Int).Value = Convert.ToInt32(box3.Text);
                    cmd.Parameters.AddWithValue("@TrangThai", SqlDbType.Int).Value = Convert.ToInt32(box5.Text);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    System.Windows.MessageBox.Show("Đã thêm");
                }
                catch
                {
                    System.Windows.MessageBox.Show("Thêm Thất Bại");
                }
            }
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Bạn có muốn xóa không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                connectClass conClass = new connectClass("tienDZ", "12345");
                SqlConnection con = conClass.getConnect();
                using (con)
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "DeleteDataBus";
                        cmd.Parameters.AddWithValue("@MaXe", bus.Maxxe.ToString());

                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        System.Windows.MessageBox.Show("Đã xóa");
                    }
                    catch
                    {
                        System.Windows.MessageBox.Show("Xóa Thất Bại");
                    }
                }
            }

            
        }
    }
}
