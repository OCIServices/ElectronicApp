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

namespace ElectronicApp.NebraskaApp
{
    public partial class preview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           

            if (Session["Buffer"] != null)
            {
                ByteBuffer foo = (ByteBuffer)Session["Buffer"];
                //Context.Response.Buffer = false;
                Context.Response.ContentType = "application/pdf";
                Context.Response.OutputStream.Write(foo.ToByteArray(), 0, (int)foo.Size);
                Context.Response.Flush();
                Context.Response.Close();

                //Session.Remove("Buffer");
            }
        }
    }
}
