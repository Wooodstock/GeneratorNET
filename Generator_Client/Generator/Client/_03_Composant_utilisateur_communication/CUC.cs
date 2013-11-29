using Generator.Couche_middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Collections;
using System.Windows.Forms;

namespace Generator
{
    public class CUC
    {
        public CUC()
        {
            
        }

        static public STG oSTG;

        public async Task<STG> sendMessage(STG oSTG)
        {
            oSTG.TokenApp = "Generator";

            try
            {
                Couche_middleware.IcomposantService myService = new Couche_middleware.IcomposantServiceClient();
                Task<STG> Temp_Task = myService.connectionAsync(oSTG);
                oSTG = await Temp_Task;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK);
            }
            
            CUC.oSTG = oSTG;

            return oSTG;
        }
    }
}
