using ElectronicApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ElectronicApp.BrokerAdmin
{
    public partial class ViewClient : Page
    {

        protected bool IsGUID(string expression)
        {
            if (expression != null)
            {
                Regex regex = new Regex(@"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$");
                return regex.IsMatch(expression);
            }
            return false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack || base.IsPostBack)
            {
                if (this.Session["BrokerID"] != null)
                {
                    Guid guid = (Guid)this.Session["BrokerID"];
                    try
                    {
                        if (this.Session["clid"] != null)
                        {
                            HtmlTableRow row;
                            Guid guid2 = new Guid((string)this.Session["clid"]);
                            ElectronicAppDBDataContext context = new ElectronicAppDBDataContext();
                            uspGetClientByIDResult result = context.uspGetClientByID(new Guid?(guid2)).Single<uspGetClientByIDResult>();
                            uspGetClientContactResult result2 = context.uspGetClientContact(new Guid?(guid2)).Single<uspGetClientContactResult>();
                            if (result.OwnerID != guid)
                            {
                                this.Session.Abandon();
                                FormsAuthentication.SignOut();
                                base.Response.Redirect("~/Default.aspx?security=1", false);
                            }
                            this.header.InnerHtml = "<span class=\"red\">Client Applications</span> " + result.EmployerName;
                            this.BrokerName.InnerText = result.EmployerName;
                            this.BrokerPhone.InnerText = result2.Phone;
                            this.BrokerAddress.InnerHtml = result2.Address + "<br />" + result2.City + ", " + result2.state + " " + result2.zip;
                            this.BrokerFax.InnerText = result2.Fax;
                            List<uspGetSubmissionsByClientIDBrokerViewResult> list = context.uspGetSubmissionsByClientIDBrokerView(new Guid?(result.ClientID)).ToList<uspGetSubmissionsByClientIDBrokerViewResult>();
                            bool flag = false;
                            if (list.Count <= 0)
                            {
                                row = new HtmlTableRow();
                                HtmlTableCell cell = new HtmlTableCell();
                                this.lblsubcount.Text = "0";
                                cell.InnerHtml = "There are no submissions to display.";
                                row.Cells.Add(cell);
                                this.clients.Rows.Add(row);
                            }
                            else
                            {
                                HtmlTableRow row2;
                                HtmlTableCell cell2;
                                HtmlTableCell cell3;
                                HtmlTableCell cell4;
                                HtmlTableCell cell5;
                                HtmlTableCell cell6;
                                HtmlTableCell cell7;
                                this.lblsubcount.Text = list.Count.ToString();
                                string str = base.Request.QueryString["sortby"];
                                switch (str)
                                {
                                    case null:
                                    case "":
                                        list = (from x in list
                                                orderby x.firstname
                                                orderby x.lastname
                                                orderby x.addeddate descending
                                                select x).ToList<uspGetSubmissionsByClientIDBrokerViewResult>();
                                        row2 = new HtmlTableRow();
                                        cell2 = new HtmlTableCell
                                        {
                                            InnerHtml = "<a style=\"font-size:14px; font-weight: bold;\" href=\"ViewClient.aspx?sortby=submissiondate\">Date Submitted</a>"
                                        };
                                        cell2.Attributes["Style"] = "border-bottom: 2px solid;";
                                        cell2.BgColor = flag ? "#CCCCCC" : "#FFFFFF";
                                        cell2.Width = "130px";
                                        cell3 = new HtmlTableCell
                                        {
                                            InnerHtml = "<a style=\"font-size:14px; font-weight: bold;\" href=\"ViewClient.aspx?sortby=employee\">Enrollee Name</a>"
                                        };
                                        cell3.Attributes["Style"] = "border-bottom: 2px solid;";
                                        cell3.BgColor = flag ? "#CCCCCC" : "#FFFFFF";
                                        cell3.Width = "200px";
                                        cell4 = new HtmlTableCell
                                        {
                                            InnerHtml = "<a style=\"font-size:14px; font-weight: bold;\" href=\"ViewClient.aspx?sortby=birthdate\">Birth Date</a>"
                                        };
                                        cell4.Attributes["Style"] = "border-bottom: 2px solid;";
                                        cell4.BgColor = flag ? "#CCCCCC" : "#FFFFFF";
                                        cell4.Width = "100px";
                                        row2.Cells.Add(cell3);
                                        row2.Cells.Add(cell4);
                                        row2.Cells.Add(cell2);
                                        this.clients.Rows.Add(row2);
                                        flag = !flag;
                                        foreach (uspGetSubmissionsByClientIDBrokerViewResult result3 in list)
                                        {
                                            row = new HtmlTableRow();
                                            cell5 = new HtmlTableCell
                                            {
                                                InnerHtml = result3.addeddate.Value.ToShortDateString(),
                                                BgColor = flag ? "#CCCCCC" : "#FFFFFF"
                                            };
                                            cell6 = new HtmlTableCell
                                            {
                                                BgColor = flag ? "#CCCCCC" : "#FFFFFF",
                                                InnerHtml = result3.lastname + ", " + result3.firstname
                                            };
                                            cell7 = new HtmlTableCell
                                            {
                                                BgColor = flag ? "#CCCCCC" : "#FFFFFF",
                                                InnerHtml = result3.birthdate
                                            };
                                            row.Cells.Add(cell6);
                                            row.Cells.Add(cell7);
                                            row.Cells.Add(cell5);
                                            this.clients.Rows.Add(row);
                                            flag = !flag;
                                        }
                                        return;
                                }
                                if (str == "employee")
                                {
                                    list = (from x in list
                                            orderby x.firstname
                                            orderby x.lastname
                                            select x).ToList<uspGetSubmissionsByClientIDBrokerViewResult>();
                                    row2 = new HtmlTableRow();
                                    cell2 = new HtmlTableCell
                                    {
                                        InnerHtml = "<a style=\"font-size:14px; font-weight: bold;\"  href=\"ViewClient.aspx?sortby=submissiondate\">Date Submitted</a>"
                                    };
                                    cell2.Attributes["Style"] = "border-bottom: 2px solid;";
                                    cell2.BgColor = flag ? "#CCCCCC" : "#FFFFFF";
                                    cell2.Width = "130px";
                                    cell3 = new HtmlTableCell
                                    {
                                        InnerHtml = "<a style=\"font-size:14px; font-weight: bold;\" href=\"ViewClient.aspx?sortby=employee\">Enrollee Name</a>"
                                    };
                                    cell3.Attributes["Style"] = "border-bottom: 2px solid;";
                                    cell3.BgColor = flag ? "#CCCCCC" : "#FFFFFF";
                                    cell3.Width = "200px";
                                    cell4 = new HtmlTableCell
                                    {
                                        InnerHtml = "<a style=\"font-size:14px; font-weight: bold;\" href=\"ViewClient.aspx?sortby=birthdate\">Birth Date</a>"
                                    };
                                    cell4.Attributes["Style"] = "border-bottom: 2px solid;";
                                    cell4.BgColor = flag ? "#CCCCCC" : "#FFFFFF";
                                    cell4.Width = "100px";
                                    row2.Cells.Add(cell3);
                                    row2.Cells.Add(cell4);
                                    row2.Cells.Add(cell2);
                                    this.clients.Rows.Add(row2);
                                    flag = !flag;
                                    foreach (uspGetSubmissionsByClientIDBrokerViewResult result3 in list)
                                    {
                                        row = new HtmlTableRow();
                                        cell5 = new HtmlTableCell
                                        {
                                            InnerHtml = result3.addeddate.Value.ToShortDateString(),
                                            BgColor = flag ? "#CCCCCC" : "#FFFFFF"
                                        };
                                        cell6 = new HtmlTableCell
                                        {
                                            BgColor = flag ? "#CCCCCC" : "#FFFFFF",
                                            InnerHtml = result3.lastname + ", " + result3.firstname
                                        };
                                        cell7 = new HtmlTableCell
                                        {
                                            BgColor = flag ? "#CCCCCC" : "#FFFFFF",
                                            InnerHtml = result3.birthdate
                                        };
                                        row.Cells.Add(cell6);
                                        row.Cells.Add(cell7);
                                        row.Cells.Add(cell5);
                                        this.clients.Rows.Add(row);
                                        flag = !flag;
                                    }
                                }
                                else if (str == "submissiondate")
                                {
                                    list = (from x in list
                                            orderby x.firstname
                                            orderby x.lastname
                                            orderby x.addeddate descending
                                            select x).ToList<uspGetSubmissionsByClientIDBrokerViewResult>();
                                    row2 = new HtmlTableRow();
                                    cell2 = new HtmlTableCell
                                    {
                                        InnerHtml = "<a style=\"font-size:14px; font-weight: bold;\" href=\"ViewClient.aspx?sortby=submissiondate\">Date Submitted</a>"
                                    };
                                    cell2.Attributes["Style"] = "border-bottom: 2px solid;";
                                    cell2.BgColor = flag ? "#CCCCCC" : "#FFFFFF";
                                    cell2.Width = "130px";
                                    cell3 = new HtmlTableCell
                                    {
                                        InnerHtml = "<a style=\"font-size:14px; font-weight: bold;\" href=\"ViewClient.aspx?sortby=employee\">Enrollee Name</a>"
                                    };
                                    cell3.Attributes["Style"] = "border-bottom: 2px solid;";
                                    cell3.BgColor = flag ? "#CCCCCC" : "#FFFFFF";
                                    cell3.Width = "200px";
                                    cell4 = new HtmlTableCell
                                    {
                                        InnerHtml = "<a style=\"font-size:14px; font-weight: bold;\" href=\"ViewClient.aspx?sortby=birthdate\">Birth Date</a>"
                                    };
                                    cell4.Attributes["Style"] = "border-bottom: 2px solid;";
                                    cell4.BgColor = flag ? "#CCCCCC" : "#FFFFFF";
                                    cell4.Width = "100px";
                                    row2.Cells.Add(cell3);
                                    row2.Cells.Add(cell4);
                                    row2.Cells.Add(cell2);
                                    this.clients.Rows.Add(row2);
                                    flag = !flag;
                                    foreach (uspGetSubmissionsByClientIDBrokerViewResult result3 in list)
                                    {
                                        row = new HtmlTableRow();
                                        cell5 = new HtmlTableCell
                                        {
                                            InnerHtml = result3.addeddate.Value.ToShortDateString(),
                                            BgColor = flag ? "#CCCCCC" : "#FFFFFF"
                                        };
                                        cell6 = new HtmlTableCell
                                        {
                                            BgColor = flag ? "#CCCCCC" : "#FFFFFF",
                                            InnerHtml = result3.lastname + ", " + result3.firstname
                                        };
                                        cell7 = new HtmlTableCell
                                        {
                                            BgColor = flag ? "#CCCCCC" : "#FFFFFF",
                                            InnerHtml = result3.birthdate
                                        };
                                        row.Cells.Add(cell6);
                                        row.Cells.Add(cell7);
                                        row.Cells.Add(cell5);
                                        this.clients.Rows.Add(row);
                                        flag = !flag;
                                    }
                                }
                                else if (str == "birthdate")
                                {
                                    list = (from x in list
                                            orderby x.firstname
                                            orderby x.lastname
                                            orderby x.birthdate descending
                                            select x).ToList<uspGetSubmissionsByClientIDBrokerViewResult>();
                                    row2 = new HtmlTableRow();
                                    cell2 = new HtmlTableCell
                                    {
                                        InnerHtml = "<a style=\"font-size:14px; font-weight: bold;\" href=\"ViewClient.aspx?sortby=submissiondate\">Date Submitted</a>"
                                    };
                                    cell2.Attributes["Style"] = "border-bottom: 2px solid;";
                                    cell2.BgColor = flag ? "#CCCCCC" : "#FFFFFF";
                                    cell2.Width = "130px";
                                    cell3 = new HtmlTableCell
                                    {
                                        InnerHtml = "<a style=\"font-size:14px; font-weight: bold;\" href=\"ViewClient.aspx?sortby=employee\">Enrollee Name</a>"
                                    };
                                    cell3.Attributes["Style"] = "border-bottom: 2px solid;";
                                    cell3.BgColor = flag ? "#CCCCCC" : "#FFFFFF";
                                    cell3.Width = "200px";
                                    cell4 = new HtmlTableCell
                                    {
                                        InnerHtml = "<a style=\"font-size:14px; font-weight: bold;\" href=\"ViewClient.aspx?sortby=birthdate\">Birth Date</a>"
                                    };
                                    cell4.Attributes["Style"] = "border-bottom: 2px solid;";
                                    cell4.BgColor = flag ? "#CCCCCC" : "#FFFFFF";
                                    cell4.Width = "100px";
                                    row2.Cells.Add(cell3);
                                    row2.Cells.Add(cell4);
                                    row2.Cells.Add(cell2);
                                    this.clients.Rows.Add(row2);
                                    flag = !flag;
                                    foreach (uspGetSubmissionsByClientIDBrokerViewResult result3 in list)
                                    {
                                        row = new HtmlTableRow();
                                        cell5 = new HtmlTableCell
                                        {
                                            InnerHtml = result3.addeddate.Value.ToShortDateString(),
                                            BgColor = flag ? "#CCCCCC" : "#FFFFFF"
                                        };
                                        cell6 = new HtmlTableCell
                                        {
                                            BgColor = flag ? "#CCCCCC" : "#FFFFFF",
                                            InnerHtml = result3.lastname + ", " + result3.firstname
                                        };
                                        cell7 = new HtmlTableCell
                                        {
                                            BgColor = flag ? "#CCCCCC" : "#FFFFFF",
                                            InnerHtml = result3.birthdate
                                        };
                                        row.Cells.Add(cell6);
                                        row.Cells.Add(cell7);
                                        row.Cells.Add(cell5);
                                        this.clients.Rows.Add(row);
                                        flag = !flag;
                                    }
                                }
                                else
                                {
                                    list = (from x in list
                                            orderby x.firstname
                                            orderby x.lastname
                                            orderby x.addeddate descending
                                            select x).ToList<uspGetSubmissionsByClientIDBrokerViewResult>();
                                    row2 = new HtmlTableRow();
                                    cell2 = new HtmlTableCell
                                    {
                                        InnerHtml = "<a style=\"font-size:14px; font-weight: bold;\" href=\"ViewClient.aspx?sortby=submissiondate\">Date Submitted</a>"
                                    };
                                    cell2.Attributes["Style"] = "border-bottom: 2px solid;";
                                    cell2.BgColor = flag ? "#CCCCCC" : "#FFFFFF";
                                    cell2.Width = "130px";
                                    cell3 = new HtmlTableCell
                                    {
                                        InnerHtml = "<a style=\"font-size:14px; font-weight: bold;\" href=\"ViewClient.aspx?sortby=employee\">Enrollee Name</a>"
                                    };
                                    cell3.Attributes["Style"] = "border-bottom: 2px solid;";
                                    cell3.BgColor = flag ? "#CCCCCC" : "#FFFFFF";
                                    cell3.Width = "200px";
                                    cell4 = new HtmlTableCell
                                    {
                                        InnerHtml = "<a style=\"font-size:14px; font-weight: bold;\" href=\"ViewClient.aspx?sortby=birthdate\">Birth Date</a>"
                                    };
                                    cell4.Attributes["Style"] = "border-bottom: 2px solid;";
                                    cell4.BgColor = flag ? "#CCCCCC" : "#FFFFFF";
                                    cell4.Width = "100px";
                                    row2.Cells.Add(cell3);
                                    row2.Cells.Add(cell4);
                                    row2.Cells.Add(cell2);
                                    this.clients.Rows.Add(row2);
                                    flag = !flag;
                                    foreach (uspGetSubmissionsByClientIDBrokerViewResult result3 in list)
                                    {
                                        row = new HtmlTableRow();
                                        cell5 = new HtmlTableCell
                                        {
                                            InnerHtml = result3.addeddate.Value.ToShortDateString(),
                                            BgColor = flag ? "#CCCCCC" : "#FFFFFF"
                                        };
                                        cell6 = new HtmlTableCell
                                        {
                                            BgColor = flag ? "#CCCCCC" : "#FFFFFF",
                                            InnerHtml = result3.lastname + ", " + result3.firstname
                                        };
                                        cell7 = new HtmlTableCell
                                        {
                                            BgColor = flag ? "#CCCCCC" : "#FFFFFF",
                                            InnerHtml = result3.birthdate
                                        };
                                        row.Cells.Add(cell6);
                                        row.Cells.Add(cell7);
                                        row.Cells.Add(cell5);
                                        this.clients.Rows.Add(row);
                                        flag = !flag;
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.Session.Abandon();
                            FormsAuthentication.SignOut();
                            base.Response.Redirect("~/Default.aspx", false);
                        }
                    }
                    catch (Exception)
                    {
                        this.Session.Abandon();
                        FormsAuthentication.SignOut();
                        base.Response.Redirect("~/Default.aspx", false);
                    }
                }
                else
                {
                    this.Session.Abandon();
                    FormsAuthentication.SignOut();
                    base.Response.Redirect("~/Default.aspx", false);
                }
            }
        }

        public void savepasswd_Click(object sender, EventArgs e)
        {
            ElectronicAppSecurityDBDataContext context = new ElectronicAppSecurityDBDataContext();
            uspGetWebUserByOwnerIDResult result = context.uspGetWebUserByOwnerID(new Guid(this.Session["clid"].ToString())).Single<uspGetWebUserByOwnerIDResult>();
            if (this.password.Text.Equals(result.Password))
            {
                this.showlink_Click(sender, e);
            }
            else if (this.username.Text.Equals(this.password.Text))
            {
                this.errors.Text = "The username and password should be different. Please select a new username or password";
                this.errors.Visible = true;
            }
            else if (this.password.Text.Length < 4)
            {
                this.errors.Text = "The password is not valid. Please choose a longer password.";
                this.errors.Visible = true;
            }
            else
            {
                context.uspAlterWebUser(new Guid?(result.UserID), this.username.Text, this.password.Text);
                this.errors.Visible = false;
                this.errors.Text = "";
                this.showlink_Click(sender, e);
            }
        }

        public void showlink_Click(object sender, EventArgs e)
        {
            if (this.showlink.Text.Equals("show password"))
            {
                ElectronicAppSecurityDBDataContext context = new ElectronicAppSecurityDBDataContext();
                uspGetWebUserByOwnerIDResult result = context.uspGetWebUserByOwnerID(new Guid(this.Session["clid"].ToString())).Single<uspGetWebUserByOwnerIDResult>();
                this.username.Text = result.UserName;
                this.password.Text = result.Password;
                this.passinfo.Style["Display"] = "block";
                this.showlink.Text = "hide password";
            }
            else
            {
                this.showlink.Text = "show password";
                this.passinfo.Style["Display"] = "none";
            }
        }
    }
}
