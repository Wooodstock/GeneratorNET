using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couche_middleware._07_Couche_metier._08_Composant_metier;

namespace Couche_middleware._04_Composant_server
{
	class Server : _04_Composant_server.IServer
	{
		/*
		[System.Security.Permissions.PrincipalPermission
			(System.Security.Permissions.SecurityAction.Assert, Unrestricted = true)
		]*/

		public STG connection(STG oSTG)
		{

			return oSTG;
		}
	}
}
