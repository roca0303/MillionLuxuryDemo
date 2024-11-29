namespace MillionLuxury.Models.Dtos
{
  public class PropertyDto
  {
    public string? Id { get; set; }
    public int IdOwner { get; set; }
    public string? OwnerName { get; set; }
    public string? PropertyName { get; set; }
    public string? PropertyAddress { get; set; }
    public double? Price { get; set; }
    public string? Image { get; set; }

  }
}
