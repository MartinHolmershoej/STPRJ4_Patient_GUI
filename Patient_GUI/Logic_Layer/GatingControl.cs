using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace Logic_Layer
{
    public class GatingControl
    {
        private bool state = false;
        // lav denne klasse til et concrete subject.
        public void CheckGating(object obj)
        {
            DTO_Measurement data = obj as DTO_Measurement;

            if (data.GatingLowerValue <= data.MeasurementData && data.MeasurementData >= data.GatingUpperValue)
            {
                state = true;
            }
            else
            {
                state = false;
            }
            // kald notify her med state som variable
        }
    }
}
