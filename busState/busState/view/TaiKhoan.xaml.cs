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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using busState.viewModel;

namespace busState.view
{
    /// <summary>
    /// Interaction logic for TaiKhoan.xaml
    /// </summary>
    public partial class TaiKhoan : Page
    {
        string phone;
        string mk;
        int statuslog;
        handleTaikhoan htk;
      /*  public TaiKhoan()
        {
            
            InitializeComponent();
           
        }*/
        public TaiKhoan(string phone, string mk,int stt)
        {
            InitializeComponent();
            Phone = phone;
            Mk = mk;
            Statuslog = stt;
            htk = new handleTaikhoan(Phone,Mk,Statuslog);
            try
            {
                BitmapImage image_ = htk.onLoadImage();
                avatarBoder.Background = new ImageBrush(image_);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
           
            
        }

        public string Phone { get => phone; set => phone = value; }
        public string Mk { get => mk; set => mk = value; }
        public int Statuslog { get => statuslog; set => statuslog = value; }

        private void selectimage_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                // int id = htk.getId(Phone.ToString());
                try
                {
                    htk.SaveImageToSql(fileBytes);
                    BitmapImage image_ = htk.onLoadImage();
                    avatarBoder.Background = new ImageBrush(image_);
                }
                catch
                {
                    selectimage.Content = "fail";
                }



            }



        }
    }
}
