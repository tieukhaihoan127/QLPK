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
    public class DAL_Thuoc
    {
        DTO_Thuoc t;


        public DAL_Thuoc(string MaThuoc, string TenThuoc, string DonViTinh, BigInteger GiaNhap, BigInteger GiaBan, string DanhMuc, string NSX, DateTime NgayNhapHang, string CachDung ,string TrangThai)
        {
            t = new DTO_Thuoc(MaThuoc, TenThuoc, DonViTinh, GiaNhap, GiaBan, DanhMuc, NSX, NgayNhapHang, CachDung, TrangThai);
        }

        public DataTable selectQuery()
        {
            string query = "SELECT MaThuoc,TenThuoc, DonViTinh, DanhMuc, NSX, GiaBan, CachDung, NgayNhapHang FROM Thuoc WHERE TrangThai = 'Active'";
            return Connection.selectQuery(query);
        }

        public DataTable selectDeleteQuery()
        {
            string query = "SELECT MaThuoc,TenThuoc, DonViTinh, DanhMuc, NSX, GiaBan, CachDung, NgayNhapHang FROM Thuoc WHERE TrangThai = 'Inactive'";
            return Connection.selectQuery(query);
        }

        public DataTable getMedicineDesc()
        {
            string query = "SELECT TOP 1 MaThuoc FROM Thuoc ORDER BY MaThuoc DESC";
            return Connection.selectQuery(query);
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

        public void addQuery()
        {
            string id = getId();
            DateTime now = DateTime.Now;
            string query = "INSERT INTO Thuoc VALUES ('" + id + "',N'" + t._TenThuoc + "',N'" + t._DonViTinh + "'," + t._GiaNhap + "," + t._GiaBan + ",N'" + t._DanhMuc + "',N'" + t._NSX + "','" + t._NgayNhapHang + "',N'" + t._CachDung + "','" + t._TrangThai + "')"; 
            Connection.actionQuery(query);
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
            string text = getMaTHDelete(dataGridView1);
            if (text == "")
            {
                return;
            }
            else
            {
                string query = "UPDATE Thuoc  SET TrangThai = 'Inactive' WHERE MaThuoc IN (" + text + ")";

                Connection.actionQuery(query);
            }
        }

        public void updateActiveQuery(DataGridView dataGridView1)
        {
            string text = getMaTHDelete(dataGridView1);
            if (text == "")
            {
                return;
            }
            else
            {
                string query = "UPDATE Thuoc  SET TrangThai = 'Active' WHERE MaThuoc IN (" + text + ")";

                Connection.actionQuery(query);
            }
        }

        public DataTable getThuocInfo(string MaThuoc)
        {
            string query = "SELECT * FROM Thuoc WHERE MaThuoc = '" + MaThuoc + "'";
            return Connection.selectQuery(query);
        }

        public DataTable getThuocName()
        {
            string query = "SELECT TenThuoc FROM Thuoc";
            return Connection.selectQuery(query);
        }

        public DataTable getThuocInfoByName(string TenThuoc) {
            string query = "SELECT * FROM Thuoc WHERE TenThuoc = '" + TenThuoc + "'";
            return Connection.selectQuery(query);
        }

        public void updateCurrentQuery()
        {
            string query = "UPDATE Thuoc SET TenThuoc = N'" + t._TenThuoc + "', DonViTinh = N'" + t._DonViTinh + "', GiaNhap =" + t._GiaNhap + ", GiaBan = " + t._GiaBan + ", DanhMuc = N'" + t._DanhMuc + "', NSX = N'" + t._NSX + "', CachDung = N'" + t._CachDung + "' WHERE MaThuoc = '" + t._MaThuoc + "'";
            Connection.actionQuery(query);
        }
    }
}
