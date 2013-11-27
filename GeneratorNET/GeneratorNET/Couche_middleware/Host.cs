using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Couche_middleware._10_Composant_acces_donnees;
using GeneratorNET.ReceptionSTG;
using System.Collections;


namespace Couche_middleware
{
	class Host
	{
		static void Main(string[] args)
		{
			ServiceHost svhost = new ServiceHost(typeof(_04_Composant_server.Server));
			svhost.Open();
			Console.WriteLine("server ready");

            /*CAD cad = new CAD();
            cad.openConnection();
            cad.executeRQuery(new STG());
			Console.Read();

            /*  TEST To Remove
            Hashtable map = new Hashtable();
            map.Add("M_database", "//localhost:3306/dicobdd");
            map.Add("M_driver", "com.mysql.jdbc.Driver");
            map.Add("M_user", "root");
            map.Add("M_password", "admin");
            map.Add("txt_decrypted", "La aborder est abaisse. L'avion is not aboutir beautiful.");

            try
            {
                ReceptionSTGClient client = new ReceptionSTGClient();
                client.sendToQueue("La aborder est abaisse. L'avion is not aboutir beautiful", "file1", "010111");
            }
            catch (Exception ex) {
                
                Console.WriteLine("Exception Webservice Java : " + ex.StackTrace);
                Console.Read();
            }*/
            Console.ReadKey();
			//svhost.Close();
		}
	}
}
