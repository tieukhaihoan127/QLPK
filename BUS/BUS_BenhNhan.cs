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
    public class BUS_BenhNhan
    {
        DAL_BenhNhan bn;

        public BUS_BenhNhan(string MaBN, string Ten, string SDT, DateTime NgaySinh, string GioiTinh, string DiaChi, string CanNang, string Sp02, string NhietDo, string Mach, string HuyetAp, string NhipTho, string TrangThai,DateTime NgayLap)
        {
            bn = new DAL_BenhNhan(MaBN, Ten, SDT, NgaySinh, GioiTinh, DiaChi, CanNang, Sp02, NhietDo, Mach, HuyetAp, NhipTho, TrangThai,NgayLap);
        }

        public DataTable getPatientDesc()
        {
            return bn.getPatientDesc();
        }

        public string getId()
        {
            DataTable tb = getPatientDesc();
            string id = "";
            if (tb.Rows.Count > 0)
            {
                id = tb.Rows[0][0].ToString();
                int stt = int.Parse(id.Substring(2, 9)) + 1;
                if (stt < 10)
                {
                    id = "BN00000000" + stt.ToString();
                }
                else if (stt < 100)
                {
                    id = "BN0000000" + stt.ToString();
                }

                else if (stt < 1000)
                {
                    id = "BN000000" + stt.ToString();
                }
                else if (stt < 10000)
                {
                    id = "BN00000" + stt.ToString();
                }
                else if (stt < 100000)
                {
                    id = "BN0000" + stt.ToString();
                }
                else if (stt < 1000000)
                {
                    id = "BN000" + stt.ToString();
                }
                else if (stt < 10000000)
                {
                    id = "BN00" + stt.ToString();
                }
                else if (stt < 100000000)
                {
                    id = "BN0" + stt.ToString();
                }
                else if (stt < 1000000000)
                {
                    id = "BN" + stt.ToString();
                }
            }
            else
            {
                id = "BN000000001";
            }
            return id;
        }

        public string getMaBNDelete(DataGridView dataGridView1)
        {
            List<string> selectedValues = new List<string>();
            string text = "";
            foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
            {

                if (selectedRow.Cells["MaBN"].Value != null)
                {
                    selectedValues.Add(selectedRow.Cells["MaBN"].Value.ToString());
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
                MessageBox.Show("Bạn chưa chọn bệnh nhân nào !");

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
            bn.addQuery(id);
        }

        public DataTable selectQuery()
        {
            return bn.selectQuery();
        }

        public DataTable selectDeleteQuery()
        {
            return bn.selectDeleteQuery();
        }

        public DataTable selectSearch(string content)
        {
            return bn.selectSearch(content);
        }

        public DataTable selectFilterTime(DateTime first, DateTime second)
        {
            return bn.selectFilterTime(first, second);  
        }

        public DataTable selectPhoneNumber(string sdt)
        {
            return bn.selectPhoneNumber(sdt);
        }

        public void updateQuery(DataGridView dataGridView1)
        {
            string text = getMaBNDelete(dataGridView1);
            bn.updateQuery(text);
        }

        public DataTable getBNInfo(string MaBN)
        {
            return bn.getBNInfo(MaBN);
        }

        public void updateCurrentQuery()
        {
            bn.updateCurrentQuery();
        }

        public void updateActiveQuery(DataGridView dataGridView1)
        {
            string text = getMaBNDelete(dataGridView1);
            bn.updateActiveQuery(text);
        }
    }
}
