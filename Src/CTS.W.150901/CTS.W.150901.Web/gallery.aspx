<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="gallery.aspx.cs" Inherits="CTS.W._150901.Web.gallery" %>

<%@ Import Namespace="CTS.Core.Domain.Model" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">
    <link rel='stylesheet' href='/res/css/main.css' type='text/css' media='all' />
    <link rel='stylesheet' href='/res/css/lightgallery.css' type='text/css' media='all' />
    <link rel='stylesheet' href='/res/css/justifiedGallery.min.css' type='text/css' media='all' />
    <!--  js -->
    <%--<script type='text/javascript' src='/res/jss/jquery-1.8.0.min.js'></script>--%>
    <script type='text/javascript' src='/res/jss/lightgallery.js'></script>
    <script type='text/javascript' src='/res/jss/lg-zoom.js'></script>
    <script type='text/javascript' src='/res/jss/lg-video.js'></script>
    <script type='text/javascript' src='/res/jss/lg-thumbnail.js'></script>
    <script type='text/javascript' src='/res/jss/lg-fullscreen.js'></script>
    <script type='text/javascript' src='/res/jss/lg-autoplay.js'></script>
    <script type='text/javascript' src='/res/jss/jquery.justifiedGallery.min.js'></script>
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
    <asp:Repeater ID="rptPhotos" runat="server">
        <HeaderTemplate>
            <div class="demo-gallery mrb50">
                <div id="aniimated-thumbnials">
        </HeaderTemplate>
        <ItemTemplate>
            <a href='<%# "/file-manager?fcd=" + PageCom.GetValue(Container.DataItem as HashMap, "FileCd") + "&lang=en&s=large" %>'>
                <img class="img-responsive" src='<%# "/file-manager?fcd=" + PageCom.GetValue(Container.DataItem as HashMap, "FileCd") + "&lang=en&s=normal&w=340&h=255&bgcolor=fff&noimg=/res/img/noimg340x255.jpg" %>'
                    alt='<%# PageCom.GetValue(Container.DataItem as HashMap, "PhotoName") %>' title='<%# PageCom.GetValue(Container.DataItem as HashMap, "PhotoName") %>'>
                <div class="demo-gallery-poster">
                    <img src="/res/img/zoom.png" alt="">
                </div>
            </a>
        </ItemTemplate>
        <FooterTemplate>
            </div> </div>
        </FooterTemplate>
    </asp:Repeater>
    <script type="text/javascript">
        $(document).ready(function () {
            // Animated thumbnails
            var $animThumb = $('#aniimated-thumbnials');
            if ($animThumb.length) {
                $animThumb.justifiedGallery({
                    border: 6
                });
            };
        });
        $('#aniimated-thumbnials').lightGallery({
            thumbnail: true
        }); 
    </script>
</asp:Content>
