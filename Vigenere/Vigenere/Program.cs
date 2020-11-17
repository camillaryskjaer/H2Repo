using System;
using System.Collections.Generic;
using System.IO;
using Vigenere.Managers;

namespace Vigenere
{
    class Program
    {
        static void Main(string[] args)
        {
            Cryptomanager manager = new Cryptomanager();

            string SaltFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Salt.txt";

            string salt;
            if (File.Exists(SaltFile))
            {
                salt = File.ReadAllText(SaltFile);
            }
            else
            {
                salt = manager.GenerateSalt();
            }
            File.WriteAllText(SaltFile, salt);

            List<string> hashes = new List<string>();
            List<string> newhashes = new List<string>();

            foreach (string file in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\cryptofolder"))
            {
                if (file.Contains(".txtrinj"))
                {
                    Console.WriteLine("Storing found hash");
                    Console.WriteLine("-------------------------");
                    string hash = File.ReadAllText(file);
                    hashes.Add(hash);
                }
                else
                {
                    string filecontent = File.ReadAllText(file);
                    string encryptedContent = manager.Encrypt(filecontent, "Kode", Convert.FromBase64String(salt));
                    byte[] encryptedHash = manager.GetHash(Convert.FromBase64String(encryptedContent));
                    string test = Convert.ToBase64String(encryptedHash);
                    newhashes.Add(test);
                    File.WriteAllText(file + "rinj", Convert.ToBase64String(encryptedHash));
                }
            }

            foreach (string h in newhashes)
            {
                if (hashes.Contains(h))
                {
                    Console.WriteLine("Found matching hash!");
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine(h);
                    Console.WriteLine("-------------------------------");
                }
            }

            Console.ReadLine();
        }
    }
}
