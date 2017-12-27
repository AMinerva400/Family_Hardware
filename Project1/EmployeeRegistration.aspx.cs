using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project1.DataModels;

namespace Project1
{
    public partial class EmployeeRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeRegistration"] != null)
            {
                Employee objEmployee = (Employee)Session["EmployeeRegistration"];
                txtFirstName.Text = objEmployee.firstName;
                txtMiddleName.Text = objEmployee.middleName;
                txtLastName.Text = objEmployee.lastName;
                txtAddress.Text = objEmployee.address;
                txtAddress2.Text = objEmployee.address2;
                txtCity.Text = objEmployee.city;
                txtState.Text = objEmployee.state;
                txtZipCode.Text = objEmployee.zipCode.ToString();
                txtDateHired.Text = objEmployee.DateHired;
                txtDateTerminated.Text = objEmployee.DateTerminated;
                txtTaxID.Text = objEmployee.TaxID.ToString();
                txtManagerID.Text = objEmployee.ManagerID.ToString();
                txtDepartmentID.Text = objEmployee.DepartmentID.ToString();
                Session["EmployeeRegistration"] = null;
            }
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            Employee theEmployee = new Employee();
            theEmployee.firstName = txtFirstName.Text;
            theEmployee.middleName = txtMiddleName.Text;
            theEmployee.lastName = txtLastName.Text;
            theEmployee.address = txtAddress.Text;
            theEmployee.address2 = txtAddress2.Text;
            theEmployee.city = txtCity.Text;
            theEmployee.state = txtState.Text;
            theEmployee.DateHired = txtDateHired.Text;
            theEmployee.DateTerminated = txtDateTerminated.Text;
            try
            {
                theEmployee.zipCode = int.Parse(txtZipCode.Text);
                theEmployee.TaxID = int.Parse(txtTaxID.Text);
                theEmployee.ManagerID = int.Parse(txtManagerID.Text);
                theEmployee.DepartmentID = int.Parse(txtDepartmentID.Text);
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            Session["EmployeeRegistration"] = theEmployee;
            Response.Redirect("EmployeeConfirmation.aspx");
        }
    }
}