using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SWZ.ViewModels
{
    class CommandHandler : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _action;
        private Action<object> _actionParam;

        public CommandHandler(Action action)
        {
            this._action = action;
        }
        public CommandHandler(Action<object> action)
        {
            this._actionParam = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_actionParam != null)
                this._actionParam(parameter);
            else
                this._action();
        }
    }
}
