using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameGui.ViewModel
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> executeAction;
        private readonly Func<object, bool> canExecutePredicate;

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            executeAction = execute;
            canExecutePredicate = canExecute;
        }


        public bool CanExecute(object parameter)
        {
            return canExecutePredicate(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter))
            {
                throw new InvalidOperationException("Cannot execute now (nikita)");
            }
            executeAction(parameter);
        }


        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
