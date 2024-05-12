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

        public DataTable getMedicineDesc()
        {
            return t.getMedicineDesc();
        }

        public string getId()
        {
            DataTable tb = getMedicineDesc();
            string id = "";
            if (tb.Rows.Count > 0)
            {
                id = tb.Rows[0][0].ToString();
                int stt = int.Parse(id.Substring(2, 9)) + 1;
                if (stt < 10)
                {
                    id = "TH00000000" + stt.ToString();
                }
                else if (stt < 100)
                {
                    id = "TH0000000" + stt.ToString();
                }

                else if (stt < 1000)
                {
                    id = "TH000000" + stt.ToString();
                }
                else if (stt < 10000)
                {
                    id = "TH00000" + stt.ToString();
                }
                else if (stt < 100000)
                {
                    id = "TH0000" + stt.ToString();
                }
                else if (stt < 1000000)
                {
                    id = "TH000" + stt.ToString();
                }
                else if (stt < 10000000)
                {
                    id = "TH00" + stt.ToString();
                }
                else if (stt < 100000000)
                {
                    id = "TH0" + stt.ToString();
                }
                else if (stt < 1000000000)
                {
                    id = "TH" + stt.ToString();
                }
            }
            else
            {
                id = "TH000000001";
            }
            return id;
        }

        public string getMaTHDelete(DataGridView dataGridView1)
        {
            List<string> selectedValues = new List<string>();
            string text = "";
            foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
            {

                if (selectedRow.Cells["MaThuoc"].Value != null)
                {
                    selectedValues.Add(selectedRow.Cells["MaThuoc"].Value.ToString());
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
                MessageBox.Show("Bạn chưa chọn thuốc nào !");

            }
            else
            {
                text = text.Substring(0, text.Length - 1);
            }
            return text;
        }

        public void addQuery()
        {
            string id = getId();
            t.addQuery(id);
        }

        public DataTable selectQuery()
        {
            return t.selectQuery();
        }

        public DataTable selectDeleteQuery()
        {
            return t.selectDeleteQuery();
        }

        public DataTable selectSearch(string content)
        {
            return t.selectSearch(content);
        }

        public DataTable selectFilterTime(DateTime first, DateTime second)
        {
            return t.selectFilterTime(first, second);
        }

        public void updateQuery(DataGridView dataGridView1)
        {
            string text = getMaTHDelete(dataGridView1);
            t.updateQuery(text);
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
            string text = getMaTHDelete(dataGridView1);
            t.updateActiveQuery(text);
        }

    }
}
