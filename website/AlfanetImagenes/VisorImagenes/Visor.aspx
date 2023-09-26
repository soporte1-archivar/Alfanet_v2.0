<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Visor.aspx.cs" Inherits="WebApplication1.AlfanetImagenes.VisorImagenes.Visor" %>

<%@ Register Assembly="Infragistics2.Web.v8.1" Namespace="Infragistics.Web.UI.LayoutControls"
    TagPrefix="ig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="Neodynamic.WebControls.ImageDraw" Namespace="Neodynamic.WebControls.ImageDraw" TagPrefix="neoimg" %>
<%@ Register Assembly="Infragistics2.Web.v8.1, Version=8.1.20081.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script src="Script/Visor.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    // <!CDATA[

    function exit() {

        window.close()

    }

    function confirmSubmit() {
        var agree = confirm("Esta Completamente Seguro que Desea Eliminar la Imagen?");
        if (agree)
            return true;
        else
            return false;
    }
    //function imprimir()
    //{ if ((navigator.appName == "IExplorer")) { window.print() ; 
    //} 
    //else
    //{ var WebBrowser = '<OBJECT ID="WebBrowser1" WIDTH=0 HEIGHT=0 CLASSID="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2"></OBJECT>'; 
    //document.body.insertAdjacentHTML('beforeEnd', WebBrowser); WebBrowser1.ExecWB(6, -1); WebBrowser1.outerHTML = "";
    //}
    //}

    function Print(evt)
    //    function Print()  
    {
        var src = window.event != window.undefined ? window.event.srcElement : evt.target;

        //window.location.reload();
        window.print();

    }

    function ClientSidePrint(idDiv) {
        var w = 600;
        var h = 400;
        var l = (window.screen.availWidth - w) / 2;
        var t = (window.screen.availHeight - h) / 2;

        var sOption = "toolbar=no,location=no,directories=no,menubar=no,scrollbars=yes,width=" + w + ",height=" + h + ",left=" + l + ",top=" + t;
        // Get the HTML content of the div
        var sDivText = window.document.getElementById(idDiv).innerHTML;
        // Open a new window
        var objWindow = window.open("", "Print", sOption);
        // Write the div element to the window
        objWindow.document.write(sDivText);
        objWindow.document.close();
        // Print the window            
        objWindow.print();
        // Close the window
        objWindow.close();
    }
    // ]]>
  </script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Visor Imagenes AlfaNet</title>
</head>
<body>

<form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
   </div>
   <div class="Splitters">
       <ig:WebSplitter id="VerticalSplitter" runat="server" StyleSetName="Default" DynamicResize="True" style="vertical-align: top; text-align: center">
       <SplitterBar CssClass="Default"></SplitterBar>
           <Panes>
               <ig:SplitterPane runat="server" CollapsedDirection="NextPane" Size="10%" MinSize="0px"><Template>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    <asp:Label ID="LNImagen"  runat="server"></asp:Label>
</Template>
</ig:SplitterPane>
               <ig:SplitterPane runat="server" CollapsedDirection="NextPane" Size="90%" MinSize="0px" ScrollBars="Hidden">
               <Template>
                 <div style="VERTICAL-ALIGN: top; TEXT-ALIGN: left; height: 100%;">
                 <table class="Container" cellPadding="2">
                 <tbody>
                 <tr class="viewerHeader">
                     <td valign="top" align="left">
                     <asp:UpdatePanel id="UpdatePanel1" runat="server">
                 <contenttemplate>
                 <TABLE style="WIDTH: 70%"><TBODY><TR><TD style="WIDTH: 32647px"><asp:Label id="LblDocumentoNro" runat="server" Width="110px" Font-Size="Small" ForeColor="Red" Text="Label" Font-Bold="True">
                 </asp:Label> </TD><TD><IMG alt="auto" id="imgclip" runat="server" src="Imagenes/ToolBar/file.gif" /> </TD><TD style="WIDTH: 339px"><asp:FileUpload id="FileUpload1" runat="server" Width="420px">
                 </asp:FileUpload></TD><TD style="WIDTH: 1265px" align="Right"><asp:Button style="BORDER-RIGHT: #3399ff thin solid; BORDER-TOP: #3399ff thin solid; BORDER-LEFT: #3399ff thin solid; BORDER-BOTTOM: #3399ff thin solid; BACKGROUND-COLOR: silver" id="BtnEnviar" onclick="BtnEnviar_Click" runat="server" Width="69px" Text="Adjuntar ..." CssClass="PointerCursor"></asp:Button></TD></TR></TBODY></TABLE><asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" BackColor="ButtonHighlight"><TABLE><TBODY><TR><TD style="BACKGROUND-COLOR: activecaption" align=center><asp:Label id="Label555" runat="server" Width="120px" Font-Size="14pt" ForeColor="White" Text="Mensaje" Font-Bold="False"></asp:Label></TD><TD style="BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="Imagenes/ToolBar/cross.png" ImageAlign="Right" CausesValidation="False" ValidationGroup="789"></asp:ImageButton> </TD></TR><TR><TD align="center" colspan="2"><BR /><asp:Label id="LblMessageBox" runat="server" Font-Size="Small" ForeColor="Black"></asp:Label><BR /><asp:Label id="LblUploadDetails" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label> </TD></TR></TBODY></TABLE></asp:Panel> <cc1:ModalPopupExtender id="MPEMensaje" runat="server" OkControlID="btnCerrar" DropShadow="True" PopupControlID="PnlMensaje" BackgroundCssClass="MessageStyle" TargetControlID="LblMessageBox"></cc1:ModalPopupExtender> 
                 </contenttemplate>  
                 <triggers>
                 <asp:PostBackTrigger ControlID="BtnEnviar"></asp:PostBackTrigger>
                 </triggers>
                 </asp:UpdatePanel>

         <table border="0">
    <tbody><tr><td style="width: 26px;" valign="baseline"><asp:ImageButton id="prevButton" onclick="prevButton_Click" runat="server" ImageUrl="Imagenes/ToolBar/prev.gif" CssClass="PointerCursor" AlternateText="Pagina Anterior..." ToolTip="Pagina Anterior..."></asp:ImageButton></TD><TD vAlign=baseline><asp:DropDownList id="ddlPages" runat="server" onselectedindexchanged="ddlPages_SelectedIndexChanged" AutoPostBack="True" CssClass="PointerCursor" ToolTip="Ir a la página..">
                    </asp:DropDownList></td><td valign=baseline><asp:ImageButton id="nextButton" onclick="nextButton_Click" runat="server" ImageUrl="Imagenes/ToolBar/next.gif" CssClass="PointerCursor" AlternateText="Pagina Siguiente..." ToolTip="Pagina Siguiente..."></asp:ImageButton></TD>
        <td align="left" style="width: 3px;" valign="middle">
            <asp:ImageButton ID="zoomMasButton" runat="server" AlternateText="Zoom In..." ToolTip="Acercar..." CssClass="PointerCursor" onclick="zoomMasButton_Click"
                ImageUrl="Imagenes/ToolBar/zoommas.gif"/></td>
        <td align="left" style="width: 3px;" valign="middle">
            <asp:ImageButton ID="zoomMenosButton" runat="server" AlternateText="Zoom Out..." ToolTip="Disminuir..." CssClass="PointerCursor" onclick="zoomMenosButton_Click"
                ImageUrl="Imagenes/ToolBar/zoommenos.gif" /></td>
        <td valign="middle" align="left">
        <asp:ImageButton id="rotarIzqButton" onclick="rotarIzqButton_Click" runat="server" ToolTip="Girar a la izquierda" ImageUrl="Imagenes/ToolBar/rotarizq.gif" CssClass="PointerCursor" AlternateText="Rotar a la izquierda...">
        </asp:ImageButton>
        <asp:ImageButton id="rotarDerButton" onclick="rotarDerButton_Click" runat="server" ToolTip="Girar a la derecha" ImageUrl="Imagenes/ToolBar/rotarder.gif" CssClass="PointerCursor" AlternateText="Rotar a la derecha..."></asp:ImageButton>
        </TD><TD vAlign=middle align=left></TD><TD style="WIDTH: 57px;" vAlign=middle align=left><asp:DropDownList id="ddlZoom" runat="server" onselectedindexchanged="ddlZoom_SelectedIndexChanged" AutoPostBack="True" CssClass="PointerCursor" ToolTip="Tamaño de la imágen...">
            
            <asp:ListItem Value="400">400%</asp:ListItem>
            <asp:ListItem Value="300">300%</asp:ListItem>
            <asp:ListItem Value="200">200%</asp:ListItem>
            <asp:ListItem Value="150">150%</asp:ListItem>
                        <asp:ListItem Value="100">100%</asp:ListItem>
                        <asp:ListItem Value="90">90%</asp:ListItem>
                        <asp:ListItem Value="80" Selected="True">80%</asp:ListItem>
            <asp:ListItem Value="70">70%</asp:ListItem>
            <asp:ListItem Value="60">60%</asp:ListItem>
            <asp:ListItem Value="50">50%</asp:ListItem>
            <asp:ListItem Value="40">40%</asp:ListItem>
            <asp:ListItem Value="30">30%</asp:ListItem>
            <asp:ListItem Value="20">20%</asp:ListItem>
                    </asp:DropDownList></TD><TD valign="middle" align="left"><asp:CheckBox id="chkWatermark" runat="server" Width="88px" Text="Confidencial" AutoPostBack="true" oncheckedchanged="chkWatermark_CheckedChanged" CssClass="PointerCursor"></asp:CheckBox>
                    </TD>
        <td align="left" valign="middle">
            <asp:ImageButton id="DeleteButton" Visible="true" onclick="DeleteButton_Click" runat="server" ImageUrl="Imagenes/ToolBar/Delete.png" CssClass="PointerCursor" AlternateText="Delete" OnClientClick='return confirmSubmit()' ToolTip="Elminar Imagen"></asp:ImageButton>
            <asp:LinkButton ID="LinkButton1" Visible="true" OnClick="DeleteButton_Click" runat="server" OnClientClick="return confirmSubmit()">Eliminar Imagen</asp:LinkButton>
        </td>
        <td align="left" valign="middle" style="width: 90px">
            <asp:Panel ID="PnlPrint" runat="server">
                <asp:ImageButton ID="ImageButton2" OnClick="ImageButtonguardar_click" runat="server" ImageUrl="Imagenes/icono_guardar.gif"
                    ToolTip="Guardar Imagen..." Visible="False" />
                <asp:ImageButton ID="ImgBtnPrintPDF" runat="server" Height="21px" ImageUrl="Imagenes/ToolBar/icono_pdf.gif"
                    Width="20px" OnClick="ImgBtnPrintPDF_Click" ToolTip="Guardar como PDF" />
            <asp:Image ID="ImgPrint" runat="server" ImageUrl="Imagenes/ToolBar/action_print.gif" Width="16px" ToolTip="Imprimir imágen"/>&nbsp;
                </asp:Panel>
        </td>
        <td align="left" style="width: 60px" valign="middle">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="Imagenes/ToolBar/cross.png"
                OnClientClick="return exit();" />
            <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="return exit();">Cerrar</asp:LinkButton></td>
    </TR></TBODY>
    </TABLE>
</td>
</tr><tr>
<td valign="top" align="center" colapan="3">
<div id ="currentPage" class="viewerContainer">
    


    
    <neoimg:ImageDraw ID="ImageDraw2" runat="server" CacheExpiresAtDateTime="" ImageFormat="Jpeg" Monochrome="False">
        <Canvas CenterElements="True" Fill-BackgroundColor="115, 111, 110" />
        <Elements>            
        <neoimg:ImageElement MultiPageIndex="0" Name="myTiff" UseSourceDpi="False" Source="File" NullImageUrl="Imagenes/icono_Blanco.JPG" ></neoimg:ImageElement>      
        </Elements>
    </neoimg:ImageDraw>
    
    <asp:Panel ID="Panel1" runat="server">
    <iframe id="FramePDF" name="iframe1" runat="server" enableviewstate="true" visible="false" style="width: 700px; height: 700px" frameborder="0" src="file:///C:/RepositorioFacturas/2012/12/6000286_9739542_1.pdf">
    
    </iframe>
     </asp:Panel>  
    &nbsp;</div>
</td>
</tr>
</tbody>
</table>
</div>
</Template>
               </ig:SplitterPane>
           </Panes>
       </ig:WebSplitter>
   </div>
   </form>
    
   


    
</body>
</html>
