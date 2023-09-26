namespace GeoGem.Service.DTOs.LandMarks;

public class LandMarkForCreationDto
{
    public long CityId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
