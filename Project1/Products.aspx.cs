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
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Table mainTable = new Table();
            mainTable.Attributes.Add("HorizontalAlign", "Center");
            ProductInfoTier productTier = new ProductInfoTier();
            TableRow mainTr;
            TableCell mainTd;
            int counter = 0;
            List<Product> productList = productTier.getAllProducts();
            mainTr = new TableRow();
            foreach (Product item in productList)
            {
                if (counter % 3 == 0)
                {
                    mainTable.Rows.Add(mainTr);
                    mainTr = new TableRow();
                }
                //create a new table cell
                mainTd = new TableCell();
                //get a product table from my method definded bellow.
                Table theProductTable = productTable(item);
                //Add the product table to the table cell
                mainTd.Controls.Add(theProductTable);
                //add the table cell to the table row.
                mainTr.Cells.Add(mainTd);

                counter++;
            }
            //Add the main table to the panel on the ASPX Page
            pnlProduct.Controls.Add(mainTable);
        }

        /// <summary>
        /// This method will create a table of a single product.
        /// </summary>
        /// <param name="theProduct">A Product as a Product Data Model</param>
        /// <returns>Returns the table of a single Product</returns>
        private Table productTable(Product theProduct)
        {
            //declare all the variable I need for the single table
            Table theTable = new Table();
            TableRow tr = new TableRow();
            TableCell td = new TableCell();
            Label theLabel = new Label();
            Button addToCart;

            //create an instance of the image control
            Label Name = new Label();

            //set the URL of the image control to my image handler.  Notice the product ID is used
            //in the query string.
            Name.Text = theProduct.ProductName;
            td.Controls.Add(Name);
            //add the table cell to the table row
            tr.Cells.Add(td);
            //add the table row to the table.
            theTable.Rows.Add(tr);


            //Now cereate a new instance of both table row and table cell
            tr = new TableRow();
            td = new TableCell();
            //create an instance of the label needed for the description
            theLabel = new Label();
            //set the text of the label to the description of the product.
            theLabel.Text = theProduct.ProductDescription;
            //add the label to the cell
            td.Controls.Add(theLabel);
            //add the cell to the row
            tr.Cells.Add(td);
            //add the row to the table.
            theTable.Rows.Add(tr);

            tr = new TableRow();
            td = new TableCell();
            theLabel = new Label();
            theLabel.Text = theProduct.ProductPrice.ToString();
            td.Controls.Add(theLabel);
            tr.Cells.Add(td);
            theTable.Rows.Add(tr);

            tr = new TableRow();
            td = new TableCell();
            //create a new instance of type button control
            addToCart = new Button();
            //set the ID of the burtton to the product ID (needed later)
            addToCart.ID = theProduct.ProductID.ToString();
            //set the text of the button
            addToCart.Text = "Add To Cart";
            //set some bootstrap classes to the button
            addToCart.CssClass = "btn btn-success";
            //set the event handler for the button.  This eventhandler is created
            //by you.  See method below.
            addToCart.Click += addToCartClick;
            //Add button to table cell
            td.Controls.Add(addToCart);
            //add table cell to table row
            tr.Cells.Add(td);
            //add table row to the table
            theTable.Rows.Add(tr);

            return theTable;
        }

        protected void addToCartClick(object sender, EventArgs e)
        {
            //sender is a button, make it a button
            Button theButton = (Button)sender;

            ProductInfoTier productTier = new ProductInfoTier();

            //using the ID from the button, get a product from the Data Tier
            Product theProduct = productTier.getProductByID(int.Parse(theButton.ID));

            //The following is basic shopping cart code minus the shoppiong cart class.
            List<Product> theCart;

            if (Session["Cart"] != null)
            {
                theCart = (List<Product>)Session["Cart"];
                theCart.Add(theProduct);
            }
            else
            {
                theCart = new List<Product>();
                theCart.Add(theProduct);
            }

            Session["Cart"] = theCart;
        }
    }
}