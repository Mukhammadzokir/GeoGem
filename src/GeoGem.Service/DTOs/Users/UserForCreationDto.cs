namespace GeoGem.Service.DTOs.Users;

public class UserForCreationDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public decimal Balance { get; set; }
}
