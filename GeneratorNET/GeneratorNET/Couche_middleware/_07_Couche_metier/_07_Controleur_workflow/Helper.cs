using Couche_middleware._07_Couche_metier._08_Composant_metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneratorNET.ReceptionSTG;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeneratorNET.Couche_middleware._07_Couche_metier._07_Controleur_workflow
{
	//delegate void paramDelegate(string solution, string file_name, string cle, bool sample);
	class Helper
	{
		private int[] starters;
		private int[] operations;
		private int nombreProc { get; set; }
		private int keyNumber { get; set; }
		private uint[] txt_tab;

		public uint[] Txt_tab
		{
			get { return txt_tab; }
			set { txt_tab = value; }
		}

		public int[] Starters
		{
			get { return starters; }
			set { starters = value; }
		}


		public int[] Operations
		{
			get { return operations; }
			set { operations = value; }
		}



		private int envoi;

		public int Envoi
		{
			get { return envoi; }
			set { envoi = value; }
		}

		public Helper() { }

		public void calculOperation(int nombreProc, int keyNumber)
		{
			this.nombreProc = nombreProc;
			this.keyNumber = keyNumber;
			int operation = keyNumber / nombreProc;
			if (keyNumber % nombreProc != 0)
			{
				operation++;
			}

			//Console.WriteLine("Nombre de proc : {0} - nombre de clés {1}", nombreProc, keyNumber);
			this.starters = new int[nombreProc];
			this.operations = new int[nombreProc];
			for (int i = 0; i < nombreProc; i++)
			{
				this.starters[i] = 0 + (i * operation);
				//Console.WriteLine("Starters {0} - {1} ", i, this.starters[i]);
			}
			for (int i = 0; i < nombreProc; i++)
			{
				if (i == nombreProc - 1)
				{
					this.operations[i] = this.keyNumber;
				}
				else
				{
					this.operations[i] = this.starters[i + 1];
				}
				//Console.WriteLine("Operations {0} - {1} ", i, this.operations[i]);
			}
		}

		public string EncryptOrDecrypt(uint[] txt_tab, string key)
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

		public void ReadText()
		{
			string texte = System.IO.File.ReadAllText("C:\\Users\\tony\\Downloads\\A4L_DAD_GEN_LEVEL1\\f4.txt");
			if (texte.Length > 500)
			{
				texte = texte.Substring(0, 500);
			}
			this.txt_tab = new uint[texte.Length];
			for (int j = 0; j < texte.Length; j++)
			{
				this.txt_tab[j] = (uint)texte[j];
			}
		}

		public void decrypter(object j, string file_name)
		{
			ReceptionSTGClient rSTG = new ReceptionSTGClient();
			//paramDelegate oDLG = new paramDelegate(rSTG.sendToQueue);
			int k = (int)j;
			int start = this.starters[k];
			int operation = this.operations[k];
			for (int i = start; i < operation; i++)
			{
				string solution = EncryptOrDecrypt(this.txt_tab, i.ToString());
				//Console.WriteLine("Décryptage avec la clé :" + i);
				solution = CleanInvalidXmlChars(solution);
				string[] solution_split = solution.Split(new char[] { ' ' });
				// solution_split[0].Length < 50
				// solution_split[0].Contains('@')
				if (solution_split.Length > 1 || solution_split[0].Length < 50)
				{					
					rSTG.sendToQueue(solution, file_name, i.ToString(), true);
					envoi++;
				}
				//Console.WriteLine("apres send : " + sw.ElapsedMilliseconds.ToString());				
				if (GlobalVariables.clientStop)
				{
					GlobalVariables.clientStop = false;
					break;
				}
				else if (GlobalVariables.cleTrouve)
				{
					break;
				}
				else if (GlobalVariables.finTraitement)
				{

					GlobalVariables.finTraitement = false;
					break;
				}
				//Console.WriteLine("fin boucle : " + sw.ElapsedMilliseconds.ToString());					
				//Console.WriteLine(txt_decrypted);
			}

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
