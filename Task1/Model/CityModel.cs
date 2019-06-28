using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using System.Configuration;
using System.Windows;

namespace Task1.Model
{
    //класс модели City
    public class CityModel : INotifyPropertyChanged
    {
        private const string SiteUrl = "http://weather.service.msn.com/data.aspx?weasearchstr=";
        private const string ParamUrl = "&culture=en-US&weadegreetype=C&src=outlook";
        private string _cityName = string.Empty;
        private string _cityUrl = string.Empty;
        private static string _staticcityUrl = string.Empty;

        private static Dictionary<string, string> _staticdictionaryCity = new Dictionary<string, string>(12);
        private Dictionary<string,string> _dictionaryCity = new Dictionary<string, string>(12);

        //событие изменения свойства
        public event PropertyChangedEventHandler PropertyChanged;

        //возвращает или устанавливает значение для поля "Имя города"
        public string CityName
        {
            get { return _cityName; }
            private set
            {
                _cityName = value;
            }
        }

        public Dictionary<string, string> StaticDictionaryCity
        {
            get { return _staticdictionaryCity; }
            set
            {
                _staticdictionaryCity = value;
                OnPropertChanged(nameof(StaticDictionaryCity));
            }
        }

        public Dictionary<string, string> DictionaryCity
        {
            get { return _dictionaryCity; }
            set
            {
                _dictionaryCity = value;
                OnPropertChanged(nameof(DictionaryCity));
            }
        }

        //возвращает или устанавливает значение для поля "Запрос по городу"
        public string CityUrl
        {
            get { return _cityUrl; }
            set
            {
                _cityUrl = value;
                OnPropertChanged(string.Empty);
            }
        }

        public string StaticCityUrl
        {
            get { return _staticcityUrl; }
            set
            {
                _staticcityUrl = value;
                OnPropertChanged(string.Empty);
            }
        }

        //конструктор класса "Город"
        public CityModel(string name)
        {
            _cityName = name ?? throw new ArgumentException();
        }

        //функция вычисления cityUrl из других полей и с помощью get-запроса
        public void GetUrl()
        {
            var url = $"{SiteUrl}{CityName}{ParamUrl}";
            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            ref string chat = ref _cityUrl;
            XmlSerializer formatter = new XmlSerializer(typeof(WeatherdataClass));
            
            using (var stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    WeatherdataClass Weatherdata = (WeatherdataClass)formatter.Deserialize(reader);
                    if (Settings.SwitchSave == true)
                    {
                        chat = ref _cityUrl;
                        var temp = new Dictionary<string, string>();
                        temp.Add("Имя места назначения", $"{Weatherdata.weather.weatherlocationname}");
                        temp.Add("Широта", $"{Weatherdata.weather.lat}");
                        temp.Add("Долгота", $"{Weatherdata.weather.longitude}");
                        temp.Add("Дата", $"{Weatherdata.weather.current.date}");
                        temp.Add("День недели", $"{Weatherdata.weather.current.day}");
                        temp.Add("Время наблюдения", $"{Weatherdata.weather.current.observationtime}");
                        temp.Add("Часовой пояс", $"{Weatherdata.weather.timezone}");
                        temp.Add("Температура", $"{Weatherdata.weather.current.temperature}°{Weatherdata.weather.degreetype}");
                        temp.Add("Ощущается как", $"{Weatherdata.weather.current.feelslike}°{Weatherdata.weather.degreetype}");
                        temp.Add("Облачность", $"{Weatherdata.weather.current.skytext}");
                        temp.Add("Влажность", $"{Weatherdata.weather.current.humidity}%");
                        temp.Add("Направление и скорость ветра", $"{Weatherdata.weather.current.winddisplay}");
                        DictionaryCity = temp;
                    }
                    else
                    {
                        chat = ref _staticcityUrl;
                        var temp = new Dictionary<string, string>();
                        temp.Add("Имя места назначения", $"{Weatherdata.weather.weatherlocationname}");
                        temp.Add("Широта", $"{Weatherdata.weather.lat}");
                        temp.Add("Долгота", $"{Weatherdata.weather.longitude}");
                        temp.Add("Дата", $"{Weatherdata.weather.current.date}");
                        temp.Add("День недели", $"{Weatherdata.weather.current.day}");
                        temp.Add("Время наблюдения", $"{Weatherdata.weather.current.observationtime}");
                        temp.Add("Часовой пояс", $"{Weatherdata.weather.timezone}");
                        temp.Add("Температура", $"{Weatherdata.weather.current.temperature}°{Weatherdata.weather.degreetype}");
                        temp.Add("Ощущается как", $"{Weatherdata.weather.current.feelslike}°{Weatherdata.weather.degreetype}");
                        temp.Add("Облачность", $"{Weatherdata.weather.current.skytext}");
                        temp.Add("Влажность", $"{Weatherdata.weather.current.humidity}%");
                        temp.Add("Направление и скорость ветра", $"{Weatherdata.weather.current.winddisplay}");
                        StaticDictionaryCity = temp;
                    }
                    chat = $"Прогноз на: {Weatherdata.weather.forecast[0].date}, день недели: {Weatherdata.weather.forecast[0].day}, температура мин: {Weatherdata.weather.forecast[0].low}°{Weatherdata.weather.degreetype}, температура макс: {Weatherdata.weather.forecast[0].high}°{Weatherdata.weather.degreetype}, облачность: {Weatherdata.weather.forecast[0].skytextday}\nПрогноз на: {Weatherdata.weather.forecast[1].date}, день недели: {Weatherdata.weather.forecast[1].day}, температура мин: {Weatherdata.weather.forecast[1].low}°{Weatherdata.weather.degreetype}, температура макс: {Weatherdata.weather.forecast[1].high}°{Weatherdata.weather.degreetype}, облачность: {Weatherdata.weather.forecast[1].skytextday}\nПрогноз на: {Weatherdata.weather.forecast[2].date}, день недели: {Weatherdata.weather.forecast[2].day}, температура мин: {Weatherdata.weather.forecast[2].low}°{Weatherdata.weather.degreetype}, температура макс: {Weatherdata.weather.forecast[2].high}°{Weatherdata.weather.degreetype}, облачность: {Weatherdata.weather.forecast[2].skytextday}\nПрогноз на: {Weatherdata.weather.forecast[3].date}, день недели: {Weatherdata.weather.forecast[3].day}, температура мин: {Weatherdata.weather.forecast[3].low}°{Weatherdata.weather.degreetype}, температура макс: {Weatherdata.weather.forecast[3].high}°{Weatherdata.weather.degreetype}, облачность: {Weatherdata.weather.forecast[3].skytextday}\nПрогноз на: {Weatherdata.weather.forecast[4].date}, день недели: {Weatherdata.weather.forecast[4].day}, температура мин: {Weatherdata.weather.forecast[4].low}°{Weatherdata.weather.degreetype}, температура макс: {Weatherdata.weather.forecast[4].high}°{Weatherdata.weather.degreetype}, облачность: {Weatherdata.weather.forecast[4].skytextday}";
                    OnPropertChanged(string.Empty);
                }
            }

            response.Close();
        }

        void OnPropertChanged(string propertyName)
        {
            if (PropertyChanged != null)
            { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }
    }
}
