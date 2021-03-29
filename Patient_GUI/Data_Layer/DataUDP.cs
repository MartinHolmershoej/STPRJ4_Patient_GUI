using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using DTO;
using OperatoerLibrary;

namespace Data_Layer
{
    public class DataUDP : IConnection
    {

        private BlockingCollection<DTO_Measurement> measurementQueue;

        private DTO_Measurement measurement;

        private static int port0 = 11000;

        public DataUDP(BlockingCollection<DTO_Measurement> measurementQueue_)
        {
            measurementQueue = measurementQueue_;
        }

        public void UdpRecieveData()
        {
            UdpClient udpClient = new UdpClient(port0);
            
            var remoteIP = new IPEndPoint(IPAddress.Any, port0);
            byte[] bytes;
            string jason;


            using (Socket sock1 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                sock1.Connect("1213.1323.13131", 11000);
                IPEndPoint endpoint = sock1.LocalEndPoint as IPEndPoint;

            }

            try
            {
                while (true)
                {
                    bytes = udpClient.Receive(ref remoteIP);
                    jason = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    measurement = JsonSerializer.Deserialize<DTO_Measurement>(jason);
                    measurementQueue.Add(measurement);
                }

            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                udpClient.Close();
            }

        }


    }
}
