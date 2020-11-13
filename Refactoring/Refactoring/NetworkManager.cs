using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Refactoring
{
    /// <summary>
    /// Class to connect network tools
    /// </summary>
    class NetworkManager
    {
        // Creates instances of network tool classes
        private DHCP DHCP = new DHCP();
        private DNS DNS = new DNS();
        private Connectivity connectivity = new Connectivity();

        // Calls the ipfromhostname method in DNS class
        public string IpFromHostname(string Hostname)
        {
            return DNS.GetIpFromHostname(Hostname);
        }

        // Calls the hostnamefromip method in DNS class
        public string HostnameFromIp(string Ip)
        {
            return DNS.GetHostnameFromIp(Ip);
        }

        // Calls the localping method in Connectivity class
        public string LocalPing()
        {
            return connectivity.LocalPing(new StringBuilder(), new Ping());
        }
        // Calls the traceroute method in Connectivity class
        public string Traceroute(string IpAddressOrHostname)
        {
            return connectivity.Traceroute(IpAddressOrHostname, new StringBuilder());
        }

        // Calls the displaydhcpserveraddresses method in DHCP class
        public string DisplayDHCPServerAddresses()
        {
            return DHCP.DisplayDhcpServerAddresses(new StringBuilder());
        }
    }
}
