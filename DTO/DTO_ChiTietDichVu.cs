using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChiTietDichVu
    {
        private string MaToa, MaDV;
        private int SoLuong;

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

        public int _SoLuong
        {
            get
            {
                return SoLuong;
            }
            set
            {
                SoLuong = value;
            }
        }

        public DTO_ChiTietDichVu(string MaToa, string MaDV, int SoLuong)
        {
            this.MaToa = MaToa;
            this.MaDV = MaDV;
            this.SoLuong = SoLuong;
        }
    }
}
