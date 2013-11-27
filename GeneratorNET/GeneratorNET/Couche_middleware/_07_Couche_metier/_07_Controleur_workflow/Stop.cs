using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couche_middleware._07_Couche_metier._08_Composant_metier;

namespace Couche_middleware._07_Couche_metier._07_Controleur_workflow
{
	public class Stop
	{
		public void Execute()
		{
			GlobalVariables.clientStop = true;
		}
	}
}
