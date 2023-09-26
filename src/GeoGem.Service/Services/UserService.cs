using GeoGem.Data.IRepositories;
using GeoGem.Data.Repositories;
using GeoGem.Domain.Entities;
using GeoGem.Service.DTOs.Users;
using GeoGem.Service.Exceptions;
using GeoGem.Service.Interfaces;

namespace GeoGem.Service.Services;

public class UserService : IUserService
{
    private long _id;
    private readonly IRepository<User> userRepository = new Repository<User>();
    public async Task<UserForResultDto> CreateAsync(UserForCreationDto dto)
    {
        var user = (await userRepository.SelectAllAsync())
            .FirstOrDefault(u => u.Email.ToLower() == dto.Email.ToLower());
        if (user != null)
            throw new GeoGemException(409, "User is already exist");

        await GenerateIdAsync();

        User person = new User()
        {
            Id = _id,
            Name = dto.Name,
            Email = dto.Email,
            Password = dto.Password,
            Balance = dto.Balance,
            CreatedAt = DateTime.UtcNow,
        };

        await userRepository.InsertAsync(person);

        var result = new UserForResultDto()
        {
            Id = _id,
            Name = person.Name,
            Email = person.Email,
            Password = person.Password,
            Balance = person.Balance,
        };

        return result;
    }

    public async Task<List<UserForResultDto>> GetAllAsync()
    {
        List<User> users = await userRepository.SelectAllAsync();
        List<UserForResultDto> mappedUsers = new List<UserForResultDto>();

        foreach (var user in users)
        {
            var item = new UserForResultDto()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Balance = user.Balance,
            };
            mappedUsers.Add(item);
        }
        return mappedUsers;
    }

    public async Task<UserForResultDto> GetByIdAsync(long id)
    {
        var user = await userRepository.SelectByIdAsync(id);
        if (user == null)
            throw new GeoGemException(404, "User is not found");

        var result = new UserForResultDto()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
            Balance = user.Balance,
        };

        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await userRepository.SelectByIdAsync(id);
        if (user == null)
            throw new GeoGemException(404, "User is not found");

        await userRepository.DeleteAsync(id);

        return true;
    }

    public async Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto)
    {
        var user = await userRepository.SelectByIdAsync(dto.Id);
        if (user == null)
            throw new GeoGemException(404, "User is not found");

        var meppedUser = new User()
        {
            Id = dto.Id,
            Name = dto.Name,
            Email = dto.Email,
            Password = dto.Password,
            Balance = dto.Balance,
            UpdatedAt = DateTime.UtcNow
        };

        await userRepository.UpdateAsync(meppedUser);

        var result = new UserForResultDto()
        {
            Id = meppedUser.Id,
            Name = meppedUser.Name,
            Email = meppedUser.Email,
            Password = meppedUser.Password,
            Balance = meppedUser.Balance,
        };

        return result;
    }

    public async Task GenerateIdAsync()
    {
        var users = await userRepository.SelectAllAsync();
        if (users.Count == 0)
        {
            this._id = 1;
        }
        else
        {
            var user = users[users.Count() - 1];
            this._id = ++user.Id;
        }
    }
}
