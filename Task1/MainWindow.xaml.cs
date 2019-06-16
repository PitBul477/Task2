using System;
using System.Windows;
using System.IO;
using System.Net;

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string SiteUrl = "http://weather.service.msn.com/data.aspx?weasearchstr=";
        const string ParamUrl = "&culture=en-US&weadegreetype=C&src=outlook";

        //Создание главного окна
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CityNameInput.Text != String.Empty)
            {
                var url = ($"{SiteUrl}{CityNameInput.Text}{ParamUrl}");
                var request = WebRequest.Create(url);
                var response = request.GetResponse();
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        WeatherInfoOutput.Text = reader.ReadToEnd();
                    }
                }
                response.Close();
            }
        }
    }
}
