using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Filters.InitializeFilters(null);
            InitializeComponent();

            String firstLaunch = Utilities.ReadFromConfig("firstLaunch");

            if (firstLaunch != null && firstLaunch.Equals("true"))
            {
                NavigationFrame.Navigate(new MainPage());
                //NavigationFrame.Navigate(new StartPage());
            }
            else
            {
                NavigationFrame.Navigate(new StartPage());
            }
            
            System.IO.Directory.CreateDirectory("SavedFilters");
            if (System.IO.File.Exists("SavedListings.xml"))
            {
                SavableFilters s = new SavableFilters();
                s.ReadListings("SavedListings.xml");
            }
        }

        public void SaveSavedListing(object sender, EventArgs e)
        {
            List<int> saved_listings = new List<int>();
            foreach (Pin pin in PinCollection.pins)
            {
                if (pin.GetType() == typeof(ListingPin))
                {
                    if (((ListingPin)pin).listing.Saved)
                    {
                        saved_listings.Add(((ListingPin)pin).listing.ID);
                    }
                }
            }
            SavableFilters s = new SavableFilters();
            s.SaveListings("SavedListings.xml", saved_listings);
        }
    }
}
