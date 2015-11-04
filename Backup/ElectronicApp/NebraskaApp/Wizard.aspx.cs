using System;
using System.Xml.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Text;
using System.Linq;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.xml;
using iTextSharp.text.pdf;
using ElectronicApp;
using ElectronicApp.Supporting_Classes;
using ElectronicApp.NebraskaApp.Controls;

namespace ElectronicApp.NebraskaApp
{
    public partial class Wizard : System.Web.UI.Page
    {
        bool isEdit = false, isAdd = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ClientID"] == null && Session["UserID"] == null)
            {
                Session.Abandon();
                FormsAuthentication.SignOut();
                Response.Redirect("~/Default.aspx?timeout=1");
            }

            else
            {


                //Update the title.
                String title = UserWizard1.ActiveStep.Title;
                int firstSpace = title.IndexOf(' ');

                header.InnerHtml = "<span class=\"red\">" + title.Substring(0, firstSpace) + "</span>" + title.Substring(firstSpace);

                this.Title = "e-Enroll :: " + title;

                Button btn = (Button)(UserWizard1.FindControl("StepNavigationTemplateContainerID").FindControl("StepNextButton"));
                btn.Attributes.Add("onClick", "return valSubmit();");

                Button btn2 = (Button)(UserWizard1.FindControl("StartNavigationTemplateContainerID").FindControl("StartNextButton"));
                btn2.Attributes.Add("onClick", "return valSubmit();");

                Button btn3 = (Button)(UserWizard1.FindControl("FinishNavigationTemplateContainerID").FindControl("FinishButton"));
                btn3.Attributes.Add("disabled", "true");
            }
        }

        protected void UserWizard1_FinishButtonClick(object sender, EventArgs e)
        {
            //Process The Application and save it.
            #region Sign Application
            if (UserWizard1.ActiveStepIndex == 14)
            {
                if (ctlMySignature.IsValid())
                {
                    // show the newly generated signature image in sign area (optional)
                    ctlMySignature.ShowSignature();

                    // get the path of generated signature file
                    string finalImg = ctlMySignature.SignatureFile;
                    Session.Add("Signature", finalImg);
                    if (Session["ClientID"] != null && Session["UserID"] != null)
                    {
                        ByteBuffer PDF = (ByteBuffer)Session["PDF"];
                        SignAndDatePDF myPDF = new SignAndDatePDF(PDF);
                        myPDF.SignPDF(Server.MapPath(finalImg));
                        myPDF.close();
                        ByteBuffer pdf = myPDF.getSignedPDF();
                        Session.Add("Signed", pdf);

                        try
                        {
                            Encrypt encPDF = new Encrypt((Guid)Session["UserID"], Request.UserHostAddress.ToString());
                            encPDF.EncryptPDF(pdf.Buffer);
                        }
                        catch (Exception ex)
                        {
                            Title = "!!! " + Title;
                        }

                    }
                    else
                    {
                        Response.Redirect("~/Default.aspx?timeout=1");
                    }
                }
                else
                {
                    Page.RegisterStartupScript("nosign", "<script language='javascript'>ClearSignature();</script>");
                    Page.RegisterStartupScript("nosign", "<script language='javascript'>alert('" + ctlMySignature.NoSignMessage + "');</script>");
                }
            }
            #endregion
        }

        protected void UserWizard1_NextButtonClick(object sender, EventArgs e)
        {
            //Handle saving data the old way.
            #region Basic Info
            if (UserWizard1.ActiveStepIndex == 0)
            {
                if (Session["ClientID"] == null && Session["UserID"] == null)
                {
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Default.aspx?timeout=1");
                }
                else
                {
                    Guid ClientID = (Guid)Session["ClientID"];
                    Guid UserID = (Guid)Session["UserID"];
                    ElectronicAppDBDataContext eappdata = new ElectronicAppDBDataContext();
                    //eappdata.uspDoesEnrolleeExist(ClientID, txtFirstName, txtLastName, txtBirthDate);
                    List<uspDoesEnrolleeExistResult> myResult = eappdata.uspDoesEnrolleeExist(ClientID, txtFirstName.Text, txtLastName.Text, txtMonth.Text + "/" + txtDay.Text + "/" + txtYear.Text).ToList<uspDoesEnrolleeExistResult>();
                    if (myResult.Count > 0)
                    {
                        Session["UserID"] = myResult[0].EnrolleeID;
                    }
                    else
                    {
                        eappdata.uspInsertEnrollee(UserID, ClientID, txtFirstName.Text, txtLastName.Text, txtMonth.Text + "/" + txtDay.Text + "/" + txtYear.Text, false, Request.UserHostAddress.ToString());
                    }

                    employeeData myData = new employeeData();
                    myData.EmployeeName = txtFirstName.Text + " " + txtLastName.Text;
                    myData.DOB = txtMonth.Text + "/" + txtDay.Text + "/" + txtYear.Text;

                    if (cmbWaive.Text.Equals("Yes", StringComparison.CurrentCultureIgnoreCase))
                    {
                        myData.WaiveAll = true;
                        Session.Add("EmployeeData", myData);
                        UserWizard1.ActiveStepIndex = 2;
                    }
                    else
                    {
                        myData.WaiveAll = false;
                        Session.Add("EmployeeData", myData);
                    }
                }
            }
            #endregion

            #region Employee Data
            else if (UserWizard1.ActiveStepIndex == 1)
            {
                if (Session["UserID"] != null && Session["ClientID"] != null && Session["EmployeeData"] != null)
                {
                    employeeData myData = (employeeData)Session["EmployeeData"];


                    myData.HomeAddress = txtAddress.Text;
                    myData.City = txtCity.Text;
                    myData.State = txtState.Text;
                    myData.Zip = txtZip.Text;
                    myData.HomePhone = txtHomePhone.Text + "-" + txtHomePhone0.Text + "-" + txtHomePhone1.Text;
                    myData.WorkPhone = txtWorkPhone.Text + "-" + txtWorkPhone0.Text + "-" + txtWorkPhone1.Text;
                    myData.Email = txtEmail.Text;
                    // myData.DOB = txtDOB.Text;
                    myData.Height = txtHeight.Text;
                    myData.Weight = txtWeight.Text;
                    myData.Soc = txtSoc.Text + "-" + txtSoc0.Text + "-" + txtSoc1.Text;
                    myData.JobTitle = txtTitle.Text;
                    myData.DOH = txtHireDate.Text;
                    myData.AvgHours = txtHours.Text;
                    myData.Salary = txtSalary.Text;
                    myData.EmploymentStatus = cmbStatus.SelectedValue;
                    myData.MaritalStatus = cmbMaritalStatus.SelectedValue;
                    myData.NumChildren = int.Parse(cmbChildren.SelectedValue);
                    myData.PrimaryPhysician = txtPhysician.Text;

                    if (cmbMedicare.SelectedValue.ToUpper() == "YES")
                    {
                        myData.Medicare = true;
                    }
                    else
                    {
                        myData.Medicare = false;
                    }
                    if (cmbDisabled.SelectedValue.ToUpper() == "YES")
                    {
                        myData.Disabled = true;
                    }
                    else
                    {
                        myData.Disabled = false;
                    }

                    if (cmbGender.SelectedValue.ToUpper() == "MALE")
                    {
                        myData.Gender = "male";
                    }
                    else
                    {
                        myData.Gender = "female";
                    }

                    Session["EmployeeData"] = myData;
                }
                else
                {
                    Response.Redirect("~/Default.aspx?timeout=1", false);
                }
            }
            #endregion

            #region Coverage Selection
            else if (UserWizard1.ActiveStepIndex == 2)
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
                            UserWizard1.ActiveStepIndex = 4;
                        }
                        else if (myCoverage.isWaiving("Dental"))
                        {
                            UserWizard1.ActiveStepIndex = 5;
                        }
                        else if (myCoverage.isWaiving("Vision"))
                        {
                            UserWizard1.ActiveStepIndex = 6;
                        }
                        else if (myCoverage.isWaiving("Life"))
                        {
                            UserWizard1.ActiveStepIndex = 7;
                        }
                        else if (myCoverage.isWaiving("Disability"))
                        {
                            UserWizard1.ActiveStepIndex = 8;
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
                                //Do Nothing. Wizard will procede to Step 3 normally.
                            }
                            else
                            {
                                UserWizard1.ActiveStepIndex = 9;
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
            #endregion

            #region Dependent Data
            else if (UserWizard1.ActiveStepIndex == 3)
            {
                if (Session["UserID"] != null)
                {
                    Dependents myDependents = new Dependents();
                    if (isSpouse.Value.Equals("1"))
                    {
                        Dependent myDependent = new Dependent();
                        myDependent.IsSpouse = true;
                        myDependent.Name = spName.Text;
                        if (spGender.Text.ToLower().Equals("male"))
                        {
                            myDependent.Gender = 'M';
                        }
                        else if (spGender.Text.ToLower().Equals("female"))
                        {
                            myDependent.Gender = 'F';
                        }
                        myDependent.Height = spHeight.Text;
                        myDependent.Weight = spWeight.Text;
                        myDependent.DOB = spDOB.Text;
                        myDependent.SSN = spSSN.Text;
                        myDependent.PrimaryCarePhysician = spPhysician.Text;
                        if (spStudent.Text.ToLower().Equals("yes"))
                        {
                            myDependent.Student = true;
                        }
                        else
                        {
                            myDependent.Student = false;
                        }
                        if (spMedicare.Text.ToLower().Equals("yes"))
                        {
                            myDependent.Medicare = true;
                        }
                        else
                        {
                            myDependent.Medicare = false;
                        }
                        if (spSS.Text.ToLower().Equals("yes"))
                        {
                            myDependent.SSEnrolled = true;
                        }
                        else
                        {
                            myDependent.SSEnrolled = false;
                        }
                        myDependents.addDependent(myDependent);
                    }
                    if (!numChildren.Value.Equals("0"))
                    {
                        getChildren(myDependents);
                    }
                    if (Session["Dependents"] != null)
                    {
                        Session["Dependents"] = myDependents;
                    }
                    else
                    {
                        Session.Add("Dependents", myDependents);
                    }
                    UserWizard1.ActiveStepIndex = 9;

                }
            }
            #endregion

            #region Medical Waive
            else if (UserWizard1.ActiveStepIndex == 4)
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
                            UserWizard1.ActiveStepIndex = 5;
                        }
                        else if (myCoverage.isWaiving("Vision"))
                        {
                            UserWizard1.ActiveStepIndex = 6;
                        }
                        else if (myCoverage.isWaiving("Life"))
                        {
                            UserWizard1.ActiveStepIndex = 7;
                        }
                        else if (myCoverage.isWaiving("Disability"))
                        {
                            UserWizard1.ActiveStepIndex = 8;
                        }
                        else if (isSpouseCovered || isChildrenCovered)
                        {
                            UserWizard1.ActiveStepIndex = 3;
                        }
                        else
                        {
                            if (myData.WaiveAll || myCoverage.IsWaiveAll)
                            {
                                UserWizard1.ActiveStepIndex = 12;
                            }
                            else
                            {
                                UserWizard1.ActiveStepIndex = 9;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Dental Waive
            else if (UserWizard1.ActiveStepIndex == 5)
            {
                if (Session["UserID"] != null)
                {
                    if ((Session["EmployeeData"] != null) && (Session["Coverage"] != null))
                    {
                        bool isSpouseCovered = false;
                        bool isChildrenCovered = false;

                        Coverage myCoverage = (Coverage)Session["Coverage"];
                        employeeData myData = (employeeData)Session["EmployeeData"];
                        DeclineReason myReason = saveReasons0();

                        if (Session["ReasonForDeclineDental"] != null)
                        {
                            Session.Add("ReasonForDeclineDental", myReason);
                        }
                        else
                        {
                            Session["ReasonForDeclineDental"] = myReason;
                        }
                        if (!myData.IsSingle)
                        {
                            isSpouseCovered = myCoverage.isSpouseCovered();
                        }
                        if (myData.IsChildren)
                        {
                            isChildrenCovered = myCoverage.isChildCovered();
                        }
                        if (myCoverage.isWaiving("Vision"))
                        {
                            UserWizard1.ActiveStepIndex = 6;
                        }
                        else if (myCoverage.isWaiving("Life"))
                        {
                            UserWizard1.ActiveStepIndex = 7;
                        }
                        else if (myCoverage.isWaiving("Disability"))
                        {
                            UserWizard1.ActiveStepIndex = 8;
                        }
                        else if (isSpouseCovered || isChildrenCovered)
                        {
                            UserWizard1.ActiveStepIndex = 3;
                        }
                        else if (isSpouseCovered || isChildrenCovered)
                        {
                            UserWizard1.ActiveStepIndex = 3;
                        }
                        else
                        {
                            if (myData.WaiveAll || myCoverage.IsWaiveAll)
                            {
                                UserWizard1.ActiveStepIndex = 12;
                            }
                            else
                            {
                                UserWizard1.ActiveStepIndex = 9;
                            }                        }
                    }
                }
            }
            #endregion

            #region Vison Waive
            else if (UserWizard1.ActiveStepIndex == 6)
            {
                if (Session["UserID"] != null)
                {
                    if ((Session["EmployeeData"] != null) && (Session["Coverage"] != null))
                    {
                        bool isSpouseCovered = false;
                        bool isChildrenCovered = false;

                        Coverage myCoverage = (Coverage)Session["Coverage"];
                        employeeData myData = (employeeData)Session["EmployeeData"];
                        DeclineReason myReason = saveReasons1();

                        if (Session["ReasonForDeclineVision"] != null)
                        {
                            Session.Add("ReasonForDeclineVision", myReason);
                        }
                        else
                        {
                            Session["ReasonForDeclineVision"] = myReason;
                        }
                        if (!myData.IsSingle)
                        {
                            isSpouseCovered = myCoverage.isSpouseCovered();
                        }
                        if (myData.IsChildren)
                        {
                            isChildrenCovered = myCoverage.isChildCovered();
                        }

                        if (myCoverage.isWaiving("Life"))
                        {
                            UserWizard1.ActiveStepIndex = 7;
                        }
                        else if (myCoverage.isWaiving("Disability"))
                        {
                            UserWizard1.ActiveStepIndex = 8;
                        }
                        else if (isSpouseCovered || isChildrenCovered)
                        {
                            UserWizard1.ActiveStepIndex = 3;
                        }
                        else if (isSpouseCovered || isChildrenCovered)
                        {
                            UserWizard1.ActiveStepIndex = 3;
                        }
                        else
                        {
                            if (myData.WaiveAll || myCoverage.IsWaiveAll)
                            {
                                UserWizard1.ActiveStepIndex = 12;
                            }
                            else
                            {
                                UserWizard1.ActiveStepIndex = 9;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Life Waive
            else if (UserWizard1.ActiveStepIndex == 7)
            {
                if (Session["UserID"] != null)
                {
                    if ((Session["EmployeeData"] != null) && (Session["Coverage"] != null))
                    {
                        bool isSpouseCovered = false;
                        bool isChildrenCovered = false;

                        Coverage myCoverage = (Coverage)Session["Coverage"];
                        employeeData myData = (employeeData)Session["EmployeeData"];
                        DeclineReason myReason = saveReasons2();

                        if (Session["ReasonForDeclineLife"] != null)
                        {
                            Session.Add("ReasonForDeclineLife", myReason);
                        }
                        else
                        {
                            Session["ReasonForDeclineLife"] = myReason;
                        }
                        if (!myData.IsSingle)
                        {
                            isSpouseCovered = myCoverage.isSpouseCovered();
                        }
                        if (myData.IsChildren)
                        {
                            isChildrenCovered = myCoverage.isChildCovered();
                        } if (myCoverage.isWaiving("Disability"))
                        {
                            UserWizard1.ActiveStepIndex = 8;
                        }
                        else if (isSpouseCovered || isChildrenCovered)
                        {
                            UserWizard1.ActiveStepIndex = 3;
                        }
                        else
                        {
                            if (myData.WaiveAll || myCoverage.IsWaiveAll)
                            {
                                UserWizard1.ActiveStepIndex = 12;
                            }
                            else
                            {
                                UserWizard1.ActiveStepIndex = 9;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Disability Waive
            else if (UserWizard1.ActiveStepIndex == 8)
            {
                if (Session["UserID"] != null)
                {
                    if ((Session["EmployeeData"] != null) && (Session["Coverage"] != null))
                    {
                        bool isSpouseCovered = false;
                        bool isChildrenCovered = false;

                        Coverage myCoverage = (Coverage)Session["Coverage"];
                        employeeData myData = (employeeData)Session["EmployeeData"];
                        DeclineReason myReason = saveReasons3();

                        if (Session["ReasonForDeclineDisability"] != null)
                        {
                            Session.Add("ReasonForDeclineDisability", myReason);
                        }
                        else
                        {
                            Session["ReasonForDeclineDisability"] = myReason;
                        }
                        if (!myData.IsSingle)
                        {
                            isSpouseCovered = myCoverage.isSpouseCovered();
                        }
                        if (myData.IsChildren)
                        {
                            isChildrenCovered = myCoverage.isChildCovered();
                        }
                        if (isSpouseCovered || isChildrenCovered)
                        {
                            UserWizard1.ActiveStepIndex = 3;
                        }
                        else
                        {
                            if (myData.WaiveAll || myCoverage.IsWaiveAll)
                            {
                                UserWizard1.ActiveStepIndex = 12;
                            }
                            else
                            {
                                UserWizard1.ActiveStepIndex = 9;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Other Coverage
            else if (UserWizard1.ActiveStepIndex == 9)
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
                }
            }
            #endregion

            #region Health Information
            else if (UserWizard1.ActiveStepIndex == 10)
            {
                bool hasCondition = false;
                HealthInformationAnswers myAnswers = new HealthInformationAnswers();
                foreach (System.Web.UI.WebControls.ListItem li in CheckBoxList1.Items)
                {
                    if (li.Selected)
                    {
                        myAnswers.addAnswer(li);
                        hasCondition = true;
                    }
                }
                foreach (System.Web.UI.WebControls.ListItem li in CheckBoxList3.Items)
                {
                    if (li.Selected)
                    {
                        myAnswers.addAnswer(li);
                        hasCondition = true;
                    }
                }

                if (txtDueDate.Text != "")
                {
                    myAnswers.DueData = txtDueDate.Text;
                }
                else
                {
                    myAnswers.DueData = "";
                }

                if (Q32.Text.ToLower().Equals("yes"))
                {
                    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("32. Have you or any of your dependents recieved inpatiant or outpatient services in the last 3 years (excluding routine tests, physicals or inoculations)?", "Q32", true);
                    li.Selected = true;
                    myAnswers.addAnswer(li);
                    myAnswers.Q32 = true;
                    hasCondition = true;
                }

                if (Q33.Text.ToLower().Equals("yes"))
                {
                    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("33. Do you or any person named in this application have tests, treatments, hospitalization or surgery planned or recommended in the future?", "Q33", true);
                    li.Selected = true;
                    myAnswers.addAnswer(li);
                    myAnswers.Q33 = true;
                    hasCondition = true;
                }

                if (Q34.Text.ToLower().Equals("yes"))
                {
                    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("34. Do you or any person named in this application take any medicine, prescription drugs or require shots/injections?", "Q34", true);
                    li.Selected = true;
                    myAnswers.addAnswer(li);
                    myAnswers.Q34 = true;
                    hasCondition = true;
                }
                if (Q35.Text.ToLower().Equals("yes"))
                {
                    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("35. Do you or any person named in this application have any other medical conditions which have not yet been previously mentioned?", "Q35", true);
                    li.Selected = true;
                    myAnswers.addAnswer(li);
                    myAnswers.Q35 = true;
                    hasCondition = true;
                }

                Session.Add("HealthInformationAnswers", myAnswers);

                if (!hasCondition)
                {
                    if (Session["HealthStatements"] != null)
                    {
                        Session.Remove("HealthStatements");
                    }
                    UserWizard1.ActiveStepIndex = 12;
                }

                else
                {
                    //Response.Redirect("~/NebraskaApp/HealthExplanations.aspx", false);

                    HealthStatements hs = new HealthStatements();

                    HealthStatement mystatem = new HealthStatement();

                    mystatem.Condition = "Text";
                    mystatem.DateDiagnosed = "Date";
                    mystatem.DateLastTreated = "Date";
                    mystatem.IsMedication = false;
                    mystatem.Name = "Foo";
                    mystatem.Question = "Question?";
                    mystatem.QuestionNum = "1a";
                    mystatem.Recovery = "sdfshjdlkf";
                    mystatem.RowID = 1;
                    mystatem.TreatmentType = "jdflskdj";

                    //hs.addStatement(mystatem);

                    if (Session["HealthStatements"] == null)
                    {
                        Session.Add("HealthStatements", hs);
                    }
                    ObjectDataSource1.Select();
                }
            }
            #endregion

            #region Health Explanations
            else if (UserWizard1.ActiveStepIndex == 11)
            {
                HealthStatements myStatements = new HealthStatements();
                /*foreach (KeyValuePair<int, string> id in ControlIdList)
                {
                    DynamicTableControl control = (DynamicTableControl)m_controls[id.Key];
                    foreach (int id2 in control.RowIdList)
                    {
                        RowControl r = (RowControl)control.MyRows[id2];
                        HealthStatement myStatement = r.getHealthStatement();
                        myStatement.QuestionNum = id.Value.Split('.')[0];
                        myStatement.Question = id.Value;
                        myStatement.RowID = id2;
                        myStatements.addStatement(myStatement);
                    }
                }*/

                if (Session["HealthStatements"] != null)
                {
                    //Session.Add("HealthStatements", myStatements);
                }
                else
                {
                    //Session["HealthStatements"] = myStatements;
                }

                
            }
            #endregion

            #region Processing
            else if (UserWizard1.ActiveStepIndex == 12)
            {
                fillPdf();
            }
            #endregion

            #region Review And Sign
            else if (UserWizard1.ActiveStepIndex == 13)
            {
                //Simply pass control to next step.
            }
            #endregion

        }

        protected void UserWizard1_PreviousButtonClick(object sender, EventArgs e)
        {
            //ViewState is helpful here, is saving everything on returns.
            //Only need to handle special cases here. I.e. Employee Data fields for SSN.
        }

        protected void UserWizard1_ActiveStepChanged(object sender, EventArgs e)
        {
            #region Generic Page Updates
            //Update the title.
            String title = UserWizard1.ActiveStep.Title;
            int firstSpace = title.IndexOf(' ');

            header.InnerHtml = "<span class=\"red\">" + title.Substring(0, firstSpace) + "</span>" + title.Substring(firstSpace);

            this.Title = "e-Enroll :: " + title;
            #endregion

            //ONLOADs from other pages.
            //!! TODO Optimize this and remove any redundant code, i.e. logout if invalid

            #region Basic Info
            if (UserWizard1.ActiveStepIndex == 0)
            {
                if (Session["ClientID"] == null && Session["UserID"] == null)
                {
                    Response.Redirect("~/Default.aspx?timeout=1");
                }
            }
            #endregion

            #region Employee Data
            if (UserWizard1.ActiveStepIndex == 1)
            {
                if (Session["EmployeeData"] != null)
                {
                    employeeData myData = (employeeData)Session["EmployeeData"];

                    txtEmployeeName.Text = myData.EmployeeName;
                    txtAddress.Text = myData.HomeAddress;
                    txtCity.Text = myData.City;
                    txtState.Text = myData.State;
                    txtZip.Text = myData.Zip;
                    if (myData.HomePhone != "" && myData.WorkPhone != "")
                    {
                        txtHomePhone.Text = myData.HomePhone.Split('-')[0];
                        txtHomePhone0.Text = myData.HomePhone.Split('-')[1];
                        txtHomePhone1.Text = myData.HomePhone.Split('-')[2];
                        txtWorkPhone.Text = myData.WorkPhone.Split('-')[0];
                        txtWorkPhone0.Text = myData.WorkPhone.Split('-')[1];
                        txtWorkPhone1.Text = myData.WorkPhone.Split('-')[2];
                    }
                    txtEmail.Text = myData.Email;
                    txtDOB.Text = myData.DOB;
                    txtHeight.Text = myData.Height;
                    txtWeight.Text = myData.Weight;
                    //txtSoc.Text = myData.Soc;
                    txtTitle.Text = myData.JobTitle;
                    txtHireDate.Text = myData.DOH;
                    txtHours.Text = myData.AvgHours;
                    txtSalary.Text = myData.Salary;
                    //cmbStatus.SelectedValue = myData.EmploymentStatus;
                    //cmbMaritalStatus.SelectedValue = myData.MaritalStatus;
                    //cmbChildren.SelectedValue = myData.NumChildren.ToString();
                    txtPhysician.Text = myData.PrimaryPhysician;

                    if (myData.Medicare)
                    {
                        cmbMedicare.SelectedValue = "yes";
                    }
                    else
                    {
                        cmbMedicare.SelectedValue = "no";
                    }
                    if (myData.Disabled)
                    {
                        cmbDisabled.SelectedValue = "yes";
                    }
                    else
                    {
                        cmbDisabled.SelectedValue = "no";
                    }
                    if (myData.Gender.Equals("male"))
                    {
                        cmbGender.SelectedValue = "Male";
                    }
                    else if (myData.Gender.Equals("female"))
                    {
                        cmbGender.SelectedValue = "Female";
                    }

                }
            }
            #endregion

            #region Coverage Selection
            if (UserWizard1.ActiveStepIndex == 2)
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
                            coverageItems.Add(new System.Web.UI.WebControls.ListItem("Decline", "Waive"));
                        }
                        else if (!myEmployeeData.MaritalStatus.ToLower().Equals("married"))
                        {
                            if (myEmployeeData.NumChildren == 0)
                            {
                                coverageItems.Add(new System.Web.UI.WebControls.ListItem("Employee", "Employee"));
                                coverageItems.Add(new System.Web.UI.WebControls.ListItem("Decline", "Waive"));
                            }
                            else
                            {
                                coverageItems.Add(new System.Web.UI.WebControls.ListItem("Employee", "Employee"));
                                coverageItems.Add(new System.Web.UI.WebControls.ListItem("Employee/Child(ren)", "Employee/Child(ren)"));
                                coverageItems.Add(new System.Web.UI.WebControls.ListItem("Decline", "Waive"));
                            }
                        }
                        else
                        {
                            if (myEmployeeData.NumChildren == 0)
                            {
                                coverageItems.Add(new System.Web.UI.WebControls.ListItem("Employee", "Employee"));
                                coverageItems.Add(new System.Web.UI.WebControls.ListItem("Employee/Spouse", "Employee/Spouse"));
                                coverageItems.Add(new System.Web.UI.WebControls.ListItem("Decline", "Waive"));
                            }
                            else
                            {
                                coverageItems.Add(new System.Web.UI.WebControls.ListItem("Employee", "Employee"));
                                coverageItems.Add(new System.Web.UI.WebControls.ListItem("Employee/Spouse", "Employee/Spouse"));
                                coverageItems.Add(new System.Web.UI.WebControls.ListItem("Employee/Child(ren)", "Employee/Child(ren)"));
                                coverageItems.Add(new System.Web.UI.WebControls.ListItem("Employee/Spouse/Child(ren)", "Employee/Spouse/Child(ren)"));
                                coverageItems.Add(new System.Web.UI.WebControls.ListItem("Decline", "Waive"));
                            }
                        }

                        if (cmbMedical.Items.Count - 1 != coverageItems.Count)
                        {
                            cmbMedical.Items.Clear();
                            cmbDental.Items.Clear();
                            cmbVision.Items.Clear();
                            cmbDisability.Items.Clear();
                            cmbLife.Items.Clear();

                            if (myCoverageOffered.IsMedical)
                            {
                                cmbMedical.Items.Add(new System.Web.UI.WebControls.ListItem("(Select)", "(Select)"));
                            }

                            if (myCoverageOffered.IsDental)
                            {
                                cmbDental.Items.Add(new System.Web.UI.WebControls.ListItem("(Select)", "(Select)"));
                            }
                            if (myCoverageOffered.IsVision)
                            {
                                cmbVision.Items.Add(new System.Web.UI.WebControls.ListItem("(Select)", "(Select)"));
                            }
                            if (myCoverageOffered.IsLife)
                            {
                                cmbLife.Items.Add(new System.Web.UI.WebControls.ListItem("(Select)", "(Select)"));
                            }

                            foreach (System.Web.UI.WebControls.ListItem li in coverageItems)
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
                                    cmbDisability.Items.Add(new System.Web.UI.WebControls.ListItem("(Select)", "(Select)"));
                                    cmbDisability.Items.Add(new System.Web.UI.WebControls.ListItem("Employee", "Employee"));
                                    //cmbDisability.Items.Add(new System.Web.UI.WebControls.ListItem("Employee/Long Term", "Employee/Long Term"));
                                    cmbDisability.Items.Add(new System.Web.UI.WebControls.ListItem("Decline", "Waive"));
                                }
                                else
                                {
                                    cmbDisability.Items.Add(new System.Web.UI.WebControls.ListItem("Decline", "Waive"));
                                    cmbDisability.SelectedValue = "Waive";
                                }
                            }
                            else
                                trDisability.Visible = false;
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
            #endregion

            #region Dependent Data
            if (UserWizard1.ActiveStepIndex == 3)
            {
                if (Session["UserID"] != null)
                {
                    employeeData myEmployeeData = (employeeData)Session["EmployeeData"];
                    Coverage myCoverage = (Coverage)Session["Coverage"];
                    isSpouse.Value = "0";
                    numChildren.Value = "0";
                    if (!myEmployeeData.IsSingle)
                    {
                        if (!myCoverage.isSpouseCovered())
                        {
                            trSpouseTitle.Visible = false;
                            trSpouse.Visible = false;
                            isSpouse.Value = "0";
                        }
                        else
                        {
                            isSpouse.Value = "1";
                        }
                    }
                    else
                    {
                        trSpouseTitle.Visible = false;
                        trSpouse.Visible = false;
                        isSpouse.Value = "0";

                    }
                    if (myEmployeeData.NumChildren != 0)
                    {
                        if (!myCoverage.isChildCovered())
                        {
                            trChildTitle.Visible = false;
                            trChildOne.Visible = false;
                            trChildTwo.Visible = false;
                            trChildThree.Visible = false;
                            trChildFour.Visible = false;
                            trChildFive.Visible = false;
                        }
                        else
                        {
                            numChildren.Value = myEmployeeData.NumChildren.ToString();
                            if (myEmployeeData.NumChildren == 1)
                            {
                                trChildTwo.Visible = false;
                                trChildThree.Visible = false;
                                trChildFour.Visible = false;
                                trChildFive.Visible = false;
                                numChildren.Value = "1";
                            }
                            else if (myEmployeeData.NumChildren == 2)
                            {
                                trChildThree.Visible = false;
                                trChildFour.Visible = false;
                                trChildFive.Visible = false;
                                numChildren.Value = "2";
                            }
                            else if (myEmployeeData.NumChildren == 3)
                            {
                                trChildFour.Visible = false;
                                trChildFive.Visible = false;
                                numChildren.Value = "3";
                            }
                            else if (myEmployeeData.NumChildren == 4)
                            {
                                trChildFive.Visible = false;
                                numChildren.Value = "4";
                            }
                            else
                            {
                                numChildren.Value = "5";
                            }
                        }
                    }
                    else
                    {
                        trChildTitle.Visible = false;
                        trChildOne.Visible = false;
                        trChildTwo.Visible = false;
                        trChildThree.Visible = false;
                        trChildFour.Visible = false;
                        trChildFive.Visible = false;
                    }
                }
            }
            #endregion

            #region Medical Waive
            if (UserWizard1.ActiveStepIndex == 4)
            {
                if (Session["UserID"] != null)
                {
                    if ((Session["EmployeeData"] != null) && (Session["Coverage"] != null))
                    {
                        Coverage myCoverage = (Coverage)Session["Coverage"];
                        if (myCoverage.isWaiving("Medical"))
                        {
                            tdMedical.InnerHtml = myCoverage.getWhoIsWaiving("Medical");
                        }
                        else
                        {
                            trMedical.Visible = false;
                        }

                    }
                }
            }
            #endregion

            #region Dental Waive
            if (UserWizard1.ActiveStepIndex == 5)
            {
                if (Session["UserID"] != null)
                {
                    if ((Session["EmployeeData"] != null) && (Session["Coverage"] != null))
                    {
                        Coverage myCoverage = (Coverage)Session["Coverage"];
                        if (myCoverage.isWaiving("Dental"))
                        {
                            tdDental.InnerHtml = myCoverage.getWhoIsWaiving("Dental");
                        }
                    }
                }
            }
            #endregion

            #region Vision Waive
            if (UserWizard1.ActiveStepIndex == 6)
            {
                if (Session["UserID"] != null)
                {
                    if ((Session["EmployeeData"] != null) && (Session["Coverage"] != null))
                    {
                        Coverage myCoverage = (Coverage)Session["Coverage"];
                        if (myCoverage.isWaiving("Vision"))
                        {
                            tdVision.InnerHtml = myCoverage.getWhoIsWaiving("Vision");
                        }

                    }
                }
            }
            #endregion

            #region Life Waive
            if (UserWizard1.ActiveStepIndex == 7)
            {
                if (Session["UserID"] != null)
                {
                    if ((Session["EmployeeData"] != null) && (Session["Coverage"] != null))
                    {
                        Coverage myCoverage = (Coverage)Session["Coverage"];
                        if (myCoverage.isWaiving("Life"))
                        {
                            tdLife.InnerHtml = myCoverage.getWhoIsWaiving("Life");
                        }

                    }
                }
            }
            #endregion

            #region Disability Waive
            if (UserWizard1.ActiveStepIndex == 8)
            {
                if (Session["UserID"] != null)
                {
                    if ((Session["EmployeeData"] != null) && (Session["Coverage"] != null))
                    {
                        Coverage myCoverage = (Coverage)Session["Coverage"];
                        if (myCoverage.isWaiving("Disability"))
                        {
                            tdDisability.InnerHtml = myCoverage.getWhoIsWaiving("Disability");
                        }
                        else
                        {
                            trMedical.Visible = false;
                        }

                    }
                }
            }
            #endregion

            #region Other Coverage
            if (UserWizard1.ActiveStepIndex == 9)
            {
                myIsLife.Value = "0";
                if (Session["UserID"] != null)
                {
                    if (Session["Coverage"] != null && Session["CoverageOffered"] != null)
                    {
                        Coverage myCoverage = (Coverage)Session["Coverage"];
                        coverageOffered myCoverageOffered = (coverageOffered)Session["CoverageOffered"];
                        if (myCoverageOffered.IsLife)
                        {
                            if (!myCoverage.isWaiving("Life"))
                            {
                                myIsLife.Value = "1";
                            }
                        }
                    }
                    else Response.Redirect("~/Default.aspx");
                }
            }
            #endregion

            #region HealthInformation
            if (UserWizard1.ActiveStepIndex == 10)
            {
                CheckBoxList1.Attributes.Add("onClick", "toggleDueDate();");
            }
            #endregion

            #region Health Explanations
            if (UserWizard1.ActiveStepIndex == 11)
            {
                if (!IsPostBack || IsPostBack )
                {
                    HealthInformationAnswers hia = (HealthInformationAnswers)(Session["HealthInformationAnswers"]);
                    cmbQuestion.Items.Clear();
                    if (hia != null)
                    {
                        foreach (System.Web.UI.WebControls.ListItem answer in hia.MyAnswers)
                        {
                            String text, value;

                            value = answer.Value.Split('.')[0];
                            text = answer.Value.Split('.')[1].Trim();

                            cmbQuestion.Items.Add(new System.Web.UI.WebControls.ListItem(text, value));
                        }

                        NumExplanationsRequired.Value = cmbQuestion.Items.Count.ToString();
                    }

                    cmbPersonName.Items.Clear();

                    employeeData employee = (employeeData)(Session["EmployeeData"]);
                    cmbPersonName.Items.Add(txtFirstName.Text);
                    
                    if (Session["Dependents"] != null)
                    {
                        Dependents dd = (Dependents)(Session["Dependents"]);

                        if (isSpouse.Value == "1")
                        {
                            cmbPersonName.Items.Add(dd.getSpouse().Name);
                        }
                        
                        if (isChildren.Value == "true")
                        {
                            List<Dependent> dep = dd.getDependents();
                            foreach (Dependent d in dep)
                            {
                                cmbPersonName.Items.Add(d.Name);
                            }
                        }
                    }

                    if (Session["HealthStatements"] == null)
                    {
                        Session.Add("HealthStatements", new HealthStatements());
                    }

                    //Update validation information
                    UpdateExplanationValidationField();
                }
            }
            #endregion

            #region Processing
            if (UserWizard1.ActiveStepIndex == 12)
            {
                if (Session["UserID"] == null)
                {
                    Response.Redirect("~/Default.aspx?timeout=1", false);
                }
            }
            #endregion

            #region Review And Sign
            if (UserWizard1.ActiveStepIndex == 13)
            {
                //frame1.Attributes["src"] = "https://enrolltest.ociservices.com/NebraskaApp/preview.aspx";
                frame1.Attributes["src"] = "http://localhost:4242/NebraskaApp/preview.aspx";
            }
            #endregion

            #region Sign Application
            if (UserWizard1.ActiveStepIndex == 14)
            {
            }
            #endregion

        }

        #region Supporting Methods

        protected void fillPdf()
        {
            ElectronicAppDBDataContext eappdb = new ElectronicAppDBDataContext();

            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Default.aspx?timeout=1", false);
            }

            FillPDF myPDF = new FillPDF(Server.MapPath("~/NebraskaApp/App/"));
            if (Session["EmployeeData"] != null)
            {
                employeeData myEmployeeData = (employeeData)Session["EmployeeData"];
                myPDF.fillEmployeeData(myEmployeeData);
            }
            #region Fill Waiver Sections

            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Default.aspx?timeout=1", false);
            }
            if (Session["Coverage"] != null && Session["CoverageOffered"] != null)
            {
                Coverage myCoverage = (Coverage)Session["Coverage"];
                coverageOffered myOffered = (coverageOffered)Session["CoverageOffered"];
                if (myOffered.IsMedical)
                {
                    if (myCoverage.isWaiving("Medical"))
                    {
                        DeclineReason myReason = (DeclineReason)Session["ReasonForDeclineHealth"];
                        myPDF.FillOutReasons(myReason, myCoverage, "Medical");
                    }
                }

                if (myOffered.IsDental)
                {
                    if (myCoverage.isWaiving("Dental"))
                    {
                        DeclineReason myReason = (DeclineReason)Session["ReasonForDeclineDental"];
                        myPDF.FillOutReasons(myReason, myCoverage, "Dental");
                    }
                }
                if (myOffered.IsLife)
                {
                    if (myCoverage.isWaiving("Life"))
                    {
                        DeclineReason myReason = (DeclineReason)Session["ReasonForDeclineLife"];
                        myPDF.FillOutReasons(myReason, myCoverage, "Life");
                    }
                }

                if (myOffered.IsVision)
                {
                    if (myCoverage.isWaiving("Vision"))
                    {
                        DeclineReason myReason = (DeclineReason)Session["ReasonForDeclineVision"];
                        myPDF.FillOutReasons(myReason, myCoverage, "Vision");
                    }
                }

                if (myOffered.IsDisability)
                {
                    if (myCoverage.isWaiving("Disability"))
                    {
                        DeclineReason myReason = (DeclineReason)Session["ReasonForDeclineDisability"];
                        myPDF.FillOutReasons(myReason, myCoverage, "Disability");
                    }
                }
            }
            #endregion

            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Default.aspx?timeout=1", false);
            }
            if (Session["Coverage"] != null)
            {
                Coverage myCoverage = (Coverage)Session["Coverage"];
                myPDF.FillSelectedCoverage(myCoverage);
            }

            #region Fill Dependents
            if (Session["Dependents"] != null)
            {
                Dependents myDepenedents = (Dependents)Session["Dependents"];
                myPDF.FillDependentData(myDepenedents);
            }
            #endregion

            #region Fill Other Coverage
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Default.aspx?timeout=1", false);
            }
            if (Session["MedicareCoverage"] != null)
            {
                MedicareCoverage myMedicare = (MedicareCoverage)Session["MedicareCoverage"];
                myPDF.FillMedicare(myMedicare);
            }

            if (Session["ConcurrentCoverage"] != null)
            {
                ConcurrentCoverage myCC = (ConcurrentCoverage)Session["ConcurrentCoverage"];
                myPDF.FillConcurrent(myCC);
            }
            else
            {
                myPDF.FillConcurrent();
            }

            if (Session["PreviousCoverage"] != null)
            {
                PreviousCoverage myPrevious = (PreviousCoverage)Session["PreviousCoverage"];
                myPDF.FillPrevious(myPrevious);
            }
            else
            {
                myPDF.FillPrevious();
            }

            if (Session["LifeBeneficiaries"] != null)
            {
                LifeBeneficiaries myBeneficiaries = (LifeBeneficiaries)Session["LifeBeneficiaries"];
                myPDF.FillBeneficiaries(myBeneficiaries);
            }
            #endregion

            #region Fill Health Information
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Default.aspx?timeout=1", false);
            }
            if (Session["HealthInformationAnswers"] != null)
            {
                HealthInformationAnswers myHealth = (HealthInformationAnswers)Session["HealthInformationAnswers"];
                myPDF.FillHealthInformation(myHealth);
            }
            #endregion

            #region fill employer info
            ElectronicAppDBDataContext db = new ElectronicAppDBDataContext();
            uspGetClientContactResult myEmployerInfo = db.uspGetClientContact((Guid)Session["ClientID"]).First<uspGetClientContactResult>();
            myPDF.fillEmployerData(myEmployerInfo, (uspGetClientByIDResult)Session["Client"]);
            #endregion

            #region Fill Health Statements
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Default.aspx?timeout=1", false);
            }
            if (Session["HealthStatements"] != null)
            {
                HealthStatements myStatements = (HealthStatements)Session["HealthStatements"];
                myPDF.FillHealthStatements(myStatements);
            }
            #endregion

            Guid clientID = (Guid)(Session["ClientID"]);
            System.Collections.Generic.List<String> lstCarriers = new System.Collections.Generic.List<String>();

            foreach (uspGetClientCarriersResult carrier in eappdb.uspGetClientCarriers(clientID))
            {
                lstCarriers.Add(carrier.carrierName);
            }

            myPDF.fillCarriers(lstCarriers);


            myPDF.close();
            myPDF.addAdditionalPages();
            ByteBuffer filledPDF = myPDF.GetFilledPDFFlattened();
            Session.Add("Buffer", filledPDF);

            ByteBuffer unflattened = myPDF.GetFilledPDFUnflattened();
            Session.Add("PDF", unflattened);

        }

        #region Decline Reasons Methods
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

        //Dental Form
        protected DeclineReason saveReasons0()
        {
            DeclineReason myReason = new DeclineReason();
            //Store reasons in decline reason object
            if (RadioButton1.Checked)
            {
                myReason.SpousePlan = true;
            }
            if (RadioButton3.Checked)
            {
                myReason.Medicare = true;
            }
            if (RadioButton5.Checked)
            {
                myReason.COBRA = true;
            }
            if (RadioButton7.Checked)
            {
                myReason.NoCoverage = true;
            }
            if (RadioButton9.Checked)
            {
                myReason.Disability = true;
            }
            if (RadioButton2.Checked)
            {
                myReason.Individual = true;
            }
            if (RadioButton4.Checked)
            {
                myReason.VA = true;
            }
            if (RadioButton6.Checked)
            {
                myReason.TriCare = true;
            }
            if (RadioButton8.Checked)
            {
                myReason.Medicaid = true;
            }
            if (RadioButton10.Checked)
            {
                myReason.Other = true;
                myReason.Explanation = TextBox1.Text;
            }
            return myReason;
        }

        //Vision Form
        protected DeclineReason saveReasons1()
        {
            DeclineReason myReason = new DeclineReason();
            //Store reasons in decline reason object
            if (RadioButton11.Checked)
            {
                myReason.SpousePlan = true;
            }
            if (RadioButton13.Checked)
            {
                myReason.Medicare = true;
            }
            if (RadioButton15.Checked)
            {
                myReason.COBRA = true;
            }
            if (RadioButton17.Checked)
            {
                myReason.NoCoverage = true;
            }
            if (RadioButton19.Checked)
            {
                myReason.Disability = true;
            }
            if (RadioButton12.Checked)
            {
                myReason.Individual = true;
            }
            if (RadioButton14.Checked)
            {
                myReason.VA = true;
            }
            if (RadioButton16.Checked)
            {
                myReason.TriCare = true;
            }
            if (RadioButton18.Checked)
            {
                myReason.Medicaid = true;
            }
            if (RadioButton20.Checked)
            {
                myReason.Other = true;
                myReason.Explanation = TextBox2.Text;
            }
            return myReason;
        }

        //Life Form
        protected DeclineReason saveReasons2()
        {
            DeclineReason myReason = new DeclineReason();
            //Store reasons in decline reason object
            if (RadioButton21.Checked)
            {
                myReason.SpousePlan = true;
            }
            if (RadioButton23.Checked)
            {
                myReason.Medicare = true;
            }
            if (RadioButton25.Checked)
            {
                myReason.COBRA = true;
            }
            if (RadioButton27.Checked)
            {
                myReason.NoCoverage = true;
            }
            if (RadioButton29.Checked)
            {
                myReason.Disability = true;
            }
            if (RadioButton22.Checked)
            {
                myReason.Individual = true;
            }
            if (RadioButton24.Checked)
            {
                myReason.VA = true;
            }
            if (RadioButton26.Checked)
            {
                myReason.TriCare = true;
            }
            if (RadioButton28.Checked)
            {
                myReason.Medicaid = true;
            }
            if (RadioButton20.Checked)
            {
                myReason.Other = true;
                myReason.Explanation = TextBox3.Text;
            }
            return myReason;
        }

        //Disability Form
        protected DeclineReason saveReasons3()
        {
            DeclineReason myReason = new DeclineReason();
            //Store reasons in decline reason object
            if (RadioButton31.Checked)
            {
                myReason.SpousePlan = true;
            }
            if (RadioButton33.Checked)
            {
                myReason.Medicare = true;
            }
            if (RadioButton35.Checked)
            {
                myReason.COBRA = true;
            }
            if (RadioButton37.Checked)
            {
                myReason.NoCoverage = true;
            }
            if (RadioButton39.Checked)
            {
                myReason.Disability = true;
            }
            if (RadioButton32.Checked)
            {
                myReason.Individual = true;
            }
            if (RadioButton34.Checked)
            {
                myReason.VA = true;
            }
            if (RadioButton36.Checked)
            {
                myReason.TriCare = true;
            }
            if (RadioButton38.Checked)
            {
                myReason.Medicaid = true;
            }
            if (RadioButton40.Checked)
            {
                myReason.Other = true;
                myReason.Explanation = TextBox4.Text;
            }
            return myReason;
        }
        
        #endregion

        protected void getChildren(Dependents d)
        {
            int numberOfChildren = int.Parse(numChildren.Value);
            if (numberOfChildren >= 1)
            {
                Dependent myDependent = new Dependent();
                myDependent.IsSpouse = false;
                myDependent.Name = ch1Name.Text;
                if (ch1Gender.Text.ToLower().Equals("male"))
                {
                    myDependent.Gender = 'M';
                }
                else if (ch1Gender.Text.ToLower().Equals("female"))
                {
                    myDependent.Gender = 'F';
                }
                myDependent.Height = ch1Height.Text;
                myDependent.Weight = ch1Weight.Text;
                myDependent.DOB = ch1DOB.Text;
                myDependent.SSN = ch1SSN.Text;
                myDependent.PrimaryCarePhysician = ch1Physician.Text;
                if (ch1Student.Text.ToLower().Equals("yes"))
                {
                    myDependent.Student = true;
                }
                else
                {
                    myDependent.Student = false;
                }
                if (ch1Medicare.Text.ToLower().Equals("yes"))
                {
                    myDependent.Medicare = true;
                }
                else
                {
                    myDependent.Medicare = false;
                }
                if (ch1SS.Text.ToLower().Equals("yes"))
                {
                    myDependent.SSEnrolled = true;
                }
                else
                {
                    myDependent.SSEnrolled = false;
                }
                d.addDependent(myDependent);
            }

            if (numberOfChildren >= 2)
            {
                Dependent myDependent = new Dependent();
                myDependent.IsSpouse = false;
                myDependent.Name = ch2Name.Text;
                if (ch2Gender.Text.ToLower().Equals("male"))
                {
                    myDependent.Gender = 'M';
                }
                else if (ch2Gender.Text.ToLower().Equals("female"))
                {
                    myDependent.Gender = 'F';
                }
                myDependent.Height = ch2Height.Text;
                myDependent.Weight = ch2Weight.Text;
                myDependent.DOB = ch2DOB.Text;
                myDependent.SSN = ch2SSN.Text;
                myDependent.PrimaryCarePhysician = ch2Physician.Text;
                if (ch2Student.Text.ToLower().Equals("yes"))
                {
                    myDependent.Student = true;
                }
                else
                {
                    myDependent.Student = false;
                }
                if (ch2Medicare.Text.ToLower().Equals("yes"))
                {
                    myDependent.Medicare = true;
                }
                else
                {
                    myDependent.Medicare = false;
                }
                if (ch2SS.Text.ToLower().Equals("yes"))
                {
                    myDependent.SSEnrolled = true;
                }
                else
                {
                    myDependent.SSEnrolled = false;
                }
                d.addDependent(myDependent);
            }
            if (numberOfChildren >= 3)
            {
                Dependent myDependent = new Dependent();
                myDependent.IsSpouse = false;
                myDependent.Name = ch3Name.Text;
                if (ch3Gender.Text.ToLower().Equals("male"))
                {
                    myDependent.Gender = 'M';
                }
                else if (ch3Gender.Text.ToLower().Equals("female"))
                {
                    myDependent.Gender = 'F';
                }
                myDependent.Height = ch3Height.Text;
                myDependent.Weight = ch3Weight.Text;
                myDependent.DOB = ch3DOB.Text;
                myDependent.SSN = ch3SSN.Text;
                myDependent.PrimaryCarePhysician = ch3Physician.Text;
                if (ch3Student.Text.ToLower().Equals("yes"))
                {
                    myDependent.Student = true;
                }
                else
                {
                    myDependent.Student = false;
                }
                if (ch3Medicare.Text.ToLower().Equals("yes"))
                {
                    myDependent.Medicare = true;
                }
                else
                {
                    myDependent.Medicare = false;
                }
                if (ch3SS.Text.ToLower().Equals("yes"))
                {
                    myDependent.SSEnrolled = true;
                }
                else
                {
                    myDependent.SSEnrolled = false;
                }
                d.addDependent(myDependent);
            }
            if (numberOfChildren >= 4)
            {
                Dependent myDependent = new Dependent();
                myDependent.IsSpouse = false;
                myDependent.Name = ch4Name.Text;
                if (ch4Gender.Text.ToLower().Equals("male"))
                {
                    myDependent.Gender = 'M';
                }
                else if (ch4Gender.Text.ToLower().Equals("female"))
                {
                    myDependent.Gender = 'F';
                }
                myDependent.Height = ch4Height.Text;
                myDependent.Weight = ch4Weight.Text;
                myDependent.DOB = ch4DOB.Text;
                myDependent.SSN = ch4SSN.Text;
                myDependent.PrimaryCarePhysician = ch4Physician.Text;
                if (ch4Student.Text.ToLower().Equals("yes"))
                {
                    myDependent.Student = true;
                }
                else
                {
                    myDependent.Student = false;
                }
                if (ch4Medicare.Text.ToLower().Equals("yes"))
                {
                    myDependent.Medicare = true;
                }
                else
                {
                    myDependent.Medicare = false;
                }
                if (ch4SS.Text.ToLower().Equals("yes"))
                {
                    myDependent.SSEnrolled = true;
                }
                else
                {
                    myDependent.SSEnrolled = false;
                }
                d.addDependent(myDependent);
            }
            if (numberOfChildren == 5)
            {
                Dependent myDependent = new Dependent();
                myDependent.IsSpouse = false;
                myDependent.Name = ch5Name.Text;
                if (ch5Gender.Text.ToLower().Equals("male"))
                {
                    myDependent.Gender = 'M';
                }
                else if (ch5Gender.Text.ToLower().Equals("female"))
                {
                    myDependent.Gender = 'F';
                }
                myDependent.Height = ch5Height.Text;
                myDependent.Weight = ch5Weight.Text;
                myDependent.DOB = ch5DOB.Text;
                myDependent.SSN = ch5SSN.Text;
                myDependent.PrimaryCarePhysician = ch5Physician.Text;
                if (ch5Student.Text.ToLower().Equals("yes"))
                {
                    myDependent.Student = true;
                }
                else
                {
                    myDependent.Student = false;
                }
                if (ch5Medicare.Text.ToLower().Equals("yes"))
                {
                    myDependent.Medicare = true;
                }
                else
                {
                    myDependent.Medicare = false;
                }
                if (ch5SS.Text.ToLower().Equals("yes"))
                {
                    myDependent.SSEnrolled = true;
                }
                else
                {
                    myDependent.SSEnrolled = false;
                }
                d.addDependent(myDependent);
            }
        }

        #endregion


        protected void GridView1_SelectedIndexChanged(Object sender, EventArgs e)
        {

            /*ObjectDataSource2.DataBind();
            dvCondition.DataBind();
            dvCondition.Style["Display"] = "block";*/

            //NOTE: Set up fields here.

            mdlPopup.Show();

            isEdit = true;
            isAdd = false;
            isEditOrAdd.Value = "Edit";


            HealthStatementData hsd = new HealthStatementData();

            HealthInformationAnswers hia = (HealthInformationAnswers)(Session["HealthInformationAnswers"]);

            HealthStatement hs = hsd.getStatementByRowID(Convert.ToInt32(GridView1.DataKeys[GridView1.SelectedIndex].Value));

            cmbQuestion.SelectedIndex = cmbQuestion.Items.IndexOf(new System.Web.UI.WebControls.ListItem(hs.Question, hs.QuestionNum));
            cmbPersonName.SelectedIndex = cmbPersonName.Items.IndexOf(new System.Web.UI.WebControls.ListItem(hs.Name));

            chkOngoing.Checked = hs.IsMedication;
            txtMeds.Text = hs.TreatmentType;
            txtDateDiagnosed.Text = hs.DateDiagnosed;
            txtDateLastTreated.Text = hs.DateLastTreated;
            txtDegreeOfRecovery.Text = hs.Recovery;
            indexes.Value = hs.RowID.ToString();
            txtCondition.Text = hs.Condition;

            UpdatePanel1.Update();

        }

        protected void ObjectDataSource2_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["RowID"] = Convert.ToString(GridView1.DataKeys[GridView1.SelectedIndex].Value);
        }

        protected void ObjectDataSource2_Selected(object sender, EventArgs e)
        {
            //dvCondition.DataBind();
            //dvCondition.Style["Display"] = "block";
            mdlPopup.Show();

            c_resultLabel.Text = GridView1.DataKeys[GridView1.SelectedIndex].Value.ToString();
        }

        protected void btnEdit_Click(Object sender, EventArgs e)
        {
            

        }

        protected void btnDel_Click(Object sender, EventArgs e)
        {
        }

        protected void btnSave_Click(Object sender, EventArgs e)
        {

            HealthStatementData hsd = new HealthStatementData();

            HealthStatement newStatement = new HealthStatement();
            int num1;

            int.TryParse(indexes.Value, out num1);

            newStatement.RowID = num1;
            newStatement.QuestionNum = cmbQuestion.SelectedItem.Value;
            newStatement.Question = cmbQuestion.SelectedItem.Text;
            newStatement.IsMedication = chkOngoing.Checked;
            newStatement.Name = cmbPersonName.SelectedItem.Text;
            newStatement.Condition = txtCondition.Text;
            newStatement.DateDiagnosed = txtDateDiagnosed.Text;
            newStatement.DateLastTreated = txtDateLastTreated.Text;
            newStatement.Recovery = txtDegreeOfRecovery.Text;
            newStatement.TreatmentType = txtMeds.Text;

            if (isEditOrAdd.Value.Equals("Add"))
            {
                //dvCondition.InsertItem(false);

                hsd.InsertEntry(newStatement);
            }

            else if (isEditOrAdd.Value.Equals("Edit"))
            {
                //dvCondition.UpdateItem(false);

                hsd.UpdateEntry(newStatement);
            }

            isEdit = false;
            isAdd = false;
            isEditOrAdd.Value = "none";
            
            //Update validation information
            UpdateExplanationValidationField();

            ObjectDataSource1.Select();
            ObjectDataSource1.DataBind();
            GridView1.DataBind();
            UpdatePanel1.Update();
        }

        protected void UpdateExplanationValidationField()
        {
            HealthStatements collection = (HealthStatements)(Session["HealthStatements"]);
            List<String> QuestionsToAnswer = new List<String>();

            foreach (System.Web.UI.WebControls.ListItem li in cmbQuestion.Items)
            {
                if (!QuestionsToAnswer.Contains(li.Value))
                {
                    QuestionsToAnswer.Add(li.Value);
                }
            }

            foreach (HealthStatement hs in collection.MyHealthStatements)
            {
                if (QuestionsToAnswer.Contains(hs.QuestionNum))
                {
                    QuestionsToAnswer.Remove(hs.QuestionNum);
                }
            }

            //Update field used for validation.
            NumExplanationsRequired.Value = QuestionsToAnswer.Count.ToString();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            HealthStatementData hsd = new HealthStatementData();
            HealthStatement hs = new HealthStatement();
            hs.RowID = Convert.ToInt32(e.Keys[e.RowIndex]);

            hsd.DeleteEntry(hs);

            //Update validation information
            UpdateExplanationValidationField();
            
            //e.Keys[e.RowIndex]
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //dvCondition.DataBind();
            
            //dvCondition.Style["Display"] = "block";
            mdlPopup.Show();
            isAdd = true;
            isEdit = false;
            isEditOrAdd.Value = "Add";
            HealthStatementData hsd = new HealthStatementData();
            cmbQuestion.SelectedIndex = 0;
            cmbPersonName.SelectedIndex = 0;
            chkOngoing.Checked = false;
            txtCondition.Text = "";
            txtMeds.Text = "";
            txtDateDiagnosed.Text = "";
            txtDateLastTreated.Text = "";
            txtDegreeOfRecovery.Text = "";
            indexes.Value = hsd.NextIndex.ToString();
            UpdatePanel1.Update();

        }

    }
}
