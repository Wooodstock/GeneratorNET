using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Couche_middleware._07_Couche_metier._08_Composant_metier
{
	public static class GlobalVariables
	{
		public static bool finTraitement = false;
		public static bool cleTrouve = false;
		public static bool clientStop = false;
		public static string nomFichier = "";
		public static string cle = "";
		public static string mail = "";
		public static Hashtable files = new Hashtable();
		public static int nb_callback = 0;

		public static void SetData(string key, object value)
		{
			if (files.ContainsKey(key))
			{
				files.Remove(key);
				files.Add(key, value);
			}
			else
			{
				files.Add(key, value);
			}
		}

	}
}
