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
    //Класс модели представления (ViewModel) для связи с Model и View
    public class ViewModels : INotifyPropertyChanged
    {
        //событие изменения свойства
        public event PropertyChangedEventHandler PropertyChanged; 
        private City selectedCity;

        //Свойство для коллекции городов
        public IEnumerable<City> Cities { get; }

        //свойство для поля selectedCity, которое хранит в себе выбранный в ComboBox-е город
        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                OnPropertyChanged("selectedCity");
            }
        }

        //конструктор модели представления, создаёт объекты для коллекции городов и задаёт команду
        public ViewModels()
        {
            Cities = new List<City> {
                new City {CityName = "Москва" },
                new City {CityName = "Череповец" },
                new City {CityName = "Токио" },
                new City {CityName = "Осака" },
                new City {CityName = "Квебек" }
            };
            GetInfoWeather = new RelayCommand(() => { selectedCity.GetUrl(); });
        }

        //команда на запуск формирования get-запроса
        public RelayCommand GetInfoWeather { get; }

        //функция для обработки изменений, в качестве аргументра принимает название метода, вызвавшего изменение, ничего не возвращает
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}