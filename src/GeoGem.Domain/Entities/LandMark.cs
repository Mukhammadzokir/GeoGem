using GeoGem.Domain.Commons;

namespace GeoGem.Domain.Entities;

public class LandMark : Auditable
{
    public long CityId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl {  get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
