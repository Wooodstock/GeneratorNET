using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couche_middleware._07_Couche_metier._08_Composant_metier;
using Couche_middleware._06_Composant_acces_metier;

namespace Couche_middleware._05_Groupe_processus
{
	class GpcsUser
	{
		private CAM oCAM;
		public GpcsUser()
		{
			this.oCAM = new CAM();
		}

		public STG ConnectionUser(STG oSTG)
		{
			oSTG = oCAM.connection(oSTG);
			return oSTG;
		}
	}
}
