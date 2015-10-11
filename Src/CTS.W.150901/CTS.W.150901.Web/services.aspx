<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="services.aspx.cs" Inherits="CTS.W._150901.Web.services" %>

<%@ Import Namespace="CTS.Core.Domain.Model" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentMain" runat="server">
    <asp:Literal runat="server" ID="ltPageName"></asp:Literal>
    <asp:Literal runat="server" ID="ltPageContent"></asp:Literal>
    <asp:Repeater ID="rptServices" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <%# ((HashMap)Container.DataItem)["ServiceName"]%>
            <%# ((HashMap)Container.DataItem)["Notes"]%>
            <img alt='<%# ((HashMap)Container.DataItem)["ServiceName"] %>' title='<%# ((HashMap)Container.DataItem)["ServiceName"] %>'
                src='<%# "/file-manager?fcd=" + ((HashMap)Container.DataItem)["FileCd"] + "&lang=en&s=normal" %>' />
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
