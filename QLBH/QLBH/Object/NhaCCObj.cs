using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Object
{
    class NhaCCObj
    {
        string ma, ten, diachi, sdt;

        public string DiaChi
        {
            get
            {
                return diachi;
            }

            set
            {
                diachi = value;
            }
        }

        public string MaNCC
        {
            get
            {
                return ma;
            }

            set
            {
                ma = value;
            }
        }

        public string SDT
        {
            get
            {
                return sdt;
            }

            set
            {
                sdt = value;
            }
        }

        public string TenNCC
        {
            get
            {
                return ten;
            }

            set
            {
                ten = value;
            }
        }
        public NhaCCObj() { }
        public NhaCCObj(string ma, string ten, string diachi, string sdt)
        {
            this.ten = ten;
            this.ma = ma;
            this.diachi = diachi;
            this.sdt = sdt;
        }
    }
}
