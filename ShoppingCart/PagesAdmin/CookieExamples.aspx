<%@ Page Title="" Language="C#" MasterPageFile="~/PagesAdmin/NestedAdmin.master" AutoEventWireup="true" CodeBehind="CookieExamples.aspx.cs" Inherits="ShoppingCart.GetAllCookies" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="adminContentPlaceHolder" runat="server">
    <h1>Current Cookies</h1>
    <asp:GridView
        ID="grdCookies"
        runat="server"
        CaptionAlign="Bottom"
        Caption="*ASP.NET must track a session ID for each user so that it can map the user to session state information on the server. 
        By default, ASP.NET uses a non-persistent cookie to store the session state.">
    </asp:GridView>
    <br />
    <asp:Button ID="btnGetCookies" runat="server" Text="Get Cookies" OnClick="btnGetCookies_Click" />
    <hr />
    <table class="table table-bordered table-striped">
        <tr>
            <td>Cookie Name:</td>
            <td colspan="2">
                <asp:TextBox ID="txtCookieName" runat="server" ></asp:TextBox></td>
        </tr>
        <tr>
            <td>Name/Key-value pair 1:</td>
            <td>
                <asp:TextBox ID="txtName1" runat="server"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="txtValue1" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Name/Key-value pair 2:</td>
            <td>
                <asp:TextBox ID="txtName2" runat="server"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="txtValue2" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Expiration</td>
            <td colspan="2">
                <input id="txtExpiration" type="date" runat="server" />
        </tr>
    </table>
    <asp:Button ID="btnWriteCookie" runat="server" Text="Create New Cookie" OnClick="btnWriteCookie_Click" />
</asp:Content>
