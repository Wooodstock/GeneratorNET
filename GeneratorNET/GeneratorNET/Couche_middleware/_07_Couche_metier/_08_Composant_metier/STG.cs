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

		[DataMember]
		private string info;

		[DataMember]
		private string operationname;

		[DataMember]
		private string tokenApp;

		[DataMember]
		private string tokenUser;

		[DataMember]
		private Object[] data;
	}
}
