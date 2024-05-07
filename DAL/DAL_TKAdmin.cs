using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class DAL_TKAdmin
    {
        DTO_TKAdmin ad;

        public DAL_TKAdmin(string TaiKhoanAdmin,string MatKhauAdmin)
        {
            ad = new DTO_TKAdmin(TaiKhoanAdmin,MatKhauAdmin);
        }

        public Boolean checkQuery()
        {
            string query = "SELECT * FROM TKAdmin WHERE TaiKhoanAdmin = '" + ad._TaiKhoanAdmin + "' AND MatKhauAdmin = '" + ad._MatKhauAdmin + "'";
            return Connection.haveQuery(query);
        }


    }
}
