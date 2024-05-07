using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using DAL;
using System.Data;
using System.Collections;
using System.Windows.Forms;

namespace BUS
{
    public class BUS_NhanVien
    {
        DAL_NhanVien nv;

        public BUS_NhanVien(string MaNV, string Ten, string SDT, string GioiTinh, string Email, string DiaChiLienHe, string CMND, string VaiTro, DateTime NgaySinh, BigInteger luong)
        {
            nv = new DAL_NhanVien(MaNV, Ten, SDT, GioiTinh, Email, DiaChiLienHe, CMND, VaiTro, NgaySinh, luong);
        }

        public void addQuery()
        {
            nv.addQuery();
        }

        public DataTable selectQuery()
        {
            return nv.selectQuery();
        }

        public DataTable selectDeleteQuery()
        {
            return nv.selectDeleteQuery();
        }

        public DataTable selectedChangeQuery(int option)
        {
            return nv.selectedChangeQuery(option);
        }

        public DataTable selectNVByID(string id)
        {
            return nv.selectNVByID(id);
        }

        public DataTable searchDoctor(string value)
        {
            return nv.searchDoctor(value);
        }

        public DataTable getDoctorDesc()
        {
            return nv.getDoctorDesc();
        }

        public void updateQuery()
        {
            nv.updateQuery();
        }

        public string getMaNV()
        {
            return nv.getMaNV();
        }
    }
}
