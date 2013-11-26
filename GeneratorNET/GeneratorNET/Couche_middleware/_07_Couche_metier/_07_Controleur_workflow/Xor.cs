using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorNET.Couche_middleware._07_Couche_metier._07_Controleur_workflow
{
    class Xor
    {
        public static void writeFile(string[] toWrite, int fileNumber)
        {
            try
            {

                System.IO.File.WriteAllLines("result.txt" + fileNumber, toWrite);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur :" + ex.Message);
            }

        }
        
        public void decryptStringWith9999(string truc)
        {
            List<string> results = new List<string>();

            byte[] byteArray = NormalStringByteArray(truc);
            string unetzero = Format(byteArray);
            Console.WriteLine("Code Ascii binaire :     " + unetzero);
            for (int i = 1; i < 10000; i++) // modification de la clé => 4 octets
            {
                string s = Convert.ToString(i, 2);
                while (s.Length < 8)
                {
                    s = "0" + s;
                }
                string unetzeroxor = xor(unetzero, s);
                byte[] byteArrayXor = GetBytesFromBinaryString(unetzeroxor);
                string result = getStringFromBytes(byteArrayXor);
                results.Add(result);
            }

            // write result to file
            //writeFile(results.ToArray(), 1);
        }

        public byte[] NormalStringByteArray(string normalString)
        {
            Encoding ASCIIEncoding = Encoding.ASCII;
            byte[] byteArray = new byte[ASCIIEncoding.GetByteCount(normalString)];
            byteArray = ASCIIEncoding.GetBytes(normalString);
            return byteArray;
        }

        public string Format(byte[] data)
        {
            //storage for the resulting string
            string result = string.Empty;
            //iterate through the byte[]
            foreach (byte value in data)
            {
                //storage for the individual byte
                string binarybyte = Convert.ToString(value, 2);
                //if the binarybyte is not 8 characters long, its not a proper result
                while (binarybyte.Length < 8)
                {
                    //prepend the value with a 0
                    binarybyte = "0" + binarybyte;
                }
                //append the binarybyte to the result
                result += binarybyte;
            }
            //return the result
            return result;
        }

        public string xor(string binarybyte, string key)
        {
            char[] t = binarybyte.ToCharArray();
            char[] k = key.ToCharArray();


            string result = "";
            int j = 0;
            for (int i = 0; i < t.Length; i++)
            {
                if (j < k.Length - 1) { j++; } else { j = 0; }
                result += t[i] ^ k[j];
            }
            Console.WriteLine("Resultat Xor bit a bit : " + result);
            return result;
        }

        public string binaryToString(string bynary)
        {


            return bynary;
        }

        public Byte[] GetBytesFromBinaryString(String binary)
        {
            var list = new List<Byte>();

            for (int i = 0; i < binary.Length; i += 8)
            {
                String t = binary.Substring(i, 8);
                Console.WriteLine(Convert.ToByte(t, 2));
                list.Add(Convert.ToByte(t, 2));
            }

            return list.ToArray();
        }

        public string getStringFromBytes(byte[] b)
        {
            Encoding ASCIIEncoding = Encoding.ASCII;
            string result = ASCIIEncoding.GetString(b);
            Console.WriteLine(result);
            return result;
        }

        
    }
}
