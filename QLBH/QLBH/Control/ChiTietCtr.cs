using QLBanHang.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Control
{
    class ChiTietCtr
    {
        ChiTietMod ctMod = new ChiTietMod();
        public DataTable GetData(string ma)
        {
            return ctMod.GetData(ma);
        }
        public bool AddData(DataTable dt)
        {
            return ctMod.AddData(dt);
        }
        public bool DelData(string ma)
        {
            return ctMod.DelData(ma);
        }
    }
}
