namespace GeoGem.Service.DTOs.LandMarks;

public class LandMarkForResultDto
{
    public long Id { get; set; }
    public long CityId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime CreatedAt { get; set; }
}
