using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wpf_practice.core
{
    internal class RelayCommand : ICommand
    {

        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }

        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool canExecute(object parameter)
        {
            return _canExecute == null || canExecute(parameter);
        }


        public void Execute(object parameter) {

            _execute(parameter);
        }

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }




}
