using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_QuanLyPhongKham
    {
        private string MaQL, TenQL, Email, TaiKhoanAdmin;

        public string _MaQL
        {
            get
            {
                return MaQL;
            }
            set
            {
                MaQL = value;
            }
        }

        public string _TenQL
        {
            get
            {
                return TenQL;
            }
            set
            {
                TenQL = value;
            }
        }

        public string _Email
        {
            get
            {
                return Email;
            }
            set
            {
                Email = value;
            }
        }

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

        public DTO_QuanLyPhongKham(string MaQL,string TenQL,string Email,string TaiKhoanAdmin)
        {
            this.MaQL = MaQL;
            this.TenQL = TenQL;
            this.Email = Email;
            this.TaiKhoanAdmin = TaiKhoanAdmin;
        }
    }
}
