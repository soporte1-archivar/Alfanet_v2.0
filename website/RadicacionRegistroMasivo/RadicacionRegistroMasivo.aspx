<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RadicacionRegistroMasivo.aspx.cs" Inherits="WebApplication1.RadicacionRegistroMasivo.RadicacionRegistroMasivo" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Radicaci&oacute;n masiva</title>

    <script src="../Scripts/jquery-1.8.2.js" type="text/javascript"></script>
    <%--<script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>--%>    <%--<script src="../Scripts/jquery-1.8.2-vsdoc.js" type="text/javascript"></script>--%>
    <script src="script/RadicacionMasiva.js" type="text/javascript"></script>
    <link href="css/radicacionmasivastyle.css" rel="stylesheet" type="text/css" />    
    <script src="../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <link href="../Styles/smoothness/jquery-ui-1.9.1.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/smoothness/jquery-ui-1.9.1.custom.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-ui-1.9.1.custom.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.9.1.custom.min.js" type="text/javascript"></script>
    <script src="script/RadRegScrips.js" type="text/javascript"></script>
    <%--<script src="script/jquery-1.4.4-vsdoc.js" type="text/javascript"></script>--%>    <%--<script src="script/jquery-1.4.4.min.js" type="text/javascript"></script>--%>
    <script src="script/jquery.uploadify.v2.1.4.min.js" type="text/javascript"></script>
    <script src="script/swfobject.js" type="text/javascript"></script>
    <link href="css/uploadify.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        $(document).ready(function () {
            $('#fuFiles').uploadify({
                'uploader': 'image/uploadify.swf',
                'script': 'FileUploads.aspx',
                'cancelImg': 'image/cancel.png',
                'auto': 'true',
                'multi': 'true',
                'buttonText': 'Seleccione...',
                'queueSizeLimit': 50
            });
        });

        function ImpresionSticker() 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../RadicacionRegistroMasivo/Sticker/Sticker.aspx', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes,menubar=yes');
        }


    </script>

</head>
    <body>
        <form id="form1" runat="server">
            <div class="rm_all_container">
                <div class = "rm_header">                    
                    <h1>Radicaci&oacute;n masiva</h1>                    
                </div>
                <div class="rm_content">
                    <div class = "rm_optios_container">
                         <div class = "rm_preview_container" ID="divInicial" runat="server">
                            <h2>Paso 1 - Seleccione el tipo de documento</h2>                            
                            <table>
                                <tr>
                                    <td>
                                       <div id="myTabs">
                                          
                                            <ul class="tabs">
                                                <li><a href="#tab-1" class="active">Radicados</a></li>
                                                <li><a href="#tab-2">Registros</a></li>                                               
                                            </ul>
                                          
                                          <div id="tab-1">
                                              <table border="0" cellpadding="0" cellspacing="0">
                                              <tr>
                                                  <td>
                                                  <asp:HyperLink ID="hlRadicadoTemplate" NavigateUrl="../RadicacionRegistroMasivo/UpTemplates/Radicado.xlsx" Text = "Descargue aqui el formato de radicacion masiva" runat="server" />                                                     
                                                  <td>
                                                  <asp:Button ID="btnRadicados" Text="Siguiente" CssClass="btns2" runat="server"  onclick="btnRadicados_Click" />
                                                  </td>
                                                </tr>
                                              </table>
                                        </div>
                                          <div id="tab-2" style="display:none;">
                                          <table>
                                          <tr>
                                          <td>
                                          <asp:HyperLink ID="hlRegistroTemplate" NavigateUrl="../RadicacionRegistroMasivo/UpTemplates/Registro.xlsx" Text = "Descargue aqui el formato de registro masivo" runat="server"/>
                                          </td>
                                          <td>
                                          <asp:Button ID="btnRegistro" Text="Siguiente" CssClass="btns2" runat="server"  onclick="btnRegistros_Click"/>
                                          </td>
                                          </tr>
                                          </table>
                                         </div> 
                                        </div>
                                                                          
                                    </td>
                                </tr>
                                <tr>
                                    <td class="rm_center_content">
                                    
                                     
                                </tr>
                                <tr>
                                    <td class="rm_center_content">                                    
                                            </td>
                                </tr>
                            </table>
                        </div>
                         <div class = "rm_preview_container">
                            <h2>Paso 2 - Cargar Archivo</h2>                            
                            <table>
                                <tr>
                                    <td>
                                        <h4>Seleccione el archivo con los datos a radicar. (.xls, .xlsx, .csv)</h4>                                    
                                    </td>
                                </tr>
                                <tr>
                                    <td class="rm_center_content">
                                        <asp:FileUpload ID="fuFileToImport" runat="server"
                                            ToolTip="Soporta XLS, XLSX, Y CSV." enabled="false"/>
                                    </td>                                    
                                </tr>
                                <tr>
                                    <td class="rm_center_content">                                    
                                            <asp:Button ID="btnVistaPrevia" CssClass = "btns" runat="server" 
                                                Text="Vista previa" enabled="false" onclick="btnVistaPrevia_Click"  />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class = "rm_content_paso2">
                            <h2>Paso 3 - Cargar y validar im&aacute;genes</h2>
                            <h4>Seleccione las im&aacute;genes que desea subir. Y espere a que se complete el proceso de cargue. Luego Presione Validar</h4>
                            <div id= "div_paso2" runat="server" visible = "false">
                                <div id="fuFiles">
            
                                </div>                          
                        
                                <br />
                                <div>
                                    <asp:Button ID="btnValidateImages" runat="server" Text="Validar" 
                                        CssClass = "btns" enabled="false" onclick="btnValidateImages_Click"/>
                                </div>
                                <div>
                                        <asp:Label ID="lblSummaryFiles" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="rm_panel_radicar">
                        <h2>Paso 4 - Radicar</h2>
                            <table style = "display:none;">
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
                                    <td colspan = "4" class="rm_center_content">                                
                                            
                                    </td>
                                </tr>
                            </table>
                            <h4>Presione radicar, para realizar el proceso de radicacion masiva</h4><br />
                            <asp:Button ID="btnRadicar" CssClass = "btns" runat="server" Text="Radicar" 
                                ToolTip="Esta funcionalidad aún no esta disponible" Enabled="False" 
                                onclick="btnRadicar_Click" />
                            <br />
                            <br />
                            <asp:Button ID="btnSticker" CssClass = "btns" runat="server" 
                                Text="Imprimir Sticker" ToolTip="Esta funcionalidad aún no esta disponible" 
                                OnClientClick="ImpresionSticker(); return false;" />
                        </div>
                    </div>                  
                    <div class="rm_contenedormensaje">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblMessage0" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblMessage1" runat="server"></asp:Label>
                    </div>
                    <div id="pre_view" class = "rm_preview_data_container" visible = "false" runat="server">
                        <h2>Vista previa</h2>

                        <asp:ListView ID="lsvRegistroMasivo" runat="server" >
                            <LayoutTemplate>
                                <table class="rm_listview"  cellspacing="0" cellpadding="3" rules="rows">
                                    <tr>                               
                                        <th>
                                            <p>RADICADO FUENTE</p>
                                        </th>
                                        <th>
                                            <p>NIT</p>
                                        </th>
                                        <th>
                                            <p>FUNCIONARIO</p>
                                        </th>
                                        <th>
                                            <p>MEDIO</p>
                                        </th>
                                        <th> 
                                             <p>ASUNTO</p>                                   
                                        </th>
                                        <th>
                                            <p>SERIE</p>
                                        </th>                                
                                        <th>
                                            <p>NATURALEZA CODIGO</p>
                                        </th>
                                        <th>
                                            <p>Tipo Documento</p>
                                                                     
                                    </tr>
                                    <tbody>
                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr >   
                                    <td >                                        
                                        <span id="Span1"><%# Eval("RadicadoFuente")%></span>
                                    </td>                                                
                                    <td >
                                        <span id="Span27"><%# Eval("ProcedenciaNUI")%></span>
                                    </td>
                                    <td >
                                        <span id="Span6"><%# Eval("DependenciaDestino")%></span>
                                    </td>
                                    <td >
                                        <span id="Span2"><%# Eval("MedioCodigo")%></span>
                                    </td>
                                    <td >
                                        <span id="Span3"><%# Eval("RadicadoDetalle")%></span>
                                    </td>
                                    <td >
                                        <span id="Span4"><%# Eval("SerieCodigo")%></span>                            
                                    </td>
                                    <td >
                                        <span id="Span5"><%# Eval("NaturalezaCodigo")%></span>                            
                                    </td >
                                    <td >
                                        <span id="Span7"><%# Eval("TipoDocumento")%></span>                            
                                    </td > 
                                                                                                                     
                                    <td >                               
                                       <%-- <span id="Span8" style="display:none;"><%# Eval("Facf_final")%></span>                                 
                                        <span id="Span10" style="display:none;"><%# Eval("Facf_radicado")%></span>                                        
                                        <span id="Span12" style="display:none;"><%# Eval("Facv_imputable")%></span>
                                        <span id="Span13" style="display:none;"><%# Eval("Facc_conciliado")%></span> 
                                        <span id="Span14" style="display:none;"><%# Eval("Facv_responsable")%></span>
                                        <span id="Span15" style="display:none;"><%# Eval("Facv_copago")%></span> 
                                        <span id="Span16" style="display:none;"><%# Eval("Facn_recibo")%></span>

                                        <span id="Span6" style="display:none;"><%# Eval("Facf_confirmacion")%></span> 
                                        <span id="Span17" style="display:none;"><%# Eval("Terc_nombre")%></span>
                                        <span id="Span18" style="display:none;"><%# Eval("Facc_alto_costo")%></span> 
                                        <span id="Span19" style="display:none;"><%# Eval("Facc_factura")%></span>


                                        <span id="Span20" style="display:none;"><%# Eval("Facn_factura2")%></span> 
                                        <span id="Span21" style="display:none;"><%# Eval("Facc_prefijo")%></span>
                                        <span id="Span22" style="display:none;"><%# Eval("Facc_estado")%></span> 
                                        <span id="Span23" style="display:none;"><%# Eval("Facv_total")%></span>

                                        <span id="Span24" style="display:none;"><%# Eval("Facn_empresa")%></span> 
                                        <span id="Span25" style="display:none;"><%# Eval("Facc_documento")%></span>
                                        <span id="Span26" style="display:none;"><%# Eval("Facn_ubicacion")%></span>--%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <asp:Label ID="lblVacioTodos" CssClass="wf_label_vacio" runat="server" Text="No hay facturas para cargar<br/>">
                                </asp:Label>
                            </EmptyDataTemplate>
                        </asp:ListView>


                         <asp:ListView ID="lstvVista" runat="server" >
                            <LayoutTemplate>
                                <table class="rm_listview"  cellspacing="0" cellpadding="3" rules="rows">
                                    <tr>                               
                                        <th>
                                            <p>RADICADO PADRE</p>
                                        </th>
                                        <th>
                                            <p>FECHA IMPOSICION</p>
                                        </th>
                                        <th>
                                            <p>PLACA DEL VEHICULO</p>
                                        </th>
                                        <th> 
                                             <p>CODIGO DE LA INFRACCION</p>                                   
                                        </th>
                                        <th>
                                            <p>OBSERVACIONES</p>
                                        </th>                                
                                        <th>
                                            <p>MEDIO DE RECEPCION</p>
                                        </th>
                                        <th>
                                            <p>ANEXOS</p>
                                        </th>
                                        <th>
                                            <p>NIT</p>
                                        </th>
                                        <th>
                                            <p>RADICADOR</p>
                                        </th>
                                        <th>
                                            <p>IUIT</p>
                                        </th>
                                         
                                        <th>                                    
                                        </th>                              
                                    </tr>
                                    <tbody>
                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr >   
                                    <td >                                        
                                        <span id="Span1"><%# Eval("radicadoPadre")%></span>
                                    </td>                                                
                                    <td >
                                        <span id="Span27"><%# Eval("fechaImposicion")%></span>
                                    </td>
                                    <td >
                                        <span id="Span2"><%# Eval("placaVehiculo")%></span>
                                    </td>
                                    <td >
                                        <span id="Span3"><%# Eval("codInfraccion")%></span>
                                    </td>
                                    <td >
                                        <span id="Span4"><%# Eval("observaciones")%></span>                            
                                    </td>
                                    <td >
                                        <span id="Span5"><%# Eval("medioNombre")%></span>                            
                                    </td >
                                    <td >
                                        <span id="Span7"><%# Eval("anexo")%></span>                            
                                    </td > 
                                    <td >
                                        <span id="Span9"><%# Eval("procedenciaNUI")%></span>                            
                                    </td > 
                                    <td >
                                        <span id="Span28"><%# Eval("DependenciaCodigo")%></span>                            
                                    </td >
                                    <td >
                                        <span id="Span29"><%# Eval("IUIT")%></span>                            
                                    </td > 
                                                                                                                     
                                    <td >                               
                                       <%-- <span id="Span8" style="display:none;"><%# Eval("Facf_final")%></span>                                 
                                        <span id="Span10" style="display:none;"><%# Eval("Facf_radicado")%></span>                                        
                                        <span id="Span12" style="display:none;"><%# Eval("Facv_imputable")%></span>
                                        <span id="Span13" style="display:none;"><%# Eval("Facc_conciliado")%></span> 
                                        <span id="Span14" style="display:none;"><%# Eval("Facv_responsable")%></span>
                                        <span id="Span15" style="display:none;"><%# Eval("Facv_copago")%></span> 
                                        <span id="Span16" style="display:none;"><%# Eval("Facn_recibo")%></span>

                                        <span id="Span6" style="display:none;"><%# Eval("Facf_confirmacion")%></span> 
                                        <span id="Span17" style="display:none;"><%# Eval("Terc_nombre")%></span>
                                        <span id="Span18" style="display:none;"><%# Eval("Facc_alto_costo")%></span> 
                                        <span id="Span19" style="display:none;"><%# Eval("Facc_factura")%></span>


                                        <span id="Span20" style="display:none;"><%# Eval("Facn_factura2")%></span> 
                                        <span id="Span21" style="display:none;"><%# Eval("Facc_prefijo")%></span>
                                        <span id="Span22" style="display:none;"><%# Eval("Facc_estado")%></span> 
                                        <span id="Span23" style="display:none;"><%# Eval("Facv_total")%></span>

                                        <span id="Span24" style="display:none;"><%# Eval("Facn_empresa")%></span> 
                                        <span id="Span25" style="display:none;"><%# Eval("Facc_documento")%></span>
                                        <span id="Span26" style="display:none;"><%# Eval("Facn_ubicacion")%></span>--%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <asp:Label ID="lblVacioTodos" CssClass="wf_label_vacio" runat="server" Text="No hay facturas para cargar<br/>">
                                </asp:Label>
                            </EmptyDataTemplate>
                        </asp:ListView>
                        <asp:Label ID="lblSummary" runat="server" Text="" ForeColor="Red"></asp:Label>
                        <div class="rm_pager_container">
                            <asp:Label ID="lblTotal" runat="server"></asp:Label>
                            <br />                        
                            <asp:DataPager ID="dprPagerPreview" PagedControlID="lstvVista" PageSize="10" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Link" NextPageText="Siguiente" PreviousPageText="Anterior" ShowFirstPageButton ="true" LastPageText="Ultimo"
                                    ShowLastPageButton="true" FirstPageText="Primero"/>                                    
                                </Fields>
                            </asp:DataPager>
                        </div>

                    </div>
                    <div id="resumen" class = "rm_preview_data_container" visible = "false" runat="server">
                        <h2>RESUMEN DEL PROCESO DE RADICACI&Oacute;N</h2><img alt = "Warning" src ="image/warning.png" />
                        <asp:ListView ID="lstv_resumen" runat="server">
                            <LayoutTemplate>
                                <table class="rm_listview"  cellspacing="0" cellpadding="3" rules="rows">
                                    <tr>                               
                                        <th>
                                            <p>RADICADO C&Oacute;DIGO</p>
                                        </th>
                                        <th>
                                            <p>FECHA RADICACI&Oacute;N / REGISTRO</p>
                                        </th>
                                        <th>
                                            <p>DEPENDENCIA CODIGO DESTINO</p>
                                        </th>
                                        <th>
                                            <p>PROCEDENCIA DESTINO</p>
                                        </th>
                                        <th>
                                            <p>IUIT (Radicacion)</p>
                                        </th>
                                        <th> 
                                               
                                        </th>                                                                      
                                    </tr>
                                    <tbody>
                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr >   
                                    <td >                                        
                                        <span id="spm_radicado"><%# Eval("NumeroDocumento")%></span>
                                    </td>
                                    <td >
                                        <span id="spm_fecha"><%# Eval("wfmovimientoFecha")%></span>
                                    </td>
                                    <td >
                                        <span id="spm_Coddestino"><%# Eval("Coddestino")%></span>
                                    </td>
                                    <td >
                                        <span id="Span8"><%# Eval("ProcedenciaNui")%></span>
                                    </td>
                                    <td >
                                        <span id="Span10"><%# Eval("IUIT")%></span>
                                    </td>
                                    <td >
                                     
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
                                    <asp:NextPreviousPagerField ButtonType="Link" NextPageText="Siguiente" PreviousPageText="Anterior" ShowFirstPageButton ="true" LastPageText="Ultimo"
                                    ShowLastPageButton="true" FirstPageText="Primero"/>                                    
                                </Fields>
                            </asp:DataPager>
                        </div>
                    </div>
                </div>
                <%# Eval("RadicadoFuente")%>
                <div class="rm_foother">
                
                </div>                
            </div>
        </form>
    </body>
</html>
