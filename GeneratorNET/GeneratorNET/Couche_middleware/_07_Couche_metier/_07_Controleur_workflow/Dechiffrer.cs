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
using GeneratorNET.Couche_middleware._07_Couche_metier._07_Controleur_workflow;

namespace Couche_middleware._07_Couche_metier._07_Controleur_workflow
{
    class Dechiffrer
    {
		delegate void paramDelegate(object o, string file_name);
        public STG Execute(STG oSTG) 
		{
			Stopwatch sw2 = new Stopwatch();
			sw2.Start();
            Hashtable files = (Hashtable) oSTG.files;
			int sampleSize = (int)oSTG.GetData("sampleSize");
			bool useSample = true;
			if (sampleSize < 1)
			{
				useSample = false;
			}
			ReceptionSTGClient rSTG = new ReceptionSTGClient();
            foreach (DictionaryEntry key in files)
            {
				Stopwatch sw = new Stopwatch();	
				sw.Start();
                //Console.WriteLine("key : "+key.Key/* + " - value :" + key.Value*/);
				string texte = key.Value.ToString();
				string echantillon;
				if (texte.Length > sampleSize && useSample)
				{
					echantillon = texte.Substring(0, sampleSize);
				}
				else
				{
					echantillon = texte;
				}				
				int taille = echantillon.Length;
				uint[] txt_tab = new uint[taille];
				for (int j = 0; j < taille; j++)
				{
					txt_tab[j] = (uint)echantillon[j];
				}
				Console.WriteLine("début de l'envoi des messages : ");
				Helper help = new Helper();
				// on lit le fichier
				help.Txt_tab = txt_tab;
				// On compte le nombre de processeur :
				int heart = Environment.ProcessorCount;
				int keyNumber = 10000;
				string file_name = key.Key.ToString();

				//On complete les tableau de start et operations
				help.calculOperation(heart, keyNumber);


				// Création du delegate de traitement :
				paramDelegate dlg = new paramDelegate(help.decrypter);

				// ON commence le traitement sur les 10 000 clés
				Parallel.For(0, heart, i =>
				{
					help.decrypter(i, file_name);
				});						
				sw.Stop();
				Console.WriteLine("messages envoyés : " + help.Envoi + " en " + sw.Elapsed + " secondes");
				if (GlobalVariables.cleTrouve)
				{
					break;
				}
            }
			if (GlobalVariables.cleTrouve)
			{
				int nb_files = 0;
				foreach (DictionaryEntry key in files)
				{

					string texte = key.Value.ToString();
					int taille = texte.Length;
					uint[] txt_tab = new uint[taille];
					for (int j = 0; j < taille; j++)
					{
						txt_tab[j] = (uint)texte[j];
					}
					string txt = EncryptOrDecrypt(txt_tab, GlobalVariables.cle);
					txt = CleanInvalidXmlChars(txt);
					rSTG.sendToQueue(txt, key.Key.ToString(), GlobalVariables.cle, false);
					nb_files++;
					//Console.WriteLine(txt);
					//Console.WriteLine("l'email trouve est" + GlobalVariables.mail);
				}
				while (GlobalVariables.nb_callback < nb_files)
				{
					System.Threading.Thread.Sleep(500);
				}
				oSTG.files.Clear();
				oSTG.SetData("cle", GlobalVariables.cle);
				oSTG.SetData("mail", GlobalVariables.mail);
				
				oSTG.files = GlobalVariables.files;
			}
			sw2.Stop();
			Console.WriteLine("Temps de traitement total : " + sw2.Elapsed.ToString());
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
