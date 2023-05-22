using busState.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Interop;
using busState._model;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace busState
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        //delegate--------------------


        // tao một login
        login loginMain=new login();

       


       
        //==========================================

        string sdt;
        string mk;
        int statuslog;
        NhaVIen nv ;
        TaiKhoan tk;
        Bus bus;
        Tuyen tuyen;
        public MainWindow()
        {
            
            loginMain.ShowDialog();
            sdt = loginMain.data;
            mk = loginMain.pss;
            statuslog = loginMain.statusLog;
            nv = new NhaVIen(sdt, mk,statuslog);
            tk = new TaiKhoan(sdt, mk,statuslog);
           bus = new Bus(statuslog, sdt, mk);
            tuyen=new Tuyen(statuslog,sdt, mk);
          //  MessageBox.Show(sdt+mk);
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        public static extern IntPtr sendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        private void pnlCtrBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnMin_click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void rdoBtnTaiKhoan_Checked(object sender, RoutedEventArgs e)
        {
           // tk = new TaiKhoan(sdt,mk);
            mainNavigate.Navigate(tk);
            tk.txtName.Text = sdt;
            tk.txtSDT.Text = mk;

        }

        private void rdoBtnHome_Checked(object sender, RoutedEventArgs e)
        {
            mainNavigate.Navigate(new Home());
        }

        private void rdoBtnNhanvien_Checked(object sender, RoutedEventArgs e)
        {
            mainNavigate.Navigate(nv);
        }

        private void rdoBtnBus_Checked(object sender, RoutedEventArgs e)
        {
            mainNavigate.Navigate(bus);
        }

        private void rdoBtntaixe_Checked(object sender, RoutedEventArgs e)
        {
            mainNavigate.Navigate(new taixe());
        }

        private void rdoBtnTuyen_Checked(object sender, RoutedEventArgs e)
        {
            mainNavigate.Navigate(tuyen);
        }
    }
}
