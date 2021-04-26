﻿using System;
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
        /// 
        /// </summary>
        private DTO_Measurement dto_measurement;
        /// <summary>
        /// 
        /// </summary>
        private double step;
        /// <summary>
        /// Constructor for Christmas_GUI uden parameter
        /// </summary>
        public Christmas_GUI()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Denne metode skal bruges til at flytte blokken i vinduet og fremvise "Hold vejret"-beskeden til patienten
        /// </summary>
        /// <param name="obj"></param>
        public void Update(object obj)
        {
            dto_measurement = new DTO_Measurement();

            step = dto_measurement.MeasurementData;

            Christmas.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => { Canvas.SetBottom(BlockPosition, step); }));
            
            if (step >= dto_measurement.GatingLowerValue && step < dto_measurement.GatingUpperValue)
            {
                Christmas.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => { label.Visibility = Visibility.Visible; }));
            }
            else
            {
                Christmas.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => { label.Visibility = Visibility.Hidden; }));
            }

        }

    }

}
