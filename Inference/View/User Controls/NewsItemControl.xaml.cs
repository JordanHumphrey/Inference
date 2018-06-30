using Inference.Model;
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

namespace Inference.View.User_Controls
{
    /// <summary>
    /// Interaction logic for NewsItemControl.xaml
    /// </summary>
    public partial class NewsItemControl : UserControl
    {
        public Model.News News
        {
            get { return (Model.News)GetValue(newsProperty); }
            set { SetValue(newsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisplayNews.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty newsProperty =
            DependencyProperty.Register("News", typeof(Model.News), typeof(NewsItemControl), new PropertyMetadata(new News() { Name = "Name LastInitial", NewsContent = "News Content" }, SetValues));


        private static void SetValues(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NewsItemControl news = d as NewsItemControl;

            if (news != null)
            {
                news.NewsNameTextBlock.Text = (e.NewValue as Model.News).Name;
                news.NewsItemTextBlock.Text = (e.NewValue as Model.News).NewsContent;
            }
        }
        
        public NewsItemControl()
        {
            InitializeComponent();
        }
    }
}
