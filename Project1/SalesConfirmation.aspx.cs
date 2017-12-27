using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project1.DataModels;
using Project1.DataTiers;

namespace Project1
{
    public partial class SalesConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Sales"] != null)
            {
                Sales sale = (Sales)Session["Sales"];
                lblQuantitySold.Text = sale.QuantitySold.ToString();
                lblPaymentMethod.Text = sale.PaymentType;
                lblTotalPrice.Text = sale.TotalPrice.ToString();
            }
            else
            {
                Response.Redirect("ShoppingCart.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Sales sale = (Sales)Session["Sales"];
            SalesInfoTier salesInfoTier = new SalesInfoTier();
            try
            {
                salesInfoTier.insertSale(sale);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Session["Sales"] = null;
            Response.Redirect("Products.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Products.aspx");
        }
    }
}