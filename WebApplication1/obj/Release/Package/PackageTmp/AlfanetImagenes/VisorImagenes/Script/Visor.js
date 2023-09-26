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