<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="booking-step-3.aspx.cs" Inherits="CTS.W._150901.Web.booking_step_3" %>

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
                        <div class="step-icon step-icon-current">
                            3.</div>
                    </div>
                    <div class="step-title">
                        Place Your Reservation</div>
                </div>
                <div class="step-wrapper last-col">
                    <div class="step-icon-wrapper">
                        <div class="step-icon ">
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
                    <div class="dark-notice booking-form-notice">
                        <p>
                            Please fill out the required fields marked with *</p>
                    </div>
                    <div class="dark-notice booking-form-terms">
                        <p>
                            Please accept the terms and conditions</p>
                    </div>
                    <h4 class="title-style4">
                        Guest Details<span class="title-block"></span></h4>
                    <form action="http://themes.quitenicestuff.com/sohohotelwp/booking-step4" class="booking-fields-form clearfix"
                    method="post">
                    <div class="input-left">
                        <label for="first_name">
                            First Name *</label>
                        <input type="text" name="first_name" id="first_name">
                        <label for="last_name">
                            Last Name *</label>
                        <input type="text" name="last_name" id="last_name">
                        <label for="email_address">
                            Email Address *</label>
                        <input type="text" name="email_address" id="email_address">
                        <label for="phone_number">
                            Telephone Number *</label>
                        <input type="text" name="phone_number" id="phone_number">
                        <label for="address_line1">
                            Address Line 1 *</label>
                        <input type="text" name="address_line1" id="address_line1">
                    </div>
                    <div class="input-right">
                        <label for="address_line2">
                            Address Line 2 *</label>
                        <input type="text" name="address_line2" id="address_line2">
                        <label for="city">
                            City *</label>
                        <input type="text" name="city" id="city">
                        <label for="state_county">
                            State / County *</label>
                        <input type="text" name="state_county" id="state_county">
                        <label for="zip_postcode">
                            Zip / Postcode *</label>
                        <input type="text" name="zip_postcode" id="zip_postcode">
                        <label for="country">
                            Country *</label>
                        <input type="text" name="country" id="country">
                    </div>
                    <label for="special_requirements">
                        Special Requirements</label>
                    <textarea name="special_requirements" id="special_requirements" rows="10"></textarea>
                    <p class="terms">
                        <input type="checkbox" name="terms" id="terms_check">
                        I have read and accept the <a rel="prettyPhoto" href="#terms_conditions">terms and conditions</a>.</p>
                    <!-- BEGIN #terms_conditions -->
                    <div id="terms_conditions" class="hide">
                        <div class="lightbox-title">
                            <h4 class="title-style4">
                                Terms and Conditions<span class="title-block"></span></h4>
                        </div>
                        <div class="page-content">
                            <p>
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus mattis elit in
                                ligula pulvinar consectetur. Praesent lacinia dignissim eros, sed dictum nibh porttitor
                                id. In adipiscing feugiat erat, at gravida nulla tristique vel.</p>
                            <p>
                                Donec ligula lorem, dictum imperdiet neque tincidunt, molestie faucibus erat. Etiam
                                in tellus nec est porta vulputate ut at metus. Duis bibendum nisi ut tincidunt ultrices.
                                Integer porttitor dictum mauris, id dapibus lacus egestas rhoncus.</p>
                        </div>
                        <!-- END #terms_conditions -->
                    </div>
                    <img src="http://themes.quitenicestuff.com/sohohotelwp/wp-content/themes/sohohotel/images/payment.png"
                        alt="" class="payment-image">
                    <div class="clearfix">
                    </div>
                    <input type="hidden" name="submit" value="submit">
                    <input type="hidden" name="room_qty" value="1">
                    <input type="hidden" name="room_deposit_0" value="57"><input type="hidden" name="room_total_price_0"
                        value="380">
                    <input class="book-deposit" type="submit" value="Book Now &amp; Pay Deposit">
                    </form>
                    <!-- BEGIN .booking-main -->
                </div>
                <!-- BEGIN .booking-main-wrapper -->
            </div>
            <!-- BEGIN .booking-side-wrapper -->
            <div class="booking-side-wrapper">
                <!-- BEGIN .booking-side -->
                <div class="booking-side clearfix">
                    <h4 class="title-style4">
                        Your Reservation<span class="title-block"></span></h4>
                    <ul>
                        <li><span>Room: </span>Hotel Room #9</li><li><span>Check In: </span>16/10/2015</li><li>
                            <span>Check Out: </span>17/10/2015</li><li><span>Guests: </span>1 Adult(s), 1 Child(s)</li></ul>
                    <div class="price-details">
                        <p class="deposit">
                            15% Deposit Due Now</p>
                        <h3 class="price">
                            $57</h3>
                        <hr class="total-line">
                        <p class="total">
                            Total Price</p>
                        <h3 class="total-price">
                            $380</h3>
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
                                                Fri 16th October, 2015
                                            </td>
                                            <td data-title="Price">
                                                Adults: $230 (x1)<br>
                                                Children: $150 (x1)
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
