<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="tour-detail.aspx.cs" Inherits="CTS.W._150901.Web.tour_detail" %>

<%@ Import Namespace="CTS.Core.Domain.Model" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentMain" runat="server">
    <div class="row title-page">
        <div class="col-xs-12">
            <h1>
                <asp:Literal ID="ltTourTitle" runat="server"></asp:Literal></h1>
        </div>
    </div>
    <div class="row description-page pagetourdetail">
        <div class="col-xs-12 col-sm-12">
            <asp:Literal ID="ltTourDes" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
