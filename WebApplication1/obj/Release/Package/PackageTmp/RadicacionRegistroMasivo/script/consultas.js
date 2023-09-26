var numeroDocumento;
var fechaRadicacion;
var procedencia;
var detalle;
var row;
var clicked = 0;
var regOasis;
var remision;
var facPrestador;
var expediente;
var procNui;
var facn_empresa;
var facc_documento;
var facn_ubicacion;
var facv_total;
var facc_estado;
var facc_prefijo;
var facn_factura2;
var facc_alto_costo;
var facf_confirmacion;
var facv_copago;
var facv_responsable;
var facc_conciliado;
var facv_imputable;
var facf_radicado;
var facf_final;
//var facc_digitalizado;
var facc_almacenamiento;
var cntc_concepto;
var conc_nombre;
var facn_recibo;

function pageLoad() {
    if (clicked == 1) {
        //alert("entro");
        $(".rm_data_container").hide();
        var content = "#tab-2" //$(this).find("a").attr("href");
        location.hash = content; //Add the anchor to the url (for refresh)
        $(content).fadeIn();        
    }

    $(function () {
        $(".fechaInicial").datepicker({
            changeMonth: true,
            changeYear: true,
            dateFormat: 'mm/dd/yy'
        });
    });

    $(function () {
        $(".fechaFinal").datepicker({
            changeMonth: true,
            changeYear: true,
            dateFormat: 'mm/dd/yy'
        });
    });

    $(".rm_txtaccion2").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "../RadicacionMasiva/Ajax.asmx/GetCiudades2",
                data: "{'keyword':'" + request.term + "'}",
                dataType: "json",
                success: function (data) {
                    response(data.d);
                },
                error: function (xhr, status, error) {
                    alert('Uncaught Error.\n' + xhr.responseText);
                }
            });
        },
        minLength: 2
    });

    $(".rm_txtnombreonit").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "../RadicacionMasiva/Ajax.asmx/GetProcedencias",
                data: "{'keyword':'" + request.term + "'}",
                dataType: "json",
                success: function (data) {
                    response(data.d);
                },
                error: function (xhr, status, error) {
                    alert('Uncaught Error.\n' + xhr.responseText);
                }
            });
        },
        minLength: 4
    });

    $(".txtRadicador").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "../RadicacionMasiva/Ajax.asmx/GetDependencias",
                data: "{'keyword':'" + request.term + "'}",
                dataType: "json",
                success: function (data) {
                    response(data.d);
                },
                error: function (xhr, status, error) {
                    alert('Uncaught Error.\n' + xhr.responseText);
                }
            });
        },
        minLength: 2
    });

}
//$(document).ready(function () {

//});

function OpenEdit(btn) {
    //OBTENER VALORES PARA LOS CAMPOS
    
    row = $(btn).parent().parent();
    numeroDocumento = $("#Span1", row).text();
    fechaRadicacion = $("#Span2", row).text();
    procedencia = $("#Span3", row).text();
    detalle = $("#Span4", row).text();
    regOasis = $("#Span11", row).text();
    remision = $("#Span12", row).text();
    facPrestador = $("#Span5", row).text();
    expediente = $("#Span9", row).text();
    procNui = $("#ProcedenciaNUI", row).text();
    facn_empresa = $("#Facn_empresa", row).text();
    facc_documento = $("#Facc_documento", row).text();
    facn_ubicacion = $("#Facn_ubicacion", row).text();
    facv_total = $("#Facv_total", row).text();
    facc_estado = $("#Facc_estado", row).text();
    facc_prefijo = $("#Facc_prefijo", row).text();
    facn_factura2 = $("#Facn_factura2", row).text();
    facc_alto_costo = $("#Facc_alto_costo", row).text();
    facf_confirmacion = $("#Facf_confirmacion", row).text();
    facv_copago = $("#Facv_copago", row).text();
    facv_responsable = $("#Facv_responsable", row).text();
    facc_conciliado = $("#Facc_conciliado", row).text();
    facv_imputable = $("#Facv_imputable", row).text();
    facf_radicado = $("#Facf_radicado", row).text();
    facf_final = $("#Facf_final", row).text();
    //facc_digitalizado = $("#Facc_digitalizado", row).text();
    facc_almacenamiento = $("#Facc_almacenamiento", row).text();
    cntc_concepto = $("#Cntc_concepto", row).text();
    conc_nombre = $("#Conc_nombre", row).text();
    facn_recibo = $("#Facn_recibo", row).text();
    
    //FIN OBTENER VALORES PARA LOS CAMPOS


    //LLENAR LOS DATOS DEL FORMULARIO    
    $(".txtRadicadoCodigo").val(numeroDocumento);
    $(".spm_fecharadicacion").val(fechaRadicacion);
    $(".procedencia").val(procedencia);
    $(".txtDetalle").val(trim(detalle," "));
    $(".txtRegistroOasis").val(regOasis);
    $(".txtRemision").val(remision);
    $(".txtFacPrestador").val(facPrestador);
    $(".txtExpediente").val(expediente);
    $(".txtProcNui").val(procNui);
    $(".txtFacn_empresa").val(facn_empresa);
    $(".txtFacc_documento").val(facc_documento);
    $(".txtFacn_ubicacion").val(facn_ubicacion);
    $(".txtFacv_total").val(facv_total);
    $(".txtFacc_estado").val(facc_estado);
    $(".txtFacc_prefijo").val(facc_prefijo);
    $(".txtFacn_factura2").val(facn_factura2);
    $(".txtFacc_alto_costo").val(facc_alto_costo);
    $(".txtFacf_confirmacion").val(facf_confirmacion);
    $(".txtFacv_copago").val(facv_copago);
    $(".txtFacv_responsable").val(facv_responsable);
    $(".txtFacc_conciliado").val(facc_conciliado);
    $(".txtFacv_imputable").val(facv_imputable);
    $(".txtFacf_radicado").val(facf_radicado);
    $(".txtFacf_final").val(facf_final);
    //$(".txtFacc_digitalizado").val(facc_digitalizado);
    $(".txtFacc_almacenamiento").val(facc_almacenamiento);
    $(".txtCntc_concepto").val(cntc_concepto);
    $(".txtConc_nombre").val(conc_nombre);
    $(".txtFacn_recibo").val(facn_recibo);
    
    //FIN LLENAR DATOS DEL FORMULARIO


    var content = "#tab-2";  //$(this).find("a").attr("href");
    location.hash = content; //Add the anchor to the url (for refresh)
    $(content).fadeIn();
    //$("ul.tabs li").removeClass("active");
    $(".rm_data_container").hide();
    clicked = 1;
}

function Regresar() {
    var content = "#tab-1";  //$(this).find("a").attr("href");
    location.hash = content; //Add the anchor to the url (for refresh)
    $(content).fadeIn();

    //$("ul.tabs li").removeClass("active");
    $(".rm_edit_content").hide();
    clicked = 0;
    //_doPostBack('', '');
    __doPostBack('btnBuscar', 'Click');
}

function putClicked() {
    clicked = 1;
    //alert(clicked);
}
function putNewDetalle() {
    var textDetalle = $(".txtDetalle").val();
    //alert(textDetalle);     
    $("#Span4", row).val(textDetalle);
}

function trim(str, chars) {
    return ltrim(rtrim(str, chars), chars);
}

function ltrim(str, chars) {
    chars = chars || "\\s";
    return str.replace(new RegExp("^[" + chars + "]+", "g"), "");
}
//rtrim quita los espacios o caracteres indicados al final de la cadena 
function rtrim(str, chars) {
    chars = chars || "\\s";
    return str.replace(new RegExp("[" + chars + "]+$", "g"), "");
}
//function Edit(btn) {
//    btn.Disabled = true;
//    var codigo = $("#spm_radicado").text();
//    var detalleUpdate = $(".txtDetalle").val();
//    if (detalleUpdate == detalle) {
//        detalleUpdate = "";
//    }
//    var comprobante = $(".txtComprobanteEgreso").val();
//    $.ajax({
//        type: "POST",
//        url: "../RadicacionMasiva/Ajax.asmx/UpdateFacturaRadicada",
//        data: "{'codigo':'" + codigo + "', 'detalle':'" + detalleUpdate + "', 'comprobante':'" + comprobante + "'}",        
//        error: function (xhr, status, error) {            
//            alert("Error al procesar esta soliciutd");
//            row.removeClass("highlightRow");
//            CloseReclasifyDialog();
//            document.getElementById("btnReclasificarTicket").disabled = false;
//        },
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (response) {
//            var result = response.d;
//            if (result != "") {
//                $("#Span4", row).text(result); //traer el nuevo estado.                    

//                btn.disabled = false;
//            }
//            else {
//                alert('Ocurrió un error durante la actualización');
//                btn.disabled = false;
//            }
//        },
//        failure: function (msg) {
//            alert(msg);
//            
//            btn.disabled = false;
//        }
//    });
//}