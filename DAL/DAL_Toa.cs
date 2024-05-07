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

        public DataTable selectMaThuoc(string MaToa)
        {
            string query = "SELECT * FROM ChiTietToaThuoc WHERE MaToa = '" + MaToa + "'";
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

        public string getId()
        {
            DataTable tb = getPrescriptionDesc();
            string id = "";
            if (tb.Rows.Count > 0)
            {
                id = tb.Rows[0][0].ToString();
                int stt = int.Parse(id.Substring(1,9)) + 1;
                if (stt < 10)
                {
                    id = "T00000000" + stt.ToString();
                }
                else if (stt < 100)
                {
                    id = "T0000000" + stt.ToString();
                }

                else if (stt < 1000)
                {
                    id = "T000000" + stt.ToString();
                }
                else if (stt < 10000)
                {
                    id = "T00000" + stt.ToString();
                }
                else if (stt < 100000)
                {
                    id = "T0000" + stt.ToString();
                }
                else if (stt < 1000000)
                {
                    id = "T000" + stt.ToString();
                }
                else if (stt < 10000000)
                {
                    id = "T00" + stt.ToString();
                }
                else if (stt < 100000000)
                {
                    id = "T0" + stt.ToString();
                }
                else if (stt < 1000000000)
                {
                    id = "T" + stt.ToString();
                }
            }
            else
            {
                id = "T000000001";
            }
            return id;
        }

        public string getPrevId()
        {
            DataTable tb = getPrescriptionDesc();
            return tb.Rows[0][0].ToString();
        }

        public void addQuery()
        {
            string id = getId();
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
            MessageBox.Show(id);
            string query = "INSERT INTO ChiTietToaThuoc VALUES ('" + id + "','" + MaThuoc + "',N'" + TenThuoc + "',N'" + DVT + "'," + SoLuong + "," + GiaBan + ",N'" + CachDung + "')";
            Connection.actionQuery(query);
        }

        public void addDetailService(string MaDV, string Ten, string DVT, int SoLuong, BigInteger Gia)
        {
            string id = getPrevId();
            string query = "INSERT INTO ChiTietDichVu VALUES ('" + id  + "','" + MaDV + "',N'" + Ten + "',N'" + DVT + "'," + SoLuong + "," + Gia + ")";
            Connection.actionQuery(query);

        }

        public string getMaToaDelete(DataGridView dataGridView1)
        {
            List<string> selectedValues = new List<string>();
            string text = "";
            foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
            {

                if (selectedRow.Cells["MaToa"].Value != null)
                {
                    selectedValues.Add(selectedRow.Cells["MaToa"].Value.ToString());
                }
            }
            foreach (string value in selectedValues)
            {
                text += "'";
                text += value.Trim();
                text += "',";
            }
            if (text == "")
            {
                MessageBox.Show("Bạn chưa chọn nhân viên nào !");

            }
            else
            {
                text = text.Substring(0, text.Length - 1);
            }
            return text;
        }

        public void updateQuery(DataGridView dataGridView1)
        {
            string text = getMaToaDelete(dataGridView1);
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

        public void updateActiveQuery(DataGridView dataGridView1)
        {
            string text = getMaToaDelete(dataGridView1);
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
