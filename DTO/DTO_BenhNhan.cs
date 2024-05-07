using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_BenhNhan
    {
        private string MaBN, Ten, SDT, GioiTinh, DiaChi, CanNang, Sp02, NhietDo, Mach, HuyetAp, NhipTho, TrangThai;
        private DateTime NgaySinh, NgayLap;

        public string _MaBN
        {
            get
            {
                return MaBN;
            }
            set
            {
                MaBN = value;
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

        public string _DiaChi
        {
            get
            {
                return DiaChi;
            }
            set
            {
                DiaChi = value;
            }
        }

        public string _CanNang
        {
            get
            {
                return CanNang;
            }
            set
            {
                CanNang = value;
            }
        }

        public string _Sp02
        {
            get
            {
                return Sp02;
            }
            set
            {
                Sp02 = value;
            }
        }

        public string _NhietDo
        {
            get
            {
                return NhietDo;
            }
            set
            {
                NhietDo = value;
            }
        }

        public string _Mach
        {
            get
            {
                return Mach;
            }
            set
            {
                Mach = value;
            }
        }

        public string _HuyetAp
        {
            get
            {
                return HuyetAp;
            }
            set
            {
                HuyetAp = value;
            }
        }

        public string _NhipTho
        {
            get
            {
                return NhipTho;
            }
            set
            {
                NhipTho = value;
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

        public DateTime _NgaySinh
        {
            get
            {
                return NgaySinh;
            }set
            {
                NgaySinh = value;
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

        public DTO_BenhNhan(string MaBN,string Ten,string SDT,DateTime NgaySinh,string GioiTinh,string DiaChi,string CanNang,string Sp02, string NhietDo,string Mach,string HuyetAp,string NhipTho,string TrangThai,DateTime NgayLap)
        {
            this.MaBN = MaBN;
            this.Ten  = Ten;
            this.SDT = SDT;
            this.NgaySinh = NgaySinh;
            this.GioiTinh = GioiTinh;
            this.DiaChi = DiaChi;
            this.CanNang = CanNang;
            this.Sp02 = Sp02;
            this.NhietDo = NhietDo;
            this.Mach = Mach;
            this.HuyetAp = HuyetAp;
            this.NhipTho = NhipTho;
            this.TrangThai = TrangThai;
            this.NgayLap = NgayLap;
        }
    }
}
