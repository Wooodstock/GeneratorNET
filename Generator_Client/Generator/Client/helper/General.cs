using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Generator.Couche_middleware;
using System.IO;
using System.Collections;

namespace Generator
{
    public class General
    {
        public string file_path;

        public void Leave()
        {
            if (MessageBox.Show("Voulez-vous vraiment quitter l'application ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        public void sendEmail()
        {
            string Mail_From = "sendemailgenerator@yopmail.com";
            string Mail_To = "receiveemailgenerator@yopmail.com";
            string Mail_Subject = "test"; //CUC.oSTG.TokenApp + " - Résultats du déchiffrement";
            string Mail_Body = "Ci-joint le rapport de déchiffrement des fichiers.";

            SmtpClient Mail_Smtp = new SmtpClient("smtp.yopmail.com");
            Mail_Smtp.Credentials = new NetworkCredential("", "");

            MailMessage oMail = new MailMessage(Mail_From, Mail_To, Mail_Subject, Mail_Body);

            //oMail.Attachments.Add(new Attachment(@"C:\Generator\report.txt"));

            try
            {
                Mail_Smtp.Send(oMail);
                MessageBox.Show("Email envoyé.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur d'envoi de l'Email : " + ex.Message);
            }
        }

        public void createReport(STG oSTG)
        {
            if(File.Exists(@"C:\Generator\report.txt"))
            {
                File.Delete(@"C:\Generator\report.txt");
            }

            TextWriter Text_Writer = new StreamWriter(@"C:\Generator\report.txt");

            Text_Writer.WriteLine("Rapport de déchiffrement des fichiers");
            Text_Writer.WriteLine("");
            Text_Writer.WriteLine("Nombre de fichiers traités :" + oSTG.files.Count.ToString());

            foreach (DictionaryEntry key in oSTG.files)
            {
                Text_Writer.WriteLine("");
                Text_Writer.WriteLine("- " + key.Key + " :");
                Text_Writer.WriteLine(key.Value);
                Text_Writer.WriteLine("");
            }
                        
            Text_Writer.Write("Adresse Email : " + oSTG.data["mail"]);

            Text_Writer.Close();
        }
    }
}
