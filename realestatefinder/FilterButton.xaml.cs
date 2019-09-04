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

namespace realestatefinder
{
    /// <summary>
    /// Interaction logic for FilterButton.xaml
    /// </summary>
    public partial class FilterButton : Button
    {
        private SolidColorBrush checkedColor;
        private SolidColorBrush uncheckedColor;

        private String filtername = "";
        private bool state;

        public FilterButton()
        {
            InitializeComponent();
            checkedColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#03a9f4"));
            uncheckedColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7f7f7f"));
        }

        public bool FilterActive
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
                CheckBox check = this.FindName("Check") as CheckBox;
                check.IsChecked = value;
                this.Background = value ? checkedColor : uncheckedColor;
            }
        }
        public String FilterButtonName
        {
            set
            {
                Label name = this.FindName("FilterName") as Label;
                name.Content = value;
                filtername = value;
                if (filtername.Equals("Subscribe"))
                {
                    FilterActive = false;
                }
                else
                {
                    if (!filtername.Equals("View Saved Listings"))
                    {
                        FilterActive = (bool)Filters.FilterDict[value];
                    }
                }
            }
        }

        public void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            this.FilterActive = !this.FilterActive;
            if (!filtername.Equals("Subscribe") && !filtername.Equals("View Saved Listings"))
            {
                Filters.FilterDict[filtername] = this.FilterActive;
            }
        }
    }
}
