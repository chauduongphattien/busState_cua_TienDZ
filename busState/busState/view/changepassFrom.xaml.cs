using busState.model;
using System;
using System.Collections.Generic;
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
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace busState.view
{
    /// <summary>
    /// Interaction logic for changepassFrom.xaml
    /// </summary>
    public partial class changepassFrom : Window
    {
        string sdt;
        string mkCU;
        int stt;

        public changepassFrom(string phone, string oldpass,int tt)
        {
            InitializeComponent();
            Sdt = phone;
            MkCU = oldpass;
           
             Stt= tt;

        }

        public string Sdt { get => sdt; set => sdt = value; }
        public string MkCU { get => mkCU; set => mkCU = value; }
        public int Stt { get => stt; set => stt = value; }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (txtNewPass.Text == txtXacNhan.Text && txtNewPass.Text!="")
            {
                connectClass conClass;
                if (Stt == 1)
                {
                    System.Windows.MessageBox.Show("tai khoanr quan ly khong ");
                }
                else
                {
                    conClass = new connectClass("nhanvien", "12345");
                    SqlConnection con = conClass.getConnect();


                    using (con)
                    {
                       
                        
                        try
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "change_pass";

                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@sdt", Sdt);
                            cmd.Parameters.AddWithValue("@newpass", txtNewPass.Text);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            this.Close();
                        }
                        catch(Exception ex)
                        {
                            System.Windows.MessageBox.Show("bạn không đủ quyền" +ex);
                        }
                       
                        

                    }
                   

                }
               
            }
            else
            {
                LBnotfy.Content = "Mật khẩu không khớp";
            }




        }

        private void btnHUY_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
