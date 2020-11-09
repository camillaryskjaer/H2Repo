using System;

namespace HelpJakob
{
    class Program
    {
        static void Main(string[] args)
        {
            Message m = new Message("", "", "", "", "");
            Send s = new Send();
            s.sendMessage(MessageCarrier.Smtp, m, true);

            Console.ReadLine();
        }
    }
}
