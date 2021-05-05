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
        /// <summary>
        /// En attribut af typen double, der bruges til at flytte blokken
        /// </summary>
        public double step { get; set; }
        
        /// <summary>
        /// Constructor for Christmas_GUI uden parameter
        /// </summary>
        public Christmas_GUI()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Denne metode skal bruges til at flytte blokken i vinduet og fremvise "Hold vejret"-beskeden til patienten. Indeholder object som parameter
        /// </summary>
        /// <param name="obj"></param>
        public void Update(object obj)
        {
            DTO_Measurement dto_measurement = obj as DTO_Measurement;

            step = dto_measurement.MeasurementData;

            step = Math.Round(dto_measurement.MeasurementData * 450, 1);

            Christmas.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() => { Canvas.SetBottom(BlockPosition, step); }));
            //Christmas.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => { Canvas.SetBottom(greensleigh, step); }));
            //Christmas.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => { Canvas.SetBottom(sleigh, step); }));

            if (step >= dto_measurement.GatingLowerValue && step < dto_measurement.GatingUpperValue)
            {
                Christmas.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => { HoldLabel.Visibility = Visibility.Visible; }));
                //GatingArea.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 128, 0));
                //GatingArea.Fill = new SolidColorBrush(Colors.Yellow);
            }
            else
            {
                Christmas.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => { HoldLabel.Visibility = Visibility.Hidden; }));
            }

        }

    }

}
