using Couche_middleware._07_Couche_metier._08_Composant_metier;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorNET.Couche_middleware._07_Couche_metier._07_Controleur_workflow
{
    class Dechiffrer
    {
        public STG Execute(STG oSTG) {
            Hashtable files = (Hashtable) oSTG.GetData("Files_Hashtable");

            Collection<string> keys = (Collection<string>) files.Keys;

            foreach (string key in keys) {
                string fileName = (string)files[key];
                string fileContent = (string)files["file_content"];
            }

            foreach (DictionaryEntry key in files)
            {
                Console.WriteLine("key : "+key.Key + " - value :" + key.Value);
            }
            

            return oSTG;
        }
    }
}
