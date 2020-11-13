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
            Console.WriteLine("Enter hostname / website \n");
            Console.WriteLine(networkManager.IpFromHostname(Console.ReadLine()) + Environment.NewLine);

            Console.WriteLine("Pinging local machine\n");
            Console.WriteLine(networkManager.LocalPing() + Environment.NewLine);

            Console.WriteLine("Enter Ipaddress\n");
            string t = networkManager.HostnameFromIp(Console.ReadLine());
            Console.WriteLine(t);
            Console.WriteLine("Wee " + networkManager.IpFromHostname(t) + Environment.NewLine);

            Console.WriteLine("Enter Ipaddress to trace\n");
            Console.WriteLine("route*** " + networkManager.Traceroute(Console.ReadLine()) + Environment.NewLine);

            Console.WriteLine("Displaying connected DHCP server addresses\n");
            Console.WriteLine(networkManager.DisplayDHCPServerAddresses() + Environment.NewLine);

            Console.WriteLine("Local machine ip's: \n");
            string hostName = Environment.MachineName;
            IPHostEntry hostInfo = Dns.GetHostByName(hostName);
            //// Get the IP address list that resolves to the host names contained in the 
            //// Alias property.
            IPAddress[] address = hostInfo.AddressList;
            //// Get the alias names of the addresses in the IP address list.
            String[] alias = hostInfo.Aliases;

            Console.WriteLine("Host name : " + hostInfo.HostName);
            Console.WriteLine("\nAliases : ");
            for (int index = 0; index < alias.Length; index++)
            {
                Console.WriteLine(alias[index]);
            }
            Console.WriteLine("\nIP address list : ");
            for (int index = 0; index < address.Length; index++)
            {
                Console.WriteLine(address[index]);
            }
            Console.ReadKey();
        }
    }
}

