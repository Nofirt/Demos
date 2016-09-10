

//About us page
$(document).ready(function () {
    $("header nav").hide();
    $("header nav").fadeIn(500);
    $("#testimonials").hide();
    $("#aboutus-info figure img").hide();
    $("#aboutus-info figure img").slideDown(1500);
    $("#aboutus-info aside fieldset h3,p,span").hide();

    $("#aboutus-info aside fieldset:nth-child(1) h3,p,span").fadeIn(2500);

    $("#aboutus-info aside fieldset:nth-child(2) h3,p,span").fadeIn(2500);

    $("#aboutus-info aside fieldset:nth-child(3) h3,p,span").fadeIn(2500);

    $("#aboutus-info aside fieldset:nth-child(4) h3,p,span").fadeIn(2500);
    
    $("footer").hide();
    $("footer").slideDown(2500);
});