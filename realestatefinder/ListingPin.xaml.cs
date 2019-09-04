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
    /// Interaction logic for ListingPin
    /// </summary>
    public partial class ListingPin : Pin
    {
        public Listing listing;
        public Pin BasePin;
        public int BasePinID;

        // Indicates whether this pin is currently selected / clicked
        public bool IsSelected = false;

        public ListingPin(Listing l, int id, int basePinId, Pin basePin, double xdis, double ydis)
            : base(id, xdis, ydis)
        {
            InitializeComponent();
            listing = l;
            ID = id;
            BasePinID = basePinId;
            BasePin = basePin;
            xDistance = xdis + basePin.xDistance;
            yDistance = ydis + basePin.yDistance;

            if (listing != null)
            {
                listing.ProxToBasePin = (Math.Sqrt(
                    Math.Pow(xdis, 2.0)
                    + Math.Pow(ydis, 2.0)))
                    / 150;
            }

            this.Click += OnClick;
            SetPinImage();
        }

        public override void ShowPin(bool savedListings)
        {
            if (listing == null)
            {
                Visibility = Visibility.Hidden;
                UnselectPin();
                return;
            }
            if (savedListings)
            {
                if (listing.Saved)
                {
                    Visibility = Visibility.Visible;
                    UnselectPin();
                }
                else
                {
                    Visibility = Visibility.Hidden;
                    UnselectPin();
                }                
                return;
            }
            if (BasePin.Visibility == Visibility.Hidden && !string.IsNullOrEmpty(Filters.FilterDict["Address"].ToString()))
            {
                Visibility = Visibility.Hidden;
                UnselectPin();
                return;
            }
            string br = listing.BuyOrRent;
            bool justBuy = Filters.ShowBuy();
            bool justRent = Filters.ShowRent();
            bool Buy = Convert.ToBoolean(Filters.FilterDict["Buy"]);
            bool Rent = Convert.ToBoolean(Filters.FilterDict["Rent"]);
            bool listingsIsBuy = br.Equals("Buy");
            bool listingsIsRent = br.Equals("Rent");
            if (!Buy && !Rent)
            {
                Visibility = Visibility.Hidden;
                UnselectPin();
                return;
            }
            if (justBuy && listingsIsRent)
            {
                Visibility = Visibility.Hidden;
                UnselectPin();
                return;
            }
            if (justRent && listingsIsBuy)
            {
                Visibility = Visibility.Hidden;
                UnselectPin();
                return;
            }
            string type = listing.Type;
            if (!Convert.ToBoolean(Filters.FilterDict[type]))
            {
                Visibility = Visibility.Hidden;
                UnselectPin();
                return;
            }
            if (listing.ProxToBasePin > Convert.ToInt32(Filters.FilterDict["AddressProx"]))
            {
                Visibility = Visibility.Hidden;
                UnselectPin();
                return;
            }
            if (listing.Beds < Convert.ToInt32(Filters.FilterDict["BedsMin"]))
            {
                Visibility = Visibility.Hidden;
                UnselectPin();
                return;
            }
            if (listing.Baths < Convert.ToDouble(Filters.FilterDict["BathsMin"]))
            {
                Visibility = Visibility.Hidden;
                UnselectPin();
                return;
            }
            if (listingsIsRent)
            {
                if (listing.Price > Convert.ToInt32(Filters.FilterDict["RentMax"]))
                {
                    Visibility = Visibility.Hidden;
                    UnselectPin();
                    return;
                }
                if (Convert.ToBoolean(Filters.FilterDict["Water"]) && !listing.WaterIncluded)
                {
                    Visibility = Visibility.Hidden;
                    UnselectPin();
                    return;
                }
                if (Convert.ToBoolean(Filters.FilterDict["Electricity"]) && !listing.ElectricityIncluded)
                {
                    Visibility = Visibility.Hidden;
                    UnselectPin();
                    return;
                }
                if (Convert.ToBoolean(Filters.FilterDict["Heat"]) && !listing.HeatIncluded)
                {
                    Visibility = Visibility.Hidden;
                    UnselectPin();
                    return;
                }
                if (Convert.ToBoolean(Filters.FilterDict["Internet"]) && !listing.InternetIncluded)
                {
                    Visibility = Visibility.Hidden;
                    UnselectPin();
                    return;
                }
                if (Convert.ToBoolean(Filters.FilterDict["Parking"]) && !listing.ParkingIncluded)
                {
                    Visibility = Visibility.Hidden;
                    UnselectPin();
                    return;
                }
                if (Convert.ToBoolean(Filters.FilterDict["Television"]) && !listing.TelevisionIncluded)
                {
                    Visibility = Visibility.Hidden;
                    UnselectPin();
                    return;
                }
            }
            if (listingsIsBuy)
            {
                if (listing.Price > Convert.ToInt32(Filters.FilterDict["BuyMax"]))
                {
                    Visibility = Visibility.Hidden;
                    UnselectPin();
                    return;
                }
            }
            Visibility = Visibility.Visible;
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            this.SelectPin();
        }

        public void SelectPin()
        {
            PinCollection.pins.Where(x => x.GetType() == typeof(ListingPin)).ToList().ForEach(x =>
            {
                if (x == this)
                {
                    ((ListingPin)x).IsSelected = true;
                }
                else
                {
                    ((ListingPin)x).IsSelected = false;
                }
                ((ListingPin)x).SetPinImage();
            });
        }

        public void UnselectPin()
        {
            PinCollection.pins.Where(x => x.GetType() == typeof(ListingPin)).ToList().ForEach(x =>
            {
                if (x == this && this.IsSelected)
                {
                    this.IsSelected = false;
                    this.SetPinImage();
                }                
            });
        }

        public void SetPinImage()
        {
            BitmapImage pinImage = null;

            if (listing != null)
            {
                switch (listing.Type)
                {
                    case "House":
                        pinImage = IsSelected ?
                            new BitmapImage(new Uri("pack://application:,,,/assets/photos/houseMarkerClicked.png")):
                            new BitmapImage(new Uri("assets/photos/houseMarker.png", UriKind.Relative));
                        break;
                    case "Townhouse":
                        pinImage = IsSelected ?
                            new BitmapImage(new Uri("assets/photos/townhouseMarkerClicked.png", UriKind.Relative)) :
                            new BitmapImage(new Uri("assets/photos/townhouseMarker.png", UriKind.Relative));
                        break;
                    case "Apartment":
                        pinImage = IsSelected ?
                            new BitmapImage(new Uri("assets/photos/apartmentMarkerClicked.png", UriKind.Relative)) :
                            new BitmapImage(new Uri("assets/photos/apartmentMarker.png", UriKind.Relative));
                        break;
                    case "Condo":
                        pinImage = IsSelected ?
                            new BitmapImage(new Uri("assets/photos/condoMarkerClicked.png", UriKind.Relative)) :
                            new BitmapImage(new Uri("assets/photos/condoMarker.png", UriKind.Relative));
                        break;
                    case "Loft":
                        pinImage = IsSelected ?
                            new BitmapImage(new Uri("assets/photos/loftMarkerClicked.png", UriKind.Relative)) :
                            new BitmapImage(new Uri("assets/photos/loftMarker.png", UriKind.Relative));
                        break;
                    case "Duplex":
                        pinImage = IsSelected ?
                            new BitmapImage(new Uri("assets/photos/duplexMarkerClicked.png", UriKind.Relative)) :
                            new BitmapImage(new Uri("assets/photos/duplexMarker.png", UriKind.Relative));
                        break;
                    default:
                        // do nothing
                        break;
                }
            }                

            if (pinImage != null)
            {
                this.image.Source = pinImage;
            }            
        }
    }
}
