namespace GeoGem.Service.DTOs.Tickets;

public class TicketForCreationDto
{
    public long LandMarkId { get; set; }
    public double FlightDuration { get; set; }
    public DateTime FlightTime { get; set; }
    public decimal Price { get; set; }
}
