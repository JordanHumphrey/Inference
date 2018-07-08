using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inference.View.User_Controls.Doughnut_Chart
{
    /// <summary>
    /// Interaction logic for DougnutChart.xaml
    /// </summary>
    public partial class DougnutChart : UserControl
    {
        public DougnutChart()
        {
            InitializeComponent();

            

            ColorsCollection = new ColorsCollection
            {
                new Color
                {
                    R = 255,
                    G = 102,
                    B = 102,
                    A = 255
                },
                new Color
                {
                    A = 255,
                    R = 153,
                    G = 51,
                    B = 255
                },
                new Color
                {
                    A = 255,
                    R = 102,
                    G = 255,
                    B = 178
                },
                new Color
                {
                    A = 255,
                    R = 255,
                    G = 153,
                    B = 51,
                }
            };

            SeriesCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Mozilla",
                    Values = new ChartValues<ObservableValue> {new ObservableValue(8)},
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Chrome",
                    Values = new ChartValues<ObservableValue> {new ObservableValue(6)},
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Opera",
                    Values = new ChartValues<ObservableValue> {new ObservableValue(10)},
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title = "Edge",
                    Values = new ChartValues<ObservableValue> {new ObservableValue(4)},
                    DataLabels = true
                }

            };

            //adding values or series will update and animate the chart automatically
            //SeriesCollection.Add(new PieSeries());
            //SeriesCollection[0].Values.Add(5);

            DataContext = this;
        }

        public ColorsCollection ColorsCollection { get; set; }
        public SeriesCollection SeriesCollection { get; set; }

        private void RestartOnClick_Click(object sender, RoutedEventArgs e)
        {
            Chart.Update(true, true);
        }

        private void AddSeriesOnClick_Click(object sender, RoutedEventArgs e)
        {
            var r = new Random();
            var c = SeriesCollection.Count > 0 ? SeriesCollection[0].Values.Count : 5;

            var vals = new ChartValues<ObservableValue>();

            for (var i = 0; i < c; i++)
            {
                vals.Add(new ObservableValue(r.Next(0, 10)));
            }

            SeriesCollection.Add(new PieSeries
            {
                Values = vals
            });
        }

        private void UpdateAllOnClick_Click(object sender, RoutedEventArgs e)
        {
            var r = new Random();

            foreach(var series in SeriesCollection)
            {
                foreach(var observable in series.Values.Cast<ObservableValue>())
                {
                    observable.Value = r.Next(0, 10);
                }
            }
        }

        private void RemoveSeriesOnClick_Click(object sender, RoutedEventArgs e)
        {
            if (SeriesCollection.Count > 0)
                SeriesCollection.RemoveAt(0);
        }

        private void AddValueOnClick_Click(object sender, RoutedEventArgs e)
        {
            var r = new Random();
            foreach (var series in SeriesCollection)
            {
                series.Values.Add(new ObservableValue(r.Next(0, 10)));
            }
        }

        private void RemoveValueOnClick_Click(object sender, RoutedEventArgs e)
        {
            foreach (var series in SeriesCollection)
            {
                if (series.Values.Count > 0)
                    series.Values.RemoveAt(0);
            }
        }
    }
}
