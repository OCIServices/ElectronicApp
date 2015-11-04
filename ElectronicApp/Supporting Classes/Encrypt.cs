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
using System.Security.Cryptography;
using System.IO;

namespace ElectronicApp.Supporting_Classes
{
    public class Encrypt
    {
        private RSACryptoServiceProvider myRSA;
        private RijndaelManaged myRijndael;
        private Guid ObjectID;
        private Guid OwnerID;
        private Guid SubmissionID;
        private string addedBY;

        public Encrypt(Guid OwnerID, string addedBy)
        {
            //Get Public Key and Set Up RSA Encryption
            myRSA = new RSACryptoServiceProvider();
            myRSA.ImportCspBlob(Convert.FromBase64String(ConfigurationSettings.AppSettings["SubKey"]));
            myRijndael = new RijndaelManaged();

            this.ObjectID = Guid.NewGuid();
            this.OwnerID = OwnerID;
            this.addedBY = addedBy;
            this.SubmissionID = Guid.NewGuid();
        }

        public void EncryptPDF(Byte[] myPDF)
        {
            myRijndael.GenerateIV();
            myRijndael.GenerateKey();
            byte[] encPDF = encryptStringToBytes_AES(Convert.ToBase64String(myPDF), myRijndael.Key, myRijndael.IV);
            EncryptAndStoreKey(myRijndael.Key, myRijndael.IV);

            ElectronicAppDBDataContext eappdb = new ElectronicAppDBDataContext();
            eappdb.uspInsertSubmission(SubmissionID, OwnerID, ObjectID.ToString(), "pdf", addedBY);

            ElectronicAppStorageDBDataContext storagedb = new ElectronicAppStorageDBDataContext();
            storagedb.uspInsertSubmission(ObjectID, SubmissionID, encPDF, ObjectID.ToString(), "pdf", addedBY);
        }

        private byte[] encryptStringToBytes_AES(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the stream used to encrypt to an in memory
            // array of bytes.
            MemoryStream msEncrypt = null;

            // Declare the RijndaelManaged object
            // used to encrypt the data.
            RijndaelManaged aesAlg = null;

            try
            {
                // Create a RijndaelManaged object
                // with the specified key and IV.
                aesAlg = new RijndaelManaged();
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                msEncrypt = new MemoryStream();
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(plainText);
                    }
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            // Return the encrypted bytes from the memory stream.
            return msEncrypt.ToArray();
        }

        private void EncryptAndStoreKey(byte[] key, byte[] iv)
        {
            byte[] enckey = myRSA.Encrypt(key, true);
            byte[] enciv = myRSA.Encrypt(iv, true);

            ElectronicAppSecurityDBDataContext secdb = new ElectronicAppSecurityDBDataContext();
            secdb.uspInsertAttachmentData(Guid.NewGuid(), SubmissionID, enckey, iv);
        }
 
    }
}
