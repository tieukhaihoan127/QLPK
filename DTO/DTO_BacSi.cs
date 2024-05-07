using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_BacSi
    {
        private string MaNV, ChuyenNganh, HocVan, KinhNghiem, NgonNgu, TrangThai;

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

        public string _ChuyenNganh
        {
            get
            {
                return ChuyenNganh;
            }
            set
            {
                ChuyenNganh = value;
            }
        }

        public string _HocVan
        {
            get
            {
                return HocVan;
            }
            set
            {
                HocVan = value;
            }
        }

        public string _KinhNghiem
        {
            get
            {
                return KinhNghiem;
            }
            set
            {
                KinhNghiem = value;
            }
        }

        public string _NgonNgu
        { 
            get
            {
                return NgonNgu;
            }
            set
            {
                NgonNgu = value;
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

        public DTO_BacSi(string MaNV,string ChuyenNganh,string HocVan,string KinhNghiem,string NgonNgu,string TrangThai)
        {
            this.MaNV = MaNV;
            this.ChuyenNganh= ChuyenNganh;
            this.HocVan= HocVan;    
            this.KinhNghiem= KinhNghiem;
            this.NgonNgu= NgonNgu;
            this.TrangThai= TrangThai;
        }
    }
}
