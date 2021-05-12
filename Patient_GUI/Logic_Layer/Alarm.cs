using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace Logic_Layer
{
    public class Alarm 
    {
        /// <summary>
        /// Denne metode skal tjekke på den indkommende data fra operatør siden. Den tjekker altså om den data der kommer ind
        /// passer med det gatingvindue der er blevet lavet fra operatør siden. Passer data ind i vinduet, sætter den gatingstate. 
        /// </summary>
        /// <param name="obj"></param>
        public void CheckGating(object obj)
        {
            DTO_Measurement data = obj as DTO_Measurement;

            if (data.GatingLowerValue <= data.MeasurementData && data.MeasurementData <= data.GatingUpperValue)
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
