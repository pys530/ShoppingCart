<%@ Page Title="Cart Contents" Language="C#" MasterPageFile="~/PagesPublic/NestedPublic.Master" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="ShoppingCart.Results" %>

<asp:Content ID="Content1" ContentPlaceHolderID="publicContentPlaceHolder" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="PRODUCT_ID" DataSourceID="SqlDataSource1">
    <Columns>
        <asp:BoundField DataField="PRODUCT_ID" HeaderText="PRODUCT_ID" ReadOnly="True" SortExpression="PRODUCT_ID" />
        <asp:BoundField DataField="PRODUCT_NAME" HeaderText="PRODUCT_NAME" SortExpression="PRODUCT_NAME" />
        <asp:BoundField DataField="MANUFACTURER" HeaderText="MANUFACTURER" SortExpression="MANUFACTURER" />
        <asp:BoundField DataField="DESC_SHORT" HeaderText="DESC_SHORT" SortExpression="DESC_SHORT" />
        <asp:BoundField DataField="DESC_LONG" HeaderText="DESC_LONG" SortExpression="DESC_LONG" />
        <asp:BoundField DataField="UNIT_WEIGHT" HeaderText="UNIT_WEIGHT" SortExpression="UNIT_WEIGHT" />
        <asp:BoundField DataField="UNIT_PRICE" HeaderText="UNIT_PRICE" SortExpression="UNIT_PRICE" />
        <asp:CheckBoxField DataField="AVAILABLE" HeaderText="AVAILABLE" SortExpression="AVAILABLE" />
    </Columns>
</asp:GridView>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:fall16_g3ConnectionString2 %>" SelectCommand="SELECT [PRODUCT_ID], [PRODUCT_NAME], [MANUFACTURER], [DESC_SHORT], [DESC_LONG], [UNIT_WEIGHT], [UNIT_PRICE], [AVAILABLE] FROM [PRODUCT]"></asp:SqlDataSource>

</asp:Content>