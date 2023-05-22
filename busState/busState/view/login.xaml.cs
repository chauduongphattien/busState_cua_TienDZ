using busState.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace busState.view
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {



        public string data;
        public string pss;

        public int statusLog;


        Form f1;
        loginHandle lgH;
        private DispatcherTimer _timer;
        public login()
        {
            lgH = new loginHandle();
           
            InitializeComponent();

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(2);
            _timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Close();
            _timer.Stop();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void close_click(object sender, RoutedEventArgs e)
        {
            this.Close();
           
        }
        public void login_click(object sender, RoutedEventArgs e)
        {

            //---------------------------
            data = txtUser.Text;
            pss = txtpass.Password;
            //-------------------------------------------------
            

            string password = new System.Net.NetworkCredential(string.Empty, txtpass.SecurePassword).Password;

            if (nhanvienRad.IsChecked == true)
            {
                int i = lgH.login(txtUser.Text,password,"nhanvien", "12345");
                if (i == 1)
                {
                    statusLog = 0;
                    this.Close();
                }
                else { System.Windows.MessageBox.Show("dang nhap that bai");  }
            }
            if (qlyRad.IsChecked == true)
            {
                int i = lgH.loginQL(txtUser.Text, password, "tienDZ", "12345");
                if (i == 1)
                {
                    statusLog = 1;
                    this.Close();
                }
                else { System.Windows.MessageBox.Show("dang nhap that bai"); }
            }

           

        }
    }
}
