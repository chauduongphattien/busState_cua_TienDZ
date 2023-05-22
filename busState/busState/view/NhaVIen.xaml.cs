using busState._model;
using busState.model;
using busState.viewModel;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace busState.view
{
    /// <summary>
    /// Interaction logic for NhaVIen.xaml
    /// </summary>
    public partial class NhaVIen : Page
    {
       
        string phone;
        string pass;
        int statuslog;
        public string Phone { get => phone; set => phone = value; }
        public string Pass { get => pass; set => pass = value; }
        public int Statuslog { get => statuslog; set => statuslog = value; }

        public NhaVIen()
        {
            InitializeComponent();
        }
        public NhaVIen(string phone, string pass,int stt)
        {
            Phone = phone;
            Pass = pass;
            Statuslog = stt;
            InitializeComponent();
            viewInfor vi = new viewInfor();
            nv = vi.getAllNv(Statuslog);
            List_View.ItemsSource = nv;


        }
        List<NhanVien> nv = new List<NhanVien>();
        private void xemNVALL_Click(object sender, RoutedEventArgs e)
        {
            viewInfor vi = new viewInfor();
            nv = vi.getAllNv(Statuslog);
            List_View.ItemsSource = nv;
            
            
        }

        private void themNv_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                viewInfor vi = new viewInfor();
               

            }
            catch {
                System.Windows.MessageBox.Show("da xay a loi gi do");  
            
            }
           
        }
        private void listview_selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (statuslog == 1 && this.List_View.Items.Count>0 && this.List_View.SelectedItems.Count==1 )
            {
                var row = List_View.SelectedItem as NhanVien;
                var col = row.Sdt;

                viewInfor v = new viewInfor();
                try
                {
                    try
                    {
                        BitmapImage image_ = v.onLoadImage("tienDZ", "12345", col);
                        avatar.Background = new ImageBrush(image_);
                    }
                    catch
                    {
                        avatar.Background = null;
                    }
                    
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.ToString());
                }


                connectClass conClass = new connectClass("tienDZ", "12345");
                SqlConnection con = conClass.getConnect();
                try
                {
                    using (con)
                    {

                        con.Open();
                        string qr = "select * from NhanVien where SoDienThoai=" + col;
                        SqlCommand cmd = new SqlCommand(qr, con);
                        SqlDataReader reader = cmd.ExecuteReader();


                        try
                        {


                            while (reader.Read())
                            {
                                NhanVien n = new NhanVien();
                                n.Name = reader.GetString(1);
                                n.Sdt = reader.GetString(2);
                                n.Diachi = reader.GetString(3);
                                n.Ngaysinh = reader.GetDateTime(5);
                                n.CViec = reader.GetString(0);
                                n.Sex = reader.GetInt32(8);
                                // IDtxt.Text = n.Id.ToString();
                                Nametxt.Text = n.Name;
                                if (n.CViec == "Q")
                                {
                                    n.CViec = "Quản lý";
                                    chucvuTXT.Text = n.CViec;
                                }
                                dtTxt.Text = n.Sdt;
                                diachiTXT.Text = n.Diachi;
                               
                               
                                if (n.Sex == 1)
                                {
                                    namOP.IsChecked = true;
                                }
                                else { nuOP.IsChecked = true; }

                                datepicker.SelectedDate = n.Ngaysinh.Date;
                            }
                            con.Close();
                        }
                        catch
                        {
                            System.Windows.MessageBox.Show("loi");
                        }
                        finally
                        {
                            
                            con.Close();
                        }


                    }
                }
                catch
                {

                }
            }

            
            
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sua_Click(object sender, RoutedEventArgs e)
        {

        }

        private void them_Click(object sender, RoutedEventArgs e)
        {
            string qr = "insert into NhanVien values(@name,@sdt,@cv,@gt,@diachi,@ngaysinh,@tuoi,@luong)";
            string grantQuery = $"GRANT BULK ADMIN TO @username";
            connectClass conclass = new connectClass(Phone,Pass);
            SqlConnection con = conclass.getConnect();
            using (con)
            {
                SqlCommand cmd = new SqlCommand(qr, con);
                cmd.Parameters.AddWithValue("@name", Nametxt.Text);
                cmd.Parameters.AddWithValue("@sdt", dtTxt.Text);
                cmd.Parameters.AddWithValue("@cv", chucvuTXT.Text);
                if (namOP.IsChecked == true) { cmd.Parameters.AddWithValue("@gt", 1); }
                else cmd.Parameters.AddWithValue("@gt", 0);
                cmd.Parameters.AddWithValue("@diachi", diachiTXT.Text);
                cmd.Parameters.AddWithValue("@ngaysinh", datepicker.Text);
                cmd.Parameters.AddWithValue("@tuoi", ageTXT.Text);
                cmd.Parameters.AddWithValue("@luong", luongTXT);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    System.Windows.MessageBox.Show("thêm thành công!");
                }
                catch
                {
                    System.Windows.MessageBox.Show("ban không có quyền thay đổi !");
                }
                finally
                {
                    con.Close() ;
                }


               
            }
        }

        private void xemBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (Statuslog == 1 && (maleR.IsChecked==true || femaleR.IsChecked==true))
            {
                List<NhanVien> Lnv = new List<NhanVien>();
                connectClass conClass = new connectClass("tienDZ", "12345");
                SqlConnection con = conClass.getConnect();
                try
                {
                    using (con)
                    {
                        con.Open();
                        string qr = "SELECT * from dbo.fn_LietKeSoNhanVienConHoatDong(@sex)";      // hàm lấy thông tin cacs nhấn viên nam
                        SqlCommand cmd = new SqlCommand(qr, con);
                        if (maleR.IsChecked == true)
                        {
                            cmd.Parameters.AddWithValue("@sex", Convert.ToInt32(1));
                        }
                        else cmd.Parameters.AddWithValue("@sex", Convert.ToInt32(0));
                    

                        SqlDataReader reader=cmd.ExecuteReader();
                       
                        while(reader.Read()) {
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
                            Lnv.Add(nv);


                        }

                        this.List_View.ItemsSource = Lnv;
                        con.Close();

                    }
                }
                catch(Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.ToString());
                }
                finally
                {
                    maleR.IsChecked = false;
                    femaleR.IsChecked = false;
                    con.Close();
                }
                
            }
            else if(Statuslog == 1 && (maleR.IsChecked == false && femaleR.IsChecked == false))
            {
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
                    if (listnv.Count > 0 )
                    {
                        this.List_View.ItemsSource = listnv;
                        
                    }
                }
            }
        }

        private void CalcSa_Click(object sender, RoutedEventArgs e) /// tính lương
        {
            if (Statuslog == 1 && this.List_View.SelectedItems.Count==1)
            {
               
                var row = List_View.SelectedItem as NhanVien;
                var col = row.Id;
                connectClass conClass = new connectClass("tienDZ", "12345");
                SqlConnection con = conClass.getConnect();
                using (con)
                {
                    con.Open();
                    string qr = "Select  [dbo].[fn_TinhLuong] (@MaNhanVien) TongLuong FROM NhanVien";
                    SqlCommand cmd = new SqlCommand(qr, con);
                    cmd.Parameters.AddWithValue("@MaNhanVien", Convert.ToInt32(col));
                    int luong = (int)cmd.ExecuteScalar();
                    luongTXT.Text = luong.ToString();
                    con.Close();
                }
                

            }
        }

        private void seeTX_Click(object sender, RoutedEventArgs e) // xem ta xe
        {
            
            connectClass conClass;
            if (Statuslog == 1)
            {
                conClass = new connectClass("tienDZ", "12345");
            }
            else
            {
                conClass = new connectClass("nhanvien", "12345");

            }

            SqlConnection con = conClass.getConnect();

            using (con)
            {

                con.Open();
                string q = @"Select * from [dbo].[fn_TimTaiXe]()";
                SqlCommand cmd=new SqlCommand(q,con);
              
                
                List<NhanVien> lnv = new List<NhanVien>();

                try
                {
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
                        lnv.Add(nv);
                    }
                    this.List_View.ItemsSource = lnv;
                    reader.Close();

                
                }
                catch(Exception ex)
                {
                    System.Windows.MessageBox.Show("bạn không có quyền xem thông tin này"+ex);
                }
               
            }
        }

        private void seePX_Click(object sender, RoutedEventArgs e)
        {
            connectClass conClass;
            if (Statuslog == 1)
            {
                conClass = new connectClass("tienDZ", "12345");
            }
            else
            {
                conClass = new connectClass("nhanvien", "12345");

            }

            SqlConnection con = conClass.getConnect();

            using (con)
            {

                con.Open();
                string q = @"select * from [dbo].[fn_TimPhuXe] ()";
                SqlCommand cmd = new SqlCommand(q, con);


                List<NhanVien> lnv = new List<NhanVien>();

                try
                {
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
                        lnv.Add(nv);
                    }
                    this.List_View.ItemsSource = lnv;
                    reader.Close();


                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("bạn không có quyền xem thông tin này" + ex);
                }

            }
        }
    }
}
