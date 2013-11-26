using Couche_middleware._06_Composant_acces_metier;
using Couche_middleware._07_Couche_metier._08_Composant_metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Couche_middleware._05_Groupe_processus
{
	class GpcsDecrypt
	{
        private CAM oCAM;
		public GpcsDecrypt()
		{
            this.oCAM = new CAM();
		}

        public STG Decrypter(STG oSTG)
        {
            oSTG = oCAM.connection(oSTG);
            return oSTG;
        }
	}
}
