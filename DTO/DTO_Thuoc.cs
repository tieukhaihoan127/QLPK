using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Thuoc
    {
        private string MaThuoc, TenThuoc, DonViTinh, DanhMuc, NSX, CachDung ,TrangThai;
        private BigInteger GiaNhap, GiaBan;
        private DateTime NgayNhapHang;

        public string _MaThuoc
        {
            get
            {
                return MaThuoc;
            }
            set
            {
                MaThuoc = value;
            }
        }

        public string _TenThuoc
        {
            get
            {
                return TenThuoc;
            }
            set
            {
                TenThuoc = value;
            }
        }

        public string _DonViTinh
        {
            get
            {
                return DonViTinh;
            }
            set
            {
                DonViTinh = value;
            }
        }

        public string _DanhMuc
        {
            get
            {
                return DanhMuc;
            }
            set
            {
                DanhMuc = value;
            }
        }

        public string _NSX
        {
            get
            {
                return NSX;
            }
            set
            {
                NSX = value;
            }
        }

        public string _CachDung
        {
            get
            {
                return CachDung;
            }
            set
            {
                CachDung = value;
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

        public BigInteger _GiaNhap
        {
            get
            {
                return GiaNhap;
            }
            set
            {
                GiaNhap = value;
            }
        }

        public BigInteger _GiaBan
        {
            get
            {
                return GiaBan;
            }
            set
            {
                GiaBan = value;
            }
        }

        public DateTime _NgayNhapHang
        {
            get
            {
                return NgayNhapHang;
            }
            set
            {
                NgayNhapHang = value;
            }
        }

        public DTO_Thuoc(string MaThuoc, string TenThuoc, string DonViTinh, BigInteger GiaNhap, BigInteger GiaBan, string DanhMuc, string NSX, DateTime NgayNhapHang, string CachDung,string TrangThai)
        {
            this.MaThuoc = MaThuoc;
            this.TenThuoc = TenThuoc;
            this.DonViTinh = DonViTinh;
            this.GiaNhap = GiaNhap;
            this.GiaBan = GiaBan;
            this.DanhMuc = DanhMuc;
            this.NSX = NSX;
            this.NgayNhapHang = NgayNhapHang;
            this.CachDung = CachDung;
            this.TrangThai = TrangThai;
        }
    } 
}
