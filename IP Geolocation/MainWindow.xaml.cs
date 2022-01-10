using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IP_Geolocation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string DefaultTextBoxContent = "Enter your IP or domain here...";

        private static string GMapsUrl = "https://www.google.com/maps/search/?api=1&query={lat},{lon}";

        public MainWindow()
        {
            InitializeComponent();
            textBox.Text = DefaultTextBoxContent;
            searchButton.IsEnabled = false;
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBox.Text == DefaultTextBoxContent)
            {
                textBox.Text = "";
            }
        }

        private void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Length == 0)
            {
                textBox.Text = DefaultTextBoxContent;
            }
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox.Text.Length == 0 || textBox.Text == DefaultTextBoxContent)
                searchButton.IsEnabled = false;

            else
                searchButton.IsEnabled = true;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            GeoApiObject obj = GeoApi.GetObject(textBox.Text);
            webView.Source = new Uri(GMapsUrl
                .Replace("{lat}", obj.lat.ToString().Replace(',', '.'))
                .Replace("{lon}", obj.lon.ToString().Replace(',', '.'))
                );
        }
    }
}
