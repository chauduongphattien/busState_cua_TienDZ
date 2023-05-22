using busState._model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace busState.model
{
    public class busHand
    {


        public List<busObj> getDataBus( )
        {   
            List<busObj> listBus= new List<busObj>();
            connectClass conClass = new connectClass("tienDZ", "12345");
            SqlConnection con = conClass.getConnect();
            
            try
            {
                using (con)
                {

                    con.Open();
                    string qr = "select * from Bus";
                    SqlCommand cmd= new SqlCommand(qr, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                       
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
                        listBus.Add(bus);
                       
                    }
                }
            }
            catch(Exception e)
            {
                System.Windows.MessageBox.Show("bạn không có quyền truy cập dữ liệu" +e);
            }
            finally{
                con.Close();
            }



            

            return listBus;

        }
    }
}
