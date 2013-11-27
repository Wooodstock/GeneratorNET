using Generator;
using Generator.Couche_middleware;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generator
{
    public partial class frm_Login : Form
    {
        public STG oSTG;

        public frm_Login()
        {
            InitializeComponent();
        }
        
        private void frm_Login_Load(object sender, EventArgs e)
        {
            /*General General_Functions = new General();
            General_Functions.sendEmail();*/
        }

        private void btn_Connection_Click(object sender, EventArgs e)
        {
            oSTG = new STG();
            oSTG.data = new Hashtable();

            CUT user_CUT = new CUT();
            CUC user_CUC = new CUC();

            if(string.IsNullOrEmpty(txt_Login.Text) || string.IsNullOrEmpty(txt_PWD.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK);
            }
            else
            {
                if (user_CUC.sendMessage(user_CUT.login(oSTG, txt_Login.Text, txt_PWD.Text)).Status_op == true)
                {
                    Form form1 = new frm_Generator();
                    form1.Show();
                }
                else if (CUC.oSTG.Info == null)
                {
                    MessageBox.Show("Impossible de se connecter au serveur", "Erreur", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show(CUC.oSTG.Info, "Erreur", MessageBoxButtons.OK);
                }
            }
        }

        private void btn_Quitter_Click(object sender, EventArgs e)
        {
            General General_Functions = new General();
            General_Functions.Leave();
        }
    }
}
