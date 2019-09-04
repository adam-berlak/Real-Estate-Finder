using System;
using System.Collections.Generic;
using System.IO;
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

namespace realestatefinder
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        List<string> locations;

        public StartPage()
        {
            InitializeComponent();

            locations = new List<string>();
            locations.AddRange(PinCollection.searchLocations.Keys);
            locations.AddRange(PinCollection.searchLocations.Values);

            addressTextBox.ItemsSource = locations;

            MainGrid.MouseDown += MainGrid_MouseDown;
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
        }

        private void TextBox_TextChanged(object sender, EventArgs args)
        {
            foreach (string address in locations)
            {
                if (string.IsNullOrEmpty(address))
                {
                    continue;
                }
                if (address.ToLower().StartsWith(addressTextBox.Text.ToLower()))
                {
                    ErrorField.Visibility = Visibility.Hidden;
                    searchButton.IsEnabled = true;
                    return;
                }
            }
            ErrorField.Visibility = Visibility.Visible;
            searchButton.IsEnabled = false;
        }

        private void SearchButtonClicked(object sender, RoutedEventArgs e)
        {
            Filters.FilterDict["Address"] = addressTextBox.Text;

            Utilities.SaveToConfig("firstLaunch", "true");
        
            this.NavigationService.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
        }

        private void MainGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            searchButton.Focus();
            Keyboard.ClearFocus();
        }

        private void OnKeyHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                searchButton.Focus();
                Keyboard.ClearFocus();
            }
        }
    }
}
