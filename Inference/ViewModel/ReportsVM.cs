using Inference.Model;
using Inference.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Inference.ViewModel
{
    public class ReportsVM : INotifyPropertyChanged
    {
        public ObservableCollection<Report> Reports { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ReportsVM()
        {
            Reports = new ObservableCollection<Report>();

            ReadReports();
        }

        public void CreateReport()
        {
            NewIssueWindow issueWindow = new NewIssueWindow();
            issueWindow.ShowDialog();
            
            //while(string.IsNullOrEmpty(issueWindow.bugIdTextBox.Text) || (issueWindow.bugIdTextBox.Text == "Enter BugId"))
            //{
            //    const string message = "Missing Data Field Entry\nTo Cancel Report, OK | Finish Report, CANCEL";
            //    const string caption = "Missing Data Entry(s)";
            //    var result = MessageBox.Show(message, caption, MessageBoxButton.OKCancel, MessageBoxImage.Information);
                
            //    if(result == MessageBoxResult.OK)
            //    {
            //        return;
            //    }
            //    else if(result == MessageBoxResult.Cancel)
            //    {
                    
            //    }
            //}

            Report newReport = new Report()
            {
                BugId = issueWindow.bugIdTextBox.Text,
                Status = issueWindow.statusComboBox.SelectionBoxItem.ToString(),
                Priority = issueWindow.priorityComboBox.SelectionBoxItem.ToString(),
                Category = issueWindow.categoryTextBox.Text,
                Reproducibility = issueWindow.reproducibilityTextBox.Text,
                Description = issueWindow.descriptionTextBox.Text,
                CreatedBy = issueWindow.createdByTextBox.Text,
                AssignedTo = issueWindow.assignedToTextBox.Text,
                Project = issueWindow.projectTextBox.Text,
                Resolution = issueWindow.resolutionTextBox.Text,
                ETA = issueWindow.etaTextBox.Text,
                VersionBuild = issueWindow.versionBuildTextBox.Text,
                Summary = issueWindow.summaryTextBox.Text
            };

            DatabaseHelper.Insert(newReport);
            ReadReports();
        }

        /// <summary>
        /// Read Reports from Database
        /// </summary>
        public void ReadReports()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                var reports = conn.Table<Report>().ToList();

                Reports.Clear();
                foreach (var report in reports)
                {
                    Reports.Add(report);
                }
            }
        }

        public void SortReports(int sortId)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                switch (sortId)
                {
                    case 0:
                        var reportCreatedBy = conn.Table<Report>().OrderBy(r => r.CreatedBy).ToList();
                        Reports.Clear();

                        foreach (var reportC in reportCreatedBy)
                        {
                            Reports.Add(reportC);
                        }
                        break;

                    case 1:
                        var reportCategory = conn.Table<Report>().OrderBy(r => r.Category).ToList();
                        Reports.Clear();

                        foreach (var reportCat in reportCategory)
                        {
                            Reports.Add(reportCat);
                        }
                        break;

                    case 2:
                        var reportStatus = conn.Table<Report>().OrderBy(r => r.Status).ToList();
                        Reports.Clear();

                        foreach (var reportStat in reportStatus)
                        {
                            Reports.Add(reportStat);
                        }
                        break;

                    case 3:
                        var reportPriority = conn.Table<Report>().OrderBy(r => r.Priority).ToList();
                        Reports.Clear();

                        foreach (var reportP in reportPriority)
                        {
                            Reports.Add(reportP);
                        }
                        break;

                    default:
                        ReadReports();
                        break;
                }
            }
            if(sortId == 0)
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
                {
                    var reports = conn.Table<Report>().OrderBy(r => r.Status).ToList();

                    Reports.Clear();
                    foreach (var report in reports)
                    {
                        Reports.Add(report);
                    }
                }
            }
            
        }
    }
}
