using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Threading.Tasks;
using System.Numerics;
using System.Data;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DAL
{
    public class DAL_NhanVien
    {
        DTO_NhanVien nv;

        public DAL_NhanVien(string MaNV, string Ten, string SDT, string GioiTinh, string Email, string DiaChiLienHe, string CMND, string VaiTro, DateTime NgaySinh, BigInteger luong)
        {
            nv = new DTO_NhanVien(MaNV, Ten, SDT, GioiTinh, Email, DiaChiLienHe, CMND, VaiTro, NgaySinh, luong);
        }

        public DataTable selectQuery()
        {
            string query = "SELECT NhanVien.MaNV,NhanVien.Ten,NhanVien.GioiTinh,NhanVien.SDT,NhanVien.NgaySinh FROM NhanVien,BacSi WHERE NhanVien.MaNV = BacSi.MaNV AND BacSi.TrangThai = 'Active'";
            return Connection.selectQuery(query);
        }

        public DataTable selectDeleteQuery()
        {
            string query = "SELECT NhanVien.MaNV,NhanVien.Ten,NhanVien.GioiTinh,NhanVien.SDT,NhanVien.NgaySinh FROM NhanVien,BacSi WHERE NhanVien.MaNV = BacSi.MaNV AND BacSi.TrangThai = 'Inactive'";
            return Connection.selectQuery(query);
        }

        public DataTable selectedChangeQuery(int option)
        {
            string query = "";

            if (option == 0)
            {
                query = "SELECT NhanVien.MaNV,NhanVien.Ten,NhanVien.GioiTinh,NhanVien.SDT,NhanVien.NgaySinh FROM NhanVien,BacSi WHERE NhanVien.MaNV = BacSi.MaNV ORDER BY MaNV ASC";
            }
            else if (option == 1)
            {
                query = "SELECTNhanVien.MaNV,NhanVien.Ten,NhanVien.GioiTinh,NhanVien.SDT,NhanVien.NgaySinh FROM NhanVien,BacSi WHERE NhanVien.MaNV = BacSi.MaNV ORDER BY MaNV DESC";
            }
            else if (option == 2)
            {
                query = "SELECT NhanVien.MaNV,NhanVien.Ten,NhanVien.GioiTinh,NhanVien.SDT,NhanVien.NgaySinh FROM NhanVien,BacSi WHERE NhanVien.MaNV = BacSi.MaNV ORDER BY Luong ASC";
            }
            else if (option == 3)
            {
                query = "SELECT NhanVien.MaNV,NhanVien.Ten,NhanVien.GioiTinh,NhanVien.SDT,NhanVien.NgaySinh FROM NhanVien,BacSi WHERE NhanVien.MaNV = BacSi.MaNV ORDER BY Luong DESC";
            }

            return Connection.selectQuery(query);
        }

        public DataTable selectNVByID(string id)
        {
            string query = "SELECT * FROM NhanVien,BacSi,TaiKhoan WHERE NhanVien.MaNV = BacSi.MaNV AND NhanVien.MaNV = TaiKhoan.MaNV AND NhanVien.MaNV ='" + id + "'";
            return Connection.selectQuery(query);
        }

        public DataTable selectDataByID(string id)
        {
            string query = "SELECT * FROM NhanVien,TaiKhoan WHERE NhanVien.MaNV = TaiKhoan.MaNV AND NhanVien.MaNV = '" + id + "'";
            return Connection.selectQuery(query);
        }

        public DataTable selectStatusNV(string id)
        {
            string query = "SELECT TaiKhoan.TrangThai FROM NhanVien,TaiKhoan WHERE NhanVien.MaNV = TaiKhoan.MaNV AND TaiKhoan.MaNV ='" + id + "'";
            return Connection.selectQuery(query);
        }

        public DataTable searchDoctor(string value)
        {
            string query = "SELECT NhanVien.MaNV,NhanVien.Ten,NhanVien.GioiTinh,NhanVien.SDT,NhanVien.NgaySinh FROM NhanVien,BacSi WHERE (NhanVien.MaNV = BacSi.MaNV) AND (BacSi.TrangThai = 'Active') AND (Ten LIKE N'%" + value + "%' OR NhanVien.MaNV LIKE N'%" + value + "%')";
            return Connection.selectQuery(query);
        }

        public DataTable selectTimeFilter(DateTime first, DateTime second)
        {
            string query = "SELECT NhanVien.MaNV,NhanVien.Ten,NhanVien.GioiTinh,NhanVien.SDT,NhanVien.NgaySinh FROM NhanVien,BacSi WHERE (NhanVien.MaNV = BacSi.MaNV) AND (BacSi.TrangThai = 'Active')  AND (NgaySinh >= '" + first + "' AND NgaySinh < '" + second + "')";
            return Connection.selectQuery(query);
        }

        public DataTable getDoctorDesc()
        {
            string query = "SELECT TOP 1 MaNV FROM BacSi ORDER BY MaNV DESC";
            return Connection.selectQuery(query);
        }

        public void addQuery(string id)
        {
            string query = "INSERT INTO NhanVien VALUES ('" + id + "',N'" + nv._Ten + "','" + nv._SDT + "',N'" + nv._GioiTinh + "','" + nv._Email + "','" + nv._NgaySinh + "',N'" + nv._DiaChiLienHe + "','" + nv._CMND + "'," + nv._Luong + ",N'" + nv._VaiTro + "')";
            Connection.actionQuery(query);
        }

        public void updateQuery () {
            string query = "UPDATE NhanVien SET Ten = N'" + nv._Ten + "',SDT ='" + nv._SDT + "',GioiTinh = N'" + nv._GioiTinh + "',Email = '" + nv._Email + "',DiaChiLienHe = N'" + nv._DiaChiLienHe + "',CMND = '" + nv._CMND + "',NgaySinh = '" + nv._NgaySinh + "',Luong = " + nv._Luong + "WHERE MaNV = '" + nv._MaNV  + "'";
            Connection.actionQuery(query);
        }

        public string getMaNV()
        {
            return nv._MaNV;
        }


    }
}
