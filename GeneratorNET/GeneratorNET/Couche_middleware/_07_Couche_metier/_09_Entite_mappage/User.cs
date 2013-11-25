using Couche_middleware._07_Couche_metier._08_Composant_metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Couche_middleware._07_Couche_metier._09_Entite_mappage
{
    class User
    {
		//private 
        private string login { get; set; }
        private string pwd { get; set; }

        public User() { 
        }

        public User(string login, string pwd)
        {
            this.login = login;
            this.pwd = pwd;
        }

		public STG checkUser(STG oSTG)
		{
			oSTG.SetData("query", "select * from dbo.t_user where use_login = '" + oSTG.GetData("login") + " 'and use_pwd = '"+ oSTG.GetData("password") + "'");
			return oSTG;
		}
    }
}
