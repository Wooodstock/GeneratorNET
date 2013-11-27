using Couche_middleware._07_Couche_metier._08_Composant_metier;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorNET.ReceptionSTG;

namespace GeneratorNET.Couche_middleware._07_Couche_metier._07_Controleur_workflow
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
                Console.WriteLine("key : "+key.Key/* + " - value :" + key.Value*/);
				for (int i = 1298; i < 1299; i++)
				{
					string txt_decrypted = EncryptOrDecrypt((string) key.Value, i.ToString());
					string file_name = (string) key.Key;
					string cle = i.ToString();
					ReceptionSTGClient rSTG = new ReceptionSTGClient();
					txt_decrypted = escapeIllegal(txt_decrypted);
					rSTG.sendToQueue(txt_decrypted, file_name, cle);
					Console.WriteLine(txt_decrypted);
				}
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

		static string escapeIllegal(string p)
		{
			StringBuilder b = new StringBuilder(p);
			b.Replace("<", " ");
			b.Replace(">", " ");
			b.Replace("&", " ");
			b.Replace("\"", " ");
			b.Replace("'", " ");
			b.Replace("^", " ");
			b.Replace("%", " ");
			return b.ToString();
		}
    }
}
