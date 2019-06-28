using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task1.Model
{
    [Serializable]
    [XmlRoot(ElementName = ("weatherdata"))]
    public class WeatherdataClass
    {
        private Weather _weather = new Weather();

        public event PropertyChangedEventHandler PropertyChanged;

        [XmlElement(ElementName = "weather")]
        public Weather weather {
            get { return _weather; }
            set
            {
                _weather = value;
                OnPropertChanged(nameof(weather));
            }
        }
        void OnPropertChanged(string propertyName)
        {
            if (PropertyChanged != null)
            { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
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
        public string weatherlocationcode {
            get { return _weatherlocationcode; }
            set
            {
                _weatherlocationcode = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "weatherlocationname")]
        public string weatherlocationname {
            get { return _weatherlocationname; }
            set
            {
                _weatherlocationname = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "url")]
        public string url {
            get { return _url; }
            set
            {
                _url = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "imagerelativeurl")]
        public string imagerelativeurl {
            get { return _imagerelativeurl; }
            set
            {
                _imagerelativeurl = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "degreetype")]
        public string degreetype {
            get { return _degreetype; }
            set
            {
                _degreetype = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "provider")]
        public string provider {
            get { return _provider; }
            set
            {
                _provider = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "attribution")]
        public string attribution {
            get { return _attribution; }
            set
            {
                _attribution = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "attribution2")]
        public string attribution2 {
            get { return _attribution2; }
            set
            {
                _attribution2 = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "lat")]
        public string lat {
            get { return _lat; }
            set
            {
                _lat = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "long")]
        public string longitude {
            get { return _longitude; }
            set
            {
                _longitude = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "timezone")]
        public string timezone {
            get { return _timezone; }
            set
            {
                _timezone = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "alert")]
        public string alert {
            get { return _alert; }
            set
            {
                _alert = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "entityid")]
        public string entityid {
            get { return _entityid; }
            set
            {
                _entityid = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "encodedlocationname")]
        public string encodedlocationname {
            get { return _encodedlocationname; }
            set
            {
                _encodedlocationname = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlElement(ElementName = "current")]
        public Current current {
            get { return _Current; }
            set
            {
                _Current = value;
                OnPropertChanged(nameof(current));
            }
        }
        [XmlElement(ElementName = "forecast")]
        public List<Forecast> forecast {
            get
            {
                return _forecast;
            }
            set
            {
                _forecast = value;
                OnPropertChanged(nameof(Forecast));
            }
        }
        [XmlElement(ElementName = "toolbar")]
        public Toolbar toolbar {
            get { return _Toolbar; }
            set
            {
                _Toolbar = value;
                OnPropertChanged(nameof(toolbar));
            }
        }

        void OnPropertChanged(string propertyName)
        {
            if (PropertyChanged != null)
            { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
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
        public string temperature {
            get { return _temperature; }
            set
            {
                _temperature = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "skycode")]
        public string skycode {
            get { return _skycode; }
            set
            {
                _skycode = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "skytext")]
        public string skytext {
            get { return _skytext; }
            set
            {
                _skytext = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "date")]
        public string date {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "observationtime")]
        public string observationtime {
            get { return _observationtime; }
            set
            {
                _observationtime = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "observationpoint")]
        public string observationpoint {
            get { return _observationpoint; }
            set
            {
                _observationpoint = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "feelslike")]
        public string feelslike {
            get { return _feelslike; }
            set
            {
                _feelslike = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "humidity")]
        public string humidity {
            get { return _humidity; }
            set
            {
                _humidity = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "winddisplay")]
        public string winddisplay {
            get { return _winddisplay; }
            set
            {
                _winddisplay = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "day")]
        public string day {
            get { return _day; }
            set
            {
                _day = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "shortday")]
        public string shortday {
            get { return _shortday; }
            set
            {
                _shortday = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "windspeed")]
        public string windspeed {
            get { return _windspeed; }
            set
            {
                _windspeed = value;
                OnPropertChanged(string.Empty);
            }
        }
        void OnPropertChanged(string propertyName)
        {
            if (PropertyChanged != null)
            { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
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
            get { return _low; }
            set
            {
                _low = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlElement(ElementName = "high")]
        public string high
        {
            get { return _high; }
            set
            {
                _high = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlElement(ElementName = "skycodeday")]
        public string skycodeday
        {
            get { return _skycodeday; }
            set
            {
                _skycodeday = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "skytextday")]
        public string skytextday
        {
            get { return _skytextday; }
            set
            {
                _skytextday = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "date")]
        public string date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "day")]
        public string day
        {
            get { return _day; }
            set
            {
                _day = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "shortday")]
        public string shortday
        {
            get { return _shortday; }
            set
            {
                _shortday = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlAttribute(AttributeName = "precip")]
        public string precip
        {
            get { return _precip; }
            set
            {
                _precip = value;
                OnPropertChanged(string.Empty);
            }
        }
        void OnPropertChanged(string propertyName)
        {
            if (PropertyChanged != null)
            { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }
    }
    public class Toolbar
    {
        private string _timewindow = string.Empty;
        private string _minversion = string.Empty;
        public event PropertyChangedEventHandler PropertyChanged;
        [XmlAttribute(AttributeName = "timewindow")]
        public string timewindow {
            get { return _timewindow; }
            set
            {
                _timewindow = value;
                OnPropertChanged(string.Empty);
            }
        }
        [XmlElement(ElementName = "minversion")]
        public string minversion {
            get { return _minversion; }
            set
            {
                _minversion = value;
                OnPropertChanged(string.Empty);
            }
        }
        void OnPropertChanged(string propertyName)
        {
            if (PropertyChanged != null)
            { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }
    }
}
