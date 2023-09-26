using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Alfanet.CommonObject;
using Alfanet.CommonLibrary;
using System.Globalization;
using System.IO;
using WebApplication1.RadicacionMasivaService;
using WebApplication1.ErrorService;



namespace WebApplication1.RadicacionRegistroMasivo
{
    public partial class RadicacionRegistroMasivo : System.Web.UI.Page
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
                        Session["Dependencia"] = "322.3.5";
                    }
                    if (Session["DatabaseEngine"] == null)
                    {
                        ConfigData db = common.GetConfigurationInformation();
                        Session["DatabaseEngine"] = db;
                    }
                    if (common.FindAnyObjInCache("Procedencias", out result) == false)
                    {
                        //CargarProcedencias();
                    }
                    if (common.FindAnyObjInCache("Ciudades", out result) == false)
                    {
                        CargarCiudades();
                    }
                    if (!common.FindAnyObjInCache("Dependencias", out result))
                    {
                        cargarDependencias();
                    }

                    var client = new RadicacionMasivaClient();
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
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        protected void btnRadicados_Click(object sender, EventArgs e)
        {   
            List<Button> buttons = new List<Button>();
            Session["TDocumento"] = "0";
            fuFileToImport.Enabled = true;
            btnVistaPrevia.Enabled = true;
            hlRadicadoTemplate.Visible = false;
            hlRegistroTemplate.Visible = false;
            divInicial.Visible = false;
         
        }

        protected void btnRegistros_Click(object sender, EventArgs e)
        {   
            List<Button> buttons = new List<Button>();
            Session["TDocumento"] = "1";
            fuFileToImport.Enabled = true;
            btnVistaPrevia.Enabled = true;
            hlRadicadoTemplate.Visible = false;
            hlRegistroTemplate.Visible = false;
            divInicial.Visible = false;
         
        }

        protected void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            
            if (((string)Session["TDocumento"])=="0")
            {
                vistaPreviaRadicados();
            }
            else
            {
                vistaPreviaRegistros();
            }

        }

        private void vistaPreviaRadicados() 
        {
 
            btnValidateImages.Enabled = true;
            lblSummary.Text = string.Empty;
            lblMessage.Text = string.Empty;
            lblMessage0.Text = string.Empty;
            lblMessage1.Text = string.Empty;           
            RadicacionMasivaClient client = null;
            //btnVistaPrevia.Enabled = false;
            correrValidaciones();
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
                            List<ObjDocumentos> data = new List<ObjDocumentos>();
                            data = client.GetPreviewRadicados(out result, out objCacheName, out summary, out CamposVacios, out DuplicadosDB, txtDependenciaDestino.Text, txtNaturalezas.Text, txtMedio.Text, (string)Session["Dependencia"], (ConfigData)Session["DatabaseEngine"], file, fuFileToImport.FileName).ToList();
                            if (data.Count != 0)
                            {
                                Session["ObjCacheName"] = objCacheName;
                                lblSummary.Text = summary == "La(s) Procedencia(s)  No Existe(n) en Alfanet " ? "" : summary;
                                lblMessage0.Text = CamposVacios;
                                lblMessage1.Text = DuplicadosDB;
                                div_paso2.Visible = summary == "La(s) Procedencia(s)  No Existe(n) en Alfanet " & CamposVacios == "" & DuplicadosDB == "" ? true : false;
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
                                if (objCacheName.Contains("RadicacionMasivaTable_") == true)
                                {
                                    if (DuplicadosDB != "")
                                    {
                                        lblMessage.Text = "";
                                        lblMessage1.Text = DuplicadosDB;
                                        lstvVista.DataSource = data;
                                        lstvVista.DataBind();
                                        pre_view.Visible = true;
                                        btnVistaPrevia.Enabled = true;
                                        if (summary != "La(s) Procedencia(s)  No Existe(n) en Alfanet ")
                                        {
                                            lblSummary.Text = summary;
                                        }
                                    }
                                    else if (summary != "La(s) Procedencia(s) No Existe(n) en Alfanet")
                                    {
                                        lblMessage.Text = "";
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
                throw;
            }
        }
        private void vistaPreviaRegistros()
        {
            btnValidateImages.Enabled = true;
            lblSummary.Text = string.Empty;
            lblMessage.Text = string.Empty;
            lblMessage0.Text = string.Empty;
            lblMessage1.Text = string.Empty;
            RadicacionMasivaClient client = null;            
            correrValidaciones();
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
                            List<ObjDocumentos> data = new List<ObjDocumentos>();
                            data = client.GetPreviewRegistros(out result, out objCacheName, out summary, out CamposVacios, out DuplicadosDB, txtDependenciaDestino.Text, txtNaturalezas.Text, txtMedio.Text, (string)Session["Dependencia"], (ConfigData)Session["DatabaseEngine"], file, fuFileToImport.FileName).ToList();
                            if (data.Count != 0)
                            {
                                Session["ObjCacheName"] = objCacheName;
                                lblSummary.Text = summary == "La(s) Procedencia(s)  No Existe(n) en Alfanet " ? "" : summary;
                                lblMessage0.Text = CamposVacios;
                                lblMessage1.Text = DuplicadosDB;
                                div_paso2.Visible = summary == "La(s) Procedencia(s)  No Existe(n) en Alfanet " & CamposVacios == "" & DuplicadosDB == "" ? true : false;
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
                                    lsvRegistroMasivo.DataSource = data;
                                    lsvRegistroMasivo.DataBind();
                                    lblSummary.Text = summary == "La(s) Procedencia(s)  No Existe(n) en Alfanet " ? "" : summary;
                                    pre_view.Visible = true;
                                    btnVistaPrevia.Enabled = true;
                                }
                            }
                            else
                            {
                                if (objCacheName.Contains("RadicacionMasivaTable_") == true)
                                {
                                    if (DuplicadosDB != "")
                                    {
                                        lblMessage.Text = "";
                                        lblMessage1.Text = DuplicadosDB;
                                        lstvVista.DataSource = data;
                                        lstvVista.DataBind();
                                        pre_view.Visible = true;
                                        btnVistaPrevia.Enabled = true;
                                        if (summary != "La(s) Procedencia(s)  No Existe(n) en Alfanet ")
                                        {
                                            lblSummary.Text = summary;
                                        }
                                    }
                                    else if (summary != "La(s) Procedencia(s) No Existe(n) en Alfanet")
                                    {
                                        lblMessage.Text = "";
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

                throw;
            }
            
        }


        private void correrValidaciones() 
        {
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
            catch (Exception ex)
            {
                throw;
            }
        }
        private void CargarProcedencias()
        {
            RadicacionMasivaClient client = null;
            List<ObjProcedencia> procedenciaList = null;
            CommonLibrary common = null;
            try
            {
                common = new CommonLibrary();
                client = new RadicacionMasivaClient();
                procedenciaList = new List<ObjProcedencia>();
                ConfigData config = new ConfigData();
                config = (ConfigData)Session["DatabaseEngine"];
                procedenciaList = client.GetProcedencias(config).ToList();
                if (procedenciaList != null)
                {
                    string resultSave = string.Empty;
                    common.SaveObjectInCache("Procedencias", procedenciaList, out resultSave);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void CargarCiudades()
        {
            RadicacionMasivaClient client = null;
            List<ObjCiudad> ciudadList = null;
            CommonLibrary common = null;
            try
            {
                common = new CommonLibrary();
                client = new RadicacionMasivaClient();
                ciudadList = new List<ObjCiudad>();
                ConfigData config = new ConfigData();
                config = (ConfigData)Session["DatabaseEngine"];
                ciudadList = client.GetCiudades(config).ToList();
                if (ciudadList != null)
                {
                    string resultSave = string.Empty;
                    common.SaveObjectInCache("Ciudades", ciudadList, out resultSave);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void btnRadicar_Click(object sender, EventArgs e)
        {
            bool cambio = false;
            cambio = true;
            CommonLibrary common = null;
            btnRadicar.Enabled = false;
            div_paso2.Visible = false;
            string objCacheName = (string)Session["ObjCacheName"];
            List<ObjDocumentos> summary = null;
            RadicacionMasivaClient client = null;
            string result = string.Empty;
            if (Session["TDocumento"].ToString() == "0")
            {
                try
                {
                    common = new CommonLibrary();
                    summary = new List<ObjDocumentos>();
                    string culture = CultureInfo.CurrentCulture.Name;
                    client = new RadicacionMasivaClient();                   
                    summary = client.RadicarDocumentos(out result, Session["UserId"].ToString(), Session["NombreUser"].ToString(), Session["Dependencia"].ToString(), objCacheName, Session["tempPath"].ToString(), (ConfigData)Session["DatabaseEngine"]).ToList();
                    string salida;
                    common.SaveObjectInCache("ObjectResult", summary,out salida);
                    lblMessage.Text = result;
                    lstv_resumen.DataSource = summary;
                    resumen.Visible = true;
                    lstv_resumen.DataBind();
                    pre_view.Visible = false;
                    lstvVista.Dispose();
                }
                catch (Exception ex)
                {
                    ErrorClient error = new ErrorClient();
                    ObjError ext = new ObjError();
                    ext.MessegeError = ex.Message;
                    error.SaveLogError(ext, (ConfigData)Session["DatabaseEngine"]);
                    lblMessage.Text = "Ocurrió un error al realizar el proceso de radicación masiva.";
                    btnRadicar.Enabled = true;
                }                
            }
            else
            {
                try
                {
                   
                    
                    summary = new List<ObjDocumentos>();
                    string culture = CultureInfo.CurrentCulture.Name;
                    client = new RadicacionMasivaClient();
                    summary = client.RegistrarDocumentos(out result, Session["UserId"].ToString(), Session["NombreUser"].ToString(), Session["Dependencia"].ToString(), objCacheName, Session["tempPath"].ToString(), (ConfigData)Session["DatabaseEngine"]).ToList();
                    string salida;
                    common = new CommonLibrary();
                    common.SaveObjectInCache("ObjectResult", summary, out salida);
                    lblMessage.Text = result;
                    lstv_resumen.DataSource = summary;
                    resumen.Visible = true;
                    lstv_resumen.DataBind();
                    pre_view.Visible = false;
                    lstvVista.Dispose();
                }
                catch (Exception ex)
                {
                    ErrorClient error = new ErrorClient();
                    ObjError ext = new ObjError();
                    ext.MessegeError = ex.Message;
                    error.SaveLogError(ext, (ConfigData)Session["DatabaseEngine"]);
                    lblMessage.Text = "Ocurrió un error al realizar el proceso de radicación masiva.";
                    lblMessage.Text = "Ocurrió un error al realizar el proceso de registro masiva.";
                    btnRadicar.Enabled = true;
                } 
                
            }

           
            

        }

        protected void btnValidateImages_Click(object sender, EventArgs e)
        {

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
                summary = client.ValidateFilesRadicados(out result, path, Session["ObjCacheName"].ToString()).ToList();
                if (summary.Count > 0)
                {
                    string summaryText = "Los siguientes archivos no tienen un registro asociado en el archivo excel:<br/>";
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
                    lblMessage.Text = "Validación correcta. " + result;
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

       

        

               
    }
}