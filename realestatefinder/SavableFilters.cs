using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace realestatefinder
{
    public class SavableFilters
    {
        public Dictionary<String, object> FilterDict;

        public SavableFilters()
        {
            FilterDict = new Dictionary<String, object>(Filters.FilterDict);
        }

        // saves a set of filters to an xml file
        public void SaveFilters(string fileName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(typeof(item[]), new XmlRootAttribute() { ElementName = "FilterItems"});
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.Serialize(stream, FilterDict.Select(kv=>new item() {key = kv.Key,value=kv.Value.ToString() }).ToArray());
                stream.Position = 0;
                xmlDocument.Load(stream);
                xmlDocument.Save("SavedFilters/" + fileName);
            }
        }

        // reads a set of filters back from a file
        public void ReadFilters(string savename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(item[]), new XmlRootAttribute() { ElementName = "FilterItems" });
            using (FileStream stream = new FileStream("SavedFilters/" + savename + ".xml", FileMode.Open))
            {
                this.FilterDict = ((item[])serializer.Deserialize(stream)).ToDictionary(i => i.key, i => (object)i.value);
            }
        }

        // saves a set of filters to an xml file
        public void SaveListings(string fileName, List<int> listings)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(typeof(item[]), new XmlRootAttribute() { ElementName = "SavedListings" });
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.Serialize(stream, listings.Select(kv => new item() { key = "listingId", value = kv.ToString() }).ToArray());
                stream.Position = 0;
                xmlDocument.Load(stream);
                xmlDocument.Save(fileName);
            }
        }
        
        // reads a set of filters back from a file
        public void ReadListings(string savename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(item[]), new XmlRootAttribute() { ElementName = "SavedListings" });
            using (FileStream stream = new FileStream(savename, FileMode.Open))
            {
                List<int> listings = new List<int>();
                foreach ( item i in ((item[])serializer.Deserialize(stream)))
                {
                    listings.Add(Convert.ToInt32(i.value));
                }
                foreach (Pin pin in PinCollection.pins)
                {
                    if (pin.GetType() == typeof(ListingPin))
                    {
                        if (listings.Contains(((ListingPin)pin).listing.ID))
                        {
                            ((ListingPin)pin).listing.Saved = true;
                        }
                    }
                }
            }
        }
    }

    public class item
    {
        [XmlAttribute]
        public string key;
        [XmlAttribute]
        public string value;
    }
}
