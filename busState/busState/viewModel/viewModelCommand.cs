using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace busState.viewModel
{
    public class viewModelCommand : ICommand
    {

        private readonly Action<object> _execute;
        private readonly Predicate<object> _Canexecute;

        public viewModelCommand(Action<object> execute, Predicate<object> canexecute)
        {
            _execute = execute;
            _Canexecute = canexecute;
        }

        public viewModelCommand(Action<object> execute)
        {
            _execute = execute;
            _Canexecute = null;
        }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _Canexecute==null? true :_Canexecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
