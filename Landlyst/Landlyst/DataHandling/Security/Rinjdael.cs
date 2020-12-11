using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Landlyst.DataHandling
{
    // class to encrypt data
    public class Rinjdael
    {
        private RijndaelManaged rijndael = new RijndaelManaged();
        public string Encrypt(string Message, string Code, byte[] Salt)
        {
            MemoryStream memoryStream = new MemoryStream();
            // derived bytes to make key and vector
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(Code, Salt, 500000);

            // key gets set
            rijndael.Key = rfc.GetBytes(32);

            // vector gets set
            rijndael.IV = rfc.GetBytes(16);

            // creates stream to "write" the data            
            CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write);

            // gets bytes of the input
            byte[] inputBytes = Encoding.UTF8.GetBytes(Message);

            // converts the input bytes to encrypted bytes
            cryptoStream.Write(inputBytes, 0, inputBytes.Length);
            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();

            // converts the encryted bytes back to string
            string result = Convert.ToBase64String(memoryStream.ToArray());

            return result;
        }
    }
}
