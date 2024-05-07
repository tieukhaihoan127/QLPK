using System;
using System.Collections.Generic;
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

        public void addQuery()
        {
            bs.addQuery();
        }

        public void updateQuery(DataGridView dataGridView1)
        {
            bs.updateQuery(dataGridView1);
        }

        public void updateCurrentQuery()
        {
            bs.updateCurrentQuery();
        }

        public void updateActiveQuery(DataGridView dataGridView1)
        {
            bs.updateActiveQuery(dataGridView1);
        }
    }
}
