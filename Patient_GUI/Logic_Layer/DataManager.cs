using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace Logic_Layer
{
    public class DataManager : Subject
    {
        public BlockingCollection<DTO_Measurement> _measurementQueue;
        Alarm _gateControl = new Alarm();


        public DataManager()
        {
            _measurementQueue = new BlockingCollection<DTO_Measurement>();
        }


        public void DataCollector()
        {
            while (true)
            {
                DTO_Measurement _data = new DTO_Measurement();

                _data = _measurementQueue.Take();

                _gateControl.CheckGating(_data);

                NotifyGui(_data);
            }
        }

    }
}
