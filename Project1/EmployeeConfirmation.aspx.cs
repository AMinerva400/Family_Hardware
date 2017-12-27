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
    public partial class EmployeeConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeRegistration"] != null)
            {
                Employee objEmployee = (Employee)Session["EmployeeRegistration"];
                lblFirstName.Text = objEmployee.firstName;
                lblMiddleName.Text = objEmployee.middleName;
                lblLastName.Text = objEmployee.lastName;
                lblAddress.Text = objEmployee.address;
                lblAddress2.Text = objEmployee.address2;
                lblCity.Text = objEmployee.city;
                lblState.Text = objEmployee.state;
                lblZipCode.Text = objEmployee.zipCode.ToString();
                lblDateHired.Text = objEmployee.DateHired;
                lblDateTerminated.Text = objEmployee.DateTerminated;
                lblTaxID.Text = objEmployee.TaxID.ToString();
                lblManagerID.Text = objEmployee.ManagerID.ToString();
                lblDepartmentID.Text = objEmployee.DepartmentID.ToString();
            }
            else
            {
                Response.Redirect("AdminPage.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Employee theEmployee = (Employee)Session["EmployeeRegistration"];
            EmployeeInfoTier empInfoTier = new EmployeeInfoTier();
            try
            {
                empInfoTier.insertEmployee(theEmployee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Session["EmployeeRegistration"] = null;
            Response.Redirect("AdminPage.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeRegistration.aspx");
        }
    }
}