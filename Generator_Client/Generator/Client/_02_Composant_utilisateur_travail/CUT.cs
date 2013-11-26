using Generator.Couche_middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    public class CUT
    {
        /*private CUC oCUC;

        public CUT(CUC oCUC)
        {
            this.oCUC = oCUC;
        }*/

        public CUT()
        {

        }

        public STG login(STG oSTG, string oLogin, string oPWD)
        {
            oSTG.Operationname = "login";
            oSTG.data.Add("login", oLogin);
            oSTG.data.Add("password", oPWD);

            return oSTG;
        }

        public STG dechiffrer(STG oSTG, Dictionary<string, string> oFiles_Dictionnary)
        {
            oSTG.Operationname = "dechiffrer";

            foreach (KeyValuePair<string, string> key in oFiles_Dictionnary)
            {
                oSTG.data.Add("file_name", key.Key);
                oSTG.data.Add("file_content", key.Value);
            }

            return oSTG;
        }
    }
}
