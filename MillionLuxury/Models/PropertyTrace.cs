using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MillionLuxury.Models
{
  public class PropertyTrace
  {
    [BsonElement("idPropertyTrace")]
    public int IdPropertyTrace { get; set; }

    [BsonElement("dateSale")]
    public DateTime DateSale { get; set; }

    [BsonElement("name")]
    public string? Name { get; set; }

    [BsonElement("value")]
    public double Value { get; set; }

    [BsonElement("tax")]
    public double Tax { get; set; }
  }
}
