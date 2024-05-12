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

        public void addDetailService(string MaDV, string Ten, string DVT, BigInteger Gia)
        {
            gcd.addDetailService(MaDV, Ten, DVT, Gia);
        }

        public DataTable getServicesDesc()
        {
            return gcd.getServicesDesc();
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

        public int getIndexValueExistInColumn(string value, DataGridView dataGridView1)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == value)
                {
                    return row.Index;
                }
            }
            return -1;
        }

        public string getCurrentMaToa()
        {
            return gcd.getPrevId();
        }

        public void updateQuery(DataGridView dataGridView1)
        {
            string text = getMaGCDDelete(dataGridView1);
            gcd.updateQuery(text);
        }

        public void updateActiveQuery(DataGridView dataGridView1)
        {
            string text = getMaGCDDelete(dataGridView1);
            gcd.updateActiveQuery(text);
        }

        public DataTable getGCDInfo(string MaToa)
        {
            return gcd.getGCDInfo(MaToa);
        }

        public void updateCurrentQuery()
        {
            gcd.updateCurrentQuery();
        }

        public void addQuery()
        {
            string id = getId();
            gcd.addQuery(id);
        }

        public BigInteger getTongTien(DataGridView dataGridView1)
        {
            int TongSoLuong = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["GiaBan"].Value != null)
                {
                    TongSoLuong += (int.Parse(row.Cells["GiaBan"].Value.ToString()));
                }
            }
            return TongSoLuong;
        }

        public BigInteger getTongTienDichVu(DataGridView dataGridView1)
        {
            int TongSoLuong = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["TongTienDIchVu"].Value != null)
                {
                    TongSoLuong += (int.Parse(row.Cells["TongTienDichVu"].Value.ToString()));
                }
            }
            return TongSoLuong;
        }
    }
}
