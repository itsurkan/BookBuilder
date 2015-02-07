$(document).ready(function () {
    //$(window).on('resize', function(event) {
    //    var n = $("body").width();

    //    if (n < 935) {
    //        $("#superUserImg").css("margin-left", "25%");
    //    } else {
    //        $("#superUserImg").css("margin-left", "auto");
    //    }
    //});    
    function hideAllSmall(id) {
        $(".small").css("visibility", "hidden");
        $(".hr-role").css("visibility", "hidden");
        $(id).css("visibility", "visible");
    }
    $("#demo-small").on('click', function (event) {
        hideAllSmall("#demo-full"); 
    });
    $("#simpleU-small").on('click', function (event) {
        hideAllSmall("#simpleU-full"); 
    });
    $("#gold-small").on('click', function (event) {
        hideAllSmall("#gold-full");
    });
    $("#platinum-small").on('click', function (event) {
        hideAllSmall("#platinum-full");
    });
    $("#simpleA-small").on('click', function (event) {
        hideAllSmall("#simpleA-full");
    });
    $("#super-small").on('click', function (event) {
        hideAllSmall("#super-full");
    });
    $(".close").click(function () {
        $("#demo-full").css("visibility", "hidden");
        $("#simpleU-full").css("visibility", "hidden");
        $("#gold-full").css("visibility", "hidden");
        $("#platinum-full").css("visibility", "hidden");
        $("#simpleA-full").css("visibility", "hidden");
        $("#super-full").css("visibility", "hidden");
        $(".small").css("visibility", "visible");
        $(".hr-role").css("visibility", "visible");
    });    
}); 