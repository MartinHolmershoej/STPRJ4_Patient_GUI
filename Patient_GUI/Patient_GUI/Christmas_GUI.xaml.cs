using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using DTO;
using Logic_Layer.Interface;

namespace Patient_GUI
{
    /// <summary>
    /// Interaction logic for Christmas_GUI.xaml
    /// </summary>
    public partial class Christmas_GUI : Window, IObserver_GUI
    {
        private DTO_Measurement dto_measurement;
        public BlockingCollection<DTO_Measurement> _measurementQueue;
        private bool shift;
        private double step;
        public Christmas_GUI()
        {
            InitializeComponent();
        }

        public void Update(object obj)
        {
            

            while (!_measurementQueue.IsCompleted)
            {
                try
                {
                    dto_measurement = _measurementQueue.Take();

                    for (double i = 0; i < dto_measurement.GatingUpperValue; i++)
                    {
                        i = step;
                        if (shift)
                        {
                            
                            Canvas.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => { Canvas.SetBottom(BlockPosition, step); }));

                            step++;
                            if (step == 350)
                            {
                                shift = false;
                            }

                            if (step >= dto_measurement.GatingLowerValue && step < dto_measurement.GatingUpperValue)
                            {
                                Canvas.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => { label.Visibility = Visibility.Visible; }));
                            }
                            else
                            {
                                Canvas.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => { label.Visibility = Visibility.Hidden; }));
                            }
                        }
                        else
                        {
                            Canvas.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => { Canvas.SetBottom(BlockPosition, step); }));
                            step--;
                            if (step == 0)
                            {
                                shift = true;
                            }
                        }

                        Thread.Sleep(10);

                    }
                }
                catch
                {

                }
            }
        }

        public void MoveBlock(object sender, RoutedEventArgs e)
        {
        }
        
    }
}
