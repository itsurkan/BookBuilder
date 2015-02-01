$(document).ready(function(){ 
    window.onresize = function(event) {
        var n = $("body").width();

        if (n < 935) {
            $("#superUserImg").css("margin-left", "25%");
        } else {
            $("#superUserImg").css("margin-left", "auto");
        }
    }
}); 