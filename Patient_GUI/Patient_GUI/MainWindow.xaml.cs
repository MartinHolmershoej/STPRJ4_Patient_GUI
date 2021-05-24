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
    /// Denne klasse er userinterfacet, hvor skærmen loader programmet.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Et objekt af ThreaController
        /// </summary>
        private ThreadController _controller;
        /// <summary>
        /// Et objekt af DataDistributor
        /// </summary>
        private DataDistributor _dataDistributor;

        /// <summary>
        /// Constructor for MainWindow uden parameter 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _controller = new ThreadController();
            _dataDistributor = new DataDistributor();
        }
        /// <summary>
        /// Denne metode henter tema-nummer fra DataDistributor-klassen, starter tråde op og tilkobler enten Standard- eller Christmas-
        /// klasserne alt efter tema-nummer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_ContentRendered(object sender, EventArgs e)
        {

            int _Theme =_dataDistributor.GetTheme();
            _controller.Startup(_dataDistributor);
            if (_Theme == 1)
            {
                Standard_GUI standardGui = new Standard_GUI();
                standardGui.Show();
                _dataDistributor.Attach(standardGui);
                this.Hide();
            }
            if (_Theme == 2)
            {
                Christmas_GUI christmasGui = new Christmas_GUI();
                christmasGui.Show();
                _dataDistributor.Attach(christmasGui);
                this.Hide();
            }
        }
    }
}
