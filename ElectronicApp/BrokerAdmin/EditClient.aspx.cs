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
            if (!base.IsPostBack)
            {
                Guid guid = new Guid((string)this.Session["clid"]);
                uspGetClientByIDResult result = this.eappdb.uspGetClientByID(new Guid?(guid)).Single<uspGetClientByIDResult>();
                uspGetClientContactResult result2 = this.eappdb.uspGetClientContact(new Guid?(guid)).Single<uspGetClientContactResult>();
                this.BrokerFirstName.Text = result.EmployerName;
                this.TaxID.Text = result.TaxID;
                this.BrokerPhone.Text = result2.Phone;
                this.BrokerFax.Text = result2.Fax;
                this.BrokerAddress.Text = result2.Address;
                this.BrokerCity.Text = result2.City;
                this.BrokerState.Text = result2.state;
                this.BrokerZip.Text = result2.zip;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Cancel Button Clicked
            base.Response.Redirect("~/BrokerAdmin/ViewClient.aspx", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Guid guid = new Guid((string)this.Session["clid"]);
            this.eappdb.uspAlterClientInfo(new Guid?(guid), this.BrokerFirstName.Text, this.TaxID.Text, this.BrokerPhone.Text, this.BrokerFax.Text, this.BrokerAddress.Text, this.BrokerCity.Text, this.BrokerState.Text, this.BrokerZip.Text);
            base.Response.Redirect("~/BrokerAdmin/ViewClient.aspx", true);
        }
    }
}
