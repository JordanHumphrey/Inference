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
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : Window
    {
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void ExploreButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AccountsButton_Click(object sender, RoutedEventArgs e)
        {
            homepageGrid.Visibility = Visibility.Collapsed;
            accountsPageGrid.Visibility = Visibility.Visible;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            homepageGrid.Visibility = Visibility.Collapsed;
            createPageGrid.Visibility = Visibility.Visible;
        }

        private void NewAccountButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditAccountButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveAccountButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SubmitCreateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HomeScreenButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
