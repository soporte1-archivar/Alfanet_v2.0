<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication1.Admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" type="text/css" href="css/tab.css"/>
<script type="text/javascript" src="script/jquery-1.8.2.min.js"></script>
<script type="text/javascript" src="script/tabs.js"></script>
<%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.3/jquery.min.js" type="text/javascript"></script>--%>
<%--<script type="text/javascript" src="script/prueba.js"></script>--%>
    <title>Configuration</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ul class="tabs">
                <li class="active"><a href="#tab1">Grupos</a></li>
                <li><a href="#tab2">Submit</a></li>
            </ul>
            <div class="tab_container">
                <div id="tab1"  class="tab_content">
                    <asp:ListView ID="LVGrupo" runat="server" 
                        onselectedindexchanged="LVGrupo_SelectedIndexChanged">
                        <LayoutTemplate>
                            <table bgcolor="#AFFFFF">
                                <tr bgcolor="#FFFFFF">
                                    <%--<th bgcolor="#AFFFFF">
                                        <asp:CheckBox ID="CheckBox1" runat="server" Width="20px" />
                                    </th>
                                    <th bgcolor="#AFFFFF">
                                        <asp:Label ID="ImageButton1" runat="server" Width="20px" Text="prueba"/>
                                    </th>
                                    <th bgcolor="#AFFFFF">
                                        <asp:ImageButton ID="ImageButton2" runat="server" Width="20px" ImageUrl="~/Images/attachment.png" />
                                    </th>
                                    <th bgcolor="#AFFFFF">
                                        <asp:Label ID="Label1" runat="server" Width="20px" Text="prueba"/>
                                    </th>--%>
                                    <%--<td>
                                        <asp:Label ID="lab" runat="server" Text="asunto" Width="50px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="holaa" Width="100%"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ImageButton3" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="ho0laa"></asp:Label>
                                    </td>--%>
                                </tr>
                                <tbody>
                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                </tbody>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td bgcolor="#99ccff">
                                    <asp:TextBox ID="TBGrupoCodigo" runat="server" Text='<%# Eval("GrupoCodigo")%>' Enabled="false" ></asp:TextBox>
                                </td>
                                <td bgcolor="#99ccff">
                                    <asp:TextBox ID="TBGrupoNombre" runat="server" Text='<%# Eval("GrupoNombre")%>' Enabled="false" ></asp:TextBox>
                                </td>
                                <td bgcolor="#99ccff">
                                    <asp:TextBox ID="TBGrupoCodigoPadre" runat="server" Text='<%# Eval("GrupoCodigoPadre")%>' Enabled="false" ></asp:TextBox>
                                </td>
                                <td bgcolor="#99ccff">
                                    <asp:TextBox ID="TBGrupoConsecutivo" runat="server" Text='<%# Eval("GrupoConsecutivo")%>' Enabled="false" ></asp:TextBox>
                                </td>
                                <td bgcolor="#99ccff">
                                    <asp:TextBox ID="TBGrupoHabilitar" runat="server" Text='<%# Eval("GrupoHabilitar")%>' Enabled="false" ></asp:TextBox>
                                </td>
                                <td bgcolor="#99ccff">
                                    <asp:TextBox ID="TBGrupoPermiso" runat="server" Text='<%# Eval("Grupopermiso")%>' Enabled="false" ></asp:TextBox>
                                </td>
                                <td bgcolor="#99ccff">
                                    <asp:ImageButton ID="IBEditar" runat="server" ImageUrl="~/Administracion/images/editar.jpg" Width="20px"  />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="LVacio" runat="server" Text="esta vacio">
                            </asp:Label>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </div>
                <div id="tab2" class="tab_content"  style="display:none;">
                   <asp:TextBox ID="TBAlgo" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
