using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Logic_Layer.Interface;

namespace Patient_GUI
{
    class Standard_GUI : IObserver_GUI
    {
        public void Update(object obj)
        {
            DTO_Measurement _data = obj as DTO_Measurement;
            throw new NotImplementedException();
        }
    }
}
