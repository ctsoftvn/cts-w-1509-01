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
            <%# ((HashMap)Container.DataItem)["TypeName"]%>
            <img alt='<%# ((HashMap)Container.DataItem)["TypeName"] %>' title='<%# ((HashMap)Container.DataItem)["TypeName"] %>'
                src='<%# "/file-manager?fcd=" + ((HashMap)Container.DataItem)["FileCd"] + "&lang=en&s=normal" %>' />
            <asp:Repeater DataSource='<%# ((HashMap)Container.DataItem)["ListTourByType"]%>' 
                runat="server">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <a href='<%# "/tours/" +  ((Container.Parent.Parent as RepeaterItem).DataItem as HashMap)["Slug"]+ "/" + ((HashMap)Container.DataItem)["Slug"]%>'>
                        <%# ((HashMap)Container.DataItem)["TourName"]%></a>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
