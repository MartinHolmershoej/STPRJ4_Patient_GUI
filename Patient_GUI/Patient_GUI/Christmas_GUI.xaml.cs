using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using Logic_Layer;
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
        public double move { get; set; }
        public double UpperGatingValue { get; set; }
        public double LowerGatingValue { get; set; }

        public int Height { get; set; }

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

            move = dto_measurement.MeasurementData;




            UpperGatingValue = dto_measurement.GatingUpperValue;
            LowerGatingValue = dto_measurement.GatingLowerValue;
            Height = Convert.ToInt32((UpperGatingValue * 450) - (LowerGatingValue * 450));



            Christmas.Dispatcher.Invoke(DispatcherPriority.Normal,
                new Action(() =>
                {
                    Canvas.SetBottom(BlockPosition, move);
                    Canvas.SetBottom(GatingArea, (LowerGatingValue * 450));


                    int lowerGatingValue1 = 0;

                    lowerGatingValue1 = Convert.ToInt32(LowerGatingValue * 450);

                    GatingArea.Height = Height;
                    Canvas.SetBottom(GatingArea, (lowerGatingValue1));
                    GatingArea.Height = Height;


                    move = Math.Round(dto_measurement.MeasurementData * 450, 1);
                    Canvas.SetBottom(BlockPosition, move);

                    if (dto_measurement.GatingState)
                    {
                        HoldLabel.Visibility = Visibility.Visible;
                        //SystemSounds.Beep.Play();
                    }
                    else
                    {
                        HoldLabel.Visibility = Visibility.Hidden;
                    }

                }));




        }

    }

}
