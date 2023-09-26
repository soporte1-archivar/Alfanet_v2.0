using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Alfanet.Bll;
using Alfanet.CommonObject;

namespace AlfanetWCF_Library
{
    public class WorkFlowService : IWorkFlow
    {
        //[OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        //public List<ObjDocumentos> selectDocumentVenc(ConfigData config)
        //{
        //    //DocumentosBLL documentosBLL = new DocumentosBLL();
        //    //List<ObjDocumentos> documentVec = new List<ObjDocumentos>();
        //    //documentVec = documentosBLL.selectDocumentVenc(config);
        //    //return documentVec;
        //}
         [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public ObjWorkFlowDocuments GetWorkFlowDocuments(ConfigData config, string CodigoDependencia)
        {
            DocumentosBLL documentosBLL = new DocumentosBLL();
            ObjWorkFlowDocuments wfDocuments = new ObjWorkFlowDocuments();
            wfDocuments = documentosBLL.GetWorkFlowDocuments(config, CodigoDependencia);
            return wfDocuments;
        }

         [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
         public List<ObjDependencia> GetDependencias(ConfigData config) 
         {
             DocumentosBLL documentosDLL = new DocumentosBLL();
             List<ObjDependencia> wfDependencias = new List<ObjDependencia>();
             wfDependencias = documentosDLL.GetDependencias(config);
             return wfDependencias;
         }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
         public List<ObjAccion> GetAcciones(ConfigData config)
         {
             DocumentosBLL bll = new DocumentosBLL();
             List<ObjAccion> acciones = new List<ObjAccion>();
             acciones = bll.GetAcciones(config);
             return acciones;
         }
        /// <summary>
        /// Método utilizado para redireccionar un documento a otra dependencia o escritorio
        /// </summary>
        /// <param name="document"></param>
        /// <param name="dependenciaDestino">Cadena que contiene el codigo | nombre de la dependencia a la que se le asignará el documento.</param>
        /// <returns>Respuesta con el resultado del proceso.</returns>
        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public string RedirectDocument(string document, string dependenciaDestino, string note, string dependenciaOrigen, string accion, ConfigData config)
         {
             DocumentosBLL bll = new DocumentosBLL();
             return bll.RedirectDocument(document, dependenciaDestino, note, dependenciaOrigen, accion, config);
         }
    }
}
