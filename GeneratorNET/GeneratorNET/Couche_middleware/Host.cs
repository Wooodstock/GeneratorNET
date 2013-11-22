using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Couche_middleware
{
	class Host
	{
		static void Main(string[] args)
		{
			ServiceHost svhost = new ServiceHost(typeof(_04_Composant_server.Server));
			svhost.Open();
			Console.WriteLine("server ready");
			Console.Read();
			svhost.Close();
		}
	}
}
