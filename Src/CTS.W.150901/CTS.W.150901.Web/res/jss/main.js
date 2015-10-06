/**
 * Created by napa on 7/9/15 AD.
 */


$(window).load(function () {
    // Animate loader off screen
    //$(".collapse.in").prev(".panel-heading").css("background-color","#144498");
    $('.open-now').slideDown();

    var item_height = [];
    $(document).find('.box_promoion').each(function (k, v) {
        item_height.push($(this).height());
    });
    var item_max_height = Math.max.apply(Math, item_height);
    if (item_max_height) {
        $(document).find('.box_promoion').each(function (k, v) {
            $(this).find('.box_promoion').css({"height": item_max_height});
        });
    }
    $(".se-pre-con").fadeOut("slow");

});

jQuery(document).ready(function ($) {

    $('.closed-form-mobile').on("click", function () {
        $(this).parent('div').slideUp('show', function () {
            $(this).hide();
        });
    });

    $(".button-mobile-book-other").on('click', function () {
        $("body").find('#frmCheckRate').appendTo('.book-mobile');
        var obj = $('.book-mobile');
        obj.find('.res').remove();
        obj.slideDown();
    });

    var ua = window.navigator.userAgent;
    var msie = ua.indexOf("MSIE ");
    if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))      // If Internet Explorer, return version number
    {
        var refreshId = setInterval(function () {
            $('.aw-widget-content').attr('style', 'border: 0 !important');
            $('.aw-weather-description').attr('style', 'display: none !important');
            $('.aw-temp-time-desc time').attr('style', 'display: none !important');
            $('.aw-icon').attr('style', 'background-size: 60px auto !important; background-position: -15px 0px !important;top: 0px !important;margin-top:0px !important;');
            $('.aw-current-weather p').attr('style', 'padding-left: 5px !important; font-size: 30px !important;position: absolute !important;left:10px;!important;');
            $('.aw-temperature-today').attr('style', 'padding-top: 0px !important;font-size:24px !important');
            $('.aw-temperature-today b').attr('style', 'padding-left: 12px !important;');
            if ($('.aw-widget-content').attr("style") == "border: 0px currentColor !important; border-image: none !important;") {
                clearInterval(refreshId);
            }
        }, 1000);
    }


    var effect = function () {
        var elem = $("#frmCheckRate");
        return $('html,body').animate({scrollTop: elem.offset().top - ( $(window).height() - elem.outerHeight(true) ) / 2}, 'slow');
    };


    $("#bookingTopMenu").on("click", function () {

        $.when(effect()).done(function () {
            var dropdown = document.getElementById('chain-se');
            if (null == dropdown) {
                $("#dateci").focus();
            } else {
                var event;
                event = document.createEvent('MouseEvents');
                event.initMouseEvent("mousedown", true, true, window, 0,
                    event.screenX, event.screenY, event.clientX, event.clientY,
                    event.ctrlKey, event.altKey, event.shiftKey, event.metaKey,
                    0, null);
                dropdown.dispatchEvent(event);
            }
        });
    });

    $("#btnBook").click(function(e) {
        e.preventDefault();
        $('#centrepoint-group-tabs a[href="#reservation"]').tab('show');
    });

});
