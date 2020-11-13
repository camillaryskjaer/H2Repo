using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace Refactoring
{
    /// <summary>
    /// Class to test connectivity
    /// </summary>
    public class Connectivity
    {
        // Methos to test local netcard
        public string LocalPing(StringBuilder stringBuilder, Ping pingSender)
        {
            try
            {
                // Ping's the local machine.
                IPAddress address = IPAddress.Loopback;
                PingReply reply = pingSender.Send(address);

                // Builds a string with the response
                if (reply.Status == IPStatus.Success)
                {
                    stringBuilder.Append("Address: " + reply.Address.ToString() + Environment.NewLine);
                    stringBuilder.Append("RoundTrip time: " + reply.RoundtripTime + Environment.NewLine);
                    stringBuilder.Append("Time to live: " + reply.Options.Ttl + Environment.NewLine);
                    stringBuilder.Append("Don't fragment: " + reply.Options.DontFragment + Environment.NewLine);
                    stringBuilder.Append("Buffer size: " + reply.Buffer.Length);

                    return stringBuilder.ToString();
                }
                else
                {
                    return reply.Status.ToString();
                }
            }
            catch (Exception)
            {
                return "An unknown error occured";
            }
        }

        // Method to trace a ping route
        public string Traceroute(string ipAddressOrHostName, StringBuilder traceResults)
        {
            try
            {
                IPAddress ipAddress = Dns.GetHostEntry(ipAddressOrHostName).AddressList[0];

                using (Ping pingSender = new Ping())
                {

                    PingOptions pingOptions = new PingOptions();
                    Stopwatch stopWatch = new Stopwatch();
                    byte[] bytes = new byte[32];

                    pingOptions.DontFragment = true;
                    pingOptions.Ttl = 1;
                    int maxHops = 30;

                    traceResults.AppendLine(
                        string.Format(
                            "Tracing route to {0} over a maximum of {1} hops:",
                            ipAddress,
                            maxHops));

                    traceResults.AppendLine();

                    for (int i = 1; i < maxHops + 1; i++)
                    {
                        stopWatch.Reset();
                        stopWatch.Start();

                        PingReply pingReply = pingSender.Send(
                            ipAddress,
                            5000,
                            new byte[32], pingOptions);

                        stopWatch.Stop();

                        traceResults.AppendLine(
                            string.Format("{0}\t{1} ms\t{2}",
                            i,
                            stopWatch.ElapsedMilliseconds,
                            pingReply.Address));



                        if (pingReply.Status == IPStatus.Success)
                        {
                            traceResults.AppendLine();
                            traceResults.AppendLine("Trace complete."); break;
                        }

                        pingOptions.Ttl++;
                    }
                }
                return traceResults.ToString();

            }
            catch (FormatException)
            {
                return "Please enter valid ip address or hostname";
            }
            catch (Exception)
            {
                return "An unknown error occured";
            }
        }
    }
}
