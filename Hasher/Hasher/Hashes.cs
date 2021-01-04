using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Hasher
{
    public class Hashes
    {
        public byte[] Md5Hash(byte[] data)
        {
            MD5 mD5 = MD5.Create();
            return mD5.ComputeHash(data);
        }

        public byte[] Sha1Hash(byte[] data)
        {
            SHA1 sHA1 = SHA1.Create();
            return sHA1.ComputeHash(data);
        }

        public byte[] Sha2Hash(byte[] data)
        {
            SHA256 sHA256 = SHA256.Create();
            return sHA256.ComputeHash(data);
        }

        public byte[] Sha3Hash(byte[] data)
        {
            SHA384 sHA384 = SHA384.Create();
            return sHA384.ComputeHash(data);
        }

        public byte[] Sha5Hash(byte[] data)
        {
            SHA512 sHA512 = SHA512.Create();
            return sHA512.ComputeHash(data);
        }

        public byte[] Hmacsha1(byte[] data, byte[] key)
        {
            HMACSHA1 hMACSHA1 = new HMACSHA1();
            hMACSHA1.Key = key;
            return hMACSHA1.ComputeHash(data);
        }

        public byte[] HmacSha2(byte[] data, byte[] key)
        {
            HMACSHA256 hMACSHA256 = new HMACSHA256();
            hMACSHA256.Key = key;
            return hMACSHA256.ComputeHash(data);
        }
    }
}
