using GeoGem.Domain.Commons;

namespace GeoGem.Domain.Entities;

public class Ticket : Auditable
{
    public long LandMarkId {  get; set; }
    public double FlightDuration {  get; set; }

    public DateTime FlightTime {  get; set; }
    public decimal Price { get; set; }
}
