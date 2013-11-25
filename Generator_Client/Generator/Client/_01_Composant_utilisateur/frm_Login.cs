using Generator;
using Generator.Couche_middleware;
using System;
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
        static public Common.STG oSTG = new Common.STG();

        public frm_Login()
        {
            InitializeComponent();
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_Connection_Click(object sender, EventArgs e)
        {
            /*CUC user_CUC = new CUC(Couche_middleware.IcomposantServiceClient, txt_Login.Text, txt_PWD.Text);

            CUT user_CUT = new CUT(user_CUC);
            user_CUT.login();

            oSTG.data.Add(*/

            CUC user_CUC = new CUC();
            user_CUC.sendMessage(oSTG);
            //user_CUC.sendMessage(oSTG, txt_Login.Text, txt_PWD.Text);

            /*Form form1 = new frm_Generator();
            form1.Show();*/
        }

        private void btn_Quitter_Click(object sender, EventArgs e)
        {
            General General_Functions = new General();
            General_Functions.Leave();
        }
    }
}
