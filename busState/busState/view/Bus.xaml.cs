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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace busState.view
{
    /// <summary>
    /// Interaction logic for Bus.xaml
    /// </summary>
    public partial class Bus : Page
    {

        int stt;
        string ph;
        string pss;


        public Bus(int stt_, string phone, string pass)
        {

            InitializeComponent();
            Stt = stt_;
            Ph = phone; // đay là sô ddienj thoaoij của tk đăng nhập
            Pss = pass; // đây là pass của tk đăng nhập

            if(stt==0) { }
            else if (Stt == 1)
            {
                
                busHand bushandle = new busHand();
                List<busObj> BOJ = new List<busObj>();
                BOJ = bushandle.getDataBus( );
                try
                {
                    listviewBus.ItemsSource = BOJ;
                }
                catch(Exception e)
                {
                    System.Windows.MessageBox.Show(e.Message);
                }

            }
            
        }

        public int Stt { get => stt; set => stt = value; }
        public string Ph { get => ph; set => ph = value; }
        public string Pss { get => pss; set => pss = value; }

        private void listviewBus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listviewBus.SelectedItem != null)
            {
                var row=listviewBus.SelectedItem as busObj;
                calculationBus CalBus = new calculationBus(row);
                CalBus.Show();
            }
        }

        private void conHDBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Stt == 1)
            {
                connectClass conClass = new connectClass("tienDZ", "12345");
                SqlConnection con = conClass.getConnect();
                List<busObj> lb = new List<busObj>();

                using (con)
                {
                    con.Open();
                    string qr = "Select * from [dbo].[fn_LietKeSoXeBusConHoatDong]()";
                    SqlCommand cmd = new SqlCommand(qr, con);
                    SqlDataReader reader=cmd.ExecuteReader();

                    while (reader.Read()) {

                        busObj bus = new busObj();
                        bus.Maxxe = reader.GetString(0);
                        bus.Tuyen = reader.GetString(1);
                        bus.Taixe = reader.GetInt32(3);
                        bus.Phuxe = reader.GetInt32(2);
                        bus.Trangthai = reader.GetString(5);

                        string getNameTaiXe = "select Ten from NhanVien where MaNhanVien=" + bus.Taixe.ToString();
                        SqlConnection conTX = conClass.getConnect();
                        conTX.Open();
                        string getNamePhuXe = "select Ten from NhanVien where MaNhanVien=" + bus.Phuxe.ToString();
                        SqlConnection conPX = conClass.getConnect();
                        conPX.Open();
                        SqlCommand cmdTaiXe = new SqlCommand(getNameTaiXe, conTX);
                        SqlCommand cmdPhuXe = new SqlCommand(getNamePhuXe, conPX);

                        bus.TenTaiXe = cmdTaiXe.ExecuteScalar().ToString();
                        bus.TenPhuXe = cmdPhuXe.ExecuteScalar().ToString();
                        conTX.Close();
                        conPX.Close();
                        lb.Add(bus);

                        this.listviewBus.ItemsSource = lb;


                    }
                }
            }
        }

        private void seeallBtn_Click(object sender, RoutedEventArgs e)
        {
            busHand bushandle = new busHand();
            List<busObj> BOJ = new List<busObj>();
            BOJ = bushandle.getDataBus();
            try
            {
                listviewBus.ItemsSource = BOJ;
            }
            catch 
            {
                
            }
        }
    }
}
