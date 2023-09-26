using GeoGem.Domain.Commons;

namespace GeoGem.Domain.Entities;

public class Ticket : Auditable
{
    public long LandMarkId {  get; set; }
    public int FlightDuration {  get; set; }
    public decimal Price { get; set; }
}
