using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace DAL
{
    public class DAL_Toa
    {
        DTO_Toa t;
        public DAL_Toa(string MaToa, string MaBN, string TienSu, string ChanDoan, string TrieuChung, string LoiDan, string TrangThai, int SoLuongThuoc, DateTime NgayLap, DateTime NgayTaiKham,BigInteger TongTien)
        {
            t = new DTO_Toa(MaToa, MaBN, TienSu, ChanDoan, TrieuChung, LoiDan, TrangThai, SoLuongThuoc, NgayLap, NgayTaiKham,TongTien);
        }

        public DataTable selectQuery()
        {
            string query = "SELECT Toa.MaToa, BenhNhan.Ten, Toa.TrieuChung, Toa.ChanDoan, Toa.TongTien ,Toa.NgayLap FROM Toa,BenhNhan WHERE Toa.TrangThai = 'Active' AND Toa.MaBN = BenhNhan.MaBN";
            return Connection.selectQuery(query);
        }

        public DataTable selectDeleteQuery()
        {
            string query = "SELECT Toa.MaToa, BenhNhan.Ten, Toa.TrieuChung, Toa.ChanDoan, Toa.TongTien, Toa.NgayLap FROM Toa,BenhNhan WHERE Toa.TrangThai = 'Inactive' AND Toa.MaBN = BenhNhan.MaBN";
            return Connection.selectQuery(query);
        }

        public DataTable selectDataByID(string id)
        {
            string query = "SELECT Toa.MaToa, BenhNhan.Ten, Toa.TrieuChung, Toa.ChanDoan, Toa.TongTien ,Toa.NgayLap FROM Toa,BenhNhan WHERE Toa.TrangThai = 'Active' AND Toa.MaBN = BenhNhan.MaBN AND Toa.MaBN ='" + id + "'";
            return Connection.selectQuery(query);
        }

        public DataTable selectMaThuoc(string MaToa)
        {
            string query = "SELECT * FROM ChiTietToaThuoc WHERE MaToa = '" + MaToa + "'";
            return Connection.selectQuery(query);
        }

        public DataTable selectSearch(string text)
        {
            string query = "SELECT Toa.MaToa, BenhNhan.Ten, Toa.TrieuChung, Toa.ChanDoan, Toa.TongTien ,Toa.NgayLap FROM Toa,BenhNhan WHERE Toa.TrangThai = 'Active' AND Toa.MaBN = BenhNhan.MaBN AND (Toa.MaToa LIKE '%" + text + "%' OR BenhNhan.Ten LIKE N'%" + text + "%')";
            return Connection.selectQuery(query);
        }

        public DataTable selectFilterTime(DateTime first, DateTime second)
        {
            string query = "SELECT Toa.MaToa, BenhNhan.Ten, Toa.TrieuChung, Toa.ChanDoan, Toa.TongTien ,Toa.NgayLap FROM Toa,BenhNhan WHERE Toa.TrangThai = 'Active' AND Toa.MaBN = BenhNhan.MaBN AND (Toa.NgayLap >= '" + first + "' AND Toa.NgayLap < '" + second + "')";
            return Connection.selectQuery(query);
        }

        public DataTable selectThuoc()
        {
            string query = "SELECT * FROM ChiTietToaThuoc";
            return Connection.selectQuery(query);
        }

        public DataTable selectMaDV(string MaToa)
        {
            string query = "SELECT * FROM ChiTietDichVu WHERE MaToa = '" + MaToa + "'";
            return Connection.selectQuery(query);
        }

        public DataTable selectNgayLap()
        {
            string query = "SELECT DISTINCT DAY(NgayLap) as Day,MONTH(NgayLap) as Month,YEAR(NgayLap) as Year FROM Toa ORDER BY DAY(NgayLap) DESC, MONTH(NgayLap) DESC, YEAR(NgayLap) DESC";
            return Connection.selectQuery(query);
        }

        public DataTable selectFilterNgayLap(DateTime first, DateTime second)
        {
            string query = "SELECT DISTINCT DAY(NgayLap) as Day,MONTH(NgayLap) as Month,YEAR(NgayLap) as Year FROM Toa WHERE Toa.NgayLap >= '" + first + "' AND Toa.NgayLap < '" + second + "' ORDER BY DAY(NgayLap) DESC, MONTH(NgayLap) DESC, YEAR(NgayLap) DESC";
            return Connection.selectQuery(query);
        }

        public DataTable selectSearchNgayLap(DateTime first)
        {
            string query = "SELECT DISTINCT DAY(NgayLap) as Day,MONTH(NgayLap) as Month,YEAR(NgayLap) as Year FROM Toa WHERE Toa.NgayLap = '" + first + "' ORDER BY DAY(NgayLap) DESC, MONTH(NgayLap) DESC, YEAR(NgayLap) DESC";
            return Connection.selectQuery(query);
        }

        public DataTable selectTongTienThuoc(int day,int month,int year)
        {
            string query = "SELECT SUM(TongTien) as Total FROM Toa WHERE DAY(NgayLap) = " + day + "AND MONTH(NgayLap) = " + month + "AND YEAR(NgayLap) = " + year + "GROUP BY DAY(NgayLap),MONTH(NgayLap),YEAR(NgayLap)";
            return Connection.selectQuery(query);
        }

        public DataTable getPrescriptionDesc()
        {
            string query = "SELECT TOP 1 MaToa FROM Toa ORDER BY MaToa DESC";
            return Connection.selectQuery(query);
        }

        public string getPrevId()
        {
            DataTable tb = getPrescriptionDesc();
            return tb.Rows[0][0].ToString();
        }

        public void addQuery(string id)
        {
            DateTime now = DateTime.Now;
            string query = "";

            if(t._NgayLap == t._NgayTaiKham)
            {
                query = "INSERT INTO Toa VALUES ('" + id + "','" + t._MaBN + "',N'" + t._TienSu + "',N'" + t._ChanDoan + "',N'" + t._TrieuChung + "','" + t._NgayLap + "'," + t._SoLuongThuoc + ",N'" + t._LoiDan + "'," + t._TongTien + ",'" + t._TrangThai + "','')";
            }
            else
            {
                query = "INSERT INTO Toa VALUES ('" + id + "','" + t._MaBN + "',N'" + t._TienSu + "',N'" + t._ChanDoan + "',N'" + t._TrieuChung + "','" + t._NgayLap + "'," + t._SoLuongThuoc + ",N'" + t._LoiDan + "'," + t._TongTien + ",'" + t._TrangThai + "','" + t._NgayTaiKham + "')";
            }
            Connection.actionQuery(query);
        }

        public void addDetailMedicine(string MaThuoc, string TenThuoc, string DVT, int SoLuong, BigInteger GiaBan, string CachDung)
        {
            string id = getPrevId().Trim();
            string query = "INSERT INTO ChiTietToaThuoc VALUES ('" + id + "','" + MaThuoc + "',N'" + TenThuoc + "',N'" + DVT + "'," + SoLuong + "," + GiaBan + ",N'" + CachDung + "')";
            Connection.actionQuery(query);
        }

        public void addDetailService(string MaDV, string Ten, string DVT, int SoLuong, BigInteger Gia)
        {
            string id = getPrevId();
            string query = "INSERT INTO ChiTietDichVu VALUES ('" + id  + "','" + MaDV + "',N'" + Ten + "',N'" + DVT + "'," + SoLuong + "," + Gia + ")";
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
                string query = "UPDATE Toa  SET TrangThai = 'Inactive' WHERE MaToa IN (" + text + ")";

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
                string query = "UPDATE Toa  SET TrangThai = 'Active' WHERE MaToa IN (" + text + ")";

                Connection.actionQuery(query);
            }
        }

        public DataTable getToaInfo(string MaToa)
        {
            string query = "SELECT * FROM Toa WHERE MaToa = '" + MaToa + "'";
            return Connection.selectQuery(query);
        }

        public void updateCurrentQuery()
        {
            string query = "UPDATE Toa SET TienSu = N'" + t._TienSu + "', ChanDoan = N'" + t._ChanDoan + "', TrieuChung = N'" + t._TrieuChung + "', SoLuongThuoc = " + t._SoLuongThuoc + ", LoiDan = N'" + t._LoiDan + "', TongTien = " + t._TongTien + ", NgayTaiKham = '" + t._NgayTaiKham + "' WHERE MaToa = '" + t._MaToa + "'";
            Connection.actionQuery(query);
        }
    }
}
