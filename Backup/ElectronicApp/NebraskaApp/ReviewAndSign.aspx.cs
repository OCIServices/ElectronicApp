using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectronicApp.NebraskaApp
{
    public partial class ReviewAndSign : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            frame1.Attributes["src"] = "https://enrolltest.ociservices.com/NebraskaApp/preview.aspx";
           // frame1.Attributes["src"] = "http://localhost:4242/NebraskaApp/preview.aspx";
        }

        //protected void Submit_Click(object sender, EventArgs e)
        //{
        //    if (ctlMySignature.IsValid())
        //    {

                
        //        // show the newly generated signature image in sign area (optional)
        //        ctlMySignature.ShowSignature();

        //        // get the path of generated signature file
        //        string finalImg = ctlMySignature.SignatureFile;

        //        // Open the final generated signature in new window (optional)
        //        Page.RegisterClientScriptBlock("openSigImg", "<script language='javascript'>window.open('" + finalImg + "');</script>");

        //        // You can use [[finalImg]] to email or save in database. 
        //        // That is subjective
        //    }
        //    else
        //    {
        //        Page.RegisterStartupScript("nosign", "<script language='javascript'>alert('" + ctlMySignature.NoSignMessage + "');</script>");
        //    }
        //}

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignApplication.aspx");
        }
    }
}
