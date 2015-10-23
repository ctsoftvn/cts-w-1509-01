/*form send mail*/
var $ = (jQuery);
var m_validator = null;
var isLoaded_validator = false;
this.get_validator = function () {
    if (!isLoaded_validator) {
        m_validator = $(".alert_textbox_inputText");
    }
    isLoaded_validator = true;
}

// Hide span validator
this.hideValidator = function () {
    this.get_validator();
    if (m_validator != null) {
        m_validator.css("display", "none");
    }
    $('.alert_textbox_inputText').css('display', 'none');

}

function ResetForm() {
    var arrInput = $(".contact_form :text, .contact_form textarea");
    if (arrInput && arrInput.length > 0) {
        for (var i = 0; i < arrInput.length; i++)
            arrInput[i].value = "";
    }
}

$('#ubermenu-nav-main-23 li a').each(function () {
    $(this).removeClass("active");
    var a = $(this).attr('href').toLowerCase();
    if (document.URL.toLowerCase().indexOf(a) != -1) {
        $(this).addClass('active');
    }
});
$('#menu-mobile-menu>li>a').each(function () {
    $(this).removeClass("active");
    var a = $(this).attr('href').toLowerCase();
    if (document.URL.toLowerCase().indexOf(a) != -1) {
        $(this).addClass('active');
    }
});