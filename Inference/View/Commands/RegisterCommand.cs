using Inference.Model;
using Inference.ViewModel.LoginVM;
using System;
using System.Windows.Input;

namespace Inference.View.Commands
{
    public class RegisterCommand : ICommand
    {
        public LoginVM VM { get; set; }
        public event EventHandler CanExecuteChanged;

        public RegisterCommand(LoginVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            var user = parameter as User;
            return true;
        }

        public void Execute(object parameter)
        {
            VM.Register();
        }
    }
}
