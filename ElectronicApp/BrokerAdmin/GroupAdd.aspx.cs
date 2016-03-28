using ElectronicApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ElectronicApp.BrokerAdmin
{
    public partial class GroupAdd : Page
    {
        protected Label errorEligible;
        protected RegularExpressionValidator RegularExpressionValidator1;
        protected TextBox txtEligible;
        protected void Page_Init(object sender, EventArgs e)
        {
            //ElectronicAppDBDataContext eappdb = new ElectronicAppDBDataContext();

            List<uspGetCarrierOptionsResult> list = new ElectronicAppDBDataContext().uspGetCarrierOptions().ToList();
            foreach (uspGetCarrierOptionsResult carrier in list)
            {
                lstAvail.Items.Add(new ListItem(carrier.Name.ToUpper()));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!((Session["BrokerID"] != null) || IsPostBack))
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
            catch (NullReferenceException){}
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
            catch (NullReferenceException) {/*Don't do anything for a null exception..*/ }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ElectronicAppDBDataContext eappdb = new ElectronicAppDBDataContext();
            ElectronicAppSecurityDBDataContext eappsec = new ElectronicAppSecurityDBDataContext();
            uspGetBrokerByIDResult result = eappdb.uspGetBrokerByID(new Guid?((Guid)Session["BrokerID"])).Single();
            uspGetBrokerContactResult result2 = eappdb.uspGetBrokerContact(new Guid?(result.BrokerID)).Single();
            int countErrors = 0;

            //Check password length and equality.
            if ((!txtPassword.Text.Equals(txtPassword2.Text) || (txtPassword.Text.Length < 4)) || txtLogin.Text.Equals(""))
            {
                lblErrorCredentials.Visible = true;
                lblErrorCredentials.Text = "Username or password is invalid, or passwords do not match.";
                countErrors++;
            }

            else
            {
                lblErrorCredentials.Visible = false;
            }

            if (eappsec.uspCheckUsername(txtLogin.Text).ToList().Count > 0)
            {
                lblErrorTaken.Visible = true;
                lblErrorTaken.Text = "Please choose a different username, the one you provided is in use.";
                countErrors++;
            }
            else
            {
                lblErrorTaken.Visible = false;
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
            if (!(((chkDental.Checked || chkDisability.Checked) || (chkLife.Checked || chkMedical.Checked)) || chkVision.Checked))
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
            if ((((txtAddress.Text.Equals("") || txtCity.Equals("")) || (txtFax.Equals("") || txtGroupName.Equals(""))) || (txtPhone.Equals("") || txtState.Equals(""))) || txtZip.Equals(""))
            {
                lblErrorContactInfo.Visible = true;
                lblErrorContactInfo.Text = "Please fill in the contact information.";
                countErrors++;
            }
            else
            {
                lblErrorContactInfo.Visible = false;
            }
            if (this.txtEligible.Text.Equals(""))
            {
                this.errorEligible.Visible = true;
                countErrors++;
            }
            else
            {
                this.errorEligible.Visible = false;
            }

            //Finally, submit if no fatal errors occured.
            //if (countErrors == 0)
            //{
            //    //Submit form, process.
            //    Guid myNewClient = System.Guid.NewGuid();

            //    //Insert client record and contact.
            //    eappdb.uspInsertClient(myNewClient, (Guid)(Session["BrokerID"]), txtGroupName.Text, txtTaxID.Text);
            //    eappdb.uspInsertClientInfo(System.Guid.NewGuid(), myNewClient, txtPhone.Text, txtFax.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text);

            //    //Insert client coverage options
            //    eappdb.uspInsertClientOptions(System.Guid.NewGuid(), myNewClient, chkMedical.Checked, chkDental.Checked, chkLife.Checked, chkVision.Checked, chkDisability.Checked);

            //    //Insert client carriers
            //    foreach (ListItem li in lstSel.Items)
            //    {
            //        eappdb.uspInsertClientCarrier(System.Guid.NewGuid(), myNewClient, li.Text.ToUpper());
            //    }

            //    //Add the web user
            //    eappsec.uspInsertWebUser(System.Guid.NewGuid(), myNewClient, txtLogin.Text, txtPassword.Text);

            //    //Redirect the user to the home page with query string.
            //    Response.Redirect("~/BrokerAdmin/Welcome.aspx", true);


            //}
            if (countErrors == 0)
            {
                Guid guid = Guid.NewGuid();
                StringBuilder builder = new StringBuilder();
                MailAddressCollection addresss = new MailAddressCollection();
                addresss.Add("helpdesk@ociservices.com");
                addresss.Add(result2.Email);
                string str = "IEnrollNotifications@ociservices.com";
                string str2 = "New Enrollment For " + this.txtGroupName.Text;
                builder.AppendLine("Broker Name: " + result.LastName + ", " + result.FirstName);
                builder.AppendLine("Client Name: " + this.txtGroupName.Text);
                builder.AppendLine("Link: https://ienroll.ociservices.com");
                builder.AppendLine("Client Address: " + this.txtAddress.Text.ToString());
                builder.AppendLine(this.txtCity.Text.ToString() + ", " + this.txtState.Text.ToString() + " " + this.txtZip.Text.ToString());
                builder.AppendLine("Client TaxID: " + this.txtTaxID.Text);
                builder.AppendLine();
                builder.AppendLine("Number of Eligible Employees: " + this.txtEligible.Text);
                builder.AppendLine();
                builder.AppendLine("Requested Coverage Types:");
                if (this.chkMedical.Checked)
                {
                    builder.AppendLine("Medical");
                }
                if (this.chkDental.Checked)
                {
                    builder.AppendLine("Dental");
                }
                if (this.chkVision.Checked)
                {
                    builder.AppendLine("Vision");
                }
                if (this.chkLife.Checked)
                {
                    builder.AppendLine("Life");
                }
                if (this.chkDisability.Checked)
                {
                    builder.AppendLine("Disability");
                }
                builder.AppendLine();
                builder.AppendLine("Client Login Info:");
                builder.AppendLine("UserName: " + this.txtLogin.Text);
                builder.AppendLine("Password: " + this.txtPassword.Text);
                MailMessage message = new MailMessage(str, "groupsubmissions@ociservices.com", str2, builder.ToString());
                if (!(result2.Email.Equals("") || (result2.Email == null)))
                {
                    message.To.Add(result2.Email);
                }
                message.To.Add("ocihelpdesk@ociservices.com");
                new SmtpClient("smarthost.coxmail.com").Send(message);
                eappdb.uspInsertClient(new Guid?(guid), new Guid?((Guid)this.Session["BrokerID"]), this.txtGroupName.Text, this.txtTaxID.Text, new int?(int.Parse(this.txtEligible.Text)));
                eappdb.uspInsertClientInfo(new Guid?(Guid.NewGuid()), new Guid?(guid), this.txtPhone.Text, this.txtFax.Text, this.txtAddress.Text, this.txtCity.Text, this.txtState.Text, this.txtZip.Text);
                eappdb.uspInsertClientOptions(new Guid?(Guid.NewGuid()), new Guid?(guid), new bool?(this.chkMedical.Checked), new bool?(this.chkDental.Checked), new bool?(this.chkLife.Checked), new bool?(this.chkVision.Checked), new bool?(this.chkDisability.Checked));
                foreach (ListItem item in this.lstSel.Items)
                {
                    eappdb.uspInsertClientCarrier(new Guid?(Guid.NewGuid()), new Guid?(guid), item.Text.ToUpper());
                }
                eappsec.uspInsertWebUser(new Guid?(Guid.NewGuid()), new Guid?(guid), this.txtLogin.Text, this.txtPassword.Text);
                base.Response.Redirect("~/BrokerAdmin/Welcome.aspx?new=true&user=" + guid.ToString(), true);
            }
        }
    }
}
