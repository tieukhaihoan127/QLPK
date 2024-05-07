using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace BUS
{
    public class BUS_GiayChiDinh
    {
        DAL_GiayChiDinh gcd;
        public BUS_GiayChiDinh(string MaGCD, string MaBN, string TienSu, string ChanDoan, string TrieuChung, string LoiDan, string TrangThai, DateTime NgayLap, DateTime NgayTaiKham, BigInteger TongTien)
        {
            gcd = new DAL_GiayChiDinh(MaGCD, MaBN, TienSu, ChanDoan, TrieuChung, LoiDan, TrangThai, NgayLap, NgayTaiKham, TongTien);
        }

        public DataTable selectQuery()
        {
            return gcd.selectQuery();
        }

        public DataTable selectDeleteQuery()
        {
            return gcd.selectDeleteQuery();
        }


        public DataTable selectMaDV(string MaToa)
        {
            return gcd.selectMaDV(MaToa);
        }

        public DataTable selectTongTienDV(int day,int month,int year)
        {
            return gcd.selectTongTienDV(day,month,year);
        }

        public void addQuery()
        {
            gcd.addQuery();
        }

        public void addDetailService(string MaDV, string Ten, string DVT, BigInteger Gia)
        {
            gcd.addDetailService(MaDV, Ten, DVT, Gia);
        }

        public string getCurrentMaToa()
        {
            return gcd.getPrevId();
        }

        public void updateQuery(DataGridView dataGridView1)
        {
            gcd.updateQuery(dataGridView1);
        }

        public void updateActiveQuery(DataGridView dataGridView1)
        {
            gcd.updateActiveQuery(dataGridView1);
        }

        public DataTable getGCDInfo(string MaToa)
        {
            return gcd.getGCDInfo(MaToa);
        }

        public void updateCurrentQuery()
        {
            gcd.updateCurrentQuery();
        }
    }
}
