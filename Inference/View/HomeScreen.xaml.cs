using Inference.ViewModel;
using System.Windows.Controls;

namespace Inference.View
{
    /// <summary>
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : Page
    {
        HomeScreenVM homeVM;

        public HomeScreen()
        {
            InitializeComponent();

            homeVM = new HomeScreenVM();
        }
    }
}
