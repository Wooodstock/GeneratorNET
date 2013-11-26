﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couche_middleware._07_Couche_metier._08_Composant_metier;
using Couche_middleware._05_Groupe_processus;

namespace Couche_middleware._04_Composant_server
{
	class Server : _04_Composant_server.IServer
	{
		
		[
			System.Security.Permissions.PrincipalPermission
			(System.Security.Permissions.SecurityAction.Assert, Unrestricted = true)
		]

		public STG connection(STG oSTG)
		{
			oSTG.Info = "arrivée sur le serveur";
			oSTG.SetData("test", "this is a test");
			if (oSTG.TokenApp == "Generator")
			{
				if (!string.IsNullOrEmpty(oSTG.Operationname))
				{
					string[] operationSplit = oSTG.Operationname.Split(new char[] { '_' });
					if (operationSplit.Length >= 2)
					{
						string nomClasse = operationSplit[0];
						string nomMethode = operationSplit[1];
						if (nomClasse == "GpcsUser")
						{
							GpcsUser oGpcsUser = new GpcsUser();
							oSTG.Operationname = nomMethode;
							oSTG = oGpcsUser.ConnectionUser(oSTG);
						}
						else if (nomClasse == "GpcsDecrypt")
						{
							GpcsDecrypt oGpcsDecrypt = new GpcsDecrypt();
							
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
						oSTG.Info = "Le nom de l'opération n'est pas valide";
					}
				}
				else
				{
					oSTG.Status_op = false;
					oSTG.Info = "Le nom de l'opération n'est pas spécifié";
				}
				
			}
			else
			{
				oSTG.Status_op = false;
				oSTG.Info = "Le token de l'application n'est pas valide";
			}
			oSTG.SetData("sqldatareader", "");
			return oSTG;
		}

        public void callback(string reponse) {
            Console.WriteLine("J'ai trouvé une solution !");
        }
	}
}
