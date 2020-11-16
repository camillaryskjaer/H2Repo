using System;
using System.Collections.Generic;
using System.Text;

namespace Vigenere.Algorithm
{
    public interface ICrypto
    {
        string Encrypt(string Message, string Code, StringBuilder builder);
        string Decrypt(string Message, string Code, StringBuilder builder);
    }
}
