<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="Project1.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="jumbotron"><h4>Shopping Cart</h4></div>
    <asp:Table HorizontalAlign="Center" ID="tblCart" runat="server">
        <asp:TableHeaderRow runat="server">
            <asp:TableHeaderCell runat="server" ID="tblHeader">
                <p><strong>Cart Contents</strong></p>
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <br />
    <asp:Label runat="server" ID="lblPaymentType" Text="Payment Type:" style="font-weight: 700"></asp:Label>
    &nbsp;&nbsp;
    <asp:DropDownList runat="server" ID="ddlPaymentType">
        <asp:ListItem>Credit</asp:ListItem>
        <asp:ListItem>Debit</asp:ListItem>
        <asp:ListItem>Cash</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Label runat="server" Text="Total Price:" style="font-weight: 700"></asp:Label>
    &nbsp;&nbsp;
    <asp:Label runat="server" ID="lblPrice"></asp:Label>
    <br />
    <asp:Label runat="server" Text="Quantity:" style="font-weight: 700"></asp:Label>
    &nbsp;&nbsp;
    <asp:Label runat="server" ID="lblQuantity"></asp:Label>
    <br />
    <br />
    <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" />
    </asp:Content>
