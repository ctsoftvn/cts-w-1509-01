jQuery(document).ready(function () {

    "use strict";

    // PrettyPhoto
    //jQuery("a[rel^='prettyPhoto']").prettyPhoto({social_tools:false});

    // Calendar Message
    jQuery(".datepicker2").click(function (e) {
        jQuery(".ui-datepicker-calendar").effect("pulsate", { times: 2 }, 400);
        jQuery(".calendar-notice").fadeIn(1200, function () {
            // Animation complete
        });
        e.stopPropagation();
    });

    // Calendar Message
    jQuery(".booking-fields-form").click(function () {

        var bookingError = false;
        var termsError = false;

        if (jQuery("input[id$='tbFirstName']").val().length == 0) {
            bookingError = true;
        }

        if (jQuery("input[id$='tbLastName']").val().length == 0) {
            bookingError = true;
        }

        if (jQuery("input[id$='tbEmail']").val().length == 0) {
            bookingError = true;
        }

        if (jQuery("input[id$='tbPhone']").val().length == 0) {
            bookingError = true;
        }

        if (jQuery("input[id$='tbAddress']").val().length == 0) {
            bookingError = true;
        }

        if (jQuery("input[id$='tbStateCounty']").val().length == 0) {
            bookingError = true;
        }

        if (jQuery("input[id$='tbCity']").val().length == 0) {
            bookingError = true;
        }
        if (jQuery("input[id$='tbCountry']").val().length == 0) {
            bookingError = true;
        }

        if (bookingError == true) {
            jQuery(".booking-form-notice").effect("pulsate", { times: 2 }, 400);
            jQuery(".booking-form-notice").fadeIn(1200, function () {
                // Animation complete
            });
        }

        if (bookingError == true) {
            return false;
        }

        var bookingEmailError = false;
        if (!checkMail(jQuery("input[id$='tbEmail']").val())) {
            bookingEmailError = true;
        }
        if (bookingEmailError == true) {
            jQuery(".booking-form-email-notice").effect("pulsate", { times: 2 }, 400);
            jQuery(".booking-form-email-notice").fadeIn(1200, function () {
                // Animation complete
            });
        }
        if (bookingEmailError == true) {
            return false;
        }

    });

});

jQuery(function () {

    "use strict";

    // Set Datepicker Date
    var datepickerDateFormat;
    if ($('body').hasClass('en')) {
        datepickerDateFormat = 'M/dd/yy';
    } else {
        datepickerDateFormat = 'dd/mm/yy';
    }

    // Datepicker
    jQuery(".datepicker").datepicker({
        minDate: 0,
        dateFormat: datepickerDateFormat
    });

    // Make Datepicker Fields Read Only
    jQuery("input[id$='tbDateFrom']").attr('readonly', true);
    jQuery("input[id$='tbDateTo']").attr('readonly', true);

    // Booking page open datepicker
    jQuery("#open_datepicker").datepicker({
        dateFormat: datepickerDateFormat,
        numberOfMonths: 2,
        minDate: 0,
        beforeShowDay: function (date) {
            var date1 = jQuery.datepicker.parseDate(datepickerDateFormat, jQuery("input[id$='tbDateFrom']").val());
            var date2 = jQuery.datepicker.parseDate(datepickerDateFormat, jQuery("input[id$='tbDateTo']").val());
            return [true, date1 && ((date.getTime() == date1.getTime()) || (date2 && date >= date1 && date <= date2)) ? "dp-highlight" : ""];
        },
        onSelect: function (dateText, inst) {
            var dateTextForParse = (inst.currentMonth + 1) + '/' + inst.currentDay + '/' + inst.currentYear;
            var date1 = jQuery.datepicker.parseDate(datepickerDateFormat, jQuery("input[id$='tbDateFrom']").val());
            var date2 = jQuery.datepicker.parseDate(datepickerDateFormat, jQuery("input[id$='tbDateTo']").val());
            if (!date1 || date2) {
                jQuery("input[id$='tbDateFrom']").val(dateText);
                jQuery("input[id$='tbDateTo']").val("");
            } else {
                if (Date.parse(dateTextForParse) < Date.parse(date1)) {
                    jQuery("input[id$='tbDateFrom']").val(dateText);
                    jQuery("input[id$='tbDateTo']").val("");
                }
                else {
                    jQuery("input[id$='tbDateTo']").val(dateText);
                }
            }
        }
    });

});

jQuery(document).ready(function () {

    "use strict";

    // Add/Remove Rooms For Booking Form
    var i = '';

    // Validate Booking Form
    jQuery(".booking-form").click(function () {

        if (jQuery("input[id$='tbDateFrom']").val() == 'Check In' || jQuery("input[id$='tbDateTo']").val() == 'Check Out') {
            alert('Please Select Booking Dates');
            jQuery("input[id$='tbDateFrom']").effect("pulsate", { times: 2 }, 400);
            jQuery("input[id$='tbDateTo']").effect("pulsate", { times: 2 }, 400);
            return false;
        }

        if (jQuery("input[id$='tbDateFrom']").val() == jQuery("input[id$='tbDateTo']").val()) {
            alert('Check In and Check Out Dates Cannot Be On The Same Day');
            jQuery("input[id$='tbDateFrom']").effect("pulsate", { times: 2 }, 400);
            jQuery("input[id$='tbDateTo']").effect("pulsate", { times: 2 }, 400);
            return false;
        }

        var dateFrom = jQuery.datepicker.parseDate('dd/mm/yy', jQuery("input[id$='tbDateFrom']").val());
        var dateTo = jQuery.datepicker.parseDate('dd/mm/yy', jQuery("input[id$='tbDateTo']").val());

        if (dateTo < dateFrom) {
            jQuery("input[id$='tbDateFrom']").effect("pulsate", { times: 3 }, 250);
            jQuery("input[id$='tbDateTo']").effect("pulsate", { times: 3 }, 250);
            alert('Check In Date Must Be Before Check Out Date');
            return false;
        }

    });

    // Booking Form Edit
    jQuery(".edit-reservation").click(function () {
        jQuery(".display-reservation").hide();
        jQuery(".display-reservation-edit").show();
        return false;
    });
    $("input[id$='chkPickUp']").change(function () {
        calcTotal();
    });
    $("input[id$='chkSeeOff']").change(function () {
        calcTotal();
    });

});
jQuery(window).load(function () {
    if ($('.content-booking').hasClass('booking-step3')) {
        calcTotal();
    }
});
function calcTotal() {
    var pickUpPrice = 0;
    var seeOffPrice = 0;
    var hdPrice = jQuery("input[id$='hdPrice']").val();
    var price = convertToNumber(hdPrice, 0);
    var hdRoomQty = jQuery("input[id$='hdRoomQty']").val();
    var roomQty = convertToNumber(hdRoomQty, 0);
    var hdDays = jQuery("input[id$='hdDays']").val();
    var days = convertToNumber(hdDays, 0);
    if ($("input[id$='chkPickUp']").is(":checked")) {
        var hdPickUpPrice = jQuery("input[id$='hdPickUpPrice']").val();
        pickUpPrice = convertToNumber(hdPickUpPrice, 0);
    }
    if ($("input[id$='chkSeeOff']").is(":checked")) {
        var hdSeeOffPrice = jQuery("input[id$='hdSeeOffPrice']").val();
        seeOffPrice = convertToNumber(hdSeeOffPrice, 0);
    }
    var total = (price * roomQty * days) + pickUpPrice + seeOffPrice;
    jQuery('#totalPrice').html(total + "$");

}
function convertToNumber(data, defValue) {
    var result = Number(data);
    if (isNaN(result)) {
        result = defValue;
    }
    return result;
}
function checkMail(data) {
    var re = /^(([^<>()\[\]\\.,;:\s@\"]+(\.[^<>()\[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/g;
    var regex = new RegExp(re);
    return regex.test(data);
}