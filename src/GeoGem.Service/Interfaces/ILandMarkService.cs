using GeoGem.Service.DTOs.LandMarks;

namespace GeoGem.Service.Interfaces;

public interface ILandMarkService
{
    public Task<List<LandMarkForResultDto>> GetAllAsync();
    public Task<bool> RemoveAsync(long id);
    public Task<LandMarkForResultDto> GetByIdAsync(long id);
    public Task<LandMarkForResultDto> UpdateAsync(LandMarkForUpdateDto dto);
    public Task<LandMarkForResultDto> CreateAsync(landMarkCreationDto dto);
}
