using Generator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generator
{
    public partial class frm_Generator : Form
    {
        public frm_Generator()
        {
            InitializeComponent();
        }

        private void frm_Generator_Load(object sender, EventArgs e)
        {
            frm_Login.ActiveForm.Hide();

            Refresh_NB_Files();
        }

        private void btn_Parcourir_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileNames.Length > 0)
			{
				foreach(string filename in openFileDialog1.FileNames)
				{
                    if (!lst_Files.Items.Contains(filename))
                    {
                        lst_Files.Items.Add(filename);
                    }
				}
                
                Refresh_NB_Files();
			}
        }

        private void Refresh_NB_Files()
        {
            int NB_Files;
            NB_Files = lst_Files.Items.Count;

            if (NB_Files == 0 || NB_Files == 1)
            {
                lbl_NB_Files.Text = Convert.ToString(NB_Files) + " fichier sélectionné.";
            }
            else
            {
                lbl_NB_Files.Text = Convert.ToString(NB_Files) + " fichier(s) sélectionné(s).";
            }
        }

        private void btn_Quitter_Click(object sender, EventArgs e)
        {
            General General_Functions = new General();
            General_Functions.Leave();
        }

        private void Delete_Files()
        {
            foreach (String File in lst_Files.SelectedItems)
            {
                lst_Files.Items.Remove(File);

                break;
            }
        }

        private void btn_Delete_File_Click(object sender, EventArgs e)
        {
            while (lst_Files.SelectedItems.Count > 0)
            {
                Delete_Files();
            }

            Refresh_NB_Files();
        }

        private void btn_Ouvrir_Click(object sender, EventArgs e)
        {
            foreach (String File in lst_Files.SelectedItems)
            {
                Process.Start(File);
            }
        }

        private Dictionary<string, string[]> Prepare_Import()
        {
            Dictionary<string, string[]> Files_Dictionnary = new Dictionary<string, string[]>();

            foreach(string filename in openFileDialog1.FileNames)
			{
                Files_Dictionnary.Add(filename, System.IO.File.ReadAllLines(filename));
			}

            return Files_Dictionnary;
        }

        private void btn_Dechiffrer_Click(object sender, EventArgs e)
        {
            Dictionary<string, string[]> Files_Dictionnary = Prepare_Import();

            foreach(KeyValuePair<string, string[]> key in Files_Dictionnary)
            {
                Console.WriteLine(key.Value);
            }

            /*CUT user_CUT = new CUT(user_CUC);
            user_CUT.dechiffrer();*/
        }

    }
}
