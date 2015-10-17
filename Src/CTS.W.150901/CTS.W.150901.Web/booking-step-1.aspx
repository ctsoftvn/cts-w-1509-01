<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="booking-step-1.aspx.cs" Inherits="CTS.W._150901.Web.booking_step_1" %>

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
                                <div class="step-icon step-icon-current">
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
                            <div class="dark-notice calendar-notice">
                                <p>
                                    Please select your dates from the calendar</p>
                            </div>
                            <div id="open_datepicker">
                            </div>
                            <div class="clearboth">
                            </div>
                            <div class="datepicker-key clearfix">
                                <div class="key-unavailable-wrapper clearfix">
                                    <div class="key-unavailable-icon">
                                    </div>
                                    <div class="key-unavailable-text">
                                        Unavailable</div>
                                </div>
                                <div class="key-available-wrapper clearfix">
                                    <div class="key-available-icon">
                                    </div>
                                    <div class="key-available-text">
                                        Available</div>
                                </div>
                                <div class="key-selected-wrapper clearfix">
                                    <div class="key-selected-icon">
                                    </div>
                                    <div class="key-selected-text">
                                        Selected Dates</div>
                                </div>
                            </div>
                            <!-- END .booking-main -->
                        </div>
                        <!-- END .booking-main-wrapper -->
                    </div>
                    <!-- BEGIN .booking-side-wrapper -->
                    <div class="booking-side-wrapper">
                        <!-- BEGIN .booking-side -->
                        <div class="booking-side">
                            <h4 class="title-style4">
                                Your Reservation<span class="title-block"></span></h4>
                            <!-- booking-form -->
                            <div class="clearfix">
                                <div class="one-half-form">
                                    <label for="datefrom">
                                        Check In</label>
                                    <asp:TextBox ID="datefrom" runat="server" CssClass="datepicker2" size="10" name="dateform"></asp:TextBox>
                                </div>
                                <div class="one-half-form last-col">
                                    <label for="dateto">
                                        Check Out</label>
                                    <asp:TextBox ID="dateto" runat="server" CssClass="datepicker2" size="10" name="dateto"></asp:TextBox>
                                </div>
                            </div>
                            <hr class="space8" />
                            <label for="book_room">
                                Rooms</label>
                            <div class="select-wrapper">
                                <asp:DropDownList ID="room_qty" runat="server" name="room_qty">
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <hr class="space8" />
                            <asp:Button runat="server" ID="booking_step1" CssClass="bookbutton booking-form"
                                Text="Check Availability" OnClick="booking_step1_Click" />
                            <!-- BEGIN .booking-side -->
                        </div>
                        <!-- BEGIN .booking-side-wrapper -->
                    </div>
                    <div class="clearboth">
                    </div>
                    <!-- END .main-content -->
                </div>
                <!-- END .content-wrapper -->
            </div>
        </div>
    </div>
    <script type='text/javascript' src='/res/jss/datepicker.js'></script>
</asp:Content>
