using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project1.DataTiers;
using System.Data;

namespace Project1
{
    public partial class AdminPage: System.Web.UI.Page
    {
        protected void ShowCustomers()
        {
            DataSet ds = new DataSet();
            CustomerInfoTier ct = new CustomerInfoTier();
            try
            {
                ds = ct.getCustomerDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Getting DataSet " + ex.Message);
            }
            gvCustomer.DataSource = ds;
            gvCustomer.DataMember = "CustomerInfo";
            gvCustomer.DataBind();
        }

        protected void ShowSales()
        {
            DataSet ds = new DataSet();
            SalesInfoTier st = new SalesInfoTier();
            try
            {
                ds = st.getSalesDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Getting DataSet " + ex.Message);
            }
            gvSales.DataSource = ds;
            gvSales.DataBind();
        }

        protected void ShowEmployees()
        {
            DataSet ds = new DataSet();
            EmployeeInfoTier et = new EmployeeInfoTier();
            try
            {
                ds = et.getEmployeeDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Getting DataSet " + ex.Message);
            }
            gvEmployee.DataSource = ds;
            gvEmployee.DataMember = "EmployeeInfo";
            gvEmployee.DataBind();
        }

        protected void ShowProducts()
        {
            DataSet ds = new DataSet();
            ProductInfoTier pt = new ProductInfoTier();
            try
            {
                ds = pt.getProductDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Getting DataSet " + ex.Message);
            }
            gvProduct.DataSource = ds;
            gvProduct.DataMember = "ProductInfo";
            gvProduct.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowCustomers();
            ShowEmployees();
            ShowProducts();
            ShowSales();
        }

        protected void btnEmployee_Click1(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeRegistration.aspx");
        }

        protected void gvEmployee_SelectedIndexChanged(object sender, EventArgs e) { }

        protected void gvProduct_SelectedIndexChanged(object sender, EventArgs e) { }

        protected void gvCustomer_SelectedIndexChanged(object sender, EventArgs e) { }

        protected void gvSales_SelectedIndexChanged(object sender, EventArgs e) { }

        protected void btnProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("Products.aspx");
        }

        protected void btnCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerRegistration.aspx");
        }

        protected void btnSales_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShoppingCart.aspx");
        }
    }
}