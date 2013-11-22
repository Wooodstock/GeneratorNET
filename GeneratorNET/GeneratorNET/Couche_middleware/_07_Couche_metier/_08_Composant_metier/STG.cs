using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Couche_middleware._07_Couche_metier._08_Composant_metier
{
	[DataContract]
	class STG
	{
		[DataMember]
		private bool status_op;

		public bool Status_op
		{
			get { return status_op; }
			set { status_op = value; }
		}

		[DataMember]
		private string info;

		public string Info
		{
			get { return info; }
			set { info = value; }
		}

		[DataMember]
		private string operationname;

		public string Operationname
		{
			get { return operationname; }
			set { operationname = value; }
		}

		[DataMember]
		private string tokenApp;

		public string TokenApp
		{
			get { return tokenApp; }
			set { tokenApp = value; }
		}

		[DataMember]
		private string tokenUser;

		public string TokenUser
		{
			get { return tokenUser; }
			set { tokenUser = value; }
		}

		[DataMember]
		private Object[] data;

		public Object[] Data
		{
			get { return data; }
			set { data = value; }
		}

	}
}
