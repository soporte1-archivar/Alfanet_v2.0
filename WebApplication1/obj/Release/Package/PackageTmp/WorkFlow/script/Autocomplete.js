$(window).load(function () {

//    $.ajax({
//        type: "POST",
//        url: "../WorkFlow/Ajax.asmx/GetDependencias",
//        data: "{}",
//        error: function (jqXHR, exception) {
//            alert('Uncaught Error.\n' + jqXHR.responseText);            
//        },
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        async: true,
//        success: function (response) {
//            alert(response.d);
//        },
//        failure: function (msg) {
//            alert(msg);
//        }
//    });
    
//    $(".txtDependencias").autocomplete({
//        source: function (request, response) {            
//            $.ajax({
//                type: "POST",
//                contentType: "application/json; charset=utf-8",
//                url: "../WorkFlow/Ajax.asmx/GetDependencias",
//                data: "{'keyword':'" + request.term + "'}",                
//                dataType: "json",
//                //async: true,
//                success: function (data) {
//                    response(data.d);
//                },
//                error: function (xhr, status, error) {
//                    alert('Uncaught Error.\n' + xhr.responseText);
//                }
//            });            
//        },
//        //source:["test", "asp.net", "jQuery"],
//        minLength: 2
//    });

//    $(".txtAccion").autocomplete({
//        source: function (request, response) {
//            $.ajax({
//                type: "POST",
//                contentType: "application/json; charset=utf-8",
//                url: "../WorkFlow/Ajax.asmx/GetAcciones",
//                data: "{'keyword':'" + request.term + "'}",
//                dataType: "json",
//                //async: true,
//                success: function (data) {
//                    response(data.d);
//                },
//                error: function (xhr, status, error) {
//                    alert('Uncaught Error.\n' + xhr.responseText);
//                }
//            });
//        },
//        //source:["test", "asp.net", "jQuery"],
//        minLength: 1
//    });
});