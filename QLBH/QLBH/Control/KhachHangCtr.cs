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
    class KhachHangCtr
    {
        KhachHangMod nvMod = new KhachHangMod();
        public DataTable GetData()
        {
            return nvMod.GetData();
        }
        public bool AddData(KhachHangObj khObj)
        {
            return nvMod.AddData(khObj);
        }
        public bool UpdData(KhachHangObj khObj)
        {
            return nvMod.UpdData(khObj);
        }

        public bool UpdDiem(KhachHangObj khObj)
        {
            return nvMod.UpdDiem(khObj);
        }

        public bool DelData(string ma)
        {
            return nvMod.DelData(ma);
        }
    }
}
