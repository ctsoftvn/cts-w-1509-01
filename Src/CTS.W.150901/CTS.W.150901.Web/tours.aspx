<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="tours.aspx.cs" Inherits="CTS.W._150901.Web.tours" %>

<%@ Import Namespace="CTS.Core.Domain.Model" %>
<%@ Import Namespace="Resources" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentMain" runat="server">
    <div class="row title-page">
        <div class="col-xs-12">
            <h1>
                <asp:Literal runat="server" ID="ltPageName"></asp:Literal></h1>
        </div>
    </div>
    <div class="row description-page">
        <div class="col-xs-12 col-sm-12">
            <asp:Literal runat="server" ID="ltPageContent"></asp:Literal>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12">
            <asp:Repeater ID="rptTours" runat="server">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="trip-item">
                        <div class="item-media">
                            <a href='<%# "/tours/" + PageCom.GetValue(Container.DataItem as HashMap, "Slug")%>'>
                                <img alt='<%# PageCom.GetValue(Container.DataItem as HashMap, "TourName") %>' title='<%# PageCom.GetValue(Container.DataItem as HashMap, "TourName") %>'
                                    src='<%# "/file-manager?fcd=" + PageCom.GetValue(Container.DataItem as HashMap, "FileCd") + "&lang=en&s=normal&w=255&h=170&bgcolor=fff&noimg=/res/img/noimg255x170.jpg" %>' />
                            </a>
                        </div>
                        <div class="item-body">
                            <div class="item-title">
                                <h2>
                                    <a href='<%# "/tours/" + PageCom.GetValue(Container.DataItem as HashMap, "Slug")%>'>
                                        <%# PageCom.GetValue(Container.DataItem as HashMap, "TourName")%></a></h2>
                            </div>
                            <div class="item-list">
                                <%# PageCom.GetValue(Container.DataItem as HashMap, "Summary")%>
                            </div>
                            <div class="item-footer">
                                <div class="item-icon">
                                    <i class="awe-icon awe-icon-car"></i><i class="awe-icon awe-icon-level"></i><i class="awe-icon awe-icon-wifi">
                                    </i>
                                </div>
                            </div>
                        </div>
                        <div class="item-price-more">
                            <a class="awe-btn" href='<%# "/tours/" + PageCom.GetValue(Container.DataItem as HashMap, "Slug")%>'>
                                <%= Strings.CLN_TOUR_READMORE%></a></div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
