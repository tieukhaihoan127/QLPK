using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DTO
{
    public class DTO_NhanVien
    {
        private string MaNV, Ten, SDT, GioiTinh, Email, DiaChiLienHe, CMND, VaiTro;
        private DateTime NgaySinh;
        private BigInteger luong;

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

        public string _Ten
        {
            get
            {
                return Ten;
            }
            set
            {
                Ten = value;
            }
        }

        public string _SDT
        {
            get
            {
                return SDT;
            }
            set
            {
                SDT = value;
            }
        }

        public string _GioiTinh
        {
            get
            {
                return GioiTinh;
            }
            set
            {
                GioiTinh = value;
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

        public string _DiaChiLienHe
        {
            get
            {
                return DiaChiLienHe;
            }
            set
            {
                DiaChiLienHe = value;
            }
        }

        public string _CMND
        {
            get
            {
                return CMND;
            }
            set
            {
                CMND = value;
            }
        }

        public string _VaiTro
        {
            get
            {
                return VaiTro;
            }
            set
            {
                VaiTro = value;
            }
        }

        public DateTime _NgaySinh
        {
            get
            {
                return NgaySinh;
            }
            set
            {
                NgaySinh = value;
            }
        }

        public BigInteger _Luong
        {
            get
            {
                return luong;
            }
            set
            {
                luong = value;
            }
        }

        public DTO_NhanVien(string MaNV,string Ten,string SDT,string GioiTinh,string Email,string DiaChiLienHe,string CMND,string VaiTro,DateTime NgaySinh,BigInteger luong)
        {
            this.MaNV = MaNV;
            this.Ten = Ten;
            this.SDT = SDT;
            this.GioiTinh = GioiTinh;
            this.Email = Email;
            this.NgaySinh = NgaySinh;
            this.DiaChiLienHe = DiaChiLienHe;
            this.CMND = CMND;
            this.VaiTro = VaiTro;
            this.luong = luong;
        }


    }
}
