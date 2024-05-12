using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace DAL
{
    public class DAL_DichVu
    {
        DTO_DichVu dv;


        public DAL_DichVu(string MaDV, string Ten, BigInteger Gia, string DonVi, DateTime NgayLap, string TrangThai)
        {
            dv = new DTO_DichVu(MaDV,Ten,Gia,DonVi,NgayLap,TrangThai);
        }

        public DataTable selectQuery()
        {
            string query = "SELECT MaDV,Ten,Gia,DonVi,NgayLap FROM DichVu WHERE TrangThai = 'Active'";
            return Connection.selectQuery(query);
        }

        public DataTable selectDeleteQuery()
        {
            string query = "SELECT MaDV,Ten,Gia,DonVi,NgayLap FROM DichVu WHERE TrangThai = 'Inactive'";
            return Connection.selectQuery(query);
        }
        public DataTable selectSearch(string content)
        {
            string query = "SELECT MaDV,Ten,Gia,DonVi,NgayLap FROM DichVu WHERE (MaDV LIKE '%" + content + "%' OR Ten LIKE N'%" + content + "%') AND (TrangThai = 'Active')";
            return Connection.selectQuery(query);
        }

        public DataTable selectTimeFilter(DateTime first,DateTime second)
        {
            string query = "SELECT MaDV,Ten,Gia,DonVi,NgayLap FROM DichVu WHERE (NgayLap >= '" + first + "' AND NgayLap < '" + second + "') AND (TrangThai = 'Active')";
            return Connection.selectQuery(query);
        }


        public DataTable getDVDesc()
        {
            string query = "SELECT TOP 1 MaDV FROM DichVu ORDER BY MaDV DESC";
            return Connection.selectQuery(query);
        }


        public void addQuery(string id)
        {
            DateTime now = DateTime.Now;
            string query = "INSERT INTO DichVu VALUES ('" + id + "',N'" + dv._Ten + "'," + dv._Gia + ",N'" + dv._DonVi + "','" + dv._NgayLap + "','" + dv._TrangThai + "')";
            Connection.actionQuery(query);
        }

        public void updateQuery(string text)
        {
            if (text == "")
            {
                return;
            }
            else
            {
                string query = "UPDATE DichVu  SET TrangThai = 'Inactive' WHERE MaDV IN (" + text + ")";

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
                string query = "UPDATE DichVu  SET TrangThai = 'Active' WHERE MaDV IN (" + text + ")";

                Connection.actionQuery(query);
            }
        }

        public DataTable getDVInfo(string MaDV)
        {
            string query = "SELECT * FROM DichVu WHERE MaDV = '" + MaDV + "'";
            return Connection.selectQuery(query);
        }

        public DataTable getDVName()
        {
            string query = "SELECT Ten FROM DichVu WHERE TrangThai = 'Active'";
            return Connection.selectQuery(query);
        }

        public DataTable getDVInfoByName(string MaDV)
        {
            string query = "SELECT * FROM DichVu WHERE Ten = N'" + MaDV + "'";
            return Connection.selectQuery(query);
        }

        public void updateCurrentQuery()
        {
            string query = "UPDATE DichVu SET Ten = N'" + dv._Ten + "', Gia = " + dv._Gia + ", DonVi = N'"  + dv._DonVi + "' WHERE MaDV = '" + dv._MaDV + "'";
            Connection.actionQuery(query);
        }
    }
}
