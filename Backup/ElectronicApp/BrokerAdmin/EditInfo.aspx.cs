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
using System.Drawing.Imaging;
using System.Drawing;

namespace ElectronicApp.BrokerAdmin
{
    public partial class EditInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["BrokerID"] != null)
                {
                    Guid myBrokerID = (Guid)Session["BrokerID"];
                    try
                    {
                        ElectronicAppDBDataContext electronicAppDB = new ElectronicAppDBDataContext();
                        uspGetBrokerByIDResult myBroker = electronicAppDB.uspGetBrokerByID(myBrokerID).Single<uspGetBrokerByIDResult>();
                        uspGetBrokerContactResult myBrokerInfo = electronicAppDB.uspGetBrokerContact(myBroker.BrokerID).Single<uspGetBrokerContactResult>();

                        //string ClientName = myClient.EmployerName;
                        BrokerFirstName.Text = myBroker.FirstName;
                        BrokerLastName.Text = myBroker.LastName;
                        BrokerEmail.Text = myBrokerInfo.Email;
                        BrokerPhone.Text = myBrokerInfo.PhoneNumber;
                        BrokerFax.Text = myBrokerInfo.Fax;
                        BrokerAddress.Text = myBrokerInfo.Address;
                        BrokerCity.Text = myBrokerInfo.City;
                        BrokerState.Text = myBrokerInfo.State;
                        BrokerZip.Text = myBrokerInfo.Zip;
                        ElectronicAppStorageDBDataContext electronicAppStorageDB = new ElectronicAppStorageDBDataContext();
                        uspGetBrokerByIDResult broker = electronicAppDB.uspGetBrokerByID(myBroker.BrokerID).Single<uspGetBrokerByIDResult>();

                        System.Collections.Generic.List<uspGetBrokerImageByOwnerIDResult> searches = electronicAppStorageDB.uspGetBrokerImageByOwnerID(broker.BrokerID).ToList<uspGetBrokerImageByOwnerIDResult>();

                        bool hasImage = searches.Count > 0;

                        if (hasImage)
                        {
                            Image1.ImageUrl = "/BrokerImages/Broker.ashx?id=" + broker.BrokerID.ToString();
                        }
                        
                        //Session.Add("Client", myClient);
                        //ClientName = electronicAppDB.uspGetBrokerByID(myClient.OwnerID).Single<uspGetBrokerByIDResult>().
                    }
                    catch (Exception ex)
                    {
                        Session.Abandon();
                        FormsAuthentication.SignOut();
                        Response.Redirect("Default.aspx", false);
                    }
                }
                else
                {
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("Default.aspx", false);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool redir = true;

            if (FileUpload1.PostedFile.ContentLength <= 5 * 1024 * 1024 && FileUpload1.PostedFile.ContentLength > 0)
            {
                //System.Drawing.Image newbrokerimage = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);

                //newbrokerimage.Save( Server.MapPath("~/BrokerImages/") + Session["BrokerID"] + ".png", System.Drawing.Imaging.ImageFormat.Png);

                byte[] bytes = FileUpload1.FileBytes;

                bytes = imageResize.ResizeFromByteArray( 150, bytes, "test");

                System.Data.Linq.Binary image = new System.Data.Linq.Binary(bytes);

                ElectronicAppStorageDBDataContext eappstor = new ElectronicAppStorageDBDataContext();

                eappstor.uspDeleteBrokerImageByOwnerID((Guid)(Session["BrokerID"]));


                String filename = FileUpload1.FileName;
                String ext = filename.Substring( filename.LastIndexOf('.') + 1 );
                filename = filename.Substring( 0, filename.LastIndexOf('.'));

                eappstor.uspInsertBrokerImage(System.Guid.NewGuid(), (Guid)(Session["BrokerID"]), image, filename, ext);
            }
            else if (FileUpload1.PostedFile.ContentLength > 0)
            {
                redir = false;
                lblMessage.Text = "File must be less than 5MB in size.";
                lblMessage.Visible = true;
            }

            ElectronicAppDBDataContext ElectronicAppDB = new ElectronicAppDBDataContext();
            ElectronicAppDB.uspAlterBrokerInfo( (Guid)Session["BrokerID"], BrokerFirstName.Text, BrokerLastName.Text, BrokerEmail.Text, BrokerPhone.Text, BrokerFax.Text, BrokerAddress.Text, BrokerCity.Text, BrokerState.Text, BrokerZip.Text);


            if (redir)
            {
                Response.Redirect("Welcome.aspx", false);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }

    }
}
