<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="booking-step-4.aspx.cs" Inherits="CTS.W._150901.Web.booking_step_4" %>

<%@ Import Namespace="Resources" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">
    <link rel='stylesheet' href='/res/css/style-booking.css' type='text/css' media='all' />
    <link rel='stylesheet' href='/res/css/responsive-booking.css' type='text/css' media='all' />
    <link rel='stylesheet' href='/res/css/goldblack-booking.css' type='text/css' media='all' />
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentMain" runat="server">
    <div class="content-booking">
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
                                <div class="step-icon ">
                                    3.</div>
                            </div>
                            <div class="step-title">
                                <%= Strings.CLN_BOOKING_STEP_3%></div>
                        </div>
                        <div class="step-wrapper last-col">
                            <div class="step-icon-wrapper">
                                <div class="step-icon step-icon-current">
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
                            <h4 class="title-style4">
                                <%= Strings.CLN_BOOKING_RESERVATION_COMPLETE%><span class="title-block"></span></h4>
                            <p>
                                <%= Strings.CLN_BOOKING_RESERVATION_COMPLETE_INFO%></p>
                            <ul class="contact_details_list contact_details_list_dark">
                                <li class="phone_list"><strong>
                                    <%= Strings.CLN_BOOKING_RESERVATION_COMPLETE_PHONE%>:</strong>
                                    <asp:Literal runat="server" ID="ltPhone"></asp:Literal></li>
                                <li class="fax_list"><strong>
                                    <%= Strings.CLN_BOOKING_RESERVATION_COMPLETE_ADDRESS%>:</strong>
                                    <asp:Literal runat="server" ID="ltAddress"></asp:Literal></li>
                                <li class="email_list"><strong>
                                    <%= Strings.CLN_BOOKING_RESERVATION_COMPLETE_EMAIL%>:</strong>
                                    <asp:Literal runat="server" ID="ltEmail"></asp:Literal></li>
                            </ul>
                            <!-- END .booking-main -->
                        </div>
                        <!-- END .booking-main-wrapper -->
                    </div>
                    <!-- BEGIN .booking-main-wrapper -->
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
                                <li><span>
                                    <%= Strings.CLN_BOOKING_OCCUPANCY%>: </span>
                                    <asp:Literal runat="server" ID="ltMaxAdult"></asp:Literal>
                                    <%= Strings.CLN_BOOKING_PERSONS%>
                                </li>
                            </ul>
                            <div class="price-details">
                                <p class="total">
                                    <%= Strings.CLN_BOOKING_TOTAL_PRICE%></p>
                                <h3 class="total-price">
                                    <asp:Literal runat="server" ID="ltTotal"></asp:Literal></h3>
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
    <script type='text/javascript' src='/res/jss/booking.js'></script>
</asp:Content>
