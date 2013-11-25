using Generator.Couche_middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Collections;

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
            oSTG.Operationname = "GpcsUser_ConnectionUser";

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
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(oSTG.Info);

            CUC.oSTG = oSTG;

            return oSTG;
        }
    }
}
