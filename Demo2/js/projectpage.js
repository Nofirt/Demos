
//Projects Page

$(document).ready(function () {

    //Hide the navigation bar

    $("header nav").hide();

    //Fade in the navigation bar

    $("header nav").fadeIn(500);

    //Hide element with id project-page-project

    $(".project-page-projects").hide();
    
     //Fade in the id project-page-project

    $(".project-page-projects").fadeIn(600);
    
    //Hide element with id project-page-project

    $(".project-page-carousel-container").hide();

     //Fade in the id project-page-project
    
    $(".project-page-carousel-container").fadeIn(1000);
    
    //Hide element with id project-page-project

    $("#side-menu").hide();

     //Fade in the id project-page-project
     
    $("#side-menu").slideDown("slow");

    //Smooth slide
    //Select every anchor element that contains # in the begging of it's href but it's not equal to #
    //Attach click function to sthe selected elements
    
    var list = $("a[href=#first-project],a[href=#second-project],a[href=#third-project],a[href=#fourth-project],a[href=#fifth-project]");
    list.click(function () {

        //Select html and body tags from DOM and attach to them animate function

        $("html, body").animate({

            //Use scrolltop for every of the anchor elements with
            //attribute href and set the coordinates of each element from top

            scrollTop: $($(this).attr("href")).offset().top
        }, 700);
        return false;
    });
    //End of smooth slide


    //Side-menu functionality
    var exit = 0;
    $("#open-close-calculator").click(function () {
        if (exit == 1) {
            exit = 0;
            $("#side-menu").animate({
                left: "+=40%",
            });
            $("#open-close-calculator h4").replaceWith("<h4>Calculate Renovation</h4>");
        }
        else {
            exit++;
            $("#side-menu").animate({
                left: "-=40%",
            });
            $("#open-close-calculator h4").replaceWith("<h4>Close</h4>");
        }
    });
    //End of side-menu functionality


    //Calculator functionality

    //Objects containing the index for select option value element as key of outer object,
    //the key of inner object is the width of material and the value is the price 

    var eps = {
        0: { 5: "32" },
        1: { 6: "33" },
        2: { 7: "34" },
        3: { 8: "35" }
    };
    var neopor = {
        0: { 4: "34" },
        1: { 5: "37" },
        2: { 6: "38" },
        3: { 7: "39" },
        4: { 8: "40" }
    };


    // Function that output the index, width and price of isolation materials
    $(function () {
        //Attach an on change event to catch when option value of select element will change

        $("select[name='material']").on("change", function () {

            
            //Hide these options that are not choose

            $("select[name='widthOfMaterial']").html("");

            //Check which material has been chosen

            if ("eps" == $(this).val()) {
                for (var widthOfMaterial in eps) {

                    // Index of widthOfMaterial is the value for html select-option-value 

                    for (price in eps[widthOfMaterial]) {

                        //Index of price variable is width of material
                        //The value of price is the actual price

                        $("select[name='widthOfMaterial']")
                            .append("<option value='" + (widthOfMaterial) + "'>" +
                            price + "cm" + " | " + eps[widthOfMaterial][price] + " lv m<sup>2</sup>" + "</option>")
                            .show();
                    }
                }
            } else {
                for (var widthOfMaterial in neopor) {

                    // Index of widthOfMaterial is the value for html select-option-value 

                    for (price in neopor[widthOfMaterial]) {
                        $("select[name='widthOfMaterial']")
                            .append("<option value='" + (widthOfMaterial) + "'>" + price + "cm" + " | "
                            + neopor[widthOfMaterial][price] + " lv m<sup>2</sup>" + "</option>")
                            .show();
                    }
                }
            }
        });
    });

    //Global variables in the scope of this function
    var getPrice;
    var qMeters = 0, scaffold = 0, strips = 0, roofs = 0, mRunner = 0;
    //Calculate sum of the input values
    $(function () {

        //Check if scaffold checkbox is checked or unchecked and assign and unassign value 

        $("input[name=scaffold]").change(function () {
            var ischecked = $(this).is(":checked");
            if (!ischecked) {
                scaffold = 0;
                console.log("scaffold = " + scaffold);
            } else {
                scaffold = $("input[name=scaffold]").val();
                console.log("scaffold = " + scaffold);
            }
        });

        //Check if strips checkbox is checked or unchecked and assign and unassign value

        $("input[name=strips]").change(function () {
            var ischecked = $(this).is(":checked");
            if (!ischecked) {
                strips = 0;
                console.log("strips = " + strips);
            } else {
                strips = $("input[name=strips]").val();
                console.log("strips = " + strips);
            }
        });

        //Check if roofs checkbox is checked or unchecked and assign and unassign value

        $("input[name=roofs]").change(function () {
            var ischecked = $(this).is(":checked");
            if (!ischecked) {
                roofs = 0;
                console.log("roofs = " + roofs);
            } else {
                roofs = $("input[name=roofs]").val();
                console.log("roofs = " + roofs);
            }
        });

        //Check if mRunner checkbox is checked or unchecked and assign and unassign value

        $("input[name=mRunner]").change(function () {
            var ischecked = $(this).is(":checked");
            if (!ischecked) {
                mRunner = 0;
                console.log("mRunner = " + mRunner);
            } else {
                mRunner = $("input[name=mRunner]").val();
                console.log("mRunner = " + mRunner);
            }
        });

        //Get the price of material that user choose

        $("select[name='widthOfMaterial']").change(function () {
            var getResult = $("select[name='widthOfMaterial'] option:selected").text();
            getPrice = parseInt(getResult.slice(6, 8));
            console.log("Get price = " + getPrice);
        });

        //After user type some number in the input all the selected elements will be calculated 
        //and the ruslt will be saved in variable called result

        $("input[name=quantity]").keyup(function () {
            qMeters = $("input[name=quantity]").val();
            console.log("qMeters = " + qMeters);
            Calculate(getPrice, qMeters, scaffold, strips, roofs, mRunner);
        });
    });

    //Function that Calculate all from user

    function Calculate(getPrice, qMeters, scaffold, strips, roofs, mRunner) {

        //Just for check

        console.log("Values in function calculate ");
        console.log("getPrice " + getPrice);
        console.log("qMeters " + qMeters);
        console.log("scaffold " + scaffold);
        console.log("strips " + strips);
        console.log("roofs " + roofs);
        console.log("mRunner " + mRunner);

        //Variable result multiply qMeters with every other value and after that sum up them

        var result = (qMeters * scaffold) +
            (qMeters * strips) +
            (qMeters * roofs) +
            (qMeters * mRunner) +
            (getPrice * qMeters);
        console.log("Total is " + result);

        //Check if the result is NaN to not show it

        if (!isNaN(result)) {
            $("#total").text(result + " lv");
        }
    }
    //End of Calculator functionality



    //Menu button hide ahd show information about the project
    //Select each button and use function FadeToggle to show and hide it
    $("#but-info-1").click(function () {
        var link = $(this);
        $(".hidden-info-1").fadeToggle(600, function () {
            if ($(this).is(":visible")) {
                link.text("Hide");
            } else {
                link.text("More");
            }
        });
    });
    $("#but-info-2").click(function () {
        var link = $(this);
        $(".hidden-info-2").fadeToggle(600, function () {
            if ($(this).is(":visible")) {
                link.text("Hide");
            } else {
                link.text("More");
            }
        });
    });
    $("#but-info-3").click(function () {
        var link = $(this);
        $(".hidden-info-3").fadeToggle(600, function () {
            if ($(this).is(":visible")) {
                link.text("Hide");
            } else {
                link.text("More");
            }
        });
    });
    $("#but-info-4").click(function () {
        var link = $(this);
        $(".hidden-info-4").fadeToggle(600, function () {
            if ($(this).is(":visible")) {
                link.text("Hide");
            } else {
                link.text("More");
            }
        });
    });
    $("#but-info-5").click(function () {
        var link = $(this);
        $(".hidden-info-5").fadeToggle(600, function () {
            if ($(this).is(":visible")) {
                link.text("Hide");
            } else {
                link.text("More");
            }
        });
    });

    //End of doc ready function
});