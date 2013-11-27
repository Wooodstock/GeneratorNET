using Generator;
using Generator.Couche_middleware;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generator
{
    public partial class frm_Generator : Form
    {
        public int Bar_Percent;

        public frm_Generator()
        {
            InitializeComponent();
        }

        private void frm_Generator_Load(object sender, EventArgs e)
        {
            frm_Login.ActiveForm.Hide();

            btn_Annuler.Visible = false;

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
			}
            Refresh_NB_Files();
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

        private void btn_Dechiffrer_Click(object sender, EventArgs e)
        {
            CUT user_CUT = new CUT();
            CUC user_CUC = new CUC();

            CUC.oSTG.files = new Hashtable();

            if (lst_Files.Items.Count > 0)
            {
                btn_Dechiffrer.Enabled = false;
                btn_Delete_File.Enabled = false;
                btn_Parcourir.Enabled = false;
            }

            foreach (string filename in openFileDialog1.FileNames)
            {
                CUC.oSTG.files.Add(filename, System.IO.File.ReadAllText(filename));
            }

            user_CUC.sendMessage(user_CUT.dechiffrer(CUC.oSTG, Convert.ToInt16(txt_SampleSize.Text)));

            btn_Annuler.Visible = true;

            double Bar_Percent_double = Math.Round(100 / (double)lst_Files.Items.Count, 0);

            bar_FilesDone.Value += Bar_Percent;
        }

        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            btn_Annuler.Visible = false;
            btn_Dechiffrer.Enabled = true;
            btn_Delete_File.Enabled = true;
            btn_Parcourir.Enabled = true;
        }
    }
}
