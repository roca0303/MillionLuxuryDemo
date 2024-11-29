using MillionLuxury.Models;
using MillionLuxury.Models.Dtos;

namespace MillionLuxury.Services
{
  public interface IPropertyService
  {
    IEnumerable<PropertyDto> GetAll(string? propertyName = null, string? address = null, double? minPrice = null, double? maxPrice = null);
    Property GetById(int id);
    void Add(Property property);
    void Update(Property property);
    void Delete(int id);

  }
}
