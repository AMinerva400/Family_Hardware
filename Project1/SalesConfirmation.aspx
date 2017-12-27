<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalesConfirmation.aspx.cs" Inherits="Project1.SalesConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div>
        <table>
            <tr><td colspan="2" style="text-align:center"><h3>Sales Confirmation</h3></td></tr>
            <tr><td><strong>
                <asp:Label ID ="QuantitySoldTitle" runat="server" Text="Quantity Sold: "></asp:Label>
                    </strong></td>
                <td><asp:Label ID="lblQuantitySold" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr><td><strong>
                <asp:Label ID ="PaymentMethodTitle" runat="server" Text="Payment Method: "></asp:Label>
                    </strong></td>
                <td><asp:Label ID="lblPaymentMethod" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr><td><strong>
                <asp:Label ID ="TotalPriceTitle" runat="server" Text="Total Price: "></asp:Label>
                    </strong></td>
                <td><asp:Label ID="lblTotalPrice" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Button ID="btnPay" runat="server" Text="Pay" OnClick="btnSubmit_Click" CssClass="btn btn-success" />
                    <asp:Button ID="btnCancel" runat="server" Text="Continue Shopping" OnClick="btnCancel_Click" CssClass="btn btn-warning"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
