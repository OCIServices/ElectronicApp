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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using ElectronicApp;


namespace ElectronicApp.NebraskaApp
{
    public partial class Processing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnNext.Attributes.Add("onClick", "return valSubmit();");
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Default.aspx?timeout=1", false);
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Default.aspx?timeout=1", false);
            }
            fillPdf();
            Response.Redirect("ReviewAndSign.aspx", false);
        }

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
                            myPDF.FillOutReasons(myReason, myCoverage,"Medical");
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
            uspGetClientContactResult myEmployerInfo = db.uspGetClientContact((Guid) Session["ClientID"]).First<uspGetClientContactResult>();
            myPDF.fillEmployerData(myEmployerInfo, (uspGetClientByIDResult) Session["Client"]);
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

            foreach ( uspGetClientCarriersResult carrier in eappdb.uspGetClientCarriers(clientID))
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

       
    }
}
