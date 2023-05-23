using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;

namespace busState.model
{
    public class connectClass
    {

        public connectClass(string User, string pass)
        {
            AccountConUser = User;
            AccountConPass = pass;
            AcountCon = connectStr + "User ID=" + AccountConUser + ";Password=" + AccountConPass;
        }
        //Data Source=DESKTOP-9B1OK98;Initial Catalog=BusStation;Integrated Security=True
        //  public static string connectStr = @"Data Source=DESKTOP-9B1OK98;Initial Catalog=busData;User ID=tienDZ;Password=12345";
        public static string connectStr = @"Data Source=192.168.0.36;Initial Catalog=busStation;";/*User ID=tienDZ;Password=12345;*/
        string acountCon;
        string accountConUser;
        string accountConPass;

        public string AccountConUser { get => accountConUser; set => accountConUser = value; }
        public string AccountConPass { get => accountConPass; set => accountConPass = value; }
        public string AcountCon { get => acountCon; set => acountCon = value; }

        public  SqlConnection getConnect()
        {
            return new SqlConnection(AcountCon);  
        }

    }
      
}
