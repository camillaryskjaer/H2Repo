using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Text;

namespace Refactoring
{
    /// <summary>
    /// Class for DNS tools
    /// </summary>
    public class DNS
    {
        // Method to get ip adress from hostname
        public string GetIpFromHostname(string Hostname)
        {
            string ip = "";
            try
            {
                IPHostEntry ipHostEntry = Dns.Resolve(Hostname);
                if (ipHostEntry.AddressList.Length > 0)
                {
                    ip = ipHostEntry.AddressList[0].ToString();
                }
                else
                {
                    ip = "No information found.";
                }
            }
            // Exception handling
            catch (SocketException)
            {
                ip = "Unable to perform lookup - a socket error occured.";
                return ip;
            }
            catch (SecurityException)
            {
                ip = "Unable to perform lookup - permission denied.";
                return ip;
            }
            catch (Exception)
            {
                ip = "An unspecified error occured.";
                return ip;
            }

            return ip;
        }

        public string GetHostnameFromIp(string Ip)
        {
            string hostname = "";
            try
            {
                IPHostEntry ipHostEntry = Dns.GetHostByAddress(Ip);
                hostname = ipHostEntry.HostName;
            }
            catch (FormatException)
            {
                hostname = "Please specify a valid IP address.";
                return hostname;
            }
            catch (SocketException)
            {
                hostname = "Unable to perform lookup - a socket error occured.";
                return hostname;
            }
            catch (SecurityException)
            {
                hostname = "Unable to perform lookup - permission denied.";
                return hostname;
            }
            catch (Exception)
            {
                hostname = "An unspecified error occured.";
                return hostname;
            }

            return hostname;
        }
    }
}
