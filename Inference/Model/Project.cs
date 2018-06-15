using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inference.Model
{
    public class Project : INotifyPropertyChanged
    {
        private string name;
        [PrimaryKey, MaxLength(50)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string buildversion;
        public string BuildVersion
        {
            get { return buildversion; }
            set { buildversion = value; }
        }

        private string createdby;
        [Indexed]
        public string CreatedBy
        {
            get { return createdby; }
            set { createdby = value; }
        }

        private string description;
        [MaxLength(50)]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private DateTime creationdate; 
        public DateTime CreationDate
        {
            get { return creationdate; }
            set { creationdate = value; }
        }

        private string relevantinformation;
        [MaxLength(50)]
        public string RelevantInformation
        {
            get { return relevantinformation; }
            set { relevantinformation = value; }
        }

        private List<Report> projReports = new List<Report>(50);

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
