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
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Generator
{
    public class General
    {
        public string pdf_path = @"C:\Generator\report.pdf";

        public void Leave()
        {
            if (MessageBox.Show("Voulez-vous vraiment quitter l'application ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        public void sendEmail(STG oSTG)
        {
            string Mail_From = "sendemailgenerator@yopmail.com";
            string Mail_To = "receiveemailgenerator@yopmail.com";
            string Mail_Subject = "test"; //CUC.oSTG.TokenApp + " - Résultats du déchiffrement";
            string Mail_Body = "Ci-joint le rapport de déchiffrement des fichiers.";

            SmtpClient Mail_Smtp = new SmtpClient("smtp.yopmail.com");
            Mail_Smtp.Credentials = new NetworkCredential("", "");

            MailMessage oMail = new MailMessage(Mail_From, Mail_To, Mail_Subject, Mail_Body);

            createReport(oSTG);

            oMail.Attachments.Add(new Attachment(pdf_path));

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
            if(File.Exists(pdf_path))
            {
                File.Delete(pdf_path);
            }

            Document pdf_document = new Document();
            PdfWriter.GetInstance(pdf_document, new FileStream(pdf_path, FileMode.Create));
            pdf_document.Open();
            pdf_document.AddTitle("Rapport de déchiffrement");
            pdf_document.Add(new Paragraph("Rapport de déchiffrement des fichiers par " + oSTG.data["login"] + "."));
            pdf_document.Add(new Paragraph("Nombre de fichiers traités :" + oSTG.files.Count.ToString()));

            PdfPTable pdf_table_files = new PdfPTable(3) ; 
            
            foreach (DictionaryEntry key in oSTG.files)
            {
                PdfPCell pdf_cell = new PdfPCell(new Paragraph("Fichiers déchiffrés"));
                pdf_cell.Colspan = 3;
                pdf_table_files.AddCell(pdf_cell);

                pdf_table_files.AddCell(System.IO.Path.GetFileNameWithoutExtension((string)key.Key));
                pdf_table_files.AddCell("LOLOLOL");
                pdf_table_files.AddCell((string)key.Value);
            }
   
            pdf_document.Add(pdf_table_files);

            pdf_document.Add(new Paragraph("Adresse(s) Email : " + oSTG.data["mail"]));

            pdf_document.Close();
        }
    }
}
