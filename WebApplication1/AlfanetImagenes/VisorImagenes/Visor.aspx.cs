using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using WebApplication1.VisorImagenesService;
using Alfanet.CommonLibrary;
using Alfanet.CommonObject;
using Neodynamic.WebControls.ImageDraw;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WebApplication1.AlfanetImagenes.VisorImagenes
{
    public partial class Visor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CommonLibrary common = null;
            try
            {

                int t = 0;
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

                string nrodoc = Request["DocumentoCodigo"];
                string Grupo = Request["GrupoCodigo"];
                string Grupopadre = Request["GrupoPadreCodigo"];
                Session["NumDoc"] = Request["DocumentoCodigo"];
                String NombreArch = null;
                int j = 1;
                //Trabajo con radicado
                if (Convert.ToInt32(Request["GrupoPadreCodigo"]) == 1)
                {
                    //Consulta  de Imagenes por Numero de documento
                    VisorImagenesClient client = new VisorImagenesClient();
                    string[] result = result = client.GetFacturaImagenById(out result, Grupo, nrodoc, (ConfigData)Session["DatabaseEngine"]);
                 
                    if (result.Count() == 0)
                    {
                        LblDocumentoNro.Text = "No existen imagenes para este radicado " + Session["NumDoc"].ToString();
                    }

                    else
                    {
                        foreach (string dato in result)
                        {
                            string[] partes = dato.Split('#');              
                             string[] partesRutaimagen = client.GetRutaImagenById(out partesRutaimagen, partes[1], (ConfigData)Session["DatabaseEngine"]);
                            /*Se captura el consecutivo de folio*/
                            int tmFolio = Convert.ToInt32(partes[0]);
                            /*Indagar si encontró el folio*/
                            //if (j == Convert.ToInt32(Request["ImagenFolio"]))
                            if (tmFolio == Convert.ToInt32(Request["ImagenFolio"]))
                            {

                                Session["Path"] = partesRutaimagen[0];
                                NombreArch = partes[2];
                                Session["NombreArchivo"] = NombreArch;
                                //this.HFPath.Value = DTImagenRuta[0].ImagenRutaPath.ToString();
                                //NombreArch = drImgRow.RadicadoImagenNombre;
                                //this.HFFileName.Value = NombreArch;

                            }
                            HtmlTable Tabla = new HtmlTable();
                            ShowThumbanails(Tabla, j, Session["NombreArchivo"].ToString(), Session["Path"].ToString(), tmFolio.ToString(), Request["DocumentoCodigo"]);

                            this.PlaceHolder1.Controls.Add(Tabla);
                            this.LNImagen.Text = Session["NombreArchivo"].ToString();
                            this.LblDocumentoNro.Text = Session["NumDoc"].ToString();

                            //int t = 0;

                            if (!this.IsPostBack)
                            {
                                //Atributo Para Impresion
                                //((System.Web.UI.WebControls.Image)PnlPrint.FindControl("ImgPrint")).Attributes.Add("onClick", "ClientSidePrint('currentPage');");
                                //   
                                ((System.Web.UI.WebControls.Image)PnlPrint.FindControl("ImgPrint")).Attributes.Add("onClick", "ClientSidePrint('currentPage');");
                                //if (!Roles.IsUserInRole(User.Identity.Name, "Administrador"))
                                //{
                                //    this.LinkButton1.Visible = false;
                                //    this.DeleteButton.Visible = false;
                                //}
                                //else
                                //{
                                //    this.LinkButton1.Visible = true;
                                //    this.DeleteButton.Visible = true;
                                //}

                                //Instancia de ImageElement
                                ImageElement imgElem = this.ImageDraw2.Elements[0] as ImageElement;
                                //ImageElement ImgEle = new ImageElement();


                                String[] Extension = Session["NombreArchivo"].ToString().Split('.');
                                String TipoArchivo = Extension[Extension.Length - 1];
                                int indice = 0;
                                if (TipoArchivo == "gif" || TipoArchivo == "Gif" || TipoArchivo == "GIF")
                                {
                                    ImageElement ImgElem = new ImageElement();
                                    ImgElem.Source = ImageSource.File;
                                    ImgElem.SourceFile = "~/AlfanetImagenes/iconos/icono_Blaco.jpg";
                                    ImgElem.Name = "MyJpg";
                                    ImageDraw2.Elements.Add(ImgElem);
                                    indice = 1;

                                }

                                if (TipoArchivo == "gif" || TipoArchivo == "Gif" || TipoArchivo == "GIF" || TipoArchivo == "jpg" || TipoArchivo == "JPG" || TipoArchivo == "Jpg" || TipoArchivo == "png" || TipoArchivo == "PNG" || TipoArchivo == "Png" || TipoArchivo == "BMP" || TipoArchivo == "Bmp" || TipoArchivo == "bmp" || TipoArchivo == "TIF" || TipoArchivo == "Tif" || TipoArchivo == "tif")
                                {
                                    ////Get total pages once                        
                                    ////ImgEle.Source = ImageSource.File;
                                    ////ImgEle.SourceFile = @"F:\AlfaNet\AlfaNetImagen\iconos\icono_txt.gif";
                                    ////ImgEle.SourceFile = HFPath.Value + HFFileName.Value;
                                    ////ImgEle.Name = "MyJpg";
                                    imgElem.SourceFile = Session["Path"].ToString() + Session["NombreArchivo"].ToString();
                                    if (imgElem.MultiPageCount == 0)
                                        //  {

                                        //   imgElem.SourceFile = "~/AlfanetImagenes/logoalfanetnoimagen.JPG";
                                        //    //ImgEle.SourceFile = "~/AlfanetImagenes/logoalfanetnoimagen.JPG";

                                        //  }
                                        /////////////////////////////////////////////////////////////////
                                        ////Get total pages once
                                        t = ((ImageElement)this.ImageDraw2.Elements[indice]).MultiPageCount;
                                    ////Store it in the ViewState
                                    ViewState["TotalPages"] = t;
                                    ////Load drop down list for pages
                                    for (int i = 0; i < t; i++)
                                    {
                                        ddlPages.Items.Add(new System.Web.UI.WebControls.ListItem("Página " + (i + 1).ToString(), i.ToString()));
                                    }
                                    ddlPages.SelectedIndex = 0;

                                    ////Display first page
                                    this.DisplayTiffPage(0);

                                    //////////////////////////////////////////////////////////
                                    //this.SetZoom(int.Parse(this.ddlZoom.SelectedValue));

                                    this.SetZoom(50);
                                    this.ddlZoom.SelectedValue = "50";
                                    Session["ZoomValue"] = this.ddlZoom.SelectedValue;
                                    //this.HFZoom.Value = this.ddlZoom.SelectedValue;




                                    this.FramePDF.Visible = false;
                                    this.ImageDraw2.Visible = true;

                                }
                                if (TipoArchivo == "Txt" || TipoArchivo == "Pdf" || TipoArchivo == "doc" || TipoArchivo == "docx" || TipoArchivo == "xls" || TipoArchivo == "xlsx" || TipoArchivo == "ppt" || TipoArchivo == "pptx" || TipoArchivo == "TXT" || TipoArchivo == "txt" || TipoArchivo == "PDF" || TipoArchivo == "pdf")
                                {


                                    string DirectorioOrigen = Session["Path"].ToString() + Session["NombreArchivo"].ToString();
                                    string DirectorioDestino = AppDomain.CurrentDomain.BaseDirectory + "TemporalVisualisacion\\";
                                    if (!Directory.Exists(DirectorioDestino))
                                    {
                                        Directory.CreateDirectory(DirectorioDestino);
                                    }
                                    string[] ficherosCarpeta = Directory.GetFiles(DirectorioDestino);
                                    foreach (string ficheroActual in ficherosCarpeta)
                                    {
                                        File.Delete(ficheroActual);
                                    }
                                    File.Copy(DirectorioOrigen, DirectorioDestino + Session["NombreArchivo"].ToString(), true);
                                    String[] Paths = (DirectorioDestino + Session["NombreArchivo"].ToString()).Split('\\');
                                    String VirtualPath = "../../";
                                    int zv = 7;
                                    for (int z = 0; z < Paths.Length - 1; z = z + 1)
                                    {
                                        if (Paths[z] == "TemporalVisualisacion")
                                        {
                                            VirtualPath = VirtualPath + Paths[z] + '/';
                                            zv = z;
                                        }
                                        else if (z > zv)
                                        {
                                            VirtualPath = VirtualPath + Paths[z] + '/';
                                        }
                                        else if (Paths[z] == "imgregistros")
                                        {
                                            VirtualPath = @"\\172.23.24.163\alfaweb\Aplicacion\imgregistros\";
                                        }
                                        else if (Paths[z] == "imgradicados")
                                        {
                                            VirtualPath = @"\\172.23.24.163\alfaweb\Aplicacion\imgradicados\";
                                        }
                                    }

                                    ImageDraw2.Visible = false;
                                    this.FramePDF.Attributes["Src"] = VirtualPath + Session["NombreArchivo"].ToString();
                                    this.FramePDF.DataBind();
                                    this.FramePDF.Visible = true;
                                }
                            }
                            else
                            {
                                if (ViewState["TotalPages"] != null)
                                    t = (int)ViewState["TotalPages"];
                            }

                            this.Watermark(true);

                            
                        }
                    }
                }   
                    
                
            }
            catch (Exception ex)
            {
                this.LblMessageBox.Text = "Error: " + ex.Message.ToString();
                this.MPEMensaje.Show();
            }




        }





        public void ShowThumbanails(HtmlTable Table, int i, String ImagenNombre, String Path, String Folio, String NumeroDocumento)
        {
            try
            {

                HtmlTableRow Row1 = new HtmlTableRow();
                //Row1.Attributes.Add("onClick", ShowFile());
                Table.Rows.Add(Row1);
                HtmlTableCell Cell0 = new HtmlTableCell();
                Row1.Cells.Add(Cell0);
                //Neodynamic.WebControls.ImageDraw.ImageDraw.ProcessImageRequest();
                //ImageDrawButton.ProcessImageRequest();
                //Create an instance of ImageDraw
                //Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw();
                HyperLink Hpl = new HyperLink();
                Hpl.ID = ImagenNombre;
                //Hpl.                        
                //ImageDraw imgDrawButton = new ImageDraw();
                //imgDrawButton.ID = ImagenNombre;

                //imgButton.ImageUrl = @"F:\AlfaNet\RepositorioFacturas\Radicados\2009\Mayo\icono_txt.gif";
                //ImageDrawButton.
                //Cell0.Controls.Add(imgButton);
                //Create an instance of ImageElement class
                //ImageElement imgElem = new ImageElement();
                ////Set the source property
                //imgElem.Source = ImageSource.File;
                String[] Paths = Path.Split('\\');
                String VirtualPath = "~/";
                int zv = 7;
                for (int z = 0; z < Paths.Length - 1; z = z + 1)
                {
                    if (Paths[z] == "RepositorioFacturas")
                    {
                        VirtualPath = VirtualPath + Paths[z] + '/';
                        zv = z;
                    }
                    else if (z > zv)
                    {
                        VirtualPath = VirtualPath + Paths[z] + '/';
                    }

                }

                String GrupoCodigo = Request["GrupoCodigo"];
                String GrupoPadreCodigo = Request["GrupoPadreCodigo"];

                string[] words = ImagenNombre.Split('.');
                int Ind = words.Length - 1;
                if (words[Ind] == "doc" || words[Ind] == "docx")
                {
                    Hpl.ImageUrl = "~/Imagenes/iconos/icono_doc.gif";
                    //Hpl.Target = "_Blank";
                    Hpl.NavigateUrl = "~/AlfanetImagenes/VisorImagenes/Visor.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;
                    //Hpl.NavigateUrl = VirtualPath + ImagenNombre;
                    //Hpl.NavigateUrl = Path + ImagenNombre;

                }
                else if (words[Ind] == "xls" || words[Ind] == "xlsx")
                {
                    //imgElem.SourceFile = @"F:\AlfaNet\AlfaNetImagen\iconos\icono_xls.gif";
                    Hpl.ImageUrl = "~/Imagenes/iconos/icono_xls.gif";
                    //Hpl.NavigateUrl = "~/AlfanetImagenes/VisorImagenes/Visor.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;
                    //Hpl.NavigateUrl = VirtualPath + ImagenNombre;
                    Hpl.NavigateUrl = "~/AlfanetImagenes/VisorImagenes/Visor.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;

                }
                else if (words[Ind] == "ppt" || words[Ind] == "pptx")
                {
                    //imgElem.SourceFile = @"F:\AlfaNet\AlfaNetImagen\iconos\icono_ppt.gif";
                    Hpl.ImageUrl = "~/AlfanetImagenes/VisorImagenes/Imagenes/iconos/icono_ppt.gif";
                    Hpl.NavigateUrl = VirtualPath + ImagenNombre;
                }
                else if (words[Ind] == "pdf" || words[Ind] == "PDF")
                {
                    //imgElem.SourceFile = @"F:\AlfaNet\AlfaNetImagen\iconos\icono_pdf.gif";
                    Hpl.ImageUrl = "~/AlfanetImagenes/VisorImagenes/Imagenes/iconos/icono_pdf.gif";
                    Hpl.NavigateUrl = "~/AlfanetImagenes/VisorImagenes/Visor.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;
                    //Hpl.NavigateUrl = VirtualPath + ImagenNombre;
                    //HtmlControl frame1 = (HtmlControl)this.Panel1.FindControl("FramePDF");
                    //frame1.Visible = true;
                    //Hpl.Target = "iframe1";
                }
                else if (words[Ind] == "txt" || words[Ind] == "TXT")
                {
                    //Hpl.Target = "_Blank";
                    Hpl.ImageUrl = "~/AlfanetImagenes/VisorImagenes/Imagenes/iconos/icono_txt.gif";
                    Hpl.NavigateUrl = "~/AlfanetImagenes/VisorImagenes/Visor.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;
                    //Hpl.NavigateUrl = VirtualPath + ImagenNombre;
                }
                else if (words[Ind] == "tif" || words[Ind] == "TIF")
                {
                    Hpl.ImageUrl = "~/AlfanetImagenes/VisorImagenes/Imagenes/iconos/icono_tif.jpg";
                    Hpl.NavigateUrl = "~/AlfanetImagenes/VisorImagenes/Visor.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;
                }
                else if (words[Ind] == "jpg" || words[Ind] == "JPG")
                {
                    Hpl.ImageUrl = "~/AlfanetImagenes/VisorImagenes/Imagenes/iconos/icono_tif.jpg";
                    Hpl.NavigateUrl = "~/AlfanetImagenes/VisorImagenes/Visor.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;
                }
                else if (words[Ind] == "png" || words[Ind] == "PNG")
                {
                    Hpl.ImageUrl = "~/AlfanetImagenes/VisorImagenes/Imagenes/iconos/icono_tif.jpg";
                    Hpl.NavigateUrl = "~/AlfanetImagenes/VisorImagenes/Visor.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;
                }
                else if (words[Ind] == "bmp" || words[Ind] == "BMP")
                {
                    Hpl.ImageUrl = "~/AlfanetImagenes/VisorImagenes/Imagenes/iconos/icono_tif.jpg";
                    Hpl.NavigateUrl = "~/AlfanetImagenes/VisorImagenes/Visor.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;
                }
                else if (words[Ind] == "gif" || words[1] == "Gif" || words[Ind] == "GIF")
                {

                    Hpl.ImageUrl = "~/AlfanetImagenes/VisorImagenes/Imagenes/iconos/icono_tif.jpg";
                    Hpl.NavigateUrl = "~/AlfanetImagenes/VisorImagenes/Visor.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;
                }
                else if (words[Ind] == "zip" || words[1] == "ZIP" || words[Ind] == "Zip")
                {

                    Hpl.ImageUrl = "~/AlfanetImagenes/VisorImagenes/Imagenes/iconos/icono_zip.gif";
                    Hpl.NavigateUrl = VirtualPath + ImagenNombre;
                    //Hpl.NavigateUrl = "~/AlfanetImagenes/VisorImagenes/Visor.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;
                }
                else if (words[Ind] == "rar" || words[1] == "RAR" || words[Ind] == "Rar")
                {

                    Hpl.ImageUrl = "~/AlfanetImagenes/VisorImagenes/Imagenes/iconos/icono_zip.gif";
                    Hpl.NavigateUrl = VirtualPath + ImagenNombre;
                    //Hpl.NavigateUrl = "~/AlfanetImagenes/VisorImagenes/Visor.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;
                }
                else
                {
                    Hpl.ImageUrl = "~/AlfanetImagenes/VisorImagenes/Imagenes/iconos/icono_tif.jpg";
                    Hpl.NavigateUrl = VirtualPath + ImagenNombre;
                }

                ////Add uploaded image
                //imgDraw.Elements.Add(imgElem);
                //imgDrawButton.Elements.Add(imgElem);
                //Add the ImageDraw object to the PlaceHolder Controls collection
                //this.PlaceHolder1.Controls.Add(imgDrawButton);
                //this.PnlImg.Controls.Add(Cell0);
                //this.PnlImg.Controls.Add(new LiteralControl("<br />"));
                this.PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
                this.PlaceHolder1.Controls.Add(Hpl);
                //Set the ImageDraw properties and objects now
                //Label LabelDep = new Label();
                //LabelDep.ID = "LabelDepCopia" + Convert.ToString(i);
                //LabelDep.Text = this.Session["NumDoc"].ToString().ToString();
                //LabelDep.Visible = true;
                //LabelDep.Width = 150;
                //Cell0.Controls.Add(LabelDep);
                // }
            }
            catch (Exception ex)
            {
                this.LblMessageBox.Text = "Error: " + ex.Message.ToString();
                this.MPEMensaje.Show();
            }
        }
        public void ShowFile()
        {

        }
        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            string GGrupo = Request["GrupoCodigo"];
            try
            {              

                if (this.FileUpload1.HasFile)
                {                    
                    string nombreArchivo = Request["GrupoPadreCodigo"].ToString() + "_" + Request["DocumentoCodigo"].ToString() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + this.FileUpload1.FileName;

                    //Radicado
                    if (Convert.ToInt32(Request["GrupoPadreCodigo"]) == 1)
                    {
                                           
                        int Ano = DateTime.Today.Year;
                        int Mes = DateTime.Today.Month;
                        string path = System.Configuration.ConfigurationManager.AppSettings["repositoriofacturas"];
                        string pathTotal = path + Ano.ToString() + "\\" + Mes.ToString() + "\\";
                        VisorImagenesClient client = new VisorImagenesClient();
                        int rutacodigo = client.SelectRutaCodigoFacturas(pathTotal, (ConfigData)Session["DatabaseEngine"]);
                        if (rutacodigo == 0)
                        {
                            if (Directory.Exists(pathTotal))
                            {
                                client.InsertRutaImagen(out rutacodigo, 0, "rutas para facturas", Ano, Mes, 4, pathTotal, (ConfigData)Session["DatabaseEngine"]);
                                client.InsertFacturaImagen((int)Session["NumDoc"], "4", nombreArchivo, rutacodigo, (ConfigData)Session["DatabaseEngine"]);
                                this.FileUpload1.SaveAs(pathTotal + nombreArchivo);
                            }
                            else
                            {
                                Directory.CreateDirectory(pathTotal);
                                client.InsertRutaImagen(out rutacodigo, 0, "rutas para facturas", Ano, Mes, 4, pathTotal, (ConfigData)Session["DatabaseEngine"]);
                                client.InsertFacturaImagen((int)Session["NumDoc"], "4", nombreArchivo, rutacodigo, (ConfigData)Session["DatabaseEngine"]);

                                this.FileUpload1.SaveAs(pathTotal + nombreArchivo);

                            }
                        }
                        else 
                        {
                            if (Directory.Exists(pathTotal))
                            {
                                client.InsertFacturaImagen(int.Parse(Session["NumDoc"].ToString()), "4", nombreArchivo, rutacodigo, (ConfigData)Session["DatabaseEngine"]);
                                this.FileUpload1.SaveAs(pathTotal + nombreArchivo);
                            }
                            else
                            {
                                Directory.CreateDirectory(pathTotal);
                                client.InsertFacturaImagen(int.Parse(Session["NumDoc"].ToString()), "4", nombreArchivo, rutacodigo, (ConfigData)Session["DatabaseEngine"]);
                                this.FileUpload1.SaveAs(pathTotal + nombreArchivo);
                            }
 
                        }                      
                        
                        this.LblUploadDetails.Visible = true;
                        this.LblUploadDetails.Text = string.Format(
                        @"Nombre: {0}<br />
                    Tamaño (en bytes): {1:N0}<br />
                    Tipo: {2}",
                        this.FileUpload1.FileName,
                        this.FileUpload1.FileBytes.Length,
                        this.FileUpload1.PostedFile.ContentType);
                        this.PlaceHolder1.Controls.Clear();
                        Page_Load(null, null);

                        this.LblMessageBox.Text = "Imagen Adicionada";
                        this.MPEMensaje.Show();

                    }//Registro
                    else if (Convert.ToInt32(Request["GrupoPadreCodigo"]) == 2)
                    {                        
                        String Grupo = "Registros";
                        String Ano = DateTime.Today.Year.ToString();
                        String Mes = DateTime.Today.Month.ToString();

                        String PathVirtual = HttpContext.Current.Server.MapPath("~/RepositorioFacturas/" + Grupo + "/" + Ano + "/" + Mes + "/");
                                               
                        this.LblUploadDetails.Visible = true;
                        this.LblUploadDetails.Text = string.Format(
                        @"Nombre: {0}<br />
                    Tamaño (en bytes): {1:N0}<br />
                    Tipo: {2}",
                        this.FileUpload1.FileName,
                        this.FileUpload1.FileBytes.Length,
                        this.FileUpload1.PostedFile.ContentType);
                        this.PlaceHolder1.Controls.Clear();
                        Page_Load(null, null);

                        this.LblMessageBox.Text = "Imagen Adicionada";
                        this.MPEMensaje.Show();
                    }
                }
                else
                {
                    this.LblMessageBox.Text = "No ha especificado un archivo";
                    this.MPEMensaje.Show();
                }

            }
            catch (Exception ex)
            {
                this.LblMessageBox.Text = "Error: " + ex.Message.ToString();
                this.MPEMensaje.Show();
            }
        }
        protected void ddlZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetZoom(int.Parse(this.ddlZoom.SelectedValue));
        }
        private void SetZoom(int zoom)
        {
            ////get ImageElement...
            //ImageElement imgElem = this.ImageDraw2.Elements[0] as ImageElement;
            //imgElem.Actions.Clear();

            ////Create scale action
            //Scale scaleAction = new Scale();
            //scaleAction.WidthPercentage = zoom;
            //scaleAction.HeightPercentage = zoom;

            //imgElem.Actions.Add(scaleAction);
            //this.HFZoom.Value = zoom.ToString();

            ////this.LblMessageBox.Text = zoom.ToString();
            ////this.MPEMensaje.Show();

        }
        protected void zoomMasButton_Click(object sender, EventArgs e)
        {
            if (this.ddlZoom.SelectedIndex - 1 >= 0)
            {
                this.SetZoomButtons(int.Parse(this.ddlZoom.Items[this.ddlZoom.SelectedIndex - 1].Value));
                this.ddlZoom.SelectedValue = this.ddlZoom.Items[this.ddlZoom.SelectedIndex - 1].Value;
            }

        }
        protected void zoomMenosButton_Click(object sender, EventArgs e)
        {
            if (this.ddlZoom.SelectedIndex + 1 <= ddlZoom.Items.Count)
            {
                this.SetZoomButtons(int.Parse(this.ddlZoom.Items[this.ddlZoom.SelectedIndex + 1].Value));
                this.ddlZoom.SelectedValue = this.ddlZoom.Items[this.ddlZoom.SelectedIndex + 1].Value;
            }
        }
        private void SetZoomButtons(int zoom)
        {
            ////get ImageElement...
            //ImageElement imgElem = this.ImageDraw2.Elements[0] as ImageElement;
            //imgElem.Actions.Clear();

            //if (zoom >= 0)
            //{
            //    //Create scale action
            //    Scale scaleAction = new Scale();
            //    scaleAction.WidthPercentage = zoom;
            //    scaleAction.HeightPercentage = zoom;

            //    imgElem.Actions.Add(scaleAction);
            //    this.HFZoom.Value = zoom.ToString();

            //    //this.LblMessageBox.Text = zoom.ToString();
            //    //this.MPEMensaje.Show();
            //}

        }
        private void Watermark(bool addWatermark)
        {
            if (addWatermark)
            {
                //Create watermark
                RectangleShapeElement rectWatermark = new RectangleShapeElement();                
                rectWatermark.Text = "CONFIDENCIAL";               
                rectWatermark.Font.Bold = true;
                rectWatermark.Font.Name = "Arial Narrow";
                rectWatermark.Font.Size = 30f;
                rectWatermark.Fill.BackgroundColor = System.Drawing.Color.Transparent;
                rectWatermark.StrokeWidth = 5;
                rectWatermark.StrokeFill.BackgroundColor = System.Drawing.Color.FromArgb(127, System.Drawing.Color.Red);
                rectWatermark.TextForeColor = System.Drawing.Color.FromArgb(127, System.Drawing.Color.Red);

                //Rotate 45 degrees
                Rotate rotAction = new Rotate();
                rotAction.Angle = 45;

                //Apply rotation on watermark
                rectWatermark.Actions.Add(rotAction);

                //add watermark to composite image
                this.ImageDraw2.Elements.Add(rectWatermark);
            }
            else
            {
                //Remove watermark...
                if (this.ImageDraw2.Elements.Count == 2)
                {
                    this.ImageDraw2.Elements.RemoveAt(1);
                }
            }
        }
        protected void chkWatermark_CheckedChanged(object sender, EventArgs e)
        {
            this.Watermark(this.chkWatermark.Checked);
        }
        protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get ImageElement...
            //ImageElement imgElem = this.ImageDraw2.Elements[0] as ImageElement;
            ////Set page to display
            //imgElem.MultiPageIndex = int.Parse(this.ddlPages.SelectedValue);
            ////Set output image name/id
            //this.ImageDraw2.OutputImageName = "Page" + this.ddlPages.SelectedValue;
        }
        private void DisplayTiffPage(int increment)
        {
            ////get total pages
            //int totalPages = (int)ViewState["TotalPages"];

            ////get ImageElement...
            //ImageElement imgElem = this.ImageDraw2.Elements[0] as ImageElement;

            ////get current page
            //int cIndex = imgElem.MultiPageIndex + increment;

            //if (cIndex < 0)
            //{
            //    cIndex = 0;
            //}
            //else if (cIndex > totalPages - 1)
            //{
            //    cIndex = totalPages - 1;
            //}

            ////Set page to display
            //imgElem.MultiPageIndex = cIndex;

            ////Set output image name/id
            ////this.ImageDraw2.OutputImageName = "Page" + Request["DocumentoCodigo"] + cIndex.ToString();

            ////Update drop down list index
            //this.ddlPages.SelectedIndex = cIndex;
        }
        protected void prevButton_Click(object sender, ImageClickEventArgs e)
        {
            this.DisplayTiffPage(-1);
        }
        protected void nextButton_Click(object sender, ImageClickEventArgs e)
        {
            this.DisplayTiffPage(1);
        }
        protected void rotarIzqButton_Click(object sender, ImageClickEventArgs e)
        {
            ////get ImageElement...
            //ImageElement imgElem = this.ImageDraw2.Elements[0] as ImageElement;

            ////Rotate 45 degrees

            //Rotate rotAction = new Rotate();
            //rotAction.Angle = 90;

            //imgElem.Actions.Add(rotAction);

        }
        protected void rotarDerButton_Click(object sender, ImageClickEventArgs e)
        {
            ////get ImageElement...
            //ImageElement imgElem = this.ImageDraw2.Elements[0] as ImageElement;

            ////Rotate 45 degrees

            //Rotate rotAction = new Rotate();
            //rotAction.Angle = 270;

            //imgElem.Actions.Add(rotAction);

        }
        protected void DeleteButton_Click(object sender, ImageClickEventArgs e)
        {
            String Folio = Request["ImagenFolio"];
            String GrupoCodigo = Request["GrupoCodigo"];
            String NumeroDocumento = Request["DocumentoCodigo"];
            String GrupoPadre = Request["GrupoPadreCodigo"];
            if (GrupoPadre == "1")
            {
                VisorImagenesClient client = new VisorImagenesClient();
                client.EliminarImagen(int.Parse(NumeroDocumento), int.Parse(Folio), (ConfigData)Session["DatabaseEngine"]);
            }
            Response.Redirect("~/AlfanetImagenes/VisorImagenes/Visor.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadre + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=1");
            //else if (GrupoPadre == "2")
            //{
            //    DSImagenTableAdapters.RegistroImagenTableAdapter TAImgReg = new DSImagenTableAdapters.RegistroImagenTableAdapter();
            //    TAImgReg.Delete(GrupoCodigo, Convert.ToInt32(NumeroDocumento), Convert.ToInt32(Folio));
            //}
            

        }
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            String Folio = Request["ImagenFolio"];
            String GrupoCodigo = Request["GrupoCodigo"];
            String NumeroDocumento = Request["DocumentoCodigo"];
            String GrupoPadre = Request["GrupoPadreCodigo"];
            if (GrupoPadre == "1")
            {
                VisorImagenesClient client = new VisorImagenesClient();
                client.EliminarImagen(int.Parse(NumeroDocumento), int.Parse(Folio), (ConfigData)Session["DatabaseEngine"]);
            }
            Response.Redirect("~/AlfanetImagenes/VisorImagenes/Visor.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadre + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=1");
            //else if (GrupoPadre == "2")
            //{
            //    DSImagenTableAdapters.RegistroImagenTableAdapter TAImgReg = new DSImagenTableAdapters.RegistroImagenTableAdapter();
            //    TAImgReg.Delete(GrupoCodigo, Convert.ToInt32(NumeroDocumento), Convert.ToInt32(Folio));
            //}
        }
        protected void ImgBtnPrintPDF_Click(object sender, ImageClickEventArgs e)
        {
            int Imagenescount = ImageDraw2.Elements.Count;
            if (Imagenescount > 0)
            {

                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(HttpContext.Current.Server.MapPath("~/devjoker.pdf"), FileMode.Create));
                document.Open();

                ImageElement ImgEle = new ImageElement();
                if (Imagenescount > 0)
                {
                    ImgEle = this.ImageDraw2.Elements[0] as ImageElement;
                }
                else if (Imagenescount > 1)
                {
                    ImgEle = this.ImageDraw2.Elements[1] as ImageElement;
                }

                ImgEle.Name = "MyImage";

                int t = ImgEle.MultiPageCount;

                ViewState["TotalPages"] = t;
                for (int i = 0; i <= t; i++)
                {
                    //Set page to display
                    ImgEle.MultiPageIndex = i;

                    Byte[] BinaryImg = ImageDraw2.GetOutputImageBinary();

                    iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(BinaryImg);

                    png.Alignment = iTextSharp.text.Image.MIDDLE_ALIGN;
                    png.ScalePercent(80);
                    document.Add(png);
                }
                // Fin de Interface Image draw         

                document.Close();
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-disposition", "attachment; filename=" + "devjoker.pdf");
                Response.WriteFile(HttpContext.Current.Server.MapPath("~/devjoker.pdf"));
                Response.Flush();
                Response.Close();

                File.Delete(Server.MapPath("~/devjoker.pdf"));


            }

           


            }
        
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            //ImageElement ImgEle = new ImageElement();
            //int Imagenescount = ImageDraw2.Elements.Count;
            //if (Imagenescount > 0)
            //{
            //    ImgEle = this.ImageDraw1.Elements[0] as ImageElement;
            //}
            //else if (Imagenescount > 1)
            //{
            //    ImgEle = this.ImageDraw1.Elements[1] as ImageElement;
            //}

            //ImgEle.Name = "MyImage";

            //ImgEle.MultiPageIndex = this.ddlPages.SelectedIndex;

            //Byte[] BinaryImg = ImageDraw1.GetOutputImageBinary();
            //BinaryImg.

            //BinaryImg.

            //iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(BinaryImg);

            //png.Alignment = iTextSharp.text.Image.MIDDLE_ALIGN;
            //png.ScalePercent(80);
            //document.Add(png);

        }
        protected void ImageButtonguardar_click(object sender, EventArgs e)
        {
            //string Path_flie = "";
            //if (Convert.ToInt32(Request["GrupoPadreCodigo"]) == 1)
            //{
            //    DSImagenTableAdapters.RadicadoImagenTableAdapter TARadicadoImagen = new DSImagenTableAdapters.RadicadoImagenTableAdapter();
            //    DSImagenTableAdapters.ImagenRutaTableAdapter TAImgRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();
            //    DSImagen.ImagenRutaDataTable DTImgRuta = new DSImagen.ImagenRutaDataTable();

            //    Object CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "1");
            //    int codigoR = Convert.ToInt32(CodigoRuta);
            //    String Grupo = "Radicados";
            //    String Ano = DateTime.Today.Year.ToString();
            //    String Mes = DateTime.Today.Month.ToString();

            //    Path_flie = HttpContext.Current.Server.MapPath("~/RepositorioFacturas/" + Grupo + "/" + Ano + "/" + Mes + "/");
            //}
            //if (Convert.ToInt32(Request["GrupoPadreCodigo"]) == 2)
            //{
            //    DSImagenTableAdapters.RegistroImagenTableAdapter TARegistroImagen = new DSImagenTableAdapters.RegistroImagenTableAdapter();
            //    DSImagenTableAdapters.ImagenRutaTableAdapter TAImgRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();
            //    DSImagen.ImagenRutaDataTable DTImgRuta = new DSImagen.ImagenRutaDataTable();

            //    Object CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "2");
            //    int codigoR = Convert.ToInt32(CodigoRuta);
            //    String Grupo = "Registros";
            //    String Ano = DateTime.Today.Year.ToString();
            //    String Mes = DateTime.Today.Month.ToString();

            //    Path_flie = HttpContext.Current.Server.MapPath("~/RepositorioFacturas/" + Grupo + "/" + Ano + "/" + Mes + "/");


            //}
            //string filename = this.HFFileName.Value;

            //if (filename != "")
            //{

            //    string path1 = Path_flie + filename;

            //    //string path = Server.MapPath("~/AlfaNetManual/ManualInteractivo/Videos/Radicar un Documento.exe");
            //    //string path = this.HFPath.Value + this.HFFileName.Value;
            //    System.IO.FileInfo file = new System.IO.FileInfo(path1);
            //    if (file.Exists)
            //    {
            //        Response.Clear();
            //        Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
            //        Response.AddHeader("Content-Length", file.Length.ToString());
            //        Response.ContentType = "application/octet-stream";
            //        Response.WriteFile(file.FullName);
            //        Response.End();
            //    }
            //    else
            //    {
            //        //Response.Write("This file does not exist.");
            //    }
            //}
        }
    }
}