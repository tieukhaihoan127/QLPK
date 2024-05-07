using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_Thuoc
    {
        DAL_Thuoc t;

        public BUS_Thuoc(string MaThuoc, string TenThuoc, string DonViTinh, BigInteger GiaNhap, BigInteger GiaBan, string DanhMuc, string NSX, DateTime NgayNhapHang, string CachDung, string TrangThai)
        {
            t = new DAL_Thuoc(MaThuoc, TenThuoc, DonViTinh, GiaNhap, GiaBan, DanhMuc, NSX, NgayNhapHang, CachDung, TrangThai);
        }

        public void addQuery()
        {
            t.addQuery();
        }

        public DataTable selectQuery()
        {
            return t.selectQuery();
        }

        public DataTable selectDeleteQuery()
        {
            return t.selectDeleteQuery();
        }

        public void updateQuery(DataGridView dataGridView1)
        {
            t.updateQuery(dataGridView1);
        }

        public DataTable getThuocInfo(string MaThuoc)
        {
            return t.getThuocInfo(MaThuoc);
        }

        public DataTable getThuocInfoByName(string TenThuoc)
        {
            return t.getThuocInfoByName(TenThuoc);
        }

        public DataTable getThuocName()
        {
            return t.getThuocName();
        }

        public void updateCurrentQuery()
        {
            t.updateCurrentQuery();
        }

        public void updateActiveQuery(DataGridView dataGridView1)
        {
            t.updateActiveQuery(dataGridView1);
        }

    }
}
