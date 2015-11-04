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

namespace ElectronicApp
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ReturnUrl"] != null)
            {
                Response.Redirect("Default.aspx", false);
            }
            if (Request.QueryString["InvalidLogin"] != null)
            {
                lblMessage.Text = "*Invalid Login";
                lblMessage.Visible = true;
            }
            else if (Request.QueryString["timeout"] != null)
            {
                lblMessage.Text = "*Session Timeout";
                lblMessage.Visible = true;
            }

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ElectronicAppDBDataContext ElectronicAppDB = new ElectronicAppDBDataContext();
            ElectronicAppSecurityDBDataContext ElectronicAppSecurityDB = new ElectronicAppSecurityDBDataContext();
            List<uspLoginWebuserResult> Loginresult = null;
            Loginresult = ElectronicAppSecurityDB.uspLoginWebuser(txtUserName.Text, txtPassword.Text).ToList<uspLoginWebuserResult>();
            if (Loginresult.Count <= 0)
            {
                List<uspLoginBrokeruserResult> brokerresult = null;
                brokerresult = ElectronicAppSecurityDB.uspLoginBrokeruser(txtUserName.Text, txtPassword.Text).ToList<uspLoginBrokeruserResult>();
                if (brokerresult.Count > 0)
                {
                    Guid brokerID = brokerresult[0].associatedWith;

                    Session.Add("BrokerID", brokerID);

                    FormsAuthentication.RedirectFromLoginPage("txtUserName.Text", false);
                }

                else
                {
                    Response.Redirect("~/Default.aspx?InvalidLogin=1", true);
                }
            }
            else
            {
                try
                {
                    Guid myClientID = Loginresult[0].AssociatedWith;
                    uspGetClientByIDResult myClient = ElectronicAppDB.uspGetClientByID(myClientID).Single<uspGetClientByIDResult>();
                    uspGetClientCoverageOptionsResult myCoverageOptions = ElectronicAppDB.uspGetClientCoverageOptions(myClientID).Single<uspGetClientCoverageOptionsResult>();
                    List<uspGetClientPlanOptionsResult> myPlanOptions = ElectronicAppDB.uspGetClientPlanOptions(myClientID).ToList<uspGetClientPlanOptionsResult>();
                    
                    string[] myPlans = new string[myPlanOptions.Count];
                    int i = 0;
                    foreach (uspGetClientPlanOptionsResult po in myPlanOptions)
                    {
                        myPlans[i] = po.PlanName;
                        i = i+1;
                    }

                    coverageOffered myCoverageOffered = new coverageOffered(myPlans, myCoverageOptions.Medical, myCoverageOptions.Dental, myCoverageOptions.Vision, myCoverageOptions.Life, myCoverageOptions.Disability);
                    
                    Session.Add("CoverageOffered", myCoverageOffered);
                    Session.Add("UserID", Guid.NewGuid());
                    Session.Add("ClientID", myClientID);
                    //Response.Redirect("~/Welcome.aspx", false);
                    FormsAuthentication.RedirectFromLoginPage("txtUserName.Text", false);

                }
                catch( Exception ex )
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.InnerException);
                   Response.Redirect("~/Default.aspx?Exception=1", true);
                }
            }
        }
    }
}
