using Couche_middleware._07_Couche_metier._08_Composant_metier;
using Couche_middleware._07_Couche_metier._09_Entite_mappage;
using Couche_middleware._10_Composant_acces_donnees;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Couche_middleware._07_Couche_metier._07_Controleur_workflow
{
    class UpdateTokenUser
    {
        private CAD cad = new CAD();

        public STG Execute(STG oSTG)
        {

            if (!string.IsNullOrEmpty((string)oSTG.GetData("login")))
            {
                if (!string.IsNullOrEmpty(oSTG.TokenUser))
                {
                    string login = (string)oSTG.GetData("login");
                    string token = oSTG.TokenUser;
                    User oUser = new User(login, token);
                    oSTG = oUser.insertToken(oSTG);

                    cad.openConnection();
                    oSTG = cad.executeCUDQuery(oSTG);

                    SqlDataReader sqlDataReader = (SqlDataReader)oSTG.GetData("sqldatareader");
                    if (sqlDataReader.RecordsAffected != 0) //verification du token en base
                    {
                        oSTG.Status_op = true;
                        oSTG.Info = "Token Updaté";
                        //Console.WriteLine("Le token de l'utilisateur est bon " + login);
                    }
                    else
                    {
                        oSTG.Status_op = false;
                        oSTG.Info = "L'utilisation du token utilisateur n'a pas réussi";
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
