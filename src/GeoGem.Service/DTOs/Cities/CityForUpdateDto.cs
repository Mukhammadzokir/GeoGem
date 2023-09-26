namespace GeoGem.Service.DTOs.Cities;

public class CityForUpdateDto
{
    public long Id {  get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
