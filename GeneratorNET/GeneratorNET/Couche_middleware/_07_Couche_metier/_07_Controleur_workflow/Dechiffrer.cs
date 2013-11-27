using Couche_middleware._07_Couche_metier._08_Composant_metier;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorNET.ReceptionSTG;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Couche_middleware._07_Couche_metier._07_Controleur_workflow
{
    class Dechiffrer
    {
        public STG Execute(STG oSTG) {
            Hashtable files = (Hashtable) oSTG.files;

            /*Collection<string> keys = (Collection<string>) files.Keys;

            foreach (string key in keys) {
                string fileName = (string)files[key];
                string fileContent = (string)files["file_content"];
            }		
			*/
            foreach (DictionaryEntry key in files)
            {
				Stopwatch sw = new Stopwatch();
				sw.Start();
                //Console.WriteLine("key : "+key.Key/* + " - value :" + key.Value*/);
				int i;
				string texte = key.Value.ToString();
				int taille = texte.Length;
				uint[] txt_tab = new uint[taille];

				for (int j = 0; j < taille; j++)
				{
					txt_tab[j] = (uint)texte[j];
				}
				Console.WriteLine("début de l'envoi des messages : ");
				for (i = 1; i < 10000; i++)
				{
					string txt_decrypted = EncryptOrDecrypt(txt_tab, i.ToString());
					string file_name = (string) key.Key;
					string cle = i.ToString();
					ReceptionSTGClient rSTG = new ReceptionSTGClient();
					txt_decrypted = CleanInvalidXmlChars(txt_decrypted);
					rSTG.sendToQueue(txt_decrypted, file_name, cle);
					if (GlobalVariables.clientStop)
					{
						GlobalVariables.clientStop = false;
						break;
					}
					else if (GlobalVariables.finTraitement)
					{
						GlobalVariables.finTraitement = false;
						break;
					}
					
					//Console.WriteLine(txt_decrypted);
				}
				sw.Stop();
				int temps = (int)sw.ElapsedMilliseconds;
				temps = temps / 1000;
				Console.WriteLine("messages envoyés : " + i + " en " + temps + " secondes");
            }
            

            return oSTG;
        }

		static string EncryptOrDecrypt(uint[] txt_tab, string key)
		{
			var result = new StringBuilder();
			int taille = key.Length;
			int txt_taille = txt_tab.Length;
			uint[] key_tab = new uint[taille];
			for (int j = 0; j < taille; j++)
			{
				key_tab[j] = (uint)key[j];
			}
			for (int c = 0; c < txt_taille; c++)
				result.Append((char)(txt_tab[c] ^ key_tab[c % taille]));

			return result.ToString();
		}

		public static string CleanInvalidXmlChars(string text)
		{
			// From xml spec valid chars: 
			// #x9 | #xA | #xD | [#x20-#xD7FF] | [#xE000-#xFFFD] | [#x10000-#x10FFFF]     
			// any Unicode character, excluding the surrogate blocks, FFFE, and FFFF. 
			string re = @"[^\x09\x0A\x0D\x20-\uD7FF\uE000-\uFFFD\u10000-u10FFFF]";
			return Regex.Replace(text, re, "");
		}
    }
}
