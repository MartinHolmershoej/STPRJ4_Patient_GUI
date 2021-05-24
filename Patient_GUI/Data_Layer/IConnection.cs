using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Layer
{
    /// <summary>
    /// Dette interface bruges til klasserne DataUDP
    /// </summary>
    public interface IConnection
    {
        public void RecieveData();
    }
}
