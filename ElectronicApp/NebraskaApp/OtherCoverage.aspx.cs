using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ElectronicApp.Supporting_Classes;

namespace ElectronicApp.NebraskaApp
{
    public partial class OtherCoverage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnNext.Attributes.Add("onClick", "return valSubmit();");
            isLife.Value = "0";
            if (Session["UserID"] != null)
            {
                if (Session["Coverage"] != null && Session["CoverageOffered"] != null)
                {
                    Coverage myCoverage = (Coverage)Session["Coverage"];
                    coverageOffered myCoverageOffered = (coverageOffered)Session["CoverageOffered"];
                    if(myCoverageOffered.IsLife)
                    {
                        if (!myCoverage.isWaiving("Life"))
                        {
                            isLife.Value = "1";
                        }
                    }
                }
                else Response.Redirect("~/Default.aspx");
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (cmbMedicare.SelectedValue.ToLower().Equals("yes"))
                {
                    MedicareCoverage myMedicare = new MedicareCoverage();
                    myMedicare.Name = txtMedicareName.Text;
                    myMedicare.ID = txtMedicareID.Text;
                    myMedicare.EffDateA = txtMedicareA.Text;
                    myMedicare.EffDateB = txtMedicareB.Text;
                    myMedicare.EffDateC = txtMedicareC.Text;
                    if (Session["MedicareCoverage"] == null)
                    {
                        Session.Add("MedicareCoverage", myMedicare);
                    }
                    else
                    {
                        Session["MedicareCoverage"] = myMedicare;
                    }
                }
                else
                {
                    if (Session["MedicareCoverage"] != null)
                    {
                        Session.Remove("MedicareCoverage");
                    }

                }
                if (cmbConcurrentCoverage.SelectedValue.ToLower().Equals("yes"))
                {
                    ConcurrentCoverage myConcurrent = new ConcurrentCoverage();
                    myConcurrent.Name = txtConcurentName.Text;
                    myConcurrent.Employer = txtConcurrentEmployer.Text;
                    myConcurrent.InsuranceCompanyName = txtConcurrentProvider.Text;
                    myConcurrent.PolicyNo = txtConcurrentPolicy.Text;
                    myConcurrent.EffectiveDate = txtConcurrentEff.Text;
                    myConcurrent.EndDate = txtConcurrentEnd.Text;
                    myConcurrent.IsDental = ckDental.Checked;
                    myConcurrent.IsDisability = ckDisability.Checked;
                    myConcurrent.IsLife = ckLife.Checked;
                    myConcurrent.IsMedical = ckMedical.Checked;
                    myConcurrent.IsVision = ckVision.Checked;
                    if (cmbConcurrentType.SelectedValue.Equals("employee", StringComparison.CurrentCultureIgnoreCase))
                    {
                        myConcurrent.IsEmployee = true;
                    }
                    else if (cmbConcurrentType.SelectedValue.Equals("employee/child(ren)", StringComparison.CurrentCultureIgnoreCase))
                    {
                        myConcurrent.IsEmployeeChild = true;
                    }
                    else if (cmbConcurrentType.SelectedValue.Equals("employee/spouse", StringComparison.CurrentCultureIgnoreCase))
                    {
                        myConcurrent.IsEmployeeSpouse = true;
                    }
                    else if (cmbConcurrentType.SelectedValue.Equals("Employee/Spouse/Child(ren)", StringComparison.CurrentCultureIgnoreCase))
                    {
                        myConcurrent.IsEmployeeSpouseChild = true;
                    }

                    if (Session["ConcurrentCoverage"] == null)
                    {
                        Session.Add("ConcurrentCoverage", myConcurrent);
                    }
                    else
                    {
                        Session["ConcurrentCoverage"] = myConcurrent;
                    }
                }
                else
                {
                    if (Session["ConcurrentCoverage"] != null)
                    {
                        Session.Remove("ConcurrentCoverage");
                    }

                }
                if (cmbPreviousCoverage.SelectedValue.ToLower().Equals("yes"))
                {
                    PreviousCoverage myPrevious = new PreviousCoverage();
                    myPrevious.Names = txtPreviousName.Text;
                    myPrevious.Employer = txtPreviousEmployer.Text;
                    myPrevious.InsuranceCompanyName = txtPreviousProvider.Text;
                    myPrevious.Policy = txtPolicy.Text;
                    myPrevious.EffectiveDate = txtPreviousEff.Text;
                    myPrevious.EndDate = txtPreviousEnd.Text;

                    if (cmbPreviousType.SelectedValue.Equals("employee", StringComparison.CurrentCultureIgnoreCase))
                    {
                        myPrevious.IsEmployee = true;
                    }
                    else if (cmbPreviousType.SelectedValue.Equals("employee/child(ren)", StringComparison.CurrentCultureIgnoreCase))
                    {
                        myPrevious.IsEmployeeChild = true;
                    }
                    else if (cmbPreviousType.SelectedValue.Equals("employee/spouse", StringComparison.CurrentCultureIgnoreCase))
                    {
                        myPrevious.IsEmployeeSpouse = true;
                    }
                    else if (cmbPreviousType.SelectedValue.Equals("Employee/Spouse/Child(ren)", StringComparison.CurrentCultureIgnoreCase))
                    {
                        myPrevious.IsEmployeeSpouseChild = true;
                    }

                    if (Session["PreviousCoverage"] == null)
                    {
                        Session.Add("PreviousCoverage", myPrevious);
                    }
                    else
                    {
                        Session["PreviousCoverage"] = myPrevious;
                    }
                }
                else
                {
                    if (Session["PreviousCoverage"] != null)
                    {
                        Session.Remove("PreviousCoverage");
                    }
                }

                if (isLife.Value == "1")
                {
                    LifeBeneficiaries myLife = new LifeBeneficiaries();
                    myLife.Primary1Name = txtPrimary1Name.Text + ", " + txtPrimary1Addr.Text;
                    myLife.Primary1Percent = txtPrimary1Perc.Text;
                    myLife.Primary1Relationship = txtPrimary1Relation.Text;
                    myLife.Primary1SSN = txtPrimary1SSN.Text;

                    myLife.Primary2Name = txtPrimary2Name.Text + ", " + txtPrimary2Addr.Text;
                    myLife.Primary2Percent = txtPrimary2Perc.Text;
                    myLife.Primary2Relationship = txtPrimary2Relation.Text;
                    myLife.Primary2SSN = txtPrimary2SSN.Text;

                    myLife.Secondary1Name = txtSecondary1Name.Text + ", " + txtSecondary1Addr.Text;
                    myLife.Secondary1Percent = txtSecondary1Perc.Text;
                    myLife.Secondary1Relationship = txtSecondary1Relation.Text;
                    myLife.Secondary1SSN = txtSecondary1SSN.Text;

                    myLife.Secondary2Name = txtSecondary2Name.Text + ", " + txtSecondary2Addr.Text;
                    myLife.Secondary2Percent = txtSecondary2Perc.Text;
                    myLife.Secondary2Relationship = txtSecondary2Relation.Text;
                    myLife.Secondary2SSN = txtSecondary2SSN.Text;
                    if (Session["LifeBeneficiaries"] == null)
                    {
                        Session.Add("LifeBeneficiaries", myLife);
                    }
                    else
                    {
                        Session["LifeBeneficiaries"] = myLife;
                    }
                }
                else
                {
                    if (Session["LifeBeneficiaries"] != null)
                    {
                        Session.Remove("LifeBeneficiaries");
                    }
                }
                Response.Redirect("HealthInformation.aspx");
            }
        }
    }
}
