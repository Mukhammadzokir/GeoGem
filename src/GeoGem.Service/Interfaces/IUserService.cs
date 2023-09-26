using GeoGem.Service.DTOs.Users;

namespace GeoGem.Service.Interfaces;

public interface IUserService
{
    public Task<List<UserForResultDto>> GetAllAsync();
    public Task<bool> RemoveAsync(long id);
    public Task<UserForResultDto> GetByIdAsync(long id);
    public Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto);
    public Task<UserForResultDto> CreateAsync(UserForCreationDto dto);
}
