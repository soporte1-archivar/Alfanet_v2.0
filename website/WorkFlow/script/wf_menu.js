var clicked = 0;
var numeroDocumento;
var procedenciaNombre;
var naturalezaNombre;
var wfAccionNombre;
var dependenciaNombre;
var wfMovimientosNotas;
var radicadoDetalle;
var fechaVencimiento;
var fechaRadicacion;
var numeroExterno;
var fechaProcedencia;
var medioNombre;
var expediente;
var dependenciaDestino;
var anexo;
var respuesta;
function pageLoad() {
    if (clicked == 1) {
        $("ul.tabs li").removeClass("active");        
        $(".wf_tab_content").hide();

        var content = "#tab-9" //$(this).find("a").attr("href");
        location.hash = content; //Add the anchor to the url (for refresh)
        $(content).fadeIn();      
    } else {
        var hash = window.location.hash.substr(1);
        var href = $('ul.tabs li a').each(function () {
            var href = $(this).attr('href');
            href = href.substr(1);
            if (hash == href) {
                $(".wf_tab_content").hide();
                $("ul.tabs li").removeClass("active");
                $(this).parent('li').addClass("active");
                $('#' + hash).fadeIn();
            }
        })
    }

    $(".txtDependencias").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "../WorkFlow/Ajax.asmx/GetDependencias",
                data: "{'keyword':'" + request.term + "'}",
                dataType: "json",
                //async: true,
                success: function (data) {
                    response(data.d);
                },
                error: function (xhr, status, error) {
                    alert('Uncaught Error.\n' + xhr.responseText);
                }
            });
        },
        //source:["test", "asp.net", "jQuery"],
        minLength: 2
    });

    $(".txtAccion").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "../WorkFlow/Ajax.asmx/GetAcciones",
                data: "{'keyword':'" + request.term + "'}",
                dataType: "json",
                //async: true,
                success: function (data) {
                    response(data.d);
                },
                error: function (xhr, status, error) {
                    alert('Uncaught Error.\n' + xhr.responseText);
                }
            });
        },
        //source:["test", "asp.net", "jQuery"],
        minLength: 1
    });

    $("ul.tabs li").click(function () {
        $("ul.tabs li").removeClass("active");
        $(this).addClass("active");
        $(".wf_tab_content").hide();

        var content = $(this).find("a").attr("href");
        location.hash = content; //Add the anchor to the url (for refresh)
        $(content).fadeIn();
        clicked = 0;
        $("#pnlContenedorBotones").removeClass("wf_pnl_active");
        return false;
    });


    $(".wf_btnBuscar").click(function () {
        var value = $(".wf_txtbuscar").val();
        var aux = trim(value, " ");
        $(".wf_txtbuscar").val(aux);
        if (aux == "") {
            return false;
        }
        $("ul.tabs li").removeClass("active");        
        $(".wf_tab_content").hide();

        var content = "#tab-9" //$(this).find("a").attr("href");
        location.hash = content; //Add the anchor to the url (for refresh)
        $(content).fadeIn();        
        clicked = 1;
    });
};

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

function showdocument (btn) {
    $("ul.tabs li").removeClass("active");    
    $(".wf_tab_content").hide();
    row = $(btn).parent();
    numeroDocumento = $("#Span1", row).text();
    procedenciaNombre = $("#Span2", row).text();
    naturalezaNombre = $("#Span3", row).text();
    wfAccionNombre = $("#Span4", row).text();
    dependenciaNombre = $("#Span5", row).text();
    wfMovimientosNotas = $("#Span6", row).text();
    radicadoDetalle = $("#Span7", row).text();
    fechaVencimiento = $("#Span8", row).text();
    fechaRadicacion = $("#Span9", row).text();
    numeroExterno = $("#Span10", row).text();
    fechaProcedencia = $("#Span11", row).text();
    medioNombre = $("#Span12", row).text();
    expediente = $("#Span13", row).text();
    dependenciaDestino = $("#Span14", row).text();
    anexo = $("#Span15", row).text();
    respuesta = $("#Span16", row).text();
    
    $(".lblNumDocument").val(numeroDocumento);
    $("#txtFechaRadicacion").val(fechaRadicacion);
    $("#txtNumExterno").val(numeroExterno);
    $("#txtFechaProcedencia").val(fechaProcedencia);
    $("#txtFechaVencimiento").val(fechaVencimiento);
    $("#txtProcedencia").val(procedenciaNombre);
    $("#txtDetalle").val(radicadoDetalle);
    $("#txtNaturaleza").val(naturalezaNombre);
    $("#txtMedio").val(medioNombre);
    $("#txtExpediente").val(expediente);
    $("#txtCargadoA").val(dependenciaDestino);
    $("#txtAccion").val(wfAccionNombre);
    $("#txtAnexos").val(anexo);
    $("#txtRespuestas").val(respuesta);
    
    $("#pnlContenedorBotones").addClass("wf_pnl_active");
    var content = "#tab-10";  //$(this).find("a").attr("href");
    location.hash = content; //Add the anchor to the url (for refresh)
    $(content).fadeIn();
    return false;
}