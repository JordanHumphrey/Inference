using Inference.Model;
using Inference.View;
using Inference.View.Commands;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inference.ViewModel
{
    public class HomeScreenVM : INotifyPropertyChanged
    {
        #region Collections For Display Feed

        /// <summary>
        /// Collection of lists to display to users on home screen,
        /// to be updated every 30 seconds.
        /// </summary>
        public ObservableCollection<News> NewsList { get; set; }
        public ObservableCollection<Report> IssuesList { get; set; }
        public ObservableCollection<Project> ProjectsList { get; set; }

        #endregion

        #region Commands

        public NewNewsCommand NewNewsCommand { get; set; }

        #endregion Commands

        #region EVENT HANDLERS

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion EVENT HANDLERS

        #region Constructors

        public HomeScreenVM()
        {
            NewNewsCommand = new NewNewsCommand(this);

            NewsList = new ObservableCollection<News>();
            IssuesList = new ObservableCollection<Report>();
            ProjectsList = new ObservableCollection<Project>();

            RefreshLists();
        }

        #endregion Constructors

        #region DATA READING, DETACHED THREAD NEEDED

        public void RefreshLists()
        {
            ReadNews();
            ReadIssues();
            //ReadProjects();
        }

        public void ReadNews()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                var news = conn.Table<News>().ToList();

                NewsList.Clear();
                foreach(var article in news)
                {
                    NewsList.Add(article);
                }
            }
        }

        public void ReadIssues()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                var issues = conn.Table<Report>().ToList();

                IssuesList.Clear();
                foreach (var issue in issues)
                {
                    IssuesList.Add(issue);
                }
            }
        }

        public void ReadProjects()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                var projects = conn.Table<Project>().ToList();

                ProjectsList.Clear();
                foreach (var project in projects)
                {
                    ProjectsList.Add(project);
                }
            }
        }

        #endregion DATA READING, DETACHED THREAD NEEDED

        #region News

        public void CreateNews()
        {
            NewNewsItemWindow newNewsItemWindow = new NewNewsItemWindow();
            newNewsItemWindow.ShowDialog();

            RefreshLists();
        }

        #endregion News
    }
}
