using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace DAL
{
    public class DAL_DichVu
    {
        DTO_DichVu dv;


        public DAL_DichVu(string MaDV, string Ten, BigInteger Gia, string DonVi, DateTime NgayLap, string TrangThai)
        {
            dv = new DTO_DichVu(MaDV,Ten,Gia,DonVi,NgayLap,TrangThai);
        }

        public DataTable selectQuery()
        {
            string query = "SELECT MaDV,Ten,Gia,DonVi,NgayLap FROM DichVu WHERE TrangThai = 'Active'";
            return Connection.selectQuery(query);
        }

        public DataTable selectDeleteQuery()
        {
            string query = "SELECT MaDV,Ten,Gia,DonVi,NgayLap FROM DichVu WHERE TrangThai = 'Inactive'";
            return Connection.selectQuery(query);
        }

        public DataTable getDVDesc()
        {
            string query = "SELECT TOP 1 MaDV FROM DichVu ORDER BY MaDV DESC";
            return Connection.selectQuery(query);
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

        public void addQuery()
        {
            string id = getId();
            DateTime now = DateTime.Now;
            string query = "INSERT INTO DichVu VALUES ('" + id + "',N'" + dv._Ten + "'," + dv._Gia + ",N'" + dv._DonVi + "','" + dv._NgayLap + "','" + dv._TrangThai + "')";
            Connection.actionQuery(query);
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

        public void updateQuery(DataGridView dataGridView1)
        {
            string text = getMaDVDelete(dataGridView1);
            if (text == "")
            {
                return;
            }
            else
            {
                string query = "UPDATE DichVu  SET TrangThai = 'Inactive' WHERE MaDV IN (" + text + ")";

                Connection.actionQuery(query);
            }
        }

        public void updateActiveQuery(DataGridView dataGridView1)
        {
            string text = getMaDVDelete(dataGridView1);
            if (text == "")
            {
                return;
            }
            else
            {
                string query = "UPDATE DichVu  SET TrangThai = 'Active' WHERE MaDV IN (" + text + ")";

                Connection.actionQuery(query);
            }
        }

        public DataTable getDVInfo(string MaDV)
        {
            string query = "SELECT * FROM DichVu WHERE MaDV = '" + MaDV + "'";
            return Connection.selectQuery(query);
        }

        public DataTable getDVName()
        {
            string query = "SELECT Ten FROM DichVu";
            return Connection.selectQuery(query);
        }

        public DataTable getDVInfoByName(string MaDV)
        {
            string query = "SELECT * FROM DichVu WHERE Ten = N'" + MaDV + "'";
            return Connection.selectQuery(query);
        }

        public void updateCurrentQuery()
        {
            string query = "UPDATE DichVu SET Ten = N'" + dv._Ten + "', Gia = " + dv._Gia + ", DonVi = N'"  + dv._DonVi + "' WHERE MaDV = '" + dv._MaDV + "'";
            Connection.actionQuery(query);
        }
    }
}
