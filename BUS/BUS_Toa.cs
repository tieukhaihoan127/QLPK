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

        public DataTable selectDataByID(string id)
        {
            return t.selectDataByID(id);
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

        public DataTable selectFilterNgayLap(DateTime first, DateTime second)
        {
            return t.selectFilterNgayLap(first, second);
        }

        public DataTable getPrescriptionDesc()
        {
            return t.getPrescriptionDesc();
        }

        public string getId()
        {
            DataTable tb = getPrescriptionDesc();
            string id = "";
            if (tb.Rows.Count > 0)
            {
                id = tb.Rows[0][0].ToString();
                int stt = int.Parse(id.Substring(1, 9)) + 1;
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

        public int getTongSoLuongThuoc(DataGridView dataGridView1)
        {
            int TongSoLuong = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["SoLuong"].Value != null)
                {
                    TongSoLuong += (int.Parse(row.Cells["SoLuong"].Value.ToString()));
                }
            }
            return TongSoLuong;
        }

        public int getTongTien(DataGridView dataGridView1)
        {
            int TongTien = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["GiaBan"].Value != null)
                {
                    TongTien += (int.Parse(row.Cells["GiaBan"].Value.ToString()));
                }
            }
            return TongTien;
        }

        public BigInteger getTongTienThuoc(DataGridView dataGridView1)
        {
            int TongSoLuong = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["TongTienThuoc"].Value != null)
                {
                    TongSoLuong += (int.Parse(row.Cells["TongTienThuoc"].Value.ToString()));
                }
            }
            return TongSoLuong;
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

        public void addQuery()
        {
            string id = getId();
            t.addQuery(id);
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
                MessageBox.Show("Bạn chưa chọn toa nào !");

            }
            else
            {
                text = text.Substring(0, text.Length - 1);
            }
            return text;
        }

        public DataTable selectSearch(string text)
        {
            return t.selectSearch(text);
        }

        public DataTable selectFilterTime(DateTime first, DateTime second)
        {
            return t.selectFilterTime(first, second);
        }

        public DataTable selectSearchNgayLap(DateTime first)
        {
            return t.selectSearchNgayLap(first);
        }

        public void updateQuery(DataGridView dataGridView1)
        {
            string text = getMaToaDelete(dataGridView1);
            t.updateQuery(text);
        }

        public void updateActiveQuery(DataGridView dataGridView1)
        {
            string text = getMaToaDelete(dataGridView1);
            t.updateActiveQuery(text);
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
