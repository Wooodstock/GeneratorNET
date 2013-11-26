using Couche_middleware._07_Couche_metier._08_Composant_metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couche_middleware._07_Couche_metier._09_Entite_mappage;
using Couche_middleware._10_Composant_acces_donnees;
using System.Data.SqlClient;

namespace GeneratorNET.Couche_middleware._07_Couche_metier._07_Controleur_workflow
{
    class CheckTokenUser
    {
        private CAD cad = new CAD();

        public STG Execute(STG oSTG)
		{

        if (!string.IsNullOrEmpty((string)oSTG.GetData("login")))
			{
                if (!string.IsNullOrEmpty((string)oSTG.GetData("tokenUser")))
                {
                    string login = (string)oSTG.GetData("login");
                    string token = (string)oSTG.GetData("token");
                    User oUser = new User(login, token);
                    oSTG = oUser.checkToken(oSTG);

                    cad.openConnection();
                    oSTG = cad.executeRQuery(oSTG);

                    SqlDataReader sqlDataReader = (SqlDataReader)oSTG.GetData("sqldatareader");
                    if (sqlDataReader.HasRows) //verification du token en base
                    {
                        oSTG.Status_op = true;
                        oSTG.Info = "Token Trouvé";
                        Console.WriteLine("Le token de l'utilisateur est bon " + login);
                    }
                    else
                    {
                        oSTG.Status_op = false;
                        oSTG.Info = "Le token utilisateur n'existe pas en base";
                    }
                    cad.closeConnection();
                }
                else
                {
                    oSTG.Status_op = false;
                    oSTG.Info = "Le token User n'est pas fourni";
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
