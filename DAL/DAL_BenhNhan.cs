using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using Microsoft.Identity.Client;
namespace DAL
{
    public class DAL_BenhNhan
    {
        DTO_BenhNhan bn;

        public DAL_BenhNhan(string MaBN, string Ten, string SDT, DateTime NgaySinh, string GioiTinh, string DiaChi, string CanNang, string Sp02, string NhietDo, string Mach, string HuyetAp, string NhipTho, string TrangThai,DateTime NgayLap)
        {
            bn = new DTO_BenhNhan(MaBN, Ten, SDT, NgaySinh, GioiTinh, DiaChi, CanNang, Sp02, NhietDo, Mach, HuyetAp, NhipTho, TrangThai,NgayLap);
        }

        public DataTable selectQuery()
        {
            string query = "SELECT MaBN,Ten,GioiTinh,NgaySinh,DiaChi,SDT,NgayLap FROM BenhNhan WHERE TrangThai = 'Active'";
            return Connection.selectQuery(query);
        }

        public DataTable selectDeleteQuery()
        {
            string query = "SELECT MaBN,Ten,GioiTinh,NgaySinh,DiaChi,SDT,NgayLap FROM BenhNhan WHERE TrangThai = 'Inactive'";
            return Connection.selectQuery(query);
        }

        public DataTable getPatientDesc()
        {
            string query = "SELECT TOP 1 MaBN FROM BenhNhan ORDER BY MaBN DESC";
            return Connection.selectQuery(query);
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
                else if(stt < 10000)
                {
                    id = "BN00000" + stt.ToString();
                }
                else if(stt < 100000)
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

        public void addQuery()
        {
            string id = getId();
            DateTime now = DateTime.Now;
            string query = "INSERT INTO BenhNhan VALUES ('" + id + "',N'" + bn._Ten + "','" + bn._SDT + "','" + bn._NgaySinh + "',N'" + bn._GioiTinh + "',N'" + bn._DiaChi + "','" + bn._CanNang + "','" + bn._Sp02 + "','" + bn._NhietDo + "','" + bn._Mach + "','" + bn._HuyetAp + "','" + bn._NhipTho + "','" + bn._TrangThai + "','" + now + "')";
            Connection.actionQuery(query);
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
            string text = getMaBNDelete(dataGridView1);
            if (text == "")
            {
                return;
            }
            else
            {
                string query = "UPDATE BenhNhan  SET TrangThai = 'Inactive' WHERE MaBN IN (" + text + ")";

                Connection.actionQuery(query);
            }
        }

        public void updateActiveQuery(DataGridView dataGridView1)
        {
            string text = getMaBNDelete(dataGridView1);
            if (text == "")
            {
                return;
            }
            else
            {
                string query = "UPDATE BenhNhan  SET TrangThai = 'Active' WHERE MaBN IN (" + text + ")";

                Connection.actionQuery(query);
            }
        }

        public DataTable getBNInfo(string MaBN)
        {
            string query = "SELECT * FROM BenhNhan WHERE MaBN = '" + MaBN + "'";
            return Connection.selectQuery(query);
        }

        public void updateCurrentQuery()
        {
            string query = "UPDATE BenhNhan SET Ten = N'" + bn._Ten + "', SDT = '" + bn._SDT + "', NgaySinh = '" + bn._NgaySinh + "', GioiTinh = N'" + bn._GioiTinh + "', DiaChi = N'" + bn._DiaChi + "', CanNang = '" + bn._CanNang + "', sp02 = '" + bn._Sp02 + "', NhietDo = '" + bn._NhietDo + "', Mach ='" + bn._Mach + "', HuyetAp = '" + bn._HuyetAp + "', NhipTho = '" + bn._NhipTho + " 'WHERE MaBN = '" + bn._MaBN + "'";
            Connection.actionQuery(query);
        }
    }
}
