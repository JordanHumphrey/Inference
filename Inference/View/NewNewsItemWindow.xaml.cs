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
    /// Interaction logic for NewNewsItemWindow.xaml
    /// </summary>
    public partial class NewNewsItemWindow : Window
    {
        public NewNewsItemWindow()
        {
            InitializeComponent();
        }

        private void AddNewsButton_Click(object sender, RoutedEventArgs e)
        {
            News news = new News()
            {
                Name = NewsNameEntry.Text,
                NewsContent = NewsContentEntry.Text
            };

            using (SQLiteConnection connection = new SQLiteConnection(DatabaseHelper.dbFile))
            {
                connection.CreateTable<News>();
                connection.Insert(news);
            }

            Close();
        }
    }
}
