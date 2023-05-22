using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busState._model
{
    public class tkhoan
    {
       
        private string phone;
        private string pass;

        public tkhoan()
        {
        }
        

        public tkhoan(string phone, string pass) 
        {
          
            Phone = phone;
            Pass = pass;
        }

        
        public string Phone { get => phone; set => phone = value; }
        public string Pass { get => pass; set => pass = value; }
    }
}
