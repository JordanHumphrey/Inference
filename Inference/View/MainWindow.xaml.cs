using Inference.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Inference.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region ViewModel Objects

        HomeScreenVM homeVM;


        #endregion

        public MainWindow()
        {
            InitializeComponent();
            homeVM = new HomeScreenVM();
            MainWin.Content = new HomeScreen();
        }
    }
}
