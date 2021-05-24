using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_Layer.Interface
{
    /// <summary>
    /// Dette interface bruges til klasserne Standard_GUI, Christmas_GUI og MainWindow
    /// </summary>
    public interface IObserver_GUI
    {
            void Update(Object obj);
    }
    
}
