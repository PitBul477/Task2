using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Task1.ViewModel
{
    //класс RelayCommand, реализующий интерфейс ICommand
    public class RelayCommand : ICommand
    {
        private Action execute;
        private Predicate<object> canExecute;

        //событие, вызывающееся при изменении условий выполняемости команды
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //конструктор класса RelayCommand
        public RelayCommand(Action execute, Predicate<object> canExecute = null)
        {
            this.execute = execute;
            if (canExecute != null)
                this.canExecute = canExecute;
        }

        //метод, определяющий, может ли команда выполняться
        public bool CanExecute(object parameter)
        {
            if (canExecute != null)
                return canExecute(parameter);
            return true;
        }

        //метод, выполняющий команду
        public void Execute(object parameter)
        {
            execute();
        }
    }
}
