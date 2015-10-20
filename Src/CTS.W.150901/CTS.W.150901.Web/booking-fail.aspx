<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="booking-fail.aspx.cs" Inherits="CTS.W._150901.Web.booking_fail" %>

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
                                <div class="step-icon">
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
                    <div class="msg fail"><p><%= Strings.CLN_BOOKING_FAIL_NOTES%>, <a href="<%= Strings.CLN_MASTER_BOOKING_LINK%>"> <%= Strings.CLN_BOOKING_FAIL_REDIRECT%></a></p></div>
                </div>
            </div>
        </div>
    </div>
    <script type='text/javascript' src='/res/jss/booking.js'></script>
</asp:Content>
