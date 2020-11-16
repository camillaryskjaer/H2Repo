using System;
using System.Collections.Generic;
using System.Text;

namespace Vigenere.Algorithm
{
    public class Vigenere : ICrypto
    {
        char[,] charset = new char[27, 27]
        {
           {' ','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'},
           {'a','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'},
           {'b','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','a'},
           {'c','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','a','b'},
           {'d','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','a','b','c'},
           {'e','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','a','b','c','d'},
           {'f','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','a','b','c','d','e'},
           {'g','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','a','b','c','d','e','f'},
           {'h','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','a','b','c','d','e','f','g'},
           {'i','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','a','b','c','d','e','f','g','h'},
           {'j','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','a','b','c','d','e','f','g','h','i'},
           {'k','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','a','b','c','d','e','f','g','h','i','j'},
           {'l','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','a','b','c','d','e','f','g','h','i','j','k'},
           {'m','m','n','o','p','q','r','s','t','u','v','w','x','y','z','a','b','c','d','e','f','g','h','i','j','k','l'},
           {'n','n','o','p','q','r','s','t','u','v','w','x','y','z','a','b','c','d','e','f','g','h','i','j','k','l','m'},
           {'o','o','p','q','r','s','t','u','v','w','x','y','z','a','b','c','d','e','f','g','h','i','j','k','l','m','n'},
           {'p','p','q','r','s','t','u','v','w','x','y','z','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o'},
           {'q','q','r','s','t','u','v','w','x','y','z','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p'},
           {'r','r','s','t','u','v','w','x','y','z','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q'},
           {'s','s','t','u','v','w','x','y','z','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r'},
           {'t','t','u','v','w','x','y','z','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s'},
           {'u','u','v','w','x','y','z','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t'},
           {'v','v','w','x','y','z','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u'},
           {'w','w','x','y','z','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v'},
           {'x','x','y','z','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w'},
           {'y','y','z','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','y','v','w','x'},
           {'z','z','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y'}
        };
        int x;
        int y;

        public string Decrypt(string Message, string Code)
        {
            StringBuilder builder = new StringBuilder();
            int i = 0;
            char[] message = Message.ToLower().ToCharArray();
            char[] code = Code.ToLower().ToCharArray();

            foreach (char c in message)
            {
                for (int ay = 0; ay < 27; ay++)
                {
                    if (code[i] == charset[0, ay])
                    {
                        y = ay;
                    }
                }
                for (int ax = 0; ax < 27; ax++)
                {
                    if (c == charset[ax, y])
                    {
                        x = ax;
                    }
                }
                builder.Append(charset[x, 0]);
                if (i < code.Length)
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
            }
            return builder.ToString();
        }

        public string Encrypt(string Message, string Code)
        {
            StringBuilder builder = new StringBuilder();
            int i = 0;
            char[] message = Message.ToLower().ToCharArray();
            char[] code = Code.ToLower().ToCharArray();

            foreach (char c in message)
            {
                for (int ax = 0; ax < 27; ax++)
                {
                    if (c == charset[ax, 0])
                    {
                        x = ax;
                    }
                }
                for (int ay = 0; ay < 27; ay++)
                {
                    if (code[i] == charset[0, ay])
                    {
                        y = ay;
                    }
                }

                builder.Append(charset[x, y]);

                if (i < code.Length)
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
            }
            return builder.ToString();
        }
    }
}
