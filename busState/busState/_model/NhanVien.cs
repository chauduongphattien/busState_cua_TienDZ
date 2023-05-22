using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace busState._model
{
    public class NhanVien
    {
        private int id;
        private string name;
        private string sdt;
        private string cViec;
        private string gioitinh;
        private int sex;
        private string diachi;
        private DateTime ngaysinh;
        private int tuoi;
        private int luong;
        private int trangthai;
        private string maxe;
        private string iconGT;
        private string clIconGT;
        public NhanVien() { }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string CViec { get => cViec; set => cViec = value; }
    
        public string Diachi { get => diachi; set => diachi = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }
        public int Luong { get => luong; set => luong = value; }
        public int Sex { get => sex; set => sex = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string IconGT { get => iconGT; set => iconGT = value; }
        public string ClIconGT { get => clIconGT; set => clIconGT = value; }
        public int Trangthai { get => trangthai; set => trangthai = value; }
        public string Maxe { get => maxe; set => maxe = value; }
    }
}
