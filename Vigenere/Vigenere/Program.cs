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

            string Code = "kagemand";

            var salt = manager.GenerateSalt();
            string message = manager.Encrypt(Console.ReadLine(), Code, Convert.FromBase64String(salt));
            string hash = Convert.ToBase64String(manager.GetHash(Convert.FromBase64String(message)));

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine(salt);
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine(message);
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine(hash);


            saveToFile.SaveToTxt(message + "," + salt + "," + hash);

            Console.WriteLine(manager.Decrypt(message, Code, Convert.FromBase64String(salt)));
            Console.ReadLine();
        }
    }
}
