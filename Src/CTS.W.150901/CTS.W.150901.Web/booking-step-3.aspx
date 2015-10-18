<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="booking-step-3.aspx.cs" Inherits="CTS.W._150901.Web.booking_step_3" %>

<%@ Import Namespace="Resources" %>
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
                                <%= Strings.CLN_BOOKING_STEP_1%></div>
                        </div>
                        <div class="step-wrapper">
                            <div class="step-icon-wrapper">
                                <div class="step-icon ">
                                    2.</div>
                            </div>
                            <div class="step-title">
                                <%= Strings.CLN_BOOKING_STEP_2%></div>
                        </div>
                        <div class="step-wrapper">
                            <div class="step-icon-wrapper">
                                <div class="step-icon step-icon-current">
                                    3.</div>
                            </div>
                            <div class="step-title">
                                <%= Strings.CLN_BOOKING_STEP_3%></div>
                        </div>
                        <div class="step-wrapper last-col">
                            <div class="step-icon-wrapper">
                                <div class="step-icon ">
                                    4.</div>
                            </div>
                            <div class="step-title">
                                <%= Strings.CLN_BOOKING_STEP_4%></div>
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
                                    <%= Strings.CLN_BOOKING_FORM_NOTICE%></p>
                            </div>
                            <h4 class="title-style4">
                                <%= Strings.CLN_BOOKING_FORM_GUEST_DETAIL%><span class="title-block"></span></h4>
                            <div class="input-left">
                                <label for="first_name">
                                    <%= Strings.CLN_BOOKING_FORM_FIRST_NAME%></label>
                                <asp:TextBox runat="server" name="first_name" ID="tbFirstName"></asp:TextBox>
                                <label for="last_name">
                                    <%= Strings.CLN_BOOKING_FORM_LAST_NAME%></label>
                                <asp:TextBox ID="tbLastName" name="last_name" runat="server"></asp:TextBox>
                                <label for="email_address">
                                    <%= Strings.CLN_BOOKING_FORM_EMAIL%></label>
                                <asp:TextBox ID="tbEmail" name="email_address" runat="server"></asp:TextBox>
                                <label for="phone_number">
                                    <%= Strings.CLN_BOOKING_FORM_TELEPHONE%></label>
                                <asp:TextBox ID="tbPhone" name="phone_number" runat="server"></asp:TextBox>
                            </div>
                            <div class="input-right">
                                <label for="address_line2">
                                    <%= Strings.CLN_BOOKING_FORM_ADDRESS%></label>
                                <asp:TextBox ID="tbAddress" name="address" runat="server"></asp:TextBox>
                                <label for="state_county">
                                    <%= Strings.CLN_BOOKING_FORM_STATE_COUNTY%></label>
                                <asp:TextBox ID="tbStateCounty" name="state_county" runat="server"></asp:TextBox>
                                <label for="city">
                                    <%= Strings.CLN_BOOKING_FORM_CITY%></label>
                                <asp:TextBox ID="tbCity" name="city" runat="server"></asp:TextBox>
                                <label for="country">
                                    <%= Strings.CLN_BOOKING_FORM_COUNTRY%></label>
                                <asp:TextBox ID="tbCountry" name="country" runat="server"></asp:TextBox>
                            </div>
                            <label for="special_requirements">
                                <%= Strings.CLN_BOOKING_FORM_NOTES%></label>
                            <asp:TextBox runat="server" ID="tbNotes" TextMode="MultiLine" name="special_requirements"
                                Rows="10" Columns="1"></asp:TextBox>
                            <div class="clearfix">
                            </div>
                            <asp:Button runat="server" ID="booking_step3" CssClass="book-deposit booking-fields-form"
                                Text="<%= Strings.CLN_BOOKING_FORM_BOOK_NOW%>" OnClick="booking_step3_Click" />
                            <!-- BEGIN .booking-main -->
                        </div>
                        <!-- BEGIN .booking-main-wrapper -->
                    </div>
                    <!-- BEGIN .booking-side-wrapper -->
                    <div class="booking-side-wrapper">
                        <!-- BEGIN .booking-side -->
                        <div class="booking-side clearfix">
                            <h4 class="title-style4">
                                <%= Strings.CLN_BOOKING_YOUR_RESERVATION%><span class="title-block"></span></h4>
                            <ul>
                                <li><span>
                                    <%= Strings.CLN_BOOKING_ROOM%>: </span>
                                    <asp:Literal runat="server" ID="ltTypeName"></asp:Literal></li>
                                <li><span>
                                    <%= Strings.CLN_BOOKING_CHECK_IN%>: </span>
                                    <asp:Literal runat="server" ID="ltDatefrom"></asp:Literal></li>
                                <li><span>
                                    <%= Strings.CLN_BOOKING_CHECK_OUT%>: </span>
                                    <asp:Literal runat="server" ID="ltDateto"></asp:Literal></li>
                                <li>
                                    <asp:CheckBox runat="server" ID="pickup" CssClass="ckbAirport" /><span><%= Strings.CLN_BOOKING_PICKUP%>:
                                    </span>
                                    <asp:Literal runat="server" ID="ltPickup"></asp:Literal>$ </li>
                                <li>
                                    <asp:CheckBox runat="server" ID="seeoff" CssClass="ckbAirport" /><span><%= Strings.CLN_BOOKING_SEEOFF%>:
                                    </span>
                                    <asp:Literal runat="server" ID="ltSeeoff"></asp:Literal>$</li>
                            </ul>
                            <div class="price-details">
                                <p class="total">
                                    <%= Strings.CLN_BOOKING_TOTAL_PRICE%></p>
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
