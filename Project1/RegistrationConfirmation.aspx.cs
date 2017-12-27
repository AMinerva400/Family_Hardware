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
    public partial class RegistrationConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerRegistration"] != null)
            {
                Customer objCustomer = (Customer)Session["CustomerRegistration"];
                lblFirstName.Text = objCustomer.firstName;
                lblMiddleName.Text = objCustomer.middleName;
                lblLastName.Text = objCustomer.lastName;
                lblAddress.Text = objCustomer.address;
                lblAddress2.Text = objCustomer.address2;
                lblCity.Text = objCustomer.city;
                lblState.Text = objCustomer.state;
                lblZipCode.Text = objCustomer.zipCode.ToString();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Customer theCustomer = (Customer)Session["CustomerRegistration"];
            CustomerInfoTier custInfoTier = new CustomerInfoTier();
            try
            {
                custInfoTier.insertCustomer(theCustomer);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            Session["CustomerRegistration"] = null;
            Response.Redirect("Default.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerRegistration.aspx");
        }
    }
}