<%@ Page Title="Pruebas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pruebas.aspx.cs" Inherits="WebApplication1.WebPrueba.Pruebas" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div>
<h4 >Modulo de pruebas</h4>
</div>
<div>
<table style = "width:50%;">
                <tr>
                    <td style="width:20%;">                        
                    </td>
                    <td style="width:20%;">
                        <asp:Button ID="btnInsert" runat="server" 
                            Text="Insertar registro" onclick="btnInsert_Click" Width="148px" />
                    </td>
                    <td>
                    
                    </td>                    
                </tr>
                <tr>
                    <td style="width:20%;">
                        <asp:TextBox ID="txtRegistroUpdate" runat="server"></asp:TextBox>
                    </td>
                    <td style="width:20%;">
                        <asp:Button ID="btnUpdate" style="width:100%;" runat="server" 
                            Text="Actualizar registro" onclick="btnUpdate_Click" />
                    </td>
                    <td>
                    </td>                    
                </tr>
                <tr>
                    <td style="width:20%;">
                        <asp:TextBox ID="txtDelete" runat="server"></asp:TextBox>
                    </td>
                    <td style="width:20%;">
                        <asp:Button ID="btnDelete" style="width:100%;" runat="server" 
                            Text="Eliminar registro" onclick="btnDelete_Click" />
                    </td>
                    <td>
                    </td>                    
                </tr>
            </table>
</div>
    <asp:Label ID="LblResult" runat="server" Font-Bold="True" Font-Size="Large" ></asp:Label>
<br />
<br />
<asp:GridView ID="GridView1" runat="server">
</asp:GridView>
</asp:Content>
