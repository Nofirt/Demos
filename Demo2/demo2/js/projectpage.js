
//Projects Page

$(document).ready(function () {


    //smooth slide
    $('a[href*=#]:not([href=#])').click(function () {
        if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '')
            && location.hostname == this.hostname) {
            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
            if (target.length) {
                $('html, body').animate({
                    scrollTop: target.offset().top
                }, 700);
                return false;
            }
        }
    });
    //end of smooth slide


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

    //objects containing the outer object with index of
    //html select option value, and inner object containing
    //the width of isolation material as key and price of isolation material as value
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
        //attach an on function to catch when option value of select element will change
        $("select[name='material']").on("change", function () {
            //get contents of selection
            $("select[name='widthOfMaterial']").html("");
            if ("eps" == $(this).val()) {
                for (var widthOfMaterial in eps) {
                    // index of widthOfMaterial is the value for html select-option-value 
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
                    // index of widthOfMaterial is the value for html select-option-value 
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


    var getPrice;
    var qMeters = 0, scaffold = 0, strips = 0, roofs = 0, mRunner = 0;
    //Calculate sum of the input values
    $(function () {

        //global variables in the scope of this function



        //check if scaffold checkbox is checked or unchecked and assign and unassign value 

        $("input[name=scaffold]").change(function () {
            var ischecked = $(this).is(':checked');
            if (!ischecked) {
                scaffold = 0;
                console.log("scaffold = " + scaffold);
            } else {
                scaffold = $("input[name=scaffold]").val();
                console.log("scaffold = " + scaffold);
            }
        });

        //check if strips checkbox is checked or unchecked and assign and unassign value

        $("input[name=strips]").change(function () {
            var ischecked = $(this).is(':checked');
            if (!ischecked) {
                strips = 0;
                console.log("strips = " + strips);
            } else {
                strips = $("input[name=strips]").val();
                console.log("strips = " + strips);
            }
        });

        //check if roofs checkbox is checked or unchecked and assign and unassign value

        $("input[name=roofs]").change(function () {
            var ischecked = $(this).is(':checked');
            if (!ischecked) {
                roofs = 0;
                console.log("roofs = " + roofs);
            } else {
                roofs = $("input[name=roofs]").val();
                console.log("roofs = " + roofs);
            }
        });

        //check if mRunner checkbox is checked or unchecked and assign and unassign value

        $("input[name=mRunner]").change(function () {
            var ischecked = $(this).is(':checked');
            if (!ischecked) {
                mRunner = 0;
                console.log("mRunner = " + mRunner);
            } else {
                mRunner = $("input[name=mRunner]").val();
                console.log("mRunner = " + mRunner);
            }
        });

        //get the price of material that user choose
        // var getPrice;
        $("select[name='widthOfMaterial']").change(function () {
            var getResult = $("select[name='widthOfMaterial'] option:selected").text();
            getPrice = parseInt(getResult.slice(6, 8));
            console.log("Get price = " + getPrice);
        });

        //After user type some number in the input all the selected elements will be calculated 
        //and the ruslt will be saved in variable result

        $("input[name=quantity]").keyup(function () {
            qMeters = $("input[name=quantity]").val();
            console.log("qMeters = " + qMeters);
            Calculate(getPrice, qMeters, scaffold, strips, roofs, mRunner);
        });
    });

    //Function that Calculate all from user

    function Calculate(getPrice, qMeters, scaffold, strips, roofs, mRunner) {

        console.log("Values in function calculate ");
        console.log("getPrice " + getPrice);
        console.log("qMeters " + qMeters);
        console.log("scaffold " + scaffold);
        console.log("strips " + strips);
        console.log("roofs " + roofs);
        console.log("mRunner " + mRunner);

        var result = (qMeters * scaffold) +
            (qMeters * strips) +
            (qMeters * roofs) +
            (qMeters * mRunner) +
            (getPrice * qMeters);
        console.log("Total is " + result);
        if (!isNaN(result)) {
            $("#total").text(result + " lv");
        }
    }
    //End of Calculator functionality



    //Menu button hide ahd show information about the project

    $("#but-info-1").click(function () {
        $(".hidden-info-1").fadeToggle(1000);
    });
    $("#but-info-2").click(function () {
        $(".hidden-info-2").fadeToggle(1000);
    });
    $("#but-info-3").click(function () {
        $(".hidden-info-3").fadeToggle(1000);
    });
    $("#but-info-4").click(function () {
        $(".hidden-info-4").fadeToggle(1000);
    });
    $("#but-info-5").click(function () {
        $(".hidden-info-5").fadeToggle(1000);
    });

    //Working on new slider that will run simultaneously in multiple containers
/*
    // With this varable count picture in slider.
    var nextImg = 1;
    // This variable is number of picture in slider.
    var lastImg = 3;
    var image = document.getElementById('picture');
    var imageName, imageSource;
    function checkImage() {
        imageSource = image.src;
        imageName = imageSource.substring(imageSource.lastIndexOf('/') + 1);
        if (imageName == "p1-big2.png" || "p1-big3.png") {
            imageName = "p1-big1.png";
        }
        if (imageName == "p2-big2.png" || "p2-big3.png") {
            imageName = "p2-big1.png";
        }
        if (imageName == "p3-big2.png" || "p3-big3.png") {
            imageName = "p3-big1.png";
        }
        if (imageName == "p4-big2.png" || "p4-big3.png") {
            imageName = "p4-big1.png";
        }
        if (imageName == "p5-big2.png" || "p5-big3.png") {
            imageName = "p5-big1.png";
        }
    };
    // This function with name "setInterval" change picture in slider automatically.
    window.setInterval(


        function slideShow() {
            checkImage();

            nextImg = nextImg + 1;
            // When 'imagecount' is greater than total picture in slider, 'imagecount' is equal to 1, and show first picture in slider.
            if (nextImg > lastImg) {
                nextImg = 1;
            }
            // When 'imagecount' is less than one, 'imagecount' is equal to total picture in slider, and show last picture in slider.
            if (nextImg < 1) {
                nextImg = lastImg;
            }
            if (imageName == "p2-big1.png") {
                image.src = "images/projects/p2-big" + nextImg + ".png";
            }
            if (imageName == "p3-big1.png") {
                image.src = "images/projects/p3-big" + nextImg + ".png";
            }
            if (imageName == "p4-big1.png") {
                image.src = "images/projects/p4-big" + nextImg + ".png";
            }
            if (imageName == "p5-big1.png") {
                image.src = "images/projects/p5-big" + nextImg + ".png";
            }
            // After function we set how many seconds to change picture in slider.
        }, 1000);
       */ 
    //End of developing slider



    //Project1 Carousel
       var slideProjectImage = 0;
   
       function projectCarousel1() {
           var j;
           var projectImages = document.getElementsByClassName("project-page-carousel-1");
           for (j = 0; j < projectImages.length; j++) {
               projectImages[j].style.display = "none";
           }
           slideProjectImage++;
           if (slideProjectImage > projectImages.length) { slideProjectImage = 1 }
           projectImages[slideProjectImage - 1].style.display = "block";
           setTimeout(projectCarousel1, 3000);
       }
       projectCarousel1();
   
       //End of Project1 Carousel
       //Project2 Carousel
       var slideProjectImage2 = 0;
   
       function projectCarousel2() {
           var j;
           var projectImages = document.getElementsByClassName("project-page-carousel-2");
           for (j = 0; j < projectImages.length; j++) {
               projectImages[j].style.display = "none";
           }
           slideProjectImage2++;
           if (slideProjectImage2 > projectImages.length) { slideProjectImage2 = 1 }
           projectImages[slideProjectImage2 - 1].style.display = "block";
           setTimeout(projectCarousel2, 3000);
       }
       projectCarousel2();
   
       //End of Project2 Carousel
       //Project3 Carousel
       var slideProjectImage3 = 0;
   
       function projectCarousel3() {
           var j;
           var projectImages = document.getElementsByClassName("project-page-carousel-3");
           for (j = 0; j < projectImages.length; j++) {
               projectImages[j].style.display = "none";
           }
           slideProjectImage3++;
           if (slideProjectImage3 > projectImages.length) { slideProjectImage3 = 1 }
           projectImages[slideProjectImage3 - 1].style.display = "block";
           setTimeout(projectCarousel3, 3000);
       }
       projectCarousel3();
   
       //End of Project3 Carousel
       //Project4 Carousel
       var slideProjectImage4 = 0;
   
       function projectCarousel4() {
           var j;
           var projectImages = document.getElementsByClassName("project-page-carousel-4");
           for (j = 0; j < projectImages.length; j++) {
               projectImages[j].style.display = "none";
           }
           slideProjectImage4++;
           if (slideProjectImage4 > projectImages.length) { slideProjectImage4 = 1 }
           projectImages[slideProjectImage4 - 1].style.display = "block";
           setTimeout(projectCarousel4, 3000);
       }
       projectCarousel4();
   
       //End of Project4 Carousel
       //Project5 Carousel
       var slideProjectImage5 = 0;
   
       function projectCarousel5() {
           var j;
           var projectImages = document.getElementsByClassName("project-page-carousel-5");
           for (j = 0; j < projectImages.length; j++) {
               projectImages[j].style.display = "none";
           }
           slideProjectImage5++;
           if (slideProjectImage5 > projectImages.length) { slideProjectImage5 = 1 }
           projectImages[slideProjectImage5 - 1].style.display = "block";
           setTimeout(projectCarousel5, 3000);
       }
       projectCarousel5();
   
       //End of Project5 Carousel


    //End of doc ready function
});