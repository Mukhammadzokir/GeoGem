using GeoGem.Domain.Commons;

namespace GeoGem.Domain.Entities;

public class Hotel : Auditable
{
    public long LandMarkId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int NumberOfRoom { get; set; }
}
