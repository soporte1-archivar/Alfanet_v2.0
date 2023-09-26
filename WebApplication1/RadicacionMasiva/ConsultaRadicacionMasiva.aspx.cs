using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Alfanet.CommonObject;
using Alfanet.CommonLibrary;
using WebApplication1.RadicacionMasiva;
//using WebApplication1.ErrorService;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using WebApplication1.RadicacionMasivaService;
using WebApplication1.ErrorService;

namespace WebApplication1.RadicacionMasiva
{
    public partial class ConsultaRadicacionMasiva : System.Web.UI.Page
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
                        Session["Dependencia"] = "mu001";
                    }


                    if (Session["DatabaseEngine"] == null)
                    {                        
                        ConfigData db = common.GetConfigurationInformation();
                        Session["DatabaseEngine"] = db;
                    }
                    if (common.FindAnyObjInCache("Procedencias", out result) == false)
                    {
                        CargarProcedencias();
                    } 
                    if (common.FindAnyObjInCache("Ciudades", out result) == false)
                    {
                        CargarCiudades();
                    }
                    if (!common.FindAnyObjInCache("Dependencias", out result))
                    {
                        cargarDependencias();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
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
            catch (Exception)
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
            catch (Exception)
            {
                throw;
            }
        }
        protected void cbxConsultarByRadicados_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxConsultarByRadicados.Checked == true)
            {
                div_consultaByRadicados.Visible = true;
            }
            else
            {
                div_consultaByRadicados.Visible = false;
                txtInicial.Text = string.Empty;
                txtFinal.Text = string.Empty;
            }
        }

        protected void cbxConsultarByFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxConsultarByFechas.Checked == true)
            {
                div_consultaByFechas.Visible = true;
            }
            else
            {
                div_consultaByFechas.Visible = false;
                txtFechaInicial.Text = string.Empty;
                txtFechaFinal.Text = string.Empty;
            }
        }
        protected void lstvData_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            
            dprPagerData.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);            
            lstvData.DataSource = LoadFromCache();
            lstvData.DataBind();
        }

        private List<ObjFactura> LoadFromCache()
        {
            CommonLibrary common = null;
            List<ObjFactura> objList = null;
            string result = string.Empty;
            try
            {
                common = new CommonLibrary();
                objList = new List<ObjFactura>();
                objList = common.FindFacturasInCache(Session["cacheName"].ToString(), out result);
                return objList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            btnExport.Visible = false;
            btnExport.Enabled = false;
            Div_Export.Visible = false;
            lblMessage.Text = string.Empty;
            lbxCompEgreso.Items.Clear();
            //lbxCompEgreso.Text = string.Empty;

            Int64 radInicial = 0;
            Int64 radFinal = 0;
            string egresoInicial = null;
            string egresoFinal = null;
            string fechaInicial = null;
            string fechaFinal = null;
            string remisionIni = null;
            string remisionFin = null;
            string FacturaIni = null;
            string FacturaFin = null;
            string valFacturaMin = null;
            string valFacturaMax = null;
            string nombre = null;
            string detalle = null;
            string ubicacion = null;
            string modalidad = null;
            string unidad = null;
            string expediente = null;
            string imagen = null;
            string radicador = null;
            string ciudadInicial = null;
            string ciudadFinal = null;
            
            if (cbxUnidad.Checked == true)
            {
                unidad = txtUnidad.Text.Trim();                
            }
            if (cbxExpediente.Checked == true)
            {
                expediente = txtExpediente.Text.Trim();
            }
            if (cbxDetalle.Checked == true)
            {
                detalle = txtDetalleConsulta.Text.Trim();
            }
            if (cbxUbicacion.Checked == true)
            {                
                string[] ubicacionCod = txtUbicacion.Text.Trim().Split('|');
                ubicacion = ubicacionCod[0].Trim();
            }
            if (cbxModalidad.Checked == true)
            {
                modalidad = txtModalidad.Text.Trim();
            }
            if (cbxNombreNit.Checked == true)
            {
                string []  nit = txtNombreoNit.Text.Trim().Split('|');
                nombre = nit[0].Trim();
            }
            if (cbxConsultarByRadicados.Checked == true)
	        {
		        radInicial = Convert.ToInt64 (txtInicial.Text.Trim());
                radFinal = Convert.ToInt64 (txtFinal.Text.Trim());
	        }

            if (cbxConsultarByFechas.Checked == true)
            {
                fechaInicial = txtFechaInicial.Text.Trim();
                fechaFinal = txtFechaFinal.Text.Trim();
            }
            if (cbxComprobanteEgreso.Checked == true)
            {
                egresoInicial = txtEgresoIni.Text.Trim();
                egresoFinal = txtEgresoFin.Text.Trim();
            }

            if (cbxRemision.Checked == true)
            {
                remisionIni = txtRemisionIni.Text.Trim();
                remisionFin = txtRemisionFinal.Text.Trim();
            }

            if (cbxNumeroFacutra.Checked == true)
            {
                
                FacturaIni = txtFacturaInicial.Text.Trim();
                FacturaFin = txtFacturaFianl.Text.Trim();
            }


            if (cbxValoresFactura.Checked == true)
            {
                valFacturaMin = txtValorFac1.Text.Trim();
                valFacturaMax = txtValorFac2.Text.Trim();
            }

            if (cbxPorImagen.Checked == true)
            {
                imagen = RblImagen.SelectedValue;
            }
            if (cbxRadicadorCod.Checked == true)
            {
                string[] RadicadorCod = txtRadicador.Text.Trim().Split('|');
                radicador = RadicadorCod[0].Trim();
            }
            if (cbxRegional.Checked == true)
            {
                Int64 aux1 = 0;

                ciudadInicial = txtCodCiudadInicial.Text.Trim();
                ciudadFinal = txtCodCiudadFinal.Text.Trim();
                if (Convert.ToInt64(ciudadInicial) > Convert.ToInt64(ciudadFinal))
                {
                    aux1 = Convert.ToInt64(ciudadFinal);
                    ciudadFinal = ciudadInicial;
                    ciudadInicial = aux1.ToString();
                }
            }
            CommonLibrary common = null;
            RadicacionMasivaClient client = null;
            try
            {
                client = new RadicacionMasivaClient();
                common = new CommonLibrary();
                List<ObjFactura> data = client.BuscarRadicados(radicador,imagen, radInicial, radFinal, egresoInicial, egresoFinal, fechaInicial, fechaFinal, remisionIni, remisionFin, valFacturaMin, valFacturaMax, FacturaIni, FacturaFin, nombre, detalle, ubicacion, modalidad, unidad, expediente, ciudadInicial, ciudadFinal, (ConfigData)Session["DatabaseEngine"]).ToList();
                string cacheName = "resultadoBusqueda_"+Session["Dependencia"].ToString();
                string salida = string.Empty;
                common.SaveObjectInCache(cacheName, data, out salida);
                Session["cacheName"] = cacheName;
                lblTotal.Text = "Total: "+data.Count+"<br />";
                lstvData.DataSource = data;
                lstvData.DataBind();
                btnBuscar.Enabled = true;

                btnExport.Visible = true;
                btnExport.Enabled = true;
                Div_Export.Visible = true;
            }
            catch (Exception)
            {
                lblMessage.Text = "Ocurrió un error al realizar la consulta.";
                btnBuscar.Enabled = true;
            }
        }

        protected void cbxRemision_CheckedChanged(object sender, EventArgs e)
        {
            
            if (cbxRemision.Checked == true)
            {
                div_consultaByRemision.Visible = true;
            }
            else
            {
                div_consultaByRemision.Visible = false;
                txtRemisionIni.Text = string.Empty;
                txtRemisionFinal.Text = string.Empty;
            }

        }

        protected void cbxNumeroFacutra_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxNumeroFacutra.Checked == true)
            {
                div_consultaByNumeroFactura.Visible = true;
            }
            else
            {       
                div_consultaByNumeroFactura.Visible = false;
                txtFacturaInicial.Text = string.Empty;
                txtFacturaFianl.Text = string.Empty;
            }


        }

        protected void cbxValoresFactura_CheckedChanged(object sender, EventArgs e)
        {
            
            if (cbxValoresFactura.Checked == true)
            {
                div_consultaByValoresFactura.Visible = true;
            }
            else
            {                
                div_consultaByValoresFactura.Visible = false;
                txtValorFac1.Text = string.Empty;
                txtValorFac2.Text = string.Empty;
            }
        }

        protected void cbxNombreNit_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxNombreNit.Checked == true)
            {
                div_consultaByNombreoNit.Visible = true;
            }
            else
            {
                div_consultaByNombreoNit.Visible = false;
                txtNombreoNit.Text = string.Empty;                
            }
        }

        protected void cbxUbicacion_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxUbicacion.Checked == true)
            {
                div_consultaByUbicacion.Visible = true;
            }
            else
            {                
                div_consultaByUbicacion.Visible = false;
                txtUbicacion.Text = string.Empty;
            }
        }

        protected void cbxDetalle_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDetalle.Checked == true)
            {
                div_consultaByDetalle.Visible = true;
            }
            else
            {                
                div_consultaByDetalle.Visible = false;
                txtDetalleConsulta.Text = string.Empty;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string codigo = txtRadicadoCodigo.Text.Trim();
            string detalle = txtDetalle.Text.Trim();
            List<string> compEgresoList = null;
            RadicacionMasivaClient client = null;
            try
            {                         
                compEgresoList = new List<string>();                
                foreach (System.Web.UI.WebControls.ListItem item in lbxCompEgreso.Items)
                {
                    string tempItem = item.Value.ToString();
                    compEgresoList.Add(tempItem);
                }
                client = new RadicacionMasivaClient();
                string actualizo = client.UpdateRadicado(codigo, detalle, compEgresoList.ToArray(), (ConfigData)Session["DatabaseEngine"]);
                lbxCompEgreso.Items.Clear();
                //lbxCompEgreso.Text = string.Empty;
                lblMessage.Text = actualizo;
            }
            catch (Exception)
            {
                lblMessage.Text = "Ocurrió un problema al realizar el proceso de actualización. Por favor intente mas tarde nuevamente.";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RadicacionMasiva.aspx?dep=" + Session["Dependencia"].ToString());
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtCompEgreso.Text.Trim() != "")
                {
                    System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem();
                    item.Value = txtCompEgreso.Text.Trim();
                    lbxCompEgreso.Items.Add(item);
                }
                txtCompEgreso.Text = string.Empty;
            }
            catch
            {
                
            }
        }

        protected void cbxModalidad_CheckedChanged(object sender, EventArgs e)
        {            
            if (cbxModalidad.Checked == true)
            {
                div_consultaByModalidad.Visible = true;
            }
            else
            {
                div_consultaByModalidad.Visible = false;
                txtModalidad.Text = string.Empty;
            }
        }

        protected void cbxUnidad_CheckedChanged(object sender, EventArgs e)
        {            
            if (cbxUnidad.Checked == true)
            {
                div_consultaByUnidad.Visible = true;
            }
            else
            {
                div_consultaByUnidad.Visible = false;
                txtUnidad.Text = string.Empty;
            }
        }

        protected void cbxExpediente_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxExpediente.Checked == true)
            {
                div_consultaByExpediente.Visible = true;
            }
            else
            {
                div_consultaByExpediente.Visible = false;
                txtExpediente.Text = string.Empty;
            }
        }

        protected void cbxComprobanteEgreso_CheckedChanged(object sender, EventArgs e)
        {            
            if (cbxComprobanteEgreso.Checked == true)
            {
                div_consultaByComprobanteEgreso.Visible = true;
            }
            else
            {
                div_consultaByComprobanteEgreso.Visible = false;
                txtEgresoIni.Text = string.Empty;
                txtEgresoFin.Text = string.Empty;
            }

        }
        

        protected void btnExport_Click(object sender, EventArgs e)
        {
            btnExport.Enabled = false;
            RadicacionMasivaClient client = null;
            DataTable data = null;
            List<ObjFactura> dataList = null;
            CommonLibrary common = null;
            string result = string.Empty;
            try
            {
                common = new CommonLibrary();
                client = new RadicacionMasivaClient();
                dataList = common.FindFacturasInCache(Session["cacheName"].ToString(), out result);//client.GetResultadosBusqueda(Session["cacheName"].ToString()).ToList();
                data = new DataTable();
                System.IO.StringWriter tw = new System.IO.StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(tw);
                data = common.ListToDataTable(dataList);
                
                if (rdbExpExcel.Checked == true)
                {
                    //EXPORTAR A EXCEL.
                    string filename = "Informe_Facturas" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Hour + ".xls";
                    
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = data;
                    dgGrid.DataBind();

                    //Get the HTML for the control.
                    dgGrid.RenderControl(hw);
                    Response.Clear();
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.Flush();
                    Response.Close();
                    btnExport.Enabled = true;
                }
                else if (rdbExpPdf.Checked == true)
                {
                    //EXPORTAR A PDF.                    
                    Document doc = new Document(PageSize.LETTER.Rotate(), 10, 10, 20, 20);
                    string path = System.Configuration.ConfigurationManager.AppSettings["repositorioExport"].ToString();                 
                    string target = path + "InformeFacturas.pdf";
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(target, FileMode.Create));                  
                    doc.Open();                    
                    Font fuente =  FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, iTextSharp.text.Font.NORMAL);
                    Paragraph titulo = new Paragraph("                                   INFORME FACTURAS", fuente);
                    Paragraph espacio = new Paragraph(" ", fuente);
                    doc.Add(titulo);
                    doc.Add(espacio);
                    PdfContentByte cb = writer.DirectContent;
                    ColumnText ct = new ColumnText(cb);
                    //ct.SetSimpleColumn(titulo, doc.Left, 0, doc.Right, doc.Top, 24, Element.ALIGN_JUSTIFIED);
                    //ct.Go();                    
                    PdfPTable table = new PdfPTable(8);                    
                    PdfPCell celda1 = new PdfPCell(new Phrase("RADICADO", fuente));
                    PdfPCell celda2 = new PdfPCell(new Phrase("FECHA RADICACION", fuente));
                    PdfPCell celda3 = new PdfPCell(new Phrase("PROCEDENCIA", fuente));
                    PdfPCell celda4 = new PdfPCell(new Phrase("DETALLE", fuente));
                    PdfPCell celda5 = new PdfPCell(new Phrase("EXPEDIENTE", fuente));
                    PdfPCell celda6 = new PdfPCell(new Phrase("DESTINO", fuente));
                    PdfPCell celda7 = new PdfPCell(new Phrase("IMAGEN", fuente));
                    PdfPCell celda8 = new PdfPCell(new Phrase("RADICADOR", fuente));
                    table.AddCell(celda1);
                    table.AddCell(celda2);
                    table.AddCell(celda3);
                    table.AddCell(celda4);
                    table.AddCell(celda5);
                    table.AddCell(celda6);
                    table.AddCell(celda7);
                    table.AddCell(celda8);
                    Font fuentaData = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 6, iTextSharp.text.Font.NORMAL);                    
                    foreach (DataRow row in data.Rows)
                    {
                        foreach (DataColumn column in data.Columns)
                        {
                            if (column.Caption == "RadicadoCodigo" || column.Caption == "WFMovimientoFecha" || column.Caption == "ProcedenciaNombre" || column.Caption == "Detalle" || column.Caption == "ExpedienteNombre" || column.Caption == "Serie" || column.Caption == "Imagen" || column.Caption == "DependenciaNombre")
                            {
                                PdfPCell celda = new PdfPCell(new Phrase(row[column.Caption].ToString(), fuentaData));
                                celda.Colspan = 1;
                                //celda.Padding = 3;
                                celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_JUSTIFIED;
                                celda.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP;
                                table.AddCell(celda);                       
                            }                            
                        }
                        table.CompleteRow();
                    }
                    table.TotalWidth = 1100;
                    doc.Add(table);
                    //table.WriteSelectedRows(0, -1, 50, 550, writer.DirectContent);
                    //writer.Flush();
                    doc.Close();

                    Response.Clear();
                    Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", "InformeFacturas.pdf"));
                    Response.ContentType = "application/octet-stream";
                    Response.WriteFile(Path.Combine(System.Configuration.ConfigurationManager.AppSettings["repositorioExport"].ToString(), "InformeFacturas.pdf"));
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    //Response.End();
                    //Response.Clear();
                    //Response.ClearContent();
                    //Response.ClearHeaders();
                    //Response.ContentType = "application/octet-stream";
                    //Response.AddHeader("Content-Disposition", "attachment; filename=" + target + "");
                    //this.EnableViewState = false;
                    //Response.Write(tw);
                    //Response.Flush();
                    //Response.Close();
                    btnExport.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                ErrorClient errorclient = new ErrorClient();
                ObjError Error = new ObjError();
                Error.ErrorCode = ex.Source;
                Error.MessegeError = ex.Message;
                Error.StackTrace = ex.StackTrace;

                errorclient.SaveLogError(Error, (ConfigData)Session["DatabaseEngine"]);   
                lblMessage.Text = "No es posible exportar los datos en este momento. Por favor intente mas tarde";
                btnExport.Enabled = true;
            }
        }

        protected void cbxPorImagen_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPorImagen.Checked == true)
            {
                div_consultaByImagen.Visible = true;
            }
            else
            {
                div_consultaByImagen.Visible = false;               
            }
        }

      

        protected void cbxRadicadorCod_CheckedChanged(object sender, EventArgs e)
        {

            if (cbxRadicadorCod.Checked == true)
            {
                div_consultaByRadicador.Visible = true;
            }
            else
            {
                div_consultaByRadicador.Visible = false;
                txtRadicadoCodigo.Text = string.Empty;
                
            }

        }

        protected void cbxRegional_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxRegional.Checked == true)
            {
                div_consultaByRegional.Visible = true;
            }
            else
            {
                div_consultaByRegional.Visible = false;
                txtCodCiudadInicial.Text = string.Empty;
                txtCodCiudadFinal.Text = string.Empty;
            }
        }
    }
}
