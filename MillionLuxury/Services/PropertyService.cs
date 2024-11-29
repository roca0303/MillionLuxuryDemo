
using MillionLuxury.Data;
using MillionLuxury.Models;
using MillionLuxury.Models.Dtos;
using MongoDB.Driver;

namespace MillionLuxury.Services
{
  public class PropertyService : IPropertyService
  {
    private readonly IMongoCollection<Property> _properties;
    private readonly IMongoCollection<Owner> _owners;

    public PropertyService(MongoDbService mongoDbService)
    {
      _properties = mongoDbService.Database.GetCollection<Property>("properties");
      _owners = mongoDbService.Database.GetCollection<Owner>("owners");
    }

    public void Add(Property property)
    {
      throw new NotImplementedException();
    }

    public void Delete(int id)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<PropertyDto> GetAll(string? propertyName = null, string? address = null, double? minPrice = null, double? maxPrice = null)
    {
      // Get all properties in mongo
      var properties = _properties.Find(property => true).ToList();


      // Apply filters
      if (!string.IsNullOrEmpty(propertyName))
      {
        properties = properties.Where(p => p.Name.Contains(propertyName, StringComparison.OrdinalIgnoreCase)).ToList();
      }

      if (!string.IsNullOrEmpty(address))
      {
        properties = properties.Where(p => p.Address.Contains(address, StringComparison.OrdinalIgnoreCase)).ToList();
      }

      if (minPrice.HasValue)
      {
        properties = properties.Where(p => p.Price >= minPrice.Value).ToList();
      }

      if (maxPrice.HasValue)
      {
        properties = properties.Where(p => p.Price <= maxPrice.Value).ToList();
      }

      // For each property map it to a PropertyDto
      var propertyDtos = properties.Select(property =>
      {

        var owner = _owners.Find(o => o.Id == property.OwnerId).ToList();

        return new PropertyDto
        {
          Id = property.Id,
          IdOwner = property.OwnerId,
          OwnerName = owner.FirstOrDefault()?.Name,
          PropertyName = property.Name,
          PropertyAddress = property.Address,
          Price = property.Price,
          Image = property.Images?.FirstOrDefault(img => img.Enabled)?.File?.ToString() ?? "default-image-url.jpg"
        };
        
      });

      return propertyDtos;

    }

    public Property GetById(int id)
    {
      throw new NotImplementedException();
    }

    public void Update(Property property)
    {
      throw new NotImplementedException();
    }

  }
}
