using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using GeneratorNET.Couche_middleware._07_Couche_metier._07_Controleur_workflow;

namespace Couche_middleware._06_Composant_acces_metier
{
	class CAM
	{
		public STG connection(STG oSTG)
		{
			if (!string.IsNullOrEmpty(oSTG.Operationname))
			{
				string operationName = (string)oSTG.Operationname;
				if (operationName == "ConnectionUser")
				{
					ConnectionUser oConnectionUser = new ConnectionUser();
					oSTG = oConnectionUser.Execute(oSTG);
				}
				else if (operationName == "GpcsDecrypt")
				{
					//GpcsDecrypt oGpcsDecrypt = new GpcsDecrypt();
				}
				else
				{
					oSTG.Status_op = false;
					oSTG.Info = "Le nom de l'opération n'est pas valide";
				}				
			}
			else
			{
				oSTG.Status_op = false;
				oSTG.Info = "Le nom de l'opération n'est pas spécifié";
			}
			return oSTG;
		}
	}
}
