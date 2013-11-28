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
        public string pdf_path = @"C:\report.pdf";

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
            string Mail_Subject = oSTG.TokenApp + " - Résultats du déchiffrement";
            string Mail_Body = "Ci-joint le rapport de déchiffrement des fichiers.";

            SmtpClient Mail_Smtp = new SmtpClient("smtp.live.com", 25);
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
            pdf_document.Add(new Paragraph("Rapport de déchiffrement des fichiers édité par " + oSTG.data["login"] + "."));
            pdf_document.Add(new Paragraph("Nombre de fichiers traités :" + oSTG.files.Count.ToString()));

            PdfPTable pdf_table_files = new PdfPTable(3);

            PdfPCell pdf_cell_Dechiffre = new PdfPCell(new Paragraph("Fichiers déchiffrés"));
            pdf_cell_Dechiffre.BackgroundColor = iTextSharp.text.BaseColor.DARK_GRAY;
            pdf_cell_Dechiffre.Colspan = 3;

            pdf_table_files.AddCell(pdf_cell_Dechiffre);

            PdfPCell pdf_cell_Fichier = new PdfPCell(new Paragraph("Fichier"));
            pdf_cell_Fichier.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            pdf_table_files.AddCell(pdf_cell_Fichier);

            pdf_table_files.AddCell(pdf_cell_Fichier);

            PdfPCell pdf_cell_Cle = new PdfPCell(new Paragraph("Clé de déchiffrement"));
            pdf_cell_Cle.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            pdf_table_files.AddCell(pdf_cell_Cle);

            pdf_table_files.AddCell(pdf_cell_Cle);

            PdfPCell pdf_cell_Texte = new PdfPCell(new Paragraph("Texte"));
            pdf_cell_Texte.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            pdf_table_files.AddCell(pdf_cell_Texte);

            pdf_table_files.AddCell(pdf_cell_Texte);
            
            foreach (DictionaryEntry key in oSTG.files)
            {
                pdf_table_files.AddCell(new Paragraph(System.IO.Path.GetFileNameWithoutExtension((string)key.Key)));
                pdf_table_files.AddCell(new Paragraph("LOLOLOL"));
                pdf_table_files.AddCell(new Paragraph((string)key.Value));
            }

            pdf_document.Add(pdf_table_files);

            pdf_document.Add(new Paragraph("Adresse(s) Email : " + oSTG.data["mail"]));

            pdf_document.Close();
        }
    }
}
