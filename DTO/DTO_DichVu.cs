using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_DichVu
    {
        private string MaDV, Ten, DonVi, TrangThai;
        private BigInteger Gia;
        private DateTime NgayLap;

        public string _MaDV
        {
            get
            {
                return MaDV;
            }
            set
            {
                MaDV = value;
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

        public string _DonVi
        {
            get
            {
                return DonVi;
            }
            set
            {
                DonVi = value;
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

        public BigInteger _Gia
        {
            get
            {
                return Gia;
            }
            set
            {
                Gia = value;
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

        public DTO_DichVu(string MaDV,string Ten,BigInteger Gia,string DonVi, DateTime NgayLap, string TrangThai)
        {
            this.MaDV = MaDV;
            this.Ten = Ten;
            this.Gia = Gia;
            this.DonVi = DonVi;
            this.NgayLap = NgayLap;
            this.TrangThai = TrangThai;
        }
    }
}
