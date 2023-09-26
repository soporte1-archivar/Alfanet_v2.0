using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Alfanet.Dal;
using Alfanet.CommonObject;
using Alfanet.CommonLibrary;
using System.Collections.Generic;

namespace Alfanet.Bll
{
    public class Registros
    {
        CommonLibrary.CommonLibrary commLib = null;
        private string resultCache;     
              

        
        /// <summary>
        /// Este metodo retorna la configuración del motor de base de datos.
        /// </summary>
        /// <returns>Configuración del motor de base de datos.</returns>
        public ConfigData GetConfigurationInformation() 
        {
            ConfigData data = new ConfigData();
            CommonLibrary.CommonLibrary lib = new CommonLibrary.CommonLibrary();
            data = lib.GetConfigurationInformation();
            return data;
        }
    }
}
