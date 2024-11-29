using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MillionLuxury.Data;
using MillionLuxury.Services;
using MongoDB.Driver;

namespace MillionLuxury.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PropertyController : ControllerBase
  {
    private readonly IPropertyService _propertyService;

    public PropertyController(IPropertyService propertyService)
    {
      _propertyService = propertyService;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] string? propertyName, [FromQuery] string? address, [FromQuery] double? minPrice, [FromQuery] double? maxPrice)
    {
      return Ok(_propertyService.GetAll( propertyName, address, minPrice, maxPrice ));
    }

  }
}
