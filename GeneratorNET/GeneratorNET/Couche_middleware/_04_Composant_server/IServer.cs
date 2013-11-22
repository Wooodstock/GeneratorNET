using System;
using System.ServiceModel;
using Couche_middleware._07_Couche_metier._08_Composant_metier;

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
