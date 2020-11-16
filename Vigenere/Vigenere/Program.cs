using System;

namespace Vigenere
{
    class Program
    {
        static void Main(string[] args)
        {
            Cryptomanager manager = new Cryptomanager();
            string Code = "test";


            string message = manager.Encrypt(new Algorithm.Vigenere(), "hej", Code);
            Console.WriteLine(message);
            Console.WriteLine(manager.Decrypt(new Algorithm.Vigenere(), message, Code));
            Console.ReadLine();

        }
    }
}
