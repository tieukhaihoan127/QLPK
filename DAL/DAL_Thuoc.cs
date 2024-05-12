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
    public class DAL_Thuoc
    {
        DTO_Thuoc t;


        public DAL_Thuoc(string MaThuoc, string TenThuoc, string DonViTinh, BigInteger GiaNhap, BigInteger GiaBan, string DanhMuc, string NSX, DateTime NgayNhapHang, string CachDung ,string TrangThai)
        {
            t = new DTO_Thuoc(MaThuoc, TenThuoc, DonViTinh, GiaNhap, GiaBan, DanhMuc, NSX, NgayNhapHang, CachDung, TrangThai);
        }

        public DataTable selectQuery()
        {
            string query = "SELECT MaThuoc,TenThuoc, DonViTinh, DanhMuc, GiaBan, NgayNhapHang FROM Thuoc WHERE TrangThai = 'Active'";
            return Connection.selectQuery(query);
        }

        public DataTable selectDeleteQuery()
        {
            string query = "SELECT MaThuoc,TenThuoc, DonViTinh, DanhMuc, GiaBan, NgayNhapHang FROM Thuoc WHERE TrangThai = 'Inactive'";
            return Connection.selectQuery(query);
        }

        public DataTable selectSearch(string content)
        {
            string query = "SELECT MaThuoc,TenThuoc, DonViTinh, DanhMuc, GiaBan, NgayNhapHang FROM Thuoc WHERE TrangThai = 'Active' AND (MaThuoc LIKE N'%" + content + "%' OR TenThuoc LIKE N'%" + content + "%')";
            return Connection.selectQuery(query);
        }

        public DataTable selectFilterTime(DateTime first, DateTime second)
        {
            string query = "SELECT MaThuoc,TenThuoc, DonViTinh, DanhMuc, GiaBan, NgayNhapHang FROM Thuoc WHERE TrangThai = 'Active' AND (NgayNhapHang >= '" + first + "' AND NgayNhapHang < '" + second + "')";
            return Connection.selectQuery(query);
        }

        public DataTable getMedicineDesc()
        {
            string query = "SELECT TOP 1 MaThuoc FROM Thuoc ORDER BY MaThuoc DESC";
            return Connection.selectQuery(query);
        }

        public void addQuery(string id)
        {
            DateTime now = DateTime.Now;
            string query = "INSERT INTO Thuoc VALUES ('" + id + "',N'" + t._TenThuoc + "',N'" + t._DonViTinh + "'," + t._GiaNhap + "," + t._GiaBan + ",N'" + t._DanhMuc + "',N'" + t._NSX + "','" + t._NgayNhapHang + "',N'" + t._CachDung + "','" + t._TrangThai + "')"; 
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
                string query = "UPDATE Thuoc  SET TrangThai = 'Inactive' WHERE MaThuoc IN (" + text + ")";

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
                string query = "UPDATE Thuoc  SET TrangThai = 'Active' WHERE MaThuoc IN (" + text + ")";

                Connection.actionQuery(query);
            }
        }

        public DataTable getThuocInfo(string MaThuoc)
        {
            string query = "SELECT * FROM Thuoc WHERE MaThuoc = '" + MaThuoc + "'";
            return Connection.selectQuery(query);
        }

        public DataTable getThuocName()
        {
            string query = "SELECT TenThuoc FROM Thuoc WHERE TrangThai = 'Active'";
            return Connection.selectQuery(query);
        }

        public DataTable getThuocInfoByName(string TenThuoc) {
            string query = "SELECT * FROM Thuoc WHERE TenThuoc = '" + TenThuoc + "'";
            return Connection.selectQuery(query);
        }

        public void updateCurrentQuery()
        {
            string query = "UPDATE Thuoc SET TenThuoc = N'" + t._TenThuoc + "', DonViTinh = N'" + t._DonViTinh + "', GiaNhap =" + t._GiaNhap + ", GiaBan = " + t._GiaBan + ", DanhMuc = N'" + t._DanhMuc + "', NSX = N'" + t._NSX + "', CachDung = N'" + t._CachDung + "' WHERE MaThuoc = '" + t._MaThuoc + "'";
            Connection.actionQuery(query);
        }
    }
}
