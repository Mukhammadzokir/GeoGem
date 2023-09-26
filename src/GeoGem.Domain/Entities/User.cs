using GeoGem.Domain.Commons;

namespace GeoGem.Domain.Entities;

public class User : Auditable
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public decimal Balance { get; set; }
}
