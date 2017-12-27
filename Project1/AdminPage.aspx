<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Project1.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="panel panel-default col-sm-6 col-md-6 col-lg-6">
        <div class="panel-heading">
            <h4>Employees</h4>
            <asp:Button ID="btnEmployee" runat="server" Text="Employee Section" OnClick="btnEmployee_Click1" CssClass="btn btn-success" />
        </div>
        <div class="panel-body">
            <asp:ObjectDataSource ID="objEmployee" TypeName="Project1.DataTiers.EmployeeInfoTier"
                SelectMethod="getEmployeeDataSet"
                DeleteMethod="deleteEmployee"
                runat="server">
                <DeleteParameters>
                    <asp:Parameter Name="EmployeeID" Type="Int32"/>
                </DeleteParameters>
            </asp:ObjectDataSource>
            <asp:GridView ID="gvEmployee" runat="server" 
                style="text-align:center"
                HorizontalAlign="Center"
                AllowPaging="true" 
                AutoGenerateColumns="false" DataKeyNames="EmployeeID" OnSelectedIndexChanged="gvEmployee_SelectedIndexChanged" Width="292px">
                <Columns>
                    <asp:CommandField ShowDeleteButton="true"/>
                    <asp:BoundField DataField="FirstName" HeaderText=" First Name "
                        ReadOnly="false" />
                    <asp:BoundField DataField="State" HeaderText=" State "
                        ReadOnly="false"/>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="panel panel-default col-sm-6 col-md-6 col-lg-6">
        <div class="panel-heading">
            <h4>Products</h4>
            <asp:Button ID="btnProducts" runat="server" Text="Products Section" OnClick="btnProducts_Click" CssClass="btn btn-success" />
        </div>
        <div class="panel-body">
            <asp:ObjectDataSource ID="objProduct" TypeName="Project1.DataTiers.ProductInfoTier"
                SelectMethod="getProductDataSet"
                DeleteMethod="deleteProduct"
                runat="server">
                <DeleteParameters>
                    <asp:Parameter Name="ProductID" Type="Int32"/>
                </DeleteParameters>
            </asp:ObjectDataSource>
            <asp:GridView ID="gvProduct" runat="server" 
                style="text-align:center"
                HorizontalAlign="Center"
                AllowPaging="true" 
                AutoGenerateColumns="false" DataKeyNames="ProductID" OnSelectedIndexChanged="gvProduct_SelectedIndexChanged" Width="292px">
                <Columns>
                    <asp:CommandField ShowDeleteButton="true"/>
                    <asp:BoundField DataField="ProductName" HeaderText=" Product Name "
                        ReadOnly="false" />
                    <asp:BoundField DataField="ProductPrice" HeaderText=" Price "
                        ReadOnly="false"/>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <br />
    <div class="panel panel-default col-sm-6 col-md-6 col-lg-6">
        <div class="panel-heading">
            <h4>Customers</h4>
            <asp:Button ID="btnCustomer" runat="server" Text="Customer Section" OnClick="btnCustomer_Click" CssClass="btn btn-success" />
        </div>
        <div class="panel-body">
            <asp:ObjectDataSource ID="objCustomer" TypeName="Project1.DataTiers.CustomerInfoTier"
                SelectMethod="getCustomerDataSet"
                DeleteMethod="deleteCustomer"
                runat="server">
                <DeleteParameters>
                    <asp:Parameter Name="CustID" Type="Int32"/>
                </DeleteParameters>
            </asp:ObjectDataSource>
            <asp:GridView ID="gvCustomer" runat="server" 
                style="text-align:center"
                HorizontalAlign="Center"
                AllowPaging="true" 
                AutoGenerateColumns="false" DataKeyNames="CustID" OnSelectedIndexChanged="gvCustomer_SelectedIndexChanged" Width="292px">
                <Columns>
                    <asp:CommandField ShowDeleteButton="true"/>
                    <asp:BoundField DataField="FirstName" HeaderText=" First Name "
                        ReadOnly="false" />
                    <asp:BoundField DataField="State" HeaderText=" State "
                        ReadOnly="false"/>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="panel panel-default col-sm-6 col-md-6 col-lg-6">
        <div class="panel-heading">
            <h4>Sales</h4>
            <asp:Button ID="btnSales" runat="server" Text="Sales Section" OnClick="btnSales_Click" CssClass="btn btn-success" />
        </div>
        <div class="panel-body">
            <asp:ObjectDataSource ID="objSales" TypeName="Project1.DataTiers.SalesInfoTier"
                SelectMethod="getSalesDataSet"
                DeleteMethod="deleteSale"
                runat="server">
                <DeleteParameters>
                    <asp:Parameter Name="SalesID" Type="Int32"/>
                </DeleteParameters>
            </asp:ObjectDataSource>
            <asp:GridView ID="gvSales" runat="server" 
                style="text-align:center"
                HorizontalAlign="Center"
                AllowPaging="true" 
                AutoGenerateColumns="false" DataKeyNames="SalesID" OnSelectedIndexChanged="gvSales_SelectedIndexChanged" Width="292px">
                <Columns>
                    <asp:CommandField ShowDeleteButton="true"/>
                    <asp:BoundField DataField="PaymentType" HeaderText=" Payment Type "
                        ReadOnly="false" />
                    <asp:BoundField DataField="TotalPrice" HeaderText=" Total Price "
                        ReadOnly="false"/>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
