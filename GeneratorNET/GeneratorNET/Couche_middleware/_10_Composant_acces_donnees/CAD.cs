using Couche_middleware._07_Couche_metier._08_Composant_metier;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Couche_middleware.Couche_middleware._10_Composant_acces_donnees
{
    class CAD
    {
        public CAD() { }

        public CAD(string chainConn, string driver, string database, string host, string password) {
            this.chaineConn = chaineConn;
            this.driver = driver;
            this.database = database;
            this.host = host;
            this.password = password;
        }


        private string chaineConn {get;set;}
        private string driver { get; set; }
        private string database { get; set; }
        private string host { get; set; }
        private string password { get; set; }

        public void openConnection() {
            SqlConnection myConnection = new SqlConnection("Database=wcf;Server=172.16.255.194\\SQLEXPRESS;Integrated Security=True;connect timeout = 30");
            try
            {
                myConnection.Open();
            }
            catch (Exception ex) {
                Console.WriteLine("Connection failed : " + ex.Message);
            }
        }

        public STG executeRQuery(STG oSTG) {
            return oSTG;
        }

        public STG executeCUDQuery(STG oSTG) {
            return oSTG;
        }



    }
}
