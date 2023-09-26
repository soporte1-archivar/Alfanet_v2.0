function pageLoad() {

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

$(function () {
    $("#myTabs").tabs();
});