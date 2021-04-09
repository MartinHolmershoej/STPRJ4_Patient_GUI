using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Data_Layer;
using DTO;

namespace Logic_Layer
{
    public class LogicController
    {
        public void startup()
        {
            BlockingCollection<DTO_Measurement> _measurementQueue = new BlockingCollection<DTO_Measurement>();
            
            DataUDP _udp = new DataUDP(_measurementQueue);
            ConcreteSubject Dostuff = new ConcreteSubject();

            Dostuff._measurementQueue = _measurementQueue;



            // ændre navnet på dostuff senere



            Thread _udpThread = new Thread(_udp.RecieveData);
            Thread _dostuffThread = new Thread(Dostuff.aaaaa);



            _udpThread.IsBackground = true;
            _dostuffThread.IsBackground = true;


            _udpThread.Start();
            _dostuffThread.Start();

        }
    }
}
