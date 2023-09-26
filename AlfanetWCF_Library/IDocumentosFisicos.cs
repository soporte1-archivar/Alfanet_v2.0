using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Alfanet.CommonObject;

namespace AlfanetWCF_Library
{   
    [ServiceContract]
    public interface IDocumentosFisicos
    {
        [OperationContract]
        List<ObjDocumentos> GetPendingDocuments(ConfigData config, string dependenciaCodigo);

        [OperationContract]
        bool DocumentAccepted(ConfigData config, string numeroDocumento, string grupoCodigo);

        [OperationContract]
        List<ObjDocumentos> GetReceivedDocuments(string fechaInicial, string fechaFinal, string dependenciaCodigo, out string resultado, ConfigData config);        
    }
}
