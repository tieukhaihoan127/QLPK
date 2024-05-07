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

        public void updatePasswod(string pass)
        {
            string query = "UPDATE TaiKhoan SET MatKhau = '" + pass + "' WHERE TenTK = '" + tk._TenTK + "'";
            Connection.actionQuery(query);
        }
    }
}
