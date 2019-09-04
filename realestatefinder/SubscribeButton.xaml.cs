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
    /// Interaction logic for IconFilterButton.xaml
    /// </summary>
    public partial class SubscribeButton : Button
    {

        private SolidColorBrush checkedColor;
        private SolidColorBrush uncheckedColor;

        private bool state;
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

        public SubscribeButton()
        {
            InitializeComponent();
            checkedColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#03a9f4"));
            uncheckedColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7f7f7f"));
            FilterActive = false;
        }

        public void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            this.FilterActive = !this.FilterActive;
        }
    }
}
