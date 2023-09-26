<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WorkFlow.aspx.cs" Inherits="WebApplication1.WorkFlow.WorkFlow" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/jquery-1.8.2-vsdoc.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.9.1.custom.js" type="text/javascript"></script>
    <link href="../Styles/smoothness/jquery-ui-1.9.1.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/smoothness/jquery-ui-1.9.1.custom.min.css" rel="stylesheet" type="text/css" />
    <script src="script/wf_menu.js" type="text/javascript"></script>
    <script src="script/Autocomplete.js" type="text/javascript"></script>
    <script src="script/Procesos.js" type="text/javascript"></script>
    <link href="css/workflowstyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class = "wf_contenedor">
        <asp:UpdatePanel ID="updatePanel1" runat="server"> 
            <ContentTemplate>            
        <div class = "wf_busqueda">
            <table class="wf_table_busqueda">
                <tr>
                    <td>
                        <h2>Buscar</h2>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBuscar" CssClass="wf_txtbuscar" runat="server"></asp:TextBox>
                    </td>
                    <td> 
                         <asp:ImageButton ID="ibtnBuscar" CssClass="wf_btnBuscar" runat="server" 
                             ImageUrl="~/WorkFlow/image/lupa.png" onclick="ibtnBuscar_Click" />
                    </td>
                </tr>                
            </table>
        </div>
        <div class="wf_toolbar">
           <div class="wf_vacio">
                
           </div>
           <div id="pnlContenedorBotones" class="wf_contenedor_botones">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnFinalizar" CssClass="thoughtbot" runat="server" 
                            Text="Finalizar" OnClientClick="this.disabled=true;this.value='Enviando...';"
                            UseSubmitBehavior="false" onclick="btnFinalizar_Click" />
                    </td>
                    <td>
                        
                    </td>
                </tr>
            </table>               
           </div>
        </div>
        <div class="wf_contenedor_menu">
            <h4>Documentos recibidos externos</h4>
            <div class="wf_menu">
                <ul class="tabs">
                    <li><a href="#tab-1" class="active">Todos</a></li>
                    <li><a href="#tab-2">Documentos vencidos</a></li>
                    <li><a href="#tab-3">Pr&oacute;ximos a vencer</a></li>                    
                    <li><a href="#tab-4">Documentos pendientes</a></li>
                    <h4>Documentos enviados externos</h4>
                    <li><a href="#tab-5">Copia externos</a></li>
                    <h4>Documentos enviados internos</h4>
                    <li><a href="#tab-6">Enviados internos</a></li>
                    <li><a href="#tab-7">Enviados internos copia</a></li>
                    <h4>Documentos en seguimiento</h4>
                    <li><a href="#tab-8">Documentos anteriores</a></li>  
                </ul>
            </div>           
        </div>
        <div class= "tab-container">
            <div id="tab-1" class="wf_tab_content">
                <h3>Todos los documentos recibidos externos</h3>
                <asp:ListView ID="lstvTodos" runat="server" OnPagePropertiesChanging="lstvTodos_PagePropertiesChanging" >
                    <LayoutTemplate>
                        <table class="wf_listview" cellspacing="0" cellpadding="3" rules="rows">
                            <tr>
                                <th>
                                    
                                </th>
                                <th>
                                    <p>Nº RADICADO</p>
                                </th>
                                <th>
                                    <p>PROCEDENCIA</p>
                                </th>
                                <th>
                                    <p>NATURALEZA</p>
                                </th>
                                <th>                                    
                                </th>
                                <th>
                                    <p>PROVIENE DE</p>
                                </th>                                
                                <th>
                                    <p>DETALLE</p>
                                </th>
                                <th>
                                    <p>FECHA RADICACION</p>
                                </th>
                            </tr>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr >
                            <td>
                                <asp:CheckBox ID="cbxTodos"  CssClass="wf_checkbox" runat="server" />
                            </td>
                            <td onclick="showdocument(this);" >
                                <span id="Span1"><%# Eval("NumeroDocumento")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span2"><%# Eval("procedenciaNombre")%></span>                          
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span3"><%# Eval("naturalezaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span4" style="display:none;"><%# Eval("wfAccionNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span5"><%# Eval("dependenciaNombre")%></span>                            
                            </td >                                                       
                            <td onclick="showdocument(this);">
                                <span id="Span7"><%# Eval("radicadoDetalle")%></span>
                                <span id="Span8" style="display:none;"><%# Eval("FechaVencimiento")%></span>                                 
                                <span id="Span10" style="display:none;"><%# Eval("NumeroExterno")%></span> 
                                <span id="Span11" style="display:none;"><%# Eval("FechaProcedencia")%></span> 
                                <span id="Span12" style="display:none;"><%# Eval("MedioNombre")%></span>
                                <span id="Span13" style="display:none;"><%# Eval("ExpedienteNombre")%></span> 
                                <span id="Span14" style="display:none;"><%# Eval("DependenciaDestino")%></span>
                                <span id="Span15" style="display:none;"><%# Eval("Anexo")%></span> 
                                <span id="Span16" style="display:none;"><%# Eval("Respuesta")%></span>
                            </td>
                            <td>
                                <span id="Span9"><%# Eval("FechaRadicacion")%></span>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <asp:Label ID="lblVacioTodos" CssClass="wf_label_vacio" runat="server" Text="No tiene documentos en este momento !!!">
                        </asp:Label>
                    </EmptyDataTemplate>
                </asp:ListView>
                <div class = "wf_pager_container">
                    <asp:DataPager ID="dprTodos" runat="server" PagedControlID="lstvTodos" PageSize="10">
                        <Fields>
                        <asp:NumericPagerField NextPageText=">>" PreviousPageText="<<" 
                                NextPreviousButtonCssClass="wf_pager" ButtonType="Link" 
                                NumericButtonCssClass="wf_pager" />
                    </Fields>
                    </asp:DataPager>
                    <br /><br />
                </div>
            </div>
            <div id="tab-2" class="wf_tab_content" style="display:none;">
                <h3>Documentos vencidos</h3>
                <asp:ListView ID="lstvDocumentosVencidos" runat="server" OnPagePropertiesChanging="lstvDocumentosVencidos_PagePropertiesChanging" >
                    <LayoutTemplate>
                        <table class="wf_listview" cellspacing="0" cellpadding="3" rules="rows">
                            <tr>
                                <th>
                                    
                                </th>
                                <th>
                                    <p>Nº RADICADO</p>
                                </th>
                                <th>
                                    <p>PROCEDENCIA</p>
                                </th>
                                <th>
                                    <p>NATURALEZA</p>
                                </th>
                                <th>                                    
                                </th>
                                <th>
                                    <p>PROVIENE DE</p>
                                </th>                                
                                <th>
                                    <p>DETALLE</p>
                                </th>
                                <th>
                                    <p>FECHA RADICACION</p>
                                </th>
                            </tr>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class="wf_fila_documento">
                            <td>
                                <asp:CheckBox ID="cbxDocsVencidos" CssClass="wf_checkbox" runat="server" />
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span1"><%# Eval("numeroDocumento")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span2"><%# Eval("procedenciaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span3"><%# Eval("naturalezaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span4" style="display:none;"><%# Eval("wfAccionNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span5"><%# Eval("dependenciaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span6"><%# Eval("WFMovimientoNotas")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span7"><%# Eval("radicadoDetalle")%></span>
                                <span id="Span8" style="display:none;"><%# Eval("FechaVencimiento")%></span>                                
                                <span id="Span10" style="display:none;"><%# Eval("NumeroExterno")%></span> 
                                <span id="Span11" style="display:none;"><%# Eval("FechaProcedencia")%></span> 
                                <span id="Span12" style="display:none;"><%# Eval("MedioNombre")%></span>
                                <span id="Span13" style="display:none;"><%# Eval("ExpedienteNombre")%></span> 
                                <span id="Span14" style="display:none;"><%# Eval("DependenciaDestino")%></span>
                                <span id="Span15" style="display:none;"><%# Eval("Anexo")%></span> 
                                <span id="Span16" style="display:none;"><%# Eval("Respuesta")%></span>                           
                            </td>
                            <td>
                                <span id="Span9"><%# Eval("FechaRadicacion")%></span>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <asp:Label ID="lblVacioVencidos" CssClass="wf_label_vacio" runat="server" Text="No tiene documentos vencidos en este momento !!!">
                        </asp:Label>
                    </EmptyDataTemplate>
                </asp:ListView>
                <div class = "wf_pager_container">
                    <asp:DataPager ID="dprDocsVencidos" runat="server" PagedControlID="lstvDocumentosVencidos" PageSize="10">
                        <Fields>
                        <asp:NumericPagerField NextPageText=">>" PreviousPageText="<<" 
                                NextPreviousButtonCssClass="wf_pager" ButtonType="Link" 
                                NumericButtonCssClass="wf_pager" />
                    </Fields>
                    </asp:DataPager>
                    <br /><br />
                </div>
            </div>
            <div id="tab-3" class="wf_tab_content" style="display:none;">
                <h3>Documentos pr&oacute;ximos a vencer</h3>
                <asp:ListView ID="lstvProximosAVencer" runat="server" OnPagePropertiesChanging="lstvProximosAVencer_PagePropertiesChanging" >
                    <LayoutTemplate>
                        <table class="wf_listview" cellspacing="0" cellpadding="3" rules="rows">
                            <tr>
                                <th>
                                    
                                </th>
                                <th>
                                    <p>Nº RADICADO</p>
                                </th>
                                <th>
                                    <p>PROCEDENCIA</p>
                                </th>
                                <th>
                                    <p>NATURALEZA</p>
                                </th>
                                <th>                                    
                                </th>
                                <th>
                                    <p>PROVIENE DE</p>
                                </th>                                
                                <th>
                                    <p>DETALLE</p>
                                </th>
                                <th>
                                    <p>FECHA RADICACION</p>
                                </th>
                            </tr>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class="wf_fila_documento">
                            <td>
                                <asp:CheckBox ID="cbxProximosAVencer" CssClass="wf_checkbox" runat="server" />
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span1"><%# Eval("numeroDocumento")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span2"><%# Eval("procedenciaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span3"><%# Eval("naturalezaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span4" style="display:none;"><%# Eval("wfAccionNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span5"><%# Eval("dependenciaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span6"><%# Eval("WFMovimientoNotas")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span7"><%# Eval("radicadoDetalle")%></span>
                                <span id="Span8" style="display:none;"><%# Eval("FechaVencimiento")%></span>                                 
                                <span id="Span10" style="display:none;"><%# Eval("NumeroExterno")%></span> 
                                <span id="Span11" style="display:none;"><%# Eval("FechaProcedencia")%></span> 
                                <span id="Span12" style="display:none;"><%# Eval("MedioNombre")%></span>
                                <span id="Span13" style="display:none;"><%# Eval("ExpedienteNombre")%></span> 
                                <span id="Span14" style="display:none;"><%# Eval("DependenciaDestino")%></span>
                                <span id="Span15" style="display:none;"><%# Eval("Anexo")%></span> 
                                <span id="Span16" style="display:none;"><%# Eval("Respuesta")%></span>                            
                            </td>
                            <td>
                                <span id="Span9"><%# Eval("FechaRadicacion")%></span>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <asp:Label ID="lblVacioProximosAVencer" CssClass="wf_label_vacio" runat="server" Text="No tiene documentos próximos a vencer en este momento !!!">
                        </asp:Label>
                    </EmptyDataTemplate>
                </asp:ListView>
                <div class = "wf_pager_container">
                    <asp:DataPager ID="dprProximosAVencer" runat="server" PagedControlID="lstvProximosAVencer" PageSize="10">
                        <Fields>
                        <asp:NumericPagerField NextPageText=">>" PreviousPageText="<<" 
                                NextPreviousButtonCssClass="wf_pager" ButtonType="Link" 
                                NumericButtonCssClass="wf_pager" />
                    </Fields>
                    </asp:DataPager>
                    <br /><br />
                </div>
            </div>
            <div id="tab-4" class="wf_tab_content" style="display:none;">
                <h3>Documentos pendientes</h3>
                <asp:ListView ID="lstvDocumentosPendientes" runat="server" OnPagePropertiesChanging="lstvDocumentosPendientes_PagePropertiesChanging" >
                    <LayoutTemplate>
                        <table class="wf_listview" cellspacing="0" cellpadding="3" rules="rows">
                            <tr>
                                <th>
                                    
                                </th>
                                <th>
                                    <p>Nº RADICADO</p>
                                </th>
                                <th>
                                    <p>PROCEDENCIA</p>
                                </th>
                                <th>
                                    <p>NATURALEZA</p>
                                </th>
                                <th>                                    
                                </th>
                                <th>
                                    <p>PROVIENE DE</p>
                                </th>                                
                                <th>
                                    <p>DETALLE</p>
                                </th>
                                <th>
                                    <p>FECHA RADICACION</p>
                                </th>
                            </tr>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class="wf_fila_documento">
                            <td>
                                <asp:CheckBox ID="cbxPendientes" CssClass="wf_checkbox" runat="server" />
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span1"><%# Eval("numeroDocumento")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span2"><%# Eval("procedenciaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span3"><%# Eval("naturalezaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span4" style="display:none;"><%# Eval("wfAccionNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span5"><%# Eval("dependenciaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span6"><%# Eval("WFMovimientoNotas")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span7"><%# Eval("radicadoDetalle")%></span>
                                <span id="Span8" style="display:none;"><%# Eval("FechaVencimiento")%></span>                                 
                                <span id="Span10" style="display:none;"><%# Eval("NumeroExterno")%></span> 
                                <span id="Span11" style="display:none;"><%# Eval("FechaProcedencia")%></span> 
                                <span id="Span12" style="display:none;"><%# Eval("MedioNombre")%></span>
                                <span id="Span13" style="display:none;"><%# Eval("ExpedienteNombre")%></span> 
                                <span id="Span14" style="display:none;"><%# Eval("DependenciaDestino")%></span>
                                <span id="Span15" style="display:none;"><%# Eval("Anexo")%></span> 
                                <span id="Span16" style="display:none;"><%# Eval("Respuesta")%></span>                            
                            </td>
                            <td>
                                <span id="Span9"><%# Eval("FechaRadicacion")%></span>
                            </td>                          
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <asp:Label ID="lblVacioPendientes" CssClass="wf_label_vacio" runat="server" Text="No tiene documentos pendientes en este momento !!!">
                        </asp:Label>
                    </EmptyDataTemplate>
                </asp:ListView>
                <div class = "wf_pager_container">
                    <asp:DataPager ID="dprDocumentosPendientes" runat="server" PagedControlID="lstvDocumentosPendientes" PageSize="10">
                        <Fields>
                        <asp:NumericPagerField NextPageText=">>" PreviousPageText="<<" 
                                NextPreviousButtonCssClass="wf_pager" ButtonType="Link" 
                                NumericButtonCssClass="wf_pager" />
                    </Fields>
                    </asp:DataPager>
                    <br /><br />
                </div>
            </div>
            <div id="tab-5" class="wf_tab_content" style="display:none;">
                <h3>Documentos copia externos</h3>
                <asp:ListView ID="lstvDocsCopiaExternos" runat="server" OnPagePropertiesChanging="lstvDocsCopiaExternos_PagePropertiesChanging" >
                    <LayoutTemplate>
                        <table class="wf_listview" cellspacing="0" cellpadding="3" rules="rows">
                            <tr>
                                <th>
                                    
                                </th>
                                <th>
                                    <p>Nº RADICADO</p>
                                </th>
                                <th>
                                    <p>PROCEDENCIA</p>
                                </th>
                                <th>
                                    <p>NATURALEZA</p>
                                </th>
                                <th>                                    
                                </th>
                                <th>
                                    <p>PROVIENE DE</p>
                                </th>                                
                                <th>
                                    <p>DETALLE</p>
                                </th>
                                <th>
                                    <p>FECHA RADICACION</p>
                                </th>
                            </tr>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class="wf_fila_documento">
                            <td>
                                <asp:CheckBox ID="cbxCopiaExternos" CssClass="wf_checkbox" runat="server" />
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span1"><%# Eval("numeroDocumento")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span2"><%# Eval("procedenciaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span3"><%# Eval("naturalezaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span4" style="display:none;"><%# Eval("wfAccionNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span5"><%# Eval("dependenciaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span6"><%# Eval("WFMovimientoNotas")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span7"><%# Eval("radicadoDetalle")%></span>
                                <span id="Span8" style="display:none;"><%# Eval("FechaVencimiento")%></span>                                
                                <span id="Span10" style="display:none;"><%# Eval("NumeroExterno")%></span> 
                                <span id="Span11" style="display:none;"><%# Eval("FechaProcedencia")%></span> 
                                <span id="Span12" style="display:none;"><%# Eval("MedioNombre")%></span>
                                <span id="Span13" style="display:none;"><%# Eval("ExpedienteNombre")%></span> 
                                <span id="Span14" style="display:none;"><%# Eval("DependenciaDestino")%></span>
                                <span id="Span15" style="display:none;"><%# Eval("Anexo")%></span> 
                                <span id="Span16" style="display:none;"><%# Eval("Respuesta")%></span>                          
                            </td>
                            <td>
                                <span id="Span9"><%# Eval("FechaRadicacion")%></span> 
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <asp:Label ID="lblVacioCopiaExternos" CssClass="wf_label_vacio" runat="server" Text="No tiene documentos copia externos en este momento !!!">
                        </asp:Label>
                    </EmptyDataTemplate>
                </asp:ListView>
                <div class = "wf_pager_container">
                    <asp:DataPager ID="dprCopiaExternos" runat="server" PagedControlID="lstvDocsCopiaExternos" PageSize="10">
                        <Fields>
                        <asp:NumericPagerField NextPageText=">>" PreviousPageText="<<" 
                                NextPreviousButtonCssClass="wf_pager" ButtonType="Link" 
                                NumericButtonCssClass="wf_pager" />
                    </Fields>
                    </asp:DataPager>
                    <br /><br />
                </div>
            </div>
            <div id="tab-6" class="wf_tab_content" style="display:none;">
                <h3>Documentos enviados internos</h3>
                <asp:ListView ID="lstvDocsEnviadosInternos" runat="server" OnPagePropertiesChanging="lstvDocsEnviadosInternos_PagePropertiesChanging" >
                    <LayoutTemplate>
                        <table class="wf_listview" cellspacing="0" cellpadding="3" rules="rows">
                            <tr>
                                <th>
                                    
                                </th>
                                <th>
                                    <p>Nº RADICADO</p>
                                </th>
                                <th>
                                    <p>PROCEDENCIA</p>
                                </th>
                                <th>
                                    <p>NATURALEZA</p>
                                </th>
                                <th>                                    
                                </th>
                                <th>
                                    <p>PROVIENE DE</p>
                                </th>                                
                                <th>
                                    <p>DETALLE</p>
                                </th>
                                <th>
                                    <p>FECHA RADICACION</p>
                                </th>
                            </tr>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class="wf_fila_documento">
                            <td>
                                <asp:CheckBox ID="cbxDocsEnviadosInternos" CssClass="wf_checkbox" runat="server" />
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span1"><%# Eval("numeroDocumento")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span2"><%# Eval("procedenciaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span3"><%# Eval("naturalezaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span4" style="display:none;"><%# Eval("wfAccionNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span5"><%# Eval("dependenciaNombre")%></span>
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span6"><%# Eval("WFMovimientoNotas")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span7"><%# Eval("radicadoDetalle")%></span>
                                <span id="Span8" style="display:none;"><%# Eval("FechaVencimiento")%></span>                                 
                                <span id="Span10" style="display:none;"><%# Eval("NumeroExterno")%></span> 
                                <span id="Span11" style="display:none;"><%# Eval("FechaProcedencia")%></span> 
                                <span id="Span12" style="display:none;"><%# Eval("MedioNombre")%></span>
                                <span id="Span13" style="display:none;"><%# Eval("ExpedienteNombre")%></span> 
                                <span id="Span14" style="display:none;"><%# Eval("DependenciaDestino")%></span>
                                <span id="Span15" style="display:none;"><%# Eval("Anexo")%></span> 
                                <span id="Span16" style="display:none;"><%# Eval("Respuesta")%></span>                        
                            </td>
                            <td>
                                <span id="Span9"><%# Eval("FechaRadicacion")%></span>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <asp:Label ID="lblVacioDocsEnviadosInternos" CssClass="wf_label_vacio" runat="server" Text="No tiene documentos enviados internos en este momento !!!">
                        </asp:Label>
                    </EmptyDataTemplate>
                </asp:ListView>
                <div class = "wf_pager_container">
                    <asp:DataPager ID="dprDocsEnviadosInternos" runat="server" PagedControlID="lstvDocsEnviadosInternos" PageSize="10">
                        <Fields>
                        <asp:NumericPagerField NextPageText=">>" PreviousPageText="<<" 
                                NextPreviousButtonCssClass="wf_pager" ButtonType="Link" 
                                NumericButtonCssClass="wf_pager" />
                    </Fields>
                    </asp:DataPager>
                    <br /><br />
                </div>
            </div>
            <div id="tab-7" class="wf_tab_content" style="display:none;">
                <h3>Documentos enviados internos copia</h3>
                <asp:ListView ID="lstvDocsEnviadosInternosCopia" runat="server" OnPagePropertiesChanging="lstvDocsEnviadosInternosCopia_PagePropertiesChanging" >
                    <LayoutTemplate>
                        <table class="wf_listview" cellspacing="0" cellpadding="3" rules="rows">
                            <tr>
                                <th>
                                    
                                </th>
                                <th>
                                    <p>Nº RADICADO</p>
                                </th>
                                <th>
                                    <p>PROCEDENCIA</p>
                                </th>
                                <th>
                                    <p>NATURALEZA</p>
                                </th>
                                <th>                                    
                                </th>
                                <th>
                                    <p>PROVIENE DE</p>
                                </th>                                
                                <th>
                                    <p>DETALLE</p>
                                </th>
                                <th>
                                    <p>FECHA RADICACION</p>
                                </th>
                            </tr>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class="wf_fila_documento">
                            <td>
                                <asp:CheckBox ID="cbxDocsEnviadosInternosCopia" CssClass="wf_checkbox" runat="server" />
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span1"><%# Eval("numeroDocumento")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span2"><%# Eval("procedenciaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span3"><%# Eval("naturalezaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span4" style="display:none;"><%# Eval("wfAccionNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span5"><%# Eval("dependenciaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span6"><%# Eval("WFMovimientoNotas")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span7"><%# Eval("radicadoDetalle")%></span>
                                <span id="Span8" style="display:none;"><%# Eval("FechaVencimiento")%></span>                                 
                                <span id="Span10" style="display:none;"><%# Eval("NumeroExterno")%></span> 
                                <span id="Span11" style="display:none;"><%# Eval("FechaProcedencia")%></span> 
                                <span id="Span12" style="display:none;"><%# Eval("MedioNombre")%></span>
                                <span id="Span13" style="display:none;"><%# Eval("ExpedienteNombre")%></span> 
                                <span id="Span14" style="display:none;"><%# Eval("DependenciaDestino")%></span>
                                <span id="Span15" style="display:none;"><%# Eval("Anexo")%></span> 
                                <span id="Span16" style="display:none;"><%# Eval("Respuesta")%></span>
                            </td>
                            <td>
                                <span id="Span9"><%# Eval("FechaRadicacion")%></span>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <asp:Label ID="lblVacioDocsEnviadosInternosCopia" CssClass="wf_label_vacio" runat="server" Text="No tiene documentos enviados internos copia en este momento !!!">
                        </asp:Label>
                    </EmptyDataTemplate>
                </asp:ListView>
                <div class = "wf_pager_container">
                    <asp:DataPager ID="dprDocsEnviadosInternosCopia" runat="server" PagedControlID="lstvDocsEnviadosInternosCopia" PageSize="10">
                        <Fields>
                        <asp:NumericPagerField NextPageText=">>" PreviousPageText="<<" 
                                NextPreviousButtonCssClass="wf_pager" ButtonType="Link" 
                                NumericButtonCssClass="wf_pager" />
                    </Fields>
                    </asp:DataPager>
                    <br /><br />
                </div>
            </div>
            <div id="tab-8" class="wf_tab_content" style="display:none;">
                <h3>Documentos en seguimiento</h3>
                <asp:ListView ID="lstvrDocsEnSeguimiento" runat="server" OnPagePropertiesChanging="lstvrDocsEnSeguimiento_PagePropertiesChanging" >
                    <LayoutTemplate>
                        <table class="wf_listview" cellspacing="0" cellpadding="3" rules="rows">
                            <tr>
                                <th>
                                    
                                </th>
                                <th>
                                    <p>Nº RADICADO</p>
                                </th>
                                <th>
                                    <p>PROCEDENCIA</p>
                                </th>
                                <th>
                                    <p>NATURALEZA</p>
                                </th>
                                <th>                                    
                                </th>
                                <th>
                                    <p>PROVIENE DE</p>
                                </th>                                
                                <th>
                                    <p>DETALLE</p>
                                </th>
                                <th>
                                    <p>FECHA RADICACION</p>
                                </th>
                            </tr>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class="wf_fila_documento">
                            <td>
                                <asp:CheckBox ID="cbxrDocsEnSeguimiento" CssClass="wf_checkbox" runat="server" />
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span1"><%# Eval("numeroDocumento")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span2"><%# Eval("procedenciaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span3"><%# Eval("naturalezaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span4" style="display:none;"><%# Eval("wfAccionNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span5"><%# Eval("dependenciaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span6"><%# Eval("WFMovimientoNotas")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span7"><%# Eval("radicadoDetalle")%></span>
                                <span id="Span8" style="display:none;"><%# Eval("FechaVencimiento")%></span>                                 
                                <span id="Span10" style="display:none;"><%# Eval("NumeroExterno")%></span> 
                                <span id="Span11" style="display:none;"><%# Eval("FechaProcedencia")%></span> 
                                <span id="Span12" style="display:none;"><%# Eval("MedioNombre")%></span>
                                <span id="Span13" style="display:none;"><%# Eval("ExpedienteNombre")%></span> 
                                <span id="Span14" style="display:none;"><%# Eval("DependenciaDestino")%></span>
                                <span id="Span15" style="display:none;"><%# Eval("Anexo")%></span> 
                                <span id="Span16" style="display:none;"><%# Eval("Respuesta")%></span>                           
                            </td>
                            <td>
                                <span id="Span9"><%# Eval("FechaRadicacion")%></span>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <asp:Label ID="lblVaciorDocsEnSeguimiento" CssClass="wf_label_vacio" runat="server" Text="No tiene documentos en seguimiento en este momento !!!">
                        </asp:Label>
                    </EmptyDataTemplate>
                </asp:ListView>
                <div class = "wf_pager_container">
                    <asp:DataPager ID="dprDocsEnSeguimiento" runat="server" PagedControlID="lstvrDocsEnSeguimiento" PageSize="10">
                        <Fields>
                        <asp:NumericPagerField NextPageText=">>" PreviousPageText="<<" 
                                NextPreviousButtonCssClass="wf_pager" ButtonType="Link" 
                                NumericButtonCssClass="wf_pager" />
                    </Fields>
                    </asp:DataPager>
                    <br /><br />
                </div>
            </div>
            <div id="tab-9" class="wf_tab_content" style="display:none;">
                <h3>Resultados de b&uacute;squeda</h3>
                <asp:ListView ID="lstvResutadosBusqueda" runat="server" OnPagePropertiesChanging="lstvResutadosBusqueda_PagePropertiesChanging" >
                    <LayoutTemplate>
                        <table class="wf_listview" cellspacing="0" cellpadding="3" rules="rows">
                            <tr>
                                <th>
                                    
                                </th>
                                <th>
                                    <p>Nº RADICADO</p>
                                </th>
                                <th>
                                    <p>PROCEDENCIA</p>
                                </th>
                                <th>
                                    <p>NATURALEZA</p>
                                </th>
                                <th>                                    
                                </th>
                                <th>
                                    <p>PROVIENE DE</p>
                                </th>                                
                                <th>
                                    <p>DETALLE</p>
                                </th>
                                <th>
                                    <p>FECHA RADICACION</p>
                                </th>
                            </tr>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class="wf_fila_documento">
                            <td>
                                <asp:CheckBox ID="cbxrDocsBusqueda" CssClass="wf_checkbox" runat="server" />
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span1"><%# Eval("numeroDocumento")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span2"><%# Eval("procedenciaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span3"><%# Eval("naturalezaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span4" style="display:none;"><%# Eval("wfAccionNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span5"><%# Eval("dependenciaNombre")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span6"><%# Eval("WFMovimientoNotas")%></span>                            
                            </td>
                            <td onclick="showdocument(this);">
                                <span id="Span7"><%# Eval("radicadoDetalle")%></span>
                                <span id="Span8" style="display:none;"><%# Eval("FechaVencimiento")%></span>                                
                                <span id="Span10" style="display:none;"><%# Eval("NumeroExterno")%></span> 
                                <span id="Span11" style="display:none;"><%# Eval("FechaProcedencia")%></span> 
                                <span id="Span12" style="display:none;"><%# Eval("MedioNombre")%></span>
                                <span id="Span13" style="display:none;"><%# Eval("ExpedienteNombre")%></span> 
                                <span id="Span14" style="display:none;"><%# Eval("DependenciaDestino")%></span>
                                <span id="Span15" style="display:none;"><%# Eval("Anexo")%></span> 
                                <span id="Span16" style="display:none;"><%# Eval("Respuesta")%></span>                          
                            </td>
                            <td>
                                <span id="Span9"><%# Eval("FechaRadicacion")%></span>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <asp:Label ID="lblVaciorDocsBusqueda" CssClass="wf_label_vacio" runat="server" Text="No se encontraron resultados... !!!">
                        </asp:Label>
                    </EmptyDataTemplate>
                </asp:ListView>
                <div class = "wf_pager_container">
                    <asp:DataPager ID="dprBusqueda" runat="server" PagedControlID="lstvResutadosBusqueda" PageSize="10">
                        <Fields>
                        <asp:NumericPagerField NextPageText=">>" PreviousPageText="<<" 
                                NextPreviousButtonCssClass="wf_pager" ButtonType="Link" 
                                NumericButtonCssClass="wf_pager" />
                    </Fields>
                    </asp:DataPager>
                    <br /><br />
                </div>
            </div>
            <div id="tab-10" class="wf_tab_content" style="display:none;">
                <%--<h3>Documento</h3>--%>
                <div class = "wf_document_detail_container">
                    <br />
                    <table class ="wf_document_txts">
                        <tr>
                            <td class="wf_td_text">
                                Cargar a:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAutoCompleteDependencias" CssClass="txtDependencias" runat="server" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="wf_td_text">
                                Acci&oacute;n:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAutoCompleteAcciones" CssClass="txtAccion" runat="server" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                    </table>               
                    <br />
                    <div class ="wf_document_detail">
                        <table class="wf_table_info_document">
                            <tr>
                                <td colspan="2">
                                    <img src="" alt="Logo cliente" />
                                </td>
                                <td><p class = "wf_parr_radicado">RADICADO<br />N°</p></td>
                                <td>
                                    <asp:TextBox ID="txtNumDocument" CssClass="lblNumDocument" runat="server" ClientIDMode="Static" AutoPostBack="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan = "2">
                                </td>
                                <td colspan = "2">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Fecha radicaci&oacute;n:
                                </td>
                                <td>
                                    <input type="text" id = "txtFechaRadicacion" readonly ="readonly" disabled = "disabled" />
                                </td>
                                <td>
                                    N&uacute;mero externo:
                                </td>
                                <td>
                                    <input type="text" id = "txtNumExterno" readonly ="readonly" disabled = "disabled" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Fecha Procedencia:
                                </td>
                                <td>
                                    <input type="text" id = "txtFechaProcedencia" readonly ="readonly" disabled = "disabled" />
                                </td>
                                <td>
                                    Fecha Vencimiento:
                                </td>
                                <td>
                                    <input type="text" id = "txtFechaVencimiento" readonly ="readonly" disabled = "disabled" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Procedencia:
                                </td>                            
                                <td colspan="3">
                                    <input type="text" id = "txtProcedencia" class="wf_caja_texto" readonly ="readonly" disabled = "disabled" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">Detalle:</td>                            
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <textarea id="txtDetalle" class ="wf_area_texto" rows = "2" cols="5" readonly ="readonly" disabled = "disabled"></textarea>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Naturaleza:
                                </td>
                                <td colspan="3">
                                    <input type="text" id = "txtNaturaleza" class="wf_caja_texto" readonly ="readonly" disabled = "disabled" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Medio:
                                </td>
                                <td colspan="3">
                                    <input type="text" id = "txtMedio" class="wf_caja_texto" readonly ="readonly" disabled = "disabled" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Expediente:
                                </td>
                                <td colspan="3">
                                    <input type="text" id = "txtExpediente" class="wf_caja_texto" readonly ="readonly" disabled = "disabled" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Cargado a:
                                </td>
                                <td colspan="3">
                                    <input type="text" id = "txtCargadoA" class="wf_caja_texto" readonly ="readonly" disabled = "disabled" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Acci&oacute;n:
                                </td>
                                <td colspan="3">
                                    <input type="text" id = "txtAccion" class="wf_caja_texto" readonly ="readonly" disabled = "disabled" />
                                </td>
                            </tr>

                            <tr>
                                <td colspan="4">Anexos:</td>                            
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <textarea id="txtAnexos" class ="wf_area_texto" rows = "2" cols="5" readonly ="readonly" disabled = "disabled"></textarea>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">Respuestas:</td>                      
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <textarea id="txtRespuestas" class ="wf_area_texto" rows = "2" cols="5" readonly ="readonly" disabled = "disabled"></textarea>
                                </td>
                            </tr>                        
                        </table>
                    </div><br />
                </div>
            </div>
        </ContentTemplate>
        <Triggers>            
            <%--<asp:PostBackTrigger ControlID = "dprTodos"/>
            <asp:PostBackTrigger ControlID = "dprDocsVencidos"/>
            <asp:PostBackTrigger ControlID = "dprDocsVencidos"/>
            <asp:PostBackTrigger ControlID = "dprProximosAVencer"/>
            <asp:PostBackTrigger ControlID = "dprDocumentosPendientes"/>
            <asp:PostBackTrigger ControlID = "dprCopiaExternos"/>
            <asp:PostBackTrigger ControlID = "dprDocsEnviadosInternos"/>
            <asp:PostBackTrigger ControlID = "dprDocsEnviadosInternosCopia"/>
            <asp:PostBackTrigger ControlID = "dprDocsEnSeguimiento"/>  
            <asp:PostBackTrigger ControlID = "dprBusqueda"/>--%>
            <asp:PostBackTrigger ControlID = "btnFinalizar" />
            <%--<asp:PostBackTrigger ControlID = "ibtnBuscar" />--%>
        </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
