using Inference.Model;
using Inference.ViewModel;
using SQLite;
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
    /// Interaction logic for NewIssueWindow.xaml
    /// </summary>
    public partial class NewIssueWindow : Window
    {
        ReportsVM vm = new ReportsVM();
        public NewIssueWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Report report = new Report()
            {
                BugId = bugIdTextBox.Text,
                Status = statusComboBox.SelectionBoxItem.ToString(),
                Priority = priorityComboBox.SelectionBoxItem.ToString(),
                Category = categoryTextBox.Text,
                Reproducibility = reproducibilityTextBox.Text,
                Description = descriptionTextBox.Text,
                CreatedBy = createdByTextBox.Text,
                AssignedTo = assignedToTextBox.Text,
                Project = projectTextBox.Text,
                Resolution = resolutionTextBox.Text,
                ETA = etaTextBox.Text,
                VersionBuild = versionBuildTextBox.Text,
                Summary = summaryTextBox.Text
            };

            Close();
        }
    }
}
