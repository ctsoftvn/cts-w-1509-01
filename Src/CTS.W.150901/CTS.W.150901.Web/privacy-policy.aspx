﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="privacy-policy.aspx.cs" Inherits="CTS.W._150901.Web.privacy_policy" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">
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
</asp:Content>
