using Inference.View.User_Controls;
using Inference.ViewModel.Interfaces;
using Inference.ViewModel.LoginVM;
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

namespace Inference.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page, IHavePassword
    {
        public Login()
        {
            InitializeComponent();
            LoginVM vm = new LoginVM();
            DataContext = vm;
            vm.HasLoggedIn += Vm_HasLoggedIn;
        }

        public System.Security.SecureString Password
        {
            get
            {
                return AccntPasswordLoginEntry_TextBox.SecurePassword;
            }
        }

        private void Vm_HasLoggedIn(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new HomeScreen());
        }

        private void NewAccntBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginGrid.Visibility = Visibility.Collapsed;
            newAccountGrid.Visibility = Visibility.Visible;
        }
        
        private void RememberedAccntBtn_Click(object sender, RoutedEventArgs e)
        {
            newAccountGrid.Visibility = Visibility.Collapsed;
            LoginGrid.Visibility = Visibility.Visible;
        }
    }
}
