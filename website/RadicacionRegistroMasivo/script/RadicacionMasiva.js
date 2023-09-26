
$(document).ready(function () {

    //    $('#fuFiles').uploadify({
    //        'uploader': '../image/uploadify.swf',
    //        'script': '../FileUploads.aspx',
    //        'cancelImg': '../image/cancel.png',
    //        'auto': 'true',
    //        'multi': 'true',
    //        'buttonText': 'Seleccione...',
    //        'queueSizeLimit': 50
    //    });

//    $("#dialog-confirm").dialog({
//        resizable: false,
//        autoOpen: false,
//        height: 180,
//        modal: true,
//        buttons: {
//            "Continuar": function () {
//                $(this).dialog("close");
//                return true;
//            },
//            Cancel: function () {
//                $(this).dialog("close");
//                return false;
//            }
//        }
//    });

//    $("#btnValidateImages").click(function () {
//        $("#dialog-confirm").dialog("open");
//    });

    $('.btns').click(function () {
        $.blockUI({ css: {
            border: 'none',
            padding: '15px',
            backgroundColor: '#000',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: .5,
            color: '#fff'
        }
        });
        //setTimeout($.unblockUI, 10000);
    });

    $('.btns2').click(function () {
        $.blockUI({ css: {
            border: 'none',
            padding: '15px',
            backgroundColor: '#000',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: .5,
            color: '#fff'
        }
        });
        setTimeout($.unblockUI, 2000);
    });

    $(".rm_txtnaturalezas").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "../RadicacionMasiva/Ajax.asmx/GetNaturalezas",
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

    $(".rm_txtdestino").autocomplete({
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

    //    $(".rm_txtaccion2").autocomplete({
    //        source: function (request, response) {
    //            $.ajax({
    //                type: "POST",
    //                contentType: "application/json; charset=utf-8",
    //                url: "../RadicacionMasiva/Ajax.asmx/GetCiudades2",
    //                data: "{'keyword':'" + request.term + "'}",
    //                dataType: "json",
    //                success: function (data) {
    //                    response(data.d);
    //                },
    //                error: function (xhr, status, error) {
    //                    alert('Uncaught Error.\n' + xhr.responseText);
    //                }
    //            });
    //        },
    //        minLength: 2
    //    });  


    $(".rm_txtmedio").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "../RadicacionMasiva/Ajax.asmx/GetMedios",
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

    $(".rm_txtExpediente").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "../RadicacionMasiva/Ajax.asmx/GetExpedientes",
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
        minLength: 3
    });

});


