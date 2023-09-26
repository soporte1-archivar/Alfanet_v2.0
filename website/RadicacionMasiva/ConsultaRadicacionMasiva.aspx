<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ConsultaRadicacionMasiva.aspx.cs"
    Inherits="WebApplication1.RadicacionMasiva.ConsultaRadicacionMasiva" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consulta radicación masiva</title>
    <script src="../Scripts/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="script/RadicacionMasiva.js" type="text/javascript"></script>
    <link href="css/radicacionmasivastyle.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <link href="../Styles/smoothness/jquery-ui-1.9.1.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/smoothness/jquery-ui-1.9.1.custom.min.css" rel="stylesheet"
        type="text/css" />
    <script src="../Scripts/jquery-ui-1.9.1.custom.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.9.1.custom.min.js" type="text/javascript"></script>
    <script src="script/Test.js" type="text/javascript"></script>
    <script src="script/consultas.js" type="text/javascript"></script>
    <script src="script/jquery.uploadify.v2.1.4.min.js" type="text/javascript"></script>
    <script src="script/swfobject.js" type="text/javascript"></script>
    <link href="css/uploadify.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="rm_all_container">
        <div class="rm_header">
            <h1>
                Consulta Radicación Masiva</h1>
            <asp:LinkButton ID="LinkButton1" runat="server" Style="color: White;" OnClick="LinkButton1_Click">Radicaci&oacute;n</asp:LinkButton>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="rm_content">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div>
                        <h3>
                            Seleccione los par&aacute;metros de b&uacute;squeda que desee</h3>
                    </div>
                    <div class="rm_contenedor_parametros">
                        <div>
                            <asp:CheckBox ID="cbxConsultarByRadicados" runat="server" Text="Consultar entre números de radicado"
                                AutoPostBack="True" OnCheckedChanged="cbxConsultarByRadicados_CheckedChanged" />
                        </div>
                        <div id="div_consultaByRadicados" visible="false" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        C&oacute;digo inicial:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtInicial" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        C&oacute;digo final:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFinal" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <asp:CheckBox ID="cbxConsultarByFechas" runat="server" Text="Consultar entre fechas de radicación"
                                AutoPostBack="True" OnCheckedChanged="cbxConsultarByFechas_CheckedChanged" />
                        </div>
                        <div id="div_consultaByFechas" visible="false" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        Fecha inicial:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFechaInicial" runat="server" CssClass="fechaInicial"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Fecha final:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFechaFinal" runat="server" CssClass="fechaFinal"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <asp:CheckBox ID="cbxRemision" runat="server" Text="Consultar entre números de remisión"
                                AutoPostBack="True" OnCheckedChanged="cbxRemision_CheckedChanged" />
                        </div>
                        <div id="div_consultaByRemision" visible="false" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        Inicial:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRemisionIni" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Final:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRemisionFinal" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <asp:CheckBox ID="cbxNumeroFacutra" runat="server" Text="Consultar entre números de factura"
                                AutoPostBack="True" OnCheckedChanged="cbxNumeroFacutra_CheckedChanged" />
                        </div>
                        <div id="div_consultaByNumeroFactura" visible="false" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        Factura Inicial:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFacturaInicial" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Factura Final:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFacturaFianl" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <asp:CheckBox ID="cbxComprobanteEgreso" runat="server" Text="Consultar entre comprobantes de egreso"
                                AutoPostBack="True" OnCheckedChanged="cbxComprobanteEgreso_CheckedChanged" />
                        </div>
                        <div id="div_consultaByComprobanteEgreso" visible="false" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        Numero Inicial:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEgresoIni" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Numero Final:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEgresoFin" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <asp:CheckBox ID="cbxValoresFactura" runat="server" Text="Consultar entre valores de facturas"
                                AutoPostBack="True" OnCheckedChanged="cbxValoresFactura_CheckedChanged" />
                        </div>
                        <div id="div_consultaByValoresFactura" visible="false" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        Valor Inicial:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtValorFac1" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Valor Final:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtValorFac2" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <asp:CheckBox ID="cbxNombreNit" runat="server" Text="Consultar por procedencia" AutoPostBack="True"
                                OnCheckedChanged="cbxNombreNit_CheckedChanged" />
                        </div>
                        <div id="div_consultaByNombreoNit" visible="false" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        Buscar:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNombreoNit" CssClass="rm_txtnombreonit" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <asp:CheckBox ID="cbxUbicacion" runat="server" Text="Consultar por ubicación" AutoPostBack="True"
                                OnCheckedChanged="cbxUbicacion_CheckedChanged" />
                        </div>
                        <div id="div_consultaByUbicacion" visible="false" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        Buscar:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUbicacion" runat="server" CssClass="rm_txtaccion2" Enabled="true"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <asp:CheckBox ID="cbxRegional" runat="server" 
                                Text="Consultar entre c&oacute;digos de ciudad" AutoPostBack="True" 
                                oncheckedchanged="cbxRegional_CheckedChanged"/>
                        </div>
                        <div id="div_consultaByRegional" visible="false" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        C&oacute;digo Inicial:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCodCiudadInicial" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        C&oacute;digo Final:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCodCiudadFinal" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <asp:CheckBox ID="cbxDetalle" runat="server" Text="Consultar por detalle" AutoPostBack="True"
                                OnCheckedChanged="cbxDetalle_CheckedChanged" />
                        </div>
                        <div id="div_consultaByDetalle" visible="false" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        Buscar:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDetalleConsulta" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <asp:CheckBox ID="cbxUnidad" runat="server" Text="Consultar por unidad de almacenamiento"
                                AutoPostBack="True" OnCheckedChanged="cbxUnidad_CheckedChanged" />
                        </div>
                        <div id="div_consultaByUnidad" visible="false" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        Buscar:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUnidad" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <asp:CheckBox ID="cbxModalidad" runat="server" Text="Consultar por modalidad de  contrato"
                                AutoPostBack="True" OnCheckedChanged="cbxModalidad_CheckedChanged" />
                        </div>
                        <div id="div_consultaByModalidad" visible="false" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        Buscar:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtModalidad" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <asp:CheckBox ID="cbxExpediente" runat="server" Text="Consultar por expediente" AutoPostBack="True"
                                OnCheckedChanged="cbxExpediente_CheckedChanged" />
                        </div>
                        <div id="div_consultaByExpediente" visible="false" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        Buscar:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtExpediente" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <asp:CheckBox ID="cbxPorImagen" runat="server" Text="Consultar por Imagen" AutoPostBack="True"
                                OnCheckedChanged="cbxPorImagen_CheckedChanged" />
                        </div>
                        <div id="div_consultaByImagen" visible="false" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        Imagen:
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="RblImagen" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="&gt;">Con Imagen</asp:ListItem>
                                            <asp:ListItem Value="=">Sin Imagen</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <asp:CheckBox ID="cbxRadicadorCod" runat="server" Text="Consultar por radicador"
                                AutoPostBack="True" OnCheckedChanged="cbxRadicadorCod_CheckedChanged" />
                        </div>
                        <div id="div_consultaByRadicador" visible="false" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        Buscar:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRadicador" CssClass="txtRadicador" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="rm_contenedormensaje">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                    <br />
                    <div>
                        <asp:Button ID="btnBuscar" CssClass="btns" runat="server" Text="Buscar" OnClick="btnBuscar_Click"
                            OnClientClick="this.disable = true; clicked=0;" />
                    </div>
                    <br />
                    <div id="tab-1" class="rm_data_container">
                        <div id="Div_Export" visible="false" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:RadioButton ID="rdbExpExcel" runat="server" Text="Excel" Checked="True" GroupName="export" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="rdbExpPdf" runat="server" Text="Pdf" GroupName="export" />
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Button ID="btnExport" CssClass="btns3" runat="server" Text="Exportar" Enabled="False"
                                            OnClick="btnExport_Click" Visible="False" /><br />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:ListView ID="lstvData" runat="server" OnPagePropertiesChanging="lstvData_PagePropertiesChanging">
                            <LayoutTemplate>
                                <table class="rm_listview_consultas" cellspacing="0" cellpadding="2" rules="rows">
                                    <tr>
                                        <th>
                                            RADICADO
                                        </th>
                                        <th>
                                            REGISTRO OASIS
                                        </th>
                                        <th>
                                            Nº REMISI&Oacute;N
                                        </th>
                                        <th>
                                            FECHA RADICACI&Oacute;N
                                        </th>
                                        <th>
                                            PROCEDENCIA
                                        </th>
                                        <th>
                                            DETALLE
                                        </th>
                                        <th>
                                            FACTURA PRESTADOR
                                        </th>
                                        <%--<th>
                                            MEDIO
                                        </th>--%>
                                        <th>
                                            EXPEDIENTE
                                        </th>
                                        <%--<th>
                                            DESTINO
                                        </th>--%>
                                        <th>
                                            IMAGEN
                                        </th>
                                        <th>
                                            RADICADOR
                                        </th>
                                        <th colspan="2">
                                            OPCIONES
                                        </th>
                                        <%--<th>
                                            EDITAR
                                        </th> --%>
                                    </tr>
                                    <tbody>
                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <span id="Span1">
                                            <%# Eval("RadicadoCodigo")%></span>
                                    </td>
                                    <td>
                                        <span id="Span11">
                                            <%# Eval("Facn_numero")%></span>
                                    </td>
                                    <td>
                                        <span id="Span12">
                                            <%# Eval("Facn_recibo")%></span>
                                    </td>
                                    <td>
                                        <span id="Span2">
                                            <%# Eval("FechaRadicacion")%></span>
                                    </td>
                                    <td>
                                        <span id="Span3">
                                            <%# Eval("ProcedenciaNombre")%></span>
                                    </td>
                                    <td class="rm_align_left">
                                        <span id="Span4">
                                            <%# Eval("Detalle")%></span>
                                    </td>
                                    <td>
                                        <span id="Span5">
                                            <%# Eval("Facc_factura")%></span>
                                    </td>
                                    <%--<td >
                                        <span id="Span7"><%# Eval("MedioNombre")%></span>                            
                                    </td>--%>
                                    <td>
                                        <span id="Span9">
                                            <%# Eval("ExpedienteNombre")%></span>
                                    </td>
                                    <%--<td >
                                        <span id="Span10"><%# Eval("Serie")%></span>                           
                                    </td>--%>
                                    <td>
                                        <span id="Span6">
                                            <%# Eval("Imagen")%></span>
                                    </td>
                                    <td>
                                        <span id="Span8">
                                            <%# Eval("dependenciaNombre")%></span>
                                    </td>
                                    <td>
                                        <a href="#Tab-10" onclick="OpenVisor(this);">Imagenes</a>
                                        <%--<a href="../AlfanetImagenes/VisorImagenes/Visor.aspx?DocumentoCodigo=<%# Eval("RadicadoCodigo")%>&GrupoCodigo=4&GrupoPadreCodigo=1&Admon=S&ImagenFolio=1">Imagenes</a>--%>
                                    </td>
                                    <td align="center">
                                        <a href="#tab-2" onclick="OpenEdit(this);" class="active">Editar</a> 
                                        <span id="ProcedenciaNUI" style="display: none;"><%# Eval("ProcedenciaNUI")%></span>
                                        <span id="comp_egreso" style="display: none;"><%# Eval("ComprobanteEgreso")%></span>
                                            <span id="Facn_empresa" style="display: none;">
                                                <%# Eval("Facn_empresa")%></span> <span id="Facc_documento" style="display: none;">
                                                    <%# Eval("Facc_documento")%></span> <span id="Facn_ubicacion" style="display: none;">
                                                        <%# Eval("Facn_ubicacion")%></span> <span id="Facv_total" style="display: none;">
                                                            <%# Eval("Facv_total")%></span> <span id="Facc_estado" style="display: none;">
                                                                <%# Eval("Facc_estado")%></span> <span id="Facc_prefijo" style="display: none;">
                                                                    <%# Eval("Facc_prefijo")%></span> <span id="Facn_factura2" style="display: none;">
                                                                        <%# Eval("Facn_factura2")%></span> <span id="Facc_alto_costo" style="display: none;">
                                                                            <%# Eval("Facc_alto_costo")%></span> <span id="Terc_nombre" style="display: none;">
                                                                                <%# Eval("Terc_nombre")%></span> <span id="Facf_confirmacion" style="display: none;">
                                                                                    <%# Eval("Facf_confirmacion")%></span>
                                        <span id="Facv_copago" style="display: none;">
                                            <%# Eval("Facv_copago")%></span> <span id="Facv_responsable" style="display: none;">
                                                <%# Eval("Facv_responsable")%></span> <span id="Facc_conciliado" style="display: none;">
                                                    <%# Eval("Facc_conciliado")%></span> <span id="Facv_imputable" style="display: none;">
                                                        <%# Eval("Facv_imputable")%></span> <span id="Facf_radicado" style="display: none;">
                                                            <%# Eval("Facf_radicado")%></span> <span id="Facf_final" style="display: none;">
                                                                <%# Eval("Facf_final")%></span>
                                        <%--<span id="Facc_digitalizado" style="display:none;"><%# Eval("Facc_digitalizado")%></span>--%>
                                        <span id="Facc_almacenamiento" style="display: none;">
                                            <%# Eval("Facc_almacenamiento")%></span> <span id="Cntc_concepto" style="display: none;">
                                                <%# Eval("Cntc_concepto")%></span> <span id="Conc_nombre" style="display: none;">
                                                    <%# Eval("Conc_nombre")%></span> <span id="Facv_tercero" style="display: none;">
                                                        <%# Eval("Facv_tercero")%></span> <span id="FechaProcedencia" style="display: none;">
                                                            <%# Eval("FechaProcedencia")%></span> <span id="Facn_recibo" style="display: none;">
                                                                <%# Eval("Facn_recibo")%></span>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <asp:Label ID="lblVacioTodos" CssClass="wf_label_vacio" runat="server" Text="No tiene documentos en este momento !!!">
                                </asp:Label>
                            </EmptyDataTemplate>
                        </asp:ListView>
                        <div class="rm_pager_container">
                            <asp:Label ID="lblTotal" runat="server"></asp:Label>
                            <asp:DataPager ID="dprPagerData" PagedControlID="lstvData" PageSize="10" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Link" NextPageText="Siguiente" PreviousPageText="Anterior"
                                        ShowFirstPageButton="true" LastPageText="Ultimo" ShowLastPageButton="true" FirstPageText="Primero" />
                                </Fields>
                            </asp:DataPager>
                        </div>
                    </div>
                    <div id="tab-2" class="rm_edit_content" style="display: none;">
                        <div class="rm_edit_header">
                            <table>
                                <tr>
                                    <td class="rm_align_left">
                                        <asp:Button ID="btnEdit" CssClass="btns2" runat="server" Text="Editar..." OnClick="btnEdit_Click"
                                            OnClientClick="putNewDetalle();" />
                                    </td>
                                    <td>
                                        <h2>
                                            Editar</h2>
                                    </td>
                                    <td class="rm_align_rigth">                                        
                                        <input type="button" id="btnRegresar" onclick="Regresar();" class="btns2"
                                            value="<< Regresar" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="rm_edit_body">
                            <table class="rm_tableDetalleCampos">
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                N&uacute;mero de radicado:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRadicadoCodigo" CssClass="txtRadicadoCodigo" onkeydown="return false;"
                                                ClientIDMode="Static" AutoPostBack="False" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Fecha radicaci&oacute;n:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="spm_fecharadicacion" CssClass="spm_fecharadicacion" ClientIDMode="Static"
                                                Enabled="false" onkeydown="return false;" AutoPostBack="False" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                NIT Prestador:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtProcNui" CssClass="txtProcNui" ClientIDMode="Static" Enabled="false"
                                                onkeydown="return false;" AutoPostBack="False" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Nombre prestador:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="spm_procedencia" CssClass="procedencia" ClientIDMode="Static" Enabled="false"
                                                onkeydown="return false;" AutoPostBack="False" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Detalle:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDetalle" CssClass="txtDetalle" runat="server" ClientIDMode="Static"
                                                AutoPostBack="False" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Comprobantes de egreso:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_compEgreso" CssClass="txt_compEgreso" ClientIDMode="Static" Enabled="false"
                                                onkeydown="return false;" AutoPostBack="False" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Agregar comprobantes<br/>de egreso:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCompEgreso" CssClass="rm_compegreso" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="btnAdd" CssClass="rm_btnadd" ToolTip="Agregar Comprobantes"
                                                ValidationGroup="validar" runat="server" OnClientClick="putClicked();" ImageUrl="~/RadicacionMasiva/image/Add.png"
                                                OnClick="btnAdd_Click" />
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="revValidateNumsCompEgreso" ControlToValidate="txtCompEgreso"
                                                ValidationGroup="validar" ValidationExpression="\d+" runat="server" ErrorMessage="Campo Numérico."></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:ListBox ID="lbxCompEgreso" CssClass="rm_lbxCompEgreso" runat="server"></asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Registro Oasis:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRegistroOasis" CssClass="txtRegistroOasis" ClientIDMode="Static"
                                                Enabled="false" onkeydown="return false;" AutoPostBack="False" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Nº Remisi&oacute;n:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRemision" CssClass="txtRemision" ClientIDMode="Static" Enabled="false"
                                                onkeydown="return false;" AutoPostBack="False" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                N&uacute;mero factura prestador:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFacPrestador" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                CssClass="txtFacPrestador" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Expediente:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtExpediente2" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                CssClass="txtExpediente" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Empresa:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFacn_empresa" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                CssClass="txtFacn_empresa" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Tipo documento:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFacc_documento" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                CssClass="txtFacc_documento" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Ubicaci&oacute;n:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFacn_ubicacion" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                CssClass="txtFacn_ubicacion" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Valor factura:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFacv_total" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                CssClass="txtFacv_total" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Estado:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFacc_estado" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                CssClass="txtFacc_estado" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Prefijo:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFacc_prefijo" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                CssClass="txtFacc_prefijo" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                N&uacute;mero factura:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFacn_factura2" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                CssClass="txtFacn_factura2" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Alto costo:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFacc_alto_costo" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                CssClass="txtFacc_alto_costo" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Fecha de confirmaci&oacute;n:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFacf_confirmacion" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                CssClass="txtFacf_confirmacion" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Copago:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFacv_copago" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                CssClass="txtFacv_copago" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Responsable:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFacv_responsable" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                CssClass="txtFacv_responsable" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Conciliaci&oacute;n:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFacc_conciliado" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                CssClass="txtFacc_conciliado" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Imputable:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFacv_imputable" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                CssClass="txtFacv_imputable" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Fecha de radicaci&oacute;n Oasis:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFacf_radicado" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                CssClass="txtFacf_radicado" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Fecha de prestaci&oacute;n:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFacf_final" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                CssClass="txtFacf_final" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td>
                                            <p class="rm_title">
                                                Digitalizado:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFacc_digitalizado" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                CssClass="txtFacc_digitalizado" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Unidad de almacenamiento:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFacc_almacenamiento" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                CssClass="txtFacc_almacenamiento" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                C&oacute;digo modalidad:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCntc_concepto" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                CssClass="txtCntc_concepto" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                Modalidad contrato:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtConc_nombre" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                CssClass="txtConc_nombre" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="rm_title">
                                                N&uacute;mero remisi&oacute;n:</p>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFacn_recibo" runat="server" AutoPostBack="False" ClientIDMode="Static"
                                                CssClass="txtFacn_recibo" Enabled="false" onkeydown="return false;"></asp:TextBox>
                                        </td>
                                  </tr>
                            </table>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnExport" />
                    <asp:PostBackTrigger ControlID="btnBuscar" />
                    <%--<asp:PostBackTrigger ControlID="btnEdit" />--%>
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div class="rm_foother">
        </div>
    </div>
    </form>
</body>
</html>
