using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ElectronicApp.Supporting_Classes;
using System.Collections.Generic;

namespace ElectronicApp.NebraskaApp
{
    public partial class BasicInformation : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnNext.Attributes.Add("onClick", "return valSubmit();");
            if (Session["ClientID"] == null && Session["UserID"] == null)
            {
                Response.Redirect("~/Default.aspx?timeout=1");
            }           
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ClientID"] == null && Session["UserID"] == null)
                {
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Default.aspx?timeout=1");
                }
                else
                {
                    Guid ClientID = (Guid) Session["ClientID"];
                    Guid UserID = (Guid) Session["UserID"];
                    ElectronicAppDBDataContext eappdata = new ElectronicAppDBDataContext();
                    //eappdata.uspDoesEnrolleeExist(ClientID, txtFirstName, txtLastName, txtBirthDate);
                    List<uspDoesEnrolleeExistResult> myResult = eappdata.uspDoesEnrolleeExist(ClientID, txtFirstName.Text, txtLastName.Text, txtMonth.Text + "/" + txtDay.Text + "/" + txtYear.Text).ToList<uspDoesEnrolleeExistResult>();
                    if (myResult.Count> 0)
                    {
                        Session["UserID"] = myResult[0].EnrolleeID;
                    }
                    else
                    {
                        eappdata.uspInsertEnrollee(UserID, ClientID, txtFirstName.Text, txtLastName.Text, txtMonth.Text + "/" + txtDay.Text + "/" + txtYear.Text, false, Request.UserHostAddress.ToString());
                    }

                    employeeData myData = new employeeData();
                    myData.EmployeeName = txtFirstName.Text + " " + txtLastName.Text;
                    myData.DOB = txtMonth.Text + "/" + txtDay.Text + "/" + txtYear.Text;
         
                    if (cmbWaive.Text.Equals("Yes", StringComparison.CurrentCultureIgnoreCase))
                    {
                        myData.WaiveAll = true;
                        Session.Add("EmployeeData", myData);
                        Response.Redirect("CoverageSelection.aspx", false);
                    }
                    else
                    {
                        myData.WaiveAll = false;
                        Session.Add("EmployeeData", myData);
                        Response.Redirect("EmployeeData.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Abandon();
                FormsAuthentication.SignOut();
                Response.Redirect("Default.aspx", false);
            }
        }
    }
}
