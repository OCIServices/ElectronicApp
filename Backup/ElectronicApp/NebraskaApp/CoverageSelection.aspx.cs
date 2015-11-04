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

namespace ElectronicApp.NebraskaApp
{
    public partial class CoverageSelection : BasePage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            btnNext.Attributes.Add("onClick", "return valSubmit();");
            if(!IsPostBack)
            {
                if (Session["UserID"] != null)
                {
                    if (Session["EmployeeData"] != null)
                    {
                        ArrayList coverageItems = new ArrayList();
                        employeeData myEmployeeData = (employeeData)Session["EmployeeData"];
                        coverageOffered myCoverageOffered = (coverageOffered)Session["CoverageOffered"];

                        if (!myEmployeeData.IsSingle)
                        {
                            isSingle.Value = "false";
                        }
                        else
                        {
                            isSingle.Value = "true";
                        }
                        if (myEmployeeData.IsChildren)
                        {
                            isChildren.Value = "true";
                        }
                        else
                        {
                            isChildren.Value = "false";
                        }

                        if (myEmployeeData.WaiveAll)
                        {
                            coverageItems.Add(new ListItem("Decline", "Waive"));
                        }
                        else if (!myEmployeeData.MaritalStatus.ToLower().Equals("married"))
                        {
                            if (myEmployeeData.NumChildren == 0)
                            {
                                coverageItems.Add(new ListItem("Employee", "Employee"));
                                coverageItems.Add(new ListItem("Decline", "Waive"));
                            }
                            else
                            {
                                coverageItems.Add(new ListItem("Employee", "Employee"));
                                coverageItems.Add(new ListItem("Employee/Child(ren)", "Employee/Child(ren)"));
                                coverageItems.Add(new ListItem("Decline", "Waive"));
                            }
                        }
                        else
                        {
                            if (myEmployeeData.NumChildren == 0)
                            {
                                coverageItems.Add(new ListItem("Employee", "Employee"));
                                coverageItems.Add(new ListItem("Employee/Spouse", "Employee/Spouse"));
                                coverageItems.Add(new ListItem("Decline", "Waive"));
                            }
                            else
                            {
                                coverageItems.Add(new ListItem("Employee", "Employee"));
                                coverageItems.Add(new ListItem("Employee/Spouse", "Employee/Spouse"));
                                coverageItems.Add(new ListItem("Employee/Child(ren)", "Employee/Child(ren)"));
                                coverageItems.Add(new ListItem("Employee/Spouse/Child(ren)", "Employee/Spouse/Child(ren)"));
                                coverageItems.Add(new ListItem("Decline", "Waive"));
                            }
                        }

                        foreach (ListItem li in coverageItems)
                        {
                            if (myCoverageOffered.IsMedical)
                            {
                                cmbMedical.Items.Add(li);
                                if (myEmployeeData.WaiveAll)
                                {
                                    cmbMedical.SelectedValue = "Waive";
                                }
                            }
                            else
                                trMedical.Visible = false;

                            if (myCoverageOffered.IsDental)
                            {
                                cmbDental.Items.Add(li);
                                if (myEmployeeData.WaiveAll)
                                {
                                    cmbDental.SelectedValue = "Waive";
                                }
                            }
                            else
                                trDental.Visible = false;

                            if (myCoverageOffered.IsVision)
                            {
                                cmbVision.Items.Add(li);
                                if (myEmployeeData.WaiveAll)
                                {
                                    cmbVision.SelectedValue = "Waive";
                                }
                            }
                            else
                                trVision.Visible = false;

                            if (myCoverageOffered.IsLife)
                            {
                                cmbLife.Items.Add(li);
                                if (myEmployeeData.WaiveAll)
                                {
                                    cmbLife.SelectedValue = "Waive";
                                }
                            }
                            else
                                trLife.Visible = false;
                        }
                        if (myCoverageOffered.IsDisability)
                        {
                            if (!myEmployeeData.WaiveAll)
                            {
                                cmbDisability.Items.Add(new ListItem("Employee", "Employee"));
                                //cmbDisability.Items.Add(new ListItem("Employee/Long Term", "Employee/Long Term"));
                                cmbDisability.Items.Add(new ListItem("Decline", "Waive"));
                            }
                            else
                            {
                                cmbDisability.Items.Add(new ListItem("Decline", "Waive"));
                                cmbDisability.SelectedValue = "Waive";
                            }
                        }
                        else
                            trDisability.Visible = false;
                    }
                }
                else
                {
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("Default.aspx", false);
                }
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (Session["EmployeeData"] != null && Session["CoverageOffered"] != null)
                {
                    employeeData myEmployeeData = (employeeData)Session["EmployeeData"];
                    Coverage myCoverage = new Coverage(myEmployeeData.WaiveAll);
                    coverageOffered myCoverageOffered = (coverageOffered)Session["CoverageOffered"];

                    if (myCoverageOffered.IsMedical)
                    {
                        myCoverage.addCoverageItem(new CoverageItem("Medical", cmbMedical.SelectedValue.ToLower(), myEmployeeData.IsSingle, myEmployeeData.IsChildren));
                    }
                    if (myCoverageOffered.IsDental)
                    {
                        myCoverage.addCoverageItem(new CoverageItem("Dental", cmbDental.SelectedValue.ToLower(), myEmployeeData.IsSingle, myEmployeeData.IsChildren));
                    }
                    if (myCoverageOffered.IsVision)
                    {
                        myCoverage.addCoverageItem(new CoverageItem("Vision", cmbVision.SelectedValue.ToLower(), myEmployeeData.IsSingle, myEmployeeData.IsChildren));
                    }
                    if (myCoverageOffered.IsLife)
                    {
                        myCoverage.addCoverageItem(new CoverageItem("Life", cmbLife.SelectedValue.ToLower(), myEmployeeData.IsSingle, myEmployeeData.IsChildren));
                    }
                    if (myCoverageOffered.IsDisability)
                    {
                        myCoverage.addCoverageItem(new CoverageItem("Disability", cmbDisability.SelectedValue.ToLower(), myEmployeeData.IsSingle, myEmployeeData.IsChildren));
                    }

                    if ((!myCoverageOffered.IsMedical || cmbMedical.SelectedValue.ToLower() == "waive") &&
                      (!myCoverageOffered.IsDental || cmbDental.SelectedValue.ToLower() == "waive") &&
                      (!myCoverageOffered.IsDisability || cmbDisability.SelectedValue.ToLower() == "waive") &&
                      (!myCoverageOffered.IsVision || cmbVision.SelectedValue.ToLower() == "waive") &&
                      (!myCoverageOffered.IsLife || cmbLife.SelectedValue.ToLower() == "waive"))
                    {
                        //myEmployeeData.WaiveAll = true;
                        myCoverage.IsWaiveAll = true;
                    }

                    if (Session["Coverage"] != null)
                    {
                        Session["Coverage"] = myCoverage;
                    }
                    else
                    {
                        Session.Add("Coverage", myCoverage);
                    }

                    if (myCoverage.isWaiving("Medical"))
                    {
                        Response.Redirect("ReasonForDeclineHealth.aspx", false);
                    }
                    else if (myCoverage.isWaiving("Dental"))
                    {
                        Response.Redirect("ReasonForDeclineDental.aspx", false);
                    }
                    else if (myCoverage.isWaiving("Vision"))
                    {
                        Response.Redirect("ReasonForDeclineVision.aspx", false);
                    }
                    else if (myCoverage.isWaiving("Life"))
                    {
                        Response.Redirect("ReasonForDeclineLife.aspx", false);
                    }
                    else if (myCoverage.isWaiving("Disability"))
                    {
                        Response.Redirect("ReasonForDeclineDisability.aspx", false);
                    }
                    else
                    {
                        bool isSpouseCovered = false;
                        bool isChildrenCovered = false;
                        if (!myEmployeeData.IsSingle)
                        {
                            isSpouseCovered = myCoverage.isSpouseCovered();
                        }
                        if (myEmployeeData.IsChildren)
                        {
                            isChildrenCovered = myCoverage.isChildCovered();
                        }
                        if (isSpouseCovered || isChildrenCovered)
                        {
                            Response.Redirect("DependentData.aspx", false);
                        }
                        else
                        {
                            Response.Redirect("OtherCoverage.aspx", false);
                        }
                    }
                }
                else
                {
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Default.aspx?timeout=1");
                }
            }
            else
            {
                Session.Abandon();
                FormsAuthentication.SignOut();
                Response.Redirect("~/Default.aspx?timeout=1");
            }
        }

        protected void btnPrev_Click(object sender, ImageClickEventArgs e)
        {
            //Server.Transfer("EmployeeData.aspx",true);
        }
    }
}

