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
    jQuery(".booking-fields-form").submit(function () {

        var bookingError = false;
        var termsError = false;

        if (jQuery('#first_name').val().length == 0) {
            bookingError = true;
        }

        if (jQuery('#last_name').val().length == 0) {
            bookingError = true;
        }

        if (jQuery('#email_address').val().length == 0) {
            bookingError = true;
        }

        if (jQuery('#phone_number').val().length == 0) {
            bookingError = true;
        }

        if (jQuery('#address_line1').val().length == 0) {
            bookingError = true;
        }

        if (jQuery('#address_line2').val().length == 0) {
            bookingError = true;
        }

        if (jQuery('#city').val().length == 0) {
            bookingError = true;
        }

        if (jQuery('#state_county').val().length == 0) {
            bookingError = true;
        }

        if (jQuery('#zip_postcode').val().length == 0) {
            bookingError = true;
        }

        if (jQuery('#country').val().length == 0) {
            bookingError = true;
        }

        jQuery("#terms_check").change(function () {
            if (jQuery(this).is(':checked')) {
                // Checked
            } else {
                // Unchecked
            }
        });

        if (jQuery("#terms_check").is(":checked")) {
            termsError = false;
        } else {
            termsError = true;
        }

        if (bookingError == true) {
            jQuery(".booking-form-notice").effect("pulsate", { times: 2 }, 400);
            jQuery(".booking-form-notice").fadeIn(1200, function () {
                // Animation complete
            });
        }

        if (termsError == true) {
            jQuery(".booking-form-terms").effect("pulsate", { times: 2 }, 400);
            jQuery(".booking-form-terms").fadeIn(1200, function () {
                // Animation complete
            });
        }

        if (bookingError == true || termsError == true) {
            return false;
        }

    });

});

jQuery(function () {

    "use strict";

    // Set Datepicker Date
    var datepickerDateFormat = "dd/mm/yy";

    // Datepicker
    jQuery(".datepicker").datepicker({
        minDate: 0,
        dateFormat: 'dd/mm/yy'
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

    //jQuery('.rooms-wrapper div[class^="room-"]:not(div.room-0)').hide();
    /*jQuery('#room_qty').change(function(e) {
    jQuery('.rooms-wrapper div[class^="room-"]').hide();
    e.preventDefault();
    var selectedVal = jQuery(this).val();
		
    if(selectedVal > 1) {
    for(i = 1; i <= selectedVal; i++ ) {
    jQuery('div[class^=room-'+ i +']').show();
    }
    }
    else {
    jQuery('div.room-0').show();
    }		
    });*/

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

        /*if ( jQuery("#room_qty").val() == '1' ) {
        if ( (jQuery("#room_adults_0").val() + jQuery("#room_children_0").val()) < 1  ) {
        alert('Please Select At Least 1 Guest');
        jQuery("#room_adults_0").effect("pulsate", { times:2 }, 400);
        jQuery("#room_children_0").effect("pulsate", { times:2 }, 400);
        return false;
        }
        }
		
        if ( jQuery("#room_qty").val() == '2' ) {
        if ( (jQuery("#room_adults_1").val() + jQuery("#room_children_1").val()) < 1  ) {
        alert('Please Select At Least 1 Guest');
        jQuery("#room_adults_1").effect("pulsate", { times:2 }, 400);
        jQuery("#room_children_1").effect("pulsate", { times:2 }, 400);
        return false;
        }
        if ( (jQuery("#room_adults_2").val() + jQuery("#room_children_2").val()) < 1  ) {
        alert('Please Select At Least 1 Guest');
        jQuery("#room_adults_2").effect("pulsate", { times:2 }, 400);
        jQuery("#room_children_2").effect("pulsate", { times:2 }, 400);
        return false;
        }
        }
		
        if ( jQuery("#room_qty").val() == '3' ) {
        if ( (jQuery("#room_adults_1").val() + jQuery("#room_children_1").val()) < 1  ) {
        alert('Please Select At Least 1 Guest');
        jQuery("#room_adults_1").effect("pulsate", { times:2 }, 400);
        jQuery("#room_children_1").effect("pulsate", { times:2 }, 400);
        return false;
        }
        if ( (jQuery("#room_adults_2").val() + jQuery("#room_children_2").val()) < 1  ) {
        alert('Please Select At Least 1 Guest');
        jQuery("#room_adults_2").effect("pulsate", { times:2 }, 400);
        jQuery("#room_children_2").effect("pulsate", { times:2 }, 400);
        return false;
        }
        if ( (jQuery("#room_adults_3").val() + jQuery("#room_children_3").val()) < 1  ) {
        alert('Please Select At Least 1 Guest');
        jQuery("#room_adults_3").effect("pulsate", { times:2 }, 400);
        jQuery("#room_children_3").effect("pulsate", { times:2 }, 400);
        return false;
        }
        }*/

        /*if ( (jQuery("#adults").val() + jQuery("#children").val()) < 1  ) {
        alert('Please Select At Least 1 Guest');
        jQuery("#adults").effect("pulsate", { times:2 }, 400);
        jQuery("#children").effect("pulsate", { times:2 }, 400);
        return false;
        }*/

        var dateFrom = jQuery.datepicker.parseDate('dd/mm/yy', jQuery("input[id$='datefrom']").val());
        var dateTo = jQuery.datepicker.parseDate('dd/mm/yy', jQuery("input[id$='dateto']").val());

        if (dateTo < dateFrom) {
            jQuery("input[id$='datefrom']").effect("pulsate", { times: 3 }, 250);
            jQuery("input[id$='dateto']").effect("pulsate", { times: 3 }, 250);
            alert('Check In Date Must Be Before Check Out Date');
            return false;
        }

        /*if ( (jQuery("#room_adults_edit_0").val() + jQuery("#room_children_edit_0").val()) < 1  ) {
        alert('Please Select At Least 1 Guest');
        jQuery("#room_adults_edit_0").effect("pulsate", { times:2 }, 400);
        jQuery("#room_children_edit_0").effect("pulsate", { times:2 }, 400);
        return false;
        }*/

    });

    // Booking Form Edit
    jQuery(".edit-reservation").click(function () {
        jQuery(".display-reservation").hide();
        jQuery(".display-reservation-edit").show();
        return false;
    });

});