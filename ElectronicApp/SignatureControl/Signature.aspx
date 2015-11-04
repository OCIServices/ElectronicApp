<%@ Page Language="C#" %>

<%@ Import Namespace="System.Web" %>
<%@ Import Namespace="System.Drawing" %>
<%@ Import Namespace="System.Drawing.Drawing2D" %>
<%@ Import Namespace="System.Drawing.Imaging" %>
<%@ Import Namespace="System.IO" %>

<!-- 
	WebSignatureCapture (WEBSIGN) copyright © 2011 - 2012 www.websignaturecapture.com
	Contact: info@websignaturecapture.com
	This code is not a freeware. You are not authorized to distribute
	or use it if you have not purchased. Please visit
	http://www.websignaturecapture.com to buy it
-->
<html>
<head>
    <title>Signature</title>
    <style>
	body{
		background:#fff;
		cursor : hand;
		padding:0;
		margin:0;
		width:100%;
		height:100%;
	}
	#pointer{
		position:absolute;
		background:#000;
		width:3px;
		height:3px;
		font-size:1px;
		z-index:32768;
	}
</style>

    <script language="javascript">
			if (self == top) { 
			 window.location.href = './';
			 }
    </script>

</head>
<body>
    <noscript>
        <meta http-equiv="refresh" content="1;URL=./">
    </noscript>
    <form id="Form1" method="post" runat="server">

        <script runat="server">
	        
            string tmp1 = "";
            string tmp2 = "";
            string pcolor = "";
            string pwidth = "";
            string bgcolor = "";
            string signaturefile = "";
            string cWidth = "";
            string cHeight = "";
            string sSavePath = "";

            // fix for IE bug of session variables in iframe    
            protected override void OnPreRender(EventArgs e)
            {
                Response.AppendHeader("P3P", "CP=\"CAO PSA OUR\"");
                base.OnPreRender(e);
            }

            void Page_Load(object sender, System.EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    try
                    {
                        tmp1 = Request.Form[0];
                        tmp2 = Request.Form[1];
                        pwidth = Request.Form[2];
                        pcolor = Request.Form[3];
                        bgcolor = Request.Form[4];
                        signaturefile = Request.Form[5];
                        cWidth = Request.Form[6];
                        cHeight = Request.Form[7];
                        sSavePath = Convert.ToString(Request.Form[8]).Replace("_", "/");
                    }
                    catch (Exception)
                    {
                        Response.Redirect(Page.ResolveUrl("~/"));
                    }

                    GenerateImage();

                }
            }

            void GenerateImage()
            {
                Response.Clear();

                string[] arrX = tmp1.Split('|');
                string[] arrY = tmp2.Split('|');
                string formatExt = signaturefile.Split('.')[1];
                int CurrX = 0;
                int CurrY = 0;

                bool isErr = false;

                Bitmap bmp = new Bitmap(Convert.ToInt32(cWidth), Convert.ToInt32(cHeight));
                Graphics g = null;

                ImageFormat imgFormat = ParseImageFormat(formatExt);
                
                try
                {
                    g = Graphics.FromImage(bmp);
                    g.SmoothingMode = SmoothingMode.AntiAlias;

                    if (imgFormat != ImageFormat.Png || ((Color.FromName(bgcolor) != Color.White)))
                    {
                        g.FillRectangle(new SolidBrush(Color.FromName(bgcolor)), 0, 0, bmp.Width, bmp.Height);
                    }
                    
                    Pen pn = new Pen(new SolidBrush(Color.FromName(pcolor)), Convert.ToInt32(pwidth));

                    for (int i = 0; i < arrX.Length; i++)
                    {
                        if (arrX[i].Length > 0)
                        {
                            string[] innerPointsX = arrX[i].Split(',');
                            string[] innerPointsY = arrY[i].Split(',');

                            PointF[] tfArray = new PointF[innerPointsX.Length - 1];

                            for (int j = 0; j < innerPointsX.Length - 1; j++)
                            {
                                if (innerPointsX[j].Length > 0)
                                {
                                    CurrX = Convert.ToInt32(innerPointsX[j]);
                                    CurrY = Convert.ToInt32(innerPointsY[j]);

                                    PointF tf = new PointF(CurrX, CurrY);
                                    tfArray[j] = tf;

                                }
                            }

                            GraphicsPath path = new GraphicsPath();
                            path.AddLines(tfArray);
                            g.DrawPath(pn, path);
                        }
                    }

                }
                catch (Exception ex)
                {
                    string err = ex.Message.ToString();
                    isErr = true;
                }
                finally
                {
                    if (null != g)
                        g.Dispose();
                }

                

                try
                {
                    
                    string outPath = Server.MapPath(sSavePath) + "/" + signaturefile;
                    MemoryStream ms = new MemoryStream();
                    bmp.Save(ms, imgFormat);
                    Session["mysig"] = ms.ToArray();
                    
                    
                    if (File.Exists(outPath))
                        File.Delete(outPath);
                    
                    // save image to disk
                    bmp.Save(outPath, imgFormat);

                    // make transparent if background color is white and image is not Png
                    if (ImageFormat.Gif == imgFormat && (Color.FromName(bgcolor) == Color.White))
                    {
                        bmp = MakeTransparent(outPath);
                    }

                    Response.ContentType = "image/" + formatExt;


                    ms.WriteTo(Response.OutputStream);

                    // dispose bitmap object 
                    bmp.Dispose();
                    ms.Dispose();
                    Response.End();
                }
                catch (Exception ex)
                {
                    string err = ex.Message.ToString();
                    Response.Write(err);
                    isErr = true;
                }

            }

            private Bitmap MakeTransparent(string outPath)
            {
                Bitmap bmpIn = new Bitmap(outPath);
                try
                {
                    ImageAttributes mImageAttributes = new ImageAttributes();
                    mImageAttributes.SetColorKey(bmpIn.GetPixel(0, 0), bmpIn.GetPixel(0, 0));
                    Rectangle dstRect = new Rectangle(0, 0, bmpIn.Width, bmpIn.Height);

                    Bitmap bmnew = new Bitmap(bmpIn.Width, bmpIn.Height);
                    Graphics g = Graphics.FromImage(bmnew);
                    g.DrawImage(bmpIn, dstRect, 0, 0, bmpIn.Width, bmpIn.Height, GraphicsUnit.Pixel, mImageAttributes);

                    File.Delete(outPath);
                    g.Dispose();
                    bmpIn.Dispose();
                    return bmnew;
                }
                catch (Exception ex)
                {
                    string transErr = ex.Message.ToString();
                }
                return bmpIn;
            }


            private ImageFormat ParseImageFormat(string format)
            {
                switch (format.ToLower())
                {
                    case "jpg":
                        return ImageFormat.Jpeg;
                    case "jpeg":
                        return ImageFormat.Jpeg;
                    case "bmp":
                        return ImageFormat.Bmp;
                    case "gif":
                        return ImageFormat.Gif;
                    case "png":
                        return ImageFormat.Png;
                    case "tiff":
                        return ImageFormat.Tiff;
                    case "wmf":
                        return ImageFormat.Wmf;
                    case "emf":
                        return ImageFormat.Emf;
                    case "icon":
                        return ImageFormat.Icon;
                    case "ico":
                        return ImageFormat.Icon;
                    case "exif":
                        return ImageFormat.Exif;
                    default:
                        return ImageFormat.Jpeg;
                }

            }
        
        </script>

    </form>
</body>
</html>
