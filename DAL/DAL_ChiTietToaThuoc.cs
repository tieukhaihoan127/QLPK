using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ChiTietToaThuoc
    {
        DTO_ChiTietToaThuoc cttt;

        public DAL_ChiTietToaThuoc(string MaToa, string MaThuoc, int SoLuong)
        {
            cttt = new DTO_ChiTietToaThuoc(MaToa, MaThuoc, SoLuong);
        }

        public void addQuery()
        {
            string query = "INSERT INTO ChiTietToaThuoc VALUES ('" + cttt._MaToa + "','" + cttt._MaThuoc + "'," + cttt._SoLuong + ")";
            Connection.actionQuery(query);
        }
    }
}
