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

    });

});

jQuery(function () {

    "use strict";

    // Set Datepicker Date
    var datepickerDateFormat;
    if ($('body').hasClass('en')) {
        datepickerDateFormat = 'M/dd/yy';
    } else { datepickerDateFormat = 'dd/mm/yy'; }

    // Datepicker
    jQuery(".datepicker").datepicker({
        minDate: 0,
        dateFormat: datepickerDateFormat
    });

    // Make Datepicker Fields Read Only
    jQuery("input[id$='datefrom']").attr('readonly', true);
    jQuery("input[id$='dateto']").attr('readonly', true);

    // Booking page open datepicker
    jQuery("#open_datepicker").datepicker({
        dateFormat: datepickerDateFormat,
        numberOfMonths: 2,
        minDate: 0,
        beforeShowDay: function (date) {
            var date1 = jQuery.datepicker.parseDate(datepickerDateFormat, jQuery("input[id$='datefrom']").val());
            var date2 = jQuery.datepicker.parseDate(datepickerDateFormat, jQuery("input[id$='dateto']").val());
            return [true, date1 && ((date.getTime() == date1.getTime()) || (date2 && date >= date1 && date <= date2)) ? "dp-highlight" : ""];
        },
        onSelect: function (dateText, inst) {
            var dateTextForParse = (inst.currentMonth + 1) + '/' + inst.currentDay + '/' + inst.currentYear;
            var date1 = jQuery.datepicker.parseDate(datepickerDateFormat, jQuery("input[id$='datefrom']").val());
            var date2 = jQuery.datepicker.parseDate(datepickerDateFormat, jQuery("input[id$='dateto']").val());
            if (!date1 || date2) {
                jQuery("input[id$='datefrom']").val(dateText);
                jQuery("input[id$='dateto']").val("");
            } else {
                if (Date.parse(dateTextForParse) < Date.parse(date1)) {
                    jQuery("input[id$='datefrom']").val(dateText);
                    jQuery("input[id$='dateto']").val("");
                }
                else {
                    jQuery("input[id$='dateto']").val(dateText);
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

        if (jQuery("input[id$='datefrom']").val() == 'Check In' || jQuery("input[id$='dateto']").val() == 'Check Out') {
            alert('Please Select Booking Dates');
            jQuery("input[id$='datefrom']").effect("pulsate", { times: 2 }, 400);
            jQuery("input[id$='dateto']").effect("pulsate", { times: 2 }, 400);
            return false;
        }

        if (jQuery("input[id$='datefrom']").val() == jQuery("input[id$='dateto']").val()) {
            alert('Check In and Check Out Dates Cannot Be On The Same Day');
            jQuery("input[id$='datefrom']").effect("pulsate", { times: 2 }, 400);
            jQuery("input[id$='dateto']").effect("pulsate", { times: 2 }, 400);
            return false;
        }

        var dateFrom = jQuery.datepicker.parseDate('dd/mm/yy', jQuery("input[id$='datefrom']").val());
        var dateTo = jQuery.datepicker.parseDate('dd/mm/yy', jQuery("input[id$='dateto']").val());

        if (dateTo < dateFrom) {
            jQuery("input[id$='datefrom']").effect("pulsate", { times: 3 }, 250);
            jQuery("input[id$='dateto']").effect("pulsate", { times: 3 }, 250);
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

    // calc total
    jQuery(".booking-step3").load(function () {
        alert('vô hàm');
        calcTotal();

    });

    $("input[id$='pickup']").change(function () {
        calcTotal();
    });
    $("input[id$='seeoff']").change(function () {
        calcTotal();
    });

});
jQuery(window).load(function () {
    if ($('.content-booking').hasClass('booking-step3')) {
        calcTotal();
    }
});
function calcTotal() {

    var pickupPrice = 0;
    var seeoffPrice = 0;

    var hdRoomPrice = jQuery("input[id$='hdRoomPrice']").val();
    var roomPrice = convertToNumber(hdRoomPrice, 0);

    var hdNights = jQuery("input[id$='hdNights']").val();
    var nights = convertToNumber(hdNights, 0);

    if ($("input[id$='pickup']").is(":checked")) {
        var hdPickup = jQuery("input[id$='hdPickup']").val();
        pickupPrice = convertToNumber(hdPickup, 0);
    }
    if ($("input[id$='seeoff']").is(":checked")) {
        var hdSeeoff = jQuery("input[id$='hdSeeoff']").val();
        seeoffPrice = convertToNumber(hdSeeoff, 0);
    }

    var total = (roomPrice * nights) + pickupPrice + seeoffPrice;
    jQuery('#totalPrice').html(total + "$");

}
function convertToNumber(data, defValue) {
    var result = Number(data);
    if (isNaN(result)) {
        result = defValue;
    }
    return result;
}