//Home Page
$(function () {

    //Hide the navigation bar

    $("header nav").hide();

    //Fade in the navigation bar

    $("header nav").fadeIn(500);

    //Hide element with id slider-container

    $("#slider-container").hide();

    //Fade in the slider-container

    $("#slider-container").fadeIn(500);

    //Hide element with id infotext

    $("#infotext").hide();

    //Showing the element with id infotext

    $("#infotext").show(500);

    //Hide first child of element list which is in element with id projects

    $("#projects ul li:nth-child(1)").hide();

    //Fade in the first child of element list which is in element with id projects

    $("#projects ul li:nth-child(1)").fadeIn(1000);

    //Hide second child of element list which is in element with id projects

    $("#projects ul li:nth-child(2)").hide();

    //Fade in the second child of element list which is in element with id projects

    $("#projects ul li:nth-child(2)").fadeIn(1500);

    //Hide third child of element list which is in element with id projects

    $("#projects ul li:nth-child(3)").hide();

    //Fade in the third child of element list which is in element with id projects

    $("#projects ul li:nth-child(3)").fadeIn(2000);

    //Hide fourth child of element list which is in element with id projects

    $("#projects ul li:nth-child(4)").hide();

    //Fade in the fourth child of element list which is in element with id projects

    $("#projects ul li:nth-child(4)").fadeIn(2500);

    //Hide fifth child of element list which is in element with id projects

    $("#projects ul li:nth-child(5)").hide();

    //Fade in the fifth child of element list which is in element with id projects

    $("#projects ul li:nth-child(5)").fadeIn(3000);


    //Slider Configuration
    //Get the width of the window object

    var xOffset = innerWidth;

    //Initialize and set the speed of animation

    var animationSpeed = 2000;

    //Intialize the speed of slide that chnage images

    var slideSpeed = 5000;

    //Start slider from the first image

    var startSlide = 1;

    //Cache the DOM - set variables with selected elments from DOM

    var slider = $("#slider");
    var slideContainer = slider.find("ul");
    var slides = slideContainer.find("li");

    //Declare a variable that will assign setInterval function

    var sliderInterval;

    //Change the width of slideContainer depend on the innerwidth
    // of the user's browser window object and multiply it by the length of images

    slideContainer.css("width", xOffset * 5);

    //Change the width of each slide

    slides.css("width", xOffset);

    //Change the width of each image

    $("#slider ul li img").css("width", xOffset);

    //Function that starts slider

    function startSlider() {

        //Assign setInterval function to sliderInterval

        sliderInterval = setInterval(function () {

            //Invoke animate function and attach it to slideContainer
            //Every next image change margin left property to the size of innerwidth of the browser

            slideContainer.animate({ "margin-left": "-=" + xOffset }, animationSpeed, function () {

                //Increment startSlide to slide the next image

                startSlide++;

                //Check if current image is the last of all images

                if (startSlide >= slides.length) {

                    //Assign startSlide to begin from the first image again

                    startSlide = 1;

                    //And set slideContainer to margin-left 0

                    slideContainer.css("margin-left", 0);
                };
            });
        }, slideSpeed);
    };

    //Function that stops the slider 

    function stopSlider() {

        //Call clearInterval method to stop sliderInterval
        clearInterval(sliderInterval);
    }

    //Mouse event on slider, when mouse is on the slider, slider stops

    slider.on("mouseenter", stopSlider);

    //When mouse leave the slider it continue slides the images 

    slider.on("mouseleave", startSlider);

    //Invoke the function to start the slider
    startSlider();

    //End of slide configuration


    //Carousel function for testimonials

    var slideInformation = 0;

    //Function that change testimonials information

    function carousel() {
        var i;

        //Initialize variable amd assign selected by class element from DOM

        var information = document.getElementsByClassName("carousel-testimonials");

        //Iterate through the length of information
        for (i = 0; i < information.length; i++) {

            //Hide all information
            information[i].style.display = "none";
        }

        //Increment for the next information

        slideInformation++;

        //Check if is the last information

        if (slideInformation > information.length) {

            //Assign slideInformation to the first information

            slideInformation = 1
        }

        //Show the previous information
        information[slideInformation - 1].style.display = "block";

        //Invoke function setTimeout with parameters function carousel and time
        setTimeout(carousel, 3000);
    }
    carousel();
    //End of Carousel function for projects

});