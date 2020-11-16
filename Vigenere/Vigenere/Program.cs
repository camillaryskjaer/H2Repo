using System;
using Vigenere.Managers;

namespace Vigenere
{
    class Program
    {
        static void Main(string[] args)
        {
            Cryptomanager manager = new Cryptomanager();
            SaveToFile saveToFile = new SaveToFile();

            string Code = "test";

            var salt = manager.GenerateSalt();
            string message = manager.Encrypt(Console.ReadLine(), Code, Convert.FromBase64String(salt));
            Console.WriteLine(salt);
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine(message);

            saveToFile.SaveToTxt(message + "," + salt);

            Console.WriteLine(manager.Decrypt(message, Code, Convert.FromBase64String(salt)));
            Console.ReadLine();
        }
    }
}
