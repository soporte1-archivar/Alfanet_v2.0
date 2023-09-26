<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RadicacionMasiva.aspx.cs" Inherits="WebApplication1.RadicacionMasiva.RadicacionMasiva" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="X-UA-COMPATIBLE" content="IE = EmulateIE10">
    <title>Radicaci&oacute;n masiva</title>

    <script src="../Scripts/jquery-1.8.2.js" type="text/javascript"></script>
    <%--<script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>--%>
    <%--<script src="../Scripts/jquery-1.8.2-vsdoc.js" type="text/javascript"></script>--%>
    <script src="script/RadicacionMasiva.js" type="text/javascript"></script>
    <link href="css/radicacionmasivastyle.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <link href="../Styles/smoothness/jquery-ui-1.9.1.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/smoothness/jquery-ui-1.9.1.custom.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-ui-1.9.1.custom.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.9.1.custom.min.js" type="text/javascript"></script>

    <%--<script src="script/jquery-1.4.4-vsdoc.js" type="text/javascript"></script>--%>
    <%--<script src="script/jquery-1.4.4.min.js" type="text/javascript"></script>--%>
    <script src="script/jquery.uploadify.v2.1.4.min.js" type="text/javascript"></script>
    <script src="script/swfobject.js" type="text/javascript"></script>
    <link href="css/uploadify.css" rel="stylesheet" type="text/css" />

   

    <script runat="server">

        void BtnSelectImgs_Click(object sender, System.EventArgs e)
        {
            lblMessage.Text = string.Empty;
            HttpFileCollection hfc = Request.Files;
            for (int i = 0; i < hfc.Count; i++)
            {
                HttpPostedFile hpf = hfc[i];
                if (hpf.ContentLength > 0)
                {
                    string file = System.IO.Path.GetFileName(Request.Files[i].FileName);
                    string dependencia = Session["Dependencia"].ToString().Replace('.', '_');
                    string directoryTemp = System.Configuration.ConfigurationManager.AppSettings["path_images"] + dependencia + @"\";
                    try
                    {
                        if (!System.IO.Directory.Exists(directoryTemp))
                        {
                            System.IO.Directory.CreateDirectory(directoryTemp);
                        }
                        hpf.SaveAs(directoryTemp + file);

                        //ScriptManager.RegisterStartupScript(this,this.GetType(),"popup","alert('Cargo Imagenes a Temp');",true);
                    }
                    catch (Exception ex)
                    {

                    }

                }
            }
        }
    </script>

    <script type="text/javascript">

        $(document).ready(function () {
            $("#fileUpload").on("change", function () {
                var files = $(this).get(0).files;
                var formData = new FormData();
                for (var i = 0; i < files.length; i++) {
                    formData.append(files[i].name, files[i]);
                }

// Ejecutar el evento click del boton BtnSelectImgs
                $("#BtnSelectImgs").trigger("click"); 
                //uploadFiles(formData);
            })
        })

    </script>
    <style type="text/css">
        .file-upload-container {
            height: 100%;
            width: 100%;
        }

        #fileUpload {
            display: none;
            overflow: hidden;
            height: 0;
            width: 0;
        }

        .upload-mask-button:hover {
            background: #3498db;
            opacity: 0.8;
        }

        .upload-mask-button {
            margin: 10px auto;
            font-size: 18px;
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
            text-align: center;
            padding: 0px;
            display: block;
            color: white;
            border-radius: 2px;
            height: 20px;
            width: 150px;
            background: #7F8DAD;
		}
        .OcultaButton{
            display:none
        }
        .btns:hover {
            background: #3498db;
            opacity: 0.8;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        
        <div class="rm_all_container">
            <div class="rm_header">
                <h1>Radicaci&oacute;n masiva</h1>
                 <asp:LinkButton ID="LinkButton1" runat="server" style="color:White;display:none" onclick="LinkButton1_Click">Consulta</asp:LinkButton>
            </div>
            <div class="rm_content">
                <div class="rm_optios_container">
                    <div class="rm_preview_container">
                        <h2>Paso 1 - Cargar Archivo</h2>
                        <table>
                            <tr>
                                <td>
                                    <h4>Seleccione el archivo con los datos a radicar. (.xls, .xlsx, .csv)</h4>
                                </td>
                            </tr>
                            <tr>
                                <td class="rm_center_content">
                                    <asp:FileUpload ID="fuFileToImport" runat="server"
                                        ToolTip="Soporta XLS, XLSX, Y CSV." />
                                </td>
                            </tr>
                            <tr>
                                <td class="rm_center_content">
                                    <asp:Button ID="btnVistaPrevia" CssClass="btns" runat="server" Text="Vista previa" OnClick="btnVistaPrevia_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="rm_content_paso2">					
							 <h2>Paso 2 - Cargar y validar im&aacute;genes</h2>
                            <h4>Seleccione las im&aacute;genes que desea subir. Y espere a que se complete el proceso de cargue. Luego Presione Validar</h4>
                            <div id= "div_paso2" runat="server" visible = "false">
								<div id="fuFiles">
									<asp:Button ID="BtnSelectImgs" runat="server" Text="Seleccione..." CssClass="btns OcultaButton" OnClick="BtnSelectImgs_Click"  />
									<div id="fuFiles2" class="file-upload-container">
										<input type="file" id="fileUpload" multiple="true" runat="server" />
										<label for="fileUpload" class="btns">Seleccione...</label>
									</div>
								</div>  
							
                            <br />
                            <div>
                                <asp:Button ID="btnValidateImages" runat="server" Text="Validar" CssClass="btns " OnClick="btnValidateImages_Click" />
                            </div>
                            <div>
                                <asp:Label ID="lblSummaryFiles" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="rm_panel_radicar">
                        <h2>Paso 3 - Radicar</h2>
						
                        <table style="display: none;">
                            <tr>
                                <td>
                                    <h3>Naturaleza</h3>
                                </td>
                                <td>
                                    <h3>Archivar en</h3>
                                </td>
                                <td>
                                    <h3>Acci&oacute;n</h3>
                                </td>
                                <td>
                                    <h3>Medio</h3>
                                </td>
                                <td>
                                    <h3>Expediente</h3>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtNaturalezas" runat="server" CssClass="rm_txtnaturalezas"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDependenciaDestino" runat="server" CssClass="rm_txtdestino"
                                        Enabled="False"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAccion" runat="server" CssClass="rm_txtaccion"
                                        Enabled="False"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMedio" runat="server" CssClass="rm_txtmedio"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtExpediente" runat="server" CssClass="rm_txtExpediente"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td colspan="4" class="rm_center_content"></td>
                            </tr>
                        </table>
                        <h4>Presione radicar, para realizar el proceso de radicacion masiva</h4>
                        <br />
                        <asp:Button ID="btnRadicar" CssClass="btns" runat="server" Text="Radicar" OnClick="btnRadicar_Click"
                            ToolTip="Esta funcionalidad aún no esta disponible" Enabled="false" />
                    </div>
                </div>

                <div class="rm_contenedormensaje">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblMessage0" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblMessage1" runat="server"></asp:Label>
                </div>
                <div id="pre_view" class="rm_preview_data_container" visible="false" runat="server">
                    <h2>Vista previa</h2>
					 <asp:Label ID="lblSummary" runat="server" Text="" ForeColor="Red"></asp:Label><br />
                    <asp:ListView ID="lstvVista" runat="server" OnPagePropertiesChanging="lstvVista_PagePropertiesChanging">
                        <LayoutTemplate>
                            <table class="rm_listview" cellspacing="0" cellpadding="3" rules="rows">
                                <tr>
                                    <th>
                                        <p>UBICACIÓN DANE DEL MUNICIPIO</p>
                                    </th>
                                    <th>
                                        <p>NIT PRESTADOR</p>
                                    </th>
                                    <th>
                                        <p>FACTURA PRESTADOR</p>
                                    </th>
                                    <th>
                                        <p>NOMBRE PRESTADOR</p>
                                    </th>
                                    <th>
                                        <p>REMISIÓN</p>
                                    </th>
                                    <th>
                                        <p>USUARIO OASIS</p>
                                    </th>
                                    <th>
                                        <p>FECHA DE CONFIRMACIÓN</p>
                                    </th>
                                    <th>
                                        <p>FECHA DE RADICACIÓN</p>
                                    </th>
                                    <th>
                                        <p>FECHA DE PRESTACIÓN</p>
                                    </th>
                                    <th>
                                        <p>UNIDAD DE ALMACENAMIENTO</p>
                                    </th>
                                    <th>
                                        <p>MODALIDAD CONTRATO</p>
                                    </th>
                                    <th></th>
                                </tr>
                                <tbody>
                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                </tbody>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <span id="Span1"><%# Eval("facn_ubicacion")%></span>
                                </td>
                                <td>
                                    <span id="Span27"><%# Eval("Facv_tercero")%></span>
                                </td>
                                <td>
                                    <span id="Span2"><%# Eval("facc_factura")%></span>
                                </td>
                                <td>
                                    <span id="Span3"><%# Eval("terc_nombre")%></span>
                                </td>
                                <td>
                                    <span id="Span4"><%# Eval("facn_recibo")%></span>
                                </td>
                                <td>
                                    <span id="Span5"><%# Eval("facv_imputable")%></span>
                                </td>
                                <td>
                                    <span id="Span7"><%# Eval("facf_confirmacion")%></span>
                                </td>
                                <td>
                                    <span id="Span9"><%# Eval("facf_radicado")%></span>
                                </td>
                                <td>
                                    <span id="Span28"><%# Eval("facf_final")%></span>
                                </td>
                                <td>
                                    <span id="Span29"><%# Eval("facc_almacenamiento")%></span>
                                </td>
                                <td>
                                    <span id="Span30"><%# Eval("conc_nombre")%></span>
                                </td>
                                <td>
                                    <span id="Span8" style="display: none;"><%# Eval("Facf_final")%></span>
                                    <span id="Span10" style="display: none;"><%# Eval("Facf_radicado")%></span>
                                    <span id="Span12" style="display: none;"><%# Eval("Facv_imputable")%></span>
                                    <span id="Span13" style="display: none;"><%# Eval("Facc_conciliado")%></span>
                                    <span id="Span14" style="display: none;"><%# Eval("Facv_responsable")%></span>
                                    <span id="Span15" style="display: none;"><%# Eval("Facv_copago")%></span>
                                    <span id="Span16" style="display: none;"><%# Eval("Facn_recibo")%></span>

                                    <span id="Span6" style="display: none;"><%# Eval("Facf_confirmacion")%></span>
                                    <span id="Span17" style="display: none;"><%# Eval("Terc_nombre")%></span>
                                    <span id="Span18" style="display: none;"><%# Eval("Facc_alto_costo")%></span>
                                    <span id="Span19" style="display: none;"><%# Eval("Facc_factura")%></span>


                                    <span id="Span20" style="display: none;"><%# Eval("Facn_factura2")%></span>
                                    <span id="Span21" style="display: none;"><%# Eval("Facc_prefijo")%></span>
                                    <span id="Span22" style="display: none;"><%# Eval("Facc_estado")%></span>
                                    <span id="Span23" style="display: none;"><%# Eval("Facv_total")%></span>

                                    <span id="Span24" style="display: none;"><%# Eval("Facn_empresa")%></span>
                                    <span id="Span25" style="display: none;"><%# Eval("Facc_documento")%></span>
                                    <span id="Span26" style="display: none;"><%# Eval("Facn_ubicacion")%></span>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="lblVacioTodos" CssClass="wf_label_vacio" runat="server" Text="No hay facturas para cargar<br/>">
                            </asp:Label>
                        </EmptyDataTemplate>
                    </asp:ListView>
                   
                    <div class="rm_pager_container">
                        <asp:Label ID="lblTotal" runat="server"></asp:Label>
                        <br />
                        <asp:DataPager ID="dprPagerPreview" PagedControlID="lstvVista" PageSize="10" runat="server" >
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Link" NextPageText="Siguiente" PreviousPageText="Anterior" ShowFirstPageButton="true" LastPageText="Ultimo"
                                    ShowLastPageButton="true" FirstPageText="Primero" />
                            </Fields>
                        </asp:DataPager>
                    </div>

                </div>
                <div id="resumen" class="rm_preview_data_container" visible="false" runat="server">
                    <h2>RESUMEN DEL PROCESO DE RADICACI&Oacute;N</h2>
                    <img alt="Warning" src="image/warning.png" />
                    <asp:ListView ID="lstv_resumen" runat="server" OnPagePropertiesChanging="lstv_resumen_PagePropertiesChanging">
                        <LayoutTemplate>
                            <table class="rm_listview" cellspacing="0" cellpadding="3" rules="rows">
                                <tr>
                                    <th>
                                        <p>RADICADO C&Oacute;DIGO</p>
                                    </th>
                                    <th>
                                        <p>FECHA RADICACI&Oacute;N</p>
                                    </th>
                                    <th>
                                        <p>EXPEDIENTE</p>
                                    </th>
                                    <th>
                                        <p>IM&Aacute;GENES</p>
                                    </th>
                                </tr>
                                <tbody>
                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                </tbody>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <span id="spm_radicado"><%# Eval("RadicadoCodigo")%></span>
                                </td>
                                <td>
                                    <span id="spm_fecha"><%# Eval("FechaRadicacion")%></span>
                                </td>
                                <td>
                                    <span id="spm_expediente"><%# Eval("ExpedienteNombre")%></span>
                                </td>
                                <td>
                                    <span id="spm_imagen"><%# Eval("Imagen")%></span>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="lblVacioResumen" CssClass="wf_label_vacio" runat="server" Text="No se radicó ningún dato.">
                            </asp:Label>
                        </EmptyDataTemplate>
                    </asp:ListView>
                    <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                    <div class="rm_pager_container">
                        <asp:Label ID="lblTotalResumen" runat="server"></asp:Label>
                        <br />
                        <asp:DataPager ID="dprResumen" PagedControlID="lstv_resumen" PageSize="10" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Link" NextPageText="Siguiente" PreviousPageText="Anterior" ShowFirstPageButton="true" LastPageText="Ultimo"
                                    ShowLastPageButton="true" FirstPageText="Primero" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                </div>
            </div>
            <%--<div id="dialog-confirm" title="Continuar?">
                  <p><span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 20px 0;"></span>Recuerde que debe realizar el proceso de cargue de imágenes. ¿ Desea validar las imágenes ahora?</p>
                </div>--%>
            <div class="rm_foother">
            </div>
        </div>
        
    </form>
</body>
</html>
