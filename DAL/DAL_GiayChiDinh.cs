using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Threading.Tasks;
using System.Data;
using System.Numerics;
using System.Windows.Forms;

namespace DAL
{
    public class DAL_GiayChiDinh
    {
        DTO_GiayChiDinh gcd;
        public DAL_GiayChiDinh(string MaGCD, string MaBN, string TienSu, string ChanDoan, string TrieuChung, string LoiDan, string TrangThai , DateTime NgayLap, DateTime NgayTaiKham, BigInteger TongTien)
        {
            gcd = new DTO_GiayChiDinh(MaGCD, MaBN, TienSu, ChanDoan, TrieuChung, LoiDan, TrangThai , NgayLap, NgayTaiKham, TongTien);
        }

        public DataTable selectQuery()
        {
            string query = "SELECT GiayChiDinh.MaGCD, BenhNhan.Ten, GiayChiDinh.TrieuChung, GiayChiDinh.ChanDoan, GiayChiDinh.TongTien ,GiayChiDinh.NgayLap FROM GiayChiDinh,BenhNhan WHERE GiayChiDinh.TrangThai = 'Active' AND GiayChiDinh.MaBN = BenhNhan.MaBN";
            return Connection.selectQuery(query);
        }

        public DataTable selectDeleteQuery()
        {
            string query = "SELECT GiayChiDinh.MaGCD, BenhNhan.Ten, GiayChiDinh.TrieuChung, GiayChiDinh.ChanDoan, GiayChiDinh.TongTien ,GiayChiDinh.NgayLap FROM GiayChiDinh,BenhNhan WHERE GiayChiDinh.TrangThai = 'Inactive' AND GiayChiDinh.MaBN = BenhNhan.MaBN";
            return Connection.selectQuery(query);
        }

        public DataTable selectMaDV(string MaGCD)
        {
            string query = "SELECT * FROM ChiTietDichVu WHERE MaGCD = '" + MaGCD + "'";
            return Connection.selectQuery(query);
        }

        public DataTable selectTongTienDV(int day, int month, int year)
        {
            string query = "SELECT SUM(TongTien) as Total FROM GiayChiDinh WHERE DAY(NgayLap) = " + day + "AND MONTH(NgayLap) = " + month + "AND YEAR(NgayLap) = " + year + "GROUP BY DAY(NgayLap),MONTH(NgayLap),YEAR(NgayLap)";
            return Connection.selectQuery(query);
        }

        public DataTable getServicesDesc()
        {
            string query = "SELECT TOP 1 MaGCD FROM GiayChiDinh ORDER BY MaGCD DESC";
            return Connection.selectQuery(query);
        }

        public string getPrevId()
        {
            DataTable tb = getServicesDesc();
            return tb.Rows[0][0].ToString();
        }

        public void addQuery(string id)
        {
            DateTime now = DateTime.Now;
            string query = "";

            if (gcd._NgayLap == gcd._NgayTaiKham)
            {
                query = "INSERT INTO GiayChiDinh VALUES ('" + id + "','" + gcd._MaBN + "',N'" + gcd._TienSu + "',N'" + gcd._ChanDoan + "',N'" + gcd._TrieuChung + "','" + gcd._NgayLap  + "',N'" + gcd._LoiDan + "'," + gcd._TongTien + ",'" + gcd._TrangThai + "','')";
            }
            else
            {
                query = "INSERT INTO GiayChiDinh VALUES ('" + id + "','" + gcd._MaBN + "',N'" + gcd._TienSu + "',N'" + gcd._ChanDoan + "',N'" + gcd._TrieuChung + "','" + gcd._NgayLap + "',N'" + gcd._LoiDan + "'," + gcd._TongTien + ",'" + gcd._TrangThai + "','" + gcd._NgayTaiKham + "')";
            }
            Connection.actionQuery(query);
        }

        public void addDetailService(string MaDV, string Ten, string DVT, BigInteger Gia)
        {
            string id = getPrevId();
            string query = "INSERT INTO ChiTietDichVu VALUES ('" + id + "','" + MaDV + "',N'" + Ten + "',N'" + DVT + "'," + Gia + ")";
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
                string query = "UPDATE GiayChiDinh  SET TrangThai = 'Inactive' WHERE MaGCD IN (" + text + ")";

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
                string query = "UPDATE GiayChiDinh  SET TrangThai = 'Active' WHERE MaGCD IN (" + text + ")";

                Connection.actionQuery(query);
            }
        }

        public DataTable getGCDInfo(string MaGCD)
        {
            string query = "SELECT * FROM GiayChiDinh WHERE MaGCD = '" + MaGCD + "'";
            return Connection.selectQuery(query);
        }

        public void updateCurrentQuery()
        {
            string query = "UPDATE GiayChiDinh SET TienSu = N'" + gcd._TienSu + "', ChanDoan = N'" + gcd._ChanDoan + "', TrieuChung = N'" + gcd._TrieuChung +  "', LoiDan = N'" + gcd._LoiDan + "', TongTien = " + gcd._TongTien + ", NgayTaiKham = '" + gcd._NgayTaiKham + "' WHERE MaGCD = '" + gcd._MaGCD + "'";
            Connection.actionQuery(query);
        }
    }
}
