using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SerialCity
{
    [Serializable]
    [XmlRoot(ElementName = ("weatherdata"))]
    public class WeatherdataClass
    {
        private Weather _weather = new Weather();

        public event PropertyChangedEventHandler PropertyChanged;

        [XmlElement(ElementName = "weather")]
        public Weather weather
        {
            get => _weather;
            set
            {
                _weather = value;
                OnPropertChanged(nameof(weather));
            }
        }
        private void OnPropertChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Weather
    {
        private string _weatherlocationcode = string.Empty;
        private string _weatherlocationname = string.Empty;
        private string _url = string.Empty;
        private string _imagerelativeurl = string.Empty;
        private string _degreetype = string.Empty;
        private string _provider = string.Empty;
        private string _attribution = string.Empty;
        private string _attribution2 = string.Empty;
        private string _lat = string.Empty;
        private string _longitude = string.Empty;
        private string _timezone = string.Empty;
        private string _alert = string.Empty;
        private string _entityid = string.Empty;
        private string _encodedlocationname = string.Empty;
        private Current _Current = new Current();
        private List<Forecast> _forecast;
        private Toolbar _Toolbar = new Toolbar();

        public event PropertyChangedEventHandler PropertyChanged;

        [XmlAttribute(AttributeName = "weatherlocationcode")]
        public string weatherlocationcode
        {
            get => _weatherlocationcode;
            set
            {
                _weatherlocationcode = value;
                OnPropertChanged(nameof(weatherlocationcode));
            }
        }
        [XmlAttribute(AttributeName = "weatherlocationname")]
        public string weatherlocationname
        {
            get => _weatherlocationname;
            set
            {
                _weatherlocationname = value;
                OnPropertChanged(nameof(weatherlocationname));
            }
        }
        [XmlAttribute(AttributeName = "url")]
        public string url
        {
            get => _url;
            set
            {
                _url = value;
                OnPropertChanged(nameof(url));
            }
        }
        [XmlAttribute(AttributeName = "imagerelativeurl")]
        public string imagerelativeurl
        {
            get => _imagerelativeurl;
            set
            {
                _imagerelativeurl = value;
                OnPropertChanged(nameof(imagerelativeurl));
            }
        }
        [XmlAttribute(AttributeName = "degreetype")]
        public string degreetype
        {
            get => _degreetype;
            set
            {
                _degreetype = value;
                OnPropertChanged(nameof(degreetype));
            }
        }
        [XmlAttribute(AttributeName = "provider")]
        public string provider
        {
            get => _provider;
            set
            {
                _provider = value;
                OnPropertChanged(nameof(provider));
            }
        }
        [XmlAttribute(AttributeName = "attribution")]
        public string attribution
        {
            get => _attribution;
            set
            {
                _attribution = value;
                OnPropertChanged(nameof(attribution));
            }
        }
        [XmlAttribute(AttributeName = "attribution2")]
        public string attribution2
        {
            get => _attribution2;
            set
            {
                _attribution2 = value;
                OnPropertChanged(nameof(attribution2));
            }
        }
        [XmlAttribute(AttributeName = "lat")]
        public string lat
        {
            get => _lat;
            set
            {
                _lat = value;
                OnPropertChanged(nameof(lat));
            }
        }
        [XmlAttribute(AttributeName = "long")]
        public string longitude
        {
            get => _longitude;
            set
            {
                _longitude = value;
                OnPropertChanged(nameof(longitude));
            }
        }
        [XmlAttribute(AttributeName = "timezone")]
        public string timezone
        {
            get => _timezone;
            set
            {
                _timezone = value;
                OnPropertChanged(nameof(timezone));
            }
        }
        [XmlAttribute(AttributeName = "alert")]
        public string alert
        {
            get => _alert;
            set
            {
                _alert = value;
                OnPropertChanged(nameof(alert));
            }
        }
        [XmlAttribute(AttributeName = "entityid")]
        public string entityid
        {
            get => _entityid;
            set
            {
                _entityid = value;
                OnPropertChanged(nameof(entityid));
            }
        }
        [XmlAttribute(AttributeName = "encodedlocationname")]
        public string encodedlocationname
        {
            get => _encodedlocationname;
            set
            {
                _encodedlocationname = value;
                OnPropertChanged(nameof(encodedlocationname));
            }
        }
        [XmlElement(ElementName = "current")]
        public Current current
        {
            get => _Current;
            set
            {
                _Current = value;
                OnPropertChanged(nameof(current));
            }
        }
        [XmlElement(ElementName = "forecast")]
        public List<Forecast> forecast
        {
            get => _forecast;
            set
            {
                _forecast = value;
                OnPropertChanged(nameof(Forecast));
            }
        }
        [XmlElement(ElementName = "toolbar")]
        public Toolbar toolbar
        {
            get => _Toolbar;
            set
            {
                _Toolbar = value;
                OnPropertChanged(nameof(toolbar));
            }
        }

        private void OnPropertChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Current
    {
        private string _temperature = string.Empty;
        private string _skycode = string.Empty;
        private string _skytext = string.Empty;
        private string _date = string.Empty;
        private string _observationtime = string.Empty;
        private string _observationpoint = string.Empty;
        private string _feelslike = string.Empty;
        private string _humidity = string.Empty;
        private string _winddisplay = string.Empty;
        private string _day = string.Empty;
        private string _shortday = string.Empty;
        private string _windspeed = string.Empty;
        public event PropertyChangedEventHandler PropertyChanged;
        [XmlAttribute(AttributeName = "temperature")]
        public string temperature
        {
            get => _temperature;
            set
            {
                _temperature = value;
                OnPropertChanged(nameof(temperature));
            }
        }
        [XmlAttribute(AttributeName = "skycode")]
        public string skycode
        {
            get => _skycode;
            set
            {
                _skycode = value;
                OnPropertChanged(nameof(skycode));
            }
        }
        [XmlAttribute(AttributeName = "skytext")]
        public string skytext
        {
            get => _skytext;
            set
            {
                _skytext = value;
                OnPropertChanged(nameof(skytext));
            }
        }
        [XmlAttribute(AttributeName = "date")]
        public string date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertChanged(nameof(date));
            }
        }
        [XmlAttribute(AttributeName = "observationtime")]
        public string observationtime
        {
            get => _observationtime;
            set
            {
                _observationtime = value;
                OnPropertChanged(nameof(observationtime));
            }
        }
        [XmlAttribute(AttributeName = "observationpoint")]
        public string observationpoint
        {
            get => _observationpoint;
            set
            {
                _observationpoint = value;
                OnPropertChanged(nameof(observationpoint));
            }
        }
        [XmlAttribute(AttributeName = "feelslike")]
        public string feelslike
        {
            get => _feelslike;
            set
            {
                _feelslike = value;
                OnPropertChanged(nameof(feelslike));
            }
        }
        [XmlAttribute(AttributeName = "humidity")]
        public string humidity
        {
            get => _humidity;
            set
            {
                _humidity = value;
                OnPropertChanged(nameof(humidity));
            }
        }
        [XmlAttribute(AttributeName = "winddisplay")]
        public string winddisplay
        {
            get => _winddisplay;
            set
            {
                _winddisplay = value;
                OnPropertChanged(nameof(winddisplay));
            }
        }
        [XmlAttribute(AttributeName = "day")]
        public string day
        {
            get => _day;
            set
            {
                _day = value;
                OnPropertChanged(nameof(day));
            }
        }
        [XmlAttribute(AttributeName = "shortday")]
        public string shortday
        {
            get => _shortday;
            set
            {
                _shortday = value;
                OnPropertChanged(nameof(shortday));
            }
        }
        [XmlAttribute(AttributeName = "windspeed")]
        public string windspeed
        {
            get => _windspeed;
            set
            {
                _windspeed = value;
                OnPropertChanged(nameof(windspeed));
            }
        }
        private void OnPropertChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Forecast
    {
        private string _low = string.Empty;
        private string _high = string.Empty;
        private string _skycodeday = string.Empty;
        private string _skytextday = string.Empty;
        private string _date = string.Empty;
        private string _day = string.Empty;
        private string _shortday = string.Empty;
        private string _precip = string.Empty;
        public event PropertyChangedEventHandler PropertyChanged;
        [XmlAttribute(AttributeName = "low")]
        public string low
        {
            get => _low;
            set
            {
                _low = value;
                OnPropertChanged(nameof(low));
            }
        }
        [XmlAttribute(AttributeName = "high")]
        public string high
        {
            get => _high;
            set
            {
                _high = value;
                OnPropertChanged(nameof(high));
            }
        }
        [XmlAttribute(AttributeName = "skycodeday")]
        public string skycodeday
        {
            get => _skycodeday;
            set
            {
                _skycodeday = value;
                OnPropertChanged(nameof(skycodeday));
            }
        }
        [XmlAttribute(AttributeName = "skytextday")]
        public string skytextday
        {
            get => _skytextday;
            set
            {
                _skytextday = value;
                OnPropertChanged(nameof(skytextday));
            }
        }
        [XmlAttribute(AttributeName = "date")]
        public string date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertChanged(nameof(date));
            }
        }
        [XmlAttribute(AttributeName = "day")]
        public string day
        {
            get => _day;
            set
            {
                _day = value;
                OnPropertChanged(nameof(day));
            }
        }
        [XmlAttribute(AttributeName = "shortday")]
        public string shortday
        {
            get => _shortday;
            set
            {
                _shortday = value;
                OnPropertChanged(nameof(shortday));
            }
        }
        [XmlAttribute(AttributeName = "precip")]
        public string precip
        {
            get => _precip;
            set
            {
                _precip = value;
                OnPropertChanged(nameof(precip));
            }
        }
        private void OnPropertChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Toolbar
    {
        private string _timewindow = string.Empty;
        private string _minversion = string.Empty;
        public event PropertyChangedEventHandler PropertyChanged;
        [XmlAttribute(AttributeName = "timewindow")]
        public string timewindow
        {
            get => _timewindow;
            set
            {
                _timewindow = value;
                OnPropertChanged(nameof(timewindow));
            }
        }
        [XmlAttribute(AttributeName = "minversion")]
        public string minversion
        {
            get => _minversion;
            set
            {
                _minversion = value;
                OnPropertChanged(nameof(minversion));
            }
        }
        private void OnPropertChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
