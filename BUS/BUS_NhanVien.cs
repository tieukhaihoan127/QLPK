using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using DAL;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Globalization;
using System.Xml.Linq;

namespace BUS
{
    public class BUS_NhanVien
    {
        DAL_NhanVien nv;

        public BUS_NhanVien(string MaNV, string Ten, string SDT, string GioiTinh, string Email, string DiaChiLienHe, string CMND, string VaiTro, DateTime NgaySinh, BigInteger luong)
        {
            nv = new DAL_NhanVien(MaNV, Ten, SDT, GioiTinh, Email, DiaChiLienHe, CMND, VaiTro, NgaySinh, luong);
        }

        public DataTable selectQuery()
        {
            return nv.selectQuery();
        }

        public DataTable selectDeleteQuery()
        {
            return nv.selectDeleteQuery();
        }

        public DataTable selectedChangeQuery(int option)
        {
            return nv.selectedChangeQuery(option);
        }

        public DataTable selectNVByID(string id)
        {
            return nv.selectNVByID(id);
        }

        public DataTable selectDataByID(string id)
        {
            return nv.selectDataByID(id);
        }

        public DataTable selectStatusNV(string id)
        {
            return nv.selectStatusNV(id);
        }

        public DataTable searchDoctor(string value)
        {
            return nv.searchDoctor(value);
        }

        public DataTable selectTimeFilter(DateTime first, DateTime second)
        {
            return nv.selectTimeFilter(first, second);
        }

        public DataTable selectPhone(string phone)
        {
            return nv.selectPhone(phone);
        }

        public DataTable selectCMND(string CMND)
        {
            return nv.selectCMND(CMND);
        }

        public DataTable getDoctorDesc()
        {
            return nv.getDoctorDesc();
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
                id = "BS0001";
            }
            return id;
        }

        public string RemoveDiacritics(string text)
        {
            string normalizedString = text.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public string getName(string name)
        {
            string lower = RemoveDiacritics(name.ToLower());
            string[] nameParts = lower.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return nameParts[nameParts.Length - 1];
        }

        public string getPass(string pass)
        {
            string lower = RemoveDiacritics(pass.ToLower());
            string[] nameParts = lower.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string mk = string.Join("", nameParts);
            return mk;
        }

        public void addQuery()
        {
            string id = getId();
            nv.addQuery(id);
        }

        public void updateQuery()
        {
            nv.updateQuery();
        }

        public string getMaNV()
        {
            return nv.getMaNV();
        }
    }
}
