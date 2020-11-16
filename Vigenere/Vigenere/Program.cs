using System;

namespace Vigenere
{
    class Program
    {
        static void Main(string[] args)
        {
            Cryptomanager manager = new Cryptomanager();
            string Code = "test";


            var salt = manager.GenerateSalt();
            string message = manager.Encrypt(Console.ReadLine(), Code, salt);
            string salty = Convert.ToBase64String(salt);
            Console.WriteLine(salty);
            Console.WriteLine(message);

            Console.WriteLine(manager.Decrypt(message, Code, Convert.FromBase64String(salty)));
            Console.ReadLine();
        }
    }
}
