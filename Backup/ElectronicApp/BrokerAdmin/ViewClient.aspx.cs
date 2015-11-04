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
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace ElectronicApp.BrokerAdmin
{
    public partial class ViewClient : System.Web.UI.Page
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
                        if (Session["clid"] != null)
                        {
                            Guid myClientID = new Guid((String)Session["clid"]);

                            ElectronicAppDBDataContext electronicAppDB = new ElectronicAppDBDataContext();

                            uspGetClientByIDResult myClient = electronicAppDB.uspGetClientByID(myClientID).Single<uspGetClientByIDResult>();
                            uspGetClientContactResult myClientContact = electronicAppDB.uspGetClientContact(myClientID).Single<uspGetClientContactResult>();

                            if (myClient.OwnerID != myBrokerID)
                            {
                                Session.Abandon();
                                FormsAuthentication.SignOut();
                                Response.Redirect("~/Default.aspx?security=1", false);
                            }

                            header.InnerHtml = "<span class=\"red\">Client Applications</span> " + myClient.EmployerName;

                            BrokerName.InnerText = myClient.EmployerName;
                            BrokerPhone.InnerText = myClientContact.Phone;
                            BrokerAddress.InnerHtml = myClientContact.Address + "<br />" + myClientContact.City + ", " + myClientContact.state + " " + myClientContact.zip;
                            BrokerFax.InnerText = myClientContact.Fax;


                            List<uspGetSubmissionsByClientIDResult> mySubmissions = electronicAppDB.uspGetSubmissionsByClientID(myClient.ClientID).ToList<uspGetSubmissionsByClientIDResult>();
                            Boolean dark = false;
                            if (mySubmissions.Count <= 0)
                            {
                                HtmlTableRow newrow = new HtmlTableRow();
                                HtmlTableCell newcell = new HtmlTableCell();

                                newcell.InnerHtml = "There are no submissions to display.";
                                newrow.Cells.Add(newcell);
                                clients.Rows.Add(newrow);
                            }
                            else
                            {
                                HtmlTableRow row = new HtmlTableRow();

                                HtmlTableCell cell1 = new HtmlTableCell();
                                cell1.InnerHtml = "Date Submitted";
                                cell1.Attributes["Style"] = "border-bottom: 2px solid;";
                                cell1.BgColor = (dark) ? "#CCCCCC" : "#FFFFFF";
                                cell1.Width = "100px";

                                HtmlTableCell cell2 = new HtmlTableCell();
                                cell2.InnerHtml = "Enrollee Name";        
                                cell2.Attributes["Style"] = "border-bottom: 2px solid;";
                                cell2.BgColor = (dark) ? "#CCCCCC" : "#FFFFFF";
                                cell2.Width = "200px";

                                HtmlTableCell cell3 = new HtmlTableCell();
                                cell3.InnerHtml = "Birth Date";
                                cell3.Attributes["Style"] = "border-bottom: 2px solid;";
                                cell3.BgColor = (dark) ? "#CCCCCC" : "#FFFFFF";
                                cell3.Width = "100px";

                                row.Cells.Add(cell2);
                                row.Cells.Add(cell3);
                                row.Cells.Add(cell1);
                                clients.Rows.Add(row);
                                dark = !dark;

                                foreach (uspGetSubmissionsByClientIDResult submission in mySubmissions)
                                {
                                    HtmlTableRow newrow = new HtmlTableRow();

                                    HtmlTableCell newcell1 = new HtmlTableCell();
                                    newcell1.InnerHtml = submission.AddedDate.ToShortDateString();
                                    newcell1.BgColor = (dark) ? "#CCCCCC" : "#FFFFFF";
                                    HtmlTableCell newcell2 = new HtmlTableCell();

                                    uspGetEnrolleeByIDResult myEnrollee = electronicAppDB.uspGetEnrolleeByID(submission.OwnerID).Single<uspGetEnrolleeByIDResult>();
                                    newcell2.BgColor = (dark) ? "#CCCCCC" : "#FFFFFF";
                                    newcell2.InnerHtml = myEnrollee.FirstName + " " + myEnrollee.LastName;
                                    HtmlTableCell newcell3 = new HtmlTableCell();
                                    newcell3.BgColor = (dark) ? "#CCCCCC" : "#FFFFFF";
                                    newcell3.InnerHtml = myEnrollee.BirthDate;

                                    newrow.Cells.Add(newcell2);
                                    newrow.Cells.Add(newcell3);
                                    newrow.Cells.Add(newcell1);
                                    clients.Rows.Add(newrow);
                                    dark = !dark;
                                }
                            }
                        }
                        else
                        {
                            Session.Abandon();
                            FormsAuthentication.SignOut();
                            Response.Redirect("~/Default.aspx", false);
                        }
                    }
                    catch (Exception x)
                    {
                        Session.Abandon();
                        FormsAuthentication.SignOut();
                        Response.Redirect("~/Default.aspx", false);
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

        protected bool IsGUID(string expression)
        {
            if (expression != null)
            {
                Regex guidRegEx = new Regex(@"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$");

                return guidRegEx.IsMatch(expression);
            }
            return false;

            //Snatched from http://www.geekzilla.co.uk/view8AD536EF-BC0D-427F-9F15-3A1BC663848E.htm
        }
    }
}
