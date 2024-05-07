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

        public void addQuery()
        {
            bn.addQuery();
        }

        public DataTable selectQuery()
        {
            return bn.selectQuery();
        }

        public DataTable selectDeleteQuery()
        {
            return bn.selectDeleteQuery();
        }

        public void updateQuery(DataGridView dataGridView1)
        {
            bn.updateQuery(dataGridView1);
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
            bn.updateActiveQuery(dataGridView1);
        }
    }
}
