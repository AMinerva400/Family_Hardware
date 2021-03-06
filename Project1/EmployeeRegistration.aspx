﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeRegistration.aspx.cs" Inherits="Project1.EmployeeRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="panel panel-success">
        <div class="panel-heading text-center">
            <h2>Employee Registration</h2>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <label>First Name:</label>
                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" 
                    ControlToValidate="txtFirstName" ErrorMessage="Please Enter a First Name" 
                    Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Middle Name:</label>
                <asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Last Name:</label>
                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" 
                    ControlToValidate="txtLastName" ErrorMessage="Please Enter a Last Name" 
                    Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Address:</label>
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" 
                    ControlToValidate="txtAddress" ErrorMessage="Please Enter an Address" 
                    Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Address 2:</label>
                <asp:TextBox ID="txtAddress2" runat="server" CssClass="form-control"></asp:TextBox>
                <label>City:</label>
                <asp:RequiredFieldValidator ID="rfvCity" runat="server" 
                    ControlToValidate="txtCity" ErrorMessage="Please Enter a City" 
                    Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>
                <label>State:</label>
                <asp:RequiredFieldValidator ID="rfvState" runat="server" 
                    ControlToValidate="txtState" ErrorMessage="Please Enter a State" 
                    Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtState" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Zip Code:</label>
                <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" 
                    ControlToValidate="txtZipCode" ErrorMessage="Please Enter a Zip Code" 
                    Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Date Hired:</label>
                <asp:RequiredFieldValidator ID="rfvDateHired" runat="server" 
                    ControlToValidate="txtDateHired" ErrorMessage="Please Enter a Date" 
                    Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtDateHired" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Date Terminated:</label>
                <asp:TextBox ID="txtDateTerminated" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Tax ID:</label>
                <asp:RequiredFieldValidator ID="rfvTaxID" runat="server" 
                    ControlToValidate="txtTaxID" ErrorMessage="Please Enter a Tax ID" 
                    Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtTaxID" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Manager ID:</label>
                <asp:RequiredFieldValidator ID="rfvManagerID" runat="server" 
                    ControlToValidate="txtManagerID" ErrorMessage="Please Enter a Manager ID" 
                    Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtManagerID" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Department ID:</label>
                <asp:RequiredFieldValidator ID="rfvDepartmentID" runat="server" 
                    ControlToValidate="txtDepartmentID" ErrorMessage="Please Enter a Department ID" 
                    Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtDepartmentID" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="row center-block">
                <asp:Button ID="btnEnter" runat="server" Text="Submit" OnClick="btnEnter_Click" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                    DisplayMode="BulletList" ShowSummary="true" HeaderText="Please Fix the Following Errors"
                    ForeColor="Red" />
            </div>
        </div>
    </div>
</asp:Content>
