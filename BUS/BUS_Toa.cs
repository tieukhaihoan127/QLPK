using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BUS_Toa
    {
        DAL_Toa t;

        public BUS_Toa(string MaToa, string MaBN, string TienSu, string ChanDoan, string TrieuChung, string LoiDan, string TrangThai, int SoLuongThuoc, DateTime NgayLap, DateTime NgayTaiKham,BigInteger TongTien)
        {
            t = new DAL_Toa(MaToa, MaBN, TienSu, ChanDoan, TrieuChung, LoiDan, TrangThai, SoLuongThuoc, NgayLap, NgayTaiKham,TongTien);
        }

        public DataTable selectQuery()
        {
            return t.selectQuery();
        }

        public DataTable selectDeleteQuery()
        {
            return t.selectDeleteQuery();
        }

        public DataTable selectMaThuoc(string MaToa)
        {
            return t.selectMaThuoc(MaToa);
        }

        public DataTable selectThuoc()
        {
            return t.selectThuoc();
        }

        public DataTable selectMaDV(string MaToa)
        {
            return t.selectMaDV(MaToa);
        }

        public DataTable selectTongTienThuoc(int day,int month,int year)
        {
            return t.selectTongTienThuoc(day, month, year);
        }

        public DataTable selectNgayLap()
        {
            return t.selectNgayLap();
        }

        public void addQuery()
        {
            t.addQuery();
        }

        public void addDetailMedicine(string MaThuoc, string TenThuoc, string DVT, int SoLuong, BigInteger GiaBan, string CachDung)
        {
            t.addDetailMedicine(MaThuoc,TenThuoc,DVT,SoLuong,GiaBan,CachDung);
        }

        public void addDetailService(string MaDV, string Ten, string DVT, int SoLuong, BigInteger Gia)
        {
            t.addDetailService(MaDV,Ten,DVT,SoLuong,Gia);
        }

        public string getCurrentMaToa()
        {
            return t.getPrevId();   
        }

            public void updateQuery(DataGridView dataGridView1)
        {
            t.updateQuery(dataGridView1);
        }

        public void updateActiveQuery(DataGridView dataGridView1)
        {
            t.updateActiveQuery(dataGridView1);
        }

        public DataTable getToaInfo(string MaToa)
        {
            return t.getToaInfo(MaToa);
        }

        public void updateCurrentQuery()
        {
            t.updateCurrentQuery();
        }
    }
}
