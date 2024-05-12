using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_TaiKhoan
    {
        DTO_TaiKhoan tk;

        public DAL_TaiKhoan(string TenTK, string MatKhau, string TrangThai, string MaNV, DateTime NgayLap)
        {
            tk = new DTO_TaiKhoan(TenTK, MatKhau, TrangThai, MaNV, NgayLap);
        }

        public void addQuery()
        {
            DateTime now = DateTime.Now;
            string query = "INSERT INTO TaiKhoan VALUES ('" + tk._TenTK + "','" + tk._MatKhau + "','" + tk._NgayLap + "','" + tk._TrangThai + "','" + tk._MaNV + "')";
            Connection.actionQuery(query);
        }

        public DataTable selectTKByID(string id)
        {
            string query = "SELECT * FROM TaiKhoan WHERE MaNV = '" + id + "'";
            return Connection.selectQuery(query);
        }

        public DataTable selectVaiTro(string tk,string mk)
        {
            string query = "SELECT VaiTro FROM NhanVien WHERE MaNV IN (SELECT MaNV FROM TaiKhoan WHERE TenTK = '" + tk + "' AND MatKhau = '" + mk + "')";
            return Connection.selectQuery(query);
        }

        public DataTable selectID(string tk, string mk)
        {
            string query = "SELECT MaNV FROM NhanVien WHERE MaNV IN (SELECT MaNV FROM TaiKhoan WHERE TenTK = '" + tk + "' AND MatKhau = '" + mk + "')";
            return Connection.selectQuery(query);
        }

        public Boolean checkQuery(string tk, string mk)
        {
            string query = "SELECT * FROM TaiKhoan WHERE TenTK = '" + tk + "' AND MatKhau = '" + mk + "'";
            return Connection.haveQuery(query);
        }

        public void updatePasswod(string pass)
        {
            string query = "UPDATE TaiKhoan SET MatKhau = '" + pass + "' WHERE MaNV = '" + tk._MaNV + "'";
            Connection.actionQuery(query);
        }

        public void updateStatusActive(string id)
        {
            string query = "UPDATE TaiKhoan SET TrangThai = 'Active' WHERE MaNV = '" + id + "'";
            Connection.actionQuery(query);
        }

        public void updateStatusInactive(string id)
        {
            string query = "UPDATE TaiKhoan SET TrangThai = 'Inactive' WHERE MaNV = '" + id + "'";
            Connection.actionQuery(query);
        }
    }
}
