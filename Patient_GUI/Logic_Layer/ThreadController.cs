using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Data_Layer;
using DTO;

namespace Logic_Layer
{
    public class ThreadController
    {
        public void startup(DataDistributor dataDistributor)
        {
            //,
            BlockingCollection<DTO_Measurement> _measurementQueue = new BlockingCollection<DTO_Measurement>();
            
            DataUDP _udp = new DataUDP(_measurementQueue);
            dataDistributor._measurementQueue = _measurementQueue;



            Thread _udpThread = new Thread(_udp.RecieveData);
            Thread _dataThread = new Thread(dataDistributor.DataCollector);
            

            _udpThread.IsBackground = true;
            _dataThread.IsBackground = true;


            _udpThread.Start();
            _dataThread.Start();

        }
    }
}
