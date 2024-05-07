using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_GiayChiDinh
    {
        private string MaGCD, MaBN, TienSu, ChanDoan, TrieuChung, LoiDan, TrangThai;
        private DateTime NgayLap, NgayTaiKham;
        private BigInteger TongTien;

        public string _MaGCD
        {
            get
            {
                return MaGCD;
            }
            set
            {
                MaGCD = value;
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

        public DTO_GiayChiDinh(string MaGCD, string MaBN, string TienSu, string ChanDoan, string TrieuChung, string LoiDan, string TrangThai, DateTime NgayLap, DateTime NgayTaiKham, BigInteger TongTien)
        {
            this.MaGCD = MaGCD;
            this.MaBN = MaBN;
            this.TienSu = TienSu;
            this.ChanDoan = ChanDoan;
            this.TrieuChung = TrieuChung;
            this.LoiDan = LoiDan;
            this.TrangThai = TrangThai;
            this.NgayLap = NgayLap;
            this.NgayTaiKham = NgayTaiKham;
            this.TongTien = TongTien;
        }
    }
}
