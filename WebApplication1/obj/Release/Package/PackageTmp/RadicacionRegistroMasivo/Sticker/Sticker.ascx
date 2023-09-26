<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Sticker.ascx.cs" Inherits="WebApplication1.RadicacionRegistroMasivo.Sticker.Sticker" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Panel ID="Panel2" runat="server" Height="160px" Width="400px" 
    HorizontalAlign="Left" style="margin-top: 0px">
                       <asp:Panel ID="PnlSticker" runat="server" HorizontalAlign="Center" Style="text-align: left "
                            Width="400px" BorderWidth="0px" Direction="LeftToRight">
                            <table style="width: 100%; height: 100%; line-height: normal;">
                                <tr>
                                    <td colspan="3">
                            <asp:Label ID="LblCliente" runat="server" Text="SUPERINTENDENCIA DE PUERTOS Y TRANSPORTES"
                                Font-Size="7pt" Font-Bold="False"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="1" style="width: 190px; text-align: left;">
                            <asp:Label ID="Label1" runat="server" Font-Size="X-Small" Text="Fecha:  "></asp:Label><asp:Label ID="LblStickerFecRad" runat="server" Font-Size="X-Small" Font-Bold="False"></asp:Label></td>
                                    
                                    <td colspan="1" style="text-align: left; width: 170px;">
                                        <asp:Label ID="Label6" runat="server" Font-Size="X-Small" Text="Hora:  "></asp:Label><asp:Label ID="Label17" runat="server" Font-Size="X-Small" Text="Hora:  "></asp:Label></td>
                                    
                                    <td colspan="1" style="text-align: left; width: 200px;">
                                    
                                    <asp:Label ID="Label3" runat="server"
                                    Font-Size="X-Small"> FOLIOS: </asp:Label><asp:Label ID="Label19" runat="server" Font-Size="X-Small"> FOLIOS: </asp:Label></td>
                                    <%--<td colspan="1" style="text-align: left; width: 35%;">
                                    </td>--%>
                                    
                                </tr>
                                <tr>
                                    <td colspan="3" style="vertical-align: text-top">
                            <asp:Label ID="Label8" runat="server" Font-Bold="False" Font-Size="X-Small" 
                                Text="Radicado No:"></asp:Label><asp:Label ID="LblStickerNroRad" runat="server" Font-Bold="True"
                                Font-Size="Small"></asp:Label><asp:Label ID="Label13" runat="server" Font-Size="XX-Small" Text=" RADICADOR:  " Visible="False"></asp:Label><asp:Label ID="LblStickerUsr" runat="server" Font-Size="XX-Small" Font-Bold="False" Visible="False"></asp:Label><br />
                            <asp:Label ID="LabelProcedencia" runat="server" Font-Bold="False" Font-Size="X-Small" 
                                Text="Procedencia:" Width="76px"></asp:Label><asp:Label ID="Label18" runat="server"
                                    Font-Bold="False" Font-Size="X-Small" Text="Procedencia:"></asp:Label></td>
                                </tr>
                               
                               
                                <tr>
                                    <td colspan="3" style="width: 375px">
                            <asp:Label ID="Label11" runat="server" Font-Size="X-Small" Text="TRAMITE A:.     " Width="74px"></asp:Label><asp:Label ID="LblStickercargarA" runat="server" Font-Bold="False" Font-Size="XX-Small"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="3" rowspan="1" style="width: 375px">
                            <asp:Label ID="Label2" runat="server" Font-Size="X-Small" Text="DIRECCION: "></asp:Label><asp:Label ID="LblDireccion" runat="server" Font-Size="X-Small" 
                                Font-Bold="False"></asp:Label></td>
                                </tr>
                                <tr>
                                 <td style="width: 375px" colspan="3">
                                     <asp:Label ID="Label4" runat="server" Font-Size="X-Small" Text="CIUDAD: " 
                                         Visible="False"></asp:Label>
                                     <asp:Label ID="Label5" runat="server" Font-Size="X-Small"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                   
                                </tr>
                            </table>
                        </asp:Panel>
        </asp:Panel>
