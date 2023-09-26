<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultasRecepcionFisica.aspx.cs" Inherits="WebApplication1.RecepcionFisicaDocumentos.ConsultasRecepcionFisica" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Consultas recepci&oacute;n f&iacute;sica documentos</title>

    <script src="../Scripts/jquery-1.8.2.js" type="text/javascript"></script>  
           
    <script src="../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <link href="../Styles/smoothness/jquery-ui-1.9.1.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/smoothness/jquery-ui-1.9.1.custom.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-ui-1.9.1.custom.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.9.1.custom.min.js" type="text/javascript"></script>
    
    <script src="script/jquery.uploadify.v2.1.4.min.js" type="text/javascript"></script>
    <script src="script/swfobject.js" type="text/javascript"></script>
    <link href="css/uploadify.css" rel="stylesheet" type="text/css" />
    <link href="css/DocFisicosStyle.css" rel="stylesheet" type="text/css" />
    <script src="script/RecepFisicaScript.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>       
            
             <div class="rm_all_container">
                <div class = "rm_header">                    
                    <h1>Consultas Entrega Documentos F&iacute;sicos</h1>
                </div>
                <div>
                    <h3>Seleccione las fechas en las cuales<br />desea realizar la busqueda</h3>
                </div>
                <div>
                    <table>
                        <tr>
                            <td>
                                Fecha inicial:
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaInicial" runat="server" CssClass="fechaInicial"></asp:TextBox>
                            </td>
                            <td>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="*" ControlToValidate="txtFechaInicial" SetFocusOnError="True" 
                                    ValidationGroup="validar"></asp:RequiredFieldValidator>--%>
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
                               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ErrorMessage="*" ControlToValidate="txtFechaFinal" SetFocusOnError="True" 
                                    ValidationGroup="validar"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <br />
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btns" 
                                    onclick="btnBuscar_Click" ValidationGroup="validar"/>
                            </td>                            
                        </tr>
                    </table> <br />               
                </div>
                <div class="cont_mensaje_recepfisica">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </div>
                <div class="rm_content">
                    <div id="resumen" class = "rm_preview_data_container" runat="server">
                        <asp:ListView ID="lstv_resultados" runat="server" OnPagePropertiesChanging="lstv_resultados_PagePropertiesChanging">
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
                                            <p>ESTADO</p>
                                        </th>
                                         <th>
                                            <p>FECHA RECIBIDO</p>
                                        </th>
                                    </tr>
                                    <tbody>
                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>   
                                    <td >                                        
                                        <span id="spm_radicado" runat="server"><%# Eval("NumeroDocumento")%></span>
                                    </td>
                                    <td >                                        
                                        <span id="spm_procedencia" runat="server"><%# Eval("ProcedenciaNombre")%></span>
                                    </td>
                                    <td class="desaparecer">                                        
                                        <span id="Span2" runat="server"><%# Eval("GrupoNombre")%></span>
                                    </td>
                                    <td >
                                        <span id="spm_fecha" runat="server"><%# Eval("wfmovimientoFecha")%></span>
                                    </td>
                                    <td >
                                        <span id="spm_Coddestino" runat="server"><%# Eval("DependenciaNombre")%></span>
                                    </td>
                                     <td >
                                        <span id="spm_estado" runat="server"><%# Eval("Leido")%></span>
                                    </td>
                                    <td >
                                        <span id="spm_fechaRecibido" runat="server"><%# Eval("FechaVencimiento")%></span>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <asp:Label ID="lblVacioConsulta" CssClass="wf_label_vacio" runat="server" Text="No tiene documentos recibidos en las fechas seleccionadas.">
                                </asp:Label>
                            </EmptyDataTemplate>
                        </asp:ListView>
                        <div class="rm_pager_container">
                            <asp:Label ID="lblTotalConsulta" runat="server"></asp:Label>
                            <br />                        
                            <asp:DataPager ID="dprResumen" PagedControlID="lstv_resultados" PageSize="25" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Link" NextPageText="Siguiente" PreviousPageText="Anterior" ShowFirstPageButton ="true" LastPageText="Ultimo"
                                    ShowLastPageButton="true" FirstPageText="Primero"/>                                    
                                </Fields>
                            </asp:DataPager>
                        </div>
                        <br />
                        <br />                                            
                                            
                    </div>
                </div>                
                <div class="rm_foother">                
                </div>                
            </div>   
    </form>
</body>
</html>
