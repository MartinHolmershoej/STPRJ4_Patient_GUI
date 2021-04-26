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
    /// Klassen UDPTheme bruges til at modtage tema fra operatørsystemet, som skal bruges til GUI'en
    /// </summary>
    public class UDPTheme
    {
        private static int port0 = 11001;

        /// <summary>
        /// Denne metode bruges til at modtaget et tal fra UDP-forbindelsen fra operatørsystemet.
        /// Tallet fortæller om de to forskellige temaer til GUI - Standard og Christmas. 
        /// </summary>
        /// <returns>Et tal, der indikerer tema til GUI</returns>
        public int RecieveTheme()
        {
            UdpClient udpClient = new UdpClient(port0);
            var remoteIP = new IPEndPoint(IPAddress.Any, port0);
            byte[] bytes;
            int _Theme =0;


            using (Socket sock2 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                sock2.Connect("1213.1323.13131", 11000);
                IPEndPoint endpoint = sock2.LocalEndPoint as IPEndPoint;

            }
            try
            {
                bytes = udpClient.Receive(ref remoteIP);
                _Theme = Convert.ToInt32(Encoding.ASCII.GetString(bytes, 0, bytes.Length));

            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                udpClient.Close();
            }
            return _Theme;
        }


    }
}