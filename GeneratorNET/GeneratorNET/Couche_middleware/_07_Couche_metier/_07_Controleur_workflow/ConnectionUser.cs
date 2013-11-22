using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couche_middleware._07_Couche_metier._08_Composant_metier;

namespace GeneratorNET.Couche_middleware._07_Couche_metier._07_Controleur_workflow
{
	class ConnectionUser
	{
		public STG Execute(STG oSTG)
		{
			if (!string.IsNullOrEmpty((string)oSTG.GetData("login")))
			{
				if (!string.IsNullOrEmpty((string)oSTG.GetData("password")))
				{
					string login = (string)oSTG.GetData("login");
					string password = (string)oSTG.GetData("password");
					if (login == "toto" && password == "toto")
					{
						oSTG.Status_op = true;
						oSTG.Info = "Connection réussie";
					}
					else
					{
						oSTG.Status_op = false;
						oSTG.Info = "Le login et le mot de passe ne correspondent pas";
					}
				}
				else
				{
					oSTG.Status_op = false;
					oSTG.Info = "Le mot de passe n'est pas fourni";
				}
			}
			else
			{
				oSTG.Status_op = false;
				oSTG.Info = "Le login n'est pas fourni";
			}
			return oSTG;
		}
	}
}
