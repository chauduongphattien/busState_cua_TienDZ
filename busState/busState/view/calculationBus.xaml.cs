using busState._model;
using busState.model;
using System;
using System.Collections.Generic;
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
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }


                con.Close();



            }

           
        }
    }
}
