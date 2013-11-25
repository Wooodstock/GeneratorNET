using Couche_middleware._07_Couche_metier._08_Composant_metier;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Couche_middleware._10_Composant_acces_donnees
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
        private SqlConnection sqlConn;

        public void openConnection() {
            this.sqlConn = new SqlConnection(
            "Persist Security Info=False;"+
            "User ID=tony;"+
            "Password=tony;"+
            "Initial Catalog=wcf;"+
            "Server=172.16.255.194");
            try
            {
                this.sqlConn.Open();
                //Console.WriteLine("Connection Succeed");
            }
            catch (Exception/* ex*/) {
                //Console.WriteLine("Connection failed : " + ex.Message);
            }
        }

        public STG executeRQuery(STG oSTG) {
            //string query = "SELECT * FROM t_user;";
            SqlCommand sqlCommand = new SqlCommand((string)oSTG.GetData("query"), this.sqlConn);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                //Console.WriteLine((string)sqlDataReader["use_login"]);
				oSTG.SetData("resultset", sqlDataReader);
            }
            
            return oSTG;
        }

        public STG executeCUDQuery(STG oSTG) {
            return oSTG;
        }



    }
}
