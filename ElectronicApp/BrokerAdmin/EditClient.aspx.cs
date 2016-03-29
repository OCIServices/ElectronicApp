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

namespace ElectronicApp.BrokerAdmin
{
    public partial class EditClient : System.Web.UI.Page
    {
        ElectronicAppDBDataContext eappdb = new ElectronicAppDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Guid myClientID = new Guid((String)(Session["clid"]));

                uspGetClientByIDResult myClient = eappdb.uspGetClientByID(myClientID).Single<uspGetClientByIDResult>();
                uspGetClientContactResult myClientContact = eappdb.uspGetClientContact(myClientID).Single<uspGetClientContactResult>();

                BrokerFirstName.Text = myClient.EmployerName;
                TaxID.Text = myClient.TaxID;
                BrokerPhone.Text = myClientContact.Phone;
                BrokerFax.Text = myClientContact.Fax;
                BrokerAddress.Text = myClientContact.Address;
                BrokerCity.Text = myClientContact.City;
                BrokerState.Text = myClientContact.state;
                BrokerZip.Text = myClientContact.zip;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Cancel Button Clicked
            Response.Redirect("~/BrokerAdmin/ViewClient.aspx", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Guid clientID = new Guid((String)(Session["clid"]));

            //Update Button Clicked
            //Save Information
            eappdb.uspAlterClientInfo(clientID, BrokerFirstName.Text, TaxID.Text, BrokerPhone.Text, BrokerFax.Text, BrokerAddress.Text, BrokerCity.Text, BrokerState.Text, BrokerZip.Text);

            //Redirect to client page.
            Response.Redirect("~/BrokerAdmin/ViewClient.aspx", true);
        }
    }
}
