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
                            <div class="dark-notice booking-form-email-notice">
                                <p>
                                    <%= Strings.CLN_BOOKING_FORM_EMAIL_NOTICE%></p>
                            </div>
                            <h4 class="title-style4">
                                <%= Strings.CLN_BOOKING_FORM_GUEST_DETAIL%><span class="title-block"></span></h4>
                            <div class="input-left">
                                <asp:Label AssociatedControlID="tbFirstName" runat="server"><%= Strings.CLN_BOOKING_FORM_FIRST_NAME%></asp:Label>
                                <asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox>
                                <asp:Label AssociatedControlID="tbLastName" runat="server"><%= Strings.CLN_BOOKING_FORM_LAST_NAME%></asp:Label>
                                <asp:TextBox ID="tbLastName" runat="server"></asp:TextBox>
                                <asp:Label AssociatedControlID="tbEmail" runat="server"><%= Strings.CLN_BOOKING_FORM_EMAIL%></asp:Label>
                                <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                                <asp:Label AssociatedControlID="tbPhone" runat="server"><%= Strings.CLN_BOOKING_FORM_TELEPHONE%></asp:Label>
                                <asp:TextBox ID="tbPhone" runat="server"></asp:TextBox>
                            </div>
                            <div class="input-right">
                                <asp:Label AssociatedControlID="tbAddress" runat="server"><%= Strings.CLN_BOOKING_FORM_ADDRESS%></asp:Label>
                                <asp:TextBox ID="tbAddress" runat="server"></asp:TextBox>
                                <asp:Label AssociatedControlID="tbStateCounty" runat="server"><%= Strings.CLN_BOOKING_FORM_STATE_COUNTY%></asp:Label>
                                <asp:TextBox ID="tbStateCounty" runat="server"></asp:TextBox>
                                <asp:Label AssociatedControlID="tbCity" runat="server"><%= Strings.CLN_BOOKING_FORM_CITY%></asp:Label>
                                <asp:TextBox ID="tbCity" runat="server"></asp:TextBox>
                                <asp:Label AssociatedControlID="tbCountry" runat="server"><%= Strings.CLN_BOOKING_FORM_COUNTRY%></asp:Label>
                                <asp:TextBox ID="tbCountry" runat="server"></asp:TextBox>
                            </div>
                            <asp:Label AssociatedControlID="tbCountry" runat="server"><%= Strings.CLN_BOOKING_FORM_NOTES%></asp:Label>
                            <asp:TextBox ID="tbNotes" runat="server" TextMode="MultiLine" Rows="10" Columns="1"></asp:TextBox>
                            <div class="clearfix">
                            </div>
                            <asp:Button ID="btnBookingStep3" CssClass="book-deposit booking-fields-form" Text='<%= Strings.CLN_BOOKING_FORM_BOOK_NOW%>'
                                OnClick="btnBookingStep3_Click" runat="server" />
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
                                    <asp:Literal runat="server" ID="ltDateFrom"></asp:Literal></li>
                                <li><span>
                                    <%= Strings.CLN_BOOKING_CHECK_OUT%>: </span>
                                    <asp:Literal runat="server" ID="ltDateTo"></asp:Literal></li>
                                <li>
                                    <asp:CheckBox runat="server" ID="chkPickUp" CssClass="ckbAirport" /><span><%= Strings.CLN_BOOKING_PICKUP%>:
                                    </span>
                                    <asp:Literal runat="server" ID="ltPickUp"></asp:Literal>$ </li>
                                <li>
                                    <asp:CheckBox runat="server" ID="chkSeeOff" CssClass="ckbAirport" /><span><%= Strings.CLN_BOOKING_SEEOFF%>:
                                    </span>
                                    <asp:Literal runat="server" ID="ltSeeOff"></asp:Literal>$</li>
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
    <asp:HiddenField ID="hdPrice" runat="server" />
    <asp:HiddenField ID="hdRoomQty" runat="server" />
    <asp:HiddenField ID="hdDays" runat="server" />
    <asp:HiddenField ID="hdPickUpPrice" runat="server" />
    <asp:HiddenField ID="hdSeeOffPrice" runat="server" />
    <script type='text/javascript' src='/res/jss/booking.js'></script>
</asp:Content>
