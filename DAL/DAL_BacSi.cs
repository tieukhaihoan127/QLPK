using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DAL
{
    public class DAL_BacSi
    {
        DTO_BacSi bs;

        public DAL_BacSi(string MaNV, string ChuyenNganh, string HocVan, string KinhNghiem, string NgonNgu, string TrangThai)
        {
            bs = new DTO_BacSi(MaNV,ChuyenNganh,HocVan,KinhNghiem,NgonNgu, TrangThai);
        }

        public DataTable getDoctorDesc()
        {
            string query = "SELECT TOP 1 MaNV FROM BacSi ORDER BY MaNV DESC";
            return Connection.selectQuery(query);
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

        public void addQuery()
        {

            string id = getId();
            string query = "INSERT INTO BacSi VALUES ('" + id + "',N'" + bs._ChuyenNganh + "',N'" + bs._HocVan + "',N'" + bs._KinhNghiem + "',N'" + bs._NgonNgu + "','" + bs._TrangThai + "')";
            Connection.actionQuery(query);
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
                if(text == "")
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
            string text = getMaNVDelete(dataGridView1);
            if(text == "")
            {
                return;
            }
            else
            {
                string query = "UPDATE BacSi  SET TrangThai = 'Inactive' WHERE MaNV IN (" + text + ")";

                Connection.actionQuery(query);
            }
        }

        public void updateActiveQuery(DataGridView dataGridView1)
        {
            string text = getMaNVDelete(dataGridView1);
            if (text == "")
            {
                return;
            }
            else
            {
                string query = "UPDATE BacSi  SET TrangThai = 'Active' WHERE MaNV IN (" + text + ")";

                Connection.actionQuery(query);
            }
        }

        public void updateCurrentQuery()
        {
            string query = "UPDATE BacSi SET ChuyenNganh = N'" + bs._ChuyenNganh + "',HocVan = N'" + bs._HocVan + "', KinhNghiem = N'" + bs._KinhNghiem + "',NgonNgu = N'" + bs._NgonNgu + "' WHERE MaNV = '" + bs._MaNV + "'";
            Connection.actionQuery(query);
        }

    }
}
