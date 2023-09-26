//Visor de Imagenes Recibida
function VImagenes(evt, NumeroDocumento, Grupo) {
    var src = window.event != window.undefined ? window.event.srcElement : evt.target;
    hidden = open('../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=1&Admon=S&ImagenFolio=1', 'NewWindow', 'top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');

}