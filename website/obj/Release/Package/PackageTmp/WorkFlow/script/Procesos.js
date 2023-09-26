
function RedirectDocument(btn) {    
    //document.getElementById("btnFinalizar").disabled = true;
//    var result = "";
//    var numDocument = $(".lblNumDocument").text();
//    var dependenciaDestino = $(".txtDependencias").val();
//    var accion = $(".txtAccion").val();
//    var aux = trim(dependenciaDestino, " ");
//    var aux2 = trim(accion, " ");
//    alert(numDocument + dependenciaDestino);
//    if (aux == "" || aux2 == "") {
//        return false;
//    }
//    $.ajax({
//        type: "POST",
//        contentType: "application/json; charset=utf-8",
//        url: "../WorkFlow/Ajax.asmx/RedirectDocument",
//        data: "{'numDocument':'" + numDocument + "', 'dependenciaDestino':'" + aux + "'}",
//        dataType: "json",
//        async: true,
//        success: function (data) {
//            result = data.d;
//            if (result == "OK") {
//                alert(result);//ESTO DEBE SER UN MODAL WINDOW.
//            }
//        },
//        error: function (xhr, status, error) {
//            alert('Uncaught Error.\n' + xhr.responseText);            
//        }
//    });
//    if (result != "OK") {
//        return false;
//    }
//    else {
//        return true;
//    }
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