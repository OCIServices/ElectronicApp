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

namespace ElectronicApp
{
    public partial class Welcome : BasePage
    {
       // public string ClientName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ClientID"] != null)
                {
                    Guid myClientID = (Guid)Session["ClientID"];
                    try
                    {
                        ElectronicAppDBDataContext electronicAppDB = new ElectronicAppDBDataContext();
                        ElectronicAppStorageDBDataContext electronicAppStorageDB = new ElectronicAppStorageDBDataContext();
                        uspGetClientByIDResult myClient = electronicAppDB.uspGetClientByID(myClientID).Single<uspGetClientByIDResult>();
                        uspGetClientContactResult myClientContact = electronicAppDB.uspGetClientContact(myClient.ClientID).Single<uspGetClientContactResult>();
                        uspGetBrokerByIDResult myBroker = electronicAppDB.uspGetBrokerByID(myClient.OwnerID).Single<uspGetBrokerByIDResult>();
                        uspGetBrokerContactResult myBrokerInfo = electronicAppDB.uspGetBrokerContact(myBroker.BrokerID).Single<uspGetBrokerContactResult>();
                        string ClientName = myClient.EmployerName;


                        uspGetBrokerByIDResult broker = electronicAppDB.uspGetBrokerByID(myClient.OwnerID).Single<uspGetBrokerByIDResult>();

                        System.Collections.Generic.List<uspGetBrokerImageByOwnerIDResult> searches = electronicAppStorageDB.uspGetBrokerImageByOwnerID(broker.BrokerID).ToList<uspGetBrokerImageByOwnerIDResult>();

                        bool hasImage = searches.Count > 0;

                        if (hasImage)
                        {
                            Image1.ImageUrl = "/BrokerImages/Broker.ashx?id=" + broker.BrokerID.ToString();
                        }


                        header.InnerHtml = "<span class=\"red\">Welcome</span> " + ClientName;
                        BrokerName.InnerHtml = myBroker.FirstName + " " + myBroker.LastName;
                        BrokerEmail.InnerHtml = myBrokerInfo.Email;
                        BrokerPhone.InnerHtml = myBrokerInfo.PhoneNumber;
                        BrokerFax.InnerHtml = myBrokerInfo.Fax;
                        BrokerAddress.InnerHtml = myBrokerInfo.Address;
                        BrokerAddress2.InnerHtml = myBrokerInfo.City + ", " + myBrokerInfo.State + " " + myBrokerInfo.Zip;
                     
                        Session.Add("Client", myClient);
                        //ClientName = electronicAppDB.uspGetBrokerByID(myClient.OwnerID).Single<uspGetBrokerByIDResult>().
                    }
                    catch (Exception ex)
                    {
                        Session.Abandon();
                        FormsAuthentication.SignOut();
                        Response.Redirect("Default.aspx", false);
                    }
                }

                else if (Session["BrokerID"] != null)
                {
                    Response.Redirect("~/BrokerAdmin/Welcome.aspx", true);
                }

                else
                {
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("Default.aspx", false);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/NebraskaApp/BasicInformation.aspx", false);
            Response.Redirect("~/NebraskaApp/Wizard.aspx", false);
        }
    }
}
