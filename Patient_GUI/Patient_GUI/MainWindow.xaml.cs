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
        private ThreadController _controller;
        private DataDistributor _dataDistributor;
        public MainWindow()
        {
            InitializeComponent();
            _controller = new ThreadController();
            _dataDistributor = new DataDistributor();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Loading.Visibility = Visibility.Visible;
            int _Theme =_dataDistributor.GetTheme();

            if (_Theme == 1)
            {
                Standard_GUI standardGui = new Standard_GUI();
                standardGui.Show();
                _dataDistributor.Attach(standardGui);
            }
            if (_Theme == 2)
            {
                Christmas_GUI christmasGui = new Christmas_GUI();
                christmasGui.Show();
                _dataDistributor.Attach(christmasGui);
            }

            Loading.Visibility = Visibility.Hidden;
            _controller.startup();
            this.Hide();
        }
    }
}
