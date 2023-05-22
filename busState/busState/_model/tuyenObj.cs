using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busState._model
{
    public class tuyenObj
    {
        string matuyen;
        string ten;
        TimeSpan start;
        TimeSpan end;
        string bendau;
        string bencuoi;
        string trangthai;

        public string Matuyen { get => matuyen; set => matuyen = value; }
        public string Ten { get => ten; set => ten = value; }
        public TimeSpan Start { get => start; set => start = value; }
        public TimeSpan End { get => end; set => end = value; }
        public string Bendau { get => bendau; set => bendau = value; }
        public string Bencuoi { get => bencuoi; set => bencuoi = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
    }
}
