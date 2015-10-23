<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="CTS.W._150901.Web.index" %>

<%@ Import Namespace="Resources" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentMain" runat="server">
    <div class="row title-page">
        <div class="col-xs-12">
            <h1><asp:Literal runat="server" ID="ltPageName"></asp:Literal></h1>
        </div>
    </div>
    <div class="row des">
        <div class="col-xs-12 col-sm-12">
            <h2><asp:Literal runat="server" ID="ltPageContent"></asp:Literal></h2>
        </div>
    </div>
    <div class="row hotel-feature">
        <div class="col-xs-12 col-sm-4 col-md-4">
            <div class="thumbnails thumbnail-style thumbnail-kenburn box-feature">
                <a href="<%= Strings.CLN_MASTER_DESTINATIONS_LINK %>">
                    <p class="thumbnail-title-dek  img-title">
                        <%= Strings.CLN_INDEX_LOCATION%></p>
                </a>
                <div class="thumbnail-radious">
                    <div class="thumbnail-img">
                        <a href="<%= Strings.CLN_MASTER_DESTINATIONS_LINK %>">
                            <p class="thumbnail-title img-title">
                                <%= Strings.CLN_INDEX_LOCATION%></p>
                        </a>
                        <div class="overflow-hidden">
                            <img width="269" height="179" src="/res/img/location.png" alt="" class="img-responsive">
                        </div>
                    </div>
                </div>
                <a class="btn-more hover-effect" href="<%= Strings.CLN_MASTER_DESTINATIONS_LINK %>">
                    <%= Strings.CLN_INDEX_READMORE%></a>
            </div>
        </div>
        <div class="col-xs-12 col-sm-4 col-md-4">
            <div class="thumbnails thumbnail-style thumbnail-kenburn box-feature">
                <a href="<%= Strings.CLN_MASTER_PROMOTION_LINK %>">
                    <p class="thumbnail-title-dek img-title">
                        <%= Strings.CLN_INDEX_SPECIAL_DEAL %></p>
                </a>
                <div class="thumbnail-radious">
                    <div class="thumbnail-img">
                        <a href="<%= Strings.CLN_MASTER_PROMOTION_LINK %>">
                            <p class="thumbnail-title img-title">
                                <%= Strings.CLN_INDEX_SPECIAL_DEAL%></p>
                        </a>
                        <div class="overflow-hidden">
                            <img width="269" height="179" src="/res/img/promotion.png" alt="" class="img-responsive">
                        </div>
                    </div>
                </div>
                <a class="btn-more hover-effect" href="<%= Strings.CLN_MASTER_PROMOTION_LINK %>">
                    <%= Strings.CLN_INDEX_READMORE%></a>
            </div>
        </div>
        <div class="col-xs-12 col-sm-4 col-md-4">
            <div class="thumbnails thumbnail-style thumbnail-kenburn box-feature">
                <a href="<%= Strings.CLN_MASTER_TOURS_LINK %>">
                    <p class="thumbnail-title-dek img-title">
                        <%= Strings.CLN_INDEX_TOUR %></p>
                </a>
                <div class="thumbnail-radious">
                    <div class="thumbnail-img">
                        <a href="<%= Strings.CLN_MASTER_TOURS_LINK %>">
                            <p class="thumbnail-title img-title">
                                <%= Strings.CLN_INDEX_TOUR %></p>
                        </a>
                        <div class="overflow-hidden">
                            <img width="269" height="179" src="/res/img/News.png" alt="" class="img-responsive">
                        </div>
                    </div>
                </div>
                <a class="btn-more hover-effect" href="<%= Strings.CLN_MASTER_TOURS_LINK %>">
                    <%= Strings.CLN_INDEX_READMORE%></a>
            </div>
        </div>
    </div>
    
</asp:Content>
