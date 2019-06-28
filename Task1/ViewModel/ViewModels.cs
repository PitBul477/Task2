using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Task1.Model;

namespace Task1.ViewModel
{
    //класс модели представления (ViewModel) для связи с Model и View
    public class ViewModels : INotifyPropertyChanged
    {
        private City _selectedCity;
        //событие изменения свойства
        public event PropertyChangedEventHandler PropertyChanged;

        //возвращает значение коллекции городов
        public IEnumerable<City> Cities { get; }

        //возвращает или устанавливает значение для поля selectedCity, которое хранит в себе выбранный в ComboBox-е город
        public City SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                _selectedCity = value;
                OnPropertyChanged("selectedCity");
            }
        }
        
        //возвращает значение команды на запуск формирования get-запроса
        public RelayCommand GetInfoWeather { get; }

        //конструктор модели представления, создаёт объекты для коллекции городов и задаёт команду
        public ViewModels()
        {
            Cities = new List<City> {
                new City("Москва"),
                new City("Череповец"),
                new City("Токио"),
                new City("Осака"),
                new City("Квебек")
            };
            GetInfoWeather = new RelayCommand(() => { SelectedCity.GetUrl(); }, CheckSelectedCity);
        }

        private bool CheckSelectedCity(object obj)
        {
            return SelectedCity != null;
        }
        
        //функция для обработки изменений, в качестве аргументра принимает название метода, вызвавшего изменение, ничего не возвращает
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}