using System;
using System.Windows.Input;

namespace Task1.ViewModel
{
    //класс RelayCommand, реализующий интерфейс ICommand
    public class RelayCommand : ICommand    //класс чего? дай название
    {
        private readonly Action _execute;
        private readonly Predicate<object> _canExecute;

        //событие, вызывающееся при изменении условий выполняемости команды
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        //создаёт объекты класса RelayCommand
        public RelayCommand(Action execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentException();
            if (canExecute != null)
                _canExecute = canExecute;
        }

        //определяет, может ли команда выполняться
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        //выполнение команды
        public void Execute(object parameter)
        {
            _execute();
        }
    }
}
