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
    public partial class ShoppingCart : System.Web.UI.Page
    {
        int totalPrice = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            ProductInfoTier productTier = new ProductInfoTier();
            TableRow mainTr;
            TableCell mainTd;
            int counter = 0;
            List<Product> productList = new List<Product>();
            if (Session["Cart"] != null)
            {
                productList = (List<Product>)Session["Cart"];
            }
            else
            {
                Response.Redirect("Products.aspx");
            }
            mainTr = new TableRow();
            foreach (Product item in productList)
            {
                tblCart.Rows.Add(mainTr);
                mainTr = new TableRow();
                //create a new table cell
                mainTd = new TableCell();
                Label theLabel = new Label();
                theLabel.Text = item.ProductName;
                mainTd.Controls.Add(theLabel);
                mainTr.Cells.Add(mainTd);
                mainTd = new TableCell();
                Label Price = new Label();
                Price.Text = item.ProductPrice.ToString();
                totalPrice = totalPrice + int.Parse(Price.Text);
                mainTd.Controls.Add(Price);
                mainTr.Cells.Add(mainTd);
                counter++;
            }
            tblCart.Rows.Add(mainTr);
            lblPrice.Text = totalPrice.ToString();
            lblQuantity.Text = counter.ToString();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Sales sale = new DataModels.Sales();
            sale.QuantitySold = int.Parse(lblQuantity.Text);
            sale.PaymentType = ddlPaymentType.Text;
            sale.TotalPrice = int.Parse(lblPrice.Text);
            Session["Sales"] = sale;
            Response.Redirect("SalesConfirmation.aspx");
        }
    }
}