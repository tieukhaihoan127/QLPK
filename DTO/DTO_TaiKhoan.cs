using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_TaiKhoan
    {

        private string TenTK, MatKhau, TrangThai, MaNV;
        private DateTime NgayLap;

        public string _TenTK
        {
            get
            {
                return TenTK;
            }
            set
            {
                TenTK = value;
            }
        }

        public string _MatKhau
        {
            get
            {
                return MatKhau;
            }
            set
            {
                MatKhau = value;
            }
        }

        public string _TrangThai
        {
            get
            {
                return TrangThai;
            }
            set
            {
                TrangThai = value;
            }
        }

        public string _MaNV
        {
            get
            {
                return MaNV;
            }
            set
            {
                MaNV = value;
            }
        }

        public DateTime _NgayLap
        {
            get
            {
                return NgayLap;
            }
            set
            {
                NgayLap = value;
            }
        }

        public DTO_TaiKhoan(string TenTK,string MatKhau,string TrangThai, string MaNV,DateTime NgayLap)
        {
            this.TenTK = TenTK;
            this.MatKhau = MatKhau;
            this.TrangThai = TrangThai;
            this.MaNV = MaNV;
            this.NgayLap = NgayLap;
        }
    }
}
