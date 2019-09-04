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
    /// Interaction logic for SideBarItem.xaml
    /// </summary>
    public partial class SideBarItem : Button
    {
        public Listing listing;

        public SideBarItem(Listing listing)
        {
            InitializeComponent();

            this.listing = listing;
            Image.Source = new BitmapImage(new Uri((string)listing.Images[0], UriKind.RelativeOrAbsolute));
            PriceLabel.Content = listing.BuyOrRent == "Buy" ? ("$" + listing.Price) : ("$" + listing.Price + "/month");
            TypeLabel.Content = listing.Type;
            SizeLabel.Content = listing.Size;
            BedsBathsLabel.Content = listing.Beds + " Bed " + listing.Baths + " Bath";
            AddressLabel.Content = listing.Address;

            SetListingImage(listing.Saved);
        }

        private void FavoriteButton_Click(object sender, RoutedEventArgs e)
        {
            if (e != null && !e.Handled)
            {
                e.Handled = true;
            }

            SetListingImage(!listing.Saved);
            
        }

        public void SetListingImage(bool save)
        {
            if (save)
            {
                listing.Saved = true;
                FavoriteImage.Source = new BitmapImage(new Uri("assets/photos/star_filled.png", UriKind.RelativeOrAbsolute));
                FavoriteImage.ToolTip = "Press to remove this from your saved listings";
            }
            else
            {
                listing.Saved = false;
                FavoriteImage.Source = new BitmapImage(new Uri("assets/photos/star_outline.png", UriKind.RelativeOrAbsolute));
                FavoriteImage.ToolTip = "Press to save listing for later";
            }
        }
    }
}
