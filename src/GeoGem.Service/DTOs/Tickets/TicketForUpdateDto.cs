namespace GeoGem.Service.DTOs.Tickets;

public class TicketForUpdateDto
{
    public long Id { get; set; }
    public long LandMarkId { get; set; }
    public int FlightDuration { get; set; }
    public decimal Price { get; set; }
} 
