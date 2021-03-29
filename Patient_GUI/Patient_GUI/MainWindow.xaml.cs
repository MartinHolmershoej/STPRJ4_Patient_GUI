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
using Logic_Layer;

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

        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread blockThread = new Thread(MoveBlockThread);
            blockThread.IsBackground = true;
            blockThread.Start();
        }

        public void MoveBlockThread()
        {
            int move = 1;
            bool skift = true;
            for (int j = 0; j < 1000000; j++)
            {
                if (skift)
                {
                    Canvas.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Canvas.SetBottom(BlockPosition, move);
                    }));
                    move++;
                    if (move == 350)
                    {
                        skift = false;
                    }
                    if (move >= 150 && move < 200)
                    {
                        Canvas.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                        {
                            label.Visibility = Visibility.Visible;
                        }));
                    }
                    else
                    {
                        Canvas.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                        {
                            label.Visibility = Visibility.Hidden;
                        }));
                    }
                }

                else
                {
                    Canvas.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Canvas.SetBottom(BlockPosition, move);
                    }));
                    move--;
                    if (move == 0)
                    {
                        skift = true;
                    }
                }
                Thread.Sleep(10);
            }
        }
    }
}
