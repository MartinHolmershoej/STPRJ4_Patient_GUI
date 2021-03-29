using System;
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

namespace Patient_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            // hej med dig, hvordan har du det? 
            // godt
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Thread skideThread = new Thread(Skid);
                skideThread.IsBackground = true;
                skideThread.Start();
            }

            private void Skid()
            {
                int flyt = 1;
                bool skift = true;
                for (int j = 0; j < 1000000; j++)
                {
                    if (skift)
                    {
                        Virk_nu.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                        {
                            Canvas.SetBottom(FuckingVirk, flyt);
                        }));
                        flyt++;
                        if (flyt == 350)
                        {
                            skift = false;
                        }
                        if (flyt >= 150 && flyt < 200)
                        {
                            Virk_nu.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                            {
                                label.Visibility = Visibility.Visible;
                            }));
                        }
                        else
                        {
                            Virk_nu.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                            {
                                label.Visibility = Visibility.Hidden;
                            }));
                        }
                    }

                    else
                    {
                        Virk_nu.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                        {
                            Canvas.SetBottom(FuckingVirk, flyt);
                        }));
                        flyt--;
                        if (flyt == 0)
                        {
                            skift = true;
                        }
                    }
                    Thread.Sleep(10);
                }
            }
        }
    }
}
