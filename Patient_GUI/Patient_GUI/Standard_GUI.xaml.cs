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
            DTO_Measurement _data = obj as DTO_Measurement;
            

            int move = 1;
            bool skift = true;
            for (int j = 0; j < 1000000; j++)
            {
                if (skift)
                {
                    Standard.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                        new Action(() => { Canvas.SetBottom(BlockPosition, move); }));
                    move++;
                    if (move == 350)
                    {
                        skift = false;
                    }

                    if (move >= 1 && move < 200)
                    {
                        Standard.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                            new Action(() => { Alarm.Visibility = Visibility.Visible; }));
                    }
                    else
                    {
                        Standard.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                            new Action(() => { Alarm.Visibility = Visibility.Hidden; }));
                    }
                }

                else
                {
                    Standard.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                        new Action(() => { Canvas.SetBottom(BlockPosition, move); }));
                    move--;
                    if (move == 0)
                    {
                        skift = true;
                    }
                }

                Thread.Sleep(10);
                throw new NotImplementedException();
            }


        }
    }
}
    
