using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using DTO;
using Logic_Layer.Interface;

namespace Patient_GUI
{
    /// <summary>
    /// Interaction logic for Standard_GUI.xaml
    /// </summary>
    public partial class Standard_GUI : Window, IObserver_GUI

    {
        public Standard_GUI()
        {
            InitializeComponent();

        }

        public void Update(object obj)
        {
            double move;
            DTO_Measurement _data = obj as DTO_Measurement;

            
            
            move = Math.Round(_data.MeasurementData * 450, 1);





            Standard.Dispatcher.Invoke(DispatcherPriority.Normal,
                    new Action(() => { Canvas.SetBottom(BlockPosition, move); }));
            if (move >= _data.GatingLowerValue && move < _data.GatingUpperValue)
            {
                Standard.Dispatcher.Invoke(DispatcherPriority.Normal,
                    new Action(() => { Alarm.Visibility = Visibility.Visible; }));
            }
            else if (move < -0.5)
            {
                
            }
            else
            {
                
                
                Standard.Dispatcher.Invoke(DispatcherPriority.Normal,
                    new Action(() => { Alarm.Visibility = Visibility.Hidden; }));
            }


            

            
           



        }
    }
}

