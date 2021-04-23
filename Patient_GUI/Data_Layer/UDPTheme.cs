using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using DTO;

namespace Data_Layer
{
    public class UDPTheme
    {
        private static int port0 = 11001;

        public void RecieveTheme()
        {
            //UdpClient udpClient = new UdpClient(port0);
            //var remoteIP = new IPEndPoint(IPAddress.Any, port0);
            //byte[] bytes;
            //string jason;


            //using (Socket sock1 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            //{
            //    sock1.Connect("1213.1323.13131", 11000);
            //    IPEndPoint endpoint = sock1.LocalEndPoint as IPEndPoint;

            //}

            //try
            //{
            //    while (true)
            //    {
            //        bytes = udpClient.Receive(ref remoteIP);
            //        jason = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
            //    }

            //}
            //catch (SocketException e)
            //{
            //    Console.WriteLine(e);
            //}
            //finally
            //{
            //    udpClient.Close();
            //}

        }


    }
}