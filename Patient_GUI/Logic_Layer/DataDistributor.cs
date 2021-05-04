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
        
        /// <summary>
        /// Denne metode skal få temaet fra operatør siden når det er blevet valgt. Herefter skal den så retunere temaet,
        /// så man ved hvad det er for en skærm man skal bruge.
        /// </summary>
        /// <returns>Theme</returns>
        public int GetTheme()
        {
            // start udp for at få tema
            int _Theme = _udpTheme.RecieveTheme();
            return _Theme;
        }
        /// <summary>
        /// Datacollectoren skal sørge for at samle dataen der kommer, den skal så tage den data der er i køen ud af køen og derefter notify gui så man kan se grafen opdateres. 
        /// </summary>
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
