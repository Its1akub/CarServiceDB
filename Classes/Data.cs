using System.Xml.Serialization;

namespace CarServiceDB.Classes;

[XmlRoot("Data")]
public class Data
{
    [XmlArray("Customers"), XmlArrayItem("Customer")]
    public List<Customer>? Customers { get; set; }

    [XmlArray("Vehicles"), XmlArrayItem("Vehicle")]
    public List<Vehicle>? Vehicles { get; set; }
}