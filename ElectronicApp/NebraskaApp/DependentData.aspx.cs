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
    public partial class DependentData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnNext.Attributes.Add("onClick", "return valSubmit();");
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

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                Dependents myDependents = new Dependents();
                if (isSpouse.Value.Equals("1"))
                {
                    Dependent myDependent = new Dependent();
                    myDependent.IsSpouse = true;
                    myDependent.Name = spName.Text;
                    if(spGender.Text.ToLower().Equals("male"))
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
                    getChildren( myDependents );
                }
                if (Session["Dependents"] != null)
                {
                    Session["Dependents"] = myDependents;
                }
                else
                {
                    Session.Add("Dependents", myDependents);
                }
                Response.Redirect("OtherCoverage.aspx");
                    
            }         
        }
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
    }
}
