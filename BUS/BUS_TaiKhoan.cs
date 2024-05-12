using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_TaiKhoan
    {
        DAL_TaiKhoan acc;

        public BUS_TaiKhoan(string TenTK, string MatKhau, string TrangThai, string MaNV, DateTime NgayLap)
        {
            acc = new DAL_TaiKhoan(TenTK, MatKhau, TrangThai, MaNV, NgayLap);
        }

        public void addQuery()
        {
            acc.addQuery();
        }

        public DataTable selectTKByID(string id)
        {
            return acc.selectTKByID(id);
        }

        public DataTable selectVaiTro(string tk, string mk)
        {
            return acc.selectVaiTro(tk, mk);
        }
        public DataTable selectID(string tk, string mk)
        {
            return acc.selectID(tk, mk);
        }


        public Boolean checkQuery(string tk, string mk)
        {
            return acc.checkQuery(tk, mk);
        }

        public void updatePasswod(string pass)
        {
            acc.updatePasswod(pass);
        }

        public void updateStatusActive(string id)
        {
            acc.updateStatusActive(id);
        }

        public void updateStatusInactive(string id)
        {
            acc.updateStatusInactive(id);
        }
    }
}
