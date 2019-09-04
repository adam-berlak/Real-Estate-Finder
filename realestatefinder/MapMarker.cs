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
    public partial class MapMarker : Pin
    {
        public MapMarker(double xdis, double ydis)
            : base(null, 0, xdis, ydis)
        {
            InitializeComponent();
        }

        public override void ShowPin(bool savedListings)
        {
            this.Visibility = Visibility.Visible;
        }
    }
}
