using System;
using System.ServiceModel;
using Common;

namespace Couche_middleware._04_Composant_server
{
	[
		System.ServiceModel.ServiceContract
		(
			Name="IcomposantService",
			Namespace="generator"
		)
	]
	interface IServer
	{
		[
			System.ServiceModel.OperationContract
		]
		STG connection(STG oSTG);
	}
}
