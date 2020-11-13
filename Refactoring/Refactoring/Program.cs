using System;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security;
using System.Text;

namespace Refactoring
{
    class Program
    {
        private static NetworkManager networkManager = new NetworkManager();
        static void Main()
        {
            Console.WriteLine(networkManager.IpFromHostname("en.wikipedia.org"));
            Console.WriteLine(networkManager.LocalPing());

            string t = networkManager.HostnameFromIp("8.8.8.8");
            Console.WriteLine(t);
            Console.WriteLine("Wee " + networkManager.IpFromHostname(t));

            Console.WriteLine("route*** " + networkManager.Traceroute("8.8.8.8"));

            Console.WriteLine(networkManager.DisplayDHCPServerAddresses());



            //Console.ReadKey();
            ////WIN-M69SG2Q0732.test.local
            ////ZBC-RG01203MKC
            //string hostName = "ZBC-RG01203MKC";
            //IPHostEntry hostInfo = Dns.GetHostByName(hostName);
            //// Get the IP address list that resolves to the host names contained in the 
            //// Alias property.
            //IPAddress[] address = hostInfo.AddressList;
            //// Get the alias names of the addresses in the IP address list.
            //String[] alias = hostInfo.Aliases;

            //Console.WriteLine("Host name : " + hostInfo.HostName);
            //Console.WriteLine("\nAliases : ");
            //for (int index = 0; index < alias.Length; index++)
            //{
            //    Console.WriteLine(alias[index]);
            //}
            //Console.WriteLine("\nIP address list : ");
            //for (int index = 0; index < address.Length; index++)
            //{
            //    Console.WriteLine(address[index]);
            //}
            Console.ReadKey();
        }
    }
}

