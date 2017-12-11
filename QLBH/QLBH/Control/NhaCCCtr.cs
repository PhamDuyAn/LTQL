using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBanHang.Object;
using QLBanHang.Model;
using System.Data;

namespace QLBanHang.Control
{
    class NhaCCCtr
    {
        NhaCCMod nccMod = new NhaCCMod();
        public bool UpdSL(DataTable dt)
        {
            DataTable dthh = new DataTable();
            dthh = nccMod.GetData();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dthh.Rows.Count; j++)
                {
                    if (dt.Rows[i][1].ToString() == dthh.Rows[j][0].ToString())
                    {
                        string NCCcu = dthh.Rows[j][4].ToString();
                        string NCCmoi = dthh.Rows[j][4].ToString();

                        break;
                    }
                }

            }
            return true;
        }
        public DataTable GetData()
        {
            return nccMod.GetData();
        }
        public bool AddData(NhaCCObj nccObj)
        {
            return nccMod.AddData(nccObj);
        }
        public bool UpdData(NhaCCObj nccObj)
        {
            return nccMod.UpdData(nccObj);
        }
        public bool DelData(string ma)
        {
            return nccMod.DelData(ma);
        }

        internal DataTable GetData(string v)
        {
            throw new NotImplementedException();
        }
    }
}
