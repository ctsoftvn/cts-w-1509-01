<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="booking-step-2.aspx.cs" Inherits="CTS.W._150901.Web.booking_step_2" %>

<%@ Import Namespace="CTS.Core.Domain.Model" %>
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
                                <div class="step-icon step-icon-current">
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
                    <!-- BEGIN .booking-main-wrapper -->
                    <div class="booking-main-wrapper">
                        <!-- BEGIN .booking-main -->
                        <div class="booking-main">
                            <h4 class="title-style4">
                                <%= Strings.CLN_BOOKING_STEP_2%><span class="title-block"></span>
                            </h4>
                            <asp:Repeater ID="rptRoomTypes" runat="server">
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
                                                    <li><span>
                                                        <%= Strings.CLN_BOOKING_OCCUPANCY%>:</span>
                                                        <%# ((HashMap)Container.DataItem)["AdultPerRoom"]%>
                                                        <%= Strings.CLN_BOOKING_PERSONS%></li>
                                                </ul>
                                                <!-- END .room-meta -->
                                            </div>
                                            <!-- BEGIN .room-price -->
                                            <div class="room-price">
                                                <p class="price">
                                                    <%= Strings.CLN_BOOKING_FROM%>: <span>
                                                        <%# ((HashMap)Container.DataItem)["Price"]%>$</span> /
                                                    <%= Strings.CLN_BOOKING_NIGHT%></p>
                                                <!-- END .room-price -->
                                            </div>
                                            <div class="clearboth">
                                            </div>
											<asp:LinkButton ID="lnkSelectRoomType" runat="server" CssClass="button2"
                                                OnCommand="lnkSelectRoomType_Command" CommandArgument='<%# ((HashMap)Container.DataItem)["TypeCd"] %>'>
												<%= Strings.CLN_BOOKING_SELECT_ROOM%>
											</asp:LinkButton>
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
                                <%= Strings.CLN_BOOKING_YOUR_RESERVATION%><span class="title-block"></span></h4>
                            <!-- BEGIN .display-reservation -->
                            <div class="display-reservation">
                                <ul>
                                    <li><span>
                                        <%= Strings.CLN_BOOKING_CHECK_IN%>: </span>
                                        <asp:Literal ID="ltDateFrom" runat="server"></asp:Literal></li>
                                    <li><span>
                                        <%= Strings.CLN_BOOKING_CHECK_OUT%>: </span>
                                        <asp:Literal ID="ltDateTo" runat="server"></asp:Literal></li>
                                </ul>
                                <a href="#" class="button3 edit-reservation">
                                    <%= Strings.CLN_BOOKING_EDIT_RESERVATION%></a>
                                <!-- END .display-reservation -->
                            </div>
                            <!-- BEGIN .display-reservation-edit -->
                            <div class="display-reservation-edit" style="display: none">
                                <!-- BEGIN .booking-form -->
                                <div class="clearfix">
									<div class="one-half-form">
                                        <asp:Label AssociatedControlID="tbDateFrom" runat="server"><%= Strings.CLN_BOOKING_CHECK_IN%></asp:Label>
                                        <asp:TextBox ID="tbDateFrom" runat="server" CssClass="datepicker" size="10"></asp:TextBox>
                                    </div>
                                    <div class="one-half-form last-col">
                                        <asp:Label AssociatedControlID="tbDateTo" runat="server"><%= Strings.CLN_BOOKING_CHECK_OUT%></asp:Label>
                                        <asp:TextBox ID="tbDateTo" runat="server" CssClass="datepicker" size="10"></asp:TextBox>
                                    </div>
                                </div>
                                <!-- BEGIN .rooms-wrapper -->
                                <hr class="space8">
								<asp:Button runat="server" ID="btnBookingStep2" CssClass="bookbutton booking-form"
                                    Text='<%= Strings.CLN_BOOKING_CHECK_AVAILABILITY%>' OnClick="btnBookingStep2_Click" />
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
    <script type='text/javascript' src='/res/jss/booking.js'></script>
</asp:Content>
