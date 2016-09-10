
//Contacts Page
$(document).ready(function () {

    //Hide navigation bar

    $("header nav").hide();

    //Fade it in with fadeIn function

    $("header nav").fadeIn(700);
    
    //Hide google map

    $("#map-container").hide();

    //Show is with slideDown method

    $("#map-container").slideDown(700);
    
    //Hide element with infotext id
    
    $("#infotext").hide();

    //Show it

    $("#infotext").show(700);
    
    //Hide element with id contacts-info

    $("#contacts-info").hide();

    //Show it
    
    $("#contacts-info").show(700);

});