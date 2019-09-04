using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace realestatefinder
{
    public static class Filters
    {
        public static Dictionary<String, object> FilterDict = new Dictionary<String, object>();
        public static Dictionary<String, Action<object>> ObserverDict = new Dictionary<String, Action<object>>();

        public static void InitializeFilters(SavableFilters s)
        {
            if (s == null)
            {
                FilterDict.Add("ShowStartPage", false);

                FilterDict.Add("Address", "");

                FilterDict.Add("Buy", true);
                FilterDict.Add("Rent", true);

                FilterDict.Add("House", true);
                FilterDict.Add("Townhouse", true);
                FilterDict.Add("Apartment", true);
                FilterDict.Add("Condo", true);
                FilterDict.Add("Loft", true);
                FilterDict.Add("Duplex", true);

                FilterDict.Add("Water", false);
                FilterDict.Add("Electricity", false);
                FilterDict.Add("Heat", false);
                FilterDict.Add("Internet", false);
                FilterDict.Add("Parking", false);
                FilterDict.Add("Television", false);

                FilterDict.Add("RentMax", 6000);
                FilterDict.Add("BuyMax", 2000000);
                FilterDict.Add("BathsMin", 0);
                FilterDict.Add("BedsMin", 0);
                FilterDict.Add("AddressProx", 3);
            }
            else
            {
                SetFilter("Address", s.FilterDict["Address"].ToString());

                SetFilter("Buy", Convert.ToBoolean(s.FilterDict["Buy"]));
                SetFilter("Rent", Convert.ToBoolean(s.FilterDict["Rent"]));

                SetFilter("House", Convert.ToBoolean(s.FilterDict["House"]));
                SetFilter("Townhouse", Convert.ToBoolean(s.FilterDict["Townhouse"]));
                SetFilter("Apartment", Convert.ToBoolean(s.FilterDict["Apartment"]));
                SetFilter("Condo", Convert.ToBoolean(s.FilterDict["Condo"]));
                SetFilter("Loft", Convert.ToBoolean(s.FilterDict["Loft"]));
                SetFilter("Duplex", Convert.ToBoolean(s.FilterDict["Duplex"]));

                SetFilter("Water", Convert.ToBoolean(s.FilterDict["Water"]));
                SetFilter("Electricity", Convert.ToBoolean(s.FilterDict["Electricity"]));
                SetFilter("Heat", Convert.ToBoolean(s.FilterDict["Heat"]));
                SetFilter("Internet", Convert.ToBoolean(s.FilterDict["Internet"]));
                SetFilter("Parking", Convert.ToBoolean(s.FilterDict["Parking"]));
                SetFilter("Television", Convert.ToBoolean(s.FilterDict["Television"]));

                SetFilter("RentMax", Convert.ToInt32(s.FilterDict["RentMax"]));
                SetFilter("BuyMax", Convert.ToInt32(s.FilterDict["BuyMax"]));
                SetFilter("BathsMin", Convert.ToDouble(s.FilterDict["BathsMin"]));
                SetFilter("BedsMin", Convert.ToInt32(s.FilterDict["BedsMin"]));
                SetFilter("AddressProx", Convert.ToInt32(s.FilterDict["AddressProx"]));
            }
            
        }

        public static void SetFilter(string name, object value)
        {
            FilterDict[name] = value;
            ObserverDict[name].Invoke(value);
        }

        public static Boolean ShowBuy()
        {
            bool Buy = (bool)FilterDict["Buy"];
            bool Rent = (bool)FilterDict["Rent"];
            return Buy ? (Buy && !Rent) : false;
        }

        public static Boolean ShowRent()
        {
            bool Buy = (bool)FilterDict["Buy"];
            bool Rent = (bool)FilterDict["Rent"];
            return Rent ? (Rent && !Buy) : false;
        }

        public static Boolean ShowBuyPlusRent()
        {
            bool Buy = (bool)FilterDict["Buy"];
            bool Rent = (bool)FilterDict["Rent"];
            return Buy == Rent;
        }
    }
}
