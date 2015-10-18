<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="booking-step-3.aspx.cs" Inherits="CTS.W._150901.Web.booking_step_3" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">
    <link rel='stylesheet' href='/res/css/style-booking.css' type='text/css' media='all' />
    <link rel='stylesheet' href='/res/css/responsive-booking.css' type='text/css' media='all' />
    <link rel='stylesheet' href='/res/css/goldblack-booking.css' type='text/css' media='all' />
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentMain" runat="server">
    <div class="content-booking booking-step3">
        <div class="col-xs-12">
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
                            <div class="input-left">
                                <label for="first_name">
                                    First Name *</label>
                                <asp:TextBox runat="server" name="first_name" ID="tbFirstName"></asp:TextBox>
                                <label for="last_name">
                                    Last Name *</label>
                                <asp:TextBox ID="tbLastName" name="last_name" runat="server"></asp:TextBox>
                                <label for="email_address">
                                    Email Address *</label>
                                <asp:TextBox ID="tbEmail" name="email_address" runat="server"></asp:TextBox>
                                <label for="phone_number">
                                    Telephone Number *</label>
                                <asp:TextBox ID="tbPhone" name="phone_number" runat="server"></asp:TextBox>
                            </div>
                            <div class="input-right">
                                <label for="address_line2">
                                    Address *</label>
                                <asp:TextBox ID="tbAddress" name="address" runat="server"></asp:TextBox>
                                <label for="state_county">
                                    State / County *</label>
                                <asp:TextBox ID="tbStateCounty" name="state_county" runat="server"></asp:TextBox>
                                <label for="city">
                                    City *</label>
                                <asp:TextBox ID="tbCity" name="city" runat="server"></asp:TextBox>
                                <label for="country">
                                    Country *</label>
                                <asp:TextBox ID="tbCountry" name="country" runat="server"></asp:TextBox>
                            </div>
                            <label for="special_requirements">
                                Special Requirements</label>
                            <asp:TextBox runat="server" ID="tbNotes" TextMode="MultiLine" name="special_requirements"
                                Rows="10" Columns="1"></asp:TextBox>
                            <div class="clearfix">
                            </div>
                            <asp:Button runat="server" ID="booking_step3" CssClass="book-deposit booking-fields-form"
                                Text="Book Now" OnClick="booking_step3_Click" />
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
                                <li><span>Room: </span>
                                    <asp:Literal runat="server" ID="ltTypeName"></asp:Literal></li>
                                <li><span>Check In: </span>
                                    <asp:Literal runat="server" ID="ltDatefrom"></asp:Literal></li>
                                <li><span>Check Out: </span>
                                    <asp:Literal runat="server" ID="ltDateto"></asp:Literal></li>
                                <li>
                                    <asp:CheckBox runat="server" ID="pickup" /><span>Airport pickup Request </span>
                                    <br />
                                    <span>Price :</span><asp:Literal runat="server" ID="ltPickup"></asp:Literal></li>
                                <li>
                                    <asp:CheckBox runat="server" ID="seeoff" /><span>Airport
                                        see off Request </span>
                                    <asp:Literal runat="server" ID="ltSeeoff"></asp:Literal></li>
                            </ul>
                            <div class="price-details">
                                <p class="total">
                                    Total Price</p>
                                <h3 class="total-price">
                                    <span id="totalPrice"></span>
                                </h3>
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
        </div>
    </div>
    <asp:HiddenField ID="hdRoomPrice" runat="server" />
    <asp:HiddenField ID="hdNights" runat="server" />
    <asp:HiddenField ID="hdPickup" runat="server" />
    <asp:HiddenField ID="hdSeeoff" runat="server" />
    <script type='text/javascript' src='/res/jss/booking.js'></script>
</asp:Content>
