using System;

namespace Wenside
{
    class Program
    {
        static void Main(string[] args)
        {
            IRequest request;

            Factory factory = new Factory();
            request = factory.RequestWebsite();
            Console.WriteLine(request.RequestData("https://docs.microsoft.com"));
            Console.ReadLine();
            Console.Clear();
            request = factory.RequestFile();
            Console.WriteLine(request.RequestData(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Validation.txt"));
            Console.ReadLine();
        }
    }
}
