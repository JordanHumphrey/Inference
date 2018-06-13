using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inference.Model
{
    public class Report : INotifyPropertyChanged
    {
        private string bugId;
        [PrimaryKey]

        public string BugId
        {
            get { return bugId; }
            set { bugId = value; OnPropertyChanged("bugId"); }
        }

        private string project;

        public string Project
        {
            get { return project; }
            set { project = value; OnPropertyChanged("Project"); }
        }

        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged("Status"); }
        }

        private string resolution;

        public string Resolution
        {
            get { return resolution; }
            set { resolution = value; OnPropertyChanged("Resolution"); }
        }

        private string summary;

        public string Summary
        {
            get { return summary; }
            set { summary = value; OnPropertyChanged("Summary"); }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }

        private string assignedTo;

        public string AssignedTo
        {
            get { return assignedTo; }
            set { assignedTo = value; OnPropertyChanged("AssignedTo"); }
        }

        private string createdBy;
        [Indexed]

        public string CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; OnPropertyChanged("CreatedBy"); }
        }

        private string category;

        public string Category
        {
            get { return category; }
            set { category = value; OnPropertyChanged("Category"); }
        }

        private string severity;

        public string Severity
        {
            get { return severity; }
            set { severity = value; OnPropertyChanged("Severity"); }
        }

        private string priority;

        public string Priority
        {
            get { return priority; }
            set { priority = value; OnPropertyChanged("Priority"); }
        }

        private string eta;

        public string ETA
        {
            get { return eta; }
            set { eta = value; OnPropertyChanged("ETA"); }
        }
        private string reproducibility;

        public string Reproducibility
        {
            get { return reproducibility; }
            set { reproducibility = value; OnPropertyChanged("Reproducibility"); }
        }

        private DateTime dateSubmitted;

        public DateTime DateSubmitted
        {
            get { return dateSubmitted; }
            set { dateSubmitted = value; OnPropertyChanged("DateSubmitted"); }
        }

        private DateTime dateUpdated;

        public DateTime DateUpdated
        {
            get { return dateUpdated; }
            set { dateUpdated = value; OnPropertyChanged("DateUpdated"); }
        }

        private string versionBuiild;

        public string VersionBuild
        {
            get { return versionBuiild; }
            set { versionBuiild = value; OnPropertyChanged("VersionFixed"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
