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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace busState.view
{
    /// <summary>
    /// Interaction logic for Tuyen.xaml
    /// </summary>
    public partial class Tuyen : Page
    {
        int trangthai;
        string phone;
        string pass;
        List<tuyenObj> Ltuyen;
        public Tuyen(int stt,string ph, string pw)
        {
            InitializeComponent();
            Trangthai = stt;
            Phone = ph;
            Pass = pw;
            combackbtn.IsEnabled = false;
            Ltuyen=new List<tuyenObj>();
            tuyenHandle tuyenH=new tuyenHandle();
            if (Trangthai == 0) { }
            else if (Trangthai == 1)
            {
                Ltuyen = tuyenH.getTuyen("tienDZ", "12345");
                listviewtuyen.ItemsSource = Ltuyen;
            }

        }

        public int Trangthai { get => trangthai; set => trangthai = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Pass { get => pass; set => pass = value; }

        private void tuyenNgungBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Trangthai == 1)
            {
                connectClass conClass = new connectClass("tienDZ", "12345");
                SqlConnection con = conClass.getConnect();
                List<tuyenObj> lt = new List<tuyenObj>();
                using (con)
                {
                    con.Open();
                    string qr = @"Select * from [dbo].[fn_LietKeTuyenConHoatDong]()";
                    SqlCommand cmd=new SqlCommand(qr,con);
                    SqlDataReader reader=cmd.ExecuteReader();

                    while(reader.Read()) {
                        tuyenObj t = new tuyenObj();
                        t.Matuyen = reader.GetString(0);
                        t.Ten = reader.GetString(1);
                        t.Start = reader.GetTimeSpan(3);
                        t.End = reader.GetTimeSpan(2);
                        t.Bendau = reader.GetString(4);
                        t.Bencuoi = reader.GetString(5);
                        t.Trangthai = reader.GetString(6);
                        lt.Add(t);

                    }
                    this.listviewtuyen.ItemsSource = lt;
                    con.Close();
                }
            }
        }
    }
}
