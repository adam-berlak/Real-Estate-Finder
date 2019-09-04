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
using System.Windows.Shapes;

namespace realestatefinder
{
    /// <summary>
    /// Interaction logic for Popup2.xaml
    /// </summary>
    public partial class Popup2 : Window
    {
        public Popup2()
        {
            InitializeComponent();
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void buttonClick(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            b.Opacity = 0;
        }

        private void buttonHover(object sender, DragEventArgs e)
        {

        }
    }
}
