/*

	WebSignatureCapture (WEBSIGN) copyright © 2011 - 2012 www.websignaturecapture.com
	Contact: info@websignaturecapture.com
	This code is not a freeware. You are not authorized to distribute
	or use it if you have not purchased. Please visit
	http://www.websignaturecapture.com to buy it

 */
namespace WebSignatureCapture
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    using System.Web.UI;
    using System.Drawing.Imaging;

    public partial class SignatureControl : UserControl
    {

        #region " Properties "

        /// <summary>
        /// The format to save the signature file
        /// </summary>
        private ImageFormat _signatureFileFormat = ImageFormat.Png;
        public ImageFormat SignatureFileFormat
        {
            get { return _signatureFileFormat; }
            set { _signatureFileFormat = value; }
        }

        /// <summary>
        /// Path to save signature file
        /// </summary>
        private string _savePath = "~/";
        public string SavePath
        {
            get { return _savePath; }
            set { _savePath = value; }
        }

        /// <summary>
        /// Path to signature control code files
        /// </summary>
        private string _signatureCodePath = "~/";
        public string SignatureCodePath
        {
            get { return _signatureCodePath; }
            set { _signatureCodePath = value; }
        }

        /// <summary>
        /// Color of the signature Default BLUE
        /// </summary>
        private string _penColor = "Blue";
        public string PenColor
        {
            get { return _penColor; }
            set { _penColor = value; }
        }

        /// <summary>
        /// Width of the Signature Default 2
        /// </summary>
        private string _penWidth = "2";
        public string PenWidth
        {
            get { return _penWidth; }
            set { _penWidth = value; }
        }

        /// <summary>
        /// Color of the background Default White
        /// </summary>
        private string _bgColor = "White";
        public string BackColor
        {
            get { return _bgColor; }
            set { _bgColor = value; }
        }

        /// <summary>
        /// Background Image
        /// </summary>
        private string _bgImage = "";
        public string BackgroundImage
        {
            get { return _bgImage; }
            set { _bgImage = value; }
        }

        /// <summary>
        /// Message to show user if she previews without signing
        /// </summary>
        private string _noSignMsg = "No signature found !";
        public string NoSignMessage
        {
            get { return _noSignMsg; }
            set { _noSignMsg = value; }
        }

        /// <summary>
        /// Width of signature canvas
        /// </summary>
        private int _signWidth = 400;
        public int SignWidth
        {
            get { return _signWidth; }
            set { _signWidth = value; }
        }

        /// <summary>
        /// Height of signature canvas
        /// </summary>
        private int _signHeight = 200;
        public int SignHeight
        {
            get { return _signHeight; }
            set { _signHeight = value; }
        }

        /// <summary>
        /// Check if the signature file was generated
        /// </summary>
        /// <returns>True is exists</returns>
        public bool IsValid()
        {
            return System.IO.File.Exists(Server.MapPath(this.SavePath) + this.SignFile);
        }

        /// <summary>
        /// The unique identified for the control objects
        /// </summary>
        private string SignID
        {
            get { return "SignObj_" + this.ClientID; }
        }

        /// <summary>
        /// The signature GUID file that is saved across postbacks
        /// </summary>
        private string SignFile
        {
            get
            {
                if (Convert.ToString(Session[SignID]).Length == 0)
                {
                    Session[SignID] = this.ClientID + "_" + System.Guid.NewGuid().ToString();
                }

                // Get the file name GUID along with the selected extension
                return Convert.ToString(Session[SignID]) + "." + Convert.ToString(SignatureFileFormat);
            }
        }

        /// <summary>
        /// Path to the final generated signature file
        /// </summary>
        public string SignatureFile
        {
            get
            {
                return Page.ResolveUrl(this.SavePath) + this.SignFile;
            }
        }

        /// <summary>
        /// The url that is passed to further processing pages
        /// </summary>
        private string SignURL
        {
            get { return "?SignFile=" + this.SignFile + "&PColor=" + this.PenColor + "&PWidth=" + this.PenWidth + "&BGColor=" + this.BackColor + "&CanvasW=" + this.SignWidth + "&CanvasH=" + this.SignHeight + "&SSavePath=" + SavePath.Replace("/", "_") + "&NoSign=" + this.NoSignMessage + "&SBackImg=" + BackgroundImage.Replace("/", "_"); }
        }

        #endregion

        #region " Methods "

        public void ShowSignature()
        {
            Page.RegisterStartupScript("restoreImg_" + this.SignID, "<script language='javascript'>document.getElementById('" + this.SignID + "').src = '" + this.SignatureFile + "';</script>");
        }
        #endregion

        #region " Events "

        protected override void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }


        /// <summary>
        ///		Required method for Designer support - do not modify
        ///		the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            string frmCode = @"<iframe id='" + this.SignID + "' name='" + this.SignID + "' MarginHeight='0' MarginWidth='0' scrolling='no' src='" + Page.ResolveUrl(this.SignatureCodePath + "Sign.aspx") + this.SignURL + "' frameborder='0' style='width:" + Convert.ToString(this.SignWidth) + "px;height:" + Convert.ToString(this.SignHeight) + "px;border:1px dashed black;'></iframe>";
            writer.Write(frmCode);
            base.Render(writer);
        }

        protected override void OnPreRender(EventArgs e)
        {
            string clientScript = "<script language='javascript'>function SaveSignature(ctl){ try { document.getElementById(ctl).contentWindow.save(); }catch(e){NewSignature(ctl); } }	function ClearSignature(ctl){ try{document.getElementById(ctl).contentWindow.clear();}catch(e){NewSignature(ctl);}} function NewSignature(ctl){document.getElementById(ctl).src = document.getElementById(ctl).src;} </script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "websignFn", clientScript);
            base.OnPreRender(e);
        }


        #endregion
    }
}
