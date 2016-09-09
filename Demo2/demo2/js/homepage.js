//Home Page
$(function () {
    /*
    $("header nav").hide();
    $("header nav").fadeIn(500);
    $("#slider-container").hide();
    $("#slider-container").fadeIn(500);
    $("#infotext").hide();
    $("#infotext").show(500);
    $("footer").hide();
    $("#testimonials").hide();

    $("#projects ul li:nth-child(1)").hide();
    $("#projects ul li:nth-child(1)").fadeIn(1000);

    $("#projects ul li:nth-child(2)").hide();
    $("#projects ul li:nth-child(2)").fadeIn(1500);

    $("#projects ul li:nth-child(3)").hide();
    $("#projects ul li:nth-child(3)").fadeIn(2000);

    $("#projects ul li:nth-child(4)").hide();
    $("#projects ul li:nth-child(4)").fadeIn(2500);

    $("#projects ul li:nth-child(5)").hide();
    $("#projects ul li:nth-child(5)").fadeIn(3000);
   

    //detect to show testimonials and footer
    $(window).scroll(function () {
        var win = $(window).scrollTop();
         if (win >= 100) {
        // $("")
        }
        if (win >= 300) {
         $("#testimonials").fadeIn(700);
        }
        if (win >= 500) {
            $("footer").fadeIn(700);
        }
    });
    */
    //
    //sliderconfiguration
    //
    var xOffset = innerWidth;
    var animationSpeed = 2000;
    var slideSpeed = 5000;
    var startSlide = 1;

    //cache the DOM
    var slider = $("#slider");
    var slideContainer = slider.find("ul");
    var slides = slideContainer.find("li");
    var sliderInterval;
    slideContainer.css("width", xOffset * 5);
    slides.css("width", xOffset);
    $("#slider ul li img").css("width", xOffset);
    function startSlider() {
        sliderInterval = setInterval(function () {
            slideContainer.animate({ "margin-left": "-=" + xOffset }, animationSpeed, function () {
                startSlide++;
                if (startSlide >= slides.length) {
                    startSlide = 1;
                    slideContainer.css("margin-left", 0);
                    //slideContainer.animate({'margin-left' : 0}, animationSpeed);
                };
            });
        }, slideSpeed);
    };

    function stopSlider() {
        clearInterval(sliderInterval);
    }
    //mouse events
    slider.on("mouseenter", stopSlider);
    slider.on("mouseleave", startSlider);
    startSlider();
});
//End of slide configuration


//Carousel function for projects
var slideImage = 0;
carousel();

function carousel() {
    var i;
    var images = document.getElementsByClassName("carousel-testimonials");
    for (i = 0; i < images.length; i++) {
        images[i].style.display = "none";
        //images[i].style.opacity = "0";
       // images[i].style.transitionDelay = "1.5s"
    }
    slideImage++;
    if (slideImage > images.length) { slideImage = 1 }
    images[slideImage - 1].style.display = "block";
   // images[slideImage - 1].style.opacity = "1";
    //images[slideImage - 1].style.transitionDelay = "1.5s"
    setTimeout(carousel, 3000);
}
//End of Carousel function for projects
