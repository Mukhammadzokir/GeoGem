using GeoGem.Service.DTOs.Cities;

namespace GeoGem.Service.Interfaces;

public interface ICityService
{
    public Task<List<CityForResultDto>> GetAllAsync();
    public Task<bool> RemoveAsync(long id);
    public Task<CityForResultDto> GetByIdAsync(long id);
    public Task<CityForResultDto> UpdateAsync(CityForUpdateDto dto);
    public Task<CityForResultDto> CreateAsync(CityForCreationDto dto);
}
