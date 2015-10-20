<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="tours.aspx.cs" Inherits="CTS.W._150901.Web.tours" %>

<%@ Import Namespace="CTS.Core.Domain.Model" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentMain" runat="server">
    <asp:Literal runat="server" ID="ltPageName"></asp:Literal>
    <asp:Literal runat="server" ID="ltPageContent"></asp:Literal>
    <asp:Repeater ID="rptTours" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <a href='<%# "/tours/" + ((HashMap)Container.DataItem)["Slug"]%>'>
                <%# ((HashMap)Container.DataItem)["TourName"]%></a>
            <%# ((HashMap)Container.DataItem)["Summary"]%>
            <img alt='<%# ((HashMap)Container.DataItem)["TourName"] %>' title='<%# ((HashMap)Container.DataItem)["TourName"] %>'
                src='<%# "/file-manager?fcd=" + ((HashMap)Container.DataItem)["FileCd"] + "&lang=en&s=normal" %>' />
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
