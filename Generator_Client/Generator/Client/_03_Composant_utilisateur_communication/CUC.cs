﻿using Generator.Couche_middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Collections;
using Common;

namespace Generator
{
    public class CUC
    {
        Couche_middleware.IcomposantService pxy;
        public CUC()
        {
            
        }

        public Common.STG sendMessage(Common.STG oSTG)
        {
            oSTG.TokenApp = "Generator";
            oSTG.Operationname = "GpcsUser_ConnectionUser";
            oSTG.data = new Hashtable();
            /*oSTG.SetData("login", oLogin);
            oSTG.SetData("password", oPassword);*/
            oSTG.SetData("login", "toto");
            oSTG.SetData("password", "toto");
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

            return oSTG;
        }
    }
}
