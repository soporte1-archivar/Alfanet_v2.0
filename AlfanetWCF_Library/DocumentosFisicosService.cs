using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Alfanet.CommonObject;
using Alfanet.Bll;

namespace AlfanetWCF_Library
{
    public class DocumentosFisicosService : IDocumentosFisicos
    {
        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public List<ObjDocumentos> GetPendingDocuments(ConfigData config, string dependenciaCodigo)
        {
            DocumentosFisicosBLL oConn = new DocumentosFisicosBLL();
            List<ObjDocumentos> listDocumentsPending = new List<ObjDocumentos>();
            listDocumentsPending = oConn.GetPendingDocuments(config, dependenciaCodigo);
            return listDocumentsPending;
        }
        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public bool DocumentAccepted(ConfigData config, string numeroDocumento, string grupoCodigo)
        {
            DocumentosFisicosBLL oConn = new DocumentosFisicosBLL();
            return oConn.DocumentAccepted(config, numeroDocumento, grupoCodigo);           
        }
        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public List<ObjDocumentos> GetReceivedDocuments(string fechaInicial, string fechaFinal, string dependenciaCodigo, out string resultado, ConfigData config)
        {
            DocumentosFisicosBLL bll = new DocumentosFisicosBLL();
            List<ObjDocumentos> listDocuments = new List<ObjDocumentos>();
            listDocuments = bll.GetReceivedDocuments(fechaInicial, fechaFinal, dependenciaCodigo, out resultado, config);
            return listDocuments;
        }
    }
}
