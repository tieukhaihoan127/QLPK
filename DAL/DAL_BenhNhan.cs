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
            string query = "SELECT MaBN,Ten,GioiTinh,NgaySinh,SDT,NgayLap FROM BenhNhan WHERE TrangThai = 'Active'";
            return Connection.selectQuery(query);
        }

        public DataTable selectDeleteQuery()
        {
            string query = "SELECT MaBN,Ten,GioiTinh,NgaySinh,SDT,NgayLap FROM BenhNhan WHERE TrangThai = 'Inactive'";
            return Connection.selectQuery(query);
        }

        public DataTable selectSearch(string content)
        {
            string query = "SELECT MaBN,Ten,GioiTinh,NgaySinh,SDT,NgayLap FROM BenhNhan WHERE TrangThai = 'Active' AND (MaBN LIKE N'%" + content + "%' OR Ten LIKE N'%" + content + "%')";
            return Connection.selectQuery(query);
        }

        public DataTable selectFilterTime(DateTime first,DateTime second)
        {
            string query = "SELECT MaBN,Ten,GioiTinh,NgaySinh,DiaChi,SDT,NgayLap FROM BenhNhan WHERE TrangThai = 'Active' AND (NgayLap >= '" + first + "' AND NgayLap < '" + second + "')";
            return Connection.selectQuery(query);
        }

        public DataTable selectPhoneNumber(string sdt)
        {
            string query = "SELECT * FROM BenhNhan WHERE SDT ='" + sdt + "'";
            return Connection.selectQuery(query);
        }

        public DataTable getPatientDesc()
        {
            string query = "SELECT TOP 1 MaBN FROM BenhNhan ORDER BY MaBN DESC";
            return Connection.selectQuery(query);
        }

        public void addQuery(string id)
        {
            DateTime now = DateTime.Now;
            string query = "INSERT INTO BenhNhan VALUES ('" + id + "',N'" + bn._Ten + "','" + bn._SDT + "','" + bn._NgaySinh + "',N'" + bn._GioiTinh + "',N'" + bn._DiaChi + "','" + bn._CanNang + "','" + bn._Sp02 + "','" + bn._NhietDo + "','" + bn._Mach + "','" + bn._HuyetAp + "','" + bn._NhipTho + "','" + bn._TrangThai + "','" + now + "')";
            Connection.actionQuery(query);
        }

        public void updateQuery(string text)
        {
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

        public void updateActiveQuery(string text)
        {
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
