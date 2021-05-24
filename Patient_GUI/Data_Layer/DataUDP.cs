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
    /// <summary>
    /// Denne klasse modtager åndedrætsværdier fra UDP-forbindelsen fra Operatør-programmet.
    /// Klassen arver fra interfacet IConnection
    /// </summary>
    public class DataUDP : IConnection
    {
        /// <summary>
        /// Et objekt af blockingcollection af DTO-klassen DTO_Measurement
        /// </summary>
        private BlockingCollection<DTO_Measurement> measurementQueue;
        /// <summary>
        /// Et objekt af blockingcollection af DTO-klassen DTO_Measurement
        /// </summary>
        private DTO_Measurement measurement;
        /// <summary>
        /// En attribut af typen int, som fortæller om porten, data kommer fra
        /// </summary>
        private static int port0 = 11000;
        /// <summary>
        /// Et objekt af IPAddress, som fortæller om porten, der broadcastes fra
        /// </summary>
        private IPAddress broadCastIP;
        /// <summary>
        /// Constructor for klassen DataUDP med blockingcollection af DTO_Measurement som parameter
        /// </summary>
        /// <param name="_measurementQueue"></param>

        public DataUDP(BlockingCollection<DTO_Measurement> _measurementQueue)
        {
            measurementQueue = _measurementQueue;
        }
        /// <summary>
        /// Denne metode bruges til at modtage data fra operatørsystemet
        /// </summary>
        public void RecieveData()
        {
            broadCastIP = IPAddress.Parse("127.0.0.1");
            UdpClient udpClient = new UdpClient(port0);
            var remoteIP = new IPEndPoint(broadCastIP, port0);
            byte[] bytes;
            string jason;

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
