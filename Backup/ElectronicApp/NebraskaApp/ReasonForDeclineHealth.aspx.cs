﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ElectronicApp.Supporting_Classes;

namespace ElectronicApp.NebraskaApp
{
    public partial class ReasonForDeclineHealth : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnNext.Attributes.Add("onClick", "return valSubmit();");
            if (Session["UserID"] != null)
            {
                if ((Session["EmployeeData"] != null) && (Session["Coverage"] != null))
                {
                    Coverage myCoverage = (Coverage) Session["Coverage"];
                    if (myCoverage.isWaiving("Medical"))
                    {
                        tdMedical.InnerHtml =  myCoverage.getWhoIsWaiving("Medical");
                    }
                    else
                    {
                        trMedical.Visible = false;
                    }
                  
                }
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if ((Session["EmployeeData"] != null) && (Session["Coverage"] != null))
                {
                    bool isSpouseCovered = false;
                    bool isChildrenCovered = false;

                    Coverage myCoverage = (Coverage)Session["Coverage"];
                    employeeData myData = (employeeData)Session["EmployeeData"];
                    DeclineReason myReason = saveReasons();
                   
                    if (Session["ReasonForDeclineHealth"] != null)
                    {
                        Session.Add("ReasonForDeclineHealth", myReason);
                    }
                    else
                    {
                        Session["ReasonForDeclineHealth"] = myReason;
                    }
                    if (!myData.IsSingle)
                    {
                        isSpouseCovered = myCoverage.isSpouseCovered();
                    }
                    if (myData.IsChildren)
                    {
                        isChildrenCovered = myCoverage.isChildCovered();
                    }
                    if (myCoverage.isWaiving("Dental"))
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
                    else if (isSpouseCovered || isChildrenCovered)
                    {
                        Response.Redirect("DependentData.aspx", false);
                    }
                    else
                    {
                        if (myData.WaiveAll || myCoverage.IsWaiveAll)
                        {
                            Response.Redirect("Processing.aspx", false);
                        }
                        else
                        {
                            Response.Redirect("OtherCoverage.aspx", false);
                        }
                    }
                }
            }
        }

        protected DeclineReason saveReasons()
        {
            DeclineReason myReason = new DeclineReason();
            //Store reasons in decline reason object
            if (ckSpouse.Checked)
            {
                myReason.SpousePlan = true;
            }
            if (ckMedicare.Checked)
            {
                myReason.Medicare = true;
            }
            if (ckCobra.Checked)
            {
                myReason.COBRA = true;
            }
            if (ckNoCoverage.Checked)
            {
                myReason.NoCoverage = true;
            }
            if (ckDisability.Checked)
            {
                myReason.Disability = true;
            }
            if (ckIndividualPlan.Checked)
            {
                myReason.Individual = true;
            }
            if (ckVA.Checked)
            {
                myReason.VA = true;
            }
            if (ckTriCare.Checked)
            {
                myReason.TriCare = true;
            }
            if (ckMedicaid.Checked)
            {
                myReason.Medicaid = true;
            }
            if (ckOther.Checked)
            {
                myReason.Other = true;
                myReason.Explanation = txtExplanation.Text;
            }
            return myReason;
        }
    }
}
