using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
        // lopdater grafen

        throw new NotImplementedException();
    }

    //int move = 1;
    //bool skift = true;
    //    for (int j = 0; j< 1000000; j++)
    //{
    //    if (skift)
    //    {
    //        Canvas.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
    //        {
    //            Canvas.SetBottom(BlockPosition, move);
    //        }));
    //        move++;
    //        if (move == 350)
    //        {
    //            skift = false;
    //        }
    //        if (move >= 150 && move< 200)
    //        {
    //            Canvas.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
    //            {
    //                label.Visibility = Visibility.Visible;
    //            }));
    //        }
    //        else
    //        {
    //            Canvas.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
    //            {
    //                label.Visibility = Visibility.Hidden;
    //            }));
    //        }
    //    }

    //    else
    //    {
    //        Canvas.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
    //        {
    //            Canvas.SetBottom(BlockPosition, move);
    //        }));
    //        move--;
    //        if (move == 0)
    //        {
    //            skift = true;
    //        }
    //    }
    //    Thread.Sleep(10);
    }
}
