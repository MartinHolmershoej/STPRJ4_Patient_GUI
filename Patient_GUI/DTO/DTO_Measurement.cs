using System;

namespace DTO
{
    public class DTO_Measurement
    {
        /// <summary>
        /// Denne property af typen double indeholder data af målingen
        /// </summary>
        public double MeasurementData { get; set; }
        /// <summary>
        /// Denne property af typen double indeholder gatingvinduets mindste værdi
        /// </summary>
        public double GatingLowerValue { get; set; }
        /// <summary>
        /// Denne property af typen double indeholder gatingvinduets højeste værdi
        /// </summary>
        public double GatingUpperValue { get; set; }
        /// <summary>
        /// Denne property af typen bool indeholder tilstanden af gatingvinduet 
        /// </summary>
        public bool GatingState { get; set; }
        /// <summary>
        /// Constructor til klassen uden parameter
        /// </summary>
        public DTO_Measurement(double measurement, double gatingLowerValue, double gatingUpperValue, bool gatingState)
        {
            measurement = MeasurementData;
            gatingLowerValue = GatingLowerValue;
            gatingUpperValue = GatingUpperValue;
            gatingState = GatingState;
        }

    }
}