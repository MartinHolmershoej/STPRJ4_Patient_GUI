using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace Logic_Layer
{
    public class Alarm 
    {
        public void CheckGating(object obj)
        {
            DTO_Measurement data = obj as DTO_Measurement;

            if (data.GatingLowerValue <= data.MeasurementData && data.MeasurementData >= data.GatingUpperValue)
            {
                data.GatingState = true;
            }
            else
            {
                data.GatingState = false;
            }
        }
    }
}
