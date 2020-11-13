using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace Refactoring
{
    /// <summary>
    /// Class for DHCP tools
    /// </summary>
    public class DHCP
    {
        // Method to dislay dhcp server's ipaddress
        public string DisplayDhcpServerAddresses(StringBuilder stringBuilder)
        {
            stringBuilder.Append("DHCP Servers" + Environment.NewLine);

            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties adapteradapterProperties = adapter.GetIPProperties();
                IPAddressCollection addresses = adapteradapterProperties.DhcpServerAddresses;
                if (addresses.Count > 0)
                {
                    stringBuilder.Append(adapter.Description + Environment.NewLine);

                    foreach (IPAddress address in addresses)
                    {
                        stringBuilder.Append(address.ToString());
                    }
                }
            }
            return stringBuilder.ToString();
        }
    }
}
