using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Collections;
using System.Net.Security;

namespace Common
{
	[ServiceContract]
	public class STG
	{		
		private bool status_op;

		[DataMember]
		public bool Status_op
		{
			get { return status_op; }
			set { status_op = value; }
		}

		private string info;

		[DataMember]
		public string Info
		{
			get { return info; }
			set { info = value; }
		}

		private string operationname;

		[DataMember]
		public string Operationname
		{
			get { return operationname; }
			set { operationname = value; }
		}

		private string tokenApp;

		[DataMember]
		public string TokenApp
		{
			get { return tokenApp; }
			set { tokenApp = value; }
		}

		private string tokenUser;

		[DataMember]
		public string TokenUser
		{
			get { return tokenUser; }
			set { tokenUser = value; }
		}

		[DataMember]
		public Hashtable data;

		[OperationContract]
		public object GetData(string key)
		{
			return this.data[key];
		}

		[OperationContract]
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

		public STG()
		{
			this.status_op = false;
			this.info = "";
			this.operationname = "";
			this.tokenApp = "";
			this.tokenUser = "";
			this.data = new Hashtable();
		}

	}
}
