using System;
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

        //Свойство для динамической коллекции городов
        public ObservableCollection<City> Citys { get; set; }

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
            Citys = new ObservableCollection<City>
            {
                new City {CityName = "Москва", ID = 1 },
                new City {CityName = "Череповец", ID = 2 },
                new City {CityName = "Токио", ID = 3 },
                new City {CityName = "Осака", ID = 4 },
                new City {CityName = "Квебек", ID = 5 }
            };
            _GetInfoWeather = new RelayCommand((obj) => { selectedCity.URL(); });
        }

        private RelayCommand _GetInfoWeather;
        //команда на запуск формирования get-запроса
        public RelayCommand GetInfoWeather { get { return _GetInfoWeather; } }

        //функция для обработки изменений, в качестве аргументра принимает название метода, вызвавшего изменение, ничего не возвращает
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}