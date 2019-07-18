using System.Collections.Generic;
using System.ComponentModel;
using City;
using MyCommand;

namespace MyVM
{
    //класс модели представления (ViewModel) для связи с Model и View
    public class ViewModel : INotifyPropertyChanged
    {
        private CityModel _selectedCity;
        //событие изменения свойства
        public event PropertyChangedEventHandler PropertyChanged;

        //возвращает значение коллекции городов
        public IEnumerable<CityModel> Cities { get; }

        //возвращает или устанавливает значение для поля selectedCity, которое хранит в себе выбранный в ComboBox-е город
        public CityModel SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                OnPropertyChanged(nameof(SelectedCity));
            }
        }

        //возвращает значение команды на запуск формирования get-запроса
        public RelayCommand GetInfoWeather { get; }

        //конструктор модели представления, создаёт объекты для коллекции городов и задаёт команду
        public ViewModel()
        {
            Cities = new List<CityModel> {
                new CityModel("Москва"),
                new CityModel("Череповец"),
                new CityModel("Токио"),
                new CityModel("Осака"),
                new CityModel("Квебек")
            };
            GetInfoWeather = new RelayCommand(() => SelectedCity.UnloadingWeatherData(), CheckSelectedCity);
        }

        private bool CheckSelectedCity(object obj)
        {
            return SelectedCity != null;
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
