using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace Logic_Layer
{
    class ConcreteSubject : Subject
    {
        public BlockingCollection<DTO_Measurement> _measurementQueue;


        public ConcreteSubject()
        {
            _measurementQueue = new BlockingCollection<DTO_Measurement>();
        }


        public void aaaaa()
        {
            DTO_Measurement _data = new DTO_Measurement();

            _data = _measurementQueue.Take();

            NotifyGui(_data);
        }

    }
}
