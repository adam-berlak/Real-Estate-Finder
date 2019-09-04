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
    /// 
    /// Interaction logic for Pin.xaml
    /// </summary>
    public partial class Pin : Button
    {
        public int ID;

        public String address;

        //Horizontal distance away from the left side of the map image
        public double xDistance;

        //Vertical distance away from the top of the map image
        public double yDistance;

        public Pin(String address, int id, double xdis, double ydis)
        {
            InitializeComponent();
            this.address = address;
            ID = id;
            xDistance = xdis;
            yDistance = ydis;
        }

        public Pin(int id, double xdis, double ydis)
        {
            InitializeComponent();
            ID = id;
            xDistance = xdis;
            yDistance = ydis;
        }

        public virtual void ShowPin(bool savedListings)
        {
            // Check against the filters to decide to show this pin or not
            this.Visibility = !savedListings && this.address != null && ((Filters.FilterDict["Address"].Equals(this.address)
                || Filters.FilterDict["Address"].Equals(PinCollection.searchLocations[this.address])))
                ? Visibility.Visible : Visibility.Hidden;
        }             
    }
}
