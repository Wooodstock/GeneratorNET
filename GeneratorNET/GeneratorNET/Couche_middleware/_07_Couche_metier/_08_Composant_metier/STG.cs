using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Collections;
using System.Net.Security;

namespace Couche_middleware._07_Couche_metier._08_Composant_metier
{
	public class STG
	{		
		private bool status_op;

		public bool Status_op
		{
			get { return status_op; }
			set { status_op = value; }
		}

		private string info;

		public string Info
		{
			get { return info; }
			set { info = value; }
		}

		private string operationname;

		public string Operationname
		{
			get { return operationname; }
			set { operationname = value; }
		}

		private string tokenApp;

		public string TokenApp
		{
			get { return tokenApp; }
			set { tokenApp = value; }
		}

		private string tokenUser;

		public string TokenUser
		{
			get { return tokenUser; }
			set { tokenUser = value; }
		}

		public Hashtable data;

		public object GetData(string key)
		{
			return this.data[key];
		}

		public void SetData(string key, object value)
		{
			if (this.data.ContainsKey(key))
			{
				this.data.Remove(key);
				this.data.Add(key, value);
			}
			else
			{
				this.data.Add(key, value);
			}
		}

		public Hashtable files;

		public object GetFiles(string key)
		{
			return this.files[key];
		}

		public void SetFiles(string key, object value)
		{
			if (this.files.ContainsKey(key))
			{
				this.files.Remove(key);
				this.files.Add(key, value);
			}
			else
			{
				this.files.Add(key, value);
			}
		}

		public STG()
		{
			this.status_op = false;
			this.info = "";
			this.operationname = "";
			this.tokenApp = "";
			this.tokenUser = "";
			this.data = new Hashtable();
			this.files = new Hashtable();
		}

	}
}
