

function DisplayDialog() {    
    $("#editForm").show();
}

function CloseDialog() {
    $("#editForm").hide();
}


//function pageLoad() {

//    $(function () {
//        $(".fechaInicial").datepicker({
//            changeMonth: true,
//            changeYear: true,
//            dateFormat: 'yy/mm/dd'
//        });
//    });

//    $(function () {
//        $(".fechaFinal").datepicker({
//            changeMonth: true,
//            changeYear: true,
//            dateFormat: 'yy/mm/dd'
//        });
//    });
//}

$(document).ready(function () {

    $(function () {
        $(".fechaInicial").datepicker({
            changeMonth: true,
            changeYear: true,
            dateFormat: 'yy/mm/dd'
        });
    });

    $(function () {
        $(".fechaFinal").datepicker({
            changeMonth: true,
            changeYear: true,
            dateFormat: 'yy/mm/dd'
        });
    });

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

});