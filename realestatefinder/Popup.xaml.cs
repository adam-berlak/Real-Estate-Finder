using System;
using System.Diagnostics;
using System.Windows.Navigation;
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
using System.Collections;
using MaterialDesignThemes.Wpf;

namespace realestatefinder

{
    /// <summary>
    /// Interaction logic for Popup1.xaml
    /// </summary>
    public partial class Popup : Window
    {
        List<string> picture_names;
        int selected_image_index = 0;
        public bool is_favorited = false;
        Listing displayedListing;
        List<Listing> savedListings;
        int selected_listing_index = 0;
        public bool enlarged = false;

        MainPage main;

        public Popup(MainPage m)
        {
            InitializeComponent();

            main = m;

            Rectangle wantedNode = (Rectangle)FindName("largebackground");
            wantedNode.Visibility = Visibility.Collapsed;

            Button wantedNode3 = (Button)FindName("largebackgroundbutton");
            wantedNode3.Visibility = Visibility.Collapsed;

            Image wantedNode2 = (Image)FindName("largeversion");
            wantedNode2.Visibility = Visibility.Collapsed;
        }

        public void enlargePicture(object sender, RoutedEventArgs e)
        {
            Rectangle wantedNode = (Rectangle)FindName("largebackground");
            Image wantedNode2 = (Image)FindName("largeversion");
            Button wantedNode3 = (Button)FindName("largebackgroundbutton");

            wantedNode2.Source = new BitmapImage(new Uri((string)picture_names[selected_image_index], UriKind.RelativeOrAbsolute));

            wantedNode.Visibility = Visibility.Visible;
            wantedNode2.Visibility = Visibility.Visible;
            wantedNode3.Visibility = Visibility.Visible;
            largenext.Visibility = Visibility.Visible;
            largeprev.Visibility = Visibility.Visible;
            enlarged = true;
        }

        public void closeEnlarge(object sender, RoutedEventArgs e)
        {
            Rectangle wantedNode = (Rectangle)FindName("largebackground");
            Image wantedNode2 = (Image)FindName("largeversion");
            Button wantedNode3 = (Button)FindName("largebackgroundbutton");

            wantedNode.Visibility = Visibility.Hidden;
            wantedNode2.Visibility = Visibility.Hidden;
            wantedNode3.Visibility = Visibility.Hidden;
            largenext.Visibility = Visibility.Hidden;
            largeprev.Visibility = Visibility.Hidden;
            enlarged = false;
        }

        public void setDescription(Listing inList)
        {
            displayedListing = inList;

            TextBlock price_field = (TextBlock)FindName("DescriptionPrice");
            TextBlock size_field = (TextBlock)FindName("DescriptionSize");
            TextBlock rooms_field = (TextBlock)FindName("DescriptionRooms");
            TextBlock utilities_field = (TextBlock)FindName("DescriptionUtilities");
            TextBlock pets_field = (TextBlock)FindName("DescriptionPets");
            TextBlock contact = (TextBlock)FindName("Contact");
            TextBlock address = (TextBlock)FindName("address");
            TextBlock desc = (TextBlock)FindName("DescriptionDesc");
            Label type = (Label)FindName("typelabel");
            Image map = (Image)FindName("map");
            Image previmage = (Image)FindName("image");
            Image favimage = (Image)FindName("favbutton");

            type.Content = inList.Type;
            desc.Text = inList.Description;

            if (inList.Saved)
            {
                favimage.Source = new BitmapImage(new Uri(@"assets/photos/star_filled.png", UriKind.RelativeOrAbsolute));
                is_favorited = true;
            }
            else
            {
                favimage.Source = new BitmapImage(new Uri(@"assets/photos/star_outline.png", UriKind.RelativeOrAbsolute));
                is_favorited = false;
            }

            price_field.Text = "Price: $" + inList.Price;
            size_field.Text = "Size: " + inList.Size;
            rooms_field.Text = "Rooms: " + inList.Beds + " Bedrooms, " + inList.Baths + " Bathrooms";

            if (inList.BuyOrRent.Equals("Rent"))
            {
                String utilities_text = "Utlities Included: \n";
                if (inList.HeatIncluded) utilities_text = utilities_text + "Heating, ";
                if (inList.ElectricityIncluded) utilities_text = utilities_text + "Electricity, ";
                if (inList.ParkingIncluded) utilities_text = utilities_text + "Parking, ";
                if (inList.WaterIncluded) utilities_text = utilities_text + "Water, ";
                if (inList.InternetIncluded) utilities_text = utilities_text + "Internet, ";
                if (inList.TelevisionIncluded) utilities_text = utilities_text + "Television";
                if (utilities_text.Equals("Utlities Included: \n"))
                {
                    utilities_text += "None";
                }
                if (utilities_text.EndsWith(", "))
                {
                    utilities_text = utilities_text.Trim().TrimEnd(',');
                }
                utilities_field.Text = utilities_text;

                if (inList.PetFriendly) pets_field.Text = "Pets Allowed: Yes";
                else pets_field.Text = "Pets Allowed: No";
            }
            else
            {
                utilities_field.Text = "";
                pets_field.Text = "";
            }

            map.Source = new BitmapImage(new Uri(inList.MapImage, UriKind.RelativeOrAbsolute));

            address.Text = inList.Address;

            contact.Text = inList.RealtorContactInfo;
            picture_names = inList.Images;
            selected_image_index = 0;
            previmage.Source = new BitmapImage(new Uri((string)picture_names[selected_image_index], UriKind.RelativeOrAbsolute));
        }

        public void savedMode(List<ListingPin> listingPins)
        {
            foreach (ListingPin lp in listingPins)
            {
                if (lp.listing.Saved)
                {
                    savedListings.Add(lp.listing);
                }
            }
            selected_listing_index = 0;
            setDescription(savedListings[selected_listing_index]);
        }

        private void favorite_click(object sender, RoutedEventArgs e)
        {
            Image previmage = (Image)FindName("favbutton");
            if (!is_favorited)
            {
                previmage.Source = new BitmapImage(new Uri(@"assets/photos/star_filled.png", UriKind.RelativeOrAbsolute));
                is_favorited = true;
                displayedListing.Saved = true;
                previmage.ToolTip = "Press to remove this from your saved listings";
            }
            else
            {
                previmage.Source = new BitmapImage(new Uri(@"assets/photos/star_outline.png", UriKind.RelativeOrAbsolute));
                is_favorited = false;
                displayedListing.Saved = false;
                previmage.ToolTip = "Press to save listing for later";
            }

            main.UpdateSidebarStars();
        }
        private void gallary_next(object sender, RoutedEventArgs e)
        {
            Image previmage = (Image)FindName("image");
            if (previmage is Image)
            {
                if (selected_image_index == picture_names.Count - 1) selected_image_index = 0;
                else selected_image_index++;
                previmage.Source = new BitmapImage(new Uri((string)picture_names[selected_image_index], UriKind.RelativeOrAbsolute));  
            }
        }
        private void gallary_previous(object sender, RoutedEventArgs e)
        {
            Image previmage = (Image)FindName("image");
            if (previmage is Image)
            {
                if (selected_image_index == 0) selected_image_index = picture_names.Count - 1;
                else selected_image_index--;
                previmage.Source = new BitmapImage(new Uri((string)picture_names[selected_image_index], UriKind.RelativeOrAbsolute));
            }
        }

        private void gallary_next_large(object sender, RoutedEventArgs e)
        {
            Image previmage = (Image)FindName("largeversion");
            if (previmage is Image)
            {
                if (selected_image_index == picture_names.Count - 1) selected_image_index = 0;
                else selected_image_index++;
                previmage.Source = new BitmapImage(new Uri((string)picture_names[selected_image_index], UriKind.RelativeOrAbsolute));
            }
        }
        private void gallary_previous_large(object sender, RoutedEventArgs e)
        {
            Image previmage = (Image)FindName("largeversion");
            if (previmage is Image)
            {
                if (selected_image_index == 0) selected_image_index = picture_names.Count - 1;
                else selected_image_index--;
                previmage.Source = new BitmapImage(new Uri((string)picture_names[selected_image_index], UriKind.RelativeOrAbsolute));
            }
        }
        private void contact_realtor_button(object sender, RoutedEventArgs e)
        {
            //System.Diagnostics.Process.Start("mailto:Retailor@ReMacks.ca?subject=SubjectExample&amp;body=BodyExample");
            MessageBoxResult result = MessageBox.Show("Email integration under development", "Under Development", MessageBoxButton.OK);
        }
        private void buttonClick2(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            b.Opacity = 100;
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            main.ClosePopup(sender, e);
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }
        private void OnNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.AbsoluteUri);
            e.Handled = true;
        }

        private void myTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
