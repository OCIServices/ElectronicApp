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
using iTextSharp.text.pdf;


namespace ElectronicApp.NebraskaApp
{
    public partial class SignApplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
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
                        Response.Redirect("thankyou.aspx", false);
                    }
                    catch (Exception ex)
                    {

                    }
                    
                }
                else
                {
                    Response.Redirect("Default.aspx?timeout=1");
                }
            }
            //else
            //{
            //    Page.RegisterStartupScript("nosign", "<script language='javascript'>ClearSignature();</script>");
            //    Page.RegisterStartupScript("nosign", "<script language='javascript'>alert('" + ctlMySignature.NoSignMessage + "');</script>");
            //}
        }
    }
}
