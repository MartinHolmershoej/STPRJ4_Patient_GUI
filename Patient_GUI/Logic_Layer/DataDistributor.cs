using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Data_Layer;
using DTO;

namespace Logic_Layer
{
    public class DataDistributor : Subject
    {
        public BlockingCollection<DTO_Measurement> _measurementQueue;
        Alarm _gateControl = new Alarm();
        private UDPTheme _udpTheme = new UDPTheme();


        public DataDistributor()
        {
            _measurementQueue = new BlockingCollection<DTO_Measurement>();
        }

        public int GetTheme()
        {
            // start udp for at få tema
            int _Theme = _udpTheme.RecieveTheme();
            return _Theme;
        }
        public void DataCollector()
        {
            while (true)
            {
                DTO_Measurement _data = _measurementQueue.Take();

                _gateControl.CheckGating(_data);

                NotifyGui(_data);

                

                
           }
        }

    }
}
