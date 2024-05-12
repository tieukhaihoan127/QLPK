using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace BUS
{
    public class BUS_BacSi
    {
        DAL_BacSi bs;

        public BUS_BacSi(string MaNV, string ChuyenNganh, string HocVan, string KinhNghiem, string NgonNgu, string TrangThai)
        {
            bs = new DAL_BacSi(MaNV, ChuyenNganh, HocVan, KinhNghiem, NgonNgu, TrangThai);
        }

        public DataTable getDoctorDesc()
        {
            return bs.getDoctorDesc();
        }

        public string getId()
        {
            DataTable tb = getDoctorDesc();
            string id = "";
            if (tb.Rows.Count > 0)
            {
                id = tb.Rows[0][0].ToString();
                int stt = int.Parse(id.Substring(2, 5)) + 1;
                if (stt < 10)
                {
                    id = "BS000" + stt.ToString();
                }
                else if (stt < 100)
                {
                    id = "BS00" + stt.ToString();
                }

                else if (stt < 1000)
                {
                    id = "BS0" + stt.ToString();
                }
                else
                {
                    id = "BS" + stt.ToString();
                }
            }
            else
            {
                id = "BS01";
            }
            return id;
        }

        public string getMaNVDelete(DataGridView dataGridView1)
        {
            List<string> selectedValues = new List<string>();
            string text = "";
            foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
            {

                if (selectedRow.Cells["MaNV"].Value != null)
                {
                    selectedValues.Add(selectedRow.Cells["MaNV"].Value.ToString());
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

        public void addQuery()
        {
            string id = getId();
            bs.addQuery(id);
        }

        public void updateQuery(DataGridView dataGridView1)
        {
            string text = getMaNVDelete(dataGridView1);
            bs.updateQuery(text);
        }

        public void updateCurrentQuery()
        {
            bs.updateCurrentQuery();
        }

        public void updateActiveQuery(DataGridView dataGridView1)
        {
            string text = getMaNVDelete(dataGridView1);
            bs.updateActiveQuery(text);
        }
    }
}
