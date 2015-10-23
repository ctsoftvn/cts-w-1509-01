<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="contact-us.aspx.cs" Inherits="CTS.W._150901.Web.contact_us" %>

<%@ Import Namespace="Resources" %>
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
    <div class="row">
        <div class="col-xs-12 col-md-6">
            <h6 class="title">
                <asp:Literal runat="server" ID="ltCompanyName"></asp:Literal></h6>
            <div class="clearfix">
            </div>
            <div class="contact-block">
                <ul class="list-unstyled">
                    <li><i class="fa fa-map-marker"></i>
                        <asp:Literal ID="ltAdderess" runat="server" />
                    </li>
                    <li><i class="fa fa-phone"></i>
                        <asp:Literal ID="ltPhone" runat="server" />
                    </li>
                    <li><i class="fa fa-envelope-o"></i>
                        <asp:Literal ID="ltEmail" runat="server" />
                    </li>
                    <li><i class="fa fa-globe"></i>
                        <p>
                            http://www.asianrubyselecthotel.com/</p>
                    </li>
                </ul>
            </div>
        </div>
        <div class="col-xs-12 col-md-6 contact_form">
            <h6 class="title">
                <%= Strings.CLN_CONTACT_US_TITLE_FORM%></h6>
            <div class="clearfix">
            </div>
            <div class="form-group">
                <label>
                    <%= Strings.CLN_CONTACT_US_NAME %>:</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="*" ControlToValidate="txtName"
                    Display="Dynamic" ForeColor="#FF3300" CssClass="alert_textbox_inputText"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label>
                    <%= Strings.CLN_CONTACT_US_PHONE %>:</label>
                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>
                    <%= Strings.CLN_CONTACT_US_EMAIL %>:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail"
                    Display="Dynamic" ForeColor="#FF3300" CssClass="alert_textbox_inputText"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail"
                    Display="Dynamic" CssClass="alert_textbox_inputText" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label>
                    <%= Strings.CLN_CONTACT_US_REQUEST %>:</label>
                <asp:TextBox ID="txtDescription" CssClass="form-control" TextMode="MultiLine" runat="server"
                    Columns="30" Rows="5"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ErrorMessage="*" ControlToValidate="txtDescription"
                    Display="Dynamic" ForeColor="#FF3300" CssClass="alert_textbox_inputText"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label>
                </label>
                <asp:Button ID="btnSubmit" runat="server" CssClass="button" OnCommand="btnSubmit_Command" />
                <input id="btnReset" class="reset button" onclick="hideValidator(); ResetForm();"
                    type="button" value='<%= Strings.CLN_CONTACT_US_RESET %>' /></div>
        </div>
    </div>
</asp:Content>
