using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace realestatefinder
{
    public class Listing
    {
        // Identifiers used to position the pin on the map
        public int ID;
        public double ProxToBasePin;

        // String based filters
        public String BuyOrRent;
        public String Type;

        // strings that describe the pin/listing
        public String Address;
        public String Description;
        public String Size;
        public String RealtorContactInfo;

        // int based filters
        public int Price;
        public int Beds;
        public double Baths;

        // bool based filters
        public bool HeatIncluded;
        public bool ElectricityIncluded;
        public bool ParkingIncluded;
        public bool WaterIncluded;
        public bool InternetIncluded;
        public bool TelevisionIncluded;
        public bool PetFriendly;
        public bool Saved = false;

        public List<String> Images;
        public string MapImage;

        public Listing(int id, String buyorrent, String type, String address, 
            String description, String size, String realtorinfo, int price, int beds, double baths, 
            bool heat, bool electric, bool parking, bool water, bool internet, bool tv, bool pets, List<String> images, string map)
        {
            ID = id;
            BuyOrRent = buyorrent;
            Type = type;
            Address = address;
            Description = description;
            Size = size;
            RealtorContactInfo = realtorinfo;
            Price = price;
            Beds = beds;
            Baths = baths;
            HeatIncluded = heat;
            ElectricityIncluded = electric;
            ParkingIncluded = parking;
            WaterIncluded = water;
            InternetIncluded = internet;
            TelevisionIncluded = tv;
            PetFriendly = pets;
            Images = images;
            MapImage = map;
        }
    }
}
