using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Alfanet.CommonLibrary;
using Alfanet.CommonObject;
using WebApplication1.DocumentosFisicosService;

namespace WebApplication1.RecepcionFisicaDocumentos
{
    public partial class ConsultasRecepcionFisica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonLibrary common = null;
                string result = string.Empty;
                try
                {
                    common = new CommonLibrary();
                    string dependencia = Request.QueryString["dep"];
                    if (dependencia != null)
                    {
                        Session["Dependencia"] = dependencia;
                    }
                    else
                    {
                        Session["Dependencia"] = "900.12";
                    }

                    if (Session["DatabaseEngine"] == null)
                    {
                        ConfigData db = common.GetConfigurationInformation();
                        Session["DatabaseEngine"] = db;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblTotalConsulta.Text = string.Empty;
            string fechaInicial = txtFechaInicial.Text + " 00:01:00";
            string fechaFinal = txtFechaFinal.Text + " 23:59:00";
            DocumentosFisicosClient client = null;
            List<ObjDocumentos> receivedDocuments = null;
            string resultado = string.Empty;
            CommonLibrary common = null;
            try
            {
                client = new DocumentosFisicosClient();
                receivedDocuments = new List<ObjDocumentos>();
                common = new CommonLibrary();
                receivedDocuments = client.GetReceivedDocuments(out resultado, fechaInicial, fechaFinal, Session["Dependencia"].ToString(), (ConfigData)Session["DatabaseEngine"]).ToList();

                if (receivedDocuments.Count > 0)
                {
                    string aux = string.Empty;
                    bool resultSave = common.SaveObjectInCache("ResultadoBusquedaRecibidos" + Session["Dependencia"].ToString(), receivedDocuments, out aux);
                }
                lblTotalConsulta.Text = "Total: " + receivedDocuments.Count;
                lblMessage.Text = resultado;
                lstv_resultados.DataSource = receivedDocuments;
                lstv_resultados.DataBind();
            }
            catch (Exception)
            {                
                throw;
            }
        }

        protected void lstv_resultados_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            dprResumen.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            DocumentosFisicosClient oCon = new DocumentosFisicosClient();
            List<ObjDocumentos> receivedDocuments = new List<ObjDocumentos>();
            receivedDocuments = GetDocumentsFromCache();
            lblTotalConsulta.Text = "Total: " + receivedDocuments.Count;
            lstv_resultados.DataSource = receivedDocuments;
            lstv_resultados.DataBind();
        }

        private List<ObjDocumentos> GetDocumentsFromCache()
        {
            List<ObjDocumentos> list = null;
            CommonLibrary common = null;
            string aux = string.Empty;
            try
            {
                common = new CommonLibrary();
                list = new List<ObjDocumentos>();
                list = common.FindObjectInCache("ResultadoBusquedaRecibidos" + Session["Dependencia"].ToString(), out aux);
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}