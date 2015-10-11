<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="tour-detail.aspx.cs" Inherits="CTS.W._150901.Web.tour_detail" %>

<%@ Import Namespace="CTS.Core.Domain.Model" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentMain" runat="server">
    <asp:Literal ID="ltTourTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltTourDes" runat="server"></asp:Literal>
</asp:Content>
