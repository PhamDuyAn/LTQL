using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Object
{
    class HangHoaObj
    {
        string ma, ten, mancc;
        int dongia, soluong;

        public int SoLuong
        {
            get { return soluong; }
            set { soluong = value; }
        }

        public int DonGia
        {
            get { return dongia; }
            set { dongia = value; }
        }

        public string TenHangHoa
        {
            get { return ten; }
            set { ten = value; }
        }

        public string MaHangHoa
        {
            get { return ma; }
            set { ma = value; }
        }
        public string MaNCC
        {
            get
            {
                return mancc;
            }

            set
            {
                mancc = value;
            }
        }

        public HangHoaObj() { }
        public HangHoaObj(string ma, string ten, string mancc, int dongia, int soluong)
        {
            this.ma = ma;
            this.ten = ten;
            this.dongia = dongia;
            this.soluong = soluong;
            this.mancc = mancc;
        }
    }
}
