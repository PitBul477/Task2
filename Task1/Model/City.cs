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
        const string SiteUrl = "http://weather.service.msn.com/data.aspx?weasearchstr=";
        const string ParamUrl = "&culture=en-US&weadegreetype=C&src=outlook";
        private string cityName = string.Empty;
        private string cityUrl = string.Empty;

        //Свойство для поля cityName
        public string CityName
        {
            get { return cityName; }
            set
            {
                cityName = value;
                OnPropertChanged(string.Empty);
            }
        }

        //Свойство для поля cityUrl
        public string CityUrl
        {
            get { return cityUrl; }
            set
            {
                cityUrl = value;
                OnPropertChanged(string.Empty);
            }
        }

        //событие изменения свойства
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertChanged(string propertyName)
        {
            if (PropertyChanged != null)
            { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }

        //Функция вычисления cityUrl из других полей и с помощью get-запроса
        public void GetUrl()
        {
            var url = ($"{SiteUrl}{CityName}{ParamUrl}");
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
    }
}
