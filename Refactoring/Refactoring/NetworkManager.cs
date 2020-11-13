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
        private DHCP DHCP = new DHCP();
        private DNS DNS = new DNS();
        private Connectivity connectivity = new Connectivity();

        public string IpFromHostname(string Hostname)
        {
            return DNS.GetIpFromHostname(Hostname);
        }

        public string HostnameFromIp(string Ip)
        {
            return DNS.GetHostnameFromIp(Ip);
        }

        public string LocalPing()
        {
            return connectivity.LocalPing(new StringBuilder(), new Ping());
        }

        public string Traceroute(string IpAddressOrHostname)
        {
            return connectivity.Traceroute(IpAddressOrHostname, new StringBuilder());
        }

        public string DisplayDHCPServerAddresses()
        {
            return DHCP.DisplayDhcpServerAddresses(new StringBuilder());
        }
    }
}
