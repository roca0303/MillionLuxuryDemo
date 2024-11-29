using Microsoft.AspNetCore.Mvc;
using MillionLuxury.Controllers;
using MillionLuxury.Models.Dtos;
using MillionLuxury.Services;
using Moq;

namespace MillionLuxuryUnitTest
{
  public class UnitTest1
  {
    [Fact]
    public void Test1()
    {

    }
  }

  public class ProductsControllerTests
  {
    private readonly Mock<IPropertyService> _mockProductService;
    private readonly PropertyController _controller;

    public ProductsControllerTests()
    {
      _mockProductService = new Mock<IPropertyService>();
      _controller = new PropertyController(_mockProductService.Object);
    }

    [Fact]
    public void GetProducts_ReturnsOkResult_WithListOfProducts()
    {

      var mockProperties = new List<PropertyDto>
      {
        new PropertyDto { Id = "1", IdOwner = 2, PropertyAddress = "casa", Image = "casa1", OwnerName = "dueño 1", PropertyName = "Siper casa",  Price = 50000 },
        new PropertyDto { Id = "1", IdOwner = 2, PropertyAddress = "casa", Image = "casa1", OwnerName = "dueño 1", PropertyName = "Siper casa",  Price = 50000 },
      };

      _mockProductService.Setup(service => service.GetAll(null, null, null, null)).
        Returns((IEnumerable<MillionLuxury.Models.Dtos.PropertyDto>)mockProperties);

      var result = _controller.Get(null, null, null, null);

      var okResult = Assert.IsType<OkObjectResult>(result);

      // We sure for type of return value
      var returnValue = Assert.IsAssignableFrom<IEnumerable<PropertyDto>>(okResult.Value);

      // Verify that mockProperties was called and returned the same number of elements
      Assert.Equal(mockProperties.Count, returnValue.Count());
    }
  }
}