using QLBanHang.Model;
using QLBanHang.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Control
{
    class HoaDonCtr
    {
        HoaDonMod hdMod = new HoaDonMod();
        public DataTable GetData()
        {
            return hdMod.GetData();
        }
        public bool AddData(HoaDonObj hdObj)
        {
            return hdMod.AddData(hdObj);
        }
        public bool DelData(string ma)
        {
            return hdMod.DelData(ma);
        }
        //public DataTable GetHDKH()
        //{
        //    return hdMod.GetHDKH();
        //}
    }
}
