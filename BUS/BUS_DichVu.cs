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
    public class BUS_DichVu
    {
        DAL_DichVu dv;

        public BUS_DichVu(string MaDV, string Ten, BigInteger Gia, string DonVi, DateTime NgayLap, string TrangThai)
        {
           dv = new DAL_DichVu(MaDV, Ten, Gia, DonVi, NgayLap, TrangThai);
        }

        public DataTable selectQuery()
        {
            return dv.selectQuery();
        }

        public DataTable selectDeleteQuery()
        {
            return dv.selectDeleteQuery();
        }
        public DataTable selectSearch(string content)
        {
            return dv.selectSearch(content);
        }

        public DataTable selectTimeFilter(DateTime first, DateTime second)
        {
            return dv.selectTimeFilter(first, second);
        }

        public DataTable getDVDesc()
        {
            return dv.getDVDesc();
        }

        public string getId()
        {
            DataTable tb = getDVDesc();
            string id = "";
            if (tb.Rows.Count > 0)
            {
                id = tb.Rows[0][0].ToString();
                int stt = int.Parse(id.Substring(2, 9)) + 1;
                if (stt < 10)
                {
                    id = "DV00000000" + stt.ToString();
                }
                else if (stt < 100)
                {
                    id = "DV0000000" + stt.ToString();
                }

                else if (stt < 1000)
                {
                    id = "DV000000" + stt.ToString();
                }
                else if (stt < 10000)
                {
                    id = "DV00000" + stt.ToString();
                }
                else if (stt < 100000)
                {
                    id = "DV0000" + stt.ToString();
                }
                else if (stt < 1000000)
                {
                    id = "DV000" + stt.ToString();
                }
                else if (stt < 10000000)
                {
                    id = "DV00" + stt.ToString();
                }
                else if (stt < 100000000)
                {
                    id = "DV0" + stt.ToString();
                }
                else if (stt < 1000000000)
                {
                    id = "DV" + stt.ToString();
                }
            }
            else
            {
                id = "DV000000001";
            }
            return id;
        }

        public string getMaDVDelete(DataGridView dataGridView1)
        {
            List<string> selectedValues = new List<string>();
            string text = "";
            foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
            {

                if (selectedRow.Cells["MaDV"].Value != null)
                {
                    selectedValues.Add(selectedRow.Cells["MaDV"].Value.ToString());
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
                MessageBox.Show("Bạn chưa chọn dịch vụ nào !");

            }
            else
            {
                text = text.Substring(0, text.Length - 1);
            }
            return text;
        }

        public DataTable getDVInfo(string MaDV)
        {
            return dv.getDVInfo(MaDV);
        }

        public DataTable getDVName()
        {
            return dv.getDVName();
        }

        public DataTable getDVInfoByName(string MaDV)
        {
            return dv.getDVInfoByName(MaDV);
        }

        public void addQuery()
        {
            string id = getId();
            dv.addQuery(id);
        }

        public void updateCurrentQuery()
        {
            dv.updateCurrentQuery();
        }

        public void updateActiveQuery(DataGridView dataGridView1)
        {
            string text = getMaDVDelete(dataGridView1);
            dv.updateActiveQuery(text);
        }

        public void updateQuery(DataGridView dataGridView1)
        {
            string text = getMaDVDelete(dataGridView1);
            dv.updateQuery(text);
        }
    }
}
