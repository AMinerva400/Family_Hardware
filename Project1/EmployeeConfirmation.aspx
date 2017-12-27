<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeConfirmation.aspx.cs" Inherits="Project1.EmployeeConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div>
        <table>
            <tr><td colspan="2" style="text-align:center"><h3>Registration Confirmation</h3></td></tr>
            <tr><td><strong>
                <asp:Label ID ="FirstNameTitle" runat="server" Text="First Name: "></asp:Label>
                    </strong></td>
                <td><asp:Label ID="lblFirstName" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr><td><strong>
                <asp:Label ID ="MiddleNameTitle" runat="server" Text="Middle Name: "></asp:Label>
                    </strong></td>
                <td><asp:Label ID="lblMiddleName" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr><td><strong>
                <asp:Label ID ="LastNameTitle" runat="server" Text="Last Name: "></asp:Label>
                    </strong></td>
                <td><asp:Label ID="lblLastName" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr><td><strong>
                <asp:Label ID ="AddressTitle" runat="server" Text="Address: "></asp:Label>
                    </strong></td>
                <td><asp:Label ID="lblAddress" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr><td><strong>
                <asp:Label ID ="Address2Title" runat="server" Text="Address 2: "></asp:Label>
                    </strong></td>
                <td><asp:Label ID="lblAddress2" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr><td><strong>
                <asp:Label ID ="CityTitle" runat="server" Text="City: "></asp:Label>
                    </strong></td>
                <td><asp:Label ID="lblCity" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr><td><strong>
                <asp:Label ID ="StateTitle" runat="server" Text="State: "></asp:Label>
                    </strong></td>
                <td><asp:Label ID="lblState" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr><td><strong>
                <asp:Label ID ="ZipCodeTitle" runat="server" Text="Zip Code: "></asp:Label>
                    </strong></td>
                <td><asp:Label ID="lblZipCode" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr><td><strong>
                <asp:Label ID ="DateHiredTitle" runat="server" Text="Date Hired: "></asp:Label>
                    </strong></td>
                <td><asp:Label ID="lblDateHired" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr><td><strong>
                <asp:Label ID ="DateTerminatedTitle" runat="server" Text="Date Terminated: "></asp:Label>
                    </strong></td>
                <td><asp:Label ID="lblDateTerminated" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr><td><strong>
                <asp:Label ID ="TaxIDTitle" runat="server" Text="Tax ID: "></asp:Label>
                    </strong></td>
                <td><asp:Label ID="lblTaxID" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr><td><strong>
                <asp:Label ID ="ManagerIDTitle" runat="server" Text="Manager ID: "></asp:Label>
                    </strong></td>
                <td><asp:Label ID="lblManagerID" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr><td><strong>
                <asp:Label ID ="DepartmentIDTitle" runat="server" Text="Department ID: "></asp:Label>
                    </strong></td>
                <td><asp:Label ID="lblDepartmentID" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-success" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-warning"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
