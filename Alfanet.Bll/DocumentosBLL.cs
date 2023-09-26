using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfanet.Dal;
using System.Data;
using Alfanet.CommonObject;
using Alfanet.CommonLibrary;

namespace Alfanet.Bll
{
	public class DocumentosBLL
	{
		/// <summary>
		/// Obtiene los documentos que van en el workflow de cada usuario.
		/// </summary>
		/// <param name="config">Objeto de configuracion</param>
		/// <param name="CodigoDependencia">Código de la dependencia.</param>
		/// <returns></returns>
		public ObjWorkFlowDocuments GetWorkFlowDocuments(ConfigData config,string CodigoDependencia)
		{
			QueryManager dal = null;
			DataSet ds = null;
			
			List<ObjDocumentos> docsAllList = null;
			List<ObjDocumentos> docsVencidosList = null;
			List<ObjDocumentos> docsProximosAVencerList = null;
			List<ObjDocumentos> docsPendingList = null;
			List<ObjDocumentos> docsCopiaExternosList = null;
			List<ObjDocumentos> docsEnviadosInternosList = null;
			List<ObjDocumentos> docsEnviadosInternosCopiaList = null;
			List<ObjDocumentos> docsEnSeguimientoList = null;

			ObjWorkFlowDocuments wfDocuments = null;
			try
			{
				dal = new QueryManager();
                ds = dal.GetWorkFlowDocuments(config, CodigoDependencia);
				docsAllList = new List<ObjDocumentos>();				
				docsVencidosList = CreateDocumentsList(ds.Tables[1]);

				docsProximosAVencerList = CreateDocumentsList(ds.Tables[0]);
				docsPendingList = CreateDocumentsList(ds.Tables[2]);
				docsAllList.AddRange(docsVencidosList);
				docsAllList.AddRange(docsProximosAVencerList);
				docsAllList.AddRange(docsPendingList);

                //faltan estas consultas de aca para abajo en el sp, para llenar el resto de documentos en el wf.
				docsCopiaExternosList = CreateDocumentsList(ds.Tables[0]);

				docsEnviadosInternosList = CreateDocumentsList(ds.Tables[0]);
				docsEnviadosInternosCopiaList = CreateDocumentsList(ds.Tables[0]);

				docsEnSeguimientoList = CreateDocumentsList(ds.Tables[0]);
				
				wfDocuments = new ObjWorkFlowDocuments();
				wfDocuments.Todos = docsAllList;
				wfDocuments.Vencidos = docsVencidosList;
				wfDocuments.ProximosAVencer = docsProximosAVencerList;
				wfDocuments.Pendientes = docsPendingList;
				wfDocuments.CopiaExternos = docsCopiaExternosList;
				wfDocuments.EnviadosInternos = docsEnviadosInternosList;
				wfDocuments.EnviadosInternosCopia = docsEnviadosInternosCopiaList;
				wfDocuments.EnSeguimiento = docsEnSeguimientoList;

				return wfDocuments;
			}
			catch (Exception)
			{
				throw;
			}
		}
		private List<ObjDocumentos> CreateDocumentsList(DataTable table)
		{
			ObjDocumentos documents = null;
			List<ObjDocumentos> listDocuments = null;
			try
			{
				listDocuments = new List<ObjDocumentos>();

				foreach (DataRow dr in table.Rows)
				{
					documents = new ObjDocumentos();
                    documents.NumeroDocumento = dr["NumeroDocumento"].ToString();
                    documents.ProcedenciaNombre = dr["ProcedenciaNombre"].ToString();
                    documents.ProcedenciaNUI = dr["ProcedenciaNUI"].ToString();
                    documents.FechaVencimiento = dr["RadicadoFechaVencimiento"].ToString();
                    documents.DependenciaNombre = dr["DependenciaNombre"].ToString();
                    documents.WFMovimientoNotas = dr["WFMovimientoNotas"].ToString();
                    documents.WFAccionNombre = dr["WFAccionNombre"].ToString();
                    documents.RadicadoDetalle = dr["RadicadoDetalle"].ToString();
                    documents.NaturalezaNombre = dr["NaturalezaNombre"].ToString();
                    documents.FechaRadicacion = dr["WFMovimientoFecha"].ToString();
                    documents.NumeroExterno = dr["RadicadoNumeroExterno"].ToString();
                    documents.FechaProcedencia = dr["RadicadoFechaProcedencia"].ToString();
                    documents.MedioNombre = dr["MedioNombre"].ToString();
                    documents.ExpedienteNombre = dr["ExpedienteNombre"].ToString();
                    documents.DependenciaDestino = dr["DependenciaNomDestino"].ToString();
                    documents.Anexo = dr["RadicadoAnexo"].ToString();
                    documents.Leido = dr["FlagLeido"].ToString();
                    documents.Respuesta = dr["Respuesta"].ToString();                    

					listDocuments.Add(documents);
				}
				return listDocuments;
			}
			catch (Exception)
			{                
				throw;
			}
		}

		public List<ObjDependencia> GetDependencias(ConfigData config) 
		{
			QueryManager dal = null;
			ObjDependencia dependencia = null;
			CommonLibrary.CommonLibrary common = null;
			List<ObjDependencia> dependencias = null;
			DataSet data = null;
			try 
			{
				dal = new QueryManager();
			   
				common = new CommonLibrary.CommonLibrary();
				dependencias = new List<ObjDependencia>();
				data = new DataSet();
				data = dal.GetDependencias(config);
				foreach (DataRow item in data.Tables[0].Rows)
				{
					dependencia = new ObjDependencia();
					dependencia.DependenciaCodigo = item.ItemArray[0].ToString();
					dependencia.DependenciaNombre = item.ItemArray[1].ToString();
					dependencias.Add(dependencia);                    
				}                
				return dependencias;		
			}
			catch (Exception)
			{		
				throw;
			}			
		}
        public string RedirectDocument(string document, string dependenciaDestino, string note, string dependenciaOrigen, string accion, ConfigData config)
		{
            if (document.Trim() == "" || dependenciaDestino.Trim() == "" || accion.Trim() == "")
            {
                return "Algunos campos obligatorios no fueron diligenciados.";
            }
			QueryManager dal = null;
			int documentNumber = 0;			
			try
			{
				bool convert = Int32.TryParse(document, out documentNumber);
				dal = new QueryManager();
				dependenciaDestino = dependenciaDestino.Remove(dependenciaDestino.IndexOf(" | "));
				accion = accion.Remove(accion.IndexOf(" | "));
				int done = dal.RedirectDocument(document, dependenciaDestino, note, dependenciaOrigen, accion, config);
				if (done != 0)
				{
					return "Proceso realizado correctamente";
				}
				else
				{
					return "";
				}
			}
			catch (Exception)
			{
				//Gestionar logs aqui.
				return "";
			}
		}

		public List<ObjAccion> GetAcciones(ConfigData config)
		{
			QueryManager dal = null;
			ObjAccion accion = null;
			CommonLibrary.CommonLibrary common = null;
			List<ObjAccion> acciones = null;
			DataSet data = null;
			try
			{
				dal = new QueryManager();

				common = new CommonLibrary.CommonLibrary();
				acciones = new List<ObjAccion>();
				data = new DataSet();
				data = dal.GetAcciones(config);
				foreach (DataRow item in data.Tables[0].Rows)
				{
					accion = new ObjAccion();
					accion.AccionCodigo = item.ItemArray[0].ToString();
					accion.AccionNombre = item.ItemArray[1].ToString();
					acciones.Add(accion);
				}
				return acciones;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
