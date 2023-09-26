<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recepcion.aspx.cs" Inherits="WebApplication1.RecepcionFisicaDocumentos.Recepcion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Recepci&oacute;n f&iacute;sica documentos</title>

    <script src="../Scripts/jquery-1.8.2.js" type="text/javascript"></script>  
    <script src="script/RadicacionMasiva.js" type="text/javascript"></script>        
    <script src="../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <link href="../Styles/smoothness/jquery-ui-1.9.1.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/smoothness/jquery-ui-1.9.1.custom.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-ui-1.9.1.custom.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.9.1.custom.min.js" type="text/javascript"></script>
    <script src="script/RadRegScrips.js" type="text/javascript"></script>
    <script src="script/jquery.uploadify.v2.1.4.min.js" type="text/javascript"></script>
    <script src="script/swfobject.js" type="text/javascript"></script>
    <link href="css/uploadify.css" rel="stylesheet" type="text/css" />
    <link href="css/DocFisicosStyle.css" rel="stylesheet" type="text/css" />
    <script src="script/RecepFisicaScript.js" type="text/javascript"></script>
    <style type="text/css">
        .btns
        {}
    </style>

</head>
    <body>

        <form id="form2" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
            <ContentTemplate>
             <div class="rm_all_container">
                <div class = "rm_header">                    
                    <h1>Entrega Documentos F&iacute;sicos</h1>
                </div>
                <div class="rm_content">
                    <div id="resumen" class = "rm_preview_data_container" runat="server">
                        <asp:ListView ID="lstv_resumen" runat="server" OnPagePropertiesChanging="lstv_resumen_PagePropertiesChanging">
                            <LayoutTemplate>
                                <table class="rm_listview"  cellspacing="0" cellpadding="3" rules="rows">
                                    <tr>                               
                                        <th>
                                            <p>NRO. RADICADO</p>
                                        </th>
                                        <th>
                                            <p>PROCEDENCIA</p>
                                        </th>
                                        <th class="desaparecer"> 
                                            <p>GRUPO</p>
                                        </th>
                                        <th>
                                            <p>FECHA RADICACI&Oacute;N / REGISTRO</p>
                                        </th>
                                        <th>
                                            <p>DEPENDENCIA ORIGEN</p>
                                        </th>
                                         <th>
                                            <p>MARCAR</p>
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
                                        <span id="spm_radicado" runat="server"><%# Eval("NumeroDocumento")%></span>
                                    </td>
                                    <td >                                        
                                        <span id="spm_procedencia" runat="server"><%# Eval("ProcedenciaNombre")%></span>
                                    </td>
                                    <td class="desaparecer">                                        
                                        <span id="Span2" runat="server"><%# Eval("GrupoCodigo")%></span>
                                    </td>
                                    <td >
                                        <span id="spm_fecha" runat="server"><%# Eval("wfmovimientoFecha")%></span>
                                    </td>
                                    <td >
                                        <span id="spm_Coddestino" runat="server"><%# Eval("DependenciaNombre")%></span>
                                    </td>
                                     <td >
                                        <asp:CheckBox ID="cbxDocumento" runat="server"></asp:CheckBox>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <asp:Label ID="lblVacioResumen" CssClass="wf_label_vacio" runat="server" Text="No tiene documentos para recibir en este momento.">
                                </asp:Label>
                            </EmptyDataTemplate>
                        </asp:ListView>
                        <div class="rm_pager_container">
                            <asp:Label ID="lblTotalResumen" runat="server"></asp:Label>
                            <br />                        
                            <asp:DataPager ID="dprResumen" PagedControlID="lstv_resumen" PageSize="25" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Link" NextPageText="Siguiente" PreviousPageText="Anterior" ShowFirstPageButton ="true" LastPageText="Ultimo"
                                    ShowLastPageButton="true" FirstPageText="Primero"/>                                    
                                </Fields>
                            </asp:DataPager>
                        </div>
                        <br />
                        <br />
                        <div class = "btnContainer_fisicos">
                            <asp:Button ID="btnDescargar" Text="Descargar" runat="server" CssClass="btns" 
                            onclick="btnDescargar_Click"/> 
                        </div>                      
                        <br />                       
                    </div>
                </div>
                <%--<div id="dialog-confirm" title="Continuar?">
                  <p><span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 20px 0;"></span>Recuerde que debe realizar el proceso de cargue de imágenes. ¿ Desea validar las imágenes ahora?</p>
                </div>--%>
                <div class="rm_foother">
                
                </div>                
            </div>
                
            </ContentTemplate>
            
            <div id="editForm" class="editForm">
               <table style="width:100%;" cellpadding="5" cellspacing="0">
                  <tr class="headerRow">
                     <td>Resumen</td>
                     <td style="text-align: right;">
                        <a onclick="CloseDialog();" style="cursor: pointer;">Cerrar</a>
                     </td>
                  </tr>
                  <%--<tr>
                     <td align="left">Detalle:</td>
                     <td align="left"><span id="spanRta"></span></td>
                  </tr>--%>
               </table>
               <div class = "rm_resumen_data_container">
                    <h2>Usted ha recibido los siguientes documentos</h2>
                    <br />
                    <asp:ListView ID="lstvDescargados" runat="server" OnPagePropertiesChanging="lstvDescargados_PagePropertiesChanging">
                            <LayoutTemplate>
                                <table class="rm_listview_resultado"  cellspacing="0" cellpadding="3" rules="rows">
                                    <tr>                               
                                        <th>
                                            <p>NRO. RADICADO</p>
                                        </th>
                                        <th>
                                            <p>PROCEDENCIA</p>
                                        </th>
                                        <th> 
                                            <p>GRUPO</p>
                                        </th>
                                        <th>
                                            <p>FECHA RADICACI&Oacute;N / REGISTRO</p>
                                        </th>
                                        <th>
                                            <p>DEPENDENCIA ORIGEN</p>
                                        </th>
                                        <th>
                                            <p>FECHA RECEPCION</p>
                                        </th>
                                         <th>
                                            <p>ESTADO</p>
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
                                        <span id="spm_radicado" runat="server"><%# Eval("NumeroDocumento")%></span>
                                    </td>
                                    <td >                                        
                                        <span id="spm_procedencia" runat="server"><%# Eval("ProcedenciaNombre")%></span>
                                    </td>
                                    <td class="desaparecer">                                        
                                        <span id="Span2" runat="server"><%# Eval("GrupoCodigo")%></span>
                                    </td>
                                    <td >
                                        <span id="spm_fecha" runat="server"><%# Eval("wfmovimientoFecha")%></span>
                                    </td>
                                    <td >
                                        <span id="spm_Coddestino" runat="server"><%# Eval("DependenciaNombre")%></span>
                                    </td>
                                    <td>
                                        <span id="spm_fechaRecibido" runat="server"><%# Eval("FechaVencimiento")%></span>
                                    </td>
                                     <td >
                                         <asp:Label ID="Label2" runat="server" Text="RECIBIDO"></asp:Label>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <asp:Label ID="lblVacioResumen" CssClass="wf_label_vacio" runat="server" Text="No se descargó ningún documento.">
                                </asp:Label>
                            </EmptyDataTemplate>
                        </asp:ListView>
                        <br />
                        <div class="rm_pager_container">
                            <asp:Label ID="lblCantidadDescargados" runat="server"></asp:Label>
                            <br />                        
                            <asp:DataPager ID="dprDescargados" PagedControlID="lstvDescargados" PageSize="10" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Link" NextPageText="Siguiente" PreviousPageText="Anterior" ShowFirstPageButton ="true" LastPageText="Ultimo"
                                    ShowLastPageButton="true" FirstPageText="Primero"/>                                    
                                </Fields>
                            </asp:DataPager>
                        </div>
               </div>
            </div>      
        </form>
    </body>
</html>

