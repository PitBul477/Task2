using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Xml.Serialization;

namespace Task1.Model
{
    //класс "Модель города"
    public class CityModel : INotifyPropertyChanged
    {
        private const string SiteUrl = "http://weather.service.msn.com/data.aspx?weasearchstr=";
        private const string ParamUrl = "&culture=en-US&weadegreetype=C&src=outlook";
        private static Dictionary<string, string> _staticDictionaryWeatherData;
        private Dictionary<string, string> _dictionaryWeatherData;

        //событие изменения свойства
        public event PropertyChangedEventHandler PropertyChanged;

        //возвращает или устанавливает значение для поля "Имя города"
        public string CityName { get; }

        //возвращает или устанавливает значение для поля "Статический словарь данных погоды" или "Словарь данных погоды" в зависимости от настройки конфигурации
        public Dictionary<string, string> DictionaryUnloading
        {
            get
            {
                if (Settings.SaveData)
                    return _dictionaryWeatherData;
                else
                    return _staticDictionaryWeatherData;
            }
            set
            {
                if (Settings.SaveData)
                    _dictionaryWeatherData = value;
                else
                    _staticDictionaryWeatherData = value;
                OnPropertChanged(nameof(DictionaryUnloading));
            }
        }

        //создает объекты класса "Модель город"
        public CityModel(string name)
        {
            CityName = name ?? throw new ArgumentException();
            _dictionaryWeatherData = new Dictionary<string, string>();
            _staticDictionaryWeatherData = new Dictionary<string, string>();
        }

        //функция получения ответа get-запроса и формировании на его основе полей "Словарей выгрузки" 
        public void UnloadingWeatherData()
        {
            var url = $"{SiteUrl}{CityName}{ParamUrl}";
            var request = WebRequest.Create(url).GetResponse();
            var temp = new Dictionary<string, string>();
            var formatter = new XmlSerializer(typeof(WeatherdataClass));
            using (var reader = new StreamReader(request.GetResponseStream()))
                if (reader != null)
                {
                    var weatherdata = (WeatherdataClass)formatter.Deserialize(reader);
                    temp.Add("Имя места назначения", weatherdata.weather.weatherlocationname);
                    temp.Add("Широта", weatherdata.weather.lat);
                    temp.Add("Долгота", weatherdata.weather.longitude);
                    temp.Add("Дата", weatherdata.weather.current.date);
                    temp.Add("День недели", weatherdata.weather.current.day);
                    temp.Add("Время наблюдения", weatherdata.weather.current.observationtime);
                    temp.Add("Часовой пояс", weatherdata.weather.timezone);
                    temp.Add("Температура", weatherdata.weather.current.temperature + "°" + weatherdata.weather.degreetype);
                    temp.Add("Ощущается как", weatherdata.weather.current.feelslike + "°" + weatherdata.weather.degreetype);
                    temp.Add("Облачность", weatherdata.weather.current.skytext);
                    temp.Add("Влажность", weatherdata.weather.current.humidity + "%");
                    temp.Add("Направление и скорость ветра", weatherdata.weather.current.winddisplay);
                    temp.Add("ПРОГНОЗ ПОГОДЫ", string.Empty);
                    for (var i = 0; i < 4; i++)
                    {
                        temp.Add($"Прогноз на {weatherdata.weather.forecast[i].date}", $" день недели: {weatherdata.weather.forecast[i].day}, температура мин: {weatherdata.weather.forecast[i].low}°{weatherdata.weather.degreetype}, температура макс: {weatherdata.weather.forecast[i].high}°{weatherdata.weather.degreetype}, облачность: {weatherdata.weather.forecast[i].skytextday}");
                    }
                    DictionaryUnloading = temp;
                }
            request.Close();
        }

        private void OnPropertChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
