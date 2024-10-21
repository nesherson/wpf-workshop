using System.Windows.Input;

namespace WPF.Tesetto.Word.Core
{
    public class RelayParameterizedCommand : ICommand
    {
        private Action<object> _action;

        public RelayParameterizedCommand(Action<object> action)
        {
            _action = action;
        }

        public event EventHandler? CanExecuteChanged = (sender, e) => { };

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}