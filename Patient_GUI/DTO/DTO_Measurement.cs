using System;

namespace DTO
{
    public class DTO_Measurement
    {
        public DTO_Measurement()
        {
        }

        public double MeasurementData { get; set; }
        public double GatingLowerValue { get; set; }
        public double GatingUpperValue { get; set; }
    }
}