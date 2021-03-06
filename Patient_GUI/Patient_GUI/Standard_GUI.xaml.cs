using System;
using System.Collections.Generic;
using System.Media;
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
        public double move { get; set; }
        public double UpperGatingValue { get; set; }
        public double LowerGatingValue { get; set; }
        public int Height { get; set; }

        
        public Standard_GUI()
        {
            InitializeComponent();
            UpperGatingValue = 0;
            LowerGatingValue = 50;
            Height = 20;
        }

        public void Update(object obj)
        {
            int lowerGatingValue1 = 0;
            DTO_Measurement _data = obj as DTO_Measurement;

            UpperGatingValue = _data.GatingUpperValue;
            LowerGatingValue = _data.GatingLowerValue;
            Height = Convert.ToInt32((UpperGatingValue * 450) - (LowerGatingValue * 450));

            lowerGatingValue1 = Convert.ToInt32(LowerGatingValue * 450);

            Standard.Dispatcher.Invoke(DispatcherPriority.Normal,
                new Action(() =>
                {
                    Canvas.SetBottom(GatingArea, (lowerGatingValue1));
                    GatingArea.Height = Height;


                    move = Math.Round(_data.MeasurementData * 450, 1);
                    Canvas.SetBottom(BlockPosition, move);

                    if (_data.GatingState)
                    {
                        Alarm.Visibility = Visibility.Visible;
                        SystemSounds.Beep.Play();
                    }
                    else
                    {
                        Alarm.Visibility = Visibility.Hidden;
                    }

                }));
        }
    }
}

