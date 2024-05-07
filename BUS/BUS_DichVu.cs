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

        public void addQuery()
        {
            dv.addQuery();
        }

        public DataTable selectQuery()
        {
            return dv.selectQuery();
        }

        public DataTable selectDeleteQuery()
        {
            return dv.selectDeleteQuery();
        }

        public void updateQuery(DataGridView dataGridView1)
        {
            dv.updateQuery(dataGridView1);
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

        public void updateCurrentQuery()
        {
            dv.updateCurrentQuery();
        }

        public void updateActiveQuery(DataGridView dataGridView1)
        {
            dv.updateActiveQuery(dataGridView1);
        }
    }
}
