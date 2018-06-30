using Inference.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Inference.View.Commands
{
    public class NewNewsCommand : ICommand
    {
        public HomeScreenVM VM { get; set; }

        public event EventHandler CanExecuteChanged;

        public NewNewsCommand(HomeScreenVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.CreateNews();
        }
    }
}
