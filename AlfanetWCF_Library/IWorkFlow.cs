using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Alfanet.CommonObject;

namespace AlfanetWCF_Library
{
    [ServiceContract]
    public interface IWorkFlow
    {
        //[OperationContract]
        //List<ObjDocumentos> selectDocumentVenc(ConfigData config);

        [OperationContract]
        ObjWorkFlowDocuments GetWorkFlowDocuments(ConfigData config, string CodigoDependencia);  
      
        [OperationContract]
        List<ObjDependencia>  GetDependencias(ConfigData config);

        [OperationContract]
        List<ObjAccion> GetAcciones(ConfigData config);

        [OperationContract]
        string RedirectDocument(string document, string dependenciaDestino, string note, string dependenciaOrigen, string accion, ConfigData config);
    }
}
