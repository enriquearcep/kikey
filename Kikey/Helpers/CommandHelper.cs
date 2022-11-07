using System;
using System.Windows.Input;

namespace Kikey.Helpers
{
    internal class CommandHelper : ICommand
    {
        private Action _action;
        private Func<bool> _canExecute;

        /// <summary>
        /// Creates instance of the command handler
        /// </summary>
        /// <param name="action">Action to be executed by the command</param>
        /// <param name="canExecute">A bolean property to containing current permissions to execute the command</param>
        public CommandHelper(Action action, Func<bool> canExecute = null)
        {
            _action = action;
            // _canExecute = new Func<bool>(Boolean.);
        }

        /// <summary>
        /// Wires CanExecuteChanged event 
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Forcess checking if execute is allowed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            // return _canExecute.Invoke();
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
