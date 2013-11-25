using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    public class CUT
    {
        private CUC oCUC;

        public CUT(CUC oCUC)
        {
            this.oCUC = oCUC;
        }

        public Common.STG login(Common.STG oSTG, string oLogin, string oPWD)
        {
            oSTG.Operationname = "login";

            return oSTG;
        }

        public Common.STG dechiffrer(Common.STG oSTG)
        {
            oSTG.Operationname = "dechiffrer";

            return oSTG;
        }
    }
}
