using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_TKAdmin
    {

        DAL_TKAdmin ad;

        public BUS_TKAdmin(string TaiKhoanAdmin,string MatKhauAdmin)
        {
            ad = new DAL_TKAdmin(TaiKhoanAdmin, MatKhauAdmin);
        }

        public Boolean checkQuery()
        {
            return ad.checkQuery();
        }
    }
}
