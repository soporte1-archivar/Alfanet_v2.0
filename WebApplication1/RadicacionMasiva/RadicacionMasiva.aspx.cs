using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.RadicacionMasivaService;
using Alfanet.CommonObject;
using Alfanet.CommonLibrary;
using System.Globalization;
using System.Security.Permissions;
using System.Threading;
using System.IO;
using System.Collections;
using System.Xml;
using System.ServiceModel;
using System.Web.Services.Description;

namespace WebApplication1.RadicacionMasiva
{

    public partial class RadicacionMasiva : System.Web.UI.Page
    {

        private static readonly log4net.ILog log
       = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                CommonLibrary common = null;
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
                        Session["Dependencia"] = "mu001";
                    }

                    if (Session["DatabaseEngine"] == null)
                    {
                        //common = new CommonLibrary();
                        ConfigData db = common.GetConfigurationInformation();
                        Session["DatabaseEngine"] = db;
                    }

                    RadicacionMasivaClient client = new RadicacionMasivaClient();

                    if (client.ValidarUsuarioPermitido(Session["Dependencia"].ToString(), (ConfigData)Session["DatabaseEngine"]))
                    {
                        
                        List<ObjParametros> parametros = new List<ObjParametros>();
                        string userId = null;
                        string NombDep = null;

                        userId = client.ObtenerDatosDependencia(out NombDep, Session["Dependencia"].ToString(), (ConfigData)Session["DatabaseEngine"]);

                        Session["UserId"] = userId;
                        Session["NombreUser"] = NombDep;
                        parametros = client.GetParametrosIniciales("4", (ConfigData)Session["DatabaseEngine"]).ToList();
                        txtNaturalezas.Text = parametros[0].Naturaleza;
                        txtDependenciaDestino.Text = parametros[0].Serie;
                        txtMedio.Text = parametros[0].Medio;
                        txtAccion.Text = parametros[0].Accion;
                        txtExpediente.Text = parametros[0].Expediente;

                        //string resultFind = null;
                        //if (!common.FindAnyObjInCache("Naturalezas", out resultFind))
                        //{
                        //    //CargarNaturalezas();
                        //}
                        //if (!common.FindAnyObjInCache("Dependencias", out resultFind))
                        //{
                        //    //cargarDependencias();
                        //}
                        //if (!common.FindAnyObjInCache("Acciones", out resultFind))
                        //{
                        //    //CargarAcciones();
                        //}
                        //if (!common.FindAnyObjInCache("Medios", out resultFind))
                        //{
                        //    //CargarMedios();
                        //}
                        //if (!common.FindAnyObjInCache("Expedientes", out resultFind))
                        //{
                        //    //CargarExpedientes();
                        //}                        
                    }
                    else
                    {
                        lblMessage.Text = "Usted no tiene permisos para hacer radicacion masiva conctacte con su administrador " + Session["Dependencia"].ToString();
                        btnRadicar.Enabled = false;
                        btnVistaPrevia.Enabled = false;
                        fuFileToImport.Enabled = false;
                    }

                  
                }
                catch (Exception ex)
                {
                     throw;
                }
            }
        } 
        /// <summary>
        /// Carga las naturalezas de la base de datos y las almacena en cache.
        /// </summary>
        private void CargarNaturalezas()
        {
            RadicacionMasivaClient client = null;
            List<ObjNaturaleza> naturalezas = null;
            CommonLibrary common = null;
            try
            {
                common = new CommonLibrary();
                client = new RadicacionMasivaClient();
                naturalezas = new List<ObjNaturaleza>();
                ConfigData config = new ConfigData();
                config = (ConfigData)Session["DatabaseEngine"];
                naturalezas = client.GetNaturalezas(config).ToList();
                string resultSave = null;
                common.SaveObjectInCache("Naturalezas", naturalezas, out resultSave);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Carga las dependencias de la base de datos y las guarda en cache
        /// </summary>
        private void cargarDependencias()
        {
            RadicacionMasivaClient client = null;
            List<ObjDependencia> dependencias = null;
            CommonLibrary common = null;
            try
            {
                common = new CommonLibrary();
                client = new RadicacionMasivaClient();
                dependencias = new List<ObjDependencia>();
                ConfigData config = new ConfigData();
                config = (ConfigData)Session["DatabaseEngine"];
                dependencias = client.GetDependencias(config).ToList();
                string resultSave = null;
                common.SaveObjectInCache("Dependencias", dependencias, out resultSave);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Car las acciones de la base de datos y las almacena en cache.
        /// </summary>
        private void CargarAcciones()
        {
            RadicacionMasivaClient client = null;
            List<ObjAccion> acciones = null;
            CommonLibrary common = null;
            try
            {
                common = new CommonLibrary();
                client = new RadicacionMasivaClient();
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
        /// Carga los medios de la base de datos y los almacena en cache.
        /// </summary>
        private void CargarMedios()
        {
            RadicacionMasivaClient client = null;
            List<ObjMedio> medios = null;
            CommonLibrary common = null;
            try
            {
                common = new CommonLibrary();
                client = new RadicacionMasivaClient();
                medios = new List<ObjMedio>();
                ConfigData config = new ConfigData();
                config = (ConfigData)Session["DatabaseEngine"];
                medios = client.GetMedios(config).ToList();
                string resultSave = null;
                common.SaveObjectInCache("Medios", medios, out resultSave);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Carga los expedientes de la bd y los almacena en cache.
        /// </summary>
        private void CargarExpedientes()
        {
            RadicacionMasivaClient client = null;
            List<ObjExpediente> expedientes = null;
            CommonLibrary common = null;
            try
            {
                common = new CommonLibrary();
                client = new RadicacionMasivaClient();
                expedientes = new List<ObjExpediente>();
                ConfigData config = new ConfigData();
                config = (ConfigData)Session["DatabaseEngine"];
                expedientes = client.GetExpedientes(config).ToList();
                string resultSave = null;
                common.SaveObjectInCache("Expedientes", expedientes, out resultSave);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            

            lblSummary.Text = string.Empty;
            lblMessage.Text = string.Empty;
            lblMessage0.Text = string.Empty;
            lblMessage1.Text = string.Empty;
            //btnVistaPrevia.Enabled = false;
            RadicacionMasivaClient client = null;
            btnVistaPrevia.Enabled = false;
            if (pre_view.Visible == true)
            {
                pre_view.Visible = false;
                lstvVista.Dispose();
            }
            if (div_paso2.Visible == true)
            {
                div_paso2.Visible = false;
            }
            if (btnRadicar.Enabled == true)
            {
                btnRadicar.Enabled = false;
            }
            if (resumen.Visible == true)
            {
                resumen.Visible = false;
            }
                     
            string summary = null;
            try
            {
                if (fuFileToImport.HasFile)
                {
                    bool space = fuFileToImport.FileName.Contains(" ");
                    if (!space)
                    {
                        if (fuFileToImport.FileName.EndsWith(".xls") || fuFileToImport.FileName.EndsWith(".xlsx") || fuFileToImport.FileName.EndsWith(".csv"))
                        {
                            byte[] file = fuFileToImport.FileBytes;
                            client = new RadicacionMasivaClient();
                            string[] result = null;
                            string objCacheName = null;
                            string CamposVacios = null;
                            string DuplicadosDB = null;
                            string DuplicadosExcel = null;
                            List<ObjFactura> data = new List<ObjFactura>();
                            data = client.GetPreview(out result, out objCacheName, out summary, out CamposVacios, out DuplicadosDB, out DuplicadosExcel, txtDependenciaDestino.Text, txtNaturalezas.Text, txtMedio.Text, (string)Session["Dependencia"], (ConfigData)Session["DatabaseEngine"], file, fuFileToImport.FileName).ToList();

                            
                            if (data.Count != 0)
                            {                                
                                Session["ObjCacheName"] = objCacheName;
                                lblSummary.Text = summary == "La(s) Procedencia(s)  No Existe(n) en Alfanet " ? "" : summary;
                                lblMessage0.Text = CamposVacios;
                                lblMessage1.Text = DuplicadosDB;
                                div_paso2.Visible = summary == "La(s) Procedencia(s)  No Existe(n) en Alfanet " & CamposVacios == "" & DuplicadosDB == "" & DuplicadosExcel == "" ? true : false;
                                //div_paso2.Visible = true;
                                if (result.Count() > 0)
                                {
                                    lblMessage.Text = lblMessage.Text + " " + result[0] + "\n";
                                    btnVistaPrevia.Enabled = true;
                                }
                                else
                                {
                                    lblMessage.Text = "Vista previa generada correctamente.";
                                    lblTotal.Text = "Total: " + data.Count.ToString();
                                    lstvVista.DataSource = data;
                                    lstvVista.DataBind();
                                    lblSummary.Text = summary == "La(s) Procedencia(s)  No Existe(n) en Alfanet " ? "" : summary;
                                    pre_view.Visible = true;
                                    btnVistaPrevia.Enabled = true;
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(DuplicadosExcel))
                                {
                                    lblMessage.Text = string.Empty;
                                    lblMessage1.Text = DuplicadosExcel;
                                    lstvVista.DataSource = data;
                                    lstvVista.DataBind();
                                    pre_view.Visible = false;
                                    btnVistaPrevia.Enabled = true;
                                    lblMessage.Text = "<b>El proceso no puede continuar, por favor asegúrese que no haya facturas repetidas. Las siguientes facturas presentan más de un registro:</b>";                                    
                                }
                                else if (objCacheName.Contains("RadicacionMasivaTable_") == true)
                                {
                                    
                                    if (!string.IsNullOrWhiteSpace(DuplicadosDB))
                                    {
                                        lblMessage.Text = string.Empty;
                                        lblMessage1.Text = DuplicadosDB;
                                        lstvVista.DataSource = data;
                                        lstvVista.DataBind();
                                        pre_view.Visible = false;
                                        btnVistaPrevia.Enabled = false;
                                        if (summary != "La(s) Procedencia(s)  No Existe(n) en Alfanet ")
                                        {
                                            lblSummary.Text = summary;
                                        }
                                    }
                                    else if (summary != "La(s) Procedencia(s) No Existe(n) en Alfanet")
                                    {
                                        lblMessage.Text = string.Empty;
                                        lblSummary.Text = summary;
                                        lstvVista.DataSource = data;
                                        lstvVista.DataBind();
                                        pre_view.Visible = true;
                                        btnVistaPrevia.Enabled = true;
                                    }
                                    else
                                    {
                                        lblMessage.Text = "Los datos que intenta cargar ya han sido radicados.";
                                        btnVistaPrevia.Enabled = true;
                                    }
                                }
                                else
                                {
                                    lblMessage.Text = objCacheName;
                                    btnVistaPrevia.Enabled = true;
                                }
                            }
                        }
                        else
                        {
                            lblMessage.Text = "El formato del archivo seleccionado no es válido.<br/>Los tipos de archivo permitidos son .XLS, .XLSX, Y .CSV";
                            btnVistaPrevia.Enabled = true;
                        }
                        
                    }
                    else
                    {
                        lblMessage.Text = "El nombre del archivo no puede contener espacios";
                        btnVistaPrevia.Enabled = true;

                    }
                }
                else
                {
                    lblMessage.Text = "No ha seleccionado ningún archivo";
                    btnVistaPrevia.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "No es posible generar la vista previa en este momento.";                
                btnVistaPrevia.Enabled = true;
            }
        }

        protected void btnRadicar_Click(object sender, EventArgs e)
        {
            btnRadicar.Enabled = false;
            div_paso2.Visible = false;
            string objCacheName = (string)Session["ObjCacheName"];
            RadicacionMasivaClient client = null;
            string result = string.Empty;
            List<ObjFactura> summary = null;
            try
            {
                summary = new List<ObjFactura>();
                string culture = CultureInfo.CurrentCulture.Name; 
                client = new RadicacionMasivaClient();
                summary = client.RadicarFacturas(out result, Session["UserId"].ToString(), Session["NombreUser"].ToString(), Session["Dependencia"].ToString(), objCacheName, Session["tempPath"].ToString(), (ConfigData)Session["DatabaseEngine"]).ToList();
                lblMessage.Text = result;
                lstv_resumen.DataSource = summary;
                resumen.Visible = true;
                lstv_resumen.DataBind();
                pre_view.Visible = false;
                lstvVista.Dispose();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Ocurrió un error al realizar el proceso de radicación masiva.";
                btnRadicar.Enabled = true;
            }
        }
        protected void lstvVista_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            //set current page startindex, max rows and rebind to false
            dprPagerPreview.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            lstvVista.DataSource = LoadFromCache();
            lstvVista.DataBind();
        }

        private List<ObjFactura> LoadFromCache()
        {
            List<ObjFactura> facturasList = null;
            RadicacionMasivaClient client = null;
            try
            {
                client = new RadicacionMasivaClient();
                facturasList = new List<ObjFactura>();
                facturasList = client.LoadFromCache(Session["ObjCacheName"].ToString()).ToList();
                return facturasList;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        protected void lstv_resumen_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            var client = new RadicacionMasivaClient();
            dprResumen.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            lstv_resumen.DataSource = client.LoadFromCache("ResumenList");
            lstv_resumen.DataBind();
        }
        public BasicHttpBinding createBinding()
        {
            BasicHttpBinding Binding = new BasicHttpBinding();
            Binding.ReaderQuotas.MaxArrayLength = 2147483647;
            Binding.ReaderQuotas.MaxDepth = 32;
            Binding.ReaderQuotas.MaxBytesPerRead = 2147483647;
            Binding.ReaderQuotas.MaxNameTableCharCount = 2147483647;
            Binding.ReaderQuotas.MaxStringContentLength = 2147483647;
            Binding.CloseTimeout = new TimeSpan(00, 10, 00);
            Binding.OpenTimeout = new TimeSpan(00, 10, 00);
            Binding.MaxBufferPoolSize = 2147483647;
            Binding.MaxBufferSize = 2147483647;
            Binding.MaxReceivedMessageSize = 2147483647;
            Binding.TextEncoding = System.Text.Encoding.UTF8;
            Binding.TransferMode = TransferMode.Buffered;
            Binding.AllowCookies = false;
            Binding.UseDefaultWebProxy = true;                
            return Binding;
        }

        protected void btnValidateImages_Click(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
            btnValidateImages.Enabled = false;
            if (btnRadicar.Enabled == true)
            {
                btnRadicar.Enabled = false;
            }
            lblSummaryFiles.Text = string.Empty;
            lblMessage.Text = string.Empty;
            try
            {
                RadicacionMasivaClient client = null;
                string path = string.Empty;
                List<string> summary = null;
                string result = string.Empty;
                string dependencia = Session["Dependencia"].ToString().Replace('.', '_');
                path = System.Configuration.ConfigurationManager.AppSettings["path_images"] + dependencia + @"\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Session["tempPath"] = path;
                client = new RadicacionMasivaClient();
                summary = client.ValidateFiles(out result, path, Session["ObjCacheName"].ToString()).ToList();
                if (summary.Count > 0)
                {
                    string summaryText = "Los siguientes archivos no tienen un registro asociado en el reporte Oasis:<br/>";
                    foreach (string item in summary)
                    {
                        summaryText += item + "<br/>";
                    }
                    lblSummaryFiles.Text = summaryText;
                    lblMessage.Text = "No es posible continuar con el proceso, verifique las imágenes y realice el proceso de carga nuevamente";
                    btnValidateImages.Enabled = true;
                }
                else
                {
                    lblMessage.Text = "Validación correcta. "+result;
                    btnRadicar.Enabled = true;
                    btnValidateImages.Enabled = true;
                }
            }
            catch (Exception)
            {
                lblMessage.Text = "Ocurrió un error al validar las imágenes. Por favor intente nuevamente.";
                btnValidateImages.Enabled = true;
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultaRadicacionMasiva.aspx?dep=" + Session["Dependencia"].ToString());
        }
       
    }
}
