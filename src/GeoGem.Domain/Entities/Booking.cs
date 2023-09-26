using GeoGem.Domain.Commons;

namespace GeoGem.Domain.Entities;

public class Booking : Auditable
{
    public long UserId { get; set; }
    public long TicketId { get; set; }
    public long HotelId { get; set; }
    public long LandMarkId { get; set; }
}
