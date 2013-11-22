using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Couche_middleware._04_Composant_server
{
	class Server : _04_Composant_server.IServer
	{
		/*
		[System.Security.Permissions.PrincipalPermission
			(System.Security.Permissions.SecurityAction.Assert, Unrestricted = true)
		]*/

		public string test(string msg)
		{
			Console.WriteLine("test msg = " + msg);
			return "ok";
		}
	}
}
