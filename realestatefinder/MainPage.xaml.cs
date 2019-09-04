using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
    /// Interaction logic for MainPage.xaml
using System.Windows.Shapes;

namespace realestatefinder
{
    /// <summary>
    /// </summary>
    public partial class MainPage : Page
    {
        public static bool SaveSearchOpen = false;
        SaveSearchPopup ssp;
        public static bool ViewSavedSearchesOpen = false;
        ViewSavedSearchesPopup vssp;
		
		public static Dictionary<String, SavableFilters> saved_searches = new Dictionary<String, SavableFilters>();

        private List<string> locations;

        private Dictionary<Pin, SideBarItem> sideBarListings;

        private Pin currentBasePin;
        private double lastMapZoomSliderValue = 1.0;
        private double lastMapScalingValue = 1.0;
        private bool mapJustZoomed = false;

        private bool addressValid = true;

        private static readonly double oneKmCircleSize = 300; //Pixel diameter of a 1 km circle on the map image        

        private static readonly Regex regex_int = new Regex("[^0-9]+"); //regex that matches disallowed text
        private static readonly Regex regex_double = new Regex("[^0-9.]+"); //regex that matches disallowed text

        private static Button emptySidebarButton;

        public MainPage()
        {
            InitializeComponent();

            SetRentEnabled(Filters.FilterDict["Rent"]);
            Filters.ObserverDict.Add("Rent", new Action<object>(SetRentEnabled));

            SetBuyEnabled(Filters.FilterDict["Buy"]);
            Filters.ObserverDict.Add("Buy", new Action<object>(SetBuyEnabled));

            AddressTextBox.LostFocus += UpdateAddressText;
            SetAddress(Filters.FilterDict["Address"]);
            Filters.ObserverDict.Add("Address", new Action<object>(SetAddress));

            SetAddressProx(Filters.FilterDict["AddressProx"]);
            Filters.ObserverDict.Add("AddressProx", new Action<object>(SetAddressProx));

            Filters.ObserverDict.Add("House", new Action<object>(SetHouseFilter));
            Filters.ObserverDict.Add("Townhouse", new Action<object>(SetTownhouseFilter));
            Filters.ObserverDict.Add("Apartment", new Action<object>(SetApartmentFilter));
            Filters.ObserverDict.Add("Condo", new Action<object>(SetCondoFilter));
            Filters.ObserverDict.Add("Loft", new Action<object>(SetLoftFilter));
            Filters.ObserverDict.Add("Duplex", new Action<object>(SetDuplexFilter));

            Filters.ObserverDict.Add("Water", new Action<object>(SetWaterFilter));
            Filters.ObserverDict.Add("Electricity", new Action<object>(SetElectricityFilter));
            Filters.ObserverDict.Add("Heat", new Action<object>(SetHeatFilter));
            Filters.ObserverDict.Add("Internet", new Action<object>(SetInternetFilter));
            Filters.ObserverDict.Add("Parking", new Action<object>(SetParkingFilter));
            Filters.ObserverDict.Add("Television", new Action<object>(SetTelevisionFilter));

            Filters.ObserverDict.Add("RentMax", new Action<object>(SetRentValue));
            Filters.ObserverDict.Add("BuyMax", new Action<object>(SetBuyValue));
            Filters.ObserverDict.Add("BedsMin", new Action<object>(SetBedValue));
            Filters.ObserverDict.Add("BathsMin", new Action<object>(SetBathValue));

            ListingsView.PreviewMouseWheel += PreviewMouseWheel;

            string[] files = Directory.GetFiles("SavedFilters");
            foreach (string file in files)
            {
                SavableFilters s = new SavableFilters();
                s.ReadFilters(file.Remove(file.Length - 4).Substring(13));
                saved_searches.Add(file.Remove(file.Length - 4).Substring(13), s);
            }
            
            // Once everything is loaded, calculate where the pins should be placed based on actual size of components
            Loaded += delegate
            {
                foreach(Pin p in PinCollection.pins)
                {
                    MainGrid.Children.Add(p);
                    Grid.SetColumn(p, 0);
                    Grid.SetRow(p, 1);
                    Grid.SetZIndex(p, 2);
                  
                    // Set initial position
                    p.Margin = GetMapLocationAsMargin(p, p.Width, p.Height * 2);

                    currentBasePin = PinCollection.pins.Where(x => x.address != null &&
                        (x.address.Equals(AddressTextBox.Text) || (PinCollection.searchLocations[x.address] != null && PinCollection.searchLocations[x.address].Equals(AddressTextBox.Text)))).FirstOrDefault();

                    PinCollection.RefreshPins(false);
                    UpdateSearchAreaCircle();
                }
            };

            // Update pin locations when the map is zoomed or translated, or when the window is resized
            MapBorder.OnUpdateTransform += OnUpdateMapTransform;
            SizeChanged += OnSizeChanged;
            MouseWheel += OnMouseWheel;

            locations = new List<string>();
            locations.AddRange(PinCollection.searchLocations.Keys);
            locations.AddRange(PinCollection.searchLocations.Values);

            AddressTextBox.ItemsSource = locations;

            sideBarListings = new Dictionary<Pin, SideBarItem>();
            foreach (Pin i in PinCollection.pins)
            {                
                if (i.GetType() == typeof(ListingPin))
                {
                    i.Click += OnPinClick;
                    SideBarItem item = new SideBarItem(((ListingPin)i).listing);
                    item.Click += Sidebar_Button_Click;
                    sideBarListings.Add(i, item);
                };
            }
            emptySidebarButton = new Button
            {
                Height = 50,
                Background = Brushes.Transparent,
                BorderBrush = Brushes.Transparent,
            };
            UpdateListings();

            MainGrid.MouseDown += MainGrid_MouseDown;
        }

        private void OnPinClick(object sender, RoutedEventArgs e)
        {
            Pin pin = (Pin)sender;
            SideBarItem sideBarListing = sideBarListings.Where(x => x.Key.ID == pin.ID).First().Value;
            ListingsView.Items.Remove(sideBarListing);
            ListingsView.Items.Insert(0, sideBarListing);
            
            ListingsView.SelectedItem = sideBarListing;
            ListingsView.UpdateLayout();

            var listBoxItem = (ListBoxItem)ListingsView
                .ItemContainerGenerator
                .ContainerFromItem(ListingsView.SelectedItem);

            listBoxItem.Focus();
        }

        private void ListBoxItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SideBarItem sideBarItem = (SideBarItem)((ListBoxItem)sender).Content;
            ListingPin listingPin = (ListingPin)sideBarListings.Where(x => x.Value == sideBarItem).First().Key;
            listingPin.SelectPin();

            ListingsView.SelectedItem = sideBarItem;
        }

        private void MainGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddressProx.Focus();
            Keyboard.ClearFocus();
        }

        private void OnKeyHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                AddressProx.Focus();
                Keyboard.ClearFocus();
            }
        }

        // this updates the listings shown according to the listing pins visable
        private void UpdateListings()
        {
            if (sideBarListings != null)
            {
                if (SavedListingsButton.FilterActive)
                {
                    ListingsView.Items.Clear();
                    sideBarListings.Where(x => ((ListingPin)x.Key).listing.Saved).ToList().ForEach(x => ListingsView.Items.Add(x.Value));
                    ListingsView.Items.Add(emptySidebarButton);

                    ListingsSearchLabel.Content = ListingsView.Items.Count > 2 ? (ListingsView.Items.Count - 1) + " Saved Listings" : (ListingsView.Items.Count - 1) + " Saved Listing";
                    ListingsView.Items.Refresh();
                }
                else
                {
                    ListingsView.Items.Clear();
                    sideBarListings.Where(x => x.Key.Visibility == Visibility.Visible).ToList().ForEach(x => ListingsView.Items.Add(x.Value));
                    ListingsView.Items.Add(emptySidebarButton);

                    ListingsSearchLabel.Content = ListingsView.Items.Count > 2 ? (ListingsView.Items.Count - 1) + " Listings Matching Search" : (ListingsView.Items.Count - 1) + " Listing Matching Search";
                    ListingsView.Items.Refresh();
                }        
            }            
        }

        public void UpdateSidebarStars()
        {
            foreach (object item in ListingsView.Items)
            {
                if (item.GetType() == typeof(SideBarItem))
                {
                    ((SideBarItem)item).SetListingImage(((SideBarItem)item).listing.Saved);
                }                
            }
        }

        // this is a click method used to add extra behaviour to a bunch of filters
        public void PinsRefresh(object sender, RoutedEventArgs e)
        {
            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
            UpdateListings();
        }

        // this method is to handle when we want to refresh the rent filter from the backend (loading a saved search)
        public void SetRentEnabled(object enabled)
        {
            bool state = Convert.ToBoolean(enabled);
            RentSlider.IsEnabled = state;
            RentText.IsEnabled = state;
            RentButton.FilterActive = state;

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
            UpdateListings();

            TopBarGrid.ColumnDefinitions.ElementAt(5).Width = state ? new GridLength(1, GridUnitType.Auto) : new GridLength(0);
        }

        // this method is to handle when the rent button is clicked
        private void Rent_Button_Click(object sender, RoutedEventArgs e)
        {
            FilterButton btn = sender as FilterButton;
            bool enabled = btn.FilterActive;
            RentText.IsEnabled = enabled;
            RentSlider.IsEnabled = enabled;

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
            UpdateListings();

            TopBarGrid.ColumnDefinitions.ElementAt(5).Width = enabled ? new GridLength(1, GridUnitType.Auto) : new GridLength(0);
        }

        // this method is to handle when we want to refresh the buy filter from the backend (loading a saved search)
        public void SetBuyEnabled(object enabled)
        {
            bool state = Convert.ToBoolean(enabled);
            BuySlider.IsEnabled = state;
            BuyText.IsEnabled = state;
            BuyButton.FilterActive = state;

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
            UpdateListings();
        }

        // this method is to handle when the buy button is clicked
        private void Buy_Button_Click(object sender, RoutedEventArgs e)
        {
            FilterButton btn = sender as FilterButton;
            bool enabled = btn.FilterActive;
            BuySlider.IsEnabled = enabled;
            BuyText.IsEnabled = enabled;

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
            UpdateListings();
        }

        // this method is to update the address text box with a new value (loading a saved search)
        public void SetAddress(object value)
        {
            AddressTextBox.Text = value.ToString();

            currentBasePin = PinCollection.pins.Where(x => x.address != null &&
                            (x.address.Equals(AddressTextBox.Text) || (PinCollection.searchLocations[x.address] != null && PinCollection.searchLocations[x.address].Equals(AddressTextBox.Text)))).FirstOrDefault();

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
            UpdateListings();
        }

        // this method is to handle updating the filters when a new address is entered
        private void UpdateAddressText(object sender, EventArgs e)
        {
            if (!addressValid)
            {
                Filters.FilterDict["Address"] = AddressTextBox.Text;

                currentBasePin = PinCollection.pins.Where(x => x.address != null &&
                            (x.address.Equals(AddressTextBox.Text) || (PinCollection.searchLocations[x.address] != null && PinCollection.searchLocations[x.address].Equals(AddressTextBox.Text)))).FirstOrDefault();

                PinCollection.RefreshPins(false);
                UpdateSearchAreaCircle();
                UpdateListings();
            }
        }

        // this verifies the user is entering a valid address
        private void AddressBox_TextChange(object sender, EventArgs args)
        {
            foreach (string address in locations)
            {
                if (string.IsNullOrEmpty(address))
                {
                    continue;
                }
                if (address.ToLower().StartsWith(AddressTextBox.Text.ToLower()))
                {
                    ErrorField.Visibility = Visibility.Hidden;
                    addressValid = false;
                    return;
                }
            }
            ErrorField.Visibility = Visibility.Visible;
            addressValid = true;
        }

        // this method is to update the addressprox text box with a new value (loading a saved search) 
        public void SetAddressProx(object value)
        {
            AddressProx.Text = value.ToString();

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
            UpdateListings();
        }

        // this method is to handle updating the filters when a new addressprox is entered
        private void UpdateAddressProx(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;

            int newVal = -1;
            int.TryParse(box.Text, out newVal);

            if (newVal != -1)
            {
                Filters.FilterDict["AddressProx"] = newVal;

                PinCollection.RefreshPins(false);
                UpdateSearchAreaCircle();
                UpdateListings();
            }
        }

        // this method is used when loading a saved search
        public void SetHouseFilter(object enabled)
        {
            HouseFilter.FilterActive = Convert.ToBoolean(enabled);

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
        }

        // this method is used when loading a saved search
        public void SetTownhouseFilter(object enabled)
        {
            TownhouseFilter.FilterActive = Convert.ToBoolean(enabled);

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
        }

        // this method is used when loading a saved search
        public void SetApartmentFilter(object enabled)
        {
            ApartmentFilter.FilterActive = Convert.ToBoolean(enabled);

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
        }

        // this method is used when loading a saved search
        public void SetCondoFilter(object enabled)
        {
            CondoFilter.FilterActive = Convert.ToBoolean(enabled);

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
        }

        // this method is used when loading a saved search
        public void SetLoftFilter(object enabled)
        {
            LoftFilter.FilterActive = Convert.ToBoolean(enabled);

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
        }

        // this method is used when loading a saved search
        public void SetDuplexFilter(object enabled)
        {
            DuplexFilter.FilterActive = Convert.ToBoolean(enabled);

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
        }

        // this method is used when loading a saved search
        public void SetWaterFilter(object enabled)
        {
            WaterIncluded.FilterActive = Convert.ToBoolean(enabled);

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
        }

        // this method is used when loading a saved search
        public void SetElectricityFilter(object enabled)
        {
            ElectricityIncluded.FilterActive = Convert.ToBoolean(enabled);

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
        }

        // this method is used when loading a saved search
        public void SetHeatFilter(object enabled)
        {
            HeatIncluded.FilterActive = Convert.ToBoolean(enabled);

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
        }

        // this method is used when loading a saved search
        public void SetInternetFilter(object enabled)
        {
            InternetIncluded.FilterActive = Convert.ToBoolean(enabled);

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
        }

        // this method is used when loading a saved search
        public void SetParkingFilter(object enabled)
        {
            ParkingIncluded.FilterActive = Convert.ToBoolean(enabled);

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
        }

        // this method is used when loading a saved search
        public void SetTelevisionFilter(object enabled)
        {
            TelevisionIncluded.FilterActive = Convert.ToBoolean(enabled);

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
        }

        // this method handles updating the filter from the UI
        private void Rent_ValueChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            int RentMax;
            int.TryParse(box.Text, out RentMax);
            Filters.FilterDict["RentMax"] = RentMax;

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
            UpdateListings();
        }

        // this method is used when loading a saved search
        public void SetRentValue(object value)
        {
            RentText.Text = value.ToString();

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
            UpdateListings();
        }

        // this method handles updating the filter from the UI
        private void Buy_ValueChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            int BuyMax;
            int.TryParse(box.Text, out BuyMax);
            Filters.FilterDict["BuyMax"] = BuyMax;

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
            UpdateListings();
        }

        // this method is used when loading a saved search
        public void SetBuyValue(object value)
        {
            BuyText.Text = value.ToString();

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
            UpdateListings();
        }

        // this method handles updating the filter from the UI
        private void Bed_ValueChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            int beds;
            int.TryParse(box.Text, out beds);
            Filters.FilterDict["BedsMin"] = beds;

            double baths = Convert.ToDouble(Filters.FilterDict["BathsMin"]);
            ChangeHouseImage(beds, baths);

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
            UpdateListings();
        }

        // this method is used when loading a saved search
        public void SetBedValue(object value)
        {
            BedText.Text = value.ToString();

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
            UpdateListings();
        }

        // this method handles updating the filter from the UI
        private void Bath_ValueChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            double baths;
            Double.TryParse(box.Text, out baths);
            Filters.FilterDict["BathsMin"] = baths;

            double beds = Convert.ToInt32(Filters.FilterDict["BedsMin"]);
            ChangeHouseImage(beds, baths);

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
            UpdateListings();
        }

        // this method is used when loading a saved search
        public void SetBathValue(object value)
        {
            BathText.Text = value.ToString();

            PinCollection.RefreshPins(false);
            UpdateSearchAreaCircle();
            UpdateListings();
        }

        public void LostFocusValueValidation(object sender, EventArgs e)
        {
            bool textBad = string.IsNullOrEmpty(((TextBox)sender).Text);
            if (textBad)
            {
                if (((TextBox)sender).Name.Equals("RentText"))
                {
                    ((TextBox)sender).Text = "6000";
                }
                if (((TextBox)sender).Name.Equals("BuyText"))
                {
                    ((TextBox)sender).Text = "2000000";
                }
                if (((TextBox)sender).Name.Equals("AddressProx"))
                {
                    ((TextBox)sender).Text = "3";
                }
                if (((TextBox)sender).Name.Equals("BedText"))
                {
                    ((TextBox)sender).Text = "0";
                }
                if (((TextBox)sender).Name.Equals("BathText"))
                {
                    ((TextBox)sender).Text = "0.5";
                }
            }
        }

        public void PreviewTextInputInt(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text, regex_int);
        }

        public void PreviewTextInputDouble(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Equals("."))
            {
                if (((TextBox)sender).Text.Contains("."))
                {
                    e.Handled = true;
                    return;
                }
            }
            e.Handled = !IsTextAllowed(e.Text, regex_double);
        }

        private static bool IsTextAllowed(string text, Regex regex)
        {
            return !regex.IsMatch(text);
        }

        private Popup popup;

        private void Sidebar_Button_Click(object sender, RoutedEventArgs e)
        {
            largebackground.Visibility = Visibility.Visible;
            largebackgroundbutton.Visibility = Visibility.Visible;
            popup = new Popup(this);
            popup.setDescription(((SideBarItem)sender).listing);
            popup.Show();
        }

        private void SaveSearchClick(object sender, RoutedEventArgs e)
        {
            if (SaveSearchOpen)
            {
                return;
            }
            if (ViewSavedSearchesOpen)
            {
                SidebarControls.Items.Remove(vssp);
                ViewSavedSearchesOpen = false;
            }
            ssp = new SaveSearchPopup(SidebarControls);
            SidebarControls.Items.Insert(0, ssp);
            SaveSearchOpen = true;
        }

        private void ViewSavedSearchesClick(object sender, RoutedEventArgs e)
        {
            if (ViewSavedSearchesOpen)
            {
                return;
            }
            if (SaveSearchOpen)
            {
                SidebarControls.Items.Remove(ssp);
                SaveSearchOpen = false;
            }
            vssp = new ViewSavedSearchesPopup(SidebarControls);
            SidebarControls.Items.Insert(0, vssp);
            ViewSavedSearchesOpen = true;
        }

        private void ViewSavedListingsClick(object sender, RoutedEventArgs e)
        {
            if (((FilterButton)sender).FilterActive)
            {
                // Unselect all the pins
                PinCollection.pins.Where(x => x.GetType() == typeof(ListingPin)).ToList().ForEach(x => ((ListingPin)x).UnselectPin());
                PinCollection.RefreshPins(true);
                topbarblocker.Visibility = Visibility.Visible;
            }
            else
            {
                PinCollection.RefreshPins(false);
                topbarblocker.Visibility = Visibility.Hidden;
            }
            UpdateSearchAreaCircle();
            UpdateListings();
        }

        private void ChangeHouseImage(double beds, double baths)
        {
            if (beds >= baths)
            {
                if (beds <= 2)
                {
                    HouseImage.Source = new BitmapImage(new Uri("assets/photos/SmallHouse.PNG", UriKind.Relative));
                }
                else if ((2 < beds) && (beds <= 4))
                {
                    HouseImage.Source = new BitmapImage(new Uri("assets/photos/MedHouse.PNG", UriKind.Relative));
                }
                else
                {
                    HouseImage.Source = new BitmapImage(new Uri("assets/photos/BigHouse.PNG", UriKind.Relative));
                }
            }
            else
            {
                if (baths <= 2)
                {
                    HouseImage.Source = new BitmapImage(new Uri("assets/photos/SmallHouse.PNG", UriKind.Relative));
                }
                else if ((2 < baths) && (baths <= 4))
                {
                    HouseImage.Source = new BitmapImage(new Uri("assets/photos/MedHouse.PNG", UriKind.Relative));
                }
                else
                {
                    HouseImage.Source = new BitmapImage(new Uri("assets/photos/BigHouse.PNG", UriKind.Relative));
                }
            }
        }

        private static void PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (!e.Handled)
            {
                e.Handled = true;
                var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
                eventArg.RoutedEvent = UIElement.MouseWheelEvent;
                eventArg.Source = sender;
                var parent = ((Control)sender).Parent as UIElement;
                parent.RaiseEvent(eventArg);
            }
        }

        public void ClosePopup(object sender, EventArgs e)
        {
            if (popup.enlarged)
            {
                popup.closeEnlarge(sender, (RoutedEventArgs)e);
            }
            else
            {
                largebackground.Visibility = Visibility.Hidden;
                largebackgroundbutton.Visibility = Visibility.Hidden;
                popup.Close();
            }
        }

        #region Map Update Things

        private void OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            mapJustZoomed = true;
            double currentValue = MapBorder.GetScaleTransform().ScaleX;

            MapZoomSlider.Value += (currentValue - lastMapScalingValue) / 0.2;

            lastMapZoomSliderValue = MapZoomSlider.Value;
            lastMapScalingValue = currentValue;          
        }

        private void ZoomPlusClick(object sender, RoutedEventArgs e)
        {
            mapJustZoomed = false;
            MapZoomSlider.Value += 5 * MapZoomSlider.TickFrequency;
        }

        private void ZoomMinusClick(object sender, RoutedEventArgs e)
        {
            mapJustZoomed = false;
            MapZoomSlider.Value -= 5 * MapZoomSlider.TickFrequency;
        }

        private void MapZoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!mapJustZoomed)
            {
                double currentValue = ((Slider)sender).Value;
                double delta = lastMapZoomSliderValue - currentValue;

                if (MapBorder.IsLoaded)
                {
                    MapBorder.ScaleContent(MapBorderCenter, delta < 0, Math.Abs(delta));
                    lastMapZoomSliderValue = currentValue;
                }
            }
        }

        private void MapZoomSlider_DragStarted(object sender, RoutedEventArgs e)
        {
            mapJustZoomed = false;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdatePinTransforms();
            UpdateSearchAreaCircle();
        }

        private void OnUpdateMapTransform(object sender)
        {
            UpdatePinTransforms();
            UpdateSearchAreaCircle();
        }

        private void UpdatePinTransforms()
        {
            foreach (Pin p in PinCollection.pins)
            {
                p.Margin = GetMapLocationAsMargin(p, p.Width, p.Height * 2);
            }
        }

        private void UpdateSearchAreaCircle()
        {
            if (IsLoaded)
            {
                if (currentBasePin != null && AddressTextBox.Text != "" && !SavedListingsButton.FilterActive)
                {
                    SearchAreaCircle.Width = oneKmCircleSize * int.Parse(Filters.FilterDict["AddressProx"].ToString())
                        * (MapImage.ActualWidth / (MapImage.Source as BitmapSource).PixelWidth) * MapBorder.GetScaleTransform().ScaleX;
                    SearchAreaCircle.Height = SearchAreaCircle.Width;
                    SearchAreaCircle.Margin = GetMapLocationAsMargin(currentBasePin, SearchAreaCircle.Width, SearchAreaCircle.Height);
                    SearchAreaCircle.Visibility = Visibility.Visible;
                }
                else
                {
                    SearchAreaCircle.Visibility = Visibility.Hidden;
                }
            }
        }

        private Thickness GetMapLocationAsMargin(Pin pin, double width, double height)
        {
            double scalingFactor = (MapImage.ActualWidth / (MapImage.Source as BitmapSource).PixelWidth) * MapBorder.GetScaleTransform().ScaleX;

            double translationX = MapBorder.GetTranslateTransform().X;
            double translationY = MapBorder.GetTranslateTransform().Y;

            Thickness thickness = new Thickness(
                    (pin.xDistance * scalingFactor + translationX) - (width / 2),
                    (pin.yDistance * scalingFactor + translationY) - (height / 2),
                    0, 0);

            return thickness;
        }

        private Point MapBorderCenter
        {
            get { return this.TranslatePoint(new Point(MapBorder.ActualWidth / 2, MapBorder.ActualHeight / 2), MapImage); }
        }

        #endregion        
    }
}
