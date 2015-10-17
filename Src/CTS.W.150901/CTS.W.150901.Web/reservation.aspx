<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="reservation.aspx.cs" Inherits="CTS.W._150901.Web.reservation" %>

<%@ Import Namespace="CTS.Core.Domain.Model" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">

</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentMain" runat="server">
    <asp:Literal runat="server" ID="ltPageName"></asp:Literal>
    <asp:Literal runat="server" ID="ltPageContent"></asp:Literal>
    <asp:Repeater ID="rptRooms" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <%# ((HashMap)Container.DataItem)["TypeName"]%>
            <%# ((HashMap)Container.DataItem)["Notes"]%>
            <%# ((HashMap)Container.DataItem)["Price"]%>
            <%# ((HashMap)Container.DataItem)["AdultPerRoom"]%>
            <img alt='<%# ((HashMap)Container.DataItem)["TypeName"] %>' title='<%# ((HashMap)Container.DataItem)["TypeName"] %>'
                src='<%# "/file-manager?fcd=" + ((HashMap)Container.DataItem)["FileCd"] + "&lang=en&s=normal" %>' />
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
   
</asp:Content>
