using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couche_middleware._07_Couche_metier._08_Composant_metier;
using Couche_middleware._07_Couche_metier._09_Entite_mappage;
using Couche_middleware._10_Composant_acces_donnees;
using System.Data.SqlClient;

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
					bool exist = false;
					User oUser = new User(login, password);
					oSTG = oUser.checkUser(oSTG);
					CAD oCAD = new CAD();
					oCAD.openConnection();
					oSTG = oCAD.executeRQuery(oSTG);
					SqlDataReader resultset = (SqlDataReader)oSTG.GetData("resultset");
					try
					{
						resultset.Read();
						exist = true;
					}
					catch (Exception)
					{

					}
					oSTG.SetData("resultset", "");
					if (exist) // Vérification de l'utilisateur en base de données
					{
						oSTG.Status_op = true;
						oSTG.Info = "Connexion réussie";
						Console.WriteLine("Connexion réussie de l'utilisateur " + login);
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
