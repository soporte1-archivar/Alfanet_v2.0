using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.WorkFlowService;

using Alfanet.CommonObject;
using Alfanet.CommonLibrary;
using System.Web.Services;

namespace WebApplication1.WorkFlow
{
	public partial class WorkFlow : System.Web.UI.Page
	{        
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                string dependencia = Request.QueryString["dep"];
                if (dependencia   != null)
                {
                    Session["Dependencia"] = dependencia;
                }
                else
                {
                    Session["Dependencia"] = "2.02.2.2.41";
                }
				//RegistrosClient client = null;
				CommonLibrary common = null;
				try
				{
					common = new CommonLibrary();

                    if (Session["DatabaseEngine"] == null)
                    {
                        //common = new CommonLibrary();
                        ConfigData db = common.GetConfigurationInformation();
                        Session["DatabaseEngine"] = db;
                    }
					
					
                    llenarWorkFlow(Session["Dependencia"].ToString());//"2.02.2.2.41");
					string resultFind = null;
					if (!common.FindAnyObjInCache("Dependencias",out resultFind))
					{
						cargarDependencias();
					}
					if (!common.FindAnyObjInCache("Acciones", out resultFind))
					{
						CargarAcciones();
					}
				}
				catch (Exception)
				{
					throw;
				}
			}
		}
		/// <summary>
		/// Carga las acciones de la base de datos y las almacena en cache.
		/// </summary>
		private void CargarAcciones()
		{
			WorkFlowClient client = null;
			List<ObjAccion> acciones = null;
			CommonLibrary common = null;
			try
			{
				common = new CommonLibrary();
				client = new WorkFlowClient();
				acciones = new List<ObjAccion>();
				ConfigData config = new ConfigData();
				config = (ConfigData)Session["DatabaseEngine"];
				acciones = client.GetAcciones(config).ToList();
				string resultSave = null;
				common.SaveObjectInCache("Acciones", acciones, out resultSave);
			}
			catch (Exception)
			{
				throw;
			}
		}
		/// <summary>
		/// Carga y guarda las dependencias en cache
		/// </summary>
		private void cargarDependencias()
		{
			WorkFlowClient client = null;
			List<ObjDependencia> dependencias = null;
			CommonLibrary common = null;
			try 
			{
				common = new CommonLibrary();
				client = new WorkFlowClient();
				dependencias = new List<ObjDependencia>();
				ConfigData config = new ConfigData();
				config = (ConfigData)Session["DatabaseEngine"];
				dependencias = client.GetDependencias(config).ToList();
				string resultSave = null;
				common.SaveObjectInCache("Dependencias", dependencias,out resultSave);		
			}
			catch (Exception)
			{
				throw;
			}
		}
		/// <summary>
		/// Llena todos los listView del work flow.
		/// </summary>
		private void llenarWorkFlow(string dependencia)
		{
			WorkFlowClient client = null;            
			ObjWorkFlowDocuments workFlowDocs = null;
			CommonLibrary common = null;
			try
			{
				client = new WorkFlowClient();                
				ConfigData config = new ConfigData();
				config = (ConfigData)Session["DatabaseEngine"];
                workFlowDocs = client.GetWorkFlowDocuments(config, dependencia);
				lstvTodos.DataSource = workFlowDocs.Todos;
                List<ObjDocumentos> leidos = new List<ObjDocumentos>();
                List<ObjDocumentos> noLeidos = new List<ObjDocumentos>();
                //leidos = workFlowDocs.Todos.Where(x => )
				lstvTodos.DataBind();
				lstvDocumentosVencidos.DataSource = workFlowDocs.Vencidos;
				lstvDocumentosVencidos.DataBind();
				lstvProximosAVencer.DataSource = workFlowDocs.ProximosAVencer;
				lstvProximosAVencer.DataBind();
				lstvDocumentosPendientes.DataSource = workFlowDocs.Pendientes;
				lstvDocumentosPendientes.DataBind();
				lstvDocsCopiaExternos.DataSource = workFlowDocs.CopiaExternos;
				lstvDocsCopiaExternos.DataBind();
				lstvDocsEnviadosInternos.DataSource = workFlowDocs.EnviadosInternos;
				lstvDocsEnviadosInternos.DataBind();
				lstvDocsEnviadosInternosCopia.DataSource = workFlowDocs.EnviadosInternosCopia;
				lstvDocsEnviadosInternosCopia.DataBind();
				lstvrDocsEnSeguimiento.DataSource = workFlowDocs.EnSeguimiento;
				lstvrDocsEnSeguimiento.DataBind();

				common = new CommonLibrary();
				string resultado = string.Empty;
				common.SaveObjectInCache("userId", workFlowDocs, out resultado);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[WebMethod]
		public static string GetDependencias()
		{
			try
			{
				return "hola";
			}
			catch (Exception ex)
			{                
				return ex.Message;
			}            
		}
		/// <summary>
		/// Paginación del listView de todos los documentos recibidos externos.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void lstvTodos_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
		{
			//set current page startindex, max rows and rebind to false
			dprTodos.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
			lstvTodos.DataSource = LoadFromCache().Todos;
			lstvTodos.DataBind();
		}
		/// <summary>
		/// Paginación del listView de documentos vencidos.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void lstvDocumentosVencidos_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
		{
			//set current page startindex, max rows and rebind to false
			dprDocsVencidos.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
			lstvDocumentosVencidos.DataSource = LoadFromCache().Vencidos;
			lstvDocumentosVencidos.DataBind();
		}
		/// <summary>
		/// Paginación del listView de los documentos próximos a vencer.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void lstvProximosAVencer_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
		{
			//set current page startindex, max rows and rebind to false
			dprProximosAVencer.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
			lstvProximosAVencer.DataSource = LoadFromCache().ProximosAVencer;
			lstvProximosAVencer.DataBind();
		}
		/// <summary>
		/// Paginación de los documentos pendientes.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void lstvDocumentosPendientes_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
		{
			//set current page startindex, max rows and rebind to false
			dprDocumentosPendientes.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
			lstvDocumentosPendientes.DataSource = LoadFromCache().Pendientes;
			lstvDocumentosPendientes.DataBind();
		}
		/// <summary>
		/// Paginación de los documentos copia externos.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void lstvDocsCopiaExternos_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
		{
			//set current page startindex, max rows and rebind to false
			dprCopiaExternos.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
			lstvDocsCopiaExternos.DataSource = LoadFromCache().CopiaExternos;
			lstvDocsCopiaExternos.DataBind();
		}
		/// <summary>
		/// Paginación de los documentos enviados internos
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void lstvDocsEnviadosInternos_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
		{
			//set current page startindex, max rows and rebind to false
			dprDocsEnviadosInternos.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
			lstvDocsEnviadosInternos.DataSource = LoadFromCache().EnviadosInternos;
			lstvDocsEnviadosInternos.DataBind();
		}
		/// <summary>
		/// Paginación de los documentos enviados internos copia.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void lstvDocsEnviadosInternosCopia_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
		{
			//set current page startindex, max rows and rebind to false
			dprDocsEnviadosInternosCopia.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
			lstvDocsEnviadosInternosCopia.DataSource = LoadFromCache().EnviadosInternosCopia;
			lstvDocsEnviadosInternosCopia.DataBind();
		}
		/// <summary>
		/// Paginación de los documentos en seguimiento.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void lstvrDocsEnSeguimiento_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
		{
			//set current page startindex, max rows and rebind to false
			dprDocsEnSeguimiento.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
			lstvrDocsEnSeguimiento.DataSource = LoadFromCache().EnSeguimiento;
			lstvrDocsEnSeguimiento.DataBind();
		}
		/// <summary>
		/// Paginación del listview de resultados de búsqueda.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void lstvResutadosBusqueda_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
		{
			//set current page startindex, max rows and rebind to false
			CommonLibrary common = new CommonLibrary();
			string result;
			dprBusqueda.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
			lstvResutadosBusqueda.DataSource = common.FindObjectInCache("userId_search", out result);
			lstvResutadosBusqueda.DataBind();
		}
		private List<ObjDocumentos> LoadFromCacheSearchResults()
		{
			CommonLibrary common = null;
			string result = string.Empty;
			try
			{
				common = new CommonLibrary();
				return common.FindObjectInCache("userId__Search", out result);
			}
			catch (Exception)
			{
				throw;
			}
		}
		private ObjWorkFlowDocuments LoadFromCache()
		{
			CommonLibrary common = null;
			string result = string.Empty;
			try
			{
				common = new CommonLibrary();
				return common.FindObjInCache("userId", out result);
			}
			catch (Exception)
			{
				throw;
			}
		}

		protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
		{
            ibtnBuscar.Enabled = false;
			dprBusqueda.SetPageProperties(0, dprBusqueda.MaximumRows, false);

			string key = null;
			CommonLibrary common = null;
			List<ObjDocumentos> reception = null;
			try
			{
				string saveCache;
				common = new CommonLibrary();
				key = txtBuscar.Text.ToUpper();
				reception = new List<ObjDocumentos>();
				reception = common.FindKeyInWorkFlow("userId", key);
				common.SaveObjectInCache("userId_search", reception, out saveCache);//Se guarda este objeto en cache para la paginacion del listview de busqueda.
				lstvResutadosBusqueda.DataSource = reception;
				lstvResutadosBusqueda.DataBind();
				txtBuscar.Text = string.Empty;
                ibtnBuscar.Enabled = true;
			}
			catch (Exception)
			{
                ibtnBuscar.Enabled = true;
				throw;
			}
		}
		/// <summary>
		/// Redirecciona un documento a otra dependencia.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnFinalizar_Click(object sender, EventArgs e)
		{
			btnFinalizar.Enabled = false;
			string dependenciaDestino = txtAutoCompleteDependencias.Text;
            string note = string.Empty;
            string dependenciaOrigen = Session["Dependencia"].ToString();//"2.02.2.2.41" "2.02.2.2.41";
			string accion = txtAutoCompleteAcciones.Text;
			string documento = txtNumDocument.Text;
			WorkFlowClient client = null;
			ConfigData config = null;
			string result = string.Empty;
			try
			{
				config = new ConfigData();
				config = (ConfigData)Session["DatabaseEngine"];
				client = new WorkFlowClient();
				result = client.RedirectDocument(documento, dependenciaDestino, note, dependenciaOrigen, accion, config);
                llenarWorkFlow(Session["Dependencia"].ToString());//"2.02.2.2.41");
				clearCamposWorkFlow();
				btnFinalizar.Enabled = true;
			}
			catch (Exception)
			{
				btnFinalizar.Enabled = true;
			}
		}
		/// <summary>
		/// Método que limpia los campos de la pantalla de workflow.
		/// </summary>
		private void clearCamposWorkFlow()
		{
			txtAutoCompleteDependencias.Text = string.Empty;
			txtAutoCompleteAcciones.Text = string.Empty;
		}
	}
}
