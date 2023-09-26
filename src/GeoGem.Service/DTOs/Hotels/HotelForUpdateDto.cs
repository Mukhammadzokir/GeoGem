namespace GeoGem.Service.DTOs.Hotels;

public class HotelForUpdateDto
{
    public long Id { get; set; }
    public long LandMarkId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int NumberOfRoom { get; set; }
}
