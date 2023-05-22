using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busState._model
{
    public class busObj
    {

        string maxxe;
        string tuyen;
        int phuxe;
        int taixe;
        string tenTaiXe;
        string tenPhuXe;
        string xuatphat;
        string trangthai;

        public string Maxxe { get => maxxe; set => maxxe = value; }
        public string Tuyen { get => tuyen; set => tuyen = value; }
        
        public string Xuatphat { get => xuatphat; set => xuatphat = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
        public int Phuxe { get => phuxe; set => phuxe = value; }
        public int Taixe { get => taixe; set => taixe = value; }
        public string TenTaiXe { get => tenTaiXe; set => tenTaiXe = value; }
        public string TenPhuXe { get => tenPhuXe; set => tenPhuXe = value; }
    }
}
