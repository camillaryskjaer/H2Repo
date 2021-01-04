using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Coincidences
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm'
                , 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'æ', 'ø', 'å' };
            StringBuilder stringBuilder = new StringBuilder();
            string input = Console.ReadLine().ToLower();

            foreach (char c in input)
            {
                int index = Array.FindIndex(alphabet, i => i.Equals(c));
                if (index + 1 == alphabet.Length)
                {
                    index = 0;
                    stringBuilder.Append(alphabet[index]);
                }
                else
                {
                    stringBuilder.Append(alphabet[index + 1]);
                }
            }

            string encrypted = stringBuilder.ToString();
            Console.WriteLine(encrypted);
            Console.ReadLine();

            stringBuilder.Clear();
            foreach (char c in encrypted)
            {
                int index = Array.FindIndex(alphabet, i => i.Equals(c));
                if (index - 1 < 0)
                {
                    stringBuilder.Append(alphabet[alphabet.Length - 1]);
                }
                else
                {
                    stringBuilder.Append(alphabet[index - 1]);
                }
            }
            Console.WriteLine(stringBuilder.ToString());
            Console.ReadLine();
        }

        public static void RNGNumbers()
        {
            RNGCryptoServiceProvider rNG = new RNGCryptoServiceProvider();
            Random random = new Random();
            byte[] data = new byte[10];
            Stopwatch stopwatch = new Stopwatch();

            // crypto generate a 10 byte array 10 times
            Console.WriteLine("Crytpo numbers");
            stopwatch.Start();
            for (int i = 0; i < 10000000; i++)
            {
                rNG.GetBytes(data);

                int val = BitConverter.ToInt32(data, 0);
                // Console.WriteLine(val);
            }
            stopwatch.Stop();
            Console.WriteLine("Miliseconds taken: " + stopwatch.ElapsedMilliseconds);

            Console.WriteLine();
            Console.WriteLine("Random numbers");
            stopwatch.Reset();

            stopwatch.Start();
            for (int i = 0; i < 10000000; i++)
            {
                random.NextBytes(data);

                int val = BitConverter.ToInt32(data, 0);
                // Console.WriteLine(val);
            }
            stopwatch.Stop();
            Console.WriteLine("Miliseconds taken: " + stopwatch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
