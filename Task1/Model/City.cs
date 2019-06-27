using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Task1.Model
{
    //Класс модели City
    public class City : INotifyPropertyChanged
    {
        private const string SiteUrl = "http://weather.service.msn.com/data.aspx?weasearchstr=";
        private const string ParamUrl = "&culture=en-US&weadegreetype=C&src=outlook";
        private string _cityName = string.Empty;
        private string _cityUrl = string.Empty;

        //событие изменения свойства
        public event PropertyChangedEventHandler PropertyChanged;

        //Свойство для поля "Имя города"
        public string CityName
        {
            get { return _cityName; }
            set
            {
                _cityName = value;
                OnPropertChanged(string.Empty);
            }
        }

        //Свойство для поля "Запрос по городу"
        public string CityUrl
        {
            get { return _cityUrl; }
            set
            {
                _cityUrl = value;
                OnPropertChanged(string.Empty);
            }
        }

        //Функция вычисления cityUrl из других полей и с помощью get-запроса
        public void GetUrl()
        {
            if (CityName == null)
                throw new ArgumentException(String.Format("{0} не может принимать значение null", CityName), "CityName");
            var url = $"{SiteUrl}{CityName}{ParamUrl}";
            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            using (var stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    CityUrl = reader.ReadToEnd();
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
