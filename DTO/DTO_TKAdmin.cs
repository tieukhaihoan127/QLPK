using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_TKAdmin
    {
        private string TaiKhoanAdmin, MatKhauAdmin;

        public string _TaiKhoanAdmin
        {
            get
            {
                return TaiKhoanAdmin;
            }
            set
            {
                TaiKhoanAdmin = value;
            }
        }

        public string _MatKhauAdmin
        {
            get
            {
                return MatKhauAdmin;
            }
            set
            {
                MatKhauAdmin = value;
            }            
        }

        public DTO_TKAdmin(string TaiKhoanAdmin,string MatKhauAdmin)
        {
            this.TaiKhoanAdmin = TaiKhoanAdmin;
            this.MatKhauAdmin = MatKhauAdmin;              
        }
    }
}
