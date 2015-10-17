<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="booking-step-2.aspx.cs" Inherits="CTS.W._150901.Web.booking_step_2" %>

<%@ Import Namespace="CTS.Core.Domain.Model" %>
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
                                Choose Your Date</div>
                        </div>
                        <div class="step-wrapper">
                            <div class="step-icon-wrapper">
                                <div class="step-icon step-icon-current">
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
                            <h4 class="title-style4">
                                Choose Your Room<span class="title-block"></span>
                            </h4>
                            <asp:Repeater ID="rptRooms" runat="server">
                                <HeaderTemplate>
                                    <ul class="room-list-wrapper clearfix">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li class="room-item clearfix">
                                        <h5>
                                            <%# ((HashMap)Container.DataItem)["TypeName"]%></h5>
                                        <!-- BEGIN .room-list-left -->
                                        <div class="room-list-left">
                                            <img alt='<%# ((HashMap)Container.DataItem)["TypeName"] %>' title='<%# ((HashMap)Container.DataItem)["TypeName"] %>'
                                                src='<%# "/file-manager?fcd=" + ((HashMap)Container.DataItem)["FileCd"] + "&lang=en&s=normal" %>' />
                                            <!-- END .room-list-left -->
                                        </div>
                                        <!-- BEGIN .room-list-right -->
                                        <div class="room-list-right">
                                            <!-- BEGIN .room-meta -->
                                            <div class="room-meta">
                                                <ul>
                                                    <li><span>Occupancy:</span>
                                                        <%# ((HashMap)Container.DataItem)["AdultPerRoom"]%>
                                                        Person(s)</li>
                                                </ul>
                                                <!-- END .room-meta -->
                                            </div>
                                            <!-- BEGIN .room-price -->
                                            <div class="room-price">
                                                <p class="price">
                                                    From: <span>
                                                        <%# ((HashMap)Container.DataItem)["Price"]%>$</span> / Night</p>
                                                <!-- END .room-price -->
                                            </div>
                                            <div class="clearboth">
                                            </div>
                                            <asp:LinkButton runat="server" ID="booking_select_room" OnCommand="lnkSelectRoom_Command"
                                                CommandArgument='<%# ((HashMap)Container.DataItem)["TypeCd"] %>' CssClass="button2"
                                                Text="Select room" />
                                        </div>
                                        <!-- END .room-item -->
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>
                            <!-- BEGIN .room-list-wrapper -->
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
                            <!-- BEGIN .display-reservation -->
                            <div class="display-reservation">
                                <ul>
                                    <li><span>Check In: </span>
                                        <asp:Literal ID="ltDatefrom" runat="server"></asp:Literal></li>
                                    <li><span>Check Out: </span>
                                        <asp:Literal ID="ltDateto" runat="server"></asp:Literal></li>
                                </ul>
                                <a href="#" class="button3 edit-reservation">Edit Reservation</a>
                                <!-- END .display-reservation -->
                            </div>
                            <!-- BEGIN .display-reservation-edit -->
                            <div class="display-reservation-edit" style="display: none">
                                <!-- BEGIN .booking-form -->
                                <div class="clearfix">
                                    <div class="one-half-form">
                                        <label for="datefrom">
                                            Check In</label>
                                        <asp:TextBox ID="datefrom" runat="server" CssClass="datepicker" size="10" name="open_date_from_edit_0"></asp:TextBox>
                                    </div>
                                    <div class="one-half-form last-col">
                                        <label for="dateto">
                                            Check Out</label>
                                        <asp:TextBox ID="dateto" runat="server" CssClass="datepicker" size="10" name="open_date_to_edit_0"></asp:TextBox>
                                    </div>
                                </div>
                                <!-- BEGIN .rooms-wrapper -->
                                <hr class="space8">
                                <asp:Button runat="server" ID="booking_step2" CssClass="bookbutton booking-form"
                                    Text="Check Availability" OnClick="booking_step2_Click" />
                                <!-- END .booking-form -->
                                <!-- END .display-reservation-edit -->
                            </div>
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
    <script type='text/javascript' src='/res/jss/datepicker.js'></script>
</asp:Content>
