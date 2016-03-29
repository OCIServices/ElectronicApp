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
    public partial class GroupAdd : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            ElectronicAppDBDataContext eappdb = new ElectronicAppDBDataContext();

            foreach ( uspGetCarrierOptionsResult carrier in eappdb.uspGetCarrierOptions() )
            {
                lstAvail.Items.Add(new ListItem(carrier.Name));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ( Session["BrokerID"] == null && !IsPostBack )
            {
                Session.Abandon();
                FormsAuthentication.SignOut();
                Response.Redirect("Default.aspx", false);
            }
        
        }

        protected void btnAddSel_Click(object sender, EventArgs e)
        {
            try
            {
                lstSel.SelectedIndex = -1;
                lstSel.Items.Add(lstAvail.SelectedItem);
                lstAvail.Items.Remove(lstAvail.SelectedItem);
                lstAvail.SelectedIndex = -1;
                lstSel.SelectedIndex = -1;

                if (lstSel.Items.Count == 6)
                {
                    btnAddSel.Enabled = false;
                }
                else
                {
                    btnAddSel.Enabled = true;
                }

                if (lstSel.Items.Count == 0)
                {
                    btnRemoveSel.Enabled = false;
                }

                else
                {
                    btnRemoveSel.Enabled = true;
                }
            }
            catch (NullReferenceException nre){}
        }

        protected void btnRemoveSel_Click(object sender, EventArgs e)
        {
            try
            {
                lstAvail.SelectedIndex = -1;
                lstAvail.Items.Add(lstSel.SelectedItem);
                lstSel.Items.Remove(lstSel.SelectedItem);
                lstAvail.SelectedIndex = -1;
                lstSel.SelectedIndex = -1;

                if (lstSel.Items.Count == 0)
                {
                    btnRemoveSel.Enabled = false;
                }

                else
                {
                    btnRemoveSel.Enabled = true;
                }

                if (lstSel.Items.Count == 6)
                {
                    btnAddSel.Enabled = false;
                }
                else
                {
                    btnAddSel.Enabled = true;
                }
            }
            catch (NullReferenceException nre) {/*Don't do anything for a null exception..*/ }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ElectronicAppDBDataContext eappdb = new ElectronicAppDBDataContext();
            ElectronicAppSecurityDBDataContext eappsec = new ElectronicAppSecurityDBDataContext();
            int countErrors = 0;

            //Check password length and equality.
            if (!txtPassword.Text.Equals(txtPassword2.Text) || txtPassword.Text.Length < 4 || txtLogin.Text.Equals(""))
            {
                lblErrorCredentials.Visible = true;
                lblErrorCredentials.Text = "Username or password is invalid, or passwords do not match.";
                countErrors++;
            }

            else
            {
                lblErrorCredentials.Visible = false;
            }

            if (eappsec.uspCheckUsername(txtLogin.Text).ToList<uspCheckUsernameResult>().Count > 0)
            {
                lblErrorTaken.Visible = true;
                lblErrorTaken.Text = "Please choose a different username, the one you provided is in use.";
                countErrors++;
            }
            else
            {
                lblErrorTaken.Visible = false;
            }

            //Check calendar range.
            if (!(calBeginPeriod.SelectedDate.CompareTo(calEndPeriod.SelectedDate) < 0))
            {
                lblErrorCals.Visible = true;
                lblErrorCals.Text = "The enrollment period must be a vaild date range.";
                countErrors++;
            }

            else
            {
                lblErrorCals.Visible = false;
            }

            //Check carrier list for null.
            if (lstSel.Items.Count <= 0)
            {
                lblErrorCarriers.Visible = true;
                lblErrorCarriers.Text = "Please select at least one, and as many as six carriers.";
                countErrors++;
            }
            else
            {
                lblErrorCarriers.Visible = false;
            }

            //Check coverage requirements.
            if (!chkDental.Checked && !chkDisability.Checked && !chkLife.Checked && !chkMedical.Checked && !chkVision.Checked)
            {
                lblErrorCoverages.Visible = true;
                lblErrorCoverages.Text = "Please select at least one type of coverage.";
                countErrors++;
            }
            else
            {
                lblErrorCoverages.Visible = false;
            }

            //Check Contact Details
            if ( txtAddress.Text.Equals("") || txtCity.Equals("") || txtFax.Equals("") || txtGroupName.Equals("") || txtPhone.Equals("") || txtState.Equals("") || txtZip.Equals("") )
            {
                lblErrorContactInfo.Visible = true;
                lblErrorContactInfo.Text = "Please fill in the contact information.";
                countErrors++;
            }
            else
            {
                lblErrorContactInfo.Visible = false;
            }

            //Finally, submit if no fatal errors occured.
            if (countErrors == 0)
            {
                //Submit form, process.
                Guid myNewClient = System.Guid.NewGuid();

                //Insert client record and contact.
                eappdb.uspInsertClient( myNewClient, (Guid)(Session["BrokerID"]), txtGroupName.Text, txtTaxID.Text);
                eappdb.uspInsertClientInfo(System.Guid.NewGuid(), myNewClient, txtPhone.Text, txtFax.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text);

                //Insert client coverage options
                eappdb.uspInsertClientOptions( System.Guid.NewGuid(), myNewClient, chkMedical.Checked, chkDental.Checked, chkLife.Checked, chkVision.Checked,chkDisability.Checked);

                //Insert client carriers
                foreach ( ListItem li in lstSel.Items )
                {
                    eappdb.uspInsertClientCarrier( System.Guid.NewGuid(), myNewClient, li.Text.ToUpper() );
                }

                //Add the web user
                eappsec.uspInsertWebUser(System.Guid.NewGuid(), myNewClient, txtLogin.Text, txtPassword.Text);

                //Redirect the user to the home page with query string.
                Response.Redirect("~/BrokerAdmin/Welcome.aspx", true);


            }

        }
    }
}
