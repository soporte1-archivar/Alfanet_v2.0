<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="2Sticker.aspx.cs" Inherits="WebApplication1.RadicacionRegistroMasivo.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagName="Sticker" Src="~/RadicacionRegistroMasivo/Sticker/Sticker.ascx" TagPrefix="uc2" %>
<%@ Register TagName="ControlTest" TagPrefix="ct" Src="~/RadicacionRegistroMasivo/Sticker/ControlTest.ascx" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Sticker Impresion</title>
     <script language="javascript" type="text/javascript">
         function exit() {

             window.close()

         }
    </script>
    
    
</head>
<body>    
    <form id="form1" runat="server">
        
    <asp:ListView ID="lstvObjectSticker" runat="server" Visible="true" 
        onitemdatabound="lstvObjectSticker_ItemDataBound">
        <ItemTemplate>         
        <uc2:Sticker ID="Item" runat="Server"></uc2:Sticker>
        </ItemTemplate>
    </asp:ListView>
    
    <asp:ListView runat="server">
        <ItemTemplate>
         <uc2:Sticker ID="Item" runat="Server"></uc2:Sticker>
        <%--<asp:CheckBox runat=server  />  --%>  
        </ItemTemplate>
    </asp:ListView>
       
    <br />
    <br />
    <br />
       
    </form>
</body>
</html>
