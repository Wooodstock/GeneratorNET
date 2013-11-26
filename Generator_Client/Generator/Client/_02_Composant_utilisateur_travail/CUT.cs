using Generator.Couche_middleware;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    public class CUT
    {
        public CUT()
        {

        }

        public STG login(STG oSTG, string oLogin, string oPWD)
        {
            oSTG.Operationname = "GpcsUser_ConnectionUser";
            oSTG.data.Add("login", oLogin);
            oSTG.data.Add("password", oPWD);

            return oSTG;
        }

        public STG dechiffrer(STG oSTG, Hashtable oFiles_Hashtable)
        {
            oSTG.Operationname = "GpcsDecrypt_Dechiffrer";
            oSTG.data.Remove("Files_Hashtable");
            oSTG.data.Add("Files_Hashtable", oFiles_Hashtable);

            return oSTG;
        }
    }
}
