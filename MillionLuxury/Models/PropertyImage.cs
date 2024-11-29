using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MillionLuxury.Models
{
  public class PropertyImage
  {
    [BsonElement("idPropertyImage")]
    public int IdPropertyImage { get; set; }

    [BsonElement("file")]
    public string? File { get; set; }

    [BsonElement("enabled")]
    public bool Enabled { get; set; }
  }
}
