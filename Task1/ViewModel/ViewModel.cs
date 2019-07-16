using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;
using Task1.Model;

namespace Task1.ViewModel
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

        //возвращает или устанавливает значение для значения типа сохранения данных в конфигурации
        public bool SetCheck
        {
            get { return Settings.SaveData; }
            set
            {
                Settings.SaveData = value;
                OnPropertyChanged("selectedCity");
            }
        }

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
            GetInfoWeather = new RelayCommand(() => SelectedCity.GetUrl(), CheckSelectedCity);
        }

        private bool CheckSelectedCity(object obj)
        {
            return SelectedCity != null;
        }

        private void OnPropertyChanged([CallerMemberName]string property = "")
        {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}