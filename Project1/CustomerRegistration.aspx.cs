using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project1.DataModels;

namespace Project1
{
    public partial class CustomerRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["CustomerRegistration"] != null)
            {
                Customer objCustomer = (Customer)Session["CustomerRegistration"];
                txtFirstName.Text = objCustomer.firstName;
                txtMiddleName.Text = objCustomer.middleName;
                txtLastName.Text = objCustomer.lastName;
                txtAddress.Text = objCustomer.address;
                txtAddress2.Text = objCustomer.address2;
                txtCity.Text = objCustomer.city;
                txtState.Text = objCustomer.state;
                txtZipCode.Text = objCustomer.zipCode.ToString();
                Session["CustomerRegistration"] = null;
            }
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            Customer theCustomer = new DataModels.Customer();
            theCustomer.firstName = txtFirstName.Text;
            theCustomer.middleName = txtMiddleName.Text;
            theCustomer.lastName = txtLastName.Text;
            theCustomer.address = txtAddress.Text;
            theCustomer.address2 = txtAddress2.Text;
            theCustomer.city = txtCity.Text;
            theCustomer.state = txtState.Text;
            try
            {
                theCustomer.zipCode = int.Parse(txtZipCode.Text);
            }
            catch(FormatException ex)
            {
                throw ex;
            }
            Session["CustomerRegistration"] = theCustomer;
            Response.Redirect("RegistrationConfirmation.aspx");
        }
    }
}