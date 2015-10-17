<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="booking-step-4.aspx.cs" Inherits="CTS.W._150901.Web.booking_step_4" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">
    <link rel='stylesheet' href='/res/css/style-booking.css' type='text/css' media='all' />
    <link rel='stylesheet' href='/res/css/responsive-booking.css' type='text/css' media='all' />
    <link rel='stylesheet' href='/res/css/goldblack-booking.css' type='text/css' media='all' />
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentMain" runat="server">
    <div class="content-wrapper clearfix">
        <!-- BEGIN .main-content -->
        <div class="main-content full-width page-content">
            <!-- BEGIN .booking-step-wrapper -->
            <div class="booking-step-wrapper clearfix">
                <div class="step-wrapper">
                    <div class="step-icon-wrapper">
                        <div class="step-icon ">
                            1.</div>
                    </div>
                    <div class="step-title">
                        Choose Your Date</div>
                </div>
                <div class="step-wrapper">
                    <div class="step-icon-wrapper">
                        <div class="step-icon ">
                            2.</div>
                    </div>
                    <div class="step-title">
                        Choose Your Room</div>
                </div>
                <div class="step-wrapper">
                    <div class="step-icon-wrapper">
                        <div class="step-icon ">
                            3.</div>
                    </div>
                    <div class="step-title">
                        Place Your Reservation</div>
                </div>
                <div class="step-wrapper last-col">
                    <div class="step-icon-wrapper">
                        <div class="step-icon step-icon-current">
                            4.</div>
                    </div>
                    <div class="step-title">
                        Confirmation</div>
                </div>
                <div class="step-line">
                </div>
                <!-- END .booking-step-wrapper -->
            </div>
            <!-- BEGIN .booking-main-wrapper -->
            <div class="booking-main-wrapper">
                <!-- BEGIN .booking-main -->
                <div class="booking-main">
                    <h4 class="title-style4">
                        Reservation Complete<span class="title-block"></span></h4>
                    <p>
                        Details of your reservation have just been sent to you in a confirmation email,
                        we look forward to seeing you soon. In the meantime if you have any questions feel
                        free to contact us.</p>
                    <ul class="contact_details_list contact_details_list_dark">
                        <li class="phone_list"><strong>Phone:</strong> +44 0123 4567</li>
                        <li class="fax_list"><strong>Fax:</strong> +44 7654 3210</li>
                        <li class="email_list"><strong>Email:</strong> hello@quitenicestuff.com</li>
                    </ul>
                    <img src="http://themes.quitenicestuff.com/sohohotelwp/wp-content/themes/sohohotel/images/payment.png"
                        alt="" class="payment-image">
                    <form action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_blank">
                    <input type="hidden" name="business" value="hello@quitenicestuff.com">
                    <input type="hidden" name="cmd" value="_xclick">
                    <input type="hidden" name="item_name" value="Soho Hotel Room Deposit">
                    <input type="hidden" name="item_number" value="1">
                    <input type="hidden" name="return" value="http://themes.quitenicestuff.com/sohohotelwp/payment-successful/">
                    <input type="hidden" name="cancel_return" value="http://themes.quitenicestuff.com/sohohotelwp/payment-failed/">
                    <input type="hidden" name="amount" value="312">
                    <input type="hidden" name="currency_code" value="USD">
                    <input type="hidden" name="lc" value="US">
                    <input class="book-deposit" name="submit" type="submit" value="Pay Room Deposit Now">
                    </form>
                    <!-- END .booking-main -->
                </div>
                <!-- END .booking-main-wrapper -->
            </div>
            <!-- BEGIN .booking-main-wrapper -->
            <div class="booking-side-wrapper">
                <!-- BEGIN .booking-side -->
                <div class="booking-side clearfix">
                    <h4 class="title-style4">
                        Your Reservation<span class="title-block"></span></h4>
                    <ul>
                        <li><span>Room: </span>Hotel Room #9</li><li><span>Check In: </span>17/10/2015</li><li>
                            <span>Check Out: </span>20/10/2015</li><li><span>Guests: </span>2 Adult(s), 2 Child(s)</li></ul>
                    <div class="price-details">
                        <p class="deposit">
                            15% Deposit Due Now</p>
                        <h3 class="price">
                            $312</h3>
                        <hr class="total-line">
                        <p class="total">
                            Total Price</p>
                        <h3 class="total-price">
                            $2080</h3>
                        <p class="price-breakdown">
                            <a href="#price_break_hotel_room_0" rel="prettyPhoto">View Price Breakdown</a></p>
                        <div id="price_break_hotel_room_0" class="hide">
                            <div class="lightbox-title">
                                <h4 class="title-style4">
                                    Price Breakdown<span class="title-block"></span></h4>
                            </div>
                            <div class="page-content">
                                <table>
                                    <tbody>
                                        <tr>
                                            <td data-title="Date">
                                                Sat 17th October, 2015
                                            </td>
                                            <td data-title="Price">
                                                Adults: $230 (x2)<br>
                                                Children: $150 (x2)
                                            </td>
                                        </tr>
                                        <tr>
                                            <td data-title="Date">
                                                Sun 18th October, 2015
                                            </td>
                                            <td data-title="Price">
                                                Adults: $230 (x2)<br>
                                                Children: $150 (x2)
                                            </td>
                                        </tr>
                                        <tr>
                                            <td data-title="Date">
                                                Mon 19th October, 2015
                                            </td>
                                            <td data-title="Price">
                                                Adults: $180 (x2)<br>
                                                Children: $100 (x2)
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <hr class="space9">
                    <!-- END .booking-side -->
                </div>
                <!-- END .booking-side-wrapper -->
            </div>
            <div class="clearboth">
            </div>
            <!-- END .main-content -->
        </div>
        <!-- END .content-wrapper -->
    </div>
    <script type='text/javascript' src='/res/jss/datepicker.js'></script>
</asp:Content>
