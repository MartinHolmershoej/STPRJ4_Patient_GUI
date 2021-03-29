using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Data_Layer
{
    class DataUDP
    {

        private BlockingCollection<double> blockingCollection;



        private static int port0 = 11000;


        private UdpClient udpClient;





        public void UdpRecieveData()
        {
            udpClient = new UdpClient(port0);
            var remoteIP = new IPEndPoint(IPAddress.Any, port0);
            byte[] bytes;
            string jason;


            using (Socket sock1 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0)) ;
            {
                sock1.connect("1213.1323.13131", 11000);
                IPEndPoint endpoint = sock1.localEndPoint as IPEndPoint;

            }
            try
            {
                while (true)
                {

                }

            }
            catch (Exception)
            {

                throw;
            }








        }


    }
}
