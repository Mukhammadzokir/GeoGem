namespace GeoGem.Service.DTOs.Cities;

public class CityForResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime CraetedAt { get; set; }
}
