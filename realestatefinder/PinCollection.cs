using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace realestatefinder
{
    public static class PinCollection
    {
        public static readonly List<Pin> pins;

        public static readonly Dictionary<string, string> searchLocations;

        public static readonly List<Pin> blueLineTrainStations;
        public static readonly List<Pin> redLineTrainStations;

        static PinCollection()
        {
            pins = new List<Pin>();

            #region Train Markers
            redLineTrainStations = new List<Pin>()
            {
                // add pins here
                new MapMarker(944, 286),
                new MapMarker(1288, 518),
                new MapMarker(1825.0, 868.0),
                new MapMarker(2161, 1173),
                new MapMarker(2252, 1287),
                new MapMarker(2342, 1469),
                new MapMarker(2480, 1575),
                new MapMarker(2633, 1619),
                new MapMarker(2706, 1740),
                new MapMarker(2760, 1912),
                new MapMarker(2788, 1914),
                new MapMarker(2817, 1914),
                new MapMarker(2845, 1916),
                new MapMarker(2945, 1919),
                new MapMarker(2972, 1920),
                new MapMarker(3008, 2063),
                new MapMarker(2997, 2203),
                new MapMarker(3030, 1923)
            };

            redLineTrainStations.ForEach(x =>
            {
                x.image.Source = new BitmapImage(new Uri("assets/photos/trainMarkerRed.png", UriKind.Relative));
                x.Width = 30;
                x.Opacity = 0.7;
                x.IsHitTestVisible = false;
            });

            pins.AddRange(redLineTrainStations);

            blueLineTrainStations = new List<Pin>()
            {
                new MapMarker(1493, 2085),
                new MapMarker(1713, 2074),
                new MapMarker(1901, 2075),
                new MapMarker(2101, 2034),
                new MapMarker(2239, 2009),
                new MapMarker(2537, 1950),
                new MapMarker(2672, 1907),
                new MapMarker(3229, 1874),
                new MapMarker(3396, 1904),
                new MapMarker(3628, 1941)
            };

            blueLineTrainStations.ForEach(x =>
            {
                x.image.Source = new BitmapImage(new Uri("assets/photos/trainMarkerBlue.png", UriKind.Relative));
                x.Width = 30;
                x.Opacity = 0.7;
                x.IsHitTestVisible = false;
            });

            pins.AddRange(blueLineTrainStations);
            #endregion

            #region Search Locations
            searchLocations = new Dictionary<string, string>();
            searchLocations.Add("2500 University Dr NW", "University of Calgary");
            searchLocations.Add("500 Centre St S", "Downtown");
            searchLocations.Add("212 Tuscany Way NW", null);
            searchLocations.Add("8777 Nose Hill Dr NW", "Robert Thirsk High School");
            searchLocations.Add("5225 Varsity Dr NW", "Marion Carson Elementary School");
            searchLocations.Add("4820 Northland Dr NW", null);
            searchLocations.Add("1301 16 Ave NW", "SAIT");
            searchLocations.Add("223 10 St NW", null);
            searchLocations.Add("877 Northmount Dr NW", "St. Francis High School");
            searchLocations.Add("7904 43 Ave NW", null);
            #endregion

            #region Base Pins
            List<Pin> basePins = new List<Pin>()
            {
                // the first 10 pins are the base pins
                // base pins are the red pins that the circle on the map is centered on
                new Pin(searchLocations.Keys.ElementAt(0), 1, 2167, 1337), // University of Calgary 2500 University Dr NW, Calgary, AB T2N 1N4
                new Pin(searchLocations.Keys.ElementAt(1), 2, 2971, 1893), // Downtown Calgary 500 Centre St S, Calgary, AB T2G 0E3
                new Pin(searchLocations.Keys.ElementAt(2), 3, 831, 463), // 212 Tuscany Way NW, Calgary, AB T3L 2J6
                new Pin(searchLocations.Keys.ElementAt(3), 4, 1416, 354), // Robert Thirsk High School 8777 Nose Hill Dr NW, Calgary, AB T3G 5T3
                new Pin(searchLocations.Keys.ElementAt(4), 5, 1810, 1058), // Marion Carson Elementary School 5225 Varsity Dr NW, Calgary, AB T3A 1A7
                new Pin(searchLocations.Keys.ElementAt(5), 6, 2052, 1010), // 4820 Northland Dr NW, Calgary, AB T2L 2L3
                new Pin(searchLocations.Keys.ElementAt(6), 7, 2680, 1549), // SAIT 1301 16 Ave NW, Calgary, AB T2M 0L4
                new Pin(searchLocations.Keys.ElementAt(7), 8, 2683, 1788), // 223 10 St NW, Calgary, AB T2N 1V5
                new Pin(searchLocations.Keys.ElementAt(8), 9, 2500, 1204), // St. Francis High School 877 Northmount Dr NW, Calgary, AB T2L 0A7
                new Pin(searchLocations.Keys.ElementAt(9), 10, 1359, 1079), // 7904 43 Ave NW, Calgary, AB T3B 4P9
            };

            pins.AddRange(basePins);
            #endregion

            #region Listing Pins
            List<Pin> listingPins = new List<Pin>()
            {
                #region Listing Pins for Base Pin 1
                // listing pins for base pin 1
                new ListingPin(
                    new Listing(11, "Rent", "Apartment",
                        "3830 Brentwood Road NW", "This cozy 1200 sq ft apartment features stainless steel appliances, in suite laundry and floor to ceiling windows that have a fantastic west facing mountain view.",
                        "1200 square feet", "Gary Smith: (403)655-4763 gsmith@ReMacks.com",
                        1800, 2, 2,
                        true, false, true, true, false, false, false,
                        new List<string> {
                            @"assets/listing_photos/listing1/listing1_exterior.PNG",
                            @"assets/listing_photos/listing1/listing1_1.PNG",
                            @"assets/listing_photos/listing1/listing1_2.PNG",
                            @"assets/listing_photos/listing1/listing1_3.PNG",
                            @"assets/listing_photos/listing1/listing1_4.PNG",
                            @"assets/listing_photos/listing1/listing1_5.PNG"},
                        @"assets/listing_photos/listing1/listing1_map.PNG"), 
                    11, 1, basePins[0], 30, -174),
                new ListingPin(
                    new Listing(12, "Buy", "House",
                        "3279 Underhill Dr NW", "A recently remodeled 2 story home featuring a 2 car garage, large fenced back yard and new kitchen appliances.",
                        "2400 square feet", "Gary Smith: (403)655-4763 gsmith@ReMacks.com",
                        345000, 3, 2.5,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing2/listing2_exterior.PNG",
                            @"assets/listing_photos/listing2/listing2_1.PNG",
                            @"assets/listing_photos/listing2/listing2_2.PNG",
                            @"assets/listing_photos/listing2/listing2_3.PNG",
                            @"assets/listing_photos/listing2/listing2_4.PNG",
                            @"assets/listing_photos/listing2/listing2_5.PNG"},
                        @"assets/listing_photos/listing2/listing2_map.PNG"),
                    12, 1, basePins[0], -17, 108),
                new ListingPin(
                    new Listing(13, "Rent", "Townhouse",
                        "3215 Morley Trail NW", "This 2 story townhouse in a prime location features newly remodled bathrooms and a private entrance.",
                        "1800 square feet", "Mary Smyth: (403)655-6347 msmyth@ReMacks.com",
                        1400, 2, 1.5,
                        false, false, false, false, false, false, true,
                        new List<string> {
                            @"assets/listing_photos/listing3/listing3_exterior.PNG",
                            @"assets/listing_photos/listing3/listing3_1.PNG",
                            @"assets/listing_photos/listing3/listing3_2.PNG",
                            @"assets/listing_photos/listing3/listing3_3.PNG",
                            @"assets/listing_photos/listing3/listing3_4.PNG",
                            @"assets/listing_photos/listing3/listing3_5.PNG"},
                        @"assets/listing_photos/listing3/listing3_map.PNG"),
                    13, 1, basePins[0], 158, -37),
                new ListingPin(
                    new Listing(14, "Buy", "Condo",
                        "12 Varmoor Pl NW", "Condo in great neighbourhood with large fenced backyard, reserved street parking and a spacious kitchen.",
                        "2000 square feet", "Mary Smyth: (403)655-6347 msmyth@ReMacks.com",
                        125000, 4, 4,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing4/listing4_exterior.PNG",
                            @"assets/listing_photos/listing4/listing4_1.PNG",
                            @"assets/listing_photos/listing4/listing4_2.PNG",
                            @"assets/listing_photos/listing4/listing4_3.PNG",
                            @"assets/listing_photos/listing4/listing4_4.PNG",
                            @"assets/listing_photos/listing4/listing4_5.PNG"},
                        @"assets/listing_photos/listing4/listing4_map.PNG"),
                    14, 1, basePins[0], -135, -73),
                new ListingPin(
                    new Listing(15, "Rent", "Loft",
                        "1116 Windsor St NW", "This cozy loft features a private entrance and it's own kitchen with new appliances.",
                        "600 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        800, 1, 1,
                        true, true, true, true, true, true, false,
                        new List<string> {
                            @"assets/listing_photos/listing5/listing5_exterior.PNG",
                            @"assets/listing_photos/listing5/listing5_1.PNG",
                            @"assets/listing_photos/listing5/listing5_2.PNG",
                            @"assets/listing_photos/listing5/listing5_3.PNG",
                            @"assets/listing_photos/listing5/listing5_4.PNG",
                            @"assets/listing_photos/listing5/listing5_5.PNG"},
                        @"assets/listing_photos/listing5/listing5_map.PNG"),
                    15, 1, basePins[0], 103, 321),
                new ListingPin(
                    new Listing(16, "Rent", "Duplex",
                        "4403 19 Ave NW", "This beautiful newly constructed duplex features plenty of space, an open concept floor plan and shared access to a fenced backyard.",
                        "2400 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        2200, 5, 6,
                        false, false, false, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing6/listing6_exterior.PNG",
                            @"assets/listing_photos/listing6/listing6_1.PNG",
                            @"assets/listing_photos/listing6/listing6_2.PNG",
                            @"assets/listing_photos/listing6/listing6_3.PNG",
                            @"assets/listing_photos/listing6/listing6_4.PNG",
                            @"assets/listing_photos/listing6/listing6_5.PNG"},
                        @"assets/listing_photos/listing6/listing6_map.PNG"),
                    16, 1, basePins[0], -287, 153),
                new ListingPin(
                    new Listing(17, "Buy", "Condo",
                        "3114 34 Avenue NW", "This condo is in a prime location. Easy comute to downtown and a great view of the Rocky Mountains. Beautiful hardwood floors throughout.",
                        "860 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        550000, 3, 2.5,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing7/listing7_exterior.PNG",
                            @"assets/listing_photos/listing7/listing7_1.PNG",
                            @"assets/listing_photos/listing7/listing7_2.PNG",
                            @"assets/listing_photos/listing7/listing7_3.PNG",
                            @"assets/listing_photos/listing7/listing7_4.PNG",
                            @"assets/listing_photos/listing7/listing7_5.PNG"},
                        @"assets/listing_photos/listing7/listing7_map.PNG"),
                    17, 1, basePins[0], 25, -105),
                new ListingPin(
                    new Listing(18, "Rent", "House",
                        "3997 Varsity Drive NW", "Beautiful and fully renovated home featuring gas range and stainless appliances and granite countertops.",
                        "2650 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        5500, 6, 5.5,
                        false, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing8/listing8_exterior.PNG",
                            @"assets/listing_photos/listing8/listing8_1.PNG",
                            @"assets/listing_photos/listing8/listing8_2.PNG",
                            @"assets/listing_photos/listing8/listing8_3.PNG",
                            @"assets/listing_photos/listing8/listing8_4.PNG",
                            @"assets/listing_photos/listing8/listing8_5.PNG"},
                        @"assets/listing_photos/listing8/listing8_map.PNG"),
                    18, 1, basePins[0], -180, -257),
                new ListingPin(
                    new Listing(19, "Buy", "House",
                        "4415 Bulyea Road NW", "This beautifully designed home feels like it is almost brand new. The ultimate location and over 4,000 sq ft of the finest finishes come together in this luxury infill. Gorgeous curved staircase, modern fixtures, built-in cabinets, 2 gas fireplaces & a culinary dream kitchen with dark stained maple cabinets, stainless steel appliances and granite counters are only a few of the many features of this home.",
                        "4500 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        1850000, 6, 6,
                        true, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing9/listing9_exterior.PNG",
                            @"assets/listing_photos/listing9/listing9_1.PNG",
                            @"assets/listing_photos/listing9/listing9_2.PNG",
                            @"assets/listing_photos/listing9/listing9_3.PNG",
                            @"assets/listing_photos/listing9/listing9_4.PNG",
                            @"assets/listing_photos/listing9/listing9_5.PNG"},
                        @"assets/listing_photos/listing9/listing9_map.PNG"),
                    19, 1, basePins[0], -66, -292),
                new ListingPin(
                    new Listing(20, "Buy", "Apartment",
                        "4020 Vance Pl NW", "This Penthouse apartment has full unobstructed city views with a commanding nighttime view where you will want to leave the drapes open. Kitchen and living room with rift cut oak cabinets built-in with feature wall, gas fireplace, and nook area.",
                        "2650 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        1125000, 4, 4,
                        true, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing10/listing10_exterior.PNG",
                            @"assets/listing_photos/listing10/listing10_1.PNG",
                            @"assets/listing_photos/listing10/listing10_2.PNG",
                            @"assets/listing_photos/listing10/listing10_3.PNG",
                            @"assets/listing_photos/listing10/listing10_4.PNG",
                            @"assets/listing_photos/listing10/listing10_5.PNG"},
                        @"assets/listing_photos/listing10/listing10_map.PNG"),
                    20, 1, basePins[0], 178, 284),
                #endregion

                #region Listing Pins for Base Pin 2
                // listing pins for base pin 2
                new ListingPin(
                    new Listing(21, "Rent", "Apartment",
                        "3830 Brentwood Road NW", "This cozy 1200 sq ft apartment features stainless steel appliances, in suite laundry and floor to ceiling windows that have a fantastic west facing mountain view.",
                        "1200 square feet", "Gary Smith: (403)655-4763 gsmith@ReMacks.com",
                        1800, 2, 2,
                        true, false, true, true, false, false, false,
                        new List<string> {
                            @"assets/listing_photos/listing1/listing1_exterior.PNG",
                            @"assets/listing_photos/listing1/listing1_1.PNG",
                            @"assets/listing_photos/listing1/listing1_2.PNG",
                            @"assets/listing_photos/listing1/listing1_3.PNG",
                            @"assets/listing_photos/listing1/listing1_4.PNG",
                            @"assets/listing_photos/listing1/listing1_5.PNG"},
                        @"assets/listing_photos/listing1/listing1_map.PNG"),
                    21, 2, basePins[1], 30, -174),
                new ListingPin(
                    new Listing(22, "Buy", "House",
                        "3279 Underhill Dr NW", "A recently remodeled 2 story home featuring a 2 car garage, large fenced back yard and new kitchen appliances.",
                        "2400 square feet", "Gary Smith: (403)655-4763 gsmith@ReMacks.com",
                        345000, 3, 2.5,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing2/listing2_exterior.PNG",
                            @"assets/listing_photos/listing2/listing2_1.PNG",
                            @"assets/listing_photos/listing2/listing2_2.PNG",
                            @"assets/listing_photos/listing2/listing2_3.PNG",
                            @"assets/listing_photos/listing2/listing2_4.PNG",
                            @"assets/listing_photos/listing2/listing2_5.PNG"},
                        @"assets/listing_photos/listing2/listing2_map.PNG"),
                    22, 2, basePins[1], -17, 108),
                new ListingPin(
                    new Listing(23, "Rent", "Townhouse",
                        "3215 Morley Trail NW", "This 2 story townhouse in a prime location features newly remodled bathrooms and a private entrance.",
                        "1800 square feet", "Mary Smyth: (403)655-6347 msmyth@ReMacks.com",
                        1400, 2, 1.5,
                        false, false, false, false, false, false, true,
                        new List<string> {
                            @"assets/listing_photos/listing3/listing3_exterior.PNG",
                            @"assets/listing_photos/listing3/listing3_1.PNG",
                            @"assets/listing_photos/listing3/listing3_2.PNG",
                            @"assets/listing_photos/listing3/listing3_3.PNG",
                            @"assets/listing_photos/listing3/listing3_4.PNG",
                            @"assets/listing_photos/listing3/listing3_5.PNG"},
                        @"assets/listing_photos/listing3/listing3_map.PNG"),
                    23, 2, basePins[1], 158, -37),
                new ListingPin(
                    new Listing(24, "Buy", "Condo",
                        "12 Varmoor Pl NW", "Condo in great neighbourhood with large fenced backyard, reserved street parking and a spacious kitchen.",
                        "2000 square feet", "Mary Smyth: (403)655-6347 msmyth@ReMacks.com",
                        125000, 4, 4,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing4/listing4_exterior.PNG",
                            @"assets/listing_photos/listing4/listing4_1.PNG",
                            @"assets/listing_photos/listing4/listing4_2.PNG",
                            @"assets/listing_photos/listing4/listing4_3.PNG",
                            @"assets/listing_photos/listing4/listing4_4.PNG",
                            @"assets/listing_photos/listing4/listing4_5.PNG"},
                        @"assets/listing_photos/listing4/listing4_map.PNG"),
                    24, 2, basePins[1], -135, -73),
                new ListingPin(
                    new Listing(25, "Rent", "Loft",
                        "1116 Windsor St NW", "This cozy loft features a private entrance and it's own kitchen with new appliances.",
                        "600 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        800, 1, 1,
                        true, true, true, true, true, true, false,
                        new List<string> {
                            @"assets/listing_photos/listing5/listing5_exterior.PNG",
                            @"assets/listing_photos/listing5/listing5_1.PNG",
                            @"assets/listing_photos/listing5/listing5_2.PNG",
                            @"assets/listing_photos/listing5/listing5_3.PNG",
                            @"assets/listing_photos/listing5/listing5_4.PNG",
                            @"assets/listing_photos/listing5/listing5_5.PNG"},
                        @"assets/listing_photos/listing5/listing5_map.PNG"),
                    25, 2, basePins[1], 103, 321),
                new ListingPin(
                    new Listing(26, "Rent", "Duplex",
                        "4403 19 Ave NW", "This beautiful newly constructed duplex features plenty of space, an open concept floor plan and shared access to a fenced backyard.",
                        "2400 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        2200, 5, 6,
                        false, false, false, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing6/listing6_exterior.PNG",
                            @"assets/listing_photos/listing6/listing6_1.PNG",
                            @"assets/listing_photos/listing6/listing6_2.PNG",
                            @"assets/listing_photos/listing6/listing6_3.PNG",
                            @"assets/listing_photos/listing6/listing6_4.PNG",
                            @"assets/listing_photos/listing6/listing6_5.PNG"},
                        @"assets/listing_photos/listing6/listing6_map.PNG"),
                    26, 2, basePins[1], -287, 153),
                new ListingPin(
                    new Listing(27, "Buy", "Condo",
                        "3114 34 Avenue NW", "This condo is in a prime location. Easy comute to downtown and a great view of the Rocky Mountains. Beautiful hardwood floors throughout.",
                        "860 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        550000, 3, 2.5,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing7/listing7_exterior.PNG",
                            @"assets/listing_photos/listing7/listing7_1.PNG",
                            @"assets/listing_photos/listing7/listing7_2.PNG",
                            @"assets/listing_photos/listing7/listing7_3.PNG",
                            @"assets/listing_photos/listing7/listing7_4.PNG",
                            @"assets/listing_photos/listing7/listing7_5.PNG"},
                        @"assets/listing_photos/listing7/listing7_map.PNG"),
                    27, 2, basePins[1], 25, -105),
                new ListingPin(
                    new Listing(28, "Rent", "House",
                        "3997 Varsity Drive NW", "Beautiful and fully renovated home featuring gas range and stainless appliances and granite countertops.",
                        "2650 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        5500, 6, 5.5,
                        false, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing8/listing8_exterior.PNG",
                            @"assets/listing_photos/listing8/listing8_1.PNG",
                            @"assets/listing_photos/listing8/listing8_2.PNG",
                            @"assets/listing_photos/listing8/listing8_3.PNG",
                            @"assets/listing_photos/listing8/listing8_4.PNG",
                            @"assets/listing_photos/listing8/listing8_5.PNG"},
                        @"assets/listing_photos/listing8/listing8_map.PNG"),
                    28, 2, basePins[1], -180, -257),
                new ListingPin(
                    new Listing(29, "Buy", "House",
                        "4415 Bulyea Road NW", "This beautifully designed home feels like it is almost brand new. The ultimate location and over 4,000 sq ft of the finest finishes come together in this luxury infill. Gorgeous curved staircase, modern fixtures, built-in cabinets, 2 gas fireplaces & a culinary dream kitchen with dark stained maple cabinets, stainless steel appliances and granite counters are only a few of the many features of this home.",
                        "4500 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        1850000, 6, 6,
                        true, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing9/listing9_exterior.PNG",
                            @"assets/listing_photos/listing9/listing9_1.PNG",
                            @"assets/listing_photos/listing9/listing9_2.PNG",
                            @"assets/listing_photos/listing9/listing9_3.PNG",
                            @"assets/listing_photos/listing9/listing9_4.PNG",
                            @"assets/listing_photos/listing9/listing9_5.PNG"},
                        @"assets/listing_photos/listing9/listing9_map.PNG"),
                    29, 2, basePins[1], -66, -292),
                new ListingPin(
                    new Listing(30, "Buy", "Apartment",
                        "4020 Vance Pl NW", "This Penthouse apartment has full unobstructed city views with a commanding nighttime view where you will want to leave the drapes open. Kitchen and living room with rift cut oak cabinets built-in with feature wall, gas fireplace, and nook area.",
                        "2650 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        1125000, 4, 4,
                        true, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing10/listing10_exterior.PNG",
                            @"assets/listing_photos/listing10/listing10_1.PNG",
                            @"assets/listing_photos/listing10/listing10_2.PNG",
                            @"assets/listing_photos/listing10/listing10_3.PNG",
                            @"assets/listing_photos/listing10/listing10_4.PNG",
                            @"assets/listing_photos/listing10/listing10_5.PNG"},
                        @"assets/listing_photos/listing10/listing10_map.PNG"),
                    30, 2, basePins[1], 178, 284),
                #endregion

                #region Listing Pins for Base Pin 3
                // listing pins for base pin 3
                new ListingPin(
                    new Listing(31, "Rent", "Apartment",
                        "3830 Brentwood Road NW", "This cozy 1200 sq ft apartment features stainless steel appliances, in suite laundry and floor to ceiling windows that have a fantastic west facing mountain view.",
                        "1200 square feet", "Gary Smith: (403)655-4763 gsmith@ReMacks.com",
                        1800, 2, 2,
                        true, false, true, true, false, false, false,
                        new List<string> {
                            @"assets/listing_photos/listing1/listing1_exterior.PNG",
                            @"assets/listing_photos/listing1/listing1_1.PNG",
                            @"assets/listing_photos/listing1/listing1_2.PNG",
                            @"assets/listing_photos/listing1/listing1_3.PNG",
                            @"assets/listing_photos/listing1/listing1_4.PNG",
                            @"assets/listing_photos/listing1/listing1_5.PNG"},
                        @"assets/listing_photos/listing1/listing1_map.PNG"),
                    31, 3, basePins[2], 30, -174),
                new ListingPin(
                    new Listing(32, "Buy", "House",
                        "3279 Underhill Dr NW", "A recently remodeled 2 story home featuring a 2 car garage, large fenced back yard and new kitchen appliances.",
                        "2400 square feet", "Gary Smith: (403)655-4763 gsmith@ReMacks.com",
                        345000, 3, 2.5,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing2/listing2_exterior.PNG",
                            @"assets/listing_photos/listing2/listing2_1.PNG",
                            @"assets/listing_photos/listing2/listing2_2.PNG",
                            @"assets/listing_photos/listing2/listing2_3.PNG",
                            @"assets/listing_photos/listing2/listing2_4.PNG",
                            @"assets/listing_photos/listing2/listing2_5.PNG"},
                        @"assets/listing_photos/listing2/listing2_map.PNG"),
                    32, 3, basePins[2], -17, 108),
                 new ListingPin(
                    new Listing(33, "Rent", "Townhouse",
                        "3215 Morley Trail NW", "This 2 story townhouse in a prime location features newly remodled bathrooms and a private entrance.",
                        "1800 square feet", "Mary Smyth: (403)655-6347 msmyth@ReMacks.com",
                        1400, 2, 1.5,
                        false, false, false, false, false, false, true,
                        new List<string> {
                            @"assets/listing_photos/listing3/listing3_exterior.PNG",
                            @"assets/listing_photos/listing3/listing3_1.PNG",
                            @"assets/listing_photos/listing3/listing3_2.PNG",
                            @"assets/listing_photos/listing3/listing3_3.PNG",
                            @"assets/listing_photos/listing3/listing3_4.PNG",
                            @"assets/listing_photos/listing3/listing3_5.PNG"},
                        @"assets/listing_photos/listing3/listing3_map.PNG"),
                    33, 3, basePins[2], 158, -37),
                new ListingPin(
                    new Listing(34, "Buy", "Condo",
                        "12 Varmoor Pl NW", "Condo in great neighbourhood with large fenced backyard, reserved street parking and a spacious kitchen.",
                        "2000 square feet", "Mary Smyth: (403)655-6347 msmyth@ReMacks.com",
                        125000, 4, 4,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing4/listing4_exterior.PNG",
                            @"assets/listing_photos/listing4/listing4_1.PNG",
                            @"assets/listing_photos/listing4/listing4_2.PNG",
                            @"assets/listing_photos/listing4/listing4_3.PNG",
                            @"assets/listing_photos/listing4/listing4_4.PNG",
                            @"assets/listing_photos/listing4/listing4_5.PNG"},
                         @"assets/listing_photos/listing4/listing4_map.PNG"),
                    34, 3, basePins[2], -135, -73),
                new ListingPin(
                    new Listing(35, "Rent", "Loft",
                        "1116 Windsor St NW", "This cozy loft features a private entrance and it's own kitchen with new appliances.",
                        "600 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        800, 1, 1,
                        true, true, true, true, true, true, false,
                        new List<string> {
                            @"assets/listing_photos/listing5/listing5_exterior.PNG",
                            @"assets/listing_photos/listing5/listing5_1.PNG",
                            @"assets/listing_photos/listing5/listing5_2.PNG",
                            @"assets/listing_photos/listing5/listing5_3.PNG",
                            @"assets/listing_photos/listing5/listing5_4.PNG",
                            @"assets/listing_photos/listing5/listing5_5.PNG"},
                        @"assets/listing_photos/listing5/listing5_map.PNG"),
                    35, 3, basePins[2], 103, 321),
                new ListingPin(
                    new Listing(36, "Rent", "Duplex",
                        "4403 19 Ave NW", "This beautiful newly constructed duplex features plenty of space, an open concept floor plan and shared access to a fenced backyard.",
                        "2400 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        2200, 5, 6,
                        false, false, false, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing6/listing6_exterior.PNG",
                            @"assets/listing_photos/listing6/listing6_1.PNG",
                            @"assets/listing_photos/listing6/listing6_2.PNG",
                            @"assets/listing_photos/listing6/listing6_3.PNG",
                            @"assets/listing_photos/listing6/listing6_4.PNG",
                            @"assets/listing_photos/listing6/listing6_5.PNG"},
                        @"assets/listing_photos/listing6/listing6_map.PNG"),
                    36, 3, basePins[2], -287, 153),
                new ListingPin(
                    new Listing(37, "Buy", "Condo",
                        "3114 34 Avenue NW", "This condo is in a prime location. Easy comute to downtown and a great view of the Rocky Mountains. Beautiful hardwood floors throughout.",
                        "860 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        550000, 3, 2.5,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing7/listing7_exterior.PNG",
                            @"assets/listing_photos/listing7/listing7_1.PNG",
                            @"assets/listing_photos/listing7/listing7_2.PNG",
                            @"assets/listing_photos/listing7/listing7_3.PNG",
                            @"assets/listing_photos/listing7/listing7_4.PNG",
                            @"assets/listing_photos/listing7/listing7_5.PNG"},
                        @"assets/listing_photos/listing7/listing7_map.PNG"),
                    37, 3, basePins[2], 25, -105),
                new ListingPin(
                    new Listing(38, "Rent", "House",
                        "3997 Varsity Drive NW", "Beautiful and fully renovated home featuring gas range and stainless appliances and granite countertops.",
                        "2650 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        5500, 6, 5.5,
                        false, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing8/listing8_exterior.PNG",
                            @"assets/listing_photos/listing8/listing8_1.PNG",
                            @"assets/listing_photos/listing8/listing8_2.PNG",
                            @"assets/listing_photos/listing8/listing8_3.PNG",
                            @"assets/listing_photos/listing8/listing8_4.PNG",
                            @"assets/listing_photos/listing8/listing8_5.PNG"},
                        @"assets/listing_photos/listing8/listing8_map.PNG"),
                    38, 3, basePins[2], -180, -257),
                new ListingPin(
                    new Listing(39, "Buy", "House",
                        "4415 Bulyea Road NW", "This beautifully designed home feels like it is almost brand new. The ultimate location and over 4,000 sq ft of the finest finishes come together in this luxury infill. Gorgeous curved staircase, modern fixtures, built-in cabinets, 2 gas fireplaces & a culinary dream kitchen with dark stained maple cabinets, stainless steel appliances and granite counters are only a few of the many features of this home.",
                        "4500 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        1850000, 6, 6,
                        true, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing9/listing9_exterior.PNG",
                            @"assets/listing_photos/listing9/listing9_1.PNG",
                            @"assets/listing_photos/listing9/listing9_2.PNG",
                            @"assets/listing_photos/listing9/listing9_3.PNG",
                            @"assets/listing_photos/listing9/listing9_4.PNG",
                            @"assets/listing_photos/listing9/listing9_5.PNG"},
                        @"assets/listing_photos/listing9/listing9_map.PNG"),
                    39, 3, basePins[2], -66, -292),
                new ListingPin(
                    new Listing(40, "Buy", "Apartment",
                        "4020 Vance Pl NW", "This Penthouse apartment has full unobstructed city views with a commanding nighttime view where you will want to leave the drapes open. Kitchen and living room with rift cut oak cabinets built-in with feature wall, gas fireplace, and nook area.",
                        "2650 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        1125000, 4, 4,
                        true, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing10/listing10_exterior.PNG",
                            @"assets/listing_photos/listing10/listing10_1.PNG",
                            @"assets/listing_photos/listing10/listing10_2.PNG",
                            @"assets/listing_photos/listing10/listing10_3.PNG",
                            @"assets/listing_photos/listing10/listing10_4.PNG",
                            @"assets/listing_photos/listing10/listing10_5.PNG"},
                        @"assets/listing_photos/listing10/listing10_map.PNG"),
                    40, 3, basePins[2], 178, 284),
                #endregion

                #region Listing Pins for Base Pin 4
                // listing pins for base pin 4
                new ListingPin(
                    new Listing(41, "Rent", "Apartment",
                        "3830 Brentwood Road NW", "This cozy 1200 sq ft apartment features stainless steel appliances, in suite laundry and floor to ceiling windows that have a fantastic west facing mountain view.",
                        "1200 square feet", "Gary Smith: (403)655-4763 gsmith@ReMacks.com",
                        1800, 2, 2,
                        true, false, true, true, false, false, false,
                        new List<string> {
                            @"assets/listing_photos/listing1/listing1_exterior.PNG",
                            @"assets/listing_photos/listing1/listing1_1.PNG",
                            @"assets/listing_photos/listing1/listing1_2.PNG",
                            @"assets/listing_photos/listing1/listing1_3.PNG",
                            @"assets/listing_photos/listing1/listing1_4.PNG",
                            @"assets/listing_photos/listing1/listing1_5.PNG"},
                        @"assets/listing_photos/listing1/listing1_map.PNG"),
                    41, 4, basePins[3], 30, -174),
                new ListingPin(
                    new Listing(42, "Buy", "House",
                        "3279 Underhill Dr NW", "A recently remodeled 2 story home featuring a 2 car garage, large fenced back yard and new kitchen appliances.",
                        "2400 square feet", "Gary Smith: (403)655-4763 gsmith@ReMacks.com",
                        345000, 3, 2.5,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing2/listing2_exterior.PNG",
                            @"assets/listing_photos/listing2/listing2_1.PNG",
                            @"assets/listing_photos/listing2/listing2_2.PNG",
                            @"assets/listing_photos/listing2/listing2_3.PNG",
                            @"assets/listing_photos/listing2/listing2_4.PNG",
                            @"assets/listing_photos/listing2/listing2_5.PNG"},
                        @"assets/listing_photos/listing2/listing2_map.PNG"),
                    42, 4, basePins[3], -17, 108),
                 new ListingPin(
                    new Listing(43, "Rent", "Townhouse",
                        "3215 Morley Trail NW", "This 2 story townhouse in a prime location features newly remodled bathrooms and a private entrance.",
                        "1800 square feet", "Mary Smyth: (403)655-6347 msmyth@ReMacks.com",
                        1400, 2, 1.5,
                        false, false, false, false, false, false, true,
                        new List<string> {
                            @"assets/listing_photos/listing3/listing3_exterior.PNG",
                            @"assets/listing_photos/listing3/listing3_1.PNG",
                            @"assets/listing_photos/listing3/listing3_2.PNG",
                            @"assets/listing_photos/listing3/listing3_3.PNG",
                            @"assets/listing_photos/listing3/listing3_4.PNG",
                            @"assets/listing_photos/listing3/listing3_5.PNG"},
                        @"assets/listing_photos/listing3/listing3_map.PNG"),
                    43, 4, basePins[3], 158, -37),
                new ListingPin(
                    new Listing(44, "Buy", "Condo",
                        "12 Varmoor Pl NW", "Condo in great neighbourhood with large fenced backyard, reserved street parking and a spacious kitchen.",
                        "2000 square feet", "Mary Smyth: (403)655-6347 msmyth@ReMacks.com",
                        125000, 4, 4,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing4/listing4_exterior.PNG",
                            @"assets/listing_photos/listing4/listing4_1.PNG",
                            @"assets/listing_photos/listing4/listing4_2.PNG",
                            @"assets/listing_photos/listing4/listing4_3.PNG",
                            @"assets/listing_photos/listing4/listing4_4.PNG",
                            @"assets/listing_photos/listing4/listing4_5.PNG"},
                        @"assets/listing_photos/listing4/listing4_map.PNG"),
                    44, 4, basePins[3], -135, -73),
                new ListingPin(
                    new Listing(45, "Rent", "Loft",
                        "1116 Windsor St NW", "This cozy loft features a private entrance and it's own kitchen with new appliances.",
                        "600 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        800, 1, 1,
                        true, true, true, true, true, true, false,
                        new List<string> {
                            @"assets/listing_photos/listing5/listing5_exterior.PNG",
                            @"assets/listing_photos/listing5/listing5_1.PNG",
                            @"assets/listing_photos/listing5/listing5_2.PNG",
                            @"assets/listing_photos/listing5/listing5_3.PNG",
                            @"assets/listing_photos/listing5/listing5_4.PNG",
                            @"assets/listing_photos/listing5/listing5_5.PNG"},
                        @"assets/listing_photos/listing5/listing5_map.PNG"),
                    45, 4, basePins[3], 103, 321),
                new ListingPin(
                    new Listing(46, "Rent", "Duplex",
                        "4403 19 Ave NW", "This beautiful newly constructed duplex features plenty of space, an open concept floor plan and shared access to a fenced backyard.",
                        "2400 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        2200, 5, 6,
                        false, false, false, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing6/listing6_exterior.PNG",
                            @"assets/listing_photos/listing6/listing6_1.PNG",
                            @"assets/listing_photos/listing6/listing6_2.PNG",
                            @"assets/listing_photos/listing6/listing6_3.PNG",
                            @"assets/listing_photos/listing6/listing6_4.PNG",
                            @"assets/listing_photos/listing6/listing6_5.PNG"},
                        @"assets/listing_photos/listing6/listing6_map.PNG"),
                    46, 4, basePins[3], -287, 153),
                new ListingPin(
                    new Listing(47, "Buy", "Condo",
                        "3114 34 Avenue NW", "This condo is in a prime location. Easy comute to downtown and a great view of the Rocky Mountains. Beautiful hardwood floors throughout.",
                        "860 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        550000, 3, 2.5,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing7/listing7_exterior.PNG",
                            @"assets/listing_photos/listing7/listing7_1.PNG",
                            @"assets/listing_photos/listing7/listing7_2.PNG",
                            @"assets/listing_photos/listing7/listing7_3.PNG",
                            @"assets/listing_photos/listing7/listing7_4.PNG",
                            @"assets/listing_photos/listing7/listing7_5.PNG"},
                        @"assets/listing_photos/listing7/listing7_map.PNG"),
                    47, 4, basePins[3], 25, -105),
                new ListingPin(
                    new Listing(48, "Rent", "House",
                        "3997 Varsity Drive NW", "Beautiful and fully renovated home featuring gas range and stainless appliances and granite countertops.",
                        "2650 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        5500, 6, 5.5,
                        false, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing8/listing8_exterior.PNG",
                            @"assets/listing_photos/listing8/listing8_1.PNG",
                            @"assets/listing_photos/listing8/listing8_2.PNG",
                            @"assets/listing_photos/listing8/listing8_3.PNG",
                            @"assets/listing_photos/listing8/listing8_4.PNG",
                            @"assets/listing_photos/listing8/listing8_5.PNG"},
                        @"assets/listing_photos/listing8/listing8_map.PNG"),
                    48, 4, basePins[3], -180, -257),
                new ListingPin(
                    new Listing(49, "Buy", "House",
                        "4415 Bulyea Road NW", "This beautifully designed home feels like it is almost brand new. The ultimate location and over 4,000 sq ft of the finest finishes come together in this luxury infill. Gorgeous curved staircase, modern fixtures, built-in cabinets, 2 gas fireplaces & a culinary dream kitchen with dark stained maple cabinets, stainless steel appliances and granite counters are only a few of the many features of this home.",
                        "4500 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        1850000, 6, 6,
                        true, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing9/listing9_exterior.PNG",
                            @"assets/listing_photos/listing9/listing9_1.PNG",
                            @"assets/listing_photos/listing9/listing9_2.PNG",
                            @"assets/listing_photos/listing9/listing9_3.PNG",
                            @"assets/listing_photos/listing9/listing9_4.PNG",
                            @"assets/listing_photos/listing9/listing9_5.PNG"},
                        @"assets/listing_photos/listing9/listing9_map.PNG"),
                    49, 4, basePins[3], -66, -292),
                new ListingPin(
                    new Listing(50, "Buy", "Apartment",
                        "4020 Vance Pl NW", "This Penthouse apartment has full unobstructed city views with a commanding nighttime view where you will want to leave the drapes open. Kitchen and living room with rift cut oak cabinets built-in with feature wall, gas fireplace, and nook area.",
                        "2650 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        1125000, 4, 4,
                        true, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing10/listing10_exterior.PNG",
                            @"assets/listing_photos/listing10/listing10_1.PNG",
                            @"assets/listing_photos/listing10/listing10_2.PNG",
                            @"assets/listing_photos/listing10/listing10_3.PNG",
                            @"assets/listing_photos/listing10/listing10_4.PNG",
                            @"assets/listing_photos/listing10/listing10_5.PNG"},
                        @"assets/listing_photos/listing10/listing10_map.PNG"),
                    50, 4, basePins[3], 178, 284),
                #endregion

                #region Listing Pins for Base Pin 5
                // listing pins for base pin 5
                new ListingPin(
                    new Listing(51, "Rent", "Apartment",
                        "3830 Brentwood Road NW", "This cozy 1200 sq ft apartment features stainless steel appliances, in suite laundry and floor to ceiling windows that have a fantastic west facing mountain view.",
                        "1200 square feet", "Gary Smith: (403)655-4763 gsmith@ReMacks.com",
                        1800, 2, 2,
                        true, false, true, true, false, false, false,
                        new List<string> {
                            @"assets/listing_photos/listing1/listing1_exterior.PNG",
                            @"assets/listing_photos/listing1/listing1_1.PNG",
                            @"assets/listing_photos/listing1/listing1_2.PNG",
                            @"assets/listing_photos/listing1/listing1_3.PNG",
                            @"assets/listing_photos/listing1/listing1_4.PNG",
                            @"assets/listing_photos/listing1/listing1_5.PNG"},
                        @"assets/listing_photos/listing1/listing1_map.PNG"),
                    51, 5, basePins[4], 30, -174),
                new ListingPin(
                    new Listing(52, "Buy", "House",
                        "3279 Underhill Dr NW", "A recently remodeled 2 story home featuring a 2 car garage, large fenced back yard and new kitchen appliances.",
                        "2400 square feet", "Gary Smith: (403)655-4763 gsmith@ReMacks.com",
                        345000, 3, 2.5,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing2/listing2_exterior.PNG",
                            @"assets/listing_photos/listing2/listing2_1.PNG",
                            @"assets/listing_photos/listing2/listing2_2.PNG",
                            @"assets/listing_photos/listing2/listing2_3.PNG",
                            @"assets/listing_photos/listing2/listing2_4.PNG",
                            @"assets/listing_photos/listing2/listing2_5.PNG"},
                        @"assets/listing_photos/listing2/listing2_map.PNG"),
                    52, 5, basePins[4], -17, 108),
                 new ListingPin(
                    new Listing(53, "Rent", "Townhouse",
                        "3215 Morley Trail NW", "This 2 story townhouse in a prime location features newly remodled bathrooms and a private entrance.",
                        "1800 square feet", "Mary Smyth: (403)655-6347 msmyth@ReMacks.com",
                        1400, 2, 1.5,
                        false, false, false, false, false, false, true,
                        new List<string> {
                            @"assets/listing_photos/listing3/listing3_exterior.PNG",
                            @"assets/listing_photos/listing3/listing3_1.PNG",
                            @"assets/listing_photos/listing3/listing3_2.PNG",
                            @"assets/listing_photos/listing3/listing3_3.PNG",
                            @"assets/listing_photos/listing3/listing3_4.PNG",
                            @"assets/listing_photos/listing3/listing3_5.PNG"},
                        @"assets/listing_photos/listing3/listing3_map.PNG"),
                    53, 5, basePins[4], 158, -37),
                new ListingPin(
                    new Listing(54, "Buy", "Condo",
                        "12 Varmoor Pl NW", "Condo in great neighbourhood with large fenced backyard, reserved street parking and a spacious kitchen.",
                        "2000 square feet", "Mary Smyth: (403)655-6347 msmyth@ReMacks.com",
                        125000, 4, 4,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing4/listing4_exterior.PNG",
                            @"assets/listing_photos/listing4/listing4_1.PNG",
                            @"assets/listing_photos/listing4/listing4_2.PNG",
                            @"assets/listing_photos/listing4/listing4_3.PNG",
                            @"assets/listing_photos/listing4/listing4_4.PNG",
                            @"assets/listing_photos/listing4/listing4_5.PNG"},
                        @"assets/listing_photos/listing4/listing4_map.PNG"),
                    54, 5, basePins[4], -135, -73),
                new ListingPin(
                    new Listing(55, "Rent", "Loft",
                        "1116 Windsor St NW", "This cozy loft features a private entrance and it's own kitchen with new appliances.",
                        "600 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        800, 1, 1,
                        true, true, true, true, true, true, false,
                        new List<string> {
                            @"assets/listing_photos/listing5/listing5_exterior.PNG",
                            @"assets/listing_photos/listing5/listing5_1.PNG",
                            @"assets/listing_photos/listing5/listing5_2.PNG",
                            @"assets/listing_photos/listing5/listing5_3.PNG",
                            @"assets/listing_photos/listing5/listing5_4.PNG",
                            @"assets/listing_photos/listing5/listing5_5.PNG"},
                        @"assets/listing_photos/listing5/listing5_map.PNG"),
                    55, 5, basePins[4], 103, 321),
                new ListingPin(
                    new Listing(56, "Rent", "Duplex",
                        "4403 19 Ave NW", "This beautiful newly constructed duplex features plenty of space, an open concept floor plan and shared access to a fenced backyard.",
                        "2400 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        2200, 5, 6,
                        false, false, false, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing6/listing6_exterior.PNG",
                            @"assets/listing_photos/listing6/listing6_1.PNG",
                            @"assets/listing_photos/listing6/listing6_2.PNG",
                            @"assets/listing_photos/listing6/listing6_3.PNG",
                            @"assets/listing_photos/listing6/listing6_4.PNG",
                            @"assets/listing_photos/listing6/listing6_5.PNG"},
                        @"assets/listing_photos/listing6/listing6_map.PNG"),
                    56, 5, basePins[4], -287, 153),
                new ListingPin(
                    new Listing(57, "Buy", "Condo",
                        "3114 34 Avenue NW", "This condo is in a prime location. Easy comute to downtown and a great view of the Rocky Mountains. Beautiful hardwood floors throughout.",
                        "860 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        550000, 3, 2.5,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing7/listing7_exterior.PNG",
                            @"assets/listing_photos/listing7/listing7_1.PNG",
                            @"assets/listing_photos/listing7/listing7_2.PNG",
                            @"assets/listing_photos/listing7/listing7_3.PNG",
                            @"assets/listing_photos/listing7/listing7_4.PNG",
                            @"assets/listing_photos/listing7/listing7_5.PNG"},
                        @"assets/listing_photos/listing7/listing7_map.PNG"),
                    57, 5, basePins[4], 25, -105),
                new ListingPin(
                    new Listing(58, "Rent", "House",
                        "3997 Varsity Drive NW", "Beautiful and fully renovated home featuring gas range and stainless appliances and granite countertops.",
                        "2650 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        5500, 6, 5.5,
                        false, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing8/listing8_exterior.PNG",
                            @"assets/listing_photos/listing8/listing8_1.PNG",
                            @"assets/listing_photos/listing8/listing8_2.PNG",
                            @"assets/listing_photos/listing8/listing8_3.PNG",
                            @"assets/listing_photos/listing8/listing8_4.PNG",
                            @"assets/listing_photos/listing8/listing8_5.PNG"},
                        @"assets/listing_photos/listing8/listing8_map.PNG"),
                    58, 5, basePins[4], -180, -257),
                new ListingPin(
                    new Listing(59, "Buy", "House",
                        "4415 Bulyea Road NW", "This beautifully designed home feels like it is almost brand new. The ultimate location and over 4,000 sq ft of the finest finishes come together in this luxury infill. Gorgeous curved staircase, modern fixtures, built-in cabinets, 2 gas fireplaces & a culinary dream kitchen with dark stained maple cabinets, stainless steel appliances and granite counters are only a few of the many features of this home.",
                        "4500 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        1850000, 6, 6,
                        true, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing9/listing9_exterior.PNG",
                            @"assets/listing_photos/listing9/listing9_1.PNG",
                            @"assets/listing_photos/listing9/listing9_2.PNG",
                            @"assets/listing_photos/listing9/listing9_3.PNG",
                            @"assets/listing_photos/listing9/listing9_4.PNG",
                            @"assets/listing_photos/listing9/listing9_5.PNG"},
                        @"assets/listing_photos/listing9/listing9_map.PNG"),
                    59, 5, basePins[4], -66, -292),
                new ListingPin(
                    new Listing(60, "Buy", "Apartment",
                        "4020 Vance Pl NW", "This Penthouse apartment has full unobstructed city views with a commanding nighttime view where you will want to leave the drapes open. Kitchen and living room with rift cut oak cabinets built-in with feature wall, gas fireplace, and nook area.",
                        "2650 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        1125000, 4, 4,
                        true, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing10/listing10_exterior.PNG",
                            @"assets/listing_photos/listing10/listing10_1.PNG",
                            @"assets/listing_photos/listing10/listing10_2.PNG",
                            @"assets/listing_photos/listing10/listing10_3.PNG",
                            @"assets/listing_photos/listing10/listing10_4.PNG",
                            @"assets/listing_photos/listing10/listing10_5.PNG"},
                        @"assets/listing_photos/listing10/listing10_map.PNG"),
                    60, 5, basePins[4], 178, 284),
                #endregion

                #region Listing Pins for Base Pin 6
                // listing pins for base pin 6
                new ListingPin(
                    new Listing(61, "Rent", "Apartment",
                        "3830 Brentwood Road NW", "This cozy 1200 sq ft apartment features stainless steel appliances, in suite laundry and floor to ceiling windows that have a fantastic west facing mountain view.",
                        "1200 square feet", "Gary Smith: (403)655-4763 gsmith@ReMacks.com",
                        1800, 2, 2,
                        true, false, true, true, false, false, false,
                        new List<string> {
                            @"assets/listing_photos/listing1/listing1_exterior.PNG",
                            @"assets/listing_photos/listing1/listing1_1.PNG",
                            @"assets/listing_photos/listing1/listing1_2.PNG",
                            @"assets/listing_photos/listing1/listing1_3.PNG",
                            @"assets/listing_photos/listing1/listing1_4.PNG",
                            @"assets/listing_photos/listing1/listing1_5.PNG"},
                        @"assets/listing_photos/listing1/listing1_map.PNG"),
                    61, 6, basePins[5], 30, -174),
                new ListingPin(
                    new Listing(62, "Buy", "House",
                        "3279 Underhill Dr NW", "A recently remodeled 2 story home featuring a 2 car garage, large fenced back yard and new kitchen appliances.",
                        "2400 square feet", "Gary Smith: (403)655-4763 gsmith@ReMacks.com",
                        345000, 3, 2.5,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing2/listing2_exterior.PNG",
                            @"assets/listing_photos/listing2/listing2_1.PNG",
                            @"assets/listing_photos/listing2/listing2_2.PNG",
                            @"assets/listing_photos/listing2/listing2_3.PNG",
                            @"assets/listing_photos/listing2/listing2_4.PNG",
                            @"assets/listing_photos/listing2/listing2_5.PNG"},
                        @"assets/listing_photos/listing2/listing2_map.PNG"),
                    62, 6, basePins[5], -17, 108),
                 new ListingPin(
                    new Listing(63, "Rent", "Townhouse",
                        "3215 Morley Trail NW", "This 2 story townhouse in a prime location features newly remodled bathrooms and a private entrance.",
                        "1800 square feet", "Mary Smyth: (403)655-6347 msmyth@ReMacks.com",
                        1400, 2, 1.5,
                        false, false, false, false, false, false, true,
                        new List<string> {
                            @"assets/listing_photos/listing3/listing3_exterior.PNG",
                            @"assets/listing_photos/listing3/listing3_1.PNG",
                            @"assets/listing_photos/listing3/listing3_2.PNG",
                            @"assets/listing_photos/listing3/listing3_3.PNG",
                            @"assets/listing_photos/listing3/listing3_4.PNG",
                            @"assets/listing_photos/listing3/listing3_5.PNG"},
                        @"assets/listing_photos/listing3/listing3_map.PNG"),
                    63, 6, basePins[5], 158, -37),
                new ListingPin(
                    new Listing(64, "Buy", "Condo",
                        "12 Varmoor Pl NW", "Condo in great neighbourhood with large fenced backyard, reserved street parking and a spacious kitchen.",
                        "2000 square feet", "Mary Smyth: (403)655-6347 msmyth@ReMacks.com",
                        125000, 4, 4,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing4/listing4_exterior.PNG",
                            @"assets/listing_photos/listing4/listing4_1.PNG",
                            @"assets/listing_photos/listing4/listing4_2.PNG",
                            @"assets/listing_photos/listing4/listing4_3.PNG",
                            @"assets/listing_photos/listing4/listing4_4.PNG",
                            @"assets/listing_photos/listing4/listing4_5.PNG"},
                        @"assets/listing_photos/listing4/listing4_map.PNG"),
                    64, 6, basePins[5], -135, -73),
                new ListingPin(
                    new Listing(65, "Rent", "Loft",
                        "1116 Windsor St NW", "This cozy loft features a private entrance and it's own kitchen with new appliances.",
                        "600 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        800, 1, 1,
                        true, true, true, true, true, true, false,
                        new List<string> {
                            @"assets/listing_photos/listing5/listing5_exterior.PNG",
                            @"assets/listing_photos/listing5/listing5_1.PNG",
                            @"assets/listing_photos/listing5/listing5_2.PNG",
                            @"assets/listing_photos/listing5/listing5_3.PNG",
                            @"assets/listing_photos/listing5/listing5_4.PNG",
                            @"assets/listing_photos/listing5/listing5_5.PNG"},
                        @"assets/listing_photos/listing5/listing5_map.PNG"),
                    65, 6, basePins[5], 103, 321),
                new ListingPin(
                    new Listing(66, "Rent", "Duplex",
                        "4403 19 Ave NW", "This beautiful newly constructed duplex features plenty of space, an open concept floor plan and shared access to a fenced backyard.",
                        "2400 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        2200, 5, 6,
                        false, false, false, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing6/listing6_exterior.PNG",
                            @"assets/listing_photos/listing6/listing6_1.PNG",
                            @"assets/listing_photos/listing6/listing6_2.PNG",
                            @"assets/listing_photos/listing6/listing6_3.PNG",
                            @"assets/listing_photos/listing6/listing6_4.PNG",
                            @"assets/listing_photos/listing6/listing6_5.PNG"},
                        @"assets/listing_photos/listing6/listing6_map.PNG"),
                    66, 6, basePins[5], -287, 153),
                new ListingPin(
                    new Listing(67, "Buy", "Condo",
                        "3114 34 Avenue NW", "This condo is in a prime location. Easy comute to downtown and a great view of the Rocky Mountains. Beautiful hardwood floors throughout.",
                        "860 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        550000, 3, 2.5,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing7/listing7_exterior.PNG",
                            @"assets/listing_photos/listing7/listing7_1.PNG",
                            @"assets/listing_photos/listing7/listing7_2.PNG",
                            @"assets/listing_photos/listing7/listing7_3.PNG",
                            @"assets/listing_photos/listing7/listing7_4.PNG",
                            @"assets/listing_photos/listing7/listing7_5.PNG"},
                        @"assets/listing_photos/listing7/listing7_map.PNG"),
                    67, 6, basePins[5], 25, -105),
                new ListingPin(
                    new Listing(68, "Rent", "House",
                        "3997 Varsity Drive NW", "Beautiful and fully renovated home featuring gas range and stainless appliances and granite countertops.",
                        "2650 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        5500, 6, 5.5,
                        false, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing8/listing8_exterior.PNG",
                            @"assets/listing_photos/listing8/listing8_1.PNG",
                            @"assets/listing_photos/listing8/listing8_2.PNG",
                            @"assets/listing_photos/listing8/listing8_3.PNG",
                            @"assets/listing_photos/listing8/listing8_4.PNG",
                            @"assets/listing_photos/listing8/listing8_5.PNG"},
                        @"assets/listing_photos/listing8/listing8_map.PNG"),
                    68, 6, basePins[5], -180, -257),
                new ListingPin(
                    new Listing(69, "Buy", "House",
                        "4415 Bulyea Road NW", "This beautifully designed home feels like it is almost brand new. The ultimate location and over 4,000 sq ft of the finest finishes come together in this luxury infill. Gorgeous curved staircase, modern fixtures, built-in cabinets, 2 gas fireplaces & a culinary dream kitchen with dark stained maple cabinets, stainless steel appliances and granite counters are only a few of the many features of this home.",
                        "4500 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        1850000, 6, 6,
                        true, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing9/listing9_exterior.PNG",
                            @"assets/listing_photos/listing9/listing9_1.PNG",
                            @"assets/listing_photos/listing9/listing9_2.PNG",
                            @"assets/listing_photos/listing9/listing9_3.PNG",
                            @"assets/listing_photos/listing9/listing9_4.PNG",
                            @"assets/listing_photos/listing9/listing9_5.PNG"},
                        @"assets/listing_photos/listing9/listing9_map.PNG"),
                    69, 6, basePins[5], -66, -292),
                new ListingPin(
                    new Listing(70, "Buy", "Apartment",
                        "4020 Vance Pl NW", "This Penthouse apartment has full unobstructed city views with a commanding nighttime view where you will want to leave the drapes open. Kitchen and living room with rift cut oak cabinets built-in with feature wall, gas fireplace, and nook area.",
                        "2650 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        1125000, 4, 4,
                        true, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing10/listing10_exterior.PNG",
                            @"assets/listing_photos/listing10/listing10_1.PNG",
                            @"assets/listing_photos/listing10/listing10_2.PNG",
                            @"assets/listing_photos/listing10/listing10_3.PNG",
                            @"assets/listing_photos/listing10/listing10_4.PNG",
                            @"assets/listing_photos/listing10/listing10_5.PNG"},
                        @"assets/listing_photos/listing10/listing10_map.PNG"),
                    70, 6, basePins[5], 178, 284),
                #endregion

                #region Listing Pins for Base Pin 7
                // listing pins for base pin 7
                new ListingPin(
                    new Listing(71, "Rent", "Apartment",
                        "3830 Brentwood Road NW", "This cozy 1200 sq ft apartment features stainless steel appliances, in suite laundry and floor to ceiling windows that have a fantastic west facing mountain view.",
                        "1200 square feet", "Gary Smith: (403)655-4763 gsmith@ReMacks.com",
                        1800, 2, 2,
                        true, false, true, true, false, false, false,
                        new List<string> {
                            @"assets/listing_photos/listing1/listing1_exterior.PNG",
                            @"assets/listing_photos/listing1/listing1_1.PNG",
                            @"assets/listing_photos/listing1/listing1_2.PNG",
                            @"assets/listing_photos/listing1/listing1_3.PNG",
                            @"assets/listing_photos/listing1/listing1_4.PNG",
                            @"assets/listing_photos/listing1/listing1_5.PNG"},
                        @"assets/listing_photos/listing1/listing1_map.PNG"),
                    71, 7, basePins[6], 30, -174),
                new ListingPin(
                    new Listing(72, "Buy", "House",
                        "3279 Underhill Dr NW", "A recently remodeled 2 story home featuring a 2 car garage, large fenced back yard and new kitchen appliances.",
                        "2400 square feet", "Gary Smith: (403)655-4763 gsmith@ReMacks.com",
                        345000, 3, 2.5,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing2/listing2_exterior.PNG",
                            @"assets/listing_photos/listing2/listing2_1.PNG",
                            @"assets/listing_photos/listing2/listing2_2.PNG",
                            @"assets/listing_photos/listing2/listing2_3.PNG",
                            @"assets/listing_photos/listing2/listing2_4.PNG",
                            @"assets/listing_photos/listing2/listing2_5.PNG"},
                        @"assets/listing_photos/listing2/listing2_map.PNG"),
                    72, 7, basePins[6], -17, 108),
                 new ListingPin(
                    new Listing(73, "Rent", "Townhouse",
                        "3215 Morley Trail NW", "This 2 story townhouse in a prime location features newly remodled bathrooms and a private entrance.",
                        "1800 square feet", "Mary Smyth: (403)655-6347 msmyth@ReMacks.com",
                        1400, 2, 1.5,
                        false, false, false, false, false, false, true,
                        new List<string> {
                            @"assets/listing_photos/listing3/listing3_exterior.PNG",
                            @"assets/listing_photos/listing3/listing3_1.PNG",
                            @"assets/listing_photos/listing3/listing3_2.PNG",
                            @"assets/listing_photos/listing3/listing3_3.PNG",
                            @"assets/listing_photos/listing3/listing3_4.PNG",
                            @"assets/listing_photos/listing3/listing3_5.PNG"},
                        @"assets/listing_photos/listing3/listing3_map.PNG"),
                    73, 7, basePins[6], 158, -37),
                new ListingPin(
                    new Listing(74, "Buy", "Condo",
                        "12 Varmoor Pl NW", "Condo in great neighbourhood with large fenced backyard, reserved street parking and a spacious kitchen.",
                        "2000 square feet", "Mary Smyth: (403)655-6347 msmyth@ReMacks.com",
                        125000, 4, 4,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing4/listing4_exterior.PNG",
                            @"assets/listing_photos/listing4/listing4_1.PNG",
                            @"assets/listing_photos/listing4/listing4_2.PNG",
                            @"assets/listing_photos/listing4/listing4_3.PNG",
                            @"assets/listing_photos/listing4/listing4_4.PNG",
                            @"assets/listing_photos/listing4/listing4_5.PNG"},
                        @"assets/listing_photos/listing4/listing4_map.PNG"),
                    74, 7, basePins[6], -135, -73),
                new ListingPin(
                    new Listing(75, "Rent", "Loft",
                        "1116 Windsor St NW", "This cozy loft features a private entrance and it's own kitchen with new appliances.",
                        "600 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        800, 1, 1,
                        true, true, true, true, true, true, false,
                        new List<string> {
                            @"assets/listing_photos/listing5/listing5_exterior.PNG",
                            @"assets/listing_photos/listing5/listing5_1.PNG",
                            @"assets/listing_photos/listing5/listing5_2.PNG",
                            @"assets/listing_photos/listing5/listing5_3.PNG",
                            @"assets/listing_photos/listing5/listing5_4.PNG",
                            @"assets/listing_photos/listing5/listing5_5.PNG"},
                        @"assets/listing_photos/listing5/listing5_map.PNG"),
                    75, 7, basePins[6], 103, 321),
                new ListingPin(
                    new Listing(76, "Rent", "Duplex",
                        "4403 19 Ave NW", "This beautiful newly constructed duplex features plenty of space, an open concept floor plan and shared access to a fenced backyard.",
                        "2400 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        2200, 5, 6,
                        false, false, false, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing6/listing6_exterior.PNG",
                            @"assets/listing_photos/listing6/listing6_1.PNG",
                            @"assets/listing_photos/listing6/listing6_2.PNG",
                            @"assets/listing_photos/listing6/listing6_3.PNG",
                            @"assets/listing_photos/listing6/listing6_4.PNG",
                            @"assets/listing_photos/listing6/listing6_5.PNG"},
                        @"assets/listing_photos/listing6/listing6_map.PNG"),
                    76, 7, basePins[6], -287, 153),
                new ListingPin(
                    new Listing(77, "Buy", "Condo",
                        "3114 34 Avenue NW", "This condo is in a prime location. Easy comute to downtown and a great view of the Rocky Mountains. Beautiful hardwood floors throughout.",
                        "860 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        550000, 3, 2.5,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing7/listing7_exterior.PNG",
                            @"assets/listing_photos/listing7/listing7_1.PNG",
                            @"assets/listing_photos/listing7/listing7_2.PNG",
                            @"assets/listing_photos/listing7/listing7_3.PNG",
                            @"assets/listing_photos/listing7/listing7_4.PNG",
                            @"assets/listing_photos/listing7/listing7_5.PNG"},
                        @"assets/listing_photos/listing7/listing7_map.PNG"),
                    77, 7, basePins[6], 25, -105),
                new ListingPin(
                    new Listing(78, "Rent", "House",
                        "3997 Varsity Drive NW", "Beautiful and fully renovated home featuring gas range and stainless appliances and granite countertops.",
                        "2650 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        5500, 6, 5.5,
                        false, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing8/listing8_exterior.PNG",
                            @"assets/listing_photos/listing8/listing8_1.PNG",
                            @"assets/listing_photos/listing8/listing8_2.PNG",
                            @"assets/listing_photos/listing8/listing8_3.PNG",
                            @"assets/listing_photos/listing8/listing8_4.PNG",
                            @"assets/listing_photos/listing8/listing8_5.PNG"},
                        @"assets/listing_photos/listing8/listing8_map.PNG"),
                    78, 7, basePins[6], -180, -257),
                new ListingPin(
                    new Listing(79, "Buy", "House",
                        "4415 Bulyea Road NW", "This beautifully designed home feels like it is almost brand new. The ultimate location and over 4,000 sq ft of the finest finishes come together in this luxury infill. Gorgeous curved staircase, modern fixtures, built-in cabinets, 2 gas fireplaces & a culinary dream kitchen with dark stained maple cabinets, stainless steel appliances and granite counters are only a few of the many features of this home.",
                        "4500 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        1850000, 6, 6,
                        true, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing9/listing9_exterior.PNG",
                            @"assets/listing_photos/listing9/listing9_1.PNG",
                            @"assets/listing_photos/listing9/listing9_2.PNG",
                            @"assets/listing_photos/listing9/listing9_3.PNG",
                            @"assets/listing_photos/listing9/listing9_4.PNG",
                            @"assets/listing_photos/listing9/listing9_5.PNG"},
                        @"assets/listing_photos/listing9/listing9_map.PNG"),
                    79, 7, basePins[6], -66, -292),
                new ListingPin(
                    new Listing(80, "Buy", "Apartment",
                        "4020 Vance Pl NW", "This Penthouse apartment has full unobstructed city views with a commanding nighttime view where you will want to leave the drapes open. Kitchen and living room with rift cut oak cabinets built-in with feature wall, gas fireplace, and nook area.",
                        "2650 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        1125000, 4, 4,
                        true, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing10/listing10_exterior.PNG",
                            @"assets/listing_photos/listing10/listing10_1.PNG",
                            @"assets/listing_photos/listing10/listing10_2.PNG",
                            @"assets/listing_photos/listing10/listing10_3.PNG",
                            @"assets/listing_photos/listing10/listing10_4.PNG",
                            @"assets/listing_photos/listing10/listing10_5.PNG"},
                        @"assets/listing_photos/listing10/listing10_map.PNG"),
                    80, 7, basePins[6], 178, 284),
                #endregion

                #region Listing Pins for Base Pin 8
                // listing pins for base pin 8
                new ListingPin(
                    new Listing(81, "Rent", "Apartment",
                        "3830 Brentwood Road NW", "This cozy 1200 sq ft apartment features stainless steel appliances, in suite laundry and floor to ceiling windows that have a fantastic west facing mountain view.",
                        "1200 square feet", "Gary Smith: (403)655-4763 gsmith@ReMacks.com",
                        1800, 2, 2,
                        true, false, true, true, false, false, false,
                        new List<string> {
                            @"assets/listing_photos/listing1/listing1_exterior.PNG",
                            @"assets/listing_photos/listing1/listing1_1.PNG",
                            @"assets/listing_photos/listing1/listing1_2.PNG",
                            @"assets/listing_photos/listing1/listing1_3.PNG",
                            @"assets/listing_photos/listing1/listing1_4.PNG",
                            @"assets/listing_photos/listing1/listing1_5.PNG"},
                        @"assets/listing_photos/listing1/listing1_map.PNG"),
                    81, 8, basePins[7], 30, -174),
                new ListingPin(
                    new Listing(82, "Buy", "House",
                        "3279 Underhill Dr NW", "A recently remodeled 2 story home featuring a 2 car garage, large fenced back yard and new kitchen appliances.",
                        "2400 square feet", "Gary Smith: (403)655-4763 gsmith@ReMacks.com",
                        345000, 3, 2.5,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing2/listing2_exterior.PNG",
                            @"assets/listing_photos/listing2/listing2_1.PNG",
                            @"assets/listing_photos/listing2/listing2_2.PNG",
                            @"assets/listing_photos/listing2/listing2_3.PNG",
                            @"assets/listing_photos/listing2/listing2_4.PNG",
                            @"assets/listing_photos/listing2/listing2_5.PNG"},
                        @"assets/listing_photos/listing2/listing2_map.PNG"),
                    82, 8, basePins[7], -17, 108),
                 new ListingPin(
                    new Listing(83, "Rent", "Townhouse",
                        "3215 Morley Trail NW", "This 2 story townhouse in a prime location features newly remodled bathrooms and a private entrance.",
                        "1800 square feet", "Mary Smyth: (403)655-6347 msmyth@ReMacks.com",
                        1400, 2, 1.5,
                        false, false, false, false, false, false, true,
                        new List<string> {
                            @"assets/listing_photos/listing3/listing3_exterior.PNG",
                            @"assets/listing_photos/listing3/listing3_1.PNG",
                            @"assets/listing_photos/listing3/listing3_2.PNG",
                            @"assets/listing_photos/listing3/listing3_3.PNG",
                            @"assets/listing_photos/listing3/listing3_4.PNG",
                            @"assets/listing_photos/listing3/listing3_5.PNG"},
                        @"assets/listing_photos/listing3/listing3_map.PNG"),
                    83, 8, basePins[7], 158, -37),
                new ListingPin(
                    new Listing(84, "Buy", "Condo",
                        "12 Varmoor Pl NW", "Condo in great neighbourhood with large fenced backyard, reserved street parking and a spacious kitchen.",
                        "2000 square feet", "Mary Smyth: (403)655-6347 msmyth@ReMacks.com",
                        125000, 4, 4,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing4/listing4_exterior.PNG",
                            @"assets/listing_photos/listing4/listing4_1.PNG",
                            @"assets/listing_photos/listing4/listing4_2.PNG",
                            @"assets/listing_photos/listing4/listing4_3.PNG",
                            @"assets/listing_photos/listing4/listing4_4.PNG",
                            @"assets/listing_photos/listing4/listing4_5.PNG"},
                        @"assets/listing_photos/listing4/listing4_map.PNG"),
                    84, 8, basePins[7], -135, -73),
                new ListingPin(
                    new Listing(85, "Rent", "Loft",
                        "1116 Windsor St NW", "This cozy loft features a private entrance and it's own kitchen with new appliances.",
                        "600 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        800, 1, 1,
                        true, true, true, true, true, true, false,
                        new List<string> {
                            @"assets/listing_photos/listing5/listing5_exterior.PNG",
                            @"assets/listing_photos/listing5/listing5_1.PNG",
                            @"assets/listing_photos/listing5/listing5_2.PNG",
                            @"assets/listing_photos/listing5/listing5_3.PNG",
                            @"assets/listing_photos/listing5/listing5_4.PNG",
                            @"assets/listing_photos/listing5/listing5_5.PNG"},
                        @"assets/listing_photos/listing5/listing5_map.PNG"),
                    85, 8, basePins[7], 103, 321),
                new ListingPin(
                    new Listing(86, "Rent", "Duplex",
                        "4403 19 Ave NW", "This beautiful newly constructed duplex features plenty of space, an open concept floor plan and shared access to a fenced backyard.",
                        "2400 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        2200, 5, 6,
                        false, false, false, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing6/listing6_exterior.PNG",
                            @"assets/listing_photos/listing6/listing6_1.PNG",
                            @"assets/listing_photos/listing6/listing6_2.PNG",
                            @"assets/listing_photos/listing6/listing6_3.PNG",
                            @"assets/listing_photos/listing6/listing6_4.PNG",
                            @"assets/listing_photos/listing6/listing6_5.PNG"},
                        @"assets/listing_photos/listing6/listing6_map.PNG"),
                    86, 8, basePins[7], -287, 153),
                new ListingPin(
                    new Listing(87, "Buy", "Condo",
                        "3114 34 Avenue NW", "This condo is in a prime location. Easy comute to downtown and a great view of the Rocky Mountains. Beautiful hardwood floors throughout.",
                        "860 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        550000, 3, 2.5,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing7/listing7_exterior.PNG",
                            @"assets/listing_photos/listing7/listing7_1.PNG",
                            @"assets/listing_photos/listing7/listing7_2.PNG",
                            @"assets/listing_photos/listing7/listing7_3.PNG",
                            @"assets/listing_photos/listing7/listing7_4.PNG",
                            @"assets/listing_photos/listing7/listing7_5.PNG"},
                        @"assets/listing_photos/listing7/listing7_map.PNG"),
                    87, 8, basePins[7], 25, -105),
                new ListingPin(
                    new Listing(88, "Rent", "House",
                        "3997 Varsity Drive NW", "Beautiful and fully renovated home featuring gas range and stainless appliances and granite countertops.",
                        "2650 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        5500, 6, 5.5,
                        false, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing8/listing8_exterior.PNG",
                            @"assets/listing_photos/listing8/listing8_1.PNG",
                            @"assets/listing_photos/listing8/listing8_2.PNG",
                            @"assets/listing_photos/listing8/listing8_3.PNG",
                            @"assets/listing_photos/listing8/listing8_4.PNG",
                            @"assets/listing_photos/listing8/listing8_5.PNG"},
                        @"assets/listing_photos/listing8/listing8_map.PNG"),
                    88, 8, basePins[7], -180, -257),
                new ListingPin(
                    new Listing(89, "Buy", "House",
                        "4415 Bulyea Road NW", "This beautifully designed home feels like it is almost brand new. The ultimate location and over 4,000 sq ft of the finest finishes come together in this luxury infill. Gorgeous curved staircase, modern fixtures, built-in cabinets, 2 gas fireplaces & a culinary dream kitchen with dark stained maple cabinets, stainless steel appliances and granite counters are only a few of the many features of this home.",
                        "4500 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        1850000, 6, 6,
                        true, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing9/listing9_exterior.PNG",
                            @"assets/listing_photos/listing9/listing9_1.PNG",
                            @"assets/listing_photos/listing9/listing9_2.PNG",
                            @"assets/listing_photos/listing9/listing9_3.PNG",
                            @"assets/listing_photos/listing9/listing9_4.PNG",
                            @"assets/listing_photos/listing9/listing9_5.PNG"},
                        @"assets/listing_photos/listing9/listing9_map.PNG"),
                    89, 8, basePins[7], -66, -292),
                new ListingPin(
                    new Listing(90, "Buy", "Apartment",
                        "4020 Vance Pl NW", "This Penthouse apartment has full unobstructed city views with a commanding nighttime view where you will want to leave the drapes open. Kitchen and living room with rift cut oak cabinets built-in with feature wall, gas fireplace, and nook area.",
                        "2650 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        1125000, 4, 4,
                        true, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing10/listing10_exterior.PNG",
                            @"assets/listing_photos/listing10/listing10_1.PNG",
                            @"assets/listing_photos/listing10/listing10_2.PNG",
                            @"assets/listing_photos/listing10/listing10_3.PNG",
                            @"assets/listing_photos/listing10/listing10_4.PNG",
                            @"assets/listing_photos/listing10/listing10_5.PNG"},
                        @"assets/listing_photos/listing10/listing10_map.PNG"),
                    90, 8, basePins[7], 178, 284),
                #endregion

                #region Listing Pins for Base Pin 9
                // listing pins for base pin 9
                new ListingPin(
                    new Listing(91, "Rent", "Apartment",
                        "3830 Brentwood Road NW", "This cozy 1200 sq ft apartment features stainless steel appliances, in suite laundry and floor to ceiling windows that have a fantastic west facing mountain view.",
                        "1200 square feet", "Gary Smith: (403)655-4763 gsmith@ReMacks.com",
                        1800, 2, 2,
                        true, false, true, true, false, false, false,
                        new List<string> {
                            @"assets/listing_photos/listing1/listing1_exterior.PNG",
                            @"assets/listing_photos/listing1/listing1_1.PNG",
                            @"assets/listing_photos/listing1/listing1_2.PNG",
                            @"assets/listing_photos/listing1/listing1_3.PNG",
                            @"assets/listing_photos/listing1/listing1_4.PNG",
                            @"assets/listing_photos/listing1/listing1_5.PNG"},
                        @"assets/listing_photos/listing1/listing1_map.PNG"),
                    91, 9, basePins[8], 30, -174),
                new ListingPin(
                    new Listing(92, "Buy", "House",
                        "3279 Underhill Dr NW", "A recently remodeled 2 story home featuring a 2 car garage, large fenced back yard and new kitchen appliances.",
                        "2400 square feet", "Gary Smith: (403)655-4763 gsmith@ReMacks.com",
                        345000, 3, 2.5,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing2/listing2_exterior.PNG",
                            @"assets/listing_photos/listing2/listing2_1.PNG",
                            @"assets/listing_photos/listing2/listing2_2.PNG",
                            @"assets/listing_photos/listing2/listing2_3.PNG",
                            @"assets/listing_photos/listing2/listing2_4.PNG",
                            @"assets/listing_photos/listing2/listing2_5.PNG"},
                        @"assets/listing_photos/listing2/listing2_map.PNG"),
                    92, 9, basePins[8], -17, 108),
                 new ListingPin(
                    new Listing(93, "Rent", "Townhouse",
                        "3215 Morley Trail NW", "This 2 story townhouse in a prime location features newly remodled bathrooms and a private entrance.",
                        "1800 square feet", "Mary Smyth: (403)655-6347 msmyth@ReMacks.com",
                        1400, 2, 1.5,
                        false, false, false, false, false, false, true,
                        new List<string> {
                            @"assets/listing_photos/listing3/listing3_exterior.PNG",
                            @"assets/listing_photos/listing3/listing3_1.PNG",
                            @"assets/listing_photos/listing3/listing3_2.PNG",
                            @"assets/listing_photos/listing3/listing3_3.PNG",
                            @"assets/listing_photos/listing3/listing3_4.PNG",
                            @"assets/listing_photos/listing3/listing3_5.PNG"},
                        @"assets/listing_photos/listing3/listing3_map.PNG"),
                    93, 9, basePins[8], 158, -37),
                new ListingPin(
                    new Listing(94, "Buy", "Condo",
                        "12 Varmoor Pl NW", "Condo in great neighbourhood with large fenced backyard, reserved street parking and a spacious kitchen.",
                        "2000 square feet", "Mary Smyth: (403)655-6347 msmyth@ReMacks.com",
                        125000, 4, 4,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing4/listing4_exterior.PNG",
                            @"assets/listing_photos/listing4/listing4_1.PNG",
                            @"assets/listing_photos/listing4/listing4_2.PNG",
                            @"assets/listing_photos/listing4/listing4_3.PNG",
                            @"assets/listing_photos/listing4/listing4_4.PNG",
                            @"assets/listing_photos/listing4/listing4_5.PNG"},
                        @"assets/listing_photos/listing4/listing4_map.PNG"),
                    94, 9, basePins[8], -135, -73),
                new ListingPin(
                    new Listing(95, "Rent", "Loft",
                        "1116 Windsor St NW", "This cozy loft features a private entrance and it's own kitchen with new appliances.",
                        "600 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        800, 1, 1,
                        true, true, true, true, true, true, false,
                        new List<string> {
                            @"assets/listing_photos/listing5/listing5_exterior.PNG",
                            @"assets/listing_photos/listing5/listing5_1.PNG",
                            @"assets/listing_photos/listing5/listing5_2.PNG",
                            @"assets/listing_photos/listing5/listing5_3.PNG",
                            @"assets/listing_photos/listing5/listing5_4.PNG",
                            @"assets/listing_photos/listing5/listing5_5.PNG"},
                        @"assets/listing_photos/listing5/listing5_map.PNG"),
                    95, 9, basePins[8], 103, 321),
                new ListingPin(
                    new Listing(96, "Rent", "Duplex",
                        "4403 19 Ave NW", "This beautiful newly constructed duplex features plenty of space, an open concept floor plan and shared access to a fenced backyard.",
                        "2400 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        2200, 5, 6,
                        false, false, false, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing6/listing6_exterior.PNG",
                            @"assets/listing_photos/listing6/listing6_1.PNG",
                            @"assets/listing_photos/listing6/listing6_2.PNG",
                            @"assets/listing_photos/listing6/listing6_3.PNG",
                            @"assets/listing_photos/listing6/listing6_4.PNG",
                            @"assets/listing_photos/listing6/listing6_5.PNG"},
                        @"assets/listing_photos/listing6/listing6_map.PNG"),
                    96, 9, basePins[8], -287, 153),
                new ListingPin(
                    new Listing(97, "Buy", "Condo",
                        "3114 34 Avenue NW", "This condo is in a prime location. Easy comute to downtown and a great view of the Rocky Mountains. Beautiful hardwood floors throughout.",
                        "860 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        550000, 3, 2.5,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing7/listing7_exterior.PNG",
                            @"assets/listing_photos/listing7/listing7_1.PNG",
                            @"assets/listing_photos/listing7/listing7_2.PNG",
                            @"assets/listing_photos/listing7/listing7_3.PNG",
                            @"assets/listing_photos/listing7/listing7_4.PNG",
                            @"assets/listing_photos/listing7/listing7_5.PNG"},
                        @"assets/listing_photos/listing7/listing7_map.PNG"),
                    97, 9, basePins[8], 25, -105),
                new ListingPin(
                    new Listing(98, "Rent", "House",
                        "3997 Varsity Drive NW", "Beautiful and fully renovated home featuring gas range and stainless appliances and granite countertops.",
                        "2650 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        5500, 6, 5.5,
                        false, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing8/listing8_exterior.PNG",
                            @"assets/listing_photos/listing8/listing8_1.PNG",
                            @"assets/listing_photos/listing8/listing8_2.PNG",
                            @"assets/listing_photos/listing8/listing8_3.PNG",
                            @"assets/listing_photos/listing8/listing8_4.PNG",
                            @"assets/listing_photos/listing8/listing8_5.PNG"},
                        @"assets/listing_photos/listing8/listing8_map.PNG"),
                    98, 9, basePins[8], -180, -257),
                new ListingPin(
                    new Listing(99, "Buy", "House",
                        "4415 Bulyea Road NW", "This beautifully designed home feels like it is almost brand new. The ultimate location and over 4,000 sq ft of the finest finishes come together in this luxury infill. Gorgeous curved staircase, modern fixtures, built-in cabinets, 2 gas fireplaces & a culinary dream kitchen with dark stained maple cabinets, stainless steel appliances and granite counters are only a few of the many features of this home.",
                        "4500 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        1850000, 6, 6,
                        true, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing9/listing9_exterior.PNG",
                            @"assets/listing_photos/listing9/listing9_1.PNG",
                            @"assets/listing_photos/listing9/listing9_2.PNG",
                            @"assets/listing_photos/listing9/listing9_3.PNG",
                            @"assets/listing_photos/listing9/listing9_4.PNG",
                            @"assets/listing_photos/listing9/listing9_5.PNG"},
                        @"assets/listing_photos/listing9/listing9_map.PNG"),
                    99, 9, basePins[8], -66, -292),
                new ListingPin(
                    new Listing(100, "Buy", "Apartment",
                        "4020 Vance Pl NW", "This Penthouse apartment has full unobstructed city views with a commanding nighttime view where you will want to leave the drapes open. Kitchen and living room with rift cut oak cabinets built-in with feature wall, gas fireplace, and nook area.",
                        "2650 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        1125000, 4, 4,
                        true, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing10/listing10_exterior.PNG",
                            @"assets/listing_photos/listing10/listing10_1.PNG",
                            @"assets/listing_photos/listing10/listing10_2.PNG",
                            @"assets/listing_photos/listing10/listing10_3.PNG",
                            @"assets/listing_photos/listing10/listing10_4.PNG",
                            @"assets/listing_photos/listing10/listing10_5.PNG"},
                        @"assets/listing_photos/listing10/listing10_map.PNG"),
                    100, 9, basePins[8], 178, 284),
                #endregion

                #region Listing Pins for Base Pin 10
                // listing pins for base pin 10
                new ListingPin(
                    new Listing(101, "Rent", "Apartment",
                        "3830 Brentwood Road NW", "This cozy 1200 sq ft apartment features stainless steel appliances, in suite laundry and floor to ceiling windows that have a fantastic west facing mountain view.",
                        "1200 square feet", "Gary Smith: (403)655-4763 gsmith@ReMacks.com",
                        1800, 2, 2,
                        true, false, true, true, false, false, false,
                        new List<string> {
                            @"assets/listing_photos/listing1/listing1_exterior.PNG",
                            @"assets/listing_photos/listing1/listing1_1.PNG",
                            @"assets/listing_photos/listing1/listing1_2.PNG",
                            @"assets/listing_photos/listing1/listing1_3.PNG",
                            @"assets/listing_photos/listing1/listing1_4.PNG",
                            @"assets/listing_photos/listing1/listing1_5.PNG"},
                        @"assets/listing_photos/listing1/listing1_map.PNG"),
                    101, 10, basePins[9], 30, -174),
                new ListingPin(
                    new Listing(102, "Buy", "House",
                        "3279 Underhill Dr NW", "A recently remodeled 2 story home featuring a 2 car garage, large fenced back yard and new kitchen appliances.",
                        "2400 square feet", "Gary Smith: (403)655-4763 gsmith@ReMacks.com",
                        345000, 3, 2.5,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing2/listing2_exterior.PNG",
                            @"assets/listing_photos/listing2/listing2_1.PNG",
                            @"assets/listing_photos/listing2/listing2_2.PNG",
                            @"assets/listing_photos/listing2/listing2_3.PNG",
                            @"assets/listing_photos/listing2/listing2_4.PNG",
                            @"assets/listing_photos/listing2/listing2_5.PNG"},
                        @"assets/listing_photos/listing2/listing2_map.PNG"),
                    102, 10, basePins[9], -17, 108),
                 new ListingPin(
                    new Listing(103, "Rent", "Townhouse",
                        "3215 Morley Trail NW", "This 2 story townhouse in a prime location features newly remodled bathrooms and a private entrance.",
                        "1800 square feet", "Mary Smyth: (403)655-6347 msmyth@ReMacks.com",
                        1400, 2, 1.5,
                        false, false, false, false, false, false, true,
                        new List<string> {
                            @"assets/listing_photos/listing3/listing3_exterior.PNG",
                            @"assets/listing_photos/listing3/listing3_1.PNG",
                            @"assets/listing_photos/listing3/listing3_2.PNG",
                            @"assets/listing_photos/listing3/listing3_3.PNG",
                            @"assets/listing_photos/listing3/listing3_4.PNG",
                            @"assets/listing_photos/listing3/listing3_5.PNG"},
                        @"assets/listing_photos/listing3/listing3_map.PNG"),
                    103, 10, basePins[9], 158, -37),
                new ListingPin(
                    new Listing(104, "Buy", "Condo",
                        "12 Varmoor Pl NW", "Condo in great neighbourhood with large fenced backyard, reserved street parking and a spacious kitchen.",
                        "2000 square feet", "Mary Smyth: (403)655-6347 msmyth@ReMacks.com",
                        125000, 4, 4,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing4/listing4_exterior.PNG",
                            @"assets/listing_photos/listing4/listing4_1.PNG",
                            @"assets/listing_photos/listing4/listing4_2.PNG",
                            @"assets/listing_photos/listing4/listing4_3.PNG",
                            @"assets/listing_photos/listing4/listing4_4.PNG",
                            @"assets/listing_photos/listing4/listing4_5.PNG"},
                        @"assets/listing_photos/listing4/listing4_map.PNG"),
                    104, 10, basePins[9], -135, -73),
                new ListingPin(
                    new Listing(105, "Rent", "Loft",
                        "1116 Windsor St NW", "This cozy loft features a private entrance and it's own kitchen with new appliances.",
                        "600 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        800, 1, 1,
                        true, true, true, true, true, true, false,
                        new List<string> {
                            @"assets/listing_photos/listing5/listing5_exterior.PNG",
                            @"assets/listing_photos/listing5/listing5_1.PNG",
                            @"assets/listing_photos/listing5/listing5_2.PNG",
                            @"assets/listing_photos/listing5/listing5_3.PNG",
                            @"assets/listing_photos/listing5/listing5_4.PNG",
                            @"assets/listing_photos/listing5/listing5_5.PNG"},
                        @"assets/listing_photos/listing5/listing5_map.PNG"),
                    105, 10, basePins[9], 103, 321),
                new ListingPin(
                    new Listing(106, "Rent", "Duplex",
                        "4403 19 Ave NW", "This beautiful newly constructed duplex features plenty of space, an open concept floor plan and shared access to a fenced backyard.",
                        "2400 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        2200, 5, 6,
                        false, false, false, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing6/listing6_exterior.PNG",
                            @"assets/listing_photos/listing6/listing6_1.PNG",
                            @"assets/listing_photos/listing6/listing6_2.PNG",
                            @"assets/listing_photos/listing6/listing6_3.PNG",
                            @"assets/listing_photos/listing6/listing6_4.PNG",
                            @"assets/listing_photos/listing6/listing6_5.PNG"},
                        @"assets/listing_photos/listing6/listing6_map.PNG"),
                    106, 10, basePins[9], -287, 153),
                new ListingPin(
                    new Listing(107, "Buy", "Condo",
                        "3114 34 Avenue NW", "This condo is in a prime location. Easy comute to downtown and a great view of the Rocky Mountains. Beautiful hardwood floors throughout.",
                        "860 square feet", "Andrea Sesame: (403)655-3674 asesame@ReMacks.com",
                        550000, 3, 2.5,
                        true, true, true, true, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing7/listing7_exterior.PNG",
                            @"assets/listing_photos/listing7/listing7_1.PNG",
                            @"assets/listing_photos/listing7/listing7_2.PNG",
                            @"assets/listing_photos/listing7/listing7_3.PNG",
                            @"assets/listing_photos/listing7/listing7_4.PNG",
                            @"assets/listing_photos/listing7/listing7_5.PNG"},
                        @"assets/listing_photos/listing7/listing7_map.PNG"),
                    107, 10, basePins[9], 25, -105),
                new ListingPin(
                    new Listing(108, "Rent", "House",
                        "3997 Varsity Drive NW", "Beautiful and fully renovated home featuring gas range and stainless appliances and granite countertops.",
                        "2650 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        5500, 6, 5.5,
                        false, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing8/listing8_exterior.PNG",
                            @"assets/listing_photos/listing8/listing8_1.PNG",
                            @"assets/listing_photos/listing8/listing8_2.PNG",
                            @"assets/listing_photos/listing8/listing8_3.PNG",
                            @"assets/listing_photos/listing8/listing8_4.PNG",
                            @"assets/listing_photos/listing8/listing8_5.PNG"},
                        @"assets/listing_photos/listing8/listing8_map.PNG"),
                    108, 10, basePins[9], -180, -257),
                new ListingPin(
                    new Listing(109, "Buy", "House",
                        "4415 Bulyea Road NW", "This beautifully designed home feels like it is almost brand new. The ultimate location and over 4,000 sq ft of the finest finishes come together in this luxury infill. Gorgeous curved staircase, modern fixtures, built-in cabinets, 2 gas fireplaces & a culinary dream kitchen with dark stained maple cabinets, stainless steel appliances and granite counters are only a few of the many features of this home.",
                        "4500 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        1850000, 6, 6,
                        true, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing9/listing9_exterior.PNG",
                            @"assets/listing_photos/listing9/listing9_1.PNG",
                            @"assets/listing_photos/listing9/listing9_2.PNG",
                            @"assets/listing_photos/listing9/listing9_3.PNG",
                            @"assets/listing_photos/listing9/listing9_4.PNG",
                            @"assets/listing_photos/listing9/listing9_5.PNG"},
                        @"assets/listing_photos/listing9/listing9_map.PNG"),
                    109, 10, basePins[9], -66, -292),
                new ListingPin(
                    new Listing(110, "Buy", "Apartment",
                        "4020 Vance Pl NW", "This Penthouse apartment has full unobstructed city views with a commanding nighttime view where you will want to leave the drapes open. Kitchen and living room with rift cut oak cabinets built-in with feature wall, gas fireplace, and nook area.",
                        "2650 square feet", "Raymond Richard: (403)655-3666 rrichard@ReMacks.com",
                        1125000, 4, 4,
                        true, true, true, false, true, true, true,
                        new List<string> {
                            @"assets/listing_photos/listing10/listing10_exterior.PNG",
                            @"assets/listing_photos/listing10/listing10_1.PNG",
                            @"assets/listing_photos/listing10/listing10_2.PNG",
                            @"assets/listing_photos/listing10/listing10_3.PNG",
                            @"assets/listing_photos/listing10/listing10_4.PNG",
                            @"assets/listing_photos/listing10/listing10_5.PNG"},
                        @"assets/listing_photos/listing10/listing10_map.PNG"),
                    110, 10, basePins[9], 178, 284),
                #endregion
            };

            pins.AddRange(listingPins);
            #endregion
        }

        public static void RefreshPins(bool savedListings)
        {
            foreach (Pin pin in pins)
            {
                pin.ShowPin(savedListings);
            }
        }
    }
}
