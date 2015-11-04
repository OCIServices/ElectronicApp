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
using System.Collections.Generic;

namespace ElectronicApp.BrokerAdmin
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["BrokerID"] != null)
                {
                    Guid myBrokerID = (Guid)Session["BrokerID"];
                    try
                    {
                        ElectronicAppDBDataContext electronicAppDB = new ElectronicAppDBDataContext();
                        uspGetBrokerByIDResult myBroker = electronicAppDB.uspGetBrokerByID(myBrokerID).Single<uspGetBrokerByIDResult>();
                        uspGetBrokerContactResult myBrokerInfo = electronicAppDB.uspGetBrokerContact(myBroker.BrokerID).Single<uspGetBrokerContactResult>();

                        //string ClientName = myClient.EmployerName;
                        header.InnerHtml = "<span class=\"red\">Welcome, </span> " + myBroker.FirstName + " " + myBroker.LastName;
                        BrokerName.InnerHtml = myBroker.FirstName + " " + myBroker.LastName;
                        BrokerEmail.InnerHtml = myBrokerInfo.Email;
                        BrokerPhone.InnerHtml = myBrokerInfo.PhoneNumber;
                        BrokerFax.InnerHtml = myBrokerInfo.Fax;
                        BrokerAddress.InnerHtml = myBrokerInfo.Address + "<br />" + myBrokerInfo.City + " " + myBrokerInfo.State + ", " + myBrokerInfo.Zip;

                        ElectronicAppStorageDBDataContext eappstor = new ElectronicAppStorageDBDataContext();


                        System.Collections.Generic.List<uspGetBrokerImageByOwnerIDResult> searches = eappstor.uspGetBrokerImageByOwnerID(myBroker.BrokerID).ToList<uspGetBrokerImageByOwnerIDResult>();

                        bool hasImage = searches.Count > 0;

                        if (hasImage)
                        {
                            Image1.ImageUrl = "/BrokerImages/Broker.ashx?id=" + myBrokerID.ToString();
                        }

                        List<uspGetClientListByOwnerIDResult> myClients = electronicAppDB.uspGetClientListByOwnerID(myBrokerID).ToList<uspGetClientListByOwnerIDResult>();
                        
                        ListItem s = new ListItem("(Select)","na");
                        DropDownList1.Items.Add(s);

                        foreach (uspGetClientListByOwnerIDResult client in myClients)
                        {
                            ListItem newitem = new ListItem((String)client.EmployerName, client.ClientID.ToString());
                            DropDownList1.Items.Add(newitem);
                        }

                        



                        //Session.Add("Client", myClient);
                        //ClientName = electronicAppDB.uspGetBrokerByID(myClient.OwnerID).Single<uspGetBrokerByIDResult>().
                    }
                    catch (Exception ex)
                    {
                        Session.Abandon();
                        FormsAuthentication.SignOut();
                        Response.Redirect("Default.aspx", false);
                    }
                }
                else
                {
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Default.aspx", false);
                }
            }
        }

        public void DropDownList1_SelectedIndexChanged( object sender, EventArgs e )
        {
            Session.Add("clid", DropDownList1.SelectedItem.Value);
            Response.Redirect("~/BrokerAdmin/ViewClient.aspx");
        }
    }

    
}
