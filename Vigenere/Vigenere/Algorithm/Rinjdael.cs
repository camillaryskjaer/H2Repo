using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Vigenere.Algorithm
{
    public class Rinjdael : ICrypto
    {
        RijndaelManaged rijndael = new RijndaelManaged();

        public string Decrypt(string Message, string Code, byte[] Salt)
        {
            MemoryStream memoryStream = new MemoryStream();
            // derived bytes to make key and vector
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(Code, Salt, 50000);

            // key gets set
            rijndael.Key = rfc.GetBytes(32);

            // vector gets set
            rijndael.IV = rfc.GetBytes(16);

            // creates stream to "write" data            
            CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateDecryptor(), CryptoStreamMode.Write);

            // converts the encrypted string to bytes
            byte[] inputBytes = Convert.FromBase64String(Message);

            // decrypts the bytes
            cryptoStream.Write(inputBytes, 0, inputBytes.Length);
            cryptoStream.FlushFinalBlock();

            // gets the decrypted bytes and converts them back to string
            byte[] output = memoryStream.ToArray();
            string result = Encoding.UTF8.GetString(output, 0, output.Length);

            // closes the streams
            cryptoStream.Close();
            memoryStream.Close();

            // returns the result
            return result;
        }

        public string Encrypt(string Message, string Code, byte[] Salt)
        {
            MemoryStream memoryStream = new MemoryStream();
            // derived bytes to make key and vector
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(Code, Salt, 50000);

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
