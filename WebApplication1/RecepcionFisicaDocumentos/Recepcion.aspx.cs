using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Alfanet.CommonLibrary;
using Alfanet.CommonObject;
using WebApplication1.RadicacionMasivaService;
using WebApplication1.DocumentosFisicosService;

namespace WebApplication1.RecepcionFisicaDocumentos
{
    public partial class Recepcion : System.Web.UI.Page
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
                    RadicacionMasivaClient client = new RadicacionMasivaClient();
                    List<ObjParametros> parametros = new List<ObjParametros>();
                    string userId = null;
                    string NombDep = null;
                    userId = client.ObtenerDatosDependencia(out NombDep, Session["Dependencia"].ToString(), (ConfigData)Session["DatabaseEngine"]);
                    Session["UserId"] = userId;
                    Session["NombreUser"] = NombDep;
                    DocumentosFisicosClient oCon = new DocumentosFisicosClient();
                    List<ObjDocumentos> pendingDocuments = new List<ObjDocumentos>();
                    pendingDocuments = oCon.GetPendingDocuments((ConfigData)Session["DatabaseEngine"], Session["Dependencia"].ToString()).ToList();
                    lstv_resumen.DataSource = pendingDocuments;
                    lstv_resumen.DataBind();
                    lstv_resumen.Visible = true;
                    lblTotalResumen.Text = "Total: " + pendingDocuments.Count;
                    if (pendingDocuments.Count == 0)
                    {
                        btnDescargar.Enabled = false;
                    }
                }
                catch (Exception)
                {
                    throw;
                }                
            }
        }
        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            DocumentosFisicosClient oCon = null;
            List<ObjDocumentos> resultList = null;
            CommonLibrary common = null;
            try
            {
                oCon = new DocumentosFisicosClient();
                resultList = new List<ObjDocumentos>();
                ObjDocumentos result = null;
                foreach (ListViewDataItem item in lstv_resumen.Items)
                {
                    System.Web.UI.WebControls.CheckBox validationCheck = (System.Web.UI.WebControls.CheckBox)item.FindControl("cbxDocumento");
                    if (validationCheck.Checked == true)
                    {
                        string numeroDocumento = ((System.Web.UI.HtmlControls.HtmlContainerControl)(item.Controls[1])).InnerText.ToString();
                        string grupoCodigo = ((System.Web.UI.HtmlControls.HtmlContainerControl)(item.Controls[5])).InnerText.ToString();

                        bool success = oCon.DocumentAccepted((ConfigData)Session["DatabaseEngine"], numeroDocumento, grupoCodigo);
                        if (success)
                        {
                            result = new ObjDocumentos();
                            result.NumeroDocumento = numeroDocumento;
                            result.ProcedenciaNombre = ((System.Web.UI.HtmlControls.HtmlContainerControl)(item.Controls[3])).InnerText.ToString();
                            result.GrupoCodigo = grupoCodigo;
                            result.WfmovimientoFecha = ((System.Web.UI.HtmlControls.HtmlContainerControl)(item.Controls[7])).InnerText.ToString();
                            result.DependenciaNombre = ((System.Web.UI.HtmlControls.HtmlContainerControl)(item.Controls[9])).InnerText.ToString();
                            //OJO, ESTO NO ES NINGUNA FECHA DE VENCIMIENTO, SE ESTA USANDO EL CAMPO FECHA VENCIMIENTO DEL OBJETO
                            //PARA ALMACENAR LA FECHA DE RECIBIDO.
                            result.FechaVencimiento = DateTime.Now.ToString();
                            resultList.Add(result);
                            //Label1.Text = Label1.Text + "\n" + numeroDocumento;
                        }
                    }
                }
                common = new CommonLibrary();
                string aux = string.Empty;
                bool resultSave = common.SaveObjectInCache("ResultadoDocuments" + Session["Dependencia"].ToString(), resultList, out aux);

                lblCantidadDescargados.Text = "Total: " + resultList.Count;
                lstvDescargados.DataSource = resultList;
                lstvDescargados.DataBind();

                List<ObjDocumentos> pendingDocuments = new List<ObjDocumentos>();
                pendingDocuments = oCon.GetPendingDocuments((ConfigData)Session["DatabaseEngine"], Session["Dependencia"].ToString()).ToList();
                lstv_resumen.DataSource = pendingDocuments;
                lstv_resumen.DataBind();
                lstv_resumen.Visible = true;
                if (pendingDocuments.Count == 0)
                {
                    btnDescargar.Enabled = false;
                }
                lblTotalResumen.Text = "Total: " + pendingDocuments.Count;
                string script = @"<script type='text/javascript'>
                            DisplayDialog();
                        </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
            catch (Exception)
            {                
                throw;
            }
        }
        protected void lstv_resumen_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            dprResumen.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            DocumentosFisicosClient oCon = new DocumentosFisicosClient();
            List<ObjDocumentos> pendingDocuments = new List<ObjDocumentos>();
            pendingDocuments = oCon.GetPendingDocuments((ConfigData)Session["DatabaseEngine"], Session["Dependencia"].ToString()).ToList();
            lblTotalResumen.Text = "Total: " + pendingDocuments.Count;
            lstv_resumen.DataSource = pendingDocuments;
            lstv_resumen.DataBind();
        }
        protected void lstvDescargados_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            dprDescargados.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            lstv_resumen.DataSource = LoadFromCache();
            lstv_resumen.DataBind();
        }

        private List<ObjDocumentos> LoadFromCache()
        {
            //
            List<ObjDocumentos> list = null;
            CommonLibrary common = null;
            string aux = string.Empty;
            try
            {
                common = new CommonLibrary();
                list = new List<ObjDocumentos>();
                list = common.FindObjectInCache("ResultadoDocuments" + Session["Dependencia"].ToString(), out aux);
                return list;
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}