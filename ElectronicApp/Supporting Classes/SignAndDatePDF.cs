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
using System.Text;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using System.Collections.Generic;
using System.Collections;

namespace ElectronicApp.Supporting_Classes
{
    public class SignAndDatePDF
    {
        private ByteBuffer myPDF;
        private PdfStamper pdfStamper;
        private PdfReader pdfreader;
        private AcroFields pdfFormFields;
        private string pdfTemplate;
        private List<ByteBuffer> additionalHealthAnswers;

        public SignAndDatePDF(ByteBuffer myFilledPDF)
        {
            pdfreader = new PdfReader(myFilledPDF.Buffer);
            myPDF = new ByteBuffer();
            pdfStamper = new PdfStamper(pdfreader, myPDF);
            pdfFormFields = pdfStamper.AcroFields;

            
        }

        public void SignPDF(string SignaturePath)
        {
            float[] ApplicantSignature01 = null;
            float[] ApplicantSignature02 = null;
            float[] ApplicantSignature03 = null;
            ApplicantSignature01 = pdfFormFields.GetFieldPositions("applicantsignature01");
            ApplicantSignature02 = pdfFormFields.GetFieldPositions("applicantsignature02");
            ApplicantSignature03 = pdfFormFields.GetFieldPositions("applicantsignature03");

            iTextSharp.text.Image mySignature01 = iTextSharp.text.Image.GetInstance(SignaturePath);
            iTextSharp.text.Image mySignature02 = iTextSharp.text.Image.GetInstance(SignaturePath);
            iTextSharp.text.Image mySignature03 = iTextSharp.text.Image.GetInstance(SignaturePath);
            iTextSharp.text.Image mySignature04 = iTextSharp.text.Image.GetInstance(SignaturePath);
            
//Place applicantsignature01 ***************************************
            //Scale Image
            mySignature01.ScaleToFit(ApplicantSignature01[3] - ApplicantSignature01[1], ApplicantSignature01[4] - ApplicantSignature01[2]);
            //Set Position
            mySignature01.SetAbsolutePosition(ApplicantSignature01[1] +
                    ((ApplicantSignature01[3] - ApplicantSignature01[1]) - mySignature01.ScaledWidth) / 2, ApplicantSignature01[4] - mySignature01.ScaledHeight);

            //Place Image
            PdfContentByte contentByte = pdfStamper.GetOverContent((int)ApplicantSignature01[0]);
            contentByte.AddImage(mySignature01);

//Place applicantsignature02 ***************************************
            //Scale Image
            mySignature02.ScaleToFit(ApplicantSignature02[3] - ApplicantSignature02[1], ApplicantSignature02[4] - ApplicantSignature02[2]);
            //Set Position
            mySignature02.SetAbsolutePosition(ApplicantSignature02[1] +
                    ((ApplicantSignature02[3] - ApplicantSignature02[1]) - mySignature02.ScaledWidth) / 2, ApplicantSignature02[4] - mySignature02.ScaledHeight);

            //Place Image
            contentByte = pdfStamper.GetOverContent((int) ApplicantSignature02[0]);
            contentByte.AddImage(mySignature02);

//Place applicantsignature03 ***************************************
            //Scale Image
            mySignature03.ScaleToFit(ApplicantSignature03[3] - ApplicantSignature03[1], ApplicantSignature03[4] - ApplicantSignature03[2]);
            //Set Position
            mySignature03.SetAbsolutePosition(ApplicantSignature03[1] +
                    ((ApplicantSignature03[3] - ApplicantSignature03[1]) - mySignature03.ScaledWidth) / 2, ApplicantSignature03[4] - mySignature03.ScaledHeight);

            //Place Image
            contentByte = pdfStamper.GetOverContent((int)ApplicantSignature03[0]);
            contentByte.AddImage(mySignature03);

//Place Signature on Additional Pages
            float[] SignaturePort = null;
            SignaturePort = pdfFormFields.GetFieldPositions("SignaturePort");
            if (SignaturePort != null)
            {
                int numsigs = SignaturePort.Length / 5;
                for (int i = 0; i < numsigs; i++)
                {
                    mySignature04.ScaleToFit(SignaturePort[3 + (i * 5)] - SignaturePort[1 + (i * 5)], SignaturePort[4 + (i * 5)] - SignaturePort[2 + (i * 5)]);
                    //Set Position
                    mySignature04.SetAbsolutePosition(SignaturePort[1] +
                            ((SignaturePort[3 + (i * 5)] - SignaturePort[1 + (i * 5)]) - mySignature04.ScaledWidth) / 2, SignaturePort[4 + (i * 5)] - mySignature04.ScaledHeight);

                    //Place Image
                    contentByte = pdfStamper.GetOverContent((int)SignaturePort[i * 5]);
                    contentByte.AddImage(mySignature04);
                }
            }

            pdfFormFields.SetField("appdate", DateTime.Now.ToShortDateString());
        }

        public void close()
        {
            pdfreader.Close();
            pdfStamper.Close();
        }

        public ByteBuffer getSignedPDF()
        {
            return myPDF;
        }
    }
}
