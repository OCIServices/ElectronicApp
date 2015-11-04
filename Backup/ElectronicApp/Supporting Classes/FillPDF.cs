using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ElectronicApp.Supporting_Classes;
using ElectronicApp.NebraskaApp.Controls;
using System.Text;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using System.Collections.Generic;
using System.Collections;

namespace ElectronicApp.Supporting_Classes
{
    public class FillPDF
    {
        private ByteBuffer myPDF;
        private PdfStamper pdfStamper;
        private PdfReader pdfreader;
        private AcroFields pdfFormFields;
        private string pdfTemplate;
        private List<ByteBuffer> additionalHealthAnswers;

        public FillPDF(string template)
        {
            pdfTemplate = template;
            pdfreader = new PdfReader(pdfTemplate + "blankapp.pdf");
            myPDF = new ByteBuffer();
            pdfStamper = new PdfStamper(pdfreader, myPDF);
            pdfFormFields = pdfStamper.AcroFields;

            additionalHealthAnswers = new List<ByteBuffer>();
           
            
            foreach (DictionaryEntry f in pdfreader.AcroFields.Fields)
            {
                pdfFormFields.SetFieldProperty(f.Key.ToString(), "textsize", (float)0.0, null);
            }
        }

        public ByteBuffer GetFilledPDFUnflattened()
        {
            ByteBuffer temp = new ByteBuffer();
            PdfReader myReader = new PdfReader(myPDF.Buffer);
            PdfStamper myStamper = new PdfStamper(myReader, temp);
            myStamper.FormFlattening = false;
            myReader.Close();
            myStamper.Close();
            return temp;
        }

        public ByteBuffer GetFilledPDFFlattened()
        {
            ByteBuffer temp = new ByteBuffer();
            PdfReader myReader = new PdfReader(myPDF.Buffer);
            PdfStamper myStamper = new PdfStamper(myReader, temp);
            myStamper.FormFlattening = true;
            myReader.Close();
            myStamper.Close();
            return temp;
        }

        public void close()
        {
            pdfreader.Close();
            pdfStamper.Close();
        }

        public void addAdditionalPages()
        {
            if (additionalHealthAnswers.Count > 0)
            {
                ByteBuffer tmp = new ByteBuffer();
                PdfCopyFields copy = new PdfCopyFields(tmp);

                //Original App
                PdfReader reader = new PdfReader(myPDF.Buffer);
                copy.AddDocument(reader);
                reader.Close();

                //Add Aditional Pages
                foreach (ByteBuffer b in additionalHealthAnswers)
                {
                    reader = new PdfReader(b.Buffer);
                    copy.AddDocument(reader);
                    reader.Close();
                }
                copy.Close();
                myPDF = tmp;
            }
        }

        #region fill out employee data section
        public void fillEmployeeData(employeeData myEmployeeData)
        {
                if (!myEmployeeData.WaiveAll)
                {
                    pdfFormFields.SetField("employeename", myEmployeeData.EmployeeName);
                    pdfFormFields.SetField("employeeaddress", myEmployeeData.HomeAddress);
                    pdfFormFields.SetField("employeecity", myEmployeeData.City);
                    pdfFormFields.SetField("employeestate", myEmployeeData.State);
                    pdfFormFields.SetField("employeezip", myEmployeeData.Zip);
                    pdfFormFields.SetField("employeeworkphone", myEmployeeData.WorkPhone);
                    pdfFormFields.SetField("employeehomephone", myEmployeeData.HomePhone);
                    pdfFormFields.SetField("employeeemail", ""); //Need to add email somehow missed it
                    pdfFormFields.SetField("employeedateofbirth", myEmployeeData.DOB);
                    pdfFormFields.SetField("employeeheight", myEmployeeData.Height);
                    pdfFormFields.SetField("employeeweight", myEmployeeData.Weight);
                    pdfFormFields.SetField("employeessn", myEmployeeData.Soc);
                    pdfFormFields.SetField("employeejobtitle", myEmployeeData.JobTitle);
                    pdfFormFields.SetField("employeedateofhire", myEmployeeData.DOH);
                    pdfFormFields.SetField("employeeprimarycarephysician", myEmployeeData.PrimaryPhysician);
                    pdfFormFields.SetField("employeehoursworkedperweek", myEmployeeData.AvgHours);
                    pdfFormFields.SetField("employeewage", myEmployeeData.Salary);
                    pdfFormFields.SetField("employeehoursworkedperweek", myEmployeeData.AvgHours);
                    if (myEmployeeData.EmploymentStatus == "Full-Time")
                    {
                        pdfFormFields.SetField("employeeemploymentstatus1", "Yes");
                        pdfFormFields.SetField("employeeemploymentstatus2", "0");
                        pdfFormFields.SetField("employeeemploymentstatus3", "0");
                        pdfFormFields.SetField("employeeemploymentstatus4", "0");
                    }
                    else if (myEmployeeData.EmploymentStatus == "Part-Time")
                    {
                        pdfFormFields.SetField("employeeemploymentstatus1", "0");
                        pdfFormFields.SetField("employeeemploymentstatus2", "Yes");
                        pdfFormFields.SetField("employeeemploymentstatus3", "0");
                        pdfFormFields.SetField("employeeemploymentstatus4", "0");
                    }
                    else if (myEmployeeData.EmploymentStatus == "Retired")
                    {
                        pdfFormFields.SetField("employeeemploymentstatus1", "0");
                        pdfFormFields.SetField("employeeemploymentstatus2", "0");
                        pdfFormFields.SetField("employeeemploymentstatus3", "Yes");
                        pdfFormFields.SetField("employeeemploymentstatus4", "0");
                    }
                    else if (myEmployeeData.EmploymentStatus == "COBRA")
                    {
                        pdfFormFields.SetField("employeeemploymentstatus1", "0");
                        pdfFormFields.SetField("employeeemploymentstatus2", "0");
                        pdfFormFields.SetField("employeeemploymentstatus3", "0");
                        pdfFormFields.SetField("employeeemploymentstatus4", "Yes");
                    }

                    if (myEmployeeData.Disabled)
                    {
                        pdfFormFields.SetField("employeessdisabledyes", "Yes");
                        pdfFormFields.SetField("employeessdisabledno", "0");
                    }
                    else
                    {
                        pdfFormFields.SetField("employeessdisabledyes", "0");
                        pdfFormFields.SetField("employeessdisabledno", "Yes");
                    }

                    if (myEmployeeData.Medicare)
                    {
                        pdfFormFields.SetField("employeemedicareenrolledyes", "Yes");
                        pdfFormFields.SetField("employeemedicareenrolledno", "0");
                    }
                    else
                    {
                        pdfFormFields.SetField("employeemedicareenrolledyes", "0");
                        pdfFormFields.SetField("employeemedicareenrolledno", "Yes");
                    }

                    if (myEmployeeData.Gender.Equals("male", StringComparison.CurrentCultureIgnoreCase))
                    {
                        pdfFormFields.SetField("employeegenderyes", "Yes");
                        pdfFormFields.SetField("employeegenderno", "0");
                    }
                    else
                    {
                        pdfFormFields.SetField("employeegenderyes", "0");
                        pdfFormFields.SetField("employeegenderno", "Yes");
                    }


                    if (myEmployeeData.MaritalStatus.Equals("Married"))
                    {
                        pdfFormFields.SetField("employeemaritalstatus1", "Yes");
                        pdfFormFields.SetField("employeemaritalstatus2", "0");
                        pdfFormFields.SetField("employeemaritalstatus3", "0");
                        pdfFormFields.SetField("employeemaritalstatus4", "0");
                        pdfFormFields.SetField("employeemaritalstatus5", "0");
                    }
                    else if (myEmployeeData.MaritalStatus.Equals("Single"))
                    {
                        pdfFormFields.SetField("employeemaritalstatus1", "0");
                        pdfFormFields.SetField("employeemaritalstatus2", "Yes");
                        pdfFormFields.SetField("employeemaritalstatus3", "0");
                        pdfFormFields.SetField("employeemaritalstatus4", "0");
                        pdfFormFields.SetField("employeemaritalstatus5", "0");
                    }
                    else if (myEmployeeData.MaritalStatus.Equals("Divorced"))
                    {
                        pdfFormFields.SetField("employeemaritalstatus1", "0");
                        pdfFormFields.SetField("employeemaritalstatus2", "0");
                        pdfFormFields.SetField("employeemaritalstatus3", "Yes");
                        pdfFormFields.SetField("employeemaritalstatus4", "0");
                        pdfFormFields.SetField("employeemaritalstatus5", "0");
                    }
                    else if (myEmployeeData.MaritalStatus.Equals("Legally Separated"))
                    {
                        pdfFormFields.SetField("employeemaritalstatus1", "0");
                        pdfFormFields.SetField("employeemaritalstatus2", "0");
                        pdfFormFields.SetField("employeemaritalstatus3", "0");
                        pdfFormFields.SetField("employeemaritalstatus4", "Yes");
                        pdfFormFields.SetField("employeemaritalstatus5", "0");
                    }
                    else if (myEmployeeData.MaritalStatus.Equals("Widowed"))
                    {
                        pdfFormFields.SetField("employeemaritalstatus1", "0");
                        pdfFormFields.SetField("employeemaritalstatus2", "0");
                        pdfFormFields.SetField("employeemaritalstatus3", "0");
                        pdfFormFields.SetField("employeemaritalstatus4", "0");
                        pdfFormFields.SetField("employeemaritalstatus5", "Yes");
                    }
                }
                else
                {
                   //' waiveall = true;
                    pdfFormFields.SetField("employeename", myEmployeeData.EmployeeName);
                    pdfFormFields.SetField("employeedateofbirth", myEmployeeData.DOB);
                }
        }
        #endregion
        
        #region Fill Out Waiver Sections
        public void FillOutReasons(DeclineReason myReason, Coverage myCoverage,  string coverageType)
        {
            string prefixMed = "ocimedicaldecline";
            string prefixDental = "ocidentaldecline";
            string prefixLife = "ocilifedecline";
            string prefixVision = "ocivisiondecline";
            string myPrefix = "";

                if (coverageType == "Medical")
                {
                    myPrefix = prefixMed;
                    pdfFormFields.SetField("declineMed", "Yes");
                    pdfFormFields.SetField(myPrefix + "option", "Yes");
                }
            

                else if (coverageType == "Dental")
                {
                   myPrefix = prefixDental;
                   pdfFormFields.SetField("declineDental", "Yes");
                   pdfFormFields.SetField(myPrefix + "option", "Yes");
                }

                else if (coverageType == "Life")
                {
                    myPrefix = prefixLife;
                    pdfFormFields.SetField("declineLife", "Yes");
                    pdfFormFields.SetField(myPrefix + "option", "Yes");
                }

                else if (coverageType == "Vision")
                {
                    myPrefix = prefixVision;
                    pdfFormFields.SetField("declineVision", "Yes");
                    pdfFormFields.SetField(myPrefix + "option", "Yes");
                }

                else if (coverageType == "Disability")
                {
                    myPrefix = prefixVision;
                    pdfFormFields.SetField("declineDisability", "Yes");
                }

                if (coverageType != "Disablility")
                {
                    pdfFormFields.SetField(myPrefix + "names", myCoverage.getWhoIsWaiving(coverageType));
                }

            if (myReason.SpousePlan)
            {
                if (coverageType != "Disability")
                {
                    pdfFormFields.SetField(myPrefix + "01", "Yes");
                }
                pdfFormFields.SetField("decline06", "Yes");
            }
            if (myReason.Medicare)
            {
                if (coverageType != "Disability")
                {
                    pdfFormFields.SetField(myPrefix + "02", "Yes");
                }
                pdfFormFields.SetField("decline07", "Yes");
            }
            if (myReason.COBRA)
            {
                if (coverageType != "Disability")
                {
                    pdfFormFields.SetField(myPrefix + "03", "Yes");
                }
                pdfFormFields.SetField("decline08", "Yes");
            }
            if (myReason.NoCoverage)
            {
                if (coverageType != "Disability")
                {
                    pdfFormFields.SetField(myPrefix + "04", "Yes");
                }
                pdfFormFields.SetField("decline09", "Yes");
            }
            if (myReason.Disability)
            {
                pdfFormFields.SetField("decline10", "Yes");
            }
            if (myReason.Individual)
            {
                if (coverageType != "Disability")
                {
                    pdfFormFields.SetField(myPrefix + "05", "Yes");
                }
                pdfFormFields.SetField("decline11", "Yes");
            }
            if (myReason.VA)
            {
                if (coverageType != "Disability")
                {
                    pdfFormFields.SetField(myPrefix + "06", "Yes");
                }
                pdfFormFields.SetField("decline12", "Yes");
            }
            if (myReason.TriCare)
            {
                pdfFormFields.SetField("decline13", "Yes");
            }
            if (myReason.Medicaid)
            {
                if (coverageType != "Disability")
                {
                    pdfFormFields.SetField(myPrefix + "07", "Yes");
                }
                pdfFormFields.SetField("decline14", "Yes");
            }
            if (myReason.Other)
            {
                if (coverageType != "Disability")
                {
                    pdfFormFields.SetField(myPrefix + "08", "Yes");
                    pdfFormFields.SetField(myPrefix + "otherdescription", myReason.Explanation);
                }
                pdfFormFields.SetField("decline15", "Yes");
                pdfFormFields.SetField("decline15note", myReason.Explanation);
            }
        }
        #endregion

        #region fill out selected coverage section
        public void FillSelectedCoverage(Coverage myCoverage)
        {
            string prefixMed = "cselectedmedical";
            string prefixDental = "cselecteddental";
            string prefixLife = "cselectedlife";
            string prefixVision = "cselectedmedicalvision";
            string prefixDisability = "cselectedmedicaldisability";
            string myPrefix = "";

            List<CoverageItem> myCoverageItmes = myCoverage.CoverageItems;
            foreach (CoverageItem ci in myCoverageItmes)
            {
                if (ci.CoverageType == "Medical")
                {
                    myPrefix = prefixMed;
                }
                else if (ci.CoverageType == "Dental")
                {
                    myPrefix = prefixDental;
                }
                else if (ci.CoverageType == "Life")
                {
                    myPrefix = prefixLife;
                }
                else if (ci.CoverageType == "Vision")
                {
                    myPrefix = prefixVision;
                }
                else if (ci.CoverageType == "Disability")
                {
                    myPrefix = prefixDisability;
                }

                if (ci.CoverageType != "Disability")
                {
                    if(ci.CoverageSelected.Equals("employee", StringComparison.CurrentCultureIgnoreCase))
                    {
                        pdfFormFields.SetField(myPrefix + "1", "Yes");
                    }
                    else if (ci.CoverageSelected.Equals("employee/spouse", StringComparison.CurrentCultureIgnoreCase))
                    {
                        pdfFormFields.SetField(myPrefix + "2", "Yes");
                    }
                    else if (ci.CoverageSelected.Equals("employee/child(ren)", StringComparison.CurrentCultureIgnoreCase))
                    {
                        pdfFormFields.SetField(myPrefix + "3", "Yes");
                    }
                    else if (ci.CoverageSelected.Equals("employee/spouse/child(ren)", StringComparison.CurrentCultureIgnoreCase))
                    {
                        pdfFormFields.SetField(myPrefix + "4", "Yes");
                    }
                }
                else
                {
                    if (ci.CoverageSelected.Equals("employee", StringComparison.CurrentCultureIgnoreCase))
                    {
                        pdfFormFields.SetField(myPrefix + "1", "Yes");
                        pdfFormFields.SetField(myPrefix + "2", "Yes");
                    }
                    //else if (ci.CoverageSelected.Equals("employee/long term", StringComparison.CurrentCultureIgnoreCase))
                    //{
                    //    pdfFormFields.SetField(myPrefix + "2", "Yes");
                    //}
                }
            }
        }
        #endregion

        #region fill out other coverage section

        public void FillBeneficiaries(LifeBeneficiaries myBeneficiaries)
        {
            pdfFormFields.SetField("pbennameaddress1", myBeneficiaries.Primary1Name);
            pdfFormFields.SetField("pbennameaddress2", myBeneficiaries.Primary2Name);
            pdfFormFields.SetField("pbenperc1", myBeneficiaries.Primary1Percent);
            pdfFormFields.SetField("pbenperc2", myBeneficiaries.Primary2Percent);
            pdfFormFields.SetField("pbenrel1", myBeneficiaries.Primary1Relationship);
            pdfFormFields.SetField("pbenrel2", myBeneficiaries.Primary2Relationship);
            pdfFormFields.SetField("pbenssn1", myBeneficiaries.Primary1SSN);
            pdfFormFields.SetField("pbenssn2", myBeneficiaries.Primary2SSN);

            pdfFormFields.SetField("sbennameaddress1", myBeneficiaries.Secondary1Name);
            pdfFormFields.SetField("sbennameaddress2", myBeneficiaries.Secondary2Name);
            pdfFormFields.SetField("sbenperc1", myBeneficiaries.Secondary1Percent);
            pdfFormFields.SetField("sbenperc2", myBeneficiaries.Secondary2Percent);
            pdfFormFields.SetField("sbenrel1", myBeneficiaries.Secondary1Relationship);
            pdfFormFields.SetField("sbenrel2", myBeneficiaries.Secondary2Relationship);
            pdfFormFields.SetField("sbenssn1", myBeneficiaries.Secondary1SSN);
            pdfFormFields.SetField("sbenssn2", myBeneficiaries.Secondary2SSN);

        }

        public void FillMedicare(MedicareCoverage myMedicare)
        {
            pdfFormFields.SetField("medicarename", myMedicare.Name);
            pdfFormFields.SetField("medicareidnumber", myMedicare.ID);
            pdfFormFields.SetField("medicareeffectivedatea", myMedicare.EffDateA);
            pdfFormFields.SetField("medicareeffectivedateb", myMedicare.EffDateB);
            pdfFormFields.SetField("medicareeffectivedatec", myMedicare.EffDateC);
        }

        public void FillPrevious(PreviousCoverage myPrevious)
        {
            pdfFormFields.SetField("previoustriggeryes", "Yes");
            pdfFormFields.SetField("pcovcoveredpersons", myPrevious.Names);
            pdfFormFields.SetField("pcovemployer", myPrevious.Employer);
            pdfFormFields.SetField("pcovcarriernameandaddress", myPrevious.InsuranceCompanyName);
            pdfFormFields.SetField("pcovpolicynumber", myPrevious.Policy);
            pdfFormFields.SetField("pcoveffectivedate", myPrevious.EffectiveDate);
            pdfFormFields.SetField("pcovenddate", myPrevious.EndDate);

            if (myPrevious.IsEmployee)
            {
                pdfFormFields.SetField("pcovcoveragetype1", "Yes");
            }

            if (myPrevious.IsEmployeeSpouse)
            {
                pdfFormFields.SetField("pcovcoveragetype2", "Yes");
            }

            if (myPrevious.IsEmployeeChild)
            {
                pdfFormFields.SetField("pcovcoveragetype3", "Yes");
            }

            if (myPrevious.IsEmployeeSpouseChild)
            {
                pdfFormFields.SetField("pcovcoveragetype4", "Yes");
            }
        }

        public void FillConcurrent(ConcurrentCoverage myConcurrent)
        {
            if (myConcurrent.IsMedical)
            {
                pdfFormFields.SetField("medicarecc2", "Yes");
            }

            if (myConcurrent.IsDental)
            {
                pdfFormFields.SetField("medicarecc3", "Yes");
            }

            if (myConcurrent.IsLife)
            {
                pdfFormFields.SetField("medicarecc4", "Yes");
            }

            if (myConcurrent.IsVision)
            {
                pdfFormFields.SetField("medicarecc5", "Yes");
            }

            if (myConcurrent.IsDisability)
            {
                pdfFormFields.SetField("medicarecc6", "Yes");
            }

            if (myConcurrent.IsEmployee)
            {
                pdfFormFields.SetField("medicarecoveragetype1", "Yes");
            }

            if (myConcurrent.IsEmployeeSpouse)
            {
                pdfFormFields.SetField("medicarecoveragetype2", "Yes");
            }

            if (myConcurrent.IsEmployeeChild)
            {
                pdfFormFields.SetField("medicarecoveragetype3", "Yes");
            }

            if (myConcurrent.IsEmployeeSpouseChild)
            {
                pdfFormFields.SetField("medicarecoveragetype4", "Yes");
            }

            pdfFormFields.SetField("medicarecoveredpersons", myConcurrent.Name);
            pdfFormFields.SetField("medicareemployer", myConcurrent.Employer);
            pdfFormFields.SetField("medicarecarriernameandaddress", myConcurrent.InsuranceCompanyName);
            pdfFormFields.SetField("medicarepolicynumber", myConcurrent.PolicyNo);
            pdfFormFields.SetField("medicareeffectivedate", myConcurrent.EffectiveDate);
            pdfFormFields.SetField("medicareenddate", myConcurrent.EndDate);
        }

        #endregion

        #region fill out health information section
        public void FillHealthInformation(HealthInformationAnswers answers) {

            foreach (System.Web.UI.WebControls.ListItem answer in answers.MyAnswers){
                if (answer.Selected) {
                    String[] parts = answer.Text.Split('.');
                    String fieldnum = parts[0];

                    pdfFormFields.SetField("hi" + fieldnum, "Yes");
                }
            }

            if (answers.DueData != "")
            {
                pdfFormFields.SetField("hi9dd", answers.DueData);
            }

            if (answers.Q32)
            {
                pdfFormFields.SetField("hi32yes", "Yes");
            }
            else
            {
                pdfFormFields.SetField("hi32no", "Yes");
            }

            if (answers.Q33)
            {
                pdfFormFields.SetField("hi33yes", "Yes");
            }
            else
            {
                pdfFormFields.SetField("hi33no", "Yes");
            }

            if (answers.Q34)
            {
                pdfFormFields.SetField("hi34yes", "Yes");
            }
            else
            {
                pdfFormFields.SetField("hi34no", "Yes");
            }

            if (answers.Q35)
            {
                pdfFormFields.SetField("hi35yes", "Yes");
            }
            else
            {
                pdfFormFields.SetField("hi35no", "Yes");
            }

        }
        #endregion

        #region fill out dependent data section
        public void FillDependentData(Dependents myDependents)
        {
            if (myDependents.getSpouse() != null)
            {
                Dependent mySpouse = myDependents.getSpouse();
                pdfFormFields.SetField("dependentname1", mySpouse.Name);

                if (mySpouse.Gender.Equals('M'))
                {
                    pdfFormFields.SetField("dependentgender1male", "Yes");
                }
                else
                {
                    pdfFormFields.SetField("dependentgender1female", "Yes");
                }

                pdfFormFields.SetField("dependentheight1", mySpouse.Height);
                pdfFormFields.SetField("dependentweight1", mySpouse.Weight);
                pdfFormFields.SetField("dependentdob1", mySpouse.DOB);
                pdfFormFields.SetField("dependentssn1", mySpouse.SSN);
                pdfFormFields.SetField("dependentpcp1", mySpouse.PrimaryCarePhysician);

                if (mySpouse.Student)
                {
                    pdfFormFields.SetField("dependentfts1yes", "Yes");
                }
                else
                {
                    pdfFormFields.SetField("dependentfts1no", "Yes");
                }

                if (mySpouse.Medicare)
                {
                    pdfFormFields.SetField("dependentms1yes", "Yes");
                }
                else
                {
                    pdfFormFields.SetField("dependentms1no", "Yes");
                }

                if (mySpouse.SSEnrolled)
                {
                    pdfFormFields.SetField("dependentssenrolled1yes", "Yes");
                }
                else
                {
                    pdfFormFields.SetField("dependentssenrolled1no", "Yes");
                }
            }

                List<Dependent> myChildren = myDependents.getDependents();
                int i = 2;
                foreach (Dependent d in myChildren)
                {
                    pdfFormFields.SetField("dependentname" + i.ToString(), d.Name);

                    if (d.Gender.Equals('M'))
                    {
                        pdfFormFields.SetField("dependentgender" + i.ToString() + "male", "Yes");
                    }
                    else
                    {
                        pdfFormFields.SetField("dependentgender" + i.ToString() + "female", "Yes");
                    }

                    pdfFormFields.SetField("dependentheight" + i.ToString(), d.Height);
                    pdfFormFields.SetField("dependentweight" + i.ToString(), d.Weight);
                    pdfFormFields.SetField("dependentdob" + i.ToString(), d.DOB);
                    pdfFormFields.SetField("dependentssn" + i.ToString(), d.SSN);
                    pdfFormFields.SetField("dependentpcp" + i.ToString(), d.PrimaryCarePhysician);

                    if (d.Student)
                    {
                        pdfFormFields.SetField("dependentfts" + i.ToString() + "yes", "Yes");
                    }
                    else
                    {
                        pdfFormFields.SetField("dependentfts" + i.ToString() + "no", "Yes");
                    }

                    if (d.Medicare)
                    {
                        pdfFormFields.SetField("dependentms" + i.ToString() + "yes", "Yes");
                    }
                    else
                    {
                        pdfFormFields.SetField("dependentms" + i.ToString() + "no", "Yes");
                    }

                    if (d.SSEnrolled)
                    {
                        pdfFormFields.SetField("dependentssenrolled" + i.ToString() + "yes", "Yes");
                    }
                    else
                    {
                        pdfFormFields.SetField("dependentssenrolled" + i.ToString() + "no", "Yes");
                    }
                    i += 1;
                }
                
            }
            #endregion

        #region fill out health statements section
        public void FillHealthStatements(HealthStatements myStatements)
        {
            int statementCount = myStatements.MyHealthStatements.Count;
            //if ( statementCount > 16)
            //{
                int i = 0;
                //while (i < 16)
                //{
                //    HealthStatement statement = myStatements.MyHealthStatements[i];
                //    pdfFormFields.SetField("hstq." + i, statement.QuestionNum);
                //    pdfFormFields.SetField("hstname." + i, statement.Name);
                //    pdfFormFields.SetField("hstcondition." + i, statement.Condition);
                //    pdfFormFields.SetField("hstdiagnosed." + i, statement.DateDiagnosed);
                //    pdfFormFields.SetField("hstlasttreated." + i, statement.DateLastTreated);
                //    pdfFormFields.SetField("hsttreatmenttype." + i, statement.TreatmentType);
                //    pdfFormFields.SetField("hstongoing." + i, statement.IsMedication ? "Yes" : "No");
                //    pdfFormFields.SetField("hstrecovery." + i, statement.Recovery);
                //    i++;
                //}

                int remainingStatements = statementCount - i;
                int page = 1;

                pdfFormFields.SetField("SeeAttached", "Please See Attached");
                while (remainingStatements > 0)
                {
                   i = AppendAdditionalStatements(myStatements, i, statementCount, page);
                   remainingStatements = statementCount - i;
                   page++;
                }
                

            //}
            //else
            //{
            //    int i = 0;
            //    foreach (HealthStatement statement in myStatements.MyHealthStatements)
            //    {
            //        pdfFormFields.SetField("hstq." + i, statement.QuestionNum);
            //        pdfFormFields.SetField("hstname." + i, statement.Name);
            //        pdfFormFields.SetField("hstcondition." + i, statement.Condition);
            //        pdfFormFields.SetField("hstdiagnosed." + i, statement.DateDiagnosed);
            //        pdfFormFields.SetField("hstlasttreated." + i, statement.DateLastTreated);
            //        pdfFormFields.SetField("hsttreatmenttype." + i, statement.TreatmentType);
            //        pdfFormFields.SetField("hstongoing." + i, statement.IsMedication ? "Yes" : "No");
            //        pdfFormFields.SetField("hstrecovery." + i, statement.Recovery);
            //        i++;
            //    }
            //}
        }

        private int AppendAdditionalStatements(HealthStatements myStatements, int index, int StatementCount, int page)
        {
            PdfReader myPDFReader = new PdfReader(pdfTemplate + "AddMedAns.pdf");
            ByteBuffer myPDFAddTemp = new ByteBuffer();
            ByteBuffer myPDFAdd = new ByteBuffer();
            PdfStamper mypdfStamper = new PdfStamper(myPDFReader, myPDFAddTemp);
            AcroFields mypdfFormFields = mypdfStamper.AcroFields;
            List<string> myKeys = new List<string>();
           
            //Store Keys
            foreach (DictionaryEntry pf in mypdfFormFields.Fields)
            {
                myKeys.Add(pf.Key.ToString());
            }

            //Rename Fields
            foreach(string k in myKeys)
            {
                if (!k.Contains("SignaturePort") && !k.Contains("appdate"))
                {
                    mypdfFormFields.RenameField(k, k.Replace("[","").Replace("]","") + "_" + page.ToString());
                } 
            }

            //close stamper and reader to apply changes
            myPDFReader.Close();
            mypdfStamper.Close();

            //Create new reader and stamper using pdf with new fields (myPDFAddTemp)
            myPDFReader = new PdfReader(myPDFAddTemp.Buffer);
            mypdfStamper = new PdfStamper(myPDFReader, myPDFAdd);
            mypdfFormFields = mypdfStamper.AcroFields;

            int i = 1;
            while (i <= 9 && index < StatementCount)
            {
                HealthStatement statement = myStatements.MyHealthStatements[index];
                mypdfFormFields.SetField("Row" + i + "0" + "_" + page.ToString(), statement.QuestionNum);
                mypdfFormFields.SetField("Row" + i + "1" + "_" + page.ToString(), statement.Name);
                mypdfFormFields.SetField("Row" + i + "2" + "_" + page.ToString(), statement.Condition);
                mypdfFormFields.SetField("Row" + i + "3" + "_" + page.ToString(), statement.DateDiagnosed);
                mypdfFormFields.SetField("Row" + i + "4" + "_" + page.ToString(), statement.DateLastTreated);
                mypdfFormFields.SetField("Row" + i + "5" + "_" + page.ToString(), statement.TreatmentType);
                mypdfFormFields.SetField("Row" + i + "6" + "_" + page.ToString(), statement.IsMedication ? "Yes" : "No");
                mypdfFormFields.SetField("Row" + i + "7" + "_" + page.ToString(), statement.Recovery);

                i++;
                index++;
            }

            myPDFReader.Close();
            mypdfStamper.Close();
            additionalHealthAnswers.Add(myPDFAdd);
            
            return index;
        }
        #endregion

        #region fill out employer info
        public void fillEmployerData(uspGetClientContactResult myEmployerInfo, uspGetClientByIDResult myEmployer)
        {
            pdfFormFields.SetField("employername", myEmployer.EmployerName);
            pdfFormFields.SetField("employeraddress", myEmployerInfo.Address);
            pdfFormFields.SetField("employercity", myEmployerInfo.City);
            pdfFormFields.SetField("employerstate", myEmployerInfo.state);
            pdfFormFields.SetField("employerzip", myEmployerInfo.zip);
            pdfFormFields.SetField("employerphone", myEmployerInfo.Phone);
            if (myEmployerInfo.Fax != null)
            {
                pdfFormFields.SetField("employerfax", myEmployerInfo.Fax);
            }
        }
        #endregion

        #region fill out carriers
        public void fillCarriers(List<String> carriers)
        {
            for (int i = 1; i <= carriers.Count; i++)
            {
                pdfFormFields.SetField("Carrier" + i, carriers[i-1]);
            }
        }
        #endregion

        internal void FillPrevious()
        {
            pdfFormFields.SetField("previoustriggerno", "Yes");
        }

        internal void FillConcurrent()
        {
            pdfFormFields.SetField("medicarecc1", "Yes");
        }
    }
}
