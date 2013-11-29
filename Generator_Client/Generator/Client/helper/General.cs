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
using System.Diagnostics;

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
            createReport(oSTG);

            MessageBox.Show("Rapport généré avec succès.");

            Process.Start(pdf_path);

            if (MessageBox.Show("Voulez-vous envoyer le rapport par Email ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string Mail_From = "emokevin.76@gmail.com";
                string Mail_To = "groupe4generator@outlook.fr";
                string Mail_Subject = oSTG.TokenApp + " - Résultats du déchiffrement";
                string Mail_Body = "Ci-joint le rapport de déchiffrement des fichiers.";

                SmtpClient Mail_Smtp = new SmtpClient("smtp.gmail.com", 465);
                Mail_Smtp.EnableSsl = true;
                Mail_Smtp.Credentials = new NetworkCredential("emokevin.76@gmail.com", "password");

                MailMessage oMail = new MailMessage(Mail_From, Mail_To, Mail_Subject, Mail_Body);

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

            var pdf_font_black = FontFactory.GetFont("Arial", 12, iTextSharp.text.BaseColor.BLACK);
            var pdf_font_black_text = FontFactory.GetFont("Arial", 10, iTextSharp.text.BaseColor.BLACK);
            var pdf_font_white = FontFactory.GetFont("Arial", 16, iTextSharp.text.BaseColor.WHITE);

            pdf_document.AddTitle("Rapport de déchiffrement");
            pdf_document.Add(new Paragraph("Rapport de déchiffrement des fichiers édité par " + oSTG.data["login"] + ".", pdf_font_black));
            pdf_document.Add(new Paragraph("Nombre de fichiers traités : " + oSTG.files.Count.ToString(), pdf_font_black));
            pdf_document.Add(new Paragraph("Clé de déchiffrement : " + (string)oSTG.data["cle"], pdf_font_black));
            pdf_document.Add(new Paragraph("\n"));

            PdfPTable pdf_table_files = new PdfPTable(2);

            PdfPCell pdf_cell_Dechiffre = new PdfPCell(new Paragraph("Fichier(s) déchiffré(s)", pdf_font_white));
            pdf_cell_Dechiffre.BackgroundColor = iTextSharp.text.BaseColor.DARK_GRAY;
            pdf_cell_Dechiffre.Colspan = 2;
            pdf_table_files.AddCell(pdf_cell_Dechiffre);

            foreach (DictionaryEntry key in oSTG.files)
            {
                char[] delimiterChars = { ';' };
                
                string key_raw = (string)key.Key;
                string[] key_words = key_raw.Split(delimiterChars);

                PdfPCell pdf_cell_Fichier = new PdfPCell(new Paragraph("Fichier", pdf_font_black));
                pdf_cell_Fichier.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                pdf_cell_Fichier.Colspan = 1;
                pdf_table_files.AddCell(pdf_cell_Fichier);

                PdfPCell pdf_cell_Ratio = new PdfPCell(new Paragraph("Ratio de confiance", pdf_font_black));
                pdf_cell_Ratio.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                pdf_cell_Ratio.Colspan = 1;
                pdf_table_files.AddCell(pdf_cell_Ratio);

                pdf_table_files.AddCell(new Paragraph(System.IO.Path.GetFileNameWithoutExtension(key_words[0]), pdf_font_black));
                pdf_table_files.AddCell(new Paragraph(key_words[1], pdf_font_black));

                PdfPCell pdf_cell_Texte = new PdfPCell(new Paragraph("Texte", pdf_font_black));
                pdf_cell_Texte.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                pdf_cell_Texte.Colspan = 2;
                pdf_table_files.AddCell(pdf_cell_Texte);

                PdfPCell pdf_cell_Files_Texte = new PdfPCell(new Paragraph((string)key.Value, pdf_font_black_text));
                pdf_cell_Files_Texte.Colspan = 2;
                pdf_table_files.AddCell(pdf_cell_Files_Texte);
            }

            pdf_document.Add(pdf_table_files);

            pdf_document.Add(new Paragraph("\n"));
            pdf_document.Add(new Paragraph("Adresse Email : " + oSTG.data["mail"]));

            pdf_document.Close();
        }
    }
}
