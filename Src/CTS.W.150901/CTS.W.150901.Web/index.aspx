<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="CTS.W._150901.Web.index" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentMain" runat="server">
    <div class="row des">
        <div class="col-xs-12">
            <asp:Literal runat="server" ID="ltPageName"></asp:Literal>
        </div>
    </div>
    <div class="row hotel-feature">
        <div class="col-xs-12 col-sm-4 col-md-4">
            <div class="thumbnails thumbnail-style thumbnail-kenburn box-feature">
                <a href="#">
                    <p class="thumbnail-title-dek  img-title">
                        Our Location</p>
                </a>
                <div class="thumbnail-radious">
                    <div class="thumbnail-img">
                        <a href="#">
                            <p class="thumbnail-title img-title">
                                Our Location</p>
                        </a>
                        <div class="overflow-hidden">
                            <img width="269" height="179" src="/res/img/location.jpg" alt="" class="img-responsive">
                        </div>
                    </div>
                </div>
                <a class="btn-more hover-effect" href="#">Read More+</a>
            </div>
        </div>
        <div class="col-xs-12 col-sm-4 col-md-4">
            <div class="thumbnails thumbnail-style thumbnail-kenburn box-feature">
                <a href="#">
                    <p class="thumbnail-title-dek img-title">
                        Special Deal</p>
                </a>
                <div class="thumbnail-radious">
                    <div class="thumbnail-img">
                        <a href="#">
                            <p class="thumbnail-title img-title">
                                Special Deal</p>
                        </a>
                        <div class="overflow-hidden">
                            <img width="269" height="179" src="/res/img/promotion.jpg" alt="" class="img-responsive">
                        </div>
                    </div>
                </div>
                <a class="btn-more hover-effect" href="#">Read More+</a>
            </div>
        </div>
        <div class="col-xs-12 col-sm-4 col-md-4">
            <div class="thumbnails thumbnail-style thumbnail-kenburn box-feature">
                <a href="#">
                    <p class="thumbnail-title-dek img-title">
                        News &amp; Events</p>
                </a>
                <div class="thumbnail-radious">
                    <div class="thumbnail-img">
                        <a href="#">
                            <p class="thumbnail-title img-title">
                                News &amp; Events</p>
                        </a>
                        <div class="overflow-hidden">
                            <img width="269" height="179" src="/res/img/News.jpg" alt="" class="img-responsive">
                        </div>
                    </div>
                </div>
                <a class="btn-more hover-effect" href="#">Read More+</a>
            </div>
        </div>
    </div>
    <div class="row home-description">
        <div class="col-xs-12 col-sm-12">
            <asp:Literal runat="server" ID="ltPageContent"></asp:Literal>
        </div>
    </div>
</asp:Content>
