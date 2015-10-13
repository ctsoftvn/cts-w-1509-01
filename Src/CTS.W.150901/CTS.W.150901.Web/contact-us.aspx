<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="contact-us.aspx.cs" Inherits="CTS.W._150901.Web.contact_us" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentMain" runat="server">
    <asp:Literal runat="server" ID="ltPageName"></asp:Literal>
    <asp:Literal runat="server" ID="ltPageContent"></asp:Literal>
    <ul class="contact_form">
        <li>
            <label>
                Name</label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="*" ControlToValidate="txtName"
                Display="Dynamic" ForeColor="#FF3300" CssClass="alert_textbox_inputText"></asp:RequiredFieldValidator>
        </li>
        <li>
            <label>
                Phone</label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        </li>
        <li>
            <label>
                Email</label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail"
                Display="Dynamic" ForeColor="#FF3300" CssClass="alert_textbox_inputText"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail"
                Display="Dynamic" CssClass="alert_textbox_inputText" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </li>
        <li>
            <label>
                Message</label>
            <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" Columns="30"
                Rows="5"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ErrorMessage="*" ControlToValidate="txtDescription"
                Display="Dynamic" ForeColor="#FF3300" CssClass="alert_textbox_inputText"></asp:RequiredFieldValidator>
        </li>
        <li>
            <label>
                &nbsp;</label>
            <asp:Button ID="btnSubmit" runat="server" CssClass="button" OnCommand="btnSubmit_Command" />
            <input id="Reset1" class="reset" onclick="hideValidator(); ResetForm();" type="button"
                value='reset' />
        </li>
    </ul>
</asp:Content>
