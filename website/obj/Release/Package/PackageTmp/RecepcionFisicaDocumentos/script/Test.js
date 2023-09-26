var URL;
var numeroDocumento;
function OpenVisor(btn) {

    row = $(btn).parent().parent();
    numeroDocumento = $("#Span1", row).text();
    URL = '../AlfanetImagenes/VisorImagenes/Visor.aspx?DocumentoCodigo=' + numeroDocumento + '&GrupoCodigo=4&GrupoPadreCodigo=1&Admon=S&ImagenFolio=1';
    window.open(URL, 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes')

   // alert(numeroDocumento);
}