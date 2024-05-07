using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_TaiKhoan
    {
        DAL_TaiKhoan tk;

        public BUS_TaiKhoan(string TenTK, string MatKhau, string TrangThai, string MaNV, DateTime NgayLap)
        {
            tk = new DAL_TaiKhoan(TenTK, MatKhau, TrangThai, MaNV, NgayLap);
        }

        public void addQuery()
        {
            tk.addQuery();
        }

        public void updatePasswod(string pass)
        {
            tk.updatePasswod(pass);
        }
    }
}
