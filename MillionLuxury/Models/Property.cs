using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MillionLuxury.Models
{
  public class Property
  {
    [BsonId]
    [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name")]
    public string? Name { get; set; }

    [BsonElement("address")]
    public string? Address { get; set; }

    [BsonElement("price")]
    public double Price { get; set; }

    [BsonElement("codeInternal")]
    public string? CodeInternal { get; set; }

    [BsonElement("year")]
    public int Year { get; set; }

    [BsonElement("ownerId")]
    public int OwnerId { get; set; }

    [BsonElement("images")]
    public List<PropertyImage>? Images { get; set; }

    [BsonElement("traces")]
    public List<PropertyTrace>? Traces { get; set; }
  }
}