using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using System.Web.Security;

namespace ElectronicApp.NebraskaApp
{
    public partial class preview2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            //FileStream fs = new FileStream(Server.MapPath("~" + Session["myPDF"]), FileMode.Open);
            //long fSize = fs.Length;
            //byte[] Data = new byte[fSize];
            //fs.Read(Data, 0, (int) fSize);
            // fs.Close();
            if (Session["Buffer"] != null)
            {
                ByteBuffer foo = (ByteBuffer)Session["Signed"];
                Context.Response.Buffer = false;
                Context.Response.ContentType = "application/pdf";
                Context.Response.OutputStream.Write(foo.ToByteArray(), 0, (int)foo.Size);
                Context.Response.Flush();
                Context.Response.Close();

                //Session.Remove("Buffer");
            }
            Session.Abandon();
            FormsAuthentication.SignOut();
        }
    }
}
