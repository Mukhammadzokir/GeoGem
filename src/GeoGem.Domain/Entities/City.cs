using GeoGem.Domain.Commons;

namespace GeoGem.Domain.Entities;

public class City : Auditable
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
