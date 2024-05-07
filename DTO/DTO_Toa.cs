using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Toa
    {
        private string MaToa, MaBN, TienSu, ChanDoan, TrieuChung, LoiDan,TrangThai;
        private int SoLuongThuoc;
        private DateTime NgayLap, NgayTaiKham;
        private BigInteger TongTien;

        public string _MaToa
        {
            get
            {
                return MaToa;
            }
            set
            {
                MaToa = value;
            }
        }

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

        public string _TienSu
        {
            get
            {
                return TienSu;
            }
            set
            {
                TienSu = value;
            }
        }

        public string _ChanDoan
        {
            get
            {
                return ChanDoan;
            }
            set
            {
                ChanDoan = value;
            }
        }

        public string _TrieuChung
        {
            get
            {
                return TrieuChung;
            }
            set
            {
                TrieuChung = value;
            }
        }

        public string _LoiDan
        {
            get
            {
                return LoiDan;
            }
            set
            {
                LoiDan = value;
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

        public int _SoLuongThuoc
        {
            get
            {
                return SoLuongThuoc;
            }
            set
            {
                SoLuongThuoc = value;
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

        public DateTime _NgayTaiKham
        {
            get
            {
                return NgayTaiKham;
            }
            set
            {
                NgayTaiKham = value;
            }
        }

        public BigInteger _TongTien
        {
            get
            {
                return TongTien;
            }
            set
            {
                TongTien = value;
            }
        }

        public DTO_Toa(string MaToa, string MaBN, string TienSu, string ChanDoan, string TrieuChung, string LoiDan, string  TrangThai,int SoLuongThuoc, DateTime NgayLap, DateTime NgayTaiKham,BigInteger TongTien)
        {
            this.MaToa = MaToa;
            this.MaBN = MaBN;
            this.TienSu = TienSu;
            this.ChanDoan = ChanDoan;
            this.TrieuChung = TrieuChung;
            this.LoiDan = LoiDan;
            this.TrangThai = TrangThai;
            this.SoLuongThuoc = SoLuongThuoc;
            this.NgayLap = NgayLap;
            this.NgayTaiKham = NgayTaiKham;
            this.TongTien = TongTien;
        }
    }
}
