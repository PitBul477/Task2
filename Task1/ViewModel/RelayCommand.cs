using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Task1.ViewModel
{
    //класс RelayCommand, реализующий интерфейс ICommand
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Predicate<object> _canExecute;

        //событие, вызывающееся при изменении условий выполняемости команды
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //конструктор класса RelayCommand
        public RelayCommand(Action execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentException();
            if (canExecute != null)
                _canExecute = canExecute;
        }

        //метод, определяющий, может ли команда выполняться
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        //метод, выполняющий команду
        public void Execute(object parameter)
        {
            _execute();
        }
    }
}
