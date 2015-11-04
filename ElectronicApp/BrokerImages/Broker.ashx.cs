using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

namespace ElectronicApp.BrokerImages
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "ociservices.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Broker : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Guid brokerID = new Guid(context.Request.QueryString["id"]);
            ElectronicAppStorageDBDataContext stor = new ElectronicAppStorageDBDataContext();

            uspGetBrokerImageByOwnerIDResult attachment = stor.uspGetBrokerImageByOwnerID(brokerID).Single<uspGetBrokerImageByOwnerIDResult>();

            System.Data.Linq.Binary file = attachment.Attachment;

            if (attachment.Extension.ToLower().Equals("jpg"))
            {
                attachment.Extension = "jpeg";
            }

            context.Response.ContentType = "image/" + attachment.Extension;
            context.Response.BinaryWrite(file.ToArray());

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
