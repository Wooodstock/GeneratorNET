using Couche_middleware._07_Couche_metier._08_Composant_metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorNET.Couche_middleware._07_Couche_metier._07_Controleur_workflow
{
	class Decrypt
	{
		public STG Execute(STG oSTG)
		{
			for (int i = 1; i < 10000; i++)
			{

			} 
			return oSTG;
		}

		static string EncryptOrDecrypt(string text, string key)
		{
			var result = new StringBuilder();

			for (int c = 0; c < text.Length; c++)
				result.Append((char)((uint)text[c] ^ (uint)key[c % key.Length]));

			return result.ToString();
		}
	}
}
