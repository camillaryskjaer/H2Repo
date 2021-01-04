using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;

namespace Hasher
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashes hasher = new Hashes();
            Stopwatch stopwatch = new Stopwatch();
            string key;

            Console.WriteLine("Input text to hash");
            string input = Console.ReadLine();

            Console.WriteLine("Select hash type:");
            Console.WriteLine("1:SHA1\n2:HMACSHA1\n3:SHA2" +
                "\n4:HMACSHA2\n5:SHA3\n6:SHA5\n7:MD5");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.Clear();
                    stopwatch.Start();
                    byte[] hashed = hasher.Sha1Hash(Encoding.ASCII.GetBytes(input));
                    stopwatch.Stop();
                    Console.WriteLine("Plain text: " + input);
                    Console.WriteLine("Hashed: " + Encoding.ASCII.GetString(hashed));
                    Console.WriteLine("Milliseconds taken: " + stopwatch.ElapsedMilliseconds);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Input key");
                    key = Console.ReadLine();
                    stopwatch.Start();
                    byte[] hmacSha1 = hasher.Hmacsha1(Encoding.ASCII.GetBytes(input), Encoding.ASCII.GetBytes(key));
                    byte[] hmacSha1Key = Encoding.ASCII.GetBytes(key);
                    stopwatch.Stop();
                    Console.WriteLine("Plain text: " + input);
                    Console.WriteLine("Hashed: " + Encoding.ASCII.GetString(hmacSha1));
                    Console.WriteLine("Key: " + Encoding.ASCII.GetString(hmacSha1Key));
                    Console.WriteLine("Milliseconds taken: " + stopwatch.ElapsedMilliseconds);
                    break;
                case 3:
                    Console.Clear();
                    stopwatch.Start();
                    byte[] sha2 = hasher.Sha2Hash(Encoding.ASCII.GetBytes(input));
                    stopwatch.Stop();
                    Console.WriteLine("Plain text: " + input);
                    Console.WriteLine("Hashed: " + Encoding.ASCII.GetString(sha2));
                    Console.WriteLine("Milliseconds taken: " + stopwatch.ElapsedMilliseconds);
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Input key");
                    key = Console.ReadLine();
                    stopwatch.Start();
                    byte[] hmacsha2 = hasher.HmacSha2(Encoding.ASCII.GetBytes(input), Encoding.ASCII.GetBytes(key));
                    byte[] hmac2key = Encoding.ASCII.GetBytes(key);
                    stopwatch.Stop();
                    Console.WriteLine("Plain text: " + input);
                    Console.WriteLine("Hashed: " + Encoding.ASCII.GetString(hmacsha2));
                    Console.WriteLine("Key: " + Encoding.ASCII.GetString(hmac2key));
                    Console.WriteLine("Milliseconds taken: " + stopwatch.ElapsedMilliseconds);
                    break;
                case 5:
                    Console.Clear();
                    stopwatch.Start();
                    byte[] sha3 = hasher.Sha3Hash(Encoding.ASCII.GetBytes(input));
                    stopwatch.Stop();
                    Console.WriteLine("Plain text: " + input);
                    Console.WriteLine("Hashed: " + Encoding.ASCII.GetString(sha3));
                    Console.WriteLine("Milliseconds taken: " + stopwatch.ElapsedMilliseconds);
                    break;
                case 6:
                    Console.Clear();
                    stopwatch.Start();
                    byte[] sha5 = hasher.Sha5Hash(Encoding.ASCII.GetBytes(input));
                    stopwatch.Stop();
                    Console.WriteLine("Plain text: " + input);
                    Console.WriteLine("Hashed: " + Encoding.ASCII.GetString(sha5));
                    Console.WriteLine("Milliseconds taken: " + stopwatch.ElapsedMilliseconds);
                    break;
                case 7:
                    Console.Clear();
                    stopwatch.Start();
                    byte[] md5 = hasher.Md5Hash(Encoding.ASCII.GetBytes(input));
                    stopwatch.Stop();
                    Console.WriteLine("Plain text: " + input);
                    Console.WriteLine("Hashed: " + Encoding.ASCII.GetString(md5));
                    Console.WriteLine("Milliseconds taken: " + stopwatch.ElapsedMilliseconds);
                    break;
            }

            Console.ReadLine();
        }
    }
}