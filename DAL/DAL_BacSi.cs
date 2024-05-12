using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DAL
{
    public class DAL_BacSi
    {
        DTO_BacSi bs;

        public DAL_BacSi(string MaNV, string ChuyenNganh, string HocVan, string KinhNghiem, string NgonNgu, string TrangThai)
        {
            bs = new DTO_BacSi(MaNV,ChuyenNganh,HocVan,KinhNghiem,NgonNgu, TrangThai);
        }

        public DataTable getDoctorDesc()
        {
            string query = "SELECT TOP 1 MaNV FROM BacSi ORDER BY MaNV DESC";
            return Connection.selectQuery(query);
        }

        public void addQuery(string id)
        {
            string query = "INSERT INTO BacSi VALUES ('" + id + "',N'" + bs._ChuyenNganh + "',N'" + bs._HocVan + "',N'" + bs._KinhNghiem + "',N'" + bs._NgonNgu + "','" + bs._TrangThai + "')";
            Connection.actionQuery(query);
        }



        public void updateQuery(string text)
        {
            if(text == "")
            {
                return;
            }
            else
            {
                string query = "UPDATE BacSi  SET TrangThai = 'Inactive' WHERE MaNV IN (" + text + ")";

                Connection.actionQuery(query);
            }
        }

        public void updateActiveQuery(string text)
        {
            if (text == "")
            {
                return;
            }
            else
            {
                string query = "UPDATE BacSi  SET TrangThai = 'Active' WHERE MaNV IN (" + text + ")";

                Connection.actionQuery(query);
            }
        }

        public void updateCurrentQuery()
        {
            string query = "UPDATE BacSi SET ChuyenNganh = N'" + bs._ChuyenNganh + "',HocVan = N'" + bs._HocVan + "', KinhNghiem = N'" + bs._KinhNghiem + "',NgonNgu = N'" + bs._NgonNgu + "' WHERE MaNV = '" + bs._MaNV + "'";
            Connection.actionQuery(query);
        }

    }
}
