using System;
using System.Security.Cryptography;

namespace HashedLogin
{
    class Program
    {
        static File file = new File();
        static int attempts = 0;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1: opret konto\n2:login");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("---------- Opret konto her! ----------");
                        Console.WriteLine("---------- Indtast brugernavn ----------");
                        string uname = Console.ReadLine();
                        Console.WriteLine("---------- Indtast password ----------");
                        string upass = Console.ReadLine();
                        Console.WriteLine("---------- Vent venligst mens ting bliver gjort klar ----------");
                        string salt = GenerateSalt();
                        file.SetAccount(uname, Hasher(upass, salt), salt);
                        Console.WriteLine("---------- Konto er nu oprettet");
                        break;
                    case 2:
                        Login();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Tryk enter for at fortsætte");
                Console.ReadLine();
            }
        }

        public static void Login()
        {
            Console.Clear();
            if (attempts < 5)
            {
                Console.WriteLine("---------- Indtast brugernavn ----------");
                string loginName = Console.ReadLine();
                Console.WriteLine("---------- Indtast password ----------");
                string loginPass = Console.ReadLine();

                if (file.VerifyLogin(loginName, Hasher(loginPass, file.GetSalt())) != true)
                {
                    attempts++;
                    Console.WriteLine("---------- Login fejlet, forsøg nummer {0}", attempts);
                    Console.ReadLine();
                    Login();
                }
                else
                {
                    Console.WriteLine("--------- Du er nu logget ind ----------");
                }
            }
            else
            {
                Console.WriteLine("---------- Denne konto er nu låst! ---------");
            }
        }

        public static string Hasher(string password, string salt)
        {
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 100000);
            return Convert.ToBase64String(rfc.GetBytes(32));
        }

        public static string GenerateSalt()
        {
            RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
            byte[] salt = new byte[32];
            randomNumberGenerator.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }
    }
}
