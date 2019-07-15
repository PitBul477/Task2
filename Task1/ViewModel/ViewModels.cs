using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Task1.Model;

namespace Task1.ViewModel
{
    //класс модели представления (ViewModel) для связи с Model и View
    public class ViewModels : INotifyPropertyChanged
    {
        private CityModel _selectedCity;
        //событие изменения свойства
        public event PropertyChangedEventHandler PropertyChanged;

        System.Configuration.Configuration currentConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        //возвращает значение коллекции городов
        public IEnumerable<CityModel> Cities { get; }

        //возвращает или устанавливает значение для поля selectedCity, которое хранит в себе выбранный в ComboBox-е город
        public CityModel SelectedCity
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
        //возвращает или устанавливает значение для обработки сохранения конфигурации
        public RelayCommand WindowClosing { get; private set; }
        ////возвращает или устанавливает значение для значения типа сохранения данных в конфигурации
        public bool SetCheck
        {
            get { return Settings.SwitchSave; }
            set
            {
                Settings.SwitchSave = value;
                OnPropertyChanged("selectedCity");
            }
        }

        //конструктор модели представления, создаёт объекты для коллекции городов и задаёт команду
        public ViewModels()
        {            
            Cities = new List<CityModel> {
                new CityModel("Москва"),
                new CityModel("Череповец"),
                new CityModel("Токио"),
                new CityModel("Осака"),
                new CityModel("Квебек")
            };
            GetInfoWeather = new RelayCommand(() => { SelectedCity.GetUrl(); }, CheckSelectedCity);
            this.WindowClosing = new RelayCommand(()=>SaveConf());
        }

        private bool CheckSelectedCity(object obj)
        {
            return SelectedCity != null;
        }
        
        private void SaveConf()
        {
            currentConfig.AppSettings.Settings["switchsave"].Value = Settings.SwitchSave.ToString();
            currentConfig.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        //функция для обработки изменений, в качестве аргументра принимает название метода, вызвавшего изменение, ничего не возвращает
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}