using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couche_middleware._07_Couche_metier._08_Composant_metier;
using GeneratorNET.Couche_middleware._07_Couche_metier._07_Controleur_workflow;

namespace Couche_middleware._06_Composant_acces_metier
{
	class CAM
	{
		public STG connection(STG oSTG)
		{
            ConnectionUser oConnectionUser = new ConnectionUser();
            UpdateTokenUser oUpdateTokenUser = new UpdateTokenUser();
            CheckTokenUser oCheckTokenUser = new CheckTokenUser();
			if (!string.IsNullOrEmpty(oSTG.Operationname))
			{
				string operationName = (string)oSTG.Operationname;
				if (operationName == "ConnectionUser") // Vérifie si le nom de la méthode à appeller est ConnectionUser
				{

					oSTG = oConnectionUser.Execute(oSTG);

                    if (oSTG.Status_op) //User est en base
                    {
                        oSTG = oUpdateTokenUser.Execute(oSTG);
                        if (oSTG.Status_op)
                        {
                            oSTG.Status_op = true;
                            oSTG.Info = "Connection Succeed";
                        }// Token updaté
                    }
                    else {
                        oSTG.Status_op = false;
                        oSTG.Info = "Echec connection User";
                    }
				}
				else// if () // Vérifie le token en base de données
				{
                    oSTG = oCheckTokenUser.Execute(oSTG);
                    if ((bool)oSTG.GetData("statut_op"))
                    {
                        if (operationName == "GpcsDecrypt")
                        {
                            //GpcsDecrypt oGpcsDecrypt = new GpcsDecrypt();
                        }
                        else
                        {
                            oSTG.Status_op = false;
                            oSTG.Info = "Le nom de l'opération n'est pas valide";
                        }	
                    }
                    else {
                        oSTG.Status_op = false;
                        oSTG.Info = "Le token n'est pas trouvé";
                    }
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
