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
using Logic_Layer.Interface;

namespace Patient_GUI
{
    /// <summary>
    /// Interaction logic for Christmas_GUI.xaml
    /// </summary>
    public partial class Christmas_GUI : Window, IObserver_GUI
    {
        public Christmas_GUI()
        {
            InitializeComponent();
        }

        public void Update(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
