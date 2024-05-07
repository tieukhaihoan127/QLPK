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

        public string getId()
        {
            DataTable tb = getServicesDesc();
            string id = "";
            if (tb.Rows.Count > 0)
            {
                id = tb.Rows[0][0].ToString();
                int stt = int.Parse(id.Substring(2, 9)) + 1;
                if (stt < 10)
                {
                    id = "CD00000000" + stt.ToString();
                }
                else if (stt < 100)
                {
                    id = "CD0000000" + stt.ToString();
                }

                else if (stt < 1000)
                {
                    id = "CD000000" + stt.ToString();
                }
                else if (stt < 10000)
                {
                    id = "CD00000" + stt.ToString();
                }
                else if (stt < 100000)
                {
                    id = "CD0000" + stt.ToString();
                }
                else if (stt < 1000000)
                {
                    id = "CD000" + stt.ToString();
                }
                else if (stt < 10000000)
                {
                    id = "CD00" + stt.ToString();
                }
                else if (stt < 100000000)
                {
                    id = "CD0" + stt.ToString();
                }
                else if (stt < 1000000000)
                {
                    id = "CD" + stt.ToString();
                }
            }
            else
            {
                id = "CD000000001";
            }
            return id;
        }

        public string getPrevId()
        {
            DataTable tb = getServicesDesc();
            return tb.Rows[0][0].ToString();
        }

        public void addQuery()
        {
            string id = getId();
            DateTime now = DateTime.Now;
            string query = "";

            if (gcd._NgayLap == gcd._NgayTaiKham)
            {
                query = "INSERT INTO GiayChiDinh VALUES ('" + id + "','" + gcd._MaBN + "',N'" + gcd._TienSu + "',N'" + gcd._ChanDoan + "',N'" + gcd._TrieuChung + "','" + gcd._NgayLap  + "',N'" + gcd._LoiDan + "'," + gcd._TongTien + ",'" + gcd._TrangThai + "','')";
            }
            else
            {
                query = "INSERT INTO Toa VALUES ('" + id + "','" + gcd._MaBN + "',N'" + gcd._TienSu + "',N'" + gcd._ChanDoan + "',N'" + gcd._TrieuChung + "','" + gcd._NgayLap + "',N'" + gcd._LoiDan + "'," + gcd._TongTien + ",'" + gcd._TrangThai + "','" + gcd._NgayTaiKham + "')";
            }
            Connection.actionQuery(query);
        }

        public void addDetailService(string MaDV, string Ten, string DVT, BigInteger Gia)
        {
            string id = getPrevId();
            string query = "INSERT INTO ChiTietDichVu VALUES ('" + id + "','" + MaDV + "',N'" + Ten + "',N'" + DVT + "'," + Gia + ")";
            Connection.actionQuery(query);

        }

        public string getMaGCDDelete(DataGridView dataGridView1)
        {
            List<string> selectedValues = new List<string>();
            string text = "";
            foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
            {

                if (selectedRow.Cells["MaGCD"].Value != null)
                {
                    selectedValues.Add(selectedRow.Cells["MaGCD"].Value.ToString());
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
            string text = getMaGCDDelete(dataGridView1);
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

        public void updateActiveQuery(DataGridView dataGridView1)
        {
            string text = getMaGCDDelete(dataGridView1);
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
