using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfanet.CommonObject;
using Alfanet.Dal;
using System.Data;
using Alfanet.CommonLibrary;

namespace Alfanet.Bll
{
    public class DocumentosFisicosBLL
    {
        public List<ObjDocumentos> GetPendingDocuments(ConfigData config, string dependenciaCodigo)
        {
            QueryManager dal = null;
            try
            {
                dal = new QueryManager();
                List<ObjDocumentos> listDocumentsPending = new List<ObjDocumentos>();
                listDocumentsPending = dal.GetPendingDocuments(config, dependenciaCodigo);               
                return listDocumentsPending;

            }
            catch (Exception)
            { 
                throw;
            }
        }


          public bool DocumentAccepted(ConfigData config, string numeroDocumento, string grupoCodigo)
          {
              QueryManager dal = null;
              try
              {
                  dal = new QueryManager();
                  return dal.DocumentAccepted(config, numeroDocumento, grupoCodigo);
               
              }
              catch (Exception)
              {
                  throw;
              }
          }

          public List<ObjDocumentos> GetReceivedDocuments(string fechaInicial, string fechaFinal, string dependenciaCodigo, out string resultado, ConfigData config)
          {
              List<ObjDocumentos> listDocuments = null;
              ObjDocumentos documentos = null;
              DateTime fechaIni;
              DateTime fechaFin;
              QueryManager dal = null;
              DataSet data = null;
              CommonLibrary.CommonLibrary common = null;
              try
              {
                  dal = new QueryManager();
                  listDocuments = new List<ObjDocumentos>();
                  bool validaFechas = ValidarFechas(fechaInicial, fechaFinal, out fechaIni, out fechaFin);
                  if (!validaFechas)
                  {
                      resultado = "El formato de fechas no es válido.";
                      return listDocuments;
                  }
                  data = new DataSet();
                  data = dal.GetReceivedDocuments(fechaIni, fechaFin, dependenciaCodigo, config);

                  if (data.Tables[0].Rows.Count > 0)
                  {
                      foreach (DataRow row in data.Tables[0].Rows)
                      {
                          documentos = new ObjDocumentos();
                          documentos.NumeroDocumento = row["radicado"].ToString();
                          documentos.ProcedenciaNombre = row["procedencia"].ToString();
                          documentos.GrupoNombre = row["grupo"].ToString();
                          documentos.WfmovimientoFecha = row["fecharadicacion"].ToString();
                          documentos.DependenciaNombre = row["origen"].ToString();
                          documentos.Leido = row["estado"].ToString();
                          documentos.FechaVencimiento = row["fecharecepcion"].ToString();
                          listDocuments.Add(documentos);
                      }
                  }
                  resultado = "Consulta realizada correctamente.";
                  return listDocuments;
              }
              catch (Exception)
              {
                  resultado = "Error al realizar la consulta, por favor intente nuevamente.";
                  listDocuments = new List<ObjDocumentos>();
                  return listDocuments;
              }
          }

          private bool ValidarFechas(string fechaInicial, string fechaFinal, out DateTime fechaIni, out DateTime fechaFin)
          {
              try
              {
                  bool aux1 = DateTime.TryParse(fechaInicial, out fechaIni);
                  bool aux2 = DateTime.TryParse(fechaFinal, out fechaFin);
                  if (aux1 == false || aux2 == false)
                  {
                      return false;
                  }
                  if (fechaIni > fechaFin)
                  {
                      DateTime aux = fechaFin;
                      fechaFin = fechaIni;
                      fechaIni = aux;
                  }
                  return true;
              }
              catch (Exception)
              {
                  fechaIni = DateTime.Now;
                  fechaFin = DateTime.Now;
                  return false;
              }
          }
    }
}
