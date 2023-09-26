
using GeoGem.Service.Exceptions;

namespace GeoGem.Service.Services;

public class AuthenticationService
{
    public async Task<int> AuthoriseAsync(string email, string password)
    {
        var chechAdminEmail = "meniki";
        var checkAdminPassword = "topomisan";

        UserService userService = new UserService();

        var getAllUsers = await userService.GetAllAsync();

        var checkUser = getAllUsers.FirstOrDefault(u => u.Email == email && u.Password == password);
        if(checkUser == null)
        {
            if( email == chechAdminEmail &&  password == checkAdminPassword )
            {
                return 1;
            }
            return 2;
        }
        return 3;
    }
}
