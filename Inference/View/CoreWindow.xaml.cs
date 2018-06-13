using Inference.Model;
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
    /// Interaction logic for CoreWindow.xaml
    /// </summary>
    public partial class CoreWindow : Window
    {
        ReportsVM viewModel;
        public CoreWindow()
        {
            InitializeComponent();
            viewModel = new ReportsVM();
            container.DataContext = viewModel;
        }

        private void CreateIssueButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.CreateReport();
        }

        private void DeleteListViewItem_Click(object sender, RoutedEventArgs e)
        {
            Report rmReport = issueListView.SelectedItem as Report;
            DatabaseHelper.Delete(rmReport);
            viewModel.ReadReports();
        }

        private void SortStatusButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SortReports(2);
        }

        private void AllissuesButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ReadReports();
        }

        private void CreatedbyButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SortReports(0);
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SortReports(1);
        }

        private void PriorityButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SortReports(3);
        }
    }
}
