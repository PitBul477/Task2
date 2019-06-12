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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text != String.Empty)
            {
                string url = ("http://weather.service.msn.com/data.aspx?weasearchstr="+textBox.Text+"&culture=en-US&weadegreetype=C&src=outlook");
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        textBox1.Text = reader.ReadToEnd();
                    }
                }
                response.Close();
            }
        }
    }
}
