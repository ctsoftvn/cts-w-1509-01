<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="accommodation.aspx.cs" Inherits="CTS.W._150901.Web.accommodation" %>

<%@ Import Namespace="CTS.Core.Domain.Model" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentMain" runat="server">
    <div class="row title-page">
        <div class="col-xs-12">
            <h1>
                <asp:Literal runat="server" ID="ltPageName"></asp:Literal></h1>
        </div>
    </div>
    
    <asp:Repeater ID="rptRooms" runat="server">
        <HeaderTemplate>
            <div class="row">
        </HeaderTemplate>
        <ItemTemplate>
            <div class=" col-md-4 col-xs-12 mTop-40">
                <img class="img-responsive bo-img-fac" alt='<%# PageCom.GetValue(Container.DataItem as HashMap, "AccomName") %>'
                    title='<%# PageCom.GetValue(Container.DataItem as HashMap, "AccomName") %>' src='<%# "/file-manager?fcd=" + PageCom.GetValue(Container.DataItem as HashMap, "FileCd") + "&lang=en&s=normal&w=360&h=220&bgcolor=fff&noimg=/res/img/noimg360x220.jpg" %>' />
            </div>
            <div class=" col-md-8 col-xs-12 mTop-40">
                <h6 class="title">
                    <%# PageCom.GetValue(Container.DataItem as HashMap, "AccomName")%></h6>
                <div class="clearfix">
                </div>
                <%# PageCom.GetValue(Container.DataItem as HashMap, "Notes")%>
            </div>
            <hr class="right">
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>
    <div class="row description-page">
        <div class="col-xs-12 col-sm-12">
            <asp:Literal runat="server" ID="ltPageContent"></asp:Literal>
        </div>
    </div>
</asp:Content>
