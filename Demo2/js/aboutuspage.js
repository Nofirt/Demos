

//About us page
$(document).ready(function () {

    //Hide Navigation bar
    $("header nav").hide();

    //Use fadeIn function to show it for 500miliseconds
    $("header nav").fadeIn(500);

    //Hide image from element with id aboutus-info in figure

    $("#aboutus-info figure img").hide();

    //Show it with slideDown method

    $("#aboutus-info figure img").slideDown(1500);

    //Hide h3,p,spanin d aboutus-info in aside in fieldset

    $("#aboutus-info aside fieldset h3,p,span").hide();

    //Show the first child

    $("#aboutus-info aside fieldset:nth-child(1) h3,p,span").fadeIn(2500);

    //Show the second child

    $("#aboutus-info aside fieldset:nth-child(2) h3,p,span").fadeIn(2500);

    //Show the third child

    $("#aboutus-info aside fieldset:nth-child(3) h3,p,span").fadeIn(2500);

    //Show the fourth child

    $("#aboutus-info aside fieldset:nth-child(4) h3,p,span").fadeIn(2500);

    //Hide footer 

    $("footer").hide();

    //Slide it down with slideDown method

    $("footer").slideDown(1300);
});