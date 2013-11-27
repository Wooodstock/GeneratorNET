using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couche_middleware._07_Couche_metier._08_Composant_metier;
using Couche_middleware._07_Couche_metier._09_Entite_mappage;
using Couche_middleware._10_Composant_acces_donnees;
using System.Data.SqlClient;

namespace Couche_middleware._07_Couche_metier._07_Controleur_workflow
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
					User oUser = new User(login, password);
					oSTG = oUser.checkUser(oSTG);
					CAD oCAD = new CAD();
					oCAD.openConnection();
					oSTG = oCAD.executeRQuery(oSTG);
					SqlDataReader resultset = (SqlDataReader)oSTG.GetData("sqldatareader");			
					if (resultset.HasRows) // Vérification de l'utilisateur en base de données
					{
						oSTG.Status_op = true;
						oSTG.Info = "Connexion réussie";
						//Console.WriteLine("Connexion réussie de l'utilisateur " + login);
						int unixTimestamp = (int)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
						string log = login;
						if (login.Length > 10)
						{
							log = login.Substring(0, 10);
							log += unixTimestamp;
						}
						else
						{
							log += unixTimestamp;
							log += unixTimestamp.ToString().Substring(0, (10-login.Length));
						}
						oSTG.TokenUser = log;
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
