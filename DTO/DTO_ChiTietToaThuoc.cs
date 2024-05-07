using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChiTietToaThuoc
    {
        private string MaToa, MaThuoc;
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

        public DTO_ChiTietToaThuoc(string MaToa,string MaThuoc,int SoLuong)
        {
            this.MaToa = MaToa;
            this.MaThuoc = MaThuoc;
            this.SoLuong = SoLuong;
        }
    }
}
