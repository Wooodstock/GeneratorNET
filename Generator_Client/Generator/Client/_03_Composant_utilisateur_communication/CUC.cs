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

        public STG sendMessage(STG oSTG)
        {
            oSTG.TokenApp = "Generator";

            ChannelFactory<Couche_middleware.IcomposantService> myChannelFactory = null;
            Couche_middleware.IcomposantService myService;
            
            try
            {
                myChannelFactory = new ChannelFactory<IcomposantService>("NetTcpBinding_IcomposantService");
                myService = myChannelFactory.CreateChannel();
                oSTG = myService.connection(oSTG);
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
